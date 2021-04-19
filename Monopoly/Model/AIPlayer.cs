using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly.Model
{
    public class AIPlayer : Player, IPlayer
    {
        private int _difficulty;

        private enum Difficulties { EASY, NORMAL, HARD };

        private List<Property> _props;

        public AIPlayer(string name, int balance, Color color, int difficulty) : base(name, balance, color)
        {
            _difficulty = difficulty;
        }

        public bool BuyProperty(MonopolyApp game, Property prop)
        {
            switch (_difficulty)
            {
                case (int)Difficulties.EASY:
                    if (prop.BuyPrice < this.Balance)
                    {
                        return true;
                    } else
                    {
                        return false;
                    }
                case (int)Difficulties.NORMAL:
                    if (prop.BuyPrice < this.Balance)
                    {
                        if (prop.BuyPrice < (int)(0.4 * this.Balance))
                        {
                            return true;
                        } else
                        {
                            if (_props.Exists(x => x.GroupName == prop.GroupName))
                            {
                                return true;
                            }
                            foreach (Player player in game.Players)
                            {
                                if (player != this && player.Props.Exists(x => x.GroupName == prop.GroupName))
                                {
                                    return true;
                                }
                            }
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return true;
            }
        }

        public void SellProperty(int debt)
        {
            switch (_difficulty)
            {
                case (int) Difficulties.EASY:
                    foreach (Property p in _props)
                    {
                        if (p.SellPrice > debt)
                        {
                            p.Owner = null;
                            this._props.Remove(p);
                            base.Balance = base.Balance + p.SellPrice;
                        }
                    }
                    break;
                case (int)Difficulties.NORMAL:
                    _props.Sort((x, y) => x.Rent.CompareTo(y.Rent));
                    foreach (Property p in _props)
                    {
                        p.Owner = null;
                        this._props.Remove(p);
                        base.Balance = base.Balance + p.SellPrice;
                        if (base.Balance - debt > 0)
                        {
                            break;
                        }
                    }
                    break;
                default:
                    foreach (Property p in _props)
                    {
                        if (p.SellPrice > debt)
                        {
                            base.Balance = base.Balance + p.SellPrice;
                        }
                    }
                    break;
            }
        }
    }
}
