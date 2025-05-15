using System.Text.Json;
using System.Text.Json.Nodes;
using Tubes_kpl_kel_4.Reservasi;

namespace Tubes_kpl_kel_4.Reservasi
{
    public class StatusReservasi
    {
        public List<DataReservasi> DaftarReservasi { get; set; } = new();

        public const string filePath = "D:\\Praktikum Konstruksi PL\\Tubes_kpl_kel 4\\Tubes_kpl_kel 4\\Kelas.json";

        public StatusReservasi()
        {
            try
            {
                ReadStatusReservasi();
            }
            catch
            {
                Console.WriteLine("Gagal membaca konfigurasi");
                DaftarReservasi = new List<DataReservasi>();
                WriteNewConfigFile();
            }
        }

        private void ReadStatusReservasi()
        {
            string configJsonData = File.ReadAllText(filePath);
            var node = JsonNode.Parse(configJsonData);
            var reservasiArray = node["Reservasi"];
            DaftarReservasi = reservasiArray.Deserialize<List<DataReservasi>>();
        }

        private void WriteNewConfigFile()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(DaftarReservasi, options);
            File.WriteAllText(filePath, jsonString);
        }

        public void PrintStatusReservasi()
        {
            Console.WriteLine("=== Status Reservasi ===");
            if (DaftarReservasi.Count == 0)
            {
                Console.WriteLine("Tidak ada reservasi yang tersedia.");
                return;
            }

            foreach (var res in DaftarReservasi)
            {
                var jadwal = res.JadwalDetail;
                Console.WriteLine($"{res.NamaTempat} | {res.NamaRuangan} | Kapasitas {res.KapasitasRuangan} orang");
                Console.WriteLine($"Nama Pemesan : {jadwal.NamaUser}");
                Console.WriteLine($"Tanggal :  {jadwal.Tanggal}");
                Console.WriteLine($"Jam : {jadwal.JamMulai} - {jadwal.JamSelesai}");
                Console.WriteLine();
            }
        }

        public void TampilkanDaftarKelas(string hariFilter = "", int kapasitasFilter = 0)
        {
            Console.WriteLine("=== Daftar Kelas ===");
            var filtered = DaftarReservasi;

            if (!string.IsNullOrEmpty(hariFilter))
            {
                filtered = filtered.Where(r => r.JadwalDetail.Tanggal.Contains(hariFilter)).ToList();
            }

            if (kapasitasFilter > 0)
            {
                filtered = filtered.Where(r => r.KapasitasRuangan >= kapasitasFilter).ToList();
            }

            if (filtered.Count == 0)
            {
                Console.WriteLine("Tidak ada kelas yang sesuai dengan preferensi.");
                return;
            }

            foreach (var res in filtered)
            {
                var jadwal = res.JadwalDetail;
                Console.WriteLine($"{res.NamaTempat} | {res.NamaRuangan} | Kapasitas {res.KapasitasRuangan} orang");
                Console.WriteLine($"Nama Pemesan : {jadwal.NamaUser}");
                Console.WriteLine($"Tanggal : {jadwal.Tanggal}");
                Console.WriteLine($"Jam : {jadwal.JamMulai} - {jadwal.JamSelesai}");
                Console.WriteLine();
            }
        }

        public void StatusRuangan(string tanggal, string mulai, string selesai)
        {
            Console.WriteLine("=== Status Ketersediaan Ruangan ===");

            var semuaRuangan = new List<(string NamaTempat, string NamaRuangan)>
            {
                ("Gedung A", "R.01"), ("Gedung A", "R.02"), ("Gedung A", "R.03"),
                ("Gedung A", "R.04"), ("Gedung A", "R.05"),
                ("Gedung B", "R.01"), ("Gedung B", "R.02"), ("Gedung B", "R.03"),
                ("Gedung B", "R.04"), ("Gedung B", "R.05"),
                ("Lab", "01"), ("Lab", "02")
            };

            foreach (var ruangan in semuaRuangan)
            {
                bool dipesan = DaftarReservasi.Any(res =>
                    res.NamaTempat == ruangan.NamaTempat &&
                    res.NamaRuangan == ruangan.NamaRuangan &&
                    res.JadwalDetail.Tanggal == tanggal &&
                    mulai.CompareTo(res.JadwalDetail.JamSelesai) < 0 &&
                    selesai.CompareTo(res.JadwalDetail.JamMulai) > 0
                );

                string status = dipesan ? "Sudah Dipesan" : "Tersedia";
                Console.WriteLine($"{ruangan.NamaTempat} | {ruangan.NamaRuangan} => {status}");
            }
        }
    }
}
