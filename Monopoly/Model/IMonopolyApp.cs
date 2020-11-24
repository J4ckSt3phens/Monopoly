using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Model
{
    public interface IMonopolyApp
    {
        Board Board { get; }

        Player CurrentPlayer { get; }

        List<Player> Players { get; }

        void NextTurn();
    }
}
