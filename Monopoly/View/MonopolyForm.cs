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

namespace Monopoly.View
{
    public class MonopolyForm : Form
    {
        private MonopolyApp _gameapp;
        private List<Panel> _squares;
        private List<Label> _players;

        private int _die1Value = 1;
        private int _die2Value = 1;
        private Button _rollButton = new System.Windows.Forms.Button();
        private Button _endTurnButton = new System.Windows.Forms.Button();
        private PictureBox pBox = new System.Windows.Forms.PictureBox();
        private PictureBox pBox2 = new System.Windows.Forms.PictureBox();
        private List<Image> dieImages = new List<Image>();
        private PrivateFontCollection pfc;
        private List<DockStyle> dockStyles = new List<DockStyle>(4);
        private List<AnchorStyles> anchorStyles = new List<AnchorStyles>(4);

        public MonopolyForm()
        {
            SetupForm();
            SetupFont();
            SetupSquares();
            SetupButtons();
            dockStyles.Add(DockStyle.Bottom);
            dockStyles.Add(DockStyle.Bottom);
            dockStyles.Add(DockStyle.Bottom);
            dockStyles.Add(DockStyle.Bottom);
            List<String> playerNames = new List<String>(4);
            playerNames.Add("P1");
            playerNames.Add("P2");
            playerNames.Add("P3");
            playerNames.Add("P4");
            SetupPlayerLabels(playerNames);
            CalculatePlayerPositions();
            _gameapp = new MonopolyApp(playerNames);
            dieImages.Add(Resources.die_1);
            dieImages.Add(Resources.die_2);
            dieImages.Add(Resources.die_3);
            dieImages.Add(Resources.die_4);
            dieImages.Add(Resources.die_5);
            dieImages.Add(Resources.die_6);
            this.SetupDiceUI();
        }

        public List<Panel> UISquares
        {
            get { return _squares; }
        }

        public List<Label> UIPlayers
        {
            get { return _players; }
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
            this.MinimumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.BackColor = Color.LightSkyBlue;
        }
        private void SetupDiceUI()
        {
            pBox.Location = new Point(Width / 4 + 350, 400);
            pBox.Size = new Size(50, 50);
            pBox2.Location = new Point(Width/4 + 450, 400);
            pBox2.Size = new Size(50, 50);
            pBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pBox);
            this.Controls.Add(pBox2);
        }

        private void SetupButtons()
        {
            _rollButton.Text = "Roll";
            _rollButton.Dock = DockStyle.Bottom;
            this.Controls.Add(_rollButton);
            _endTurnButton.Text = "End Turn";
            _endTurnButton.Dock = DockStyle.Bottom;
            this.Controls.Add(_endTurnButton);
            _endTurnButton.Visible = false;
        }

        private void SetupPlayerLabels(List<String> players)
        {
            _players = new List<Label>(players.Count);
            foreach (String player in players)
            {
                Label playerLabel = new Label();
                playerLabel.Name = player;
                playerLabel.Text = player;
                playerLabel.AutoSize = true;
                _squares.ElementAt(0).Controls.Add(playerLabel);
                playerLabel.BringToFront();
                playerLabel.BackColor = Color.Black;
                playerLabel.ForeColor = Color.White;
                playerLabel.Font = new Font(pfc.Families[0], 12);
                playerLabel.UseCompatibleTextRendering = true;
                _players.Add(playerLabel);
                playerLabel.Refresh();
            }
        }

        public void CalculatePlayerPositions()
        {
            foreach (Panel sq in _squares)
            {
                int playerCount = 0;
                foreach (Label pl in _players)
                {
                    if (sq.Controls.IndexOf(pl) != -1)
                    {
                        playerCount += 1;
                        if (playerCount == 1)
                        {
                            PictureBox pB = (PictureBox)sq.Controls.Find("propertyImage", false).ElementAt(0);
                            pl.Location = pB.Location;
                        } else if (playerCount == 2)
                        {
                            PictureBox pB = (PictureBox)sq.Controls.Find("propertyImage", false).ElementAt(0);
                            pl.Location = new Point((pB.Location.X + pB.Size.Width) - pl.Size.Width, pB.Location.Y);
                        } else if (playerCount == 3)
                        {
                            PictureBox pB = (PictureBox)sq.Controls.Find("propertyImage", false).ElementAt(0);
                            pl.Location = new Point(pB.Location.X, pB.Location.Y + pB.Size.Height - pl.Size.Height);
                        } else if (playerCount == 4)
                        {
                            PictureBox pB = (PictureBox)sq.Controls.Find("propertyImage", false).ElementAt(0);
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

            int boardHeight = 800;
            int boardWidth = 800;
            List<Point> boardPoints = new List<Point>();
            for (int j = boardHeight; j >= 0; j -= boardHeight / 8)
            { 
                boardPoints.Add(new System.Drawing.Point(0 + Width / 4, j));
            }
            for (int i = boardWidth / 8; i <= boardWidth; i += boardWidth / 8)
            {
                boardPoints.Add(new System.Drawing.Point(i+Width/4, 0));
            }
            for (int j = boardHeight / 8; j <= boardHeight; j += boardHeight / 8)
            {
                boardPoints.Add(new System.Drawing.Point(boardWidth + Width / 4, j));
            }
            for (int i = boardWidth - boardWidth / 8; i >= boardWidth / 8; i -= boardWidth / 8)
            {
                boardPoints.Add(new System.Drawing.Point(i + Width / 4, boardHeight));
            }

            int count = 0;
            foreach (Point boardPoint in boardPoints)
            {
                count += 1;
                Panel p = new Panel();
                p.BackColor = Color.LightGray;
                p.BorderStyle = BorderStyle.Fixed3D;
                PictureBox pB = new PictureBox();
                pB.Name = "propertyImage";
                Label l = new Label();
                l.BackColor = Color.White;
                l.BringToFront();
                l.TextAlign = ContentAlignment.BottomCenter;
                l.Name = "propertyName";
                l.Text = "Square"+count;
                p.Location = boardPoint;
                l.Font = new Font(pfc.Families[0], 12);
                l.UseCompatibleTextRendering = true;
                l.Dock = DockStyle.Top;
                l.BorderStyle = BorderStyle.FixedSingle;
                p.Size = new Size(boardWidth/8, boardHeight/8);
                pB.Size = new Size(p.Size.Width, p.Size.Height-l.Size.Height);
                pB.BorderStyle = BorderStyle.FixedSingle;
                pB.Dock = DockStyle.Bottom;
                pB.SizeMode = PictureBoxSizeMode.StretchImage;
                _squares.Add(p);
                p.Controls.Add(l);
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
