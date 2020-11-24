using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly.Model
{
    public class Player : IPlayer
    {
        private int _position;
        private string _name;

        public Player(string name)
        {
            _position = 0;
            _name = name;
        }


        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public int Position
        {
            get
            {
                return _position;
            }
            set
            {
                if (value > 31)
                {
                    _position = value - 31;
                } else
                {
                   _position = value;
                }
            }
        }
    }
}
