using System.Text.Json.Serialization;

namespace Tubes_kpl_kel_4.Reservasi
{
    public class JadwalReservasi
    {
        public string NamaUser { get; set; }
        [JsonPropertyName("Tanggal")]
        public string Tanggal { get; set; }
        public string JamMulai { get; set; }
        public string JamSelesai { get; set; }
    }

    public class DataReservasi
    {
        [JsonPropertyName("Jadwal Reservasi")]
        public JadwalReservasi JadwalDetail { get; set; }

        public string NamaTempat { get; set; }
        public string NamaRuangan { get; set; }
        public int KapasitasRuangan { get; set; }
    }
}
