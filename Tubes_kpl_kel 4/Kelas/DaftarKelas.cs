using System.Text.Json;
using System.Text.Json.Nodes;
using Tubes_kpl_kel_4.Models;

namespace Tubes_kpl_kel_4
{
    public class DaftarKelas
    {
        public List<Jadwal> ListKelas { get; set; } = new List<Jadwal>();
        public string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kelas", "ListKelas.json");

        public DaftarKelas(string configPath)
        {
            try
            {
                ReadJadwalConfig();
            }
            catch (Exception)
            {
                Console.WriteLine("Gagal membaca konfigurasi");
                ListKelas = new List<Jadwal>();
                WriteNewConfigFile();
            }
        }
        public class JadwalConfig
        {
            public List<Jadwal> Jadwal { get; set; }
        }

        private void ReadJadwalConfig()
        {
            String configJsonData = File.ReadAllText(filePath);
            var config = JsonSerializer.Deserialize<JadwalConfig>(configJsonData);

            if (config?.Jadwal != null)
            {
                ListKelas = config.Jadwal;
            }
            else
            {
                Console.WriteLine("Data 'Jadwal' tidak ditemukan dalam file JSON.");
                ListKelas = new List<Jadwal>();
            }
        }

        private void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            String jsonString = JsonSerializer.Serialize(ListKelas, options);
            File.WriteAllText(filePath, jsonString);
        }
        public void PrintDaftarKelas()
        {
            Console.WriteLine("=== Daftar Kelas ===");
            foreach (var jadwal in ListKelas)
            {
                Console.WriteLine($"{jadwal.Hari} | {jadwal.Tempat} - {jadwal.Ruangan} | Kapasitas: {jadwal.Kapasitas} orang | {jadwal.Mulai} - {jadwal.Selesai}");
            }
        }
    }
}