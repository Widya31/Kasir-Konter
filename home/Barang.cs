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
    public partial class Barang : Form
    {
        public MySqlCommand cmd;
        public string idbarang;

        public Barang()
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

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pelanggan pelanggan = new Pelanggan();
            pelanggan.ShowDialog();
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

        void Tampil()
        {
            try
            {
                Koneksi.conn.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM tblbarang", Koneksi.conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                b.DataSource = ds.Tables[0];
                Koneksi.conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Koneksi Gagal");
            }
        }

        private void Barang_Load(object sender, EventArgs e)
        {
            Tampil();
        }

        private void b_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int baris = b.CurrentCell.RowIndex;
            idbarang = b.Rows[baris].Cells[0].Value.ToString();
            //MessageBox.Show(id);

            textBox11.Text = b.Rows[baris].Cells[1].Value.ToString();
            textBox22.Text = b.Rows[baris].Cells[2].Value.ToString();
            textBox33.Text = b.Rows[baris].Cells[3].Value.ToString();
            textBox44.Text = b.Rows[baris].Cells[4].Value.ToString();

            textBox11.Enabled = true;
            textBox22.Enabled = true;
            textBox33.Enabled = true;
            textBox44.Enabled = true;

            btbatal.Enabled = true;
            btsimpan.Enabled = false;
            btubah.Enabled = true;
            bthapus.Enabled = true;
            bttambah.Enabled = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Koneksi.conn.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `tblbarang` WHERE `namabarang` LIKE '%" + cari.Text + "%'", Koneksi.conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            b.DataSource = ds.Tables[0];
            Koneksi.conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Enabled = false;
        }

        private void bttambah_Click(object sender, EventArgs e)
        {
            textBox11.Enabled = true;
            textBox22.Enabled = true;
            textBox33.Enabled = true;
            textBox44.Enabled = true;

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
                cmd = new MySqlCommand("UPDATE `tblbarang` SET `namabarang` = '" + textBox11.Text + "', `hargabeli` = '" + textBox22.Text + "', `hargajual` = '" + textBox33.Text + "', `stokbarang` = '" + textBox44.Text + "' WHERE `tblbarang`.`idbarang` = '" + idbarang + "';", Koneksi.conn);
                cmd.ExecuteNonQuery();
                Koneksi.conn.Close();
                Tampil();
            }
            catch (Exception)
            {
                MessageBox.Show("Gagal Update");
            }
        }

        private void bthapus_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi.conn.Open();
                cmd = new MySqlCommand("DELETE FROM tblbarang WHERE `tblbarang`.`idbarang` = '"+idbarang+"'", Koneksi.conn);
                cmd.ExecuteNonQuery();
                Koneksi.conn.Close();
                Tampil();
            }
            catch (Exception)
            {
                MessageBox.Show("Gagal Update");
            }
        }

        private void btsimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi.conn.Open();
                cmd = new MySqlCommand("INSERT INTO `tblbarang` (`idbarang`, `namabarang`, `hargabeli`, `hargajual`, `stokbarang`) VALUES (NULL, '" + textBox11.Text + "', '" + textBox22.Text + "', '" + textBox33.Text + "', '" + textBox44.Text + "');", Koneksi.conn);
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
            textBox11.Enabled = false;
            textBox11.Text = null;
            textBox22.Enabled = false;
            textBox22.Text = null;
            textBox33.Enabled = false;
            textBox33.Text = null;
            textBox44.Enabled = false;
            textBox44.Text = null;

            bttambah.Enabled = true;
            btbatal.Enabled = false;
            btsimpan.Enabled = false;
            bthapus.Enabled = false;
            btubah.Enabled = false;
        }
    }
}
