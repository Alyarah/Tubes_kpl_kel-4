using System.Security.Cryptography;
using System.Text;
using Tubes_kpl_kel_4.Models;
using Tubes_kpl_kel_4.Validators;

namespace Tubes_kpl_kel_4.Auth
{
    public class Registrasi<TUser> where TUser : User, new()
    {
        public string Nama { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Register()
        {
            // Validasi input
            bool validNama = Validasi.ValidasiNama(Nama);
            bool validEmail = Validasi.ValidasiEmail(Email);
            bool validPassword = Validasi.ValidasiPassword(Password);

            if (!validNama || !validEmail || !validPassword)
            {
                return "Registrasi gagal. Inputan tidak valid.";
            }

            // Cek apakah user sudah terdaftar
            if (UserStorage.CekUserSudahAda(Email))
            {
                return "Registrasi gagal. User dengan email ini sudah terdaftar.";
            }

            // Hash password sebelum disimpan
            string hashedPassword = HashPassword(Password);

            var user = new TUser
            {
                Nama = Nama,
                Email = Email,
                Password = hashedPassword
            };

            UserStorage.TambahUser(user);

            return $"Registrasi berhasil untuk: {Nama}";
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
