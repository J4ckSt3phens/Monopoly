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
        public Board()
        {
            string[] SquareData = Utilities.GetFileLines(Constants.BoardDataFilePath);
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
        }
        public List<Square> Squares
        {
            get
            {
                return _squares;
            }
        }

    }
}
