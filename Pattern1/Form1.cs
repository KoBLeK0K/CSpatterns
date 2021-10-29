using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pattern1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        public float catchCheck(float x)
        {
            string text = textBox1.Text;
            float sum = float.Parse(text);
            float sumWithCash = sum * x + sum;
            return sumWithCash;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            float x = 0.03f;
            label2.Text = catchCheck(x).ToString("0.00");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            float x = 0.1f;
            label3.Text = catchCheck(x).ToString("0.00");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            float x = 0.15f;
            label4.Text = catchCheck(x).ToString("0.00");
        }

       
    }
}
