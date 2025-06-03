using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Tubes_kpl_kel_4.Models;

namespace Tubes_kpl_kel_4
{
    public class DaftarKelas
    {
        public List<Jadwal> ListKelas { get; set; } = new List<Jadwal>();

        public string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kelas", "ListKelas.json");

        public DaftarKelas(string configPath)
        {
            filePath = configPath;

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

        // Kelas untuk deserialisasi JSON
        public class JadwalConfig
        {
            public List<Jadwal> Jadwal { get; set; }
        }

        // Membaca konfigurasi jadwal dari file JSON
        private void ReadJadwalConfig()
        {
            string configJsonData = File.ReadAllText(filePath);
            var config = JsonSerializer.Deserialize<JadwalConfig>(configJsonData);

            if (config?.Jadwal == null)
            {
                Console.WriteLine("Data 'Jadwal' tidak ditemukan dalam file JSON.");
                ListKelas = new List<Jadwal>();
            }
            else
            {
                ListKelas = config.Jadwal;
            }
        }

        // Menulis file konfigurasi baru jika file tidak ada atau gagal dibaca
        private void WriteNewConfigFile()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(new JadwalConfig { Jadwal = ListKelas }, options);
            File.WriteAllText(filePath, jsonString);
        }

        // Menampilkan seluruh daftar kelas
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
