using System;
using Tubes_kpl_kel_4.Reservasi;
using Tubes_kpl_kel_4.Validators;

namespace Tubes_kpl_kel_4
{
    public enum StatusReservasiEnum
    {
        Aktif,
        Dibatalkan
    }

    public class PembatalanReservasi
    {
        public StatusReservasiEnum Status { get; private set; }
        public string AlasanPembatalan { get; private set; }

        private List<DataReservasi> _listReservasi;

        public PembatalanReservasi(List<DataReservasi> listReservasi)
        {
            _listReservasi = listReservasi;
        }

        public bool Batalkan(string tempat, string ruangan, string tanggal, string jamMulai, string alasan)
        {
            try
            {
                var target = _listReservasi.FirstOrDefault(r =>
                    r.Tempat.Equals(tempat, StringComparison.OrdinalIgnoreCase) &&
                    r.Ruangan.Equals(ruangan, StringComparison.OrdinalIgnoreCase) &&
                    r.jReservasi.Tanggal == tanggal &&
                    r.jReservasi.Mulai == jamMulai &&
                    r.Status == StatusReservasiEnum.Aktif);

                if (target == null)
                    throw new InvalidOperationException("Reservasi tidak ditemukan atau sudah dibatalkan.");

                if (!Validasi.ValidasiAlasan(alasan))
                    throw new ArgumentException("Alasan pembatalan tidak valid.");

                target.Status = StatusReservasiEnum.Dibatalkan;
                target.AlasanPembatalan = alasan;

                Console.WriteLine("Reservasi berhasil dibatalkan.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Pembatalan gagal: {ex.Message}");
                return false;
            }
        }
    }
}

