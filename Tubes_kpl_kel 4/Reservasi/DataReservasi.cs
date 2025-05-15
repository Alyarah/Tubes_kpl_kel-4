using System.Text.Json.Serialization;

namespace Tubes_kpl_kel_4.Reservasi
{
    public class JadwalReservasi
    {
        public string NamaUser { get; set; }
        [JsonPropertyName("Tanggal")]
        public string Tanggal { get; set; }
        public string Mulai { get; set; }
        public string Selesai { get; set; }
    }

    public class DataReservasi
    {
        [JsonPropertyName("Jadwal Reservasi")]
        public JadwalReservasi jReservasi { get; set; }
        public string Tempat { get; set; }
        public string Ruangan { get; set; }
        public int Kapasitas { get; set; }
        public StatusReservasiEnum Status { get; set; } = StatusReservasiEnum.Aktif;
        public string AlasanPembatalan { get; set; }
    }
}