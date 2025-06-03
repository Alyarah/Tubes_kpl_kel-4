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
using Tubes_kpl_kel_4;
using Tubes_kpl_kel_4.Reservasi;
using Tubes_kpl_kel_4.Validators;
namespace GUI
{
    public partial class batalkan : Form
    {
        private List<DataReservasi> daftarReservasi;

        public batalkan()
        {
            InitializeComponent();

        }

        public void SetData(List<DataReservasi> data)
        {
            this.daftarReservasi = data;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tempat = textBox1.Text.Trim();
            string ruangan = textBox2.Text.Trim();
            string tanggal = textBox3.Text.Trim();
            string jamMulai = textBox4.Text.Trim();
            string alasan = textBox5.Text.Trim();

            if (string.IsNullOrWhiteSpace(tempat) || string.IsNullOrWhiteSpace(ruangan) ||
                string.IsNullOrWhiteSpace(tanggal) || string.IsNullOrWhiteSpace(jamMulai) ||
                string.IsNullOrWhiteSpace(alasan))
            {
                MessageBox.Show("Semua field harus diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Validasi.ValidasiAlasan(alasan))
            {
                MessageBox.Show("Alasan pembatalan tidak valid.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PembatalanReservasi pembatalan = new PembatalanReservasi(daftarReservasi);
            bool sukses = pembatalan.Batalkan(tempat, ruangan, tanggal, jamMulai, alasan);

            if (sukses)
            {
                MessageBox.Show("Reservasi berhasil dibatalkan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Tutup form
            }
            else
            {
                MessageBox.Show("Reservasi tidak ditemukan atau gagal dibatalkan.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            menu menuUtama = new menu();
            menuUtama.Show();
            this.Hide();
        }
    }
}
