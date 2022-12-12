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
using Org.BouncyCastle.Crypto;

namespace home
{
    public partial class penjualan : Form
    {
        public MySqlCommand cmd;
        public string idpenjualan;


        public penjualan()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            bayarutang bayarutang = new bayarutang();
            bayarutang.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            returnn returnn = new returnn();
            returnn.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // this.Hide();
            // penjualan penjualan = new penjualan();
            //penjualan.ShowDialog();
            button3.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            home home = new home();
            home.ShowDialog();
        }

        void Tampil()
        {
            try
            {
                Koneksi.conn.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM tblpenjualan", Koneksi.conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                TablePenjualan.DataSource = ds.Tables[0];
                Koneksi.conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Koneksi Gagal");
            }
        }

        private void penjualan_Load(object sender, EventArgs e)
        {
            Tampil();
        }

        private void TablePenjualan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Koneksi.conn.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `tblpenjualan` WHERE `namatoko` LIKE '%" + cari.Text + "%'", Koneksi.conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            TablePenjualan.DataSource = ds.Tables[0];
            Koneksi.conn.Close();
        }

        private void TablePenjualan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int baris = TablePenjualan.CurrentCell.RowIndex;
            idLab.Text = TablePenjualan.Rows[baris].Cells[0].Value.ToString();


            //  MessageBox.Show("baris ke" + baris.ToString());
            //MessageBox.Show("data berhasil");

            textBox3.Text = TablePenjualan.Rows[baris].Cells[1].Value.ToString();
            dateTimePicker1.Text = TablePenjualan.Rows[baris].Cells[1].Value.ToString();
            textBox1.Text = TablePenjualan.Rows[baris].Cells[2].Value.ToString();
            textBox4.Text = TablePenjualan.Rows[baris].Cells[3].Value.ToString();
            textBox5.Text = TablePenjualan.Rows[baris].Cells[4].Value.ToString();
            domainUpDown1.Text = TablePenjualan.Rows[baris].Cells[6].Value.ToString();
            textBox6.Text = TablePenjualan.Rows[baris].Cells[5].Value.ToString();


            textBox3.Enabled = true;
            dateTimePicker1.Enabled = true;
            textBox1.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            domainUpDown1.Enabled = true;
            textBox6.Enabled = true;

            btbatal.Enabled = true;
            btsimpan.Enabled = false;
            btubah.Enabled = true;
            bthapus.Enabled = true;
            bttambah.Enabled = false;
        }

        private void bttambah_Click(object sender, EventArgs e)
        {
            textBox3.Enabled = true;
            dateTimePicker1.Enabled = true;
            textBox1.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            domainUpDown1.Enabled = true;
            textBox6.Enabled = true;

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
                cmd = new MySqlCommand("UPDATE `tblpenjualan` SET `idfaktur` = '" + textBox3.Text + "', `tgl` = '" + dateTimePicker1.Text + "', `namapelanggan` = '" + textBox1.Text + "', `barang` = '" + textBox4.Text + "', `hargabarang` = '" + textBox5.Text + "', `jumlah` = '" + domainUpDown1.Text + "', `ketbarang` = '" + textBox6.Text + "' WHERE `tblpenjualan`.`idpenjualan` = '" + idLab.Text + "';", Koneksi.conn);
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
                cmd = new MySqlCommand("INSERT INTO `tblpenjualan` ( `idfaktur`, `tgl`, `namapelanggan`, `barang`, `hargabarang`, `jumlah`, `ketbarang`) VALUES (NULL, '" + textBox3.Text + "', '" + dateTimePicker1.Text + "', '" + textBox1.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + domainUpDown1.Text + "', '" + textBox6.Text + "');", Koneksi.conn);
                cmd.ExecuteNonQuery();
                Koneksi.conn.Close();
                Tampil();
            }
            catch (Exception)
            {
                MessageBox.Show("Gagal Update");
            }
        }
    }
}
