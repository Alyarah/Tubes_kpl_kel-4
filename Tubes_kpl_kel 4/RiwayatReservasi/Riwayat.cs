namespace Tubes_kpl_kel_4.RiwayatReservasi
{
    class DataReservasi
    {
        public string NamaPemesan { get; set; }
        public string NamaKelas { get; set; }
        public DateTime Tanggal { get; set; }
        public string Status { get; set; }  // Contoh: "Dibatalkan", "Berhasil", "Ditolak"
    }

    class RiwayatService
    {
            private readonly List<DataReservasi> _dataRiwayat;

            public RiwayatService()
            {
                // Ini adalah "tabel" data statis (bisa diganti dari database nanti)
                _dataRiwayat = new List<DataReservasi>
            {
                new DataReservasi { NamaPemesan = "Bella", NamaKelas = "Ruang A101", Tanggal = new DateTime(2024, 11, 15), Status = "Berhasil" },
                new DataReservasi { NamaPemesan = "Dian", NamaKelas = "Ruang B202", Tanggal = new DateTime(2024, 11, 16), Status = "Dibatalkan" },
                new DataReservasi { NamaPemesan = "Budi", NamaKelas = "Lab Komputer", Tanggal = new DateTime(2024, 11, 17), Status = "Berhasil" },
            };
            }

            public List<DataReservasi> GetSemuaRiwayat()
            {
                return _dataRiwayat;
            }

            public List<DataReservasi> GetRiwayatByNama(string nama)
            {
                return _dataRiwayat.FindAll(r => r.NamaPemesan.Equals(nama, StringComparison.OrdinalIgnoreCase));
            }

            public void TampilkanRiwayat(List<DataReservasi> riwayatList)
            {
                Console.WriteLine("\n== Riwayat Reservasi ==");
                foreach (var item in riwayatList)
                {
                    Console.WriteLine($"Nama: {item.NamaPemesan} | Kelas: {item.NamaKelas} | Tanggal: {item.Tanggal.ToShortDateString()} | Status: {item.Status}");
            }
        }
    }
}
