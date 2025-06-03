using System.Text.Json.Nodes;
using System.Text.Json;
using Tubes_kpl_kel_4.Models;
using System.Text.Json.Serialization;
using System;

namespace Tubes_kpl_kel_4.Reservasi
{
    public class StatusReservasi
    {
        // List untuk menyimpan semua data reservasi
        public List<DataReservasi> DaftarReservasi { get; set; } = new List<DataReservasi>();

        // Path file JSON yang menyimpan data reservasi
        public string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kelas", "ListKelas.json");

        // Konstruktor mencoba membaca data reservasi dari file saat objek dibuat
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

        // Membaca data reservasi dari file JSON dan mengisi DaftarReservasi
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
            if (reservasiArray == null)
            {
                Console.WriteLine("Data 'Reservasi' tidak ditemukan dalam file JSON.");
                DaftarReservasi = new List<DataReservasi>();
                return;
            }

            // Deserialize data reservasi ke list
            DaftarReservasi = reservasiArray.Deserialize<List<DataReservasi>>(options);
        }

        // Menulis file konfigurasi baru ketika file JSON belum ada atau error
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

        // Menampilkan semua data reservasi ke console
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

                // Jika status reservasi dibatalkan, tampilkan alasannya
                if (res.Status == StatusReservasiEnum.Dibatalkan && !string.IsNullOrWhiteSpace(res.AlasanPembatalan))
                {
                    Console.WriteLine($"Alasan Pembatalan : {res.AlasanPembatalan}");
                }

                Console.WriteLine();
            }
        }

        // Menampilkan daftar kelas dengan filter hari dan kapasitas (opsional)
        public void TampilkanDaftarKelas(string hariFilter = "", int kapasitasFilter = 0)
        {
            Console.WriteLine("=== Daftar Kelas ===");

            var filteredKelas = DaftarReservasi;
            var filters = new List<Func<DataReservasi, bool>>();

            // Filter berdasarkan hari jika diisi
            if (!string.IsNullOrEmpty(hariFilter))
            {
                filters.Add(data => data.jReservasi.Tanggal.Contains(hariFilter));
            }

            // Filter berdasarkan kapasitas jika lebih dari 0
            if (kapasitasFilter > 0)
            {
                filters.Add(data => data.Kapasitas >= kapasitasFilter);
            }

            // Terapkan semua filter
            foreach (var filter in filters)
            {
                filteredKelas = filteredKelas.Where(filter).ToList();
            }

            if (filteredKelas.Count == 0)
            {
                Console.WriteLine("Tidak ada kelas yang sesuai dengan preferensi.");
                return;
            }

            // Tampilkan hasil filter
            foreach (var res in filteredKelas)
            {
                Console.WriteLine($"{res.Tempat} | {res.Ruangan} | Kapasitas {res.Kapasitas} orang");
                Console.WriteLine($"Nama Pemesan: {res.jReservasi.NamaUser}");
                Console.WriteLine($"Tanggal: {res.jReservasi.Tanggal}");
                Console.WriteLine($"Jam: {res.jReservasi.Mulai} - {res.jReservasi.Selesai}");
                Console.WriteLine();
            }
        }

        // Menampilkan status ketersediaan semua ruangan pada tanggal dan jam tertentu
        public void StatusRuangan(string Tanggal, string Mulai, string Selesai)
        {
            Console.WriteLine("=== Status Ketersediaan Ruangan ===");

            // Daftar semua ruangan yang tersedia
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

            // Cek tiap ruangan apakah sudah dipesan pada tanggal tersebut
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
                            // Jika sudah ada reservasi pada tanggal itu, tandai ruangan sebagai dipesan
                            dipesan = true;
                            break;
                        }
                    }
                }

                // Tampilkan status ruangan
                string status = dipesan ? "Sudah Dipesan" : "Tersedia";
                Console.WriteLine($"{ruangan.Tempat} | {ruangan.Ruangan} => {status}");
            }
        }

        // Menyimpan daftar reservasi ke file JSON
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
