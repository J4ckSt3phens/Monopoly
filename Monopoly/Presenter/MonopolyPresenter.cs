using Monopoly;
using Monopoly.Model;
using Monopoly.View;
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
            _monopolyApp.CurrentPlayer.Position += _monopolyApp.Board.RollDice();
        }

        public void EndTurn()
        {
            _monopolyApp.NextTurn();
        }
    }
}
