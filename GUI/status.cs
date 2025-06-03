using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tubes_kpl_kel_4.Reservasi;

namespace GUI
{
    public partial class status : Form
    {
        private StatusReservasi statusReservasi;
        public status()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            statusReservasi = new StatusReservasi();

            var viewModels = statusReservasi.DaftarReservasi.Select(r => new
            {
                r.Tempat,
                r.Ruangan,
                r.Kapasitas,
                NamaUser = r.jReservasi.NamaUser,
                Tanggal = r.jReservasi.Tanggal,
                Jam = $"{r.jReservasi.Mulai} - {r.jReservasi.Selesai}",
                r.Status,
                r.AlasanPembatalan
            }).ToList();

            dataGridView1.DataSource = viewModels;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu menuUtama = new menu();
            menuUtama.Show();
            this.Hide();
        }
    }
}

