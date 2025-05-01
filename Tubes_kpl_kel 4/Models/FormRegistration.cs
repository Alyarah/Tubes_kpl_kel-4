namespace Tubes_kpl_kel_4.Models
{
    public class Mahasiswa
    {
        public string NIM { get; set; }
        public string Prodi { get; set; }
    }

    public class Dosen
    {
        public string NIP { get; set; }
        public string Fakultas { get; set; }
    }

    public class Staf
    {
        public string Divisi { get; set; }
        public string Jabatan { get; set; }
    }

    public class FormRegistration<TUser> where TUser : class, new()
    {
        public TUser UserData { get; set; }

        public string Register()
        {

            // Kembalikan pesan sukses
            string message = $"Registrasi berhasil untuk: {typeof(TUser).Name}";
            return message;
        }
    }
}
