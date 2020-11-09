using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public interface IMonopolyPresenter
    {
        void SetBoardUI();
        void SetPlayersUI();
        void Roll();
    }
}
