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
        }
        public int Position
        {
            get
            {
                return _position;
            }
        }

        public void Roll()
        {
            int newPosition = _position;
            newPosition += Utilities.GetRandomNumber(1, 6) + Utilities.GetRandomNumber(1, 6);
            if (newPosition > 31)
            {
                _position = newPosition - 31;
            } else
            {
                _position = newPosition;
            }
            Console.WriteLine(_position);
        }
    }
}
