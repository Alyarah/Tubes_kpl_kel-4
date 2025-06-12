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

namespace GUI
{
    public partial class Riwayat : Form
    {
        private string _namaUser; // Nama user yang sedang login
        private StatusReservasi _statusReservasi;
        private string? namaUser;

        public Riwayat()
        {
            InitializeComponent();
            _namaUser = namaUser;
            _statusReservasi = new StatusReservasi();
            TampilkanRiwayat(); // Panggil saat form dibuat
        }

        private void TampilkanRiwayat()
        {
            var riwayatUser = _statusReservasi.DaftarReservasi
                .Where(r => r.jReservasi.NamaUser.Equals(_namaUser, StringComparison.OrdinalIgnoreCase)) 
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
            halUtama home = new halUtama();
            home.Show();
            this.Hide();
        }
    }
}
