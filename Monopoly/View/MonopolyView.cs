using Monopoly.Model;
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

namespace Monopoly
{
    public partial class MonopolyView : MonopolyForm, IMonopolyView
    {
        private MonopolyPresenter _presenter = null;
        private readonly MonopolyApp _gameApp;
        public MonopolyView(MonopolyApp gameApp)
        {
            _gameApp = gameApp;
            _presenter = new MonopolyPresenter(this, _gameApp);
            this.RollButton.Click += new EventHandler(rollButton_Click);
            ShowMonopolyData();
        }

        public Board BoardUI
        { 
            set
            {
                int count = 0;
                foreach (Square s in value.Squares)
                {
                    Button squareUI = UISquares.ElementAt(count);
                    count += 1;
                    squareUI.Text = s.Name;
                    if (s.Type == "Property")
                    {
                        Property p = (Property)s;
                        switch (p.GroupName)
                        {
                            case "Spain":
                                squareUI.BackColor = Color.CornflowerBlue;
                                break;
                            case "China":
                                squareUI.BackColor = Color.Pink;
                                break;
                            case "Italy":
                                squareUI.BackColor = Color.SpringGreen;
                                break;
                            case "Germany":
                                squareUI.BackColor = Color.DarkOrange;
                                break;
                            case "BE":
                                squareUI.BackColor = Color.MediumOrchid;
                                break;
                            case "USA":
                                squareUI.BackColor = Color.Blue;
                                break;
                            case "France":
                                squareUI.BackColor = Color.DarkGreen;
                                break;
                            case "Japan":
                                squareUI.BackColor = Color.Red;
                                break;
                            default:
                                break;
                        }
                    }
                    squareUI.Refresh();
                }
            }
        }

        public List<Player> PlayersUI
        {
            set
            {
                foreach (Player p in value)
                {
                    foreach (Label l in UIPlayers)
                    {
                        if (p.Name == l.Text)
                        {
                            l.Location = UISquares.ElementAt(p.Position).Location;
                        }
                        Console.WriteLine(l.Location);
                        l.Refresh();
                    }
                }
            }
        }

        private void rollButton_Click(object sender, EventArgs e)
        {
            _presenter.Roll();
            this.ShowMonopolyData();
        }

        public void ShowMonopolyData()
        {
            _presenter.SetBoardUI();
            _presenter.SetPlayersUI();

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MonopolyView
            // 
            this.ClientSize = new System.Drawing.Size(1264, 718);
            this.Name = "MonopolyView";
            this.ResumeLayout(false);

        }
    }   
        
}
