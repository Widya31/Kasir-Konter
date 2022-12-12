using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace home
{
    public partial class Pelanggan : Form
    {
        public MySqlCommand cmd;
        public string idPelanggan;


        public Pelanggan()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Identitas identitas = new Identitas();
            identitas.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Kategori kategori = new Kategori();
            kategori.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Barang barang = new Barang();
            barang.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            home home = new home();
            home.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Pelanggan_Load(object sender, EventArgs e)
        {
            Tampil();
        }

        void Tampil()
        {
            try
            {
                Koneksi.conn.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM tblpelanggan", Koneksi.conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                d.DataSource = ds.Tables[0];
                Koneksi.conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Koneksi Gagal");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Koneksi.conn.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `tblpelanggan` WHERE `namapelanggan` LIKE '%" + cari.Text + "%'", Koneksi.conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            d.DataSource = ds.Tables[0];
            Koneksi.conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Enabled = false;
        }

        private void btsimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi.conn.Open();
                cmd = new MySqlCommand("INSERT INTO `tblpelanggan` (`idpelanggan`, `namapelanggan`, `alamatpelanggan`, `nomortelpon`) VALUES (NULL, '" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "');", Koneksi.conn);
                cmd.ExecuteNonQuery();
                Koneksi.conn.Close();
                Tampil();
            }
            catch (Exception)
            {
                MessageBox.Show("Gagal Update");
            }
        }

        private void btbatal_Click(object sender, EventArgs e)
        {
            int baris = d.CurrentCell.RowIndex;
            idPelanggan = d.Rows[baris].Cells[0].Value.ToString();
            //MessageBox.Show(id);

            textBox1.Text = d.Rows[baris].Cells[1].Value.ToString();
            textBox2.Text = d.Rows[baris].Cells[2].Value.ToString();
            textBox3.Text = d.Rows[baris].Cells[3].Value.ToString();

            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;

            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;

            btbatal.Enabled = true;
            btsimpan.Enabled = false;
            btubah.Enabled = true;
            bthapus.Enabled = true;
            bttambah.Enabled = false;
        }

        private void bttambah_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;

            btbatal.Enabled = true;
            btsimpan.Enabled = true;
            bttambah.Enabled = false;
            btubah.Enabled = false;
        }

        private void btubah_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi.conn.Open();
                cmd = new MySqlCommand("UPDATE `tblpelanggan` SET `namapelanggan` = '" + textBox1.Text + "', `alamatpelanggan` = '" + textBox2.Text + "', `nomortelpon` = '" + textBox3.Text + "' WHERE `tblpelanggan`.`idpelanggan` = '" + idPelanggan + "';", Koneksi.conn);
                cmd.ExecuteNonQuery();
                Koneksi.conn.Close();
                Tampil();
            }
            catch (Exception)
            {
                MessageBox.Show("Gagal Update");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi.conn.Open();
                cmd = new MySqlCommand("DELETE FROM tblpelanggan WHERE `tblpelanggan`.`idpelanggan` = '" + idPelanggan + "';", Koneksi.conn);
                cmd.ExecuteNonQuery();
                Koneksi.conn.Close();
                Tampil();
            }
            catch (Exception)
            {
                MessageBox.Show("Gagal Update");
            }
        }

        private void d_Click(object sender, EventArgs e)
        {

        }

        private void d_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int baris = d.CurrentCell.RowIndex;
            idPelanggan = d.Rows[baris].Cells[0].Value.ToString();
            //MessageBox.Show(id);

            textBox1.Text = d.Rows[baris].Cells[1].Value.ToString();
            textBox2.Text = d.Rows[baris].Cells[1].Value.ToString();
            textBox3.Text = d.Rows[baris].Cells[1].Value.ToString();

            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;

            btbatal.Enabled = true;
            btsimpan.Enabled = false;
            btubah.Enabled = true;
            bthapus.Enabled = true;
            bttambah.Enabled = false;
        }
    }
}
