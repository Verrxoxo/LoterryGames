using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LoterryGames
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        DialogResult iExit;
        private List<CheckBox> CheckBoxes = new List<CheckBox>();
        private List<CheckBox> SelectedCheckBoxes = new List<CheckBox>();

        private bool resetMode = false;

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
                checkBox.Text = "" + (i + 1);
                checkBox.Name = i.ToString();
                checkBox.AutoSize = true;

                int row = i / columns;
                int column = i % columns;

                checkBox.Left = startX + (column * spacing * 3);
                checkBox.Top = startY + (row * spacing);

                checkBox.CheckedChanged += CheckBox_CheckedChanged;

                this.Controls.Add(checkBox);
                CheckBoxes.Add(checkBox);
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = sender as CheckBox;

            if (checkBox.Checked)
            {
                if (SelectedCheckBoxes.Count >= 3)
                {
                    MessageBox.Show("You can only select up to 3 numbers.");
                    checkBox.Checked = false;
                    return;
                }
                SelectedCheckBoxes.Add(checkBox);
            }
            else
            {
                SelectedCheckBoxes.Remove(checkBox);
            }

           
        }

        private void UpdatePictureBoxes()
        {
            if (SelectedCheckBoxes.Count == 3)
            {
                var selectedNumbers = GetSelectedNumbers();
                var generatedNumbers = GetGeneratedNumbers();
                int matchCount = selectedNumbers.Count(n => generatedNumbers.Contains(n));

                pictureBox1.Visible = (matchCount >= 2);

                pictureBox2.Visible = (matchCount < 2);

            }
        }

        private int[] GetSelectedNumbers()
        {
            return SelectedCheckBoxes.Select(cb => int.Parse(cb.Text.Replace("Number ", ""))).ToArray();
        }

        private int[] GetGeneratedNumbers()
        {
            HashSet<int> numbers = new HashSet<int>();
            while (numbers.Count < 3)
            {
                numbers.Add(rnd.Next(1, 50));
            }
            return numbers.ToArray();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (resetMode)
            {
                ResetSelections();
                ResetHighlights();
                ClearOutputs();
                pictureBox1.Visible=false;
                pictureBox2.Visible=false;
                Lotterbtn.Text = "Lotter"; 
                resetMode = false; 
                
                return;
            }

            Lotterbtn.Text = "Clear";

            int num1 = 0;
            int num2 = 0;
            int num3 = 0;

            Lotterbtn.Enabled = false;

            for (int i = 0; i < 10; i++)
            {
                 num1 = rnd.Next(1, 50);
                 num2 = rnd.Next(1, 50);
                 num3 = rnd.Next(1, 50);

                txtLotto1.Text = num1.ToString();
                txtLotto2.Text = num2.ToString();
                txtLotto3.Text = num3.ToString();

                txtLotto1.BackColor = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255));
                txtLotto2.BackColor = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255));
                txtLotto3.BackColor = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255));

                await Task.Delay(300);
            }

            Lotterbtn.Enabled = true;

            HighlightMatchingCheckBoxes(num1, num2, num3);
            UpdatePictureBoxes();
           
            string result = "";
            foreach (Control control in this.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    result += $"{checkBox.Text}\n";
                }
            }

            if (string.IsNullOrEmpty(result))
            {
                result = "No numbers are checked. You need to che";
            }

            MessageBox.Show(result, "Checked numbers", MessageBoxButtons.OK, MessageBoxIcon.Information);

                resetMode = true;
            

    }
        private void HighlightMatchingCheckBoxes(params int[] numbers)
        {

            foreach (var checkBox in CheckBoxes)
            {
                if (checkBox.Checked)
                {
                    checkBox.BackColor = Color.PowderBlue; 
                }
                else
                {
                    checkBox.BackColor = Color.Transparent; 
                }
            }

            foreach (var checkBox in CheckBoxes)
            {
                if (int.TryParse(checkBox.Text.Replace("Number ", ""), out int number))
                {
                    if (numbers.Contains(number))
                    {
                        checkBox.BackColor = Color.LightGreen;
                    }
                }
            }
        }

        private void ResetSelections()
        {
            var checkBoxesToReset = new List<CheckBox>(SelectedCheckBoxes);
            foreach (var checkBox in checkBoxesToReset)
            {
                checkBox.Checked = false;
            }
            SelectedCheckBoxes.Clear();
        }

        private void ResetHighlights()
        {
            foreach (var checkBox in CheckBoxes)
            {
                checkBox.BackColor = Color.Empty;
            }
        }

        private void ClearOutputs()
        {
            txtLotto1.Clear();
            txtLotto2.Clear();
            txtLotto3.Clear();
            txtLotto1.BackColor = SystemColors.Window;
            txtLotto2.BackColor = SystemColors.Window;
            txtLotto3.BackColor = SystemColors.Window;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void txtLotto3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

