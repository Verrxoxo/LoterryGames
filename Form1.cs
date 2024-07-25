using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoterryGames
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        int iStore;
        DialogResult iExit;

        private List<CheckBox> CheckBoxes = new List<CheckBox>();  
        public Form1()
        {
            InitializeComponent();
            CreateCheckBoxes();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer4.Enabled = true;
        }
        private void CreateCheckBoxes()
        {
            int startX = 10;
            int startY = 10;
            int spacing = 30;
            int columns = 5;

            for (int i = 0; i < 50; i++)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = "Number " + (i + 1);
                checkBox.Name = i.ToString();
                checkBox.AutoSize = true;

                int row = i / columns;
                int column = i % columns;

                checkBox.Left = startX + (column * spacing * 3);
                checkBox.Top = startY + (row * spacing);

                this.Controls.Add(checkBox);
                CheckBoxes.Add(checkBox);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer3.Enabled = true;
            iStore = 20;

            string result = "";
            foreach (Control control in this.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    result += $"{checkBox.Text}: {(checkBox.Checked ? "Checked" : "Not Checked")}\n";
                }
            }
            MessageBox.Show(result, "Checkbox States", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int num1;
            num1 = rnd.Next(1, 50);
            txtLotto1.Text = Convert.ToString(num1);

            if (txtLotto1.Text == "0")
            {
                int num4;
                num4 = rnd.Next(1, 50);
                txtLotto1.Text = Convert.ToString(num4);
            }

            if (txtLotto1.Text == txtLotto2.Text || txtLotto1.Text == txtLotto3.Text)
            {
                num1 = rnd.Next(1, 50);
                txtLotto1.Text = Convert.ToString(num1);
            }
            txtLotto1.BackColor = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255));
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            iExit = MessageBox.Show("Confirm if you want to exit", "Lottery Game" ,MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (iExit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int num2;
            num2 = rnd.Next(1, 50);
            txtLotto2.Text = Convert.ToString(num2);

            if (txtLotto2.Text == "0")
            {
                int num4;
                num4 = rnd.Next(1, 50);
                txtLotto2.Text = Convert.ToString(num4);
            }

            if (txtLotto1.Text == txtLotto2.Text || txtLotto2.Text == txtLotto3.Text)
            {
                num2 = rnd.Next(1, 50);
                txtLotto1.Text = Convert.ToString(num2);
            }
            txtLotto2.BackColor = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255));
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            int num3;
            Random rnd = new Random();
            num3 = rnd.Next(1, 50);
            txtLotto3.Text = Convert.ToString(num3);
            
            if (txtLotto3.Text == "0")
            {
                num3 = rnd.Next(1, 50);
                txtLotto3.Text = Convert.ToString(num3);
            }
            
            if (txtLotto3.Text == txtLotto1.Text || txtLotto3.Text == txtLotto2.Text)
            {
                int num4;
                num4 = rnd.Next(1, 50);
                txtLotto3.Text = Convert.ToString(num4);
            }

            txtLotto3.BackColor = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255));
            label1.ForeColor = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255));
            btnLottery.BackColor = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255));
            btnLottery.ForeColor = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255));
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            iStore = iStore = 0;

            if (iStore == 0)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                timer4.Enabled = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}

