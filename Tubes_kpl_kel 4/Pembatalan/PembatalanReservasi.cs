using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Tubes_kpl_kel_4.Models;

namespace Tubes_kpl_kel_4
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
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

        private Dictionary<StatusReservasiEnum, Action<DataReservasi>> _statusActions;

        public PembatalanReservasi(List<DataReservasi> listReservasi)
        {
            _listReservasi = listReservasi;

            _statusActions = new Dictionary<StatusReservasiEnum, Action<DataReservasi>>
            {
                { StatusReservasiEnum.Aktif, res => Console.WriteLine($"Reservasi aktif: {res.Tempat} - {res.Ruangan} oleh {res.jReservasi.NamaUser}") },
                { StatusReservasiEnum.Dibatalkan, res => Console.WriteLine($"Reservasi dibatalkan: {res.Tempat} - {res.Ruangan}, Alasan: {res.AlasanPembatalan}") }
            };
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

                if (!Validators.Validasi.ValidasiAlasan(alasan))
                    throw new ArgumentException("Alasan pembatalan tidak valid.");

                target.Status = StatusReservasiEnum.Dibatalkan;
                target.AlasanPembatalan = alasan;

                Console.WriteLine("Reservasi berhasil dibatalkan.");

                // Jalankan aksi berdasarkan status baru
                JalankanAksiStatus(target);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Pembatalan gagal: {ex.Message}");
                return false;
            }
        }
        private void JalankanAksiStatus(DataReservasi reservasi)
        {
            if (_statusActions.TryGetValue(reservasi.Status, out var action))
            {
                action(reservasi);
            }
            else
            {
                Console.WriteLine("Status reservasi tidak dikenali.");
            }
        }
    }
}
