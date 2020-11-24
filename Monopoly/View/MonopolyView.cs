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

namespace Monopoly
{
    public partial class MonopolyView : MonopolyForm, IMonopolyView
    {
        private MonopolyPresenter _presenter = null;
        private readonly MonopolyApp _gameApp;
        private bool isRolling = false;
        public MonopolyView(MonopolyApp gameApp)
        {
            _gameApp = gameApp;
            _presenter = new MonopolyPresenter(this, _gameApp);
            this.RollButton.Click += new EventHandler(RollButton_Click);
            this.EndTurnButton.Click += new EventHandler(EndTurnButton_Click);
            ShowMonopolyData();
        }

        public Board BoardUI
        { 
            set
            {
                int count = 0;
                foreach (Square s in value.Squares)
                {
                    Panel squareUI = UISquares.ElementAt(count);
                    count += 1;
                    PictureBox propertyImage;
                    Label propertyName;
                    foreach (Control c in squareUI.Controls)
                    {
                        if (c.Name == "propertyName")
                        {
                            propertyName = (Label)c;
                            propertyName.Text = s.Name;
                        }
                        if (c.Name == "propertyImage")
                        {
                            propertyImage = (PictureBox)c;
                            if (s.Type == "Property")
                            {
                                Property p = (Property)s;
                                switch (p.GroupName)
                                {
                                    case "Spain":
                                        propertyImage.Image = new Bitmap(Resources.spain, new Size(squareUI.Width, squareUI.Height)); ;
                                        break;
                                    case "China":
                                        propertyImage.Image = new Bitmap(Resources.china, new Size(squareUI.Width, squareUI.Height)); ;
                                        break;
                                    case "Italy":
                                        propertyImage.Image = new Bitmap(Resources.italy, new Size(squareUI.Width, squareUI.Height)); ;
                                        break;
                                    case "Germany":
                                        propertyImage.Image = new Bitmap(Resources.germany, new Size(squareUI.Width, squareUI.Height)); ;
                                        break;
                                    case "BE":
                                        propertyImage.Image = new Bitmap(Resources.england, new Size(squareUI.Width, squareUI.Height)); ;
                                        break;
                                    case "USA":
                                        propertyImage.Image = new Bitmap(Resources.usa, new Size(squareUI.Width, squareUI.Height)); ;
                                        break;
                                    case "France":
                                        propertyImage.Image = new Bitmap(Resources.france, new Size(squareUI.Width, squareUI.Height)); ;
                                        break;
                                    case "Japan":
                                        propertyImage.Image = new Bitmap(Resources.japan, new Size(squareUI.Width, squareUI.Height)); ;
                                        break;
                                    default:
                                        break;
                                }

                            }
                            else if (s.Type == "Resort")
                            {
                                propertyImage.Image = new Bitmap(Resources.beach, new Size(squareUI.Width, squareUI.Height)); ;
                            }
                            else
                            {
                                switch (s.Name)
                                {
                                    case "Chance":
                                        propertyImage.Image = new Bitmap(Resources.chance, new Size(squareUI.Width, squareUI.Height)); ;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        
                    }
                    squareUI.Refresh();
                }
                animateDice(value.Die1, value.Die2);
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
                            foreach(Panel sq in UISquares)
                            {
                                //if (l.Location.X <= sq.Location.X + sq.Width && l.Location.X >= sq.Location.X
                                   // && l.Location.Y <= sq.Location.Y + sq.Height && l.Location.Y >= sq.Location.Y )
                                if (sq.Controls.IndexOf(l) != -1)
                                {
                                    movePlayerIncrements(l, p, sq);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        async void animateDice(int die1, int die2)
        {
            if (isRolling)
            {
                for (int i = 0; i < 10; i+=1)
                {
                    Die1Value = Utilities.GetRandomNumber(1, 6);
                    Die2Value = Utilities.GetRandomNumber(1, 6);
                    await Task.Delay(100);
                }
                Die1Value = die1;
                Die2Value = die2;
                isRolling = false;
            }
        }

        async void movePlayerIncrements(Label l, Player p, Panel current)
        {
            while(isRolling)
            {
                await Task.Delay(500);
            }
            Panel dest = UISquares.ElementAt(p.Position);
            int currentPos = UISquares.IndexOf(current);
            while (current != dest)
            {
                currentPos += 1;
                if (currentPos == 32)
                {
                    currentPos = 0;
                }
                current.Controls.Remove(l);
                current = UISquares.ElementAt(currentPos);
                current.Controls.Add(l);
                l.BringToFront();
                //l.Location = new Point(s.Location.X + s.Size.Width / 2 - l.Size.Width / 2, s.Location.Y + s.Size.Height / 2);
                l.Refresh();
                await Task.Delay(200);
            }
            this.CalculatePlayerPositions();
        }

        private void RollButton_Click(object sender, EventArgs e)
        {
            RollButton.Visible = false;
            EndTurnButton.Visible = true;
            _presenter.Roll();
            isRolling = true;
            this.ShowMonopolyData();
        }

        private void EndTurnButton_Click(object sender, EventArgs e)
        {
            EndTurnButton.Visible = false;
            _presenter.EndTurn();
            RollButton.Visible = true;
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
