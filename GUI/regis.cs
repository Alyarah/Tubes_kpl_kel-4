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
    public partial class regis : Form
    {
        public regis()
        {
            InitializeComponent();
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            halUtama home = new halUtama();
            home.Show();
            this.Hide();
        }

        private void label_nama_Click(object sender, EventArgs e)
        {

        }

        private void textBox_nama_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox_email_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox_pass_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_regis_Click(object sender, EventArgs e)
        {
            string nama = textBox_nama.Text;
            string email = textBox_email.Text;
            string pass = textBox_pass.Text;

            var registrasi = new Registrasi<User>
            {
                Nama = nama,
                Email = email,
                Password = pass
            };

            string hasil = registrasi.Register();
            MessageBox.Show(hasil);

            if (hasil.StartsWith("Registrasi berhasil"))
            {
                halUtama home = new halUtama();
                home.Show();
                this.Hide();
            }
        }

        private void regis_Load(object sender, EventArgs e)
        {

        }

        private void regis_Load_1(object sender, EventArgs e)
        {

        }
    }
}
