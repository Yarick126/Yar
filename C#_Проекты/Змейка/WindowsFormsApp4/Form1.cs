using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    
    public partial class Form1 : Form
    {
        private int ri, rj;
        private PictureBox fruit;
        private PictureBox[] sneak = new PictureBox[400];
        private Label Labelscore;
        private int dirx, diry;
        private int _width = 900;
        private int _height = 800;
        private int _sizeofSides = 40;
        private int score=0;
        public Form1()
        {
            InitializeComponent();
            Text = "Snake";
            Width = _width;
            Height =_height;
            dirx = 1;
            diry = 0;
            Labelscore = new Label();
            Labelscore.Text = "Score: 0";
            Labelscore.Location = new Point(810, 10);
            Controls.Add(Labelscore);
            sneak[0] = new PictureBox();
            sneak[0].Location = new Point(201,201);
            sneak[0].Size = new Size(_sizeofSides-1, _sizeofSides-1);
            sneak[0].BackColor = Color.Red;
            Controls.Add(sneak[0]);
            fruit = new PictureBox();
            fruit.BackColor = Color.Yellow;
            fruit.Size = new Size(_sizeofSides-1, _sizeofSides-1);
            
            _generateMap();
            _generateFruite();
            timer.Tick += new EventHandler(_update);
            timer.Interval = 500;
            timer.Start();
            
            KeyDown += new KeyEventHandler(OKP);
        }

        private void _generateFruite()
        {
            Random r = new Random();
            ri = r.Next(0, _height - _sizeofSides);
            int tempI = ri % _sizeofSides;
            ri-= tempI;
            rj = r.Next(0, _height - _sizeofSides);
            int tempJ = rj % _sizeofSides;
            rj -= tempJ;
            fruit.Location = new Point(ri, rj);
            rj++;
            ri++;
            Controls.Add(fruit);
        }

        private void _checkBorder()
        {
            if (sneak[0].Location.X < 0)
            {
                for(int _i = 1; _i <= score; _i++)
                {
                    Controls.Remove(sneak[_i]);
                }
                score = 0;
                Labelscore.Text = "Score: " + score;
                dirx = 1;
            }
            if (sneak[0].Location.X > _height)
            {
                for (int _i = 1; _i <= score; _i++)
                {
                    Controls.Remove(sneak[_i]);
                }
                score = 0;
                Labelscore.Text = "Score: " + score;
                dirx =-1;
            }
            if (sneak[0].Location.Y < 0)
            {
                for (int _i = 1; _i <= score; _i++)
                {
                    Controls.Remove(sneak[_i]);
                }
                score = 0;
                Labelscore.Text = "Score: " + score;
                diry =1;
            }
            if (sneak[0].Location.Y > _height)
            {
                for (int _i = 1; _i <= score; _i++)
                {
                    Controls.Remove(sneak[_i]);
                }
                score = 0;
                Labelscore.Text = "Score: " + score;
                dirx = -1;
            }
        }

        
        private void eatitself()
        {
            for(int _i = 1; _i < score; _i++)
            {
                if (sneak[0].Location == sneak[_i].Location)
                {
                    for(int _j = 1; _j < score; _j++)
                    {
                        Controls.Remove(sneak[_j]);
                    }
                    score = score - (score - _i + 1);
                }
            }
        }

        private void _generateMap()
        {
            for(int i = 0; i < _width/_sizeofSides; i++)
            {
                    PictureBox pic = new PictureBox();
                    pic.BackColor = Color.Black;
                    pic.Location = new Point(0, _sizeofSides * i);
                    pic.Size = new Size(_width - 100, 1);
                    Controls.Add(pic);
            }
            for (int i = 0; i <=_height / _sizeofSides; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Location = new Point(_sizeofSides * i,0);
                pic.Size = new Size(1, _width);
                Controls.Add(pic);
            }
        }

        private void MoveSneak()
        {
            for (int i = score; i >= 1; i--)
            {
                sneak[i].Location = sneak[i - 1].Location;
            }
            sneak[0].Location = new Point(sneak[0].Location.X + dirx * (_sizeofSides), sneak[0].Location.Y + diry * (_sizeofSides));
            eatitself();
        }

        private void _update(Object MyObject, EventArgs eventsArgs)
        {
            _checkBorder();
            eatFruit();
            MoveSneak();
            //cube.Location = new Point(cube.Location.X + dirx * _sizeofSides, cube.Location.Y + diry * _sizeofSides);
        }


        private void eatFruit()
        {
            if(sneak[0].Location.X==ri && sneak[0].Location.Y == rj)
            {
                Labelscore.Text = "Score: " + ++score;
                sneak[score] = new PictureBox();
                sneak[score].Location = new Point(sneak[score - 1].Location.X+40*dirx, sneak[score - 1].Location.Y-40*diry);
                sneak[score].Size = new Size(_sizeofSides-1, _sizeofSides-1);
                sneak[score].BackColor = Color.Red;
                Controls.Add(sneak[score]);
                _generateFruite();
            }
        }

        private void OKP(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    dirx = 1;
                    diry = 0;
                    break;
                case "Left":
                    dirx = -1;
                    diry = 0;
                    break;
                case "Up":
                    diry = -1;
                    dirx = 0;
                    break;
                case "Down":
                    diry = 1;
                    dirx = 0;
                    break;
            }
        }

       
    }
}
