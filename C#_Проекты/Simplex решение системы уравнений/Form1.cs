using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Simplex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            Form2.n = Convert.ToInt32(numericUpDown1.Value);
            Form2.m = Convert.ToInt32(numericUpDown2.Value);
            frm2.ShowDialog();  
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Form2.n = Convert.ToInt32(numericUpDown1.Value);
            
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Form2.m = Convert.ToInt32(numericUpDown2.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "Help.chm");
        }
    }
}
