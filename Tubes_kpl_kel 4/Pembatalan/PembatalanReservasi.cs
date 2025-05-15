using System;
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
        public string KodeKelas { get; }
        public string AlasanPembatalan { get; private set; }

        public PembatalanReservasi(string kodeKelas)
        {
            if (string.IsNullOrWhiteSpace(kodeKelas))
                throw new ArgumentException("Kode kelas tidak boleh kosong.");

            KodeKelas = kodeKelas;
            Status = StatusReservasiEnum.Aktif;
        }

        public bool Batalkan(string alasan)
        {
            try
            {
                if (Status != StatusReservasiEnum.Aktif)
                    throw new InvalidOperationException("Reservasi tidak dalam status aktif.");

                if (!Validasi.ValidasiPembatalan(KodeKelas, alasan))
                    throw new ArgumentException("Alasan pembatalan tidak valid.");

                Status = StatusReservasiEnum.Dibatalkan;
                AlasanPembatalan = alasan;

                if (Status != StatusReservasiEnum.Dibatalkan || AlasanPembatalan != alasan)
                    throw new InvalidOperationException("Postcondition gagal: status atau alasan tidak sesuai.");

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
