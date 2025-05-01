namespace Tubes_kpl_kel_4
{
    class Program
    {
        static void Main()
        {
            var kelas = new lihatDaftarKelas("data.json");
            kelas.PrintDaftarKelas();
            Console.WriteLine();

            var statusReservasi = new StatusReservasi();
            statusReservasi.PrintStatusReservasi();
            Console.WriteLine();

            Console.WriteLine("Filter tanggal '2025-04-01' dan kapasitas minimal 30:");
            statusReservasi.TampilkanDaftarKelas("2025-04-01", 30);
            Console.WriteLine();

            Console.Write("Masukkan tanggal (yyyy-MM-dd): ");
            string Tanggal = Console.ReadLine();
            Console.Write("Masukkan waktu mulai (hh:mm): ");
            string Mulai = Console.ReadLine();
            Console.Write("Masukkan waktu selesai (hh:mm): ");
            string Selesai = Console.ReadLine();
            Console.WriteLine();
            statusReservasi.StatusRuangan(Tanggal, Mulai, Selesai);
        }
    }
}

