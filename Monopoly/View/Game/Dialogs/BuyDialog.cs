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
    public partial class BuyDialog : Form
    {
        private Button _buy = new Button();
        private Button _pass = new Button();
        private PrivateFontCollection pfc;

        private Label _action = new Label();

        private Property _prop;

        private RadioButton r1 = new RadioButton(), r2 = new RadioButton(), r3 = new RadioButton() , r4 = new RadioButton(), r5 = new RadioButton();

        private List<RadioButton> upgrades = new List<RadioButton>();

        public Button Buy
        {
            get
            {
                return _buy;
            }

            set
            {
                _buy = value;
            }
        }

        public Button Pass
        {
            get
            {
                return _pass;
            }

            set
            {
                _pass = value;
            }
        }

        public BuyDialog(Property p)
        {
            _prop = p;
            this.MaximumSize = new Size(400,300);
            this.Text = "Buy";
            this.SetupFont();
            this.SetupLabel();
            upgrades.Add(r1);
            upgrades.Add(r2);
            upgrades.Add(r3);
            upgrades.Add(r4);
            upgrades.Add(r5);
            this.SetupUpgradeButtons();
            this.SetupButton();
            this.Refresh();
            InitializeComponent();
        }

        private void SetupButton()
        {

            _pass.Font = new Font(pfc.Families[0], 12);
            _pass.UseCompatibleTextRendering = true;
            _buy.Font = new Font(pfc.Families[0], 12);
            _buy.UseCompatibleTextRendering = true;
            _buy.Text = "Buy";
            _pass.Text = "Pass";
            _buy.Visible = true;
            _pass.Visible = true;
            _buy.Dock = DockStyle.Bottom;
            _pass.Dock = DockStyle.Bottom;
            this.Controls.Add(_buy);
            this.Controls.Add(_pass);
        }

        private void SetupLabel()
        {
            _action.Font = new Font(pfc.Families[0], 12);
            _action.TextAlign = ContentAlignment.MiddleCenter;
            _action.Text = "Would you like to buy property: " + _prop.Name + " for " + _prop.BuyPrice.ToString() + "?";
            _action.UseCompatibleTextRendering = true;
            _action.Visible = true;
            _action.Dock = DockStyle.Fill;
            _action.Refresh();
            this.Controls.Add(_action);
        }

        private void SetupUpgradeButtons()
        {
            int count = 2;
            foreach (RadioButton r in upgrades)
            {
                if (count != 6)
                {
                    r.Text = (count-1).ToString() + " House(s)";
                    if (count > _prop.UpgradeTier)
                    {
                        r.Enabled = true;
                    } else
                    {
                        r.Enabled = false;
                    }
                }
                else
                {
                    r.Text = "Hotel";
                    if (_prop.UpgradeTier != 5)
                    {
                        r.Enabled = false;
                    } 
                }
                r.TextAlign = ContentAlignment.MiddleCenter;
                r.Font = new Font(pfc.Families[0], 12);
                r.Visible = true;
                r.UseCompatibleTextRendering = true;
                r.Refresh();
                r.Dock = DockStyle.Bottom;
                this.Controls.Add(r);
                count += 1;
            }
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
