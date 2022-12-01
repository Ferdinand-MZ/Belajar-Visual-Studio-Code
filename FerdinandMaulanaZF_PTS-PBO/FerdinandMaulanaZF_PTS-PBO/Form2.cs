using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerdinandMaulanaZF_PTS_PBO
{
    public partial class form2 : Form
    {
        public form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnHitung_Click(object sender, EventArgs e)
        {
            double a, b;
            a = Convert.ToDouble(txt1.Text);
            b = Convert.ToDouble(txt3.Text);
            if (cbo1.Text == "x")
            {
                txt4.Text = (a * b).ToString();
            }
            else if (cbo1.Text == "+")
            {
                txt4.Text = (a + b).ToString();
            }
            else if (cbo1.Text == "-")
            {
                txt4.Text = (a - b).ToString();
            }
            else if (cbo1.Text == ":")
            {
                txt4.Text = (a / b).ToString();
            }
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            Form1 form = new Form1();
            form.Show();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txt1.Clear();
            txt3.Clear();
            txt4.Clear();
        }
    }
}
