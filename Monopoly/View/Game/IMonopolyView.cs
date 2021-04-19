using Monopoly.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.View.Game
{
    public interface IMonopolyView
    {
        Board BoardUI { set; }

        List<Player> PlayersUI { set; }

        (string, Square) ActionUI { set;  }

    }
}
