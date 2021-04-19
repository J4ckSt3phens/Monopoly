﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly.Model
{
    public interface IPlayer
    {
        string Name { get; set; }
        int Position { get; set; }
        int Balance { get; set; }
    }
}
