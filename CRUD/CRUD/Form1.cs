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

namespace CRUD
{
    public partial class Form1 : Form
        {
            MySqlConnection connec = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=foreal");
            public Form1()
            {
                InitializeComponent();
            }

            void login()
            {
                try
                {
                    connec.Open();
                    MySqlDataAdapter sda = new MySqlDataAdapter("SELECT nama, password FROM users WHERE nama='" + txtNama.Text + "'AND password='" + txtPassword.Text + "'", connec);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            this.Hide();
                            Form2 form = new Form2();
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

            private void Form1_Load(object sender, EventArgs e)
            {
            }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            login();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    }
