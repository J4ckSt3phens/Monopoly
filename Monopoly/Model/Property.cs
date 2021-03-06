﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Model
{
    public class Property : Square
    {


        String _groupName = "";
        private int BASE_RENT;
        Player _owner;
        private int _buyPrice;
        private int _sellPrice;
        private int _upgradeTier = 1;

        public Property(string name, string type, string groupName, int buyPrice) : base(name, type)
        {
            BASE_RENT = (int)(buyPrice * 0.25);
            _groupName = groupName;
            _buyPrice = buyPrice;
            _owner = null; 
        }

        public string GroupName
        {
            get { return _groupName; }
        }

        public Player Owner
        {
            get { return _owner; }

            set { _owner = value; }
        }

        public int BuyPrice
        {
            get { return _buyPrice; }
            set { _buyPrice = value; }
        }

        public int SellPrice
        {
            get { return _sellPrice; }
            set { _sellPrice = value; }
        }

        public int Rent
        {
            get { return BASE_RENT*_upgradeTier; }
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
