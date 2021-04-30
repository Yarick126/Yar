using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp22
{
    public partial class Form1 : Form
    {
        private int diry;
        private int _width = 900;
        private int _height = 800;
        private int car_size = 100;
        private PictureBox Car;
        private PictureBox[] Cars = new PictureBox[3];
        private int score = 0;

        public Form1()
        {
            Program.f1 = this;
            InitializeComponent();
            CreatMap();
            KeyDown += new KeyEventHandler(OKP);
            
        }

        private void CreatMap()
        {
            timer2.Interval = 100;

            NewGame.BackgroundImageLayout = ImageLayout.Stretch;
            StartGame.BackgroundImageLayout = ImageLayout.Stretch;
            PauseGame.BackgroundImageLayout = ImageLayout.Stretch;
            GameOption.BackgroundImageLayout = ImageLayout.Stretch;

            Text = "Cars Game!";
            Width = _width;
            Height = _height;

            for (int i = 0; i < Cars.Length; i++)
            {
                Cars[i] = new PictureBox();
                Cars[i].BackColor = Color.Black;
                Cars[i].Location = new Point(30 + (101 * i), 30);
                Cars[i].Size = new Size(car_size, car_size);
                Controls.Add(Cars[i]);
            }

            diry = -1;
            Car = new PictureBox
            {
                BackColor = Color.Red,
                Size = new Size(car_size, car_size),
                Location = new Point(30, 628)
            };
            Controls.Add(Car);

            Label SCORE = new Label();
            SCORE.Location = new Point(781, 206);
            SCORE.Text = Convert.ToString("Score = " + score);

            /*Bitmap bitmap = new Bitmap(Width, Height);

            Pen p = new Pen(Color.Blue);

            Graphics graphics = Graphics.FromImage(bitmap);

            graphics.DrawRectangle(p,28,28,621,700);*/

            PictureBox Border1 = new PictureBox();
            Border1.BackColor = Color.Blue;
            Border1.Location = new Point(28, 28);
            Border1.Size = new Size(1, 700);
            
            PictureBox Border2 = new PictureBox();
            Border2.BackColor = Color.Blue;
            Border2.Location = new Point(28, 728);
            Border2.Size = new Size(621, 1);

            PictureBox Border3 = new PictureBox();
            Border3.BackColor = Color.Blue;
            Border3.Location = new Point(28, 28);
            Border3.Size = new Size(621, 1);

            PictureBox Border4 = new PictureBox();
            Border4.BackColor = Color.Blue;
            Border4.Location = new Point(649, 28);
            Border4.Size = new Size(1, 700);

            Controls.Add(Border1);
            Controls.Add(Border2);
            Controls.Add(Border3);
            Controls.Add(Border4);

            Controls.Add(SCORE);
        }

        private void Down(object MyObject, EventArgs eventArgs) => MoveRandCars();

        private void Defeat()
        {
            if (!IsInBorder(Car.Location.X, Car.Location.Y) || !Broke(Car.Location.X, Car.Location.Y))
            {
                score = 0;
                Car.Location = new Point(30, 629);
                for (int i = 0; i < Cars.Length; i++)
                    Cars[i].Location = new Point(30 + 101*i, 30);
                timer1.Stop();
                timer2.Stop();
                MessageBox.Show("YOU LOSE");

            }
        }

        private void MoveRandCars()
        {  
            Random r = new Random();
            int a , b=-1;
            Defeat();
            for (int i = 0; i <Cars.Length; i++)
            {
                if (IsInBorder(Cars[i].Location.X, Cars[i].Location.Y) )
                    Cars[i].Location = new Point(Cars[i].Location.X, Cars[i].Location.Y - diry * (car_size - 80));
                else
                {
                     a = r.Next(0, 6);
                    if(a == b)
                    {
                        while(a == b)
                        {
                            a = r.Next(0, 6);
                        }
                    }
                    Cars[i].Location = new Point(30 + (101 * a), 30);
                    score++;
                    b = a;
                }
            }   
        }

        private bool IsInBorder(int tx,int ty)
        {
            bool isBorder;
            if (tx<30 || tx >549 || ty<30 || ty >= 630 )
            {
                isBorder = false;
            }
            else
                isBorder = true;
            return isBorder;
        }

        private bool Broke(int tx,int ty)
        {
            bool IsBroke = true;
            
                if (!StartStart(tx,ty) || !StartEnd(tx,ty) || !EndStart(tx,ty) || !EndEnd(tx,ty))
                {
                    IsBroke = false;
                }
            return IsBroke;
           
        }

        private bool StartStart(int tx, int ty) 
        {
            bool B = true;
            for (int i = 0; i < Cars.Length; i++)
            {
                if (ty >= Cars[i].Location.Y && ty <= Cars[i].Location.Y + car_size && tx >= Cars[i].Location.X && tx <= Cars[i].Location.X + car_size)
                {
                    B = false;
                }
            } 
            return B;
        }

        private bool StartEnd(int tx, int ty)
        {
            bool B = true;
            for (int i = 0; i < Cars.Length; i++)
            {
                if (ty >= Cars[i].Location.Y && ty <= Cars[i].Location.Y + car_size && tx + car_size >= Cars[i].Location.X && tx + car_size <= Cars[i].Location.X + car_size)
                {
                    B = false;
                }
            }
            return B;
        }

        private bool EndStart(int tx, int ty)
        {
            bool B = true;
            for (int i = 0; i < Cars.Length; i++)
            {
                if (ty + car_size >= Cars[i].Location.Y && ty + car_size <= Cars[i].Location.Y + car_size && tx  >= Cars[i].Location.X && tx <= Cars[i].Location.X + car_size)
                {
                    B = false;
                }
            }
            return B;
        }

        private bool EndEnd(int tx, int ty)
        {
            bool B = true;
            for (int i = 0; i < Cars.Length; i++)
            {
                if (ty + car_size >= Cars[i].Location.Y && ty + car_size <= Cars[i].Location.Y + car_size && tx + car_size >= Cars[i].Location.X && tx + car_size <= Cars[i].Location.X + car_size)
                {
                    B = false;
                }
            }
            return B;
        }

        private void OKP(Object MyObject, KeyEventArgs e)
        {
            
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    Car.Location = new Point(Car.Location.X + car_size + 1 ,Car.Location.Y);
                    break;
                case "Left":
                    Car.Location = new Point(Car.Location.X - car_size - 1 , Car.Location.Y);
                    break;
                
            }
           
        }             
        private void NewGame_Click(object sender, EventArgs e)
        {
            Car.Location = new Point(30, 629);
            for (int i = 0; i < Cars.Length; i++)
                Cars[i].Location = new Point(30 + 101 * i, 30);
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            Car.Focus();
            timer2.Tick += new EventHandler(Down);

            timer2.Start();
        }

        private void PauseGame_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
        }

        private void GameOption_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            timer1.Stop();
            Form2 form2 = new Form2();
            
            form2.Show();
        }
 
    }
}
