using Tubes_kpl_kel_4.Reservasi;

namespace Tubes_kpl_kel_4.Models
{
    public class RiwayatModel
    {
        public string NamaUser { get; set; }
        public string Tanggal { get; set; }
        public string Mulai { get; set; }
        public string Selesai { get; set; }
    }
            
        
        public class RiwayatReservasiItem
        {
            public Jadwal DetailJadwal { get; set; }
            public string Tempat { get; set; }
            public string Ruangan { get; set; }
            public int Kapasitas { get; set; }
            public string Status { get; set; } = "Berhasil";
            public string AlasanPembatalan { get; set; }
        }
    }
