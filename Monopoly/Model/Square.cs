using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Model
{
    public class Square
    {
        private string _name;
        private string _type;
        public Square(string name, string type)
        {
            _name = name;
            _type = type;
        }
        

        public string Name
        {
            get { return _name; }
        }

        public string Type
        {
            get { return _type;  }
        }
    }
}
