using Monopoly.Model;
using Monopoly.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly.View.Game.Dialogs
{
    public partial class JailDialog : Form
    {
        private Button _roll = new Button();
        private Button _pay = new Button();
        private PrivateFontCollection pfc;

        private Label _action = new Label();

        public Button Roll
        {
            get
            {
                return _roll;
            }

            set
            {
                _roll = value;
            }
        }

        public Button Pay
        {
            get
            {
                return _pay;
            }

            set
            {
                _pay = value;
            }
        }

        public JailDialog()
        {
            this.MaximumSize = new Size(250,200);
            this.SetupFont();
            this.SetupLabel();
            this.SetupButton();
            this.Refresh();
            InitializeComponent();
        }

        private void SetupButton()
        {

            _pay.Font = new Font(pfc.Families[0], 12);
            _pay.UseCompatibleTextRendering = true;
            _roll.Font = new Font(pfc.Families[0], 12);
            _roll.UseCompatibleTextRendering = true;
            _roll.Text = "Roll for Double";
            _pay.Text = "Pay Fee and Roll";
            _roll.Visible = true;
            _pay.Visible = true;
            _roll.Dock = DockStyle.Bottom;
            _pay.Dock = DockStyle.Bottom;
            this.Controls.Add(_roll);
            this.Controls.Add(_pay);
        }

        private void SetupLabel()
        {
            _action.Font = new Font(pfc.Families[0], 12);
            _action.TextAlign = ContentAlignment.MiddleCenter;
            _action.Text = "Would you like to pay Jail fee or roll for double?";
            _action.UseCompatibleTextRendering = true;
            _action.Visible = true;
            _action.Dock = DockStyle.Fill;
            _action.Refresh();
            this.Controls.Add(_action);
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
    }
}
