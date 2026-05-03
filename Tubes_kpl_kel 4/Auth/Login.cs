using System.Security.Cryptography;
using System.Text;
using Tubes_kpl_kel_4.Validators;
using Tubes_kpl_kel_4.Models;

namespace Tubes_kpl_kel_4.Auth
{
    public enum StatusLogin
    {
        BelumLogin,
        Berhasil,
        Gagal
    }

    public class Login
    {
        public StatusLogin Status { get; private set; }
        public string Nama { get; private set; }
        public string Email { get; private set; }

        public User Pengguna;

        public Login()
        {
            Status = StatusLogin.BelumLogin;
        }

        public string LoginUser(string nama, string email, string password)
        {
            // Validasi input
            bool validNama = Validasi.ValidasiNama(nama);
            bool validEmail = Validasi.ValidasiEmail(email);
            bool validPass = Validasi.ValidasiPassword(password);

            if (!validNama || !validEmail || !validPass)
            {
                Status = StatusLogin.Gagal;
                return "Login gagal. Inputan tidak valid.";
            }

            // Hash password
            string hashedPassword = HashPassword(password);

            // Cek user hanya berdasarkan email dan hashed password
            bool userDitemukan = UserStorage.CariUserDenganHash(email, hashedPassword);

            if (userDitemukan)
            {
                Nama = nama;
                Email = email;
                Status = StatusLogin.Berhasil;
                return $"Login berhasil.\nNama: {nama}\nEmail: {email}";
            }
            else
            {
                Status = StatusLogin.Gagal;
                return "Login gagal. Data tidak ditemukan atau salah.";
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
