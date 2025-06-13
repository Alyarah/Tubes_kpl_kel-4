using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tubes_kpl_kel_4.Models;
using Tubes_kpl_kel_4.Reservasi;
using Tubes_kpl_kel_4;

namespace GUI
{
    public partial class reservasi : Form
    {
        private User _user;

        public reservasi(User user)
        {
            InitializeComponent();
            _user = user;
        }

        public reservasi()
        {
            InitializeComponent();
        }

        private void label_tempat_Click(object sender, EventArgs e)
        {

        }

        private void textBox_mulai_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_selesai_Click(object sender, EventArgs e)
        {

        }

        private void textBox_selesai_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_jam_Click(object sender, EventArgs e)
        {

        }

        private void reservasi_Load(object sender, EventArgs e)
        {

        }

        private void button_submit_Click(object sender, EventArgs e)
        {
            string temp = tempat.Text.Trim();
            string ruangan = textBox_ruangan.Text.Trim();
            string kapasitasStr = textBox_kapasitas.Text.Trim();
            string tanggal = textBoxt_tanggal.Text.Trim(); // format: yyyy-MM-dd
            string jamMulai = textBox_mulai.Text.Trim();  // format: HH:mm
            string jamSelesai = textBox_selesai.Text.Trim(); // format: HH:mm

            if (string.IsNullOrWhiteSpace(temp) || string.IsNullOrWhiteSpace(ruangan) ||
                string.IsNullOrWhiteSpace(kapasitasStr) || string.IsNullOrWhiteSpace(tanggal) ||
                string.IsNullOrWhiteSpace(jamMulai) || string.IsNullOrWhiteSpace(jamSelesai))
            {
                MessageBox.Show("Semua field harus diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(kapasitasStr, out int kapasitas))
            {
                MessageBox.Show("Kapasitas harus berupa angka.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!DateTime.TryParse(tanggal, out _))
            {
                MessageBox.Show("Format tanggal salah. Gunakan yyyy-MM-dd.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var jadwalList = new List<Jadwal>();
            var reservasiList = new List<DataReservasi>();
            var daftarKelas = new DaftarKelas(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kelas", "ListKelas.json"));
            var statusReservasi = new StatusReservasi();

            var reservasiRuangan = new ReservasiRuangan<User, Jadwal, DataReservasi>(_user, jadwalList, reservasiList, daftarKelas, statusReservasi);

            string hasil = reservasiRuangan.LakukanReservasi(temp, ruangan, kapasitas, tanggal, jamMulai, jamSelesai);

            MessageBox.Show(hasil, "Hasil Reservasi", MessageBoxButtons.OK, hasil.StartsWith("Sukses")
                ? MessageBoxIcon.Information: MessageBoxIcon.Error);

            tempat.Clear();
            textBox_ruangan.Clear();
            textBox_kapasitas.Clear();
            textBoxt_tanggal.Clear();
            textBox_mulai.Clear();
            textBox_selesai.Clear();

        }

        private void tempat_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            menu menuUtama = new menu(_user);
            menuUtama.Show();
            this.Hide();
        }

        private void textBoxt_tanggal_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
