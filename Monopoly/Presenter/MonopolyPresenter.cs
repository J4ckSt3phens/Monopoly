using Monopoly;
using Monopoly.Model;
using Monopoly.View.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly 
{
    public class MonopolyPresenter : IMonopolyPresenter
    {
        private IMonopolyView _monopolyView;
        private IMonopolyApp _monopolyApp;

        public MonopolyPresenter(IMonopolyView monopolyView, IMonopolyApp monopolyApp)
        {
            _monopolyView = monopolyView;
            _monopolyApp = monopolyApp;
        }

        public void SetBoardUI()
        {
            _monopolyView.BoardUI = _monopolyApp.Board;
        }
        public void SetPlayersUI()
        {
            _monopolyView.PlayersUI = _monopolyApp.Players;
        }
        public void Roll()
        {
            int move = _monopolyApp.Board.RollDice();
            if (_monopolyApp.Board.Squares.ElementAt(_monopolyApp.CurrentPlayer.Position).Name == "Jail")
            {
                if (_monopolyApp.Board.Die1 == _monopolyApp.Board.Die2)
                {
                    _monopolyApp.CurrentPlayer.Position += move;
                }
            }
            else
            {
                _monopolyApp.CurrentPlayer.Position += move;
            }
        }

        public void Buy()
        {
            _monopolyApp.BuyProperty();
        }

        public void Pay(int debt)
        {
            _monopolyApp.CurrentPlayer.Balance = _monopolyApp.CurrentPlayer.Balance - debt;
        }

        public void PayRent()
        {
            _monopolyApp.PayRent();
        }

        public void queuePlayerActions()
        {
            _monopolyView.ActionUI = _monopolyApp.QueuePlayerAction();
        }

        public void EndTurn()
        {
            _monopolyApp.NextTurn();
            if (_monopolyApp.Board.Squares.ElementAt(_monopolyApp.CurrentPlayer.Position).Name == "Jail")
            {
                _monopolyView.ActionUI = ("Jail", _monopolyApp.Board.Squares.ElementAt(_monopolyApp.CurrentPlayer.Position));
            }
        }
    }
}
