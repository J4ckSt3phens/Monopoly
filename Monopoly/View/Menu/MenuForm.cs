using Monopoly.Model;
using Monopoly.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly.View.Menu
{
    public class MenuForm : Form
    {
        private int formHeight = 720;
        private int formWidth = 1280;
        private PrivateFontCollection pfc;

        private int playerCount;
        private ComboBox playersSelection;

        public MenuForm()
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            formHeight = Size.Height;
            formWidth = Size.Width;
            SetupForm();
            SetupFont();
            SetupMenu();
        }

        public void SetupFont()
        {
            pfc = new PrivateFontCollection();

            int fontLength = Resources.MONOPOLY.Length;

            byte[] fontdata = Resources.MONOPOLY;

            IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            Marshal.Copy(fontdata, 0, data, fontLength);

            pfc.AddMemoryFont(data, fontLength);
        }

        private void SetupMenu()
        {
            ComboBox playersSelection = new ComboBox();
            playersSelection.Anchor = AnchorStyles.Top;
            playersSelection.Text = "playersSelection";
            playersSelection.Items.AddRange(new object[] {2,3,4});
            playersSelection.SelectedIndex = 0;
            this.Controls.Add(playersSelection);
            for (int i = 0; i < (int)playersSelection.SelectedItem; i += 1)
            {
                SetupPlayerPanel(i + 1);
            }
        }

        private void SetupPlayerPanel(int playerID)
        {
            Panel playerPanel = new Panel();
            playerPanel.Anchor = AnchorStyles.None;
            playerPanel.Name = string.Concat("player", playerID);
            Label p = new Label();
            p.Text = string.Concat("Player ", playerID);
            playerPanel.Controls.Add(p);
            playerPanel.BackColor = Color.White;
            TextBox n = new TextBox();
            n.Anchor = AnchorStyles.None;
            n.Name = string.Concat("player", playerID, "Name");
            playerPanel.Controls.Add(n);
            this.Controls.Add(playerPanel);
        }

        private void SetupForm()
        {
            this.Text = "Monopoly";
            this.MinimumSize = new Size(1280, 720);
            this.BackColor = Color.LightSkyBlue;
        }

        private void this_Resize(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;
            formHeight = control.Size.Height;
            formWidth = control.Size.Width;
            Refresh();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MenuForm
            // 
            this.ClientSize = new System.Drawing.Size(691, 542);
            this.Name = "MenuForm";
            this.ResumeLayout(false);

        }
    }
}
