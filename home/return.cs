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
    public partial class returnn : Form
    {
        Koneksi koneksi = new Koneksi();

       
        public returnn()
        {
            InitializeComponent();
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            home home = new home();
            home.ShowDialog();
        }

        private void returnn_Load(object sender, EventArgs e)
        {
            
        }
    }
}
