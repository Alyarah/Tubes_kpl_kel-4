namespace Tubes_kpl_kel_4.Validators
{
    public class Validasi
    {
        public static bool ValidasiNama(string nama)
        {
            return !string.IsNullOrWhiteSpace(nama) && nama.Length >= 3;
        }

        public static bool ValidasiEmail(string email)
        {
            return email.Contains("@") && (email.EndsWith(".com") || email.EndsWith(".ac.id"));
        }
        
        public static bool ValidasiTanggal(string tanggal, out DateTime result)
        {
            return DateTime.TryParse(tanggal, out result);
        }

        public static bool ValidasiAlasan(string alasan)
        {
            return !string.IsNullOrWhiteSpace(alasan) && alasan.Length >= 5;
        }

        public static bool ValidasiKelas(string kelas)
        {
            return true; //untuk saat ini
        }

        public static void TampilkanHasil(string namaField, bool hasil)
        {
            Console.WriteLine($"{namaField}: {(hasil ? "Valid" : "Tidak valid")}");
        }
    }
}
