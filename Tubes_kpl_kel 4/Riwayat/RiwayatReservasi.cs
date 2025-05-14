using System;
using System.Collections.Generic;
using Tubes_kpl_kel_4.Reservasi;

namespace Tubes_kpl_kel_4.RiwayatReservasi
{
    public class StatusHandler
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

        private void TampilkanBerhasil(DataReservasi r)
        {
            Console.WriteLine($"[BERHASIL] {r.jReservasi.NamaUser} memesan {r.Ruangan} di {r.Tempat} pada {r.jReservasi.Tanggal:d}");
        }

        private void TampilkanDibatalkan(DataReservasi r)
        {
            Console.WriteLine($"[DIBATALKAN] Reservasi oleh {r.jReservasi.NamaUser} untuk {r.Ruangan} dibatalkan.");
        }

        public void TampilkanStatus(DataReservasi reservasi, string status)
        {
            if (_statusActions.TryGetValue(status, out var aksi))
            {
                aksi(reservasi);
            }
            else
            {
                Console.WriteLine("[STATUS TIDAK DIKENAL]");
            }
        }
    }
}
