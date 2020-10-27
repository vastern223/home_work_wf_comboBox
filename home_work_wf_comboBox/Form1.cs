using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace home_work_wf_comboBox
{
    public partial class Form1 : Form
    {
        decimal sum1 = 0;
        decimal sum = 0;
        decimal allSum = 0;
        decimal sum_a = 0;
        decimal sum_b = 0;
        decimal sum_c = 0;
        decimal sum_d = 0;
        decimal sum_all = 0;
        Timer timer = new Timer();
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedItem = "A-76";
            timer.Tick += new EventHandler(Show_info);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "A-76")
            {
                label3.Text = "20";
            }
            if (comboBox1.SelectedItem.ToString() == "A-85")
            {
                label3.Text = "25";
            }
            if (comboBox1.SelectedItem.ToString() == "A-95")
            {
                label3.Text = "27";
            }
            if (comboBox1.SelectedItem.ToString() == "A-100")
            {
                label3.Text = "30";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = radioButton1.Checked;
            radioButton2.Enabled = false;
            numericUpDown2.Enabled = false;
            label7.Text = "грн";
            groupBox2.Text = "До сплати";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown2.Enabled = radioButton2.Checked;
            radioButton1.Enabled = false;
            numericUpDown1.Enabled = false;
            label7.Text = "л";
            groupBox2.Text = "До видачі";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            sum1 = int.Parse(numericUpDown1.Text) * int.Parse(label3.Text);
            label19.Text = sum1.ToString();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            float litruv = int.Parse(numericUpDown2.Text) / int.Parse(label3.Text);
            label19.Text = litruv.ToString();
            sum1 = int.Parse(numericUpDown2.Text);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown3.Enabled = checkBox1.Checked;
            if (checkBox1.Checked == false)
            {
                sum_a -= numericUpDown3.Value * decimal.Parse(label10.Text);
                sum_all -= sum_a;
                label20.Text = sum_all.ToString();
                numericUpDown3.Value = 0;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown4.Enabled = checkBox2.Checked;
            if (checkBox2.Checked == false)
            {
                sum_b -= numericUpDown4.Value * decimal.Parse(label11.Text);
                sum_all -=sum_b;
                label20.Text = sum_all.ToString();
                numericUpDown4.Value = 0;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown5.Enabled = checkBox3.Checked;
            if (checkBox3.Checked == false)
            {

                sum_c -= numericUpDown5.Value * decimal.Parse(label12.Text);
                sum_all -= sum_c;
                label20.Text = sum_all.ToString();
                numericUpDown5.Value = 0;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown6.Enabled = checkBox4.Checked;
            if (checkBox4.Checked == false)
            {
                sum_d -= numericUpDown6.Value * decimal.Parse(label13.Text);
                sum_all -= sum_d;
                label20.Text = sum_all.ToString();
                numericUpDown6.Value = 0;
            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            sum_a = 0;
            sum_a += numericUpDown3.Value * decimal.Parse(label10.Text);
            sum_all = sum_a + sum_b + sum_c + sum_d;
            label20.Text = sum_all.ToString();

        }
        
        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            sum_c = 0;
            sum_c += numericUpDown5.Value * decimal.Parse(label12.Text);
            sum_all = sum_a + sum_b + sum_c + sum_d;
            label20.Text = sum_all.ToString();
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            sum_d = 0;
            sum_d += numericUpDown6.Value * decimal.Parse(label13.Text);
            sum_all = sum_a + sum_b + sum_c + sum_d;
            label20.Text = sum_all.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Interval = 10000;
            textBox9.Text += sum_a + sum_b + sum_c + sum_d + sum1;
            allSum += sum_a + sum_b + sum_c + sum_d + sum1;
            label17.Text = allSum.ToString();
            timer.Start();
        }

        private void Show_info(object sender, EventArgs e)
        {
            timer.Stop();
            DialogResult res = MessageBox.Show($"наявність клієнта ?", "магазин!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                comboBox1.SelectedItem = "A-76";
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                numericUpDown1.Value = 0;
                numericUpDown2.Value = 0;
                numericUpDown3.Value = 0;
                numericUpDown4.Value = 0;
                numericUpDown5.Value = 0;
                numericUpDown6.Value = 0;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                textBox9.Text = null;
                label19.Text = null;
                label20.Text = null;
                label7.Text = null;
                sum1 = 0;
                sum = 0;
                groupBox2.ResetText();
            }
            else if (res == DialogResult.No)
            {
                timer.Start();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
           
                sum_b = 0;
                sum_b += numericUpDown4.Value * decimal.Parse(label11.Text);
                sum_all = sum_a + sum_b + sum_c + sum_d;
                label20.Text = sum_all.ToString();
            
        }

    }
}
