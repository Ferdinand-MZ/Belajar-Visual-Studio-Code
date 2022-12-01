using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class Form2 : Form
    {
        string database = ("server=localhost; uid=root; database=crud_pbo; pwd='';");
        public MySqlConnection koneksi;
        public MySqlCommand cmd;
        public MySqlCommand command;
        public MySqlDataAdapter adp;
        public Form2()
        {
            InitializeComponent();
        }
        public void konek()
        {
            koneksi = new MySqlConnection(database);
            koneksi.Open();
        }
        public void disconek()
        {
            koneksi = new MySqlConnection(database);
            koneksi.Close();
        }
        public DataTable baca()
        {
            string sql = "select * from hal80";
            DataTable dt = new DataTable();
            try
            {
                konek();
                cmd = new MySqlCommand(sql, koneksi);
                adp = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ferdinand)
            {
                MessageBox.Show(ferdinand.ToString());
            }
            disconek();
            return dt;
        }

        public void Query(string query)
        {
            koneksi = new MySqlConnection(database);
            try
            {
                koneksi.Open();
                cmd = new MySqlCommand(query, koneksi);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ferdinand)
            {
                MessageBox.Show(ferdinand.Message);
            }
            finally
            {
                koneksi.Close();
            }
        }
        public void query()
        {
            try
            {
                koneksi = new MySqlConnection(database);
                koneksi.Open();
                string update = "UPDATE hal80 SET nama ='" + textBox2.Text + "',jenkel = '" + textBox3.Text + "', alamat = '" + textBox4.Text + "', kelas='" + textBox5.Text + "'WHERE nomor_induk='" + textBox1.Text + "'";
                command = new MySqlCommand(update, koneksi);
                command.ExecuteNonQuery();
                koneksi.Close();
                MessageBox.Show("Update Sukses", "informasi", MessageBoxButtons.OK);
                baca();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            baca();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Query("insert into hal80 values('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "')");
            MessageBox.Show("Insert data berhasil");
            baca();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            koneksi = new MySqlConnection(database);
            koneksi.Open();
            string del = "delete from hal80 WHERE nomor_induk='" + textBox1.Text + "'";
            command = new MySqlCommand(del, koneksi);
            command.ExecuteNonQuery();
            koneksi.Close();
            MessageBox.Show("Delete Sukses", "informasi", MessageBoxButtons.OK);
            baca();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            query();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baca();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)

            {

                SaveFileDialog save = new SaveFileDialog();

                save.Filter = "PDF (*.pdf)|*.pdf";

                save.FileName = "Hasil.pdf";

                bool ErrorMessage = false;

                if (save.ShowDialog() == DialogResult.OK)

                {

                    if (File.Exists(save.FileName))

                    {

                        try

                        {

                            File.Delete(save.FileName);

                        }

                        catch (Exception ex)

                        {

                            ErrorMessage = true;

                            MessageBox.Show("Unable to wride data in disk" + ex.Message);

                        }

                    }

                    if (!ErrorMessage)

                    {

                        try

                        {

                            PdfPTable pTable = new PdfPTable(dataGridView1.Columns.Count);

                            pTable.DefaultCell.Padding = 2;

                            pTable.WidthPercentage = 100;

                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in dataGridView1.Columns)

                            {

                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));

                                pTable.AddCell(pCell);

                            }

                            foreach (DataGridViewRow viewRow in dataGridView1.Rows)

                            {

                                foreach (DataGridViewCell dcell in viewRow.Cells)

                                {

                                    pTable.AddCell(dcell.Value.ToString());

                                }

                            }

                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))

                            {

                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);

                                PdfWriter.GetInstance(document, fileStream);

                                document.Open();

                                document.Add(pTable);

                                document.Close();

                                fileStream.Close();

                            }

                            MessageBox.Show("Data Export Successfully", "info");

                        }

                        catch (Exception ex)

                        {

                            MessageBox.Show("Error while exporting Data" + ex.Message);

                        }

                    }

                }

            }

            else

            {

                MessageBox.Show("No Record Found", "Info");

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["nomor_induk"].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["nama"].FormattedValue.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["jenkel"].FormattedValue.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["alamat"].FormattedValue.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["kelas"].FormattedValue.ToString();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
