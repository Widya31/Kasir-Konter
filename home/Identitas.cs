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
using Org.BouncyCastle.Asn1.X509;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace home
{
    public partial class Identitas : Form
    {
        public MySqlCommand cmd;
        public string ididentitas;


        //Koneksi koneksi = new Koneksi();

        public Identitas()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Kategori kategori = new Kategori();
            kategori.ShowDialog();
        }

        private void button5_Click_1(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
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

                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM tblidentitas", Koneksi.conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dgDatas.DataSource = ds.Tables[0];
                Koneksi.conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Koneksi Gagal");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void Identitas_Load(object sender, EventArgs e)
        {
           
        }

        private void Identitas_Load_1(object sender, EventArgs e)
        {
            Tampil();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi.conn.Open();
                cmd = new MySqlCommand("UPDATE `tblidentitas` SET `namatoko` = '" + TbNama.Text + "', `alamattoko` = '" + TbAlamat.Text + "', `nomortelpon` = '" + NoTelpon.Text + "', `captionpertama` = '" + Cap1.Text + "', `captionkedua` = '" + Cap2.Text + "', `captionketiga` = '" + Cap3.Text + "' WHERE `tblidentitas`.`ididentitas` = '" + idLab.Text + "';", Koneksi.conn);
                cmd.ExecuteNonQuery();
                Koneksi.conn.Close();
                Tampil();
            }
            catch (Exception)
            {
                MessageBox.Show("Gagal Update");
            } 
        }

        private void a_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int baris = dgDatas.CurrentCell.RowIndex;
            idLab.Text = dgDatas.Rows[baris].Cells[0].Value.ToString();
            

            //  MessageBox.Show("baris ke" + baris.ToString());
            //MessageBox.Show("data berhasil");

            TbNama.Text = dgDatas.Rows[baris].Cells[1].Value.ToString();
            TbAlamat.Text = dgDatas.Rows[baris].Cells[2].Value.ToString();
            NoTelpon.Text = dgDatas.Rows[baris].Cells[3].Value.ToString();
            Cap1.Text = dgDatas.Rows[baris].Cells[4].Value.ToString();
            Cap2.Text = dgDatas.Rows[baris].Cells[5].Value.ToString();
            Cap3.Text = dgDatas.Rows[baris].Cells[6].Value.ToString();

            TbNama.Enabled = true;
            TbAlamat.Enabled = true;
            NoTelpon.Enabled = true;
            Cap1.Enabled = true;
            Cap2.Enabled = true;
            Cap3.Enabled = true;

            btbatal.Enabled = true;
            btsimpan.Enabled = false;
            btubah.Enabled = true;
            bthapus.Enabled = true;
            bttambah.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
       {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            

            try
            {
                Koneksi.conn.Open();
                cmd = new MySqlCommand("INSERT INTO `tblidentitas` (`ididentitas`, `namatoko`, `alamattoko`, `nomortelpon`, `captionpertama`, `captionkedua`, `captionketiga`) VALUES (NULL, '" + TbNama.Text + "', '" + TbAlamat.Text + "', '" + NoTelpon.Text + "', '" + Cap1.Text + "', '" + Cap2.Text + "', '" + Cap3.Text + "');", Koneksi.conn);
                cmd.ExecuteNonQuery();
                Koneksi.conn.Close();
                Tampil();
            }
            catch (Exception)
            {
                MessageBox.Show("Gagal Update");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            TbNama.Enabled = true;
            TbAlamat.Enabled = true;
            NoTelpon.Enabled = true;
            Cap1.Enabled = true;
            Cap2.Enabled = true;
            Cap3.Enabled = true;

            btbatal.Enabled = true;
            btsimpan.Enabled = true;
            bttambah.Enabled = false;
            btubah.Enabled = false;
        }

        private void a_Click(object sender, EventArgs e)
        {

        }

        private void idLab_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi.conn.Open();
                cmd = new MySqlCommand("DELETE FROM tblidentitas WHERE `tblidentitas`.`ididentitas` = '"+idLab.Text+"';", Koneksi.conn);
                cmd.ExecuteNonQuery();
                Koneksi.conn.Close();
                Tampil();
            }
            catch (Exception)
            {
                MessageBox.Show("Gagal Update");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Koneksi.conn.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `tblidentitas` WHERE `namatoko` LIKE '%" + cari.Text + "%'", Koneksi.conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dgDatas.DataSource = ds.Tables[0];
            Koneksi.conn.Close();
        }

        private void btbatal_Click(object sender, EventArgs e)
        {
            TbNama.Enabled = true;
            TbNama.Text = null;
            TbAlamat.Enabled = true;
            TbAlamat.Text = null;
            NoTelpon.Enabled = true;
            NoTelpon.Text = null;
            Cap1.Enabled = true;
            Cap1.Text = null;
            Cap2.Enabled = true;
            Cap2.Text = null;
            Cap3.Enabled = true;
            Cap3.Text = null;

            bttambah.Enabled = true;
            btbatal.Enabled = false;
            btsimpan.Enabled = false;
            bthapus.Enabled = false;
            btubah.Enabled = false;
        }

        private void cari_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
