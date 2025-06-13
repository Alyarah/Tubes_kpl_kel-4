using Tubes_kpl_kel_4.Models;
using Tubes_kpl_kel_4.Validators;

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
        public StatusLogin Status { get; set; }
        public string Nama { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User Pengguna { get; set; }

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

            // Cek apakah user ditemukan
            bool userDitemukan = UserStorage.CariUser(nama, email, password);

            if (userDitemukan)
            {
                Pengguna = new User
                {
                    Nama = nama,
                    Email = email,
                    Password = password
                };

                Status = StatusLogin.Berhasil;

                return $"Login berhasil.\nNama: {nama}\nEmail: {email}";
            }
            else
            {
                Status = StatusLogin.Gagal;
                return "Login gagal. Data tidak ditemukan atau salah.";
            }
        }
    }
}
