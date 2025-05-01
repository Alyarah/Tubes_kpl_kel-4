using System.Text.Json;
using System.Text.Json.Nodes;

namespace Tubes_kpl_kel_4
{
    public class JadwalConfig
    {
        public string Tempat { get; set; }
        public string Ruangan { get; set; }
        public int Kapasitas { get; set; }
        public string Hari { get; set; }
        public string Mulai { get; set; }
        public string Selesai { get; set; }

        public JadwalConfig() { }

        public JadwalConfig(string Tempat, string Ruangan, int Kapasitaas, string Hari, string Mulai, string Selesai)
        {
            Tempat = Tempat;
            Ruangan = Ruangan;
            Kapasitas = Kapasitas;
            Hari = Hari;
            Mulai = Mulai;
            Selesai = Selesai;
        }
    }
    public class lihatDaftarKelas
    {
        public List<JadwalConfig> DaftarKelas { get; set; } = new List<JadwalConfig>();
        public const string filePath = "D:\\Praktikum Konstruksi PL\\Tubes_kpl_kel 4\\Tubes_kpl_kel 4\\Kelas.json";

        public lihatDaftarKelas(string configPath)
        {
            try
            {
                ReadJadwalConfig();
            }
            catch (Exception)
            {
                Console.WriteLine("Gagal membaca konfigurasi");
                DaftarKelas = new List<JadwalConfig>();
                WriteNewConfigFile();
            }
        }

        private void ReadJadwalConfig() 
        {
            String configJsonData = File.ReadAllText(filePath);
            var jsonObject = JsonSerializer.Deserialize<JsonObject>(configJsonData);

            if (jsonObject != null && jsonObject.ContainsKey("Jadwal"))
            {
                DaftarKelas = JsonSerializer.Deserialize<List<JadwalConfig>>(jsonObject["Jadwal"].ToString());
            }
            else
            {
                Console.WriteLine("Data 'Jadwal' tidak ditemukan dalam file JSON.");
                DaftarKelas = new List<JadwalConfig>();  // Jika tidak ada data jadwal
            }
        }

        private void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            String jsonString = JsonSerializer.Serialize(DaftarKelas, options);
            File.WriteAllText(filePath, jsonString);
        }
        public void PrintDaftarKelas()
        {
            Console.WriteLine("=== Daftar Kelas ===");
            foreach (var jadwal in DaftarKelas)
            {
                Console.WriteLine($"{jadwal.Hari} | {jadwal.Tempat} - {jadwal.Ruangan} | Kapasitas: {jadwal.Kapasitas} orang | {jadwal.Mulai} - {jadwal.Selesai}");
            }
        }
    }
} 
