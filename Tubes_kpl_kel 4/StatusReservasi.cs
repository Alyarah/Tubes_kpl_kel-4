using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Tubes_kpl_kel_4
{
    public class JadwalReservasi
    {
        public string NamaPemesan { get; set; }
        [JsonPropertyName("Tanggal ")]
        public string Tanggal { get; set; }
        public string Mulai { get; set; }
        public string Selesai { get; set; }
    }
    public class Reservasi
    {
        [JsonPropertyName("Jadwal Reservasi")]
        public JadwalReservasi jReservasi { get; set; }
        public string Tempat { get; set; }
        public string Ruangan { get; set; }
        public int Kapasitas { get; set; }
    }
    public class StatusReservasi
    {
        public  List<Reservasi>  DaftarReservasi { get; set; } = new List<Reservasi>();

        public const string filePath = "D:\\Praktikum Konstruksi PL\\Tubes_kpl_kel 4\\Tubes_kpl_kel 4\\Kelas.json";
        public StatusReservasi()
        {
            try
            {
                ReadStatusReservasi();
            }
            catch (Exception)
            {
                Console.WriteLine("Gagal membaca konfigurasi");
                DaftarReservasi = new List<Reservasi>();
                WriteNewConfigFile();
            }
        }

        private void ReadStatusReservasi()
        {
            string configJsonData = File.ReadAllText(filePath);
            var node = JsonNode.Parse(configJsonData);
            var reservasiArray = node["Reservasi"];
            DaftarReservasi = reservasiArray.Deserialize<List<Reservasi>>();
        }
        
        private void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            String jsonString = JsonSerializer.Serialize(DaftarReservasi, options);
            File.WriteAllText(filePath, jsonString);
        }
        public void PrintStatusReservasi()
        {
            Console.WriteLine("=== Status Reservasi ===:");
            if (DaftarReservasi.Count == 0)
            {
                Console.WriteLine("Tidak ada reservasi yang tersedia.");
                return;
            }
            foreach (var res in DaftarReservasi)
            {
                Console.WriteLine($"{res.Tempat} | {res.Ruangan} | Kapasitas {res.Kapasitas} orang");
                var jadwal = res.jReservasi;
                    Console.WriteLine($"Nama Pemesan : {jadwal.NamaPemesan}");
                    Console.WriteLine($"Tanggal :  {jadwal.Tanggal}");
                    Console.WriteLine($"Jam : {jadwal.Mulai} - {jadwal.Selesai}");
                Console.WriteLine();

            }
        }
        public void TampilkanDaftarKelas(string hariFilter = "", int kapasitasFilter = 0)
        {
            Console.WriteLine("=== Daftar Kelas ===:");
            var filteredKelas = DaftarReservasi;
            if (!string.IsNullOrEmpty(hariFilter))
            {
                filteredKelas = filteredKelas.Where(r => r.jReservasi.Tanggal.Contains(hariFilter)).ToList();
            }

            if (kapasitasFilter > 0)
            {
                filteredKelas = filteredKelas.Where(r => r.Kapasitas >= kapasitasFilter).ToList();
            }

            if (filteredKelas.Count == 0)
            {
                Console.WriteLine("Tidak ada kelas yang sesuai dengan preferensi.");
                return;
            }

            foreach (var res in filteredKelas)
            {
                Console.WriteLine($"{res.Tempat} | {res.Ruangan} | Kapasitas {res.Kapasitas} orang");
                Console.WriteLine($"Nama Pemesan: {res.jReservasi.NamaPemesan}");
                Console.WriteLine($"Tanggal: {res.jReservasi.Tanggal}");
                Console.WriteLine($"Jam: {res.jReservasi.Mulai} - {res.jReservasi.Selesai}");
                Console.WriteLine();
            }
        }

        public void StatusRuangan(string Tanggal, string Mulai, string Selesai)
        {
            Console.WriteLine("=== Status Ketersediaan Ruangan ===");

            var semuaRuangan = new List<(string Tempat, string Ruangan)>
            {
                ("Gedung A", "R.01"),
                ("Gedung A", "R.02"),
                ("Gedung A", "R.03"),
                ("Gedung A", "R.04"),
                ("Gedung A", "R.05"),
                ("Gedung B", "R.01"),
                ("Gedung B", "R.02"),
                ("Gedung B", "R.03"),
                ("Gedung B", "R.04"),
                ("Gedung B", "R.05"),
                ("Lab", "01"),
                ("Lab", "02")
            };

            foreach (var ruangan in semuaRuangan)
            {
                bool dipesan = false;

                foreach (var reservasi in DaftarReservasi)
                {
                    if (reservasi.Tempat == ruangan.Tempat && reservasi.Ruangan == ruangan.Ruangan)
                    {
                        var jadwal = reservasi.jReservasi;
                        if (jadwal.Tanggal == Tanggal)
                        {
                            if (reservasi.Tempat == ruangan.Tempat && reservasi.Ruangan == ruangan.Ruangan)
                            {
                                dipesan = true;
                                break;
                            }
                        }
                    }
                }

                string status = dipesan ? "Sudah Dipesan" : "Tersedia";
                Console.WriteLine($"{ruangan.Tempat} | {ruangan.Ruangan} => {status}");
            }
        }
    }
}
