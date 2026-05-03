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
        private User _namaUser; // Menyimpan data user yang sedang login
        private StatusReservasi _statusReservasi; // Menyimpan status reservasi

        public Riwayat(User NamaUser)
        {
            InitializeComponent();

            if (NamaUser == null) //Cek input user untuk mencegah null reference
            {
                MessageBox.Show("ERROR: User masih null saat masuk ke form Riwayat");
                this.Close();
                return;
            }

            _namaUser = NamaUser;
            _statusReservasi = new StatusReservasi();

            try 
            {
                TampilkanRiwayat();
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Terjadi error saat menampilkan riwayat: {ex.Message}");
            }
        }

        private void TampilkanRiwayat()
        {
            if (_statusReservasi.DaftarReservasi == null) 
            {
                MessageBox.Show("Data reservasi tidak tersedia.");
                return;
            }

            var riwayatUser = _statusReservasi.DaftarReservasi
                .Where(r => r?.jReservasi?.NamaUser != null && 
                            r.jReservasi.NamaUser.Equals(_namaUser.Nama, StringComparison.OrdinalIgnoreCase))
                .ToList();

            listBox1.Items.Clear();

            if (riwayatUser.Count == 0)
            {
                listBox1.Items.Add("Belum ada riwayat reservasi.");
                return;
            }

            foreach (var r in riwayatUser)
            {
                if (r == null || r.jReservasi == null) 
                    continue;

                listBox1.Items.Add($"Tempat: {r.Tempat ?? "(Tidak diketahui)"}, Ruangan: {r.Ruangan ?? "(Tidak diketahui)"}"); 
                listBox1.Items.Add($"Tanggal: {r.jReservasi.Tanggal}, Jam: {r.jReservasi.Mulai} - {r.jReservasi.Selesai}");
                listBox1.Items.Add($"Status: {r.Status}");

                if (r.Status == StatusReservasiEnum.Dibatalkan && !string.IsNullOrWhiteSpace(r.AlasanPembatalan)) 
                    listBox1.Items.Add($"Alasan Pembatalan: {r.AlasanPembatalan}");

                listBox1.Items.Add("------------------------------------");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Tidak digunakan
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Tidak digunakan
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Tidak digunakan
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_namaUser == null) //Pastikan user valid sebelum buka menu
            {
                MessageBox.Show("User tidak valid. Tidak dapat kembali ke menu.");
                return;
            }

            menu home = new menu(_namaUser);
            home.Show();
            this.Hide();
        }

        private void Riwayat_Load(object sender, EventArgs e)
        {
            // Tidak digunakan
        }
    }
}
