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
using Tubes_kpl_kel_4.Reservasi;

namespace GUI
{
    public partial class menu : Form
    {
        private User _user;

        public menu(User user)
        {
            InitializeComponent();
            _user = user;
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
            feedback feedbackForm = new feedback(_user);
            feedbackForm.Show();
            this.Hide();
        }

        private void button_daftarKelas_Click(object sender, EventArgs e)
        {
            try
            {
                var daftarKelasForm = new LihatDaftarKelas(_user);
                daftarKelasForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat membuka form Daftar Kelas: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reservasi reservasiForm = new reservasi(_user);
            reservasiForm.Show();
            this.Hide();
        }

        private void button_batalkan_Click(object sender, EventArgs e)
        {
            var dataReservasi = new StatusReservasi().DaftarReservasi;
            batalkan formPembatalan = new batalkan(_user, dataReservasi);
            formPembatalan.Show();
            this.Hide();
        }

        private void button_status_Click(object sender, EventArgs e)
        {
            status statusForm = new status(_user);
            statusForm.Show();
            this.Hide();
        }

        private void button_reservasi_Click(object sender, EventArgs e)
        {
            Riwayat riwayat = new Riwayat(_user);
            riwayat.Show();
            this.Hide();
        }

        private void menu_Load(object sender, EventArgs e)
        {

        }
    }
}
