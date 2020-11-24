using Monopoly.Model;
using System;
using System.Collections.Generic;
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
            List<string> players = new List<string>(1);
            players.Add("P1");
            players.Add("P2");
            players.Add("P3");
            players.Add("P4");
            Application.Run(new MonopolyView(new MonopolyApp(players)));
        }
    }
}
