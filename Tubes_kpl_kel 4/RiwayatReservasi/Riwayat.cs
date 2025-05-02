using System;
using System.Collections.Generic;

namespace Tubes_kpl_kel_4.RiwayatReservasi
{
    class DataReservasi
    {
        public string NamaPemesan { get; set; }
        public string Tempat { get; set; }
        public string Ruangan { get; set; }
        public DateTime Tanggal { get; set; }
        public string Status { get; set; }
    }

    class StatusHandler
    {
        private readonly Dictionary<string, Action<DataReservasi>> _statusActions;

        public StatusHandler()
        {
            _statusActions = new Dictionary<string, Action<DataReservasi>>(StringComparer.OrdinalIgnoreCase)
            {
                { "Berhasil", TampilkanBerhasil },
                { "Dibatalkan", TampilkanDibatalkan }
            };
        }

        public void Tangani(DataReservasi reservasi)
        {
            if (_statusActions.TryGetValue(reservasi.Status, out var aksi))
            {
                aksi(reservasi);
            }
            else
            {
                Console.WriteLine($"[Status Tidak Dikenali] Nama: {reservasi.NamaPemesan} | Status: {reservasi.Status}");
            }
        }

        private void TampilkanBerhasil(DataReservasi r)
        {
            Console.WriteLine($"[BERHASIL] {r.NamaPemesan} memesan {r.Ruangan} di {r.Tempat} pada {r.Tanggal:d}");
        }

        private void TampilkanDibatalkan(DataReservasi r)
        {
            Console.WriteLine($"[DIBATALKAN] Reservasi oleh {r.NamaPemesan} untuk {r.Ruangan} dibatalkan.");
        }
    }
}
