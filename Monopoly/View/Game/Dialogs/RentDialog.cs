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
    public partial class RentDialog : Form
    {
        private Button _confirm = new Button();
        private Button _pass = new Button();
        private PrivateFontCollection pfc;

        private Label _action = new Label();

        private int _rent;
        private string _propertyName;
        private string _owner;

        public Button Confirm
        {
            get
            {
                return _confirm;
            }

            set
            {
                _confirm = value;
            }
        }

        public RentDialog(Property p)
        {
            _rent = p.Rent;
            _propertyName = p.Name;
            _owner = p.Owner.Name;
            this.MaximumSize = new Size(250,200);
            this.Text = "Rent";
            this.SetupFont();
            this.SetupLabel();
            this.SetupButton();
            this.Refresh();
            InitializeComponent();
        }

        private void SetupButton()
        {
            _confirm.Font = new Font(pfc.Families[0], 12);
            _confirm.UseCompatibleTextRendering = true;
            _confirm.Text = "Confirm";
            _confirm.Visible = true;
            _confirm.Dock = DockStyle.Bottom;
            this.Controls.Add(_confirm);
        }

        private void SetupLabel()
        {
            _action.Font = new Font(pfc.Families[0], 12);
            _action.TextAlign = ContentAlignment.MiddleCenter;
            _action.Text = "You landed on " + _propertyName + " owned by "+_owner+" and have to pay rent "+ _rent.ToString();
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
