using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tubes_kpl_kel_4;
using Tubes_kpl_kel_4.Reservasi;
using Tubes_kpl_kel_4.Models;

namespace GUI
{
    public partial class Riwayat : Form
    {
        private User _namaUser; // Nama user yang sedang login
        private StatusReservasi _statusReservasi;

        public Riwayat(User NamaUser)
        {
            InitializeComponent();
            if (NamaUser == null)
            {
                MessageBox.Show("ERROR: User masih null saat masuk ke form Riwayat");
                return;
            }
            _namaUser = NamaUser;
            _statusReservasi = new StatusReservasi();
            TampilkanRiwayat(); // Panggil saat form dibuat
        }

        private void TampilkanRiwayat()
        {
            var riwayatUser = _statusReservasi.DaftarReservasi
                .Where(r => r.jReservasi.NamaUser.Equals(_namaUser.Nama, StringComparison.OrdinalIgnoreCase))
                .ToList();

            listBox1.Items.Clear();

            if (riwayatUser.Count == 0)
            {
                listBox1.Items.Add("Belum ada riwayat reservasi.");
                return;
            }

            foreach (var r in riwayatUser)
            {
                listBox1.Items.Add($"Tempat: {r.Tempat}, Ruangan: {r.Ruangan}");
                listBox1.Items.Add($"Tanggal: {r.jReservasi.Tanggal}, Jam: {r.jReservasi.Mulai} - {r.jReservasi.Selesai}");
                listBox1.Items.Add($"Status: {r.Status}");

                if (r.Status == StatusReservasiEnum.Dibatalkan && !string.IsNullOrWhiteSpace(r.AlasanPembatalan))
                    listBox1.Items.Add($"Alasan Pembatalan: {r.AlasanPembatalan}");

                listBox1.Items.Add("------------------------------------");
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {
            //kosong
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //kosong
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //kosong
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu home = new menu(_namaUser);
            home.Show();
            this.Hide();
        }

        private void Riwayat_Load(object sender, EventArgs e)
        {

        }
    }
}
