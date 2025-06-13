using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tubes_kpl_kel_4.Auth;
using Tubes_kpl_kel_4.Models;


namespace GUI
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
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

        private void textBox_pass_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string nama = textBox_nama.Text;
            string email = textBox_email.Text;
            string pass = textBox_pass.Text;

            Login loginAuth = new Login();
            string hasilLogin = loginAuth.LoginUser(nama, email, pass);

            MessageBox.Show(hasilLogin);

            if (hasilLogin.StartsWith("Login berhasil"))
            {
                User userLogin = loginAuth.Pengguna;

                menu menuUtama = new menu(userLogin);
                menuUtama.Show();
                this.Hide();
            }
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            halUtama home = new halUtama();
            home.Show();
            this.Hide();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
