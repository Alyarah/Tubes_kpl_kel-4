using System.ComponentModel.DataAnnotations;
using Tubes_kpl_kel_4.Validators;
using Tubes_kpl_kel_4.RiwayatReservasi;

class RegistrasiValidasi
{
    public static bool ValidasiNamaEmail(string nama, string email)
    {
        bool validNama = Validasi.ValidasiNama(nama);
        bool validEmail = Validasi.ValidasiEmail(email);

        Validasi.TampilkanHasil("Nama", validNama);
        Validasi.TampilkanHasil("Email", validEmail);

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
        bool validKode = Validasi.ValidasiKelas(kodeKelas);
        bool validAlasan = Validasi.ValidasiAlasan(alasan);

        Validasi.TampilkanHasil("Kode Kelas", validKode);
        Validasi.TampilkanHasil("Alasan", validAlasan);

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
        Validasi.TampilkanHasil("Feedback", validFeedback);

        Console.WriteLine("\n== Form Pembatalan ==");
        Console.Write("Kode Kelas: ");
        string kode = Console.ReadLine();
        Console.Write("Alasan: ");
        string alasan = Console.ReadLine();
        PembatalanValidasi.ValidasiPembatalan(kode, alasan);

        var riwayatService = new RiwayatService();

        Console.WriteLine("Masukkan nama untuk melihat riwayat reservasi:");
        Console.Write("Nama: ");
        nama = Console.ReadLine();

        var hasilRiwayat = riwayatService.GetRiwayatByNama(nama);

        if (hasilRiwayat.Count == 0)
        {
            Console.WriteLine("Tidak ada riwayat untuk nama tersebut.");
        }
        else
        {
            riwayatService.TampilkanRiwayat(hasilRiwayat);
        }
    }
}