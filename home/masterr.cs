using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace home
{
    public partial class masterr : Form
    {
        public masterr()
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
            Kategori kategori= new Kategori();
            kategori.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Barang barang= new Barang();
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
    }
}
