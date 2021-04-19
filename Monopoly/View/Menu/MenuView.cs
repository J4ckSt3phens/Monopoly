using Monopoly.Model;
using Monopoly.Properties;
using Monopoly.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly.View.Menu
{
    public partial class MenuView : MenuForm, IMenuView
    {

        public MenuView()
        {
            this.Resize += new EventHandler(update_Resize);
        }

        private void update_Resize(object sender, System.EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MenuView
            // 
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Name = "MenuView";
            this.ResumeLayout(false);

        }
    }   
        
}
