using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class FormCalculate : Form
    {
        public FormCalculate()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {

            try

            {

                var num1 = decimal.Parse(this.textBox1.Text);

                var num2 = decimal.Parse(this.textBox2.Text);

                var sum = num1 + num2;

                textBoxSum.Text = sum.ToString();

            }

            catch (Exception)

            {

                textBoxSum.Text = "error";

            }

        }
    }
}
