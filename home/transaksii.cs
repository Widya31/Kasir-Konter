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
    public partial class transaksii : Form
    {
        Koneksi koneksi = new Koneksi();

        public void Tampil()
        {
            
            
        }
        public transaksii()
        {
            InitializeComponent();
        }

        private void transaksii_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            penjualan penjualan = new penjualan();
            penjualan.ShowDialog();
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            home home = new home();
            home.ShowDialog();
        }
    }
}
