using MySql.Data.MySqlClient;
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
    public partial class Form1 : Form
    {
        MySqlConnection connec = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=pts");
        public Form1()
        {
            InitializeComponent();
        }

        void login()
        {
            try
            {
                connec.Open();
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT NIS, Password FROM users WHERE NIS='" + txtNis.Text + "'AND Password='" + txtPassword.Text + "'", connec);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        this.Hide();
                        form2 form = new form2();
                        form.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Data tidak valid !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connec.Close();
            }
        }


        private void txtNis_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            login();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
