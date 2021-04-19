using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Model
{
    public class Resort : Square
    {

        private int BASE_RENT;
        private bool _owned;
        private int _buyPrice;
        private int _sellPrice;
        private int _rent;
        private int _upgradeTier = 0;

        public Resort(string name, string type, int rent) : base(name, type)
        {
            BASE_RENT = rent;
            _owned = false; 
        }

        public bool Owned
        {
            get { return _owned; }

            set { _owned = value; }
        }

        public int BuyPrice
        {
            get { return _buyPrice; }
            set { _buyPrice = value;  }
        }

        public int SellPrice
        {
            get { return _sellPrice; }
            set { _sellPrice = value; }
        }

        public int Rent
        {
            get { return _rent; }
            set { _rent = value; }
        }

        public int UpgradeTier
        {
            get { return _upgradeTier; }
            set
            { 
                if (_upgradeTier < 3)
                {
                    _upgradeTier += 1;
                }
            }
        }
    }
}
