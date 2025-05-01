using Tubes_kpl_kel_4.Validators;

namespace Tubes_kpl_kel_4
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

        public Login()
        {
            Status = StatusLogin.BelumLogin;
        }

        public string LoginUser(string nama, string email, string password)
        {
            bool validNama = Validasi.ValidasiNama(nama);
            bool validEmail = Validasi.ValidasiEmail(email);
            bool validPass = Validasi.ValidasiPassword(password);

            if (!validNama || !validEmail || !validPass)
            {
                Status = StatusLogin.Gagal;
                return "Login gagal. Nama, Email, atau Password tidak valid.";
            }
            else
            {
                Nama = nama;
                Email = email;
                Password = password;
                Status = StatusLogin.Berhasil;
                return $"Login berhasil.\nNama: {nama}\nEmail: {email}";
            }
        }
    }
}
