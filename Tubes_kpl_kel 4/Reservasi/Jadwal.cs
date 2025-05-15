namespace Tubes_kpl_kel_4.Reservasi
{
    public class Jadwal
    {
        public string NamaTempat { get; set; }
        public string NamaRuangan { get; set; }
        public int KapasitasRuangan { get; set; }
        public string Hari { get; set; }
        public string JamMulai { get; set; }
        public string JamSelesai { get; set; }

        public Jadwal() { }

        public Jadwal(string namaTempat, string namaRuangan, int kapasitasRuangan, string hari, string jamMulai, string jamSelesai)
        {
            NamaTempat = namaTempat;
            NamaRuangan = namaRuangan;
            KapasitasRuangan = kapasitasRuangan;
            Hari = hari;
            JamMulai = jamMulai;
            JamSelesai = jamSelesai;
        }
    }
}
