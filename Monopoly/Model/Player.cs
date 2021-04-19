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
        private int _balance;
        private System.Drawing.Color _color;
        private bool _bankrupt = false;

        private List<Property> _props = new List<Property>();

        public Player(string name, int balance, System.Drawing.Color color)
        {
            _position = 0;
            _name = name;
            _balance = balance;
            _color = color;
        }

        public int Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                if (value < 0)
                {
                    value = this.AutoSell(value);
                }
                _balance = value;
            }
        }

        public bool Bankrupt
        {
            get
            {
                return _bankrupt;
            }
        }

        public System.Drawing.Color Color
        {
            get
            {
                return _color;
            }
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
                    _balance += 100;
                } else
                {
                   _position = value;
                }
            }
        }

        public List<Property> Props
        {
            get
            {
                return _props;
            }

            set
            {
                 _props = value;
            }
        }

        public void BuyProperty(Property prop)
        {
            Balance = Balance - prop.BuyPrice;
            prop.Owner = this;
            Props.Add(prop);
        }

        private int AutoSell(int balance)
        {
            _props.Sort((x, y) => y.Rent.CompareTo(x.Rent));
            for (int i = _props.Count - 1; i >= 0; i--)
            {
                Property p = _props.ElementAt(i);
                p.Owner = null;
                this._props.Remove(p);
                balance = balance + p.SellPrice;
                if (balance > 0)
                {
                    return balance;
                }
            }
            this._bankrupt = true;
            return balance;
        }
    }
}
