using System;
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
        public Property(string name, string type, string groupName) : base(name, type)
        {
            _groupName = groupName;
            
        }

        public string GroupName
        {
            get { return _groupName; }
        }
    }
}
