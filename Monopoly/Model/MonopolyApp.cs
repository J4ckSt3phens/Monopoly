using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Model
{
    public class MonopolyApp : IMonopolyApp
    {
        private Board _board;
        private List<Player> _players;
        private int _currentPlayer;

        private const int STARTING_BALANCE = 1000;

        public MonopolyApp(List<(String, Color)> players)      
        {
            _board = new Board();
            _players = new List<Player>(1);
            foreach ((String, Color) player in players)
            {
                _players.Add(new Player(player.Item1, STARTING_BALANCE, player.Item2));
            }
            _currentPlayer = Utilities.GetRandomNumber(0, _players.Count - 1);
        }

        public Player CurrentPlayer
        {
            get
            {
                return _players.ElementAt(_currentPlayer);
            }
        }

        public Board Board
        {
            get
            {
                return _board;
            }
        }

        public List<Player> Players
        {
            get
            {
                return _players;
            }
        }

        public (string, Square) QueuePlayerAction()
        {
            Square currPos = Board.Squares.ElementAt(Players.ElementAt(_currentPlayer).Position);
            if (currPos.Type == "Property")
            {
                Property prop = (Property)currPos;
                if (prop.Owner != null && CurrentPlayer.Props.Contains(prop))
                {
                    return ("Upgrade", currPos);
                } else if (prop.Owner != null && !CurrentPlayer.Props.Contains(prop))
                {
                    return ("Rent", currPos);
                }
                else if (prop.Owner == null)
                {
                    return ("Buy", currPos);
                }
            }
            return ("None", currPos);
        }

        public void BuyProperty()
        {
            this.CurrentPlayer.BuyProperty((Property)Board.Squares.ElementAt(Players.ElementAt(_currentPlayer).Position));
        }

        public void PayRent()
        {
            Property prop = (Property)Board.Squares.ElementAt(Players.ElementAt(_currentPlayer).Position);
            this.CurrentPlayer.Balance = CurrentPlayer.Balance - prop.Rent;
            if (this.CurrentPlayer.Balance < 0)
            {
                prop.Owner.Balance = prop.Owner.Balance + (this.CurrentPlayer.Balance + prop.Rent);
            }
            else
            {
                prop.Owner.Balance = prop.Owner.Balance + prop.Rent;
            }
        }

        public void NextTurn()
        {
            _currentPlayer += 1;
            if (_currentPlayer == _players.Count)
            {
                _currentPlayer = 0;
            }
        }
    }
}
