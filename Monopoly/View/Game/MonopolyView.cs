using Monopoly.Model;
using Monopoly.Properties;
using Monopoly.View;
using Monopoly.View.Game.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly.View.Game
{
    public partial class MonopolyView : MonopolyForm, IMonopolyView
    {
        private MonopolyPresenter _presenter = null;
        private readonly MonopolyApp _gameApp;
        private bool isRolling = false;

        private Form currentDialog;
        public MonopolyView(MonopolyApp gameApp)
        {
            _gameApp = gameApp;
            this.Resize += new EventHandler(update_Resize);
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
                        if (c.Name == "squareName")
                        {
                            propertyName = (Label)c;
                            propertyName.Text = s.Name;
                            if (s.Type == "Property")
                            {
                                Property p = (Property)s;

                                if (p.Owner != null)
                                {
                                    propertyName.BackColor = p.Owner.Color;
                                }
                            }
                        }
                        if (c.Name == "squareImage")
                        {
                            propertyImage = (PictureBox)c;
                            if (s.Type == "Property")
                            {
                                Property p = (Property)s;

                                switch (p.GroupName)
                                {
                                    case "Spain":
                                        propertyImage.Image = Utilities.RotateImage(Resources.spain, 270, true, false, Color.Transparent);
                                        break;
                                    case "China":
                                        propertyImage.Image = Utilities.RotateImage(Resources.china, 270, true, false, Color.Transparent);
                                        break;
                                    case "Italy":
                                        propertyImage.Image = new Bitmap(Resources.italy, new Size(squareUI.Width, squareUI.Height));
                                        break;
                                    case "Germany":
                                        propertyImage.Image = new Bitmap(Resources.germany, new Size(squareUI.Width, squareUI.Height)); ;
                                        break;
                                    case "BE":
                                        propertyImage.Image = Utilities.RotateImage(Resources.england, 90, true, false, Color.Transparent);
                                        break;
                                    case "USA":
                                        propertyImage.Image = Utilities.RotateImage(Resources.usa, 90, true, false, Color.Transparent); ;
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
                                    case "Start":
                                        propertyImage.Image = new Bitmap(Resources.go, new Size(squareUI.Width, squareUI.Height));
                                        break;
                                    case "Jail":
                                        propertyImage.Image = new Bitmap(Resources.jail, new Size(squareUI.Width, squareUI.Height));
                                        break;
                                    case "Free Parking":
                                        propertyImage.Image = new Bitmap(Resources.freeparking, new Size(squareUI.Width, squareUI.Height));
                                        break;
                                    case "Tax":
                                        propertyImage.Image = new Bitmap(Resources.tax, new Size(squareUI.Width, squareUI.Height));
                                        break;
                                    case "World Tour":
                                        propertyImage.Image = new Bitmap(Resources.worldtour, new Size(squareUI.Width, squareUI.Height));
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }

                        if (c.Name == "squareUpgrades")
                        {
                            Panel upgradePanel = (Panel)c;
                            if (s.Type == "Property")
                            {
                                Property p = (Property)s;
                                if (p.UpgradeTier > 1 && p.UpgradeTier < 6)
                                {
                                    for (int i = p.UpgradeTier - 1; i > 1; i--)
                                    {
                                        upgradePanel.Controls.Add(genHousePB());
                                    }
                                }
                                else if (p.UpgradeTier == 6)
                                {
                                    PictureBox picBox = new PictureBox();
                                    picBox.Image = new Bitmap(Resources.hotel, new Size(100, 100));
                                    upgradePanel.Controls.Add(picBox);
                                }
                            }
                        }

                    }
                    squareUI.Refresh();
                }
                animateDice(value.Die1, value.Die2);
            }
        }

        private PictureBox genHousePB()
        {
            PictureBox picBox = new PictureBox();
            picBox.Image = new Bitmap(Resources.house, new Size(25, 25));
            picBox.Dock = DockStyle.Right;
            return picBox;
        }

        public List<Player> PlayersUI
        {
            set
            {
                foreach (Player p in value)
                {
                    foreach (PictureBox l in UIPlayers)
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

                    foreach (Panel pn in PlayerViews)
                    {
                        if (p.Name == pn.Name)
                        {
                            Label balance = (Label)pn.Controls.Find("Balance", false)[0];
                            balance.Text = string.Concat("£", p.Balance);
                            Label name = (Label)pn.Controls.Find("Name", false)[0];
                            name.Text = p.Name;
                        }
                    }
                }
            }
        }

        public (string, Square) ActionUI
        {
            set
            {
                string action = value.Item1;
                Console.WriteLine(action);
                Square sq = value.Item2;
                switch (action)
                {
                    case "Buy":
                        showBuyDialog(sq);
                        break;
                    case "Rent":
                        showConfirmDialog(sq);
                        _presenter.PayRent();
                        break;
                    case "Jail":
                        RollButton.Enabled = false;
                        showJailDialog();
                        break;
                    default:
                        if (sq.Name == "Jail")
                        {
                            RollButton.Visible = false;
                            EndTurnButton.Visible = true;
                        }
                        else
                        {
                            OnActionComplete();
                        }
                        break;
                }
            }
        }

        async void showJailDialog()
        {

            JailDialog jailDialog = new JailDialog();
            currentDialog = jailDialog;
            jailDialog.Roll.Click += new EventHandler(this.RollButton_Click);
            jailDialog.Pay.Click += new EventHandler(this.PayJailButton_Click);
            await Task.Delay(3000);
            jailDialog.ShowDialog();
        }

        async void showBuyDialog(Square sq)
        {

            BuyDialog buyDialog = new BuyDialog((Property)sq);
            currentDialog = buyDialog;
            buyDialog.Buy.Click += new EventHandler(this.BuyButton_Click);
            buyDialog.Pass.Click += new EventHandler(this.CloseButton_Click);
            await Task.Delay(2900);
            buyDialog.ShowDialog();
        }
        async void showConfirmDialog(Square sq)
        {

            RentDialog rentDialog = new RentDialog((Property)sq);
            currentDialog = rentDialog;
            rentDialog.Confirm.Click += new EventHandler(this.CloseButton_Click);
            await Task.Delay(2900);
            rentDialog.ShowDialog();
        }

        private void BuyButton_Click(object sender, EventArgs e)
        {
            _presenter.Buy();
            ShowMonopolyData();
            currentDialog.Close();
            OnActionComplete();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            ShowMonopolyData();
            currentDialog.Close();
            OnActionComplete();
        }

        private void PayJailButton_Click(object sender, EventArgs e)
        {
            _presenter.Pay(50);
            currentDialog.Close();
            _presenter.Roll();
            OnActionComplete();
        }

        private void PayButton_Click(object sender, EventArgs e)
        {
            _presenter.Pay(50);
            currentDialog.Close();
            OnActionComplete();
        }

        private void OnActionComplete()
        {
            if (Die1Value == Die2Value)
            {
                RollButton.Enabled = true;
            }
            else
            {
                RollButton.Visible = false;
                EndTurnButton.Visible = true;
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

        async void movePlayerIncrements(PictureBox l, Player p, Panel current)
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
            if (currentDialog is Form)
            {
               currentDialog.Close();
            }
            RollButton.Enabled = false;
            _presenter.Roll();
            isRolling = true;
            this.ShowMonopolyData();
            _presenter.queuePlayerActions();
        }

        private void EndTurnButton_Click(object sender, EventArgs e)
        {
            EndTurnButton.Visible = false;
            RollButton.Enabled = true;
            RollButton.Visible = true;
            _presenter.EndTurn();
        }

        public void ShowMonopolyData()
        {
            _presenter.SetBoardUI();
            _presenter.SetPlayersUI();

        }

        private void update_Resize(object sender, System.EventArgs e)
        {
            ShowMonopolyData();
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
