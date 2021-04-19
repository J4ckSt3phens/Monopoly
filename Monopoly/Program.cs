using Monopoly.Model;
using Monopoly.View.Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            List<(string, Color)> players = new List<(string, Color)>(1);
            players.Add(("Mason", Color.Green));
            players.Add(("Anto", Color.Blue));
            players.Add(("Marcus", Color.Red));
            players.Add(("Bruno", Color.Yellow));
            Application.Run(new MonopolyView(new MonopolyApp(players)));
        }
    }
}
