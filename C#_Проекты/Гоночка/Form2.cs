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
    public partial class Form2 : Form
    {
        public Button Hard = new Button();
        public Button Medium = new Button();
        public Button Easy = new Button();

        public Form2()
        {
            Width = 400;
            Height = 470;

            Hard.Size = new Size(360, 100);
            Hard.Location = new Point(20,50);
            Hard.Text = "Hard";
            Hard.Font = new Font(Hard.Font.Name, 20, Hard.Font.Style);

            Medium.Size = new Size(360, 100);
            Medium.Location = new Point(20, 200);
            Medium.Text = "Medium";
            Medium.Font = new Font(Hard.Font.Name,20,Hard.Font.Style);

            Easy.Size = new Size(360, 100);
            Easy.Location = new Point(20, 350);
            Easy.Text = "Easy";
            Easy.Font = new Font(Hard.Font.Name, 20, Hard.Font.Style);

            Controls.Add(Hard);
            Controls.Add(Medium);
            Controls.Add(Easy);

            InitializeComponent();
        }

        private void Hard_Click(object sender, EventArgs e)
        {
            Program.f1.timer2.Interval = 100;
            Close();
            
        }

        private void Medium_Click(object sender, EventArgs e)
        {
            
            Program.f1.timer2.Interval = 100;
            Close();
        }

        private void Easy_Click(object sender, EventArgs e)
        {
            
            Program.f1.timer2.Interval = 1000;
            Close();
        }

    }
}
