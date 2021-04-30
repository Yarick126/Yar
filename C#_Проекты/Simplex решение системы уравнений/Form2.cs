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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            fontDialog1.ShowColor = true;
        }
        
        

        public static int n;
        public static int m;
        List<Label> labels = new List<Label>();
        public List<TextBox> tb2list = new List<TextBox>();
        List<double> vs = new List<double>();
        public List<List<TextBox>> tblist = new List<List<TextBox>>();

        

        private void Form2_Load(object sender, EventArgs e)
        {
            int yk = 0;
            Width = 820;
            Height = 600;
            int x, xl, y = 60;

            for (int i = 0; i < m; i++)
            {
                x = 12;
                xl = 62;

                tblist.Add(new List<TextBox>());

                for (int j = 0; j <= n; j++)
                {
                    TextBox textb = new TextBox();
                    textb.Width = 40;

                    if (y + textb.Height > Height)
                    {
                        Height += y + textb.Height - Height;
                    }

                    textb.Location = new Point(x, y);
                    textb.Text = 0.ToString();
                    tblist[i].Add(textb);
                    Controls.Add(textb);

                    x += 70;
                    yk = y + textb.Height;
                    
                    if (j < n - 1)
                    {
                        Label lab = new Label();
                        lab.Width = 20;
                        if (y + lab.Height > Height)
                        {
                            Height += y + lab.Height - Height;
                        }
                        lab.Location = new Point(xl, y);
                        
                        lab.Text = "+";
                        labels.Add(lab);
                        Controls.Add(lab);

                    }
                    else if (j == n - 1)
                    {
                        Label lab = new Label();
                        lab.Width = 20;
                        if (y + lab.Height > Height)
                        {
                            Height += y + lab.Height - Height;
                        }
                        lab.Location = new Point(xl, y);
                        lab.Text = "<=";
                        labels.Add(lab);
                        Controls.Add(lab);
                    }
                    if(i==0 && j == n)
                    {
                        Label lab = new Label();
                        lab.Width = 50;
                        lab.Location = new Point(xl-50, 24);
                        lab.Text = "Запасы";
                        labels.Add(lab);
                        Controls.Add(lab);
                    }
                    xl += 70;
                }
                y += 40;
            }
            if (yk > Height)
            {
                y = 350 + (yk - Height);
                button1.Location = new Point(12,388 + (yk - Height));
            }
                
            else 
                y = 350;
            x = 20;
            Label label = new Label();
            label.Location = new Point(x, y);
            label.Text = "Целевая функция:";
            labels.Add(label);
            Controls.Add(label);
            x += 100;
            xl = 170;
            for (int i = 0; i <n; i++)
            {
                TextBox textb1 = new TextBox();
                textb1.Width = 40;
                if (x + textb1.Width > Width)
                    Width += 150;
                textb1.Location = new Point(x, y);
                textb1.Text = 0.ToString();
                tb2list.Add(textb1);
                Controls.Add(textb1);
                x += 70;
                if (i < n - 1)
                {
                    Label lab = new Label();
                    lab.Width = 20;
                    if (xl + lab.Width > Width)
                        Width += 150;
                    lab.Location = new Point(xl, y);
                    lab.Text = "+";
                    labels.Add(lab);
                    Controls.Add(lab);
                }
                else
                {
                    Label lab = new Label();
                    lab.Width = 50;
                    if (xl + lab.Width > Width)
                        Width += 150;
                    lab.Location = new Point(xl, y);
                    lab.Text = "-> max";
                    labels.Add(lab);
                    Controls.Add(lab);
                }
                xl += 70;
            }
        }

        /*public bool IsElementExists(Control control)
        {
            try
            {
                Controls.Find(control,true);
            }
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            double[,] a = new double[m,n+1];
            double[] z = new double[n+1];
            double[,] b = new double[m+1, n+1];
            int x = 200, y = 400;
            for(int i =0;i<n;i++)
            {
               Controls.Find("Lbl" + i, true);  
            }
            try
            {
                for(int i = 0; i <m; i++)
                {
                    for(int j = 0; j <=n; j++)
                    {
                        a[i,j] = Convert.ToDouble(tblist[i][j].Text);
                    }
                }
                for (int j = 0; j <=n; j++)
                {
                    if (j == n)
                    {
                        z[j] = 0;
                    }
                    else
                    {
                        z[j] = Convert.ToDouble(tb2list[j].Text)*-1;
                    }
                }

                for (int i = 0; i < m+1; i++)
                {
                    for (int j = 0; j <=n; j++)
                    {
                        if (i == m)
                        {
                            b[i, j] = z[j];
                        }
                        else
                            b[i, j] = a[i, j];
                    }
                }

                double[] result = new double[n];
                double[,] table;
                SimplexMethod S = new SimplexMethod(b);
                table = S.Counting(result);
                
                for(int i = 0; i < n; i++)
                {
                    Label lbl = new Label();
                    lbl.Location = new Point(x, y);
                    lbl.Name = "Lbl" + i;
                    lbl.Width = 60;
                    lbl.Text = "x" + (i+1) + " = " + Convert.ToString(Math.Round(result[i]));
                    labels.Add(lbl);
                    Controls.Add(lbl);
                    x += 100;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Вы не написали/дописали ввходные данные!");
            }
        }


        private string name;
        List<double> cfun = new List<double>();

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            string path;
            List<string> nums = new List<string>();
            
            string[] col;
            int n1 = 0;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                name = ofd.FileName;
                path = Path.Combine(Directory.GetCurrentDirectory(), name);
                using (StreamReader sr = new StreamReader(path, true))
                {
                    while (!sr.EndOfStream)
                    {
                        nums.Add(sr.ReadLine());
                        n1++;
                    }
                }
                for (int i = 0; i < n1; i++)
                {
                    col = nums[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < col.Length; j++)
                    {
                        if (i == n1-1)
                            cfun.Add(Convert.ToDouble(col[j]));
                        else
                            vs.Add(Convert.ToDouble(col[j]));
                    }
                }
                
                if (n1-1 != m && vs.Count != (n + 1 * m))
                {
                    MessageBox.Show("Количество чисел не совпадает с количеством ячеек!");
                    Close();
                }
                n1 = 0;
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n+1; j++)
                    {
                        tblist[i][j].Text = vs[n1].ToString();
                        n1++;
                    }
                }
                n1 = 0;
                foreach(TextBox a in tb2list)
                {
                    a.Text = cfun[n1].ToString();
                    n1++;
                }
            }
        }
        
       

        private void цветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.Cancel)
            return;
            // установка цвета формы
            BackColor = colorDialog1.Color;
            menuStrip1.BackColor = colorDialog1.Color;
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            foreach(Label a in labels)
            {
                a.Font = fontDialog1.Font;
                a.ForeColor = fontDialog1.Color;
            }
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path, text = "";
            foreach(List<TextBox> a in tblist)
            {
                foreach(TextBox b in a)
                    text += b.Text + " ";
                text += "\n";
            }
            foreach(TextBox a in tb2list)
            {
                text += a.Text + " ";
            }
            saveFileDialog1.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                name = saveFileDialog1.FileName;
                path = Path.Combine(Directory.GetCurrentDirectory(), name);
                using (StreamWriter streamWriter = new StreamWriter(path, true))
                {
                    streamWriter.Write(text);
                }
            }
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void свернутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
