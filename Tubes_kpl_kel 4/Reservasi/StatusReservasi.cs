using System.Text.Json.Nodes;
using System.Text.Json;
using Tubes_kpl_kel_4.Models;
using System.Text.Json.Serialization;
using System;

namespace Tubes_kpl_kel_4.Reservasi
{
    public class StatusReservasi
    {
        public List<DataReservasi> DaftarReservasi { get; set; } = new List<DataReservasi>();

        public string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kelas", "ListKelas.json");
        public StatusReservasi()
        {
            try
            {
                ReadStatusReservasi();
            }
            catch (Exception)
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
            if (node == null)
            {
                Console.WriteLine("File JSON kosong atau tidak valid.");
                DaftarReservasi = new List<DataReservasi>();
                return;
            }
            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() }
            };

            var reservasiArray = node["Reservasi"];
            if(reservasiArray == null)
    {
                Console.WriteLine("Data 'Reservasi' tidak ditemukan dalam file JSON.");
                DaftarReservasi = new List<DataReservasi>();
                return;
            }
            DaftarReservasi = reservasiArray.Deserialize<List<DataReservasi>>(options);
        }

        private void WriteNewConfigFile()
        {
            var jsonNode = new JsonObject
            {
                ["Reservasi"] = JsonSerializer.SerializeToNode(DaftarReservasi, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters = { new JsonStringEnumConverter() }
                })
            };
            File.WriteAllText(filePath, jsonNode.ToJsonString(new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() }
            }));
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
                Console.WriteLine($"{res.Tempat} | {res.Ruangan} | Kapasitas {res.Kapasitas} orang");
                var jadwal = res.jReservasi;
                Console.WriteLine($"Nama Pemesan : {jadwal.NamaUser}");
                Console.WriteLine($"Tanggal :  {jadwal.Tanggal}");
                Console.WriteLine($"Jam : {jadwal.Mulai} - {jadwal.Selesai}");
                Console.WriteLine($"Status : {res.Status}");

                if (res.Status == StatusReservasiEnum.Dibatalkan && !string.IsNullOrWhiteSpace(res.AlasanPembatalan))
                {
                    Console.WriteLine($"Alasan Pembatalan : {res.AlasanPembatalan}");
                }

                Console.WriteLine();
            }
        }

        public void TampilkanDaftarKelas(string hariFilter = "", int kapasitasFilter = 0)
        {
            Console.WriteLine("=== Daftar Kelas ===");
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
                Console.WriteLine($"Nama Pemesan: {res.jReservasi.NamaUser}");
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

        public void SimpanReservasiKeFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() }
            };
            var jsonNode = new JsonObject
            {
                ["Reservasi"] = JsonSerializer.SerializeToNode(DaftarReservasi, options)
            };
            File.WriteAllText(filePath, jsonNode.ToJsonString(options));
        }

    }
}