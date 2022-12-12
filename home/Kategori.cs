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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace home
{
    public partial class Kategori : Form
    {
        public MySqlCommand cmd;
        public string idKategori;
        

        //Koneksi koneksi = new Koneksi();


        public Kategori()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi.conn.Open();
                cmd = new MySqlCommand("UPDATE `tblkategori` SET `namakategori` = '" + textBox1.Text + "' WHERE `tblkategori`.`idkategori` = '" + idKategori + "';", Koneksi.conn);
                cmd.ExecuteNonQuery();
                Koneksi.conn.Close();
                Tampil();
            }
            catch (Exception)
            {
                MessageBox.Show("Gagal Update");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Identitas identitas = new Identitas();
            identitas.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Barang barang = new Barang();
            barang.ShowDialog();
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

                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM tblkategori", Koneksi.conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                c.DataSource = ds.Tables[0];
                Koneksi.conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Koneksi Gagal");
            }
        }

        private void Kategori_Load(object sender, EventArgs e)
        {
            Tampil();
        }

        private void c_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int baris = c.CurrentCell.RowIndex;
            idKategori = c.Rows[baris].Cells[0].Value.ToString();
            //MessageBox.Show(id);

            textBox1.Text = c.Rows[baris].Cells[1].Value.ToString();

            textBox1.Enabled = true;
            btbatal.Enabled = true;
            btsimpan.Enabled = false;
            btubah.Enabled = true;
            bthapus.Enabled = true;
            bttambah.Enabled = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi.conn.Open();
                cmd = new MySqlCommand("INSERT INTO `tblkategori` (`idkategori`, `namakategori`) VALUES (NULL, '"+textBox1.Text+"');", Koneksi.conn);
                cmd.ExecuteNonQuery();
                Koneksi.conn.Close();
                Tampil();
            }
            catch (Exception)
            {
                MessageBox.Show("Gagal Update");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            btbatal.Enabled = true;
            btsimpan.Enabled = true;
            bttambah.Enabled = false;
            btubah.Enabled=false;
        }

        private void bthapus_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi.conn.Open();
                cmd = new MySqlCommand("DELETE FROM tblkategori WHERE `tblkategori`.`idkategori` = '"+idKategori+"'", Koneksi.conn);
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
            textBox1.Enabled=false;
            textBox1.Text = null;
            bttambah.Enabled=true;
            btbatal.Enabled = false;
            btsimpan.Enabled = false;
            bthapus.Enabled = false;
            btubah.Enabled = false;

        }

      
        private void button1_Click(object sender, EventArgs e)
        {
                Koneksi.conn.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `tblkategori` WHERE `namakategori` LIKE '%" + cari.Text + "%'", Koneksi.conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                c.DataSource = ds.Tables[0];
                Koneksi.conn.Close();
       
        }

        private void cari_TextChanged(object sender, EventArgs e)
        {

        }

        private void id1_Click(object sender, EventArgs e)
        {

        }
    }
}
