using Monopoly.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly.View
{
    public class MonopolyForm : Form 
    {
        private MonopolyApp _gameapp;
        private List<Button> _squares;
        private List<Label> _players;

        private Button Square1 = new System.Windows.Forms.Button();
        private Button Square2 = new System.Windows.Forms.Button();
        private Button Square3 = new System.Windows.Forms.Button();
        private Button Square4 = new System.Windows.Forms.Button();
        private Button Square5 = new System.Windows.Forms.Button();
        private Button Square6 = new System.Windows.Forms.Button();
        private Button Square7 = new System.Windows.Forms.Button();
        private Button Square8 = new System.Windows.Forms.Button();
        private Button Square9 = new System.Windows.Forms.Button();
        private Button Square10 = new System.Windows.Forms.Button();
        private Button Square11 = new System.Windows.Forms.Button();
        private Button Square12 = new System.Windows.Forms.Button();
        private Button Square13 = new System.Windows.Forms.Button();
        private Button Square14 = new System.Windows.Forms.Button();
        private Button Square15 = new System.Windows.Forms.Button();
        private Button Square16 = new System.Windows.Forms.Button();
        private Button Square17 = new System.Windows.Forms.Button();
        private Button Square32 = new System.Windows.Forms.Button();
        private Button Square31 = new System.Windows.Forms.Button();
        private Button Square30 = new System.Windows.Forms.Button();
        private Button Square29 = new System.Windows.Forms.Button();
        private Button Square28 = new System.Windows.Forms.Button();
        private Button Square27 = new System.Windows.Forms.Button();
        private Button Square26 = new System.Windows.Forms.Button();
        private Button Square25 = new System.Windows.Forms.Button();
        private Button Square24 = new System.Windows.Forms.Button();
        private Button Square23 = new System.Windows.Forms.Button();
        private Button Square22 = new System.Windows.Forms.Button();
        private Button Square21 = new System.Windows.Forms.Button();
        private Button Square20 = new System.Windows.Forms.Button();
        private Button Square19 = new System.Windows.Forms.Button();
        private Button Square18 = new System.Windows.Forms.Button();
        private Button _rollButton = new System.Windows.Forms.Button();

        public MonopolyForm()
        {
            SetupForm();
            SetupSquares();
            SetupButtons();
            List<String> playerNames = new List<String>(1);
            playerNames.Add("Jack");
            SetupPlayerLabels(playerNames);
            _gameapp = new MonopolyApp(playerNames);
        }

        public List<Button> UISquares
        {
            get { return _squares; }
        }

        public List<Label> UIPlayers
        {
            get { return _players;  }
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

        private void SetupForm()
        {

            this.Text = "Monopoly";
            this.MinimumSize = new Size(512, 300);
        }

        private void SetupButtons()
        {
            _rollButton.Text = "Roll";
            _rollButton.Dock = DockStyle.Bottom;
            this.Controls.Add(_rollButton);
        }

        private void SetupPlayerLabels(List<String> players)
        {
            _players = new List<Label>(players.Count);
            foreach (String player in players)
            {
                Label playerLabel = new Label();
                this.Controls.Add(playerLabel);
                playerLabel.Name = player;
                playerLabel.Location = this.Square1.Location;
                playerLabel.BringToFront();
                playerLabel.Size = new Size(30, 30);
                Console.WriteLine(playerLabel.Font.Size);
                playerLabel.Text = player;
                _players.Add(playerLabel);
                Console.WriteLine(playerLabel.Text);
                playerLabel.Refresh();
            }
        }

        private void SetupSquares()
        {
            _squares = new List<Button>();
            // 
            // Square1
            // 
            this.Square1.Location = new System.Drawing.Point(273, 596);
            this.Square1.Name = "Square1";
            this.Square1.Size = new System.Drawing.Size(75, 66);
            this.Square1.TabIndex = 0;
            this.Square1.Text = "button1";
            this.Square1.UseVisualStyleBackColor = true;
            _squares.Add(Square1);
            // 
            // Square2
            // 
            this.Square2.Location = new System.Drawing.Point(273, 524);
            this.Square2.Name = "Square2";
            this.Square2.Size = new System.Drawing.Size(75, 66);
            this.Square2.TabIndex = 0;
            this.Square2.Text = "button1";
            this.Square2.UseVisualStyleBackColor = true;
            _squares.Add(Square2);
            // 
            // Square3
            // 
            this.Square3.Location = new System.Drawing.Point(273, 452);
            this.Square3.Name = "Square3";
            this.Square3.Size = new System.Drawing.Size(75, 66);
            this.Square3.TabIndex = 0;
            this.Square3.Text = "button1";
            this.Square3.UseVisualStyleBackColor = true;
            _squares.Add(Square3);
            // 
            // Square4
            // 
            this.Square4.Location = new System.Drawing.Point(273, 380);
            this.Square4.Name = "Square4";
            this.Square4.Size = new System.Drawing.Size(75, 66);
            this.Square4.TabIndex = 0;
            this.Square4.Text = "button1";
            this.Square4.UseVisualStyleBackColor = true;
            _squares.Add(Square4);
            // 
            // Square5
            // 
            this.Square5.Location = new System.Drawing.Point(273, 308);
            this.Square5.Name = "Square5";
            this.Square5.Size = new System.Drawing.Size(75, 66);
            this.Square5.TabIndex = 0;
            this.Square5.Text = "button1";
            this.Square5.UseVisualStyleBackColor = true;
            _squares.Add(Square5);
            // 
            // Square6
            // 
            this.Square6.Location = new System.Drawing.Point(273, 236);
            this.Square6.Name = "Square6";
            this.Square6.Size = new System.Drawing.Size(75, 66);
            this.Square6.TabIndex = 0;
            this.Square6.Text = "button1";
            this.Square6.UseVisualStyleBackColor = true;
            _squares.Add(Square6);
            // 
            // Square7
            // 
            this.Square7.Location = new System.Drawing.Point(273, 164);
            this.Square7.Name = "Square7";
            this.Square7.Size = new System.Drawing.Size(75, 66);
            this.Square7.TabIndex = 0;
            this.Square7.Text = "button1";
            this.Square7.UseVisualStyleBackColor = true;
            _squares.Add(Square7);
            // 
            // Square8
            // 
            this.Square8.Location = new System.Drawing.Point(273, 92);
            this.Square8.Name = "Square8";
            this.Square8.Size = new System.Drawing.Size(75, 66);
            this.Square8.TabIndex = 0;
            this.Square8.Text = "button1";
            this.Square8.UseVisualStyleBackColor = true;
            _squares.Add(Square8);
            // 
            // Square9
            // 
            this.Square9.Location = new System.Drawing.Point(273, 20);
            this.Square9.Name = "Square9";
            this.Square9.Size = new System.Drawing.Size(75, 66);
            this.Square9.TabIndex = 0;
            this.Square9.Text = "button1";
            this.Square9.UseVisualStyleBackColor = true;
            _squares.Add(Square9);
            // 
            // Square10
            // 
            this.Square10.Location = new System.Drawing.Point(354, 20);
            this.Square10.Name = "Square10";
            this.Square10.Size = new System.Drawing.Size(75, 66);
            this.Square10.TabIndex = 0;
            this.Square10.Text = "button1";
            this.Square10.UseVisualStyleBackColor = true;
            _squares.Add(Square10);
            // 
            // Square11
            // 
            this.Square11.Location = new System.Drawing.Point(435, 20);
            this.Square11.Name = "Square11";
            this.Square11.Size = new System.Drawing.Size(75, 66);
            this.Square11.TabIndex = 0;
            this.Square11.Text = "button1";
            this.Square11.UseVisualStyleBackColor = true;
            _squares.Add(Square11);
            // 
            // Square12
            // 
            this.Square12.Location = new System.Drawing.Point(516, 20);
            this.Square12.Name = "Square12";
            this.Square12.Size = new System.Drawing.Size(75, 66);
            this.Square12.TabIndex = 0;
            this.Square12.Text = "button1";
            this.Square12.UseVisualStyleBackColor = true;
            _squares.Add(Square12);
            // 
            // Square13
            // 
            this.Square13.Location = new System.Drawing.Point(597, 20);
            this.Square13.Name = "Square13";
            this.Square13.Size = new System.Drawing.Size(75, 66);
            this.Square13.TabIndex = 0;
            this.Square13.Text = "button1";
            this.Square13.UseVisualStyleBackColor = true;
            _squares.Add(Square13);
            // 
            // Square14
            // 
            this.Square14.Location = new System.Drawing.Point(678, 20);
            this.Square14.Name = "Square14";
            this.Square14.Size = new System.Drawing.Size(75, 66);
            this.Square14.TabIndex = 0;
            this.Square14.Text = "button1";
            this.Square14.UseVisualStyleBackColor = true;
            _squares.Add(Square14);
            // 
            // Square15
            // 
            this.Square15.Location = new System.Drawing.Point(759, 20);
            this.Square15.Name = "Square15";
            this.Square15.Size = new System.Drawing.Size(75, 66);
            this.Square15.TabIndex = 0;
            this.Square15.Text = "button1";
            this.Square15.UseVisualStyleBackColor = true;
            _squares.Add(Square15);
            // 
            // Square16
            // 
            this.Square16.Location = new System.Drawing.Point(840, 20);
            this.Square16.Name = "Square16";
            this.Square16.Size = new System.Drawing.Size(75, 66);
            this.Square16.TabIndex = 0;
            this.Square16.Text = "button1";
            this.Square16.UseVisualStyleBackColor = true;
            _squares.Add(Square16);
            // 
            // Square17
            // 
            this.Square17.Location = new System.Drawing.Point(921, 20);
            this.Square17.Name = "Square17";
            this.Square17.Size = new System.Drawing.Size(75, 66);
            this.Square17.TabIndex = 0;
            this.Square17.Text = "button1";
            this.Square17.UseVisualStyleBackColor = true;
            _squares.Add(Square17);
            // 
            // Square32
            // 
            this.Square32.Location = new System.Drawing.Point(354, 596);
            this.Square32.Name = "Square32";
            this.Square32.Size = new System.Drawing.Size(75, 66);
            this.Square32.TabIndex = 0;
            this.Square32.Text = "button1";
            this.Square32.UseVisualStyleBackColor = true;
            _squares.Add(Square18);
            // 
            // Square31
            // 
            this.Square31.Location = new System.Drawing.Point(435, 596);
            this.Square31.Name = "Square31";
            this.Square31.Size = new System.Drawing.Size(75, 66);
            this.Square31.TabIndex = 0;
            this.Square31.Text = "button1";
            this.Square31.UseVisualStyleBackColor = true;
            _squares.Add(Square19);
            // 
            // Square30
            // 
            this.Square30.Location = new System.Drawing.Point(516, 596);
            this.Square30.Name = "Square30";
            this.Square30.Size = new System.Drawing.Size(75, 66);
            this.Square30.TabIndex = 0;
            this.Square30.Text = "button1";
            this.Square30.UseVisualStyleBackColor = true;
            _squares.Add(Square20);
            // 
            // Square29
            // 
            this.Square29.Location = new System.Drawing.Point(597, 596);
            this.Square29.Name = "Square29";
            this.Square29.Size = new System.Drawing.Size(75, 66);
            this.Square29.TabIndex = 0;
            this.Square29.Text = "button1";
            this.Square29.UseVisualStyleBackColor = true;
            _squares.Add(Square21);
            // 
            // Square28
            // 
            this.Square28.Location = new System.Drawing.Point(678, 596);
            this.Square28.Name = "Square28";
            this.Square28.Size = new System.Drawing.Size(75, 66);
            this.Square28.TabIndex = 0;
            this.Square28.Text = "button1";
            this.Square28.UseVisualStyleBackColor = true;
            _squares.Add(Square22);
            // 
            // Square27
            // 
            this.Square27.Location = new System.Drawing.Point(759, 596);
            this.Square27.Name = "Square27";
            this.Square27.Size = new System.Drawing.Size(75, 66);
            this.Square27.TabIndex = 0;
            this.Square27.Text = "button1";
            this.Square27.UseVisualStyleBackColor = true;
            _squares.Add(Square23);
            // 
            // Square26
            // 
            this.Square26.Location = new System.Drawing.Point(840, 596);
            this.Square26.Name = "Square26";
            this.Square26.Size = new System.Drawing.Size(75, 66);
            this.Square26.TabIndex = 0;
            this.Square26.Text = "button1";
            this.Square26.UseVisualStyleBackColor = true;
            _squares.Add(Square24);
            // 
            // Square25
            // 
            this.Square25.Location = new System.Drawing.Point(921, 596);
            this.Square25.Name = "Square25";
            this.Square25.Size = new System.Drawing.Size(75, 66);
            this.Square25.TabIndex = 0;
            this.Square25.Text = "button1";
            this.Square25.UseVisualStyleBackColor = true;
            _squares.Add(Square25);
            // 
            // Square24
            // 
            this.Square24.Location = new System.Drawing.Point(921, 524);
            this.Square24.Name = "Square24";
            this.Square24.Size = new System.Drawing.Size(75, 66);
            this.Square24.TabIndex = 0;
            this.Square24.Text = "button1";
            this.Square24.UseVisualStyleBackColor = true;
            _squares.Add(Square26);
            // 
            // Square23
            // 
            this.Square23.Location = new System.Drawing.Point(921, 452);
            this.Square23.Name = "Square23";
            this.Square23.Size = new System.Drawing.Size(75, 66);
            this.Square23.TabIndex = 0;
            this.Square23.Text = "button1";
            this.Square23.UseVisualStyleBackColor = true;
            _squares.Add(Square27);
            // 
            // Square22
            // 
            this.Square22.Location = new System.Drawing.Point(921, 380);
            this.Square22.Name = "Square22";
            this.Square22.Size = new System.Drawing.Size(75, 66);
            this.Square22.TabIndex = 0;
            this.Square22.Text = "button1";
            this.Square22.UseVisualStyleBackColor = true;
            _squares.Add(Square28);
            // 
            // Square21
            // 
            this.Square21.Location = new System.Drawing.Point(921, 308);
            this.Square21.Name = "Square21";
            this.Square21.Size = new System.Drawing.Size(75, 66);
            this.Square21.TabIndex = 0;
            this.Square21.Text = "button1";
            this.Square21.UseVisualStyleBackColor = true;
            _squares.Add(Square29);
            // 
            // Square20
            // 
            this.Square20.Location = new System.Drawing.Point(921, 236);
            this.Square20.Name = "Square20";
            this.Square20.Size = new System.Drawing.Size(75, 66);
            this.Square20.TabIndex = 0;
            this.Square20.Text = "button1";
            this.Square20.UseVisualStyleBackColor = true;
            _squares.Add(Square30);
            // 
            // Square19
            // 
            this.Square19.Location = new System.Drawing.Point(921, 164);
            this.Square19.Name = "Square19";
            this.Square19.Size = new System.Drawing.Size(75, 66);
            this.Square19.TabIndex = 0;
            this.Square19.Text = "button1";
            this.Square19.UseVisualStyleBackColor = true;
            _squares.Add(Square31);
            // 
            // Square18
            // 
            this.Square18.Location = new System.Drawing.Point(921, 92);
            this.Square18.Name = "Square18";
            this.Square18.Size = new System.Drawing.Size(75, 66);
            this.Square18.TabIndex = 0;
            this.Square18.Text = "button1";
            this.Square18.UseVisualStyleBackColor = true;
            _squares.Add(Square32);


            this.Controls.Add(this.Square25);
            this.Controls.Add(this.Square17);
            this.Controls.Add(this.Square26);
            this.Controls.Add(this.Square16);
            this.Controls.Add(this.Square27);
            this.Controls.Add(this.Square15);
            this.Controls.Add(this.Square28);
            this.Controls.Add(this.Square14);
            this.Controls.Add(this.Square29);
            this.Controls.Add(this.Square13);
            this.Controls.Add(this.Square30);
            this.Controls.Add(this.Square12);
            this.Controls.Add(this.Square31);
            this.Controls.Add(this.Square11);
            this.Controls.Add(this.Square32);
            this.Controls.Add(this.Square10);
            this.Controls.Add(this.Square9);
            this.Controls.Add(this.Square18);
            this.Controls.Add(this.Square8);
            this.Controls.Add(this.Square19);
            this.Controls.Add(this.Square7);
            this.Controls.Add(this.Square20);
            this.Controls.Add(this.Square6);
            this.Controls.Add(this.Square21);
            this.Controls.Add(this.Square5);
            this.Controls.Add(this.Square22);
            this.Controls.Add(this.Square4);
            this.Controls.Add(this.Square23);
            this.Controls.Add(this.Square24);
            this.Controls.Add(this.Square3);
            this.Controls.Add(this.Square2);
            this.Controls.Add(this.Square1);
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
