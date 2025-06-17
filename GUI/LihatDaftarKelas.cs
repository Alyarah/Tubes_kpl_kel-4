using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tubes_kpl_kel_4;
using Tubes_kpl_kel_4.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class LihatDaftarKelas : Form
    {
        private User _user;

        public LihatDaftarKelas(User user)
        {
            InitializeComponent();
            _user = user;
        }

        // Menampilkan dan mengecek file daftar kelas
        private void LihatDaftarKelas_Load(object sender, EventArgs e)
        {
            //Mengakses lokasi json dan inisialisasi
            string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kelas", "ListKelas.json");
            
            // Cek apakah file daftar kelas ditemukan
            if (!File.Exists(configPath))
            {
                MessageBox.Show("File daftar kelas tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DaftarKelas daftar = new DaftarKelas(configPath);
                
                //Menampilkan isi json ke list Box
                listBoxDaftarKelas.Items.Clear();
                foreach (var jadwal in daftar.ListKelas)
                {
                    string tampil = $"{jadwal.Hari} | {jadwal.Tempat} - {jadwal.Ruangan} | " +
                                    $"Kapasitas: {jadwal.Kapasitas} | {jadwal.Mulai} - {jadwal.Selesai}";
                    listBoxDaftarKelas.Items.Add(tampil);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data kelas.\n" + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Tidak digunakan
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            try
            {
                menu menuUtama = new menu(_user);
                menuUtama.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal kembali ke menu.\n" + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //Tidak digunakan
        }

        private void listBoxDaftarKelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Tidak digunakan
        }
    }
}
