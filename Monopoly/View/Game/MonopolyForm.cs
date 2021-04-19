using Monopoly.Model;
using Monopoly.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly.View.Game
{
    public class MonopolyForm : Form
    {
        private MonopolyApp _gameapp;
        private List<Panel> _squares;
        private List<PictureBox> _pieces;
        private List<Panel> _playerViews;

        private int _die1Value = 1;
        private int _die2Value = 1;
        private int formHeight = 720;
        private int formWidth = 1280;
        private Button _rollButton = new System.Windows.Forms.Button();
        private Button _endTurnButton = new System.Windows.Forms.Button();
        private PictureBox pBox = new System.Windows.Forms.PictureBox();
        private PictureBox pBox2 = new System.Windows.Forms.PictureBox();
        private List<Image> dieImages = new List<Image>();
        private List<Image> gamePieceImages = new List<Image>();
        private PrivateFontCollection pfc;
        private List<DockStyle> dockStyles = new List<DockStyle>(4);
        private List<AnchorStyles> anchorStyles = new List<AnchorStyles>(4);
        List<(string, Color)> players = new List<(string, Color)>();
        public MonopolyForm()
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            formHeight = Size.Height;
            formWidth = Size.Width;
            SetupForm();
            SetupFont();
            SetupSquares();
            SetupButtons();
            dockStyles.Add(DockStyle.Bottom);
            dockStyles.Add(DockStyle.Bottom);
            dockStyles.Add(DockStyle.Bottom);
            dockStyles.Add(DockStyle.Bottom);
            players.Add(("Mason", Color.Green));
            players.Add(("Anto", Color.Blue));
            players.Add(("Marcus", Color.Red));
            players.Add(("Bruno", Color.Yellow));


            TextBox nameField = new TextBox();

            Regex rx = new Regex(@"[a-z]{3,20}",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);

            MatchCollection matches = rx.Matches(nameField.Text);

            gamePieceImages.Add(Resources.car);
            gamePieceImages.Add(Resources.ship);
            gamePieceImages.Add(Resources.iron);
            gamePieceImages.Add(Resources.boot);
            gamePieceImages.Add(Resources.thimble);
            gamePieceImages.Add(Resources.dog);
            gamePieceImages.Add(Resources.wheelbarrow);
            gamePieceImages.Add(Resources.hat);
            SetupPlayerPieces(players);
            SetupPlayerView(players);
            CalculatePlayerPositions();
            _gameapp = new MonopolyApp(players);
            dieImages.Add(Resources.die_1);
            dieImages.Add(Resources.die_2);
            dieImages.Add(Resources.die_3);
            dieImages.Add(Resources.die_4);
            dieImages.Add(Resources.die_5);
            dieImages.Add(Resources.die_6);
            this.SetupDiceUI();
            this.Resize += new EventHandler(this_Resize);
        }

        public List<Panel> UISquares
        {
            get { return _squares; }
        }

        public List<PictureBox> UIPlayers
        {
            get { return _pieces; }
        }

        public List<Panel> PlayerViews
        {
            get { return _playerViews;  }
        }

        public Button RollButton
        {
            get
            {
                return _rollButton;
            }
            set
            {
                _rollButton = value;
            }
        }

        public Button EndTurnButton
        {
            get
            {
                return _endTurnButton;
            }
            set
            {
                _endTurnButton = value;
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

        public int Die1Value
        {
            get
            {
                return _die1Value;
            }
            set
            {
                _die1Value = value;
                if (value > 0)
                {
                    pBox.Image = dieImages[_die1Value - 1];
                    pBox.Refresh();
                }
            } 
        }

        public int Die2Value
        {
            get
            {
                return _die2Value;
            }
            set
            {
                _die2Value = value;
                if (value > 0)
                {
                    pBox2.Image = dieImages[_die2Value - 1];
                    pBox2.Refresh();
                }
            }
        }

        private void SetupForm()
        {
            this.Text = "Monopoly";
            this.MinimumSize = new Size(1280, 720);
            this.BackColor = Color.LightSkyBlue;
        }
        private void SetupDiceUI()
        {
            pBox.Size = new Size(50, 50);
            pBox2.Size = new Size(50, 50);
            pBox.Location = new Point(formWidth/2 - pBox.Size.Width*2, formHeight/2 - pBox.Size.Height);
            pBox2.Location = new Point(formWidth / 2 + pBox.Size.Width, formHeight / 2 - pBox2.Size.Height);
            pBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pBox);
            this.Controls.Add(pBox2);
        }

        private void SetupButtons()
        {
            _rollButton.Text = "Roll";
            _rollButton.Location = new Point(formWidth/2 - _endTurnButton.Size.Width / 2, formHeight /2);
            this.Controls.Add(_rollButton);
            _endTurnButton.Text = "End Turn";
            _endTurnButton.Location = new Point(formWidth / 2 - _endTurnButton.Size.Width / 2, formHeight / 2);
            this.Controls.Add(_endTurnButton);
            _endTurnButton.Visible = false;
        }

        private void this_Resize(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;
            formHeight = control.Size.Height;
            formWidth = control.Size.Width;
            foreach (Panel p in _playerViews)
            {
                control.Controls.Remove((Control)p);
            }
            foreach (Panel s in _squares)
            {
                control.Controls.Remove((Control)s);
            }
            this.SetupButtons();
            this.SetupPlayerView(players);
            this.SetupSquares();
            this.SetupDiceUI();
            this.SetupPlayerPieces(players);
            Refresh();
        }

        private void SetupPlayerPieces(List<(String, Color)> players)
        {
            _pieces = new List<PictureBox>(players.Count);
            Random rand = new Random();
            foreach ((String, Color) player in players)
            {
                PictureBox playerLabel = new PictureBox();
                //playerLabel.Name = player;
                playerLabel.Text = player.Item1;
                playerLabel.Image = gamePieceImages[rand.Next(gamePieceImages.Count)];
                playerLabel.Size = new Size(40, 40);
                playerLabel.SizeMode = PictureBoxSizeMode.StretchImage;
                _squares.ElementAt(0).Controls.Add(playerLabel);
                playerLabel.BringToFront();
                //playerLabel.BackColor = Color.Black;
                //playerLabel.ForeColor = Color.White;
                //playerLabel.Font = new Font(pfc.Families[0], 12);
                //playerLabel.UseCompatibleTextRendering = true;
                _pieces.Add(playerLabel);
                playerLabel.Refresh();
            }
        }

        private void SetupPlayerView(List<(String, Color)> players)
        {
            _playerViews = new List<Panel>();
            Random rand = new Random();
            for (int i = 0; i < players.Count; i++)
            {
                Panel playerView = new Panel();
                playerView.Name = players.ElementAt(i).Item1;
                playerView.Size = new Size(120, 120);
                if (i == 0)
                {
                    playerView.Location = new Point(0,0);
                } else if (i == 1)
                {
                    playerView.Location = new Point(formWidth-playerView.Size.Width, 0);
                } else if (i == 2)
                {
                    playerView.Location = new Point(0, formHeight - playerView.Size.Height);
                } else
                {
                    playerView.Location = new Point(formWidth - playerView.Size.Width, formHeight - playerView.Size.Height);
                }

                playerView.BackColor = Color.LightGray;
                playerView.BorderStyle = BorderStyle.Fixed3D;
                Label playerName = new Label();
                playerName.Dock = DockStyle.Top;
                playerName.Name = "Name";
                playerName.TextAlign = ContentAlignment.MiddleCenter;
                playerName.Text = players.ElementAt(i).Item1;
                playerName.BringToFront();
                playerName.BackColor = players.ElementAt(i).Item2;
                playerName.ForeColor = Color.Black;
                playerName.Font = new Font(pfc.Families[0], 12);
                playerName.UseCompatibleTextRendering = true;
                PictureBox playerAvatar = new PictureBox();
                playerAvatar.Dock = DockStyle.Fill;
                playerAvatar.Name = "playerAvatar";
                playerAvatar.Image = gamePieceImages[rand.Next(gamePieceImages.Count)];
                playerAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
                Label playerBalance = new Label();
                playerBalance.Dock = DockStyle.Bottom;
                playerBalance.TextAlign = ContentAlignment.MiddleCenter;
                playerBalance.Name = "Balance";
                playerBalance.Text = "£500";
                playerBalance.BringToFront();
                playerBalance.BackColor = Color.Black;
                playerBalance.ForeColor = Color.White;
                playerBalance.Font = new Font(pfc.Families[0], 12);
                playerBalance.UseCompatibleTextRendering = true;
                playerView.Controls.Add(playerAvatar);
                playerView.Controls.Add(playerBalance);
                playerView.Controls.Add(playerName);
                Controls.Add(playerView);
                _playerViews.Add(playerView);
                playerView.Refresh();
            }
        }

        public void CalculatePlayerPositions()
        {
            foreach (Panel sq in _squares)
            {
                int playerCount = 0;
                foreach (PictureBox pl in _pieces)
                {
                    if (sq.Controls.IndexOf(pl) != -1)
                    {
                        playerCount += 1;
                        if (playerCount == 1)
                        {
                            PictureBox pB = (PictureBox)sq.Controls.Find("squareImage", false).ElementAt(0);
                            pl.Location = pB.Location;
                        } else if (playerCount == 2)
                        {
                            PictureBox pB = (PictureBox)sq.Controls.Find("squareImage", false).ElementAt(0);
                            pl.Location = new Point((pB.Location.X + pB.Size.Width) - pl.Size.Width, pB.Location.Y);
                        } else if (playerCount == 3)
                        {
                            PictureBox pB = (PictureBox)sq.Controls.Find("squareImage", false).ElementAt(0);
                            pl.Location = new Point(pB.Location.X, pB.Location.Y + pB.Size.Height - pl.Size.Height);
                        } else if (playerCount == 4)
                        {
                            PictureBox pB = (PictureBox)sq.Controls.Find("squareImage", false).ElementAt(0);
                            pl.Location = new Point((pB.Location.X + pB.Size.Width) - pl.Size.Width, pB.Location.Y + pB.Size.Height - pl.Size.Height);
                        }
                        pl.Refresh();
                    }
                }
            }
        }

        private void SetupSquares()
        {
            _squares = new List<Panel>();

            int boardHeight = (int)((int) formHeight * 0.6);
            int boardWidth = (int)((int) formHeight * 0.6);
            List<(Point, Size)> boardDimens = new List<(Point, Size)>();
            for (int j = boardHeight; j >= 0 + boardHeight / 8; j -= boardHeight / 8)
            {
                Size s = new Size((boardWidth / 8 * 2), boardHeight / 8);
                if (j == boardHeight)
                {
                    s = new Size(s.Width, s.Height*2);
                }
                Point p = new System.Drawing.Point(0 + formWidth / 4, j + boardHeight / 4);
                boardDimens.Add((p, s));
            }
            for (int i = 0; i <= boardWidth - boardWidth / 8; i += boardWidth / 8)
            {
                Size s = new Size(boardWidth / 8, boardHeight / 8 * 2);
                Point p = new System.Drawing.Point(i + s.Width + formWidth / 4, boardHeight / 4 - s.Width);
                if (i == 0)
                {
                    s = new Size(s.Width * 2, s.Height);
                    p = new System.Drawing.Point(i + formWidth / 4, boardHeight / 4 - s.Width / 2);
                } 
                boardDimens.Add((p, s));
            }
            for (int j = 0; j <= boardHeight - boardHeight / 8; j += boardHeight / 8)
            {
                Size s = new Size(boardWidth / 8 * 2, boardHeight / 8);
                Point p = new System.Drawing.Point(boardWidth + formWidth / 4 + s.Height, j  + boardHeight / 4);
                if (j == 0)
                {
                    s = new Size(s.Width, s.Height * 2);
                    p = new System.Drawing.Point(boardWidth + formWidth / 4 + s.Height / 2, j + boardHeight / 4 - s.Width / 2);
                }
                boardDimens.Add((p, s));
            }
            for (int i = boardWidth; i >= 0 + boardWidth / 8; i -= boardWidth / 8)
            {
                Size s = new Size(boardWidth / 8, boardHeight / 8 * 2);
                Point p = new System.Drawing.Point(i + formWidth / 4 + s.Width, boardHeight + boardHeight / 4);
                if (i == boardWidth)
                {
                    s = new Size(s.Width * 2, s.Height);
                    p = new System.Drawing.Point(i + formWidth / 4 + s.Width / 2, boardHeight + boardHeight / 4);
                }
                boardDimens.Add((p, s));
            }

            foreach ((Point boardPoint, Size boardSize) in boardDimens)
            {
                Panel p = new Panel();
                p.BackColor = Color.LightGray;
                p.BorderStyle = BorderStyle.Fixed3D;
                PictureBox pB = new PictureBox();
                pB.Name = "squareImage";
                p.Location = boardPoint;
                p.Size = boardSize;
                if (p.Size.Height > p.Size.Width)
                {
                    pB.Size = new Size(p.Size.Width, p.Size.Height / 2);
                    pB.Dock = DockStyle.Bottom;
                    Label l = new Label();
                    l.BackColor = Color.White;
                    l.BringToFront();
                    l.TextAlign = ContentAlignment.BottomCenter;
                    l.Name = "squareName";
                    l.Text = "Square" + _squares.Count + 1;
                    l.Font = new Font(pfc.Families[0], 12);
                    l.UseCompatibleTextRendering = true;
                    l.Dock = DockStyle.Top;
                    l.BorderStyle = BorderStyle.FixedSingle;
                    p.Controls.Add(l);
                } else if (p.Size.Width > p.Size.Height)
                {
                    pB.Size = new Size(p.Size.Width / 2, p.Size.Height);
                    OrientedTextLabel l = new OrientedTextLabel();
                    l.Size = new Size(p.Width / 8, pB.Size.Height);
                    if (_squares.Count > 8)
                    {
                        pB.Dock = DockStyle.Left;
                        l.RotationAngle = 90;
                        l.Dock = DockStyle.Right;
                    } else
                    {
                        pB.Dock = DockStyle.Right;
                        l.RotationAngle = 270;
                    }
                    l.BackColor = Color.White;
                    l.Name = "squareName";
                    l.Text = "Square" + _squares.Count + 1;
                    l.Font = new Font(pfc.Families[0], 12);
                    l.UseCompatibleTextRendering = true;
                    l.BorderStyle = BorderStyle.FixedSingle;
                    l.BringToFront();
                    p.Controls.Add(l);
                } else
                {
                    pB.Size = new Size(p.Size.Width, p.Size.Height);
                    pB.Dock = DockStyle.Bottom;
                }
                pB.BorderStyle = BorderStyle.FixedSingle;
                pB.SizeMode = PictureBoxSizeMode.StretchImage;
                _squares.Add(p);
                p.Controls.Add(pB);
                Controls.Add(p);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MonopolyForm
            // 
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Name = "MonopolyForm";
            this.ResumeLayout(false);

        }
    }

}
