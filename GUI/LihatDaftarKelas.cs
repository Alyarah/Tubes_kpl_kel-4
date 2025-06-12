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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class LihatDaftarKelas : Form
    {
        public LihatDaftarKelas()
        {
            InitializeComponent();
        }

        private void LihatDaftarKelas_Load(object sender, EventArgs e)
        {
            //Mengakses lokasi json dan inisialisasi
            string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kelas", "ListKelas.json");
            DaftarKelas daftar = new DaftarKelas(configPath);

            //Menampilkan isi json ke list Box
            listBox1.Items.Clear();
            foreach (var jadwal in daftar.ListKelas)
            {
                string tampil = $"{jadwal.Hari} | {jadwal.Tempat} - {jadwal.Ruangan} | " +
                                $"Kapasitas: {jadwal.Kapasitas} | {jadwal.Mulai} - {jadwal.Selesai}";
                listBox1.Items.Add(tampil);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            try
            {
                menu menuUtama = new menu();
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

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
