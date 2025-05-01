using Tubes_kpl_kel_4.Validators;

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
        public string KodeKelas { get; }
        public string AlasanPembatalan { get; private set; }

        public PembatalanReservasi(string kodeKelas)
        {
            KodeKelas = kodeKelas;
            Status = StatusReservasi.Aktif;
        }

        public bool Batalkan(string alasan)
        {
            if (Status == StatusReservasi.Aktif &&
                Validasi.ValidasiPembatalan(KodeKelas, alasan))
            {
                Status = StatusReservasi.Dibatalkan;
                AlasanPembatalan = alasan;
                Console.WriteLine("Reservasi berhasil dibatalkan.");
                return true;
            }
            Console.WriteLine("Pembatalan gagal. Data tidak valid atau status bukan Aktif.");
            return false;
        }
    }
}