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
        public StatusLogin Status { get; private set; }
        public string Nama { get; private set; }
        public string Email { get; private set; }

        public Login()
        {
            Status = StatusLogin.BelumLogin;
        }

        public string LoginUser(string nama, string email, string password)
        {
            if (password.Length >= 6)
            {
                Nama = nama;
                Email = email;
                Status = StatusLogin.Berhasil;
                return $"Login berhasil.\nNama: {nama}\nEmail: {email}";
            }
            else
            {
                Status = StatusLogin.Gagal;
                return "Login gagal. Password minimal harus 6 karakter.";
            }
        }
    }
}
