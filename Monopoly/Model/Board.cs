using Monopoly.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Model
{
    public class Board
    {
        private List<Square> _squares;
        private int die1;
        private int die2;

        private List<(String,int)> chanceList = new List<(string, int)>();
        public Board()
        {
            string[] SquareData = Utilities.ReadAllResourceLines(Properties.Resources.BoardData);
            _squares = new List<Square>();
            foreach (string data in SquareData)
            {
                string[] square = data.Split(',');
                string type = square[1];
                switch(type)
                {
                    case "Property":
                        _squares.Add(new Property(square[0], square[1], square[2]));
                        break;
                    default:
                        _squares.Add(new Square(square[0], square[1]));
                        break;
                }
            }
            chanceList.Add(("Go to Jail", 40)); 
            chanceList.Add(("Get out of Jail.", 70)); 
            chanceList.Add(("Go to Start", 60)); 
            chanceList.Add(("Go to Free Parking", 60)); 
            chanceList.Add(("Go to World Championships City", 30));
            chanceList.Add(("Pay Tax", 40)); 
            chanceList.Add(("Forced to sell a property to another player.", 20)); 
            chanceList.Add(("Force another player to sell property and receive money.Property now unowned", 30));
            chanceList.Add(("Destroy Property if not hotelled.", 10));
            chanceList.Add(("Power cut(No Rent for 3 Pass goes", 30));
            chanceList.Add(("Destroy House", 35)); 
            chanceList.Add(("Its your Birthday", 70));
            chanceList.Add(("Fined 50k", 70)); 
            chanceList.Add(("50 % off Rent to Pay", 50)); 
            chanceList.Add(("Double Rent to Pay", 40));

        }
        public List<Square> Squares
        {
            get
            {
                return _squares;
            }
        }

        public int Die1
        {
            get
            {
                return die1;
            }
        }

        public int Die2
        {
            get
            {
                return die2;
            }
        }


        public int RollDice() 
        {
            CalcChance();
            die1 = Utilities.GetRandomNumber(1, 6);
            die2 = Utilities.GetRandomNumber(1, 6);
            return die1 + die2;
        }

        void CalcChance()
        {
            int maxValue = 0;
            (String name, int poss) selectedChance = chanceList[0]; ;
            for(int i = 0; i < chanceList.Count; i+=1)
            {
                (String name, int poss) chance = chanceList[i];
                int chanceValue = Utilities.GetRandomNumber(chance.poss, 100);
                if (chanceValue > maxValue)
                {
                    maxValue = chanceValue;
                    selectedChance = chance;
                }
                else if (chanceValue == maxValue)
                {
                    //TODO
                }
            }
            Console.WriteLine(selectedChance.name);
        }

    }
}
