using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button_logout_Click(object sender, EventArgs e)
        {
            halUtama home = new halUtama();
            home.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button_daftarKelas_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button_batalkan_Click(object sender, EventArgs e)
        {

        }

        private void button_status_Click(object sender, EventArgs e)
        {

        }

        private void button_reservasi_Click(object sender, EventArgs e)
        {

        }
    }
}
