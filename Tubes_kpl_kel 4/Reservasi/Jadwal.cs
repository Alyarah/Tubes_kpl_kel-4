namespace Tubes_kpl_kel_4.Reservasi
{
    public class Jadwal
    {
        public string Tempat { get; set; }
        public string Ruangan { get; set; }
        public int Kapasitas { get; set; }
        public string Hari { get; set; }
        public string Mulai { get; set; }
        public string Selesai { get; set; }

        public Jadwal() { }

        public Jadwal(string Tempat, string Ruangan, int Kapasitas, string Hari, string Mulai, string Selesai)
        {
            Tempat = Tempat;
            Ruangan = Ruangan;
            Kapasitas = Kapasitas;
            Hari = Hari;
            Mulai = Mulai;
            Selesai = Selesai;
        }
    }

}
