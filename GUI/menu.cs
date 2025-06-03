using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tubes_kpl_kel_4.Auth;
using Tubes_kpl_kel_4.Models;

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

        private void button_feedback_Click(object sender, EventArgs e)
        {
            feedback feedbackForm = new feedback();
            feedbackForm.Show();
            this.Hide();
        }

        private void button_daftarKelas_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            reservasi reservasiForm = new reservasi();
            reservasiForm.Show();
            this.Hide();
        }

        private void button_batalkan_Click(object sender, EventArgs e)
        {
            batalkan batalkanForm = new batalkan();
            batalkanForm.Show();
            this.Hide();
        }

        private void button_status_Click(object sender, EventArgs e)
        {

        }

        private void button_reservasi_Click(object sender, EventArgs e)
        {
            
        }

        private void menu_Load(object sender, EventArgs e)
        {

        }
    }
}
