using System;
using System.Collections.Generic;

namespace Tubes_kpl_kel_4
{
    public class Kelas
    {
        public string MataKuliah { get; set; }
        public string DosenPengajar { get; set; }
    }

    public class Rapat
    {
        public string Topik { get; set; }
        public List<string> Peserta { get; set; }
    }

    public class Acara
    {
        public string NamaAcara { get; set; }
        public string Penyelenggara { get; set; }
    }

    public class ReservasiRuangan<TJenis> where TJenis : class
    {
        public string NamaRuangan { get; set; }
        public DateTime Waktu { get; set; }
        public TJenis Kegiatan { get; set; }

        public string Reservasi()
        {
            string message = $"Reservasi untuk kegiatan '{typeof(TJenis).Name}' di ruangan {NamaRuangan} pada {Waktu:dd-MM-yyyy HH:mm} telah berhasil.";
            return message;

        }
    }
}