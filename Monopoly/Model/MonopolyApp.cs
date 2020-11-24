using System;
using System.Collections.Generic;
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

        public MonopolyApp(List<String> playerNames)      
        {
            _board = new Board();
            _players = new List<Player>(1);
            foreach (String playerName in playerNames)
            {
                _players.Add(new Player(playerName));
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
