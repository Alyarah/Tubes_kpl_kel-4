namespace Tubes_kpl_kel_4
{
        public enum StatusReservasi
        {
            Aktif,
            Dibatalkan
        }

        public class PembatalanReservasi
        {
            public StatusReservasi Status { get; private set; }

            public PembatalanReservasi()
            {
                Status = StatusReservasi.Aktif;
            }

            public void Batalkan()
            {
                if (Status == StatusReservasi.Aktif)
                {
                    Status = StatusReservasi.Dibatalkan;
                }
            }
        }
 }

