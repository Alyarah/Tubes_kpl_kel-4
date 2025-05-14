using System.ComponentModel.DataAnnotations;
using Tubes_kpl_kel_4.RiwayatReservasi;

class RegistrasiValidasi
{
    public static bool ValidasiNamaEmail(string nama, string email)
    {
        bool validNama = Validator.Validasi.ValidasiNama(nama);
        bool validEmail = Validator.Validasi.ValidasiEmail(email);

        Validator.Validasi.TampilkanHasil("Nama", validNama);
        Validator.Validasi.TampilkanHasil("Email", validEmail);

        return validNama && validEmail;
    }
}

class FeedbackValidasi
{
    public static bool ValidasiIsiFeedback(string isi)
    {
        return !string.IsNullOrWhiteSpace(isi) && isi.Length >= 5;
    }
}

class PembatalanValidasi
{
    public static bool ValidasiPembatalan(string kodeKelas, string alasan)
    {
        bool validKode = Validator.Validasi.ValidasiKelas(kodeKelas);
        bool validAlasan = Validator.Validasi.ValidasiAlasan(alasan);

        Validator.Validasi.TampilkanHasil("Kode Kelas", validKode);
        Validator.Validasi.TampilkanHasil("Alasan", validAlasan);

        return validKode && validAlasan;
    }

}

class Program
{
    static void Main() 
    {
        Console.WriteLine("== Form Registrasi ==");
        Console.Write("Nama: ");
        string nama = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();
        RegistrasiValidasi.ValidasiNamaEmail(nama, email);

        Console.WriteLine("\n== Form Feedback ==");
        Console.Write("Isi feedback: ");
        string isi = Console.ReadLine();
        bool validFeedback = FeedbackValidasi.ValidasiIsiFeedback(isi);
        Validator.Validasi.TampilkanHasil("Feedback", validFeedback);

        Console.WriteLine("\n== Form Pembatalan ==");
        Console.Write("Kode Kelas: ");
        string kode = Console.ReadLine();
        Console.Write("Alasan: ");
        string alasan = Console.ReadLine();
        PembatalanValidasi.ValidasiPembatalan(kode, alasan);

        var daftarReservasi = new List<DataReservasi>
            {
                new DataReservasi { NamaPemesan = "Bella", Tempat = "Gedung A", Ruangan = "R.01", Tanggal = new DateTime(2024, 11, 15), Status = "Berhasil" },
                new DataReservasi { NamaPemesan = "Dian", Tempat = "Gedung A", Ruangan = "R.02", Tanggal = new DateTime(2024, 11, 16), Status = "Dibatalkan" },
                new DataReservasi { NamaPemesan = "Budi", Tempat = "Gedung A", Ruangan = "R.03", Tanggal = new DateTime(2024, 11, 17), Status = "Berhasil" },
                new DataReservasi { NamaPemesan = "Eka", Tempat = "Gedung B", Ruangan = "R.01", Tanggal = new DateTime(2024, 11, 18), Status = "TidakDikenal" }
            };

        var handler = new StatusHandler();

        Console.WriteLine("== Riwayat Reservasi (Hardcoded) ==");
        foreach (var reservasi in daftarReservasi)
        {
            handler.Tangani(reservasi);
        }
    }
}