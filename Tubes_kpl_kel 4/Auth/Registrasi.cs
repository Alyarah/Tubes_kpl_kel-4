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
            if (UserStorage.CekUserSudahAda(Nama, Email))
            {
                return "Registrasi gagal. User dengan nama dan email ini sudah terdaftar.";
            }

            // Tambah user baru
            var user = new TUser
            {
                Nama = Nama,
                Email = Email,
                Password = Password
            };

            UserStorage.TambahUser(user);

            return $"Registrasi berhasil untuk: {Nama}";
        }
    }
}
