using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Tubes_kpl_kel_4.Models;

namespace Tubes_kpl_kel_4
{
    // Enum untuk status reservasi
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusReservasiEnum
    {
        Aktif,
        Dibatalkan
    }

    // Kelas untuk menangani proses pembatalan reservasi
    public class PembatalanReservasi
    {
        public StatusReservasiEnum Status { get; private set; } // status saat ini
        public string AlasanPembatalan { get; private set; }     // alasan pembatalan

        private List<DataReservasi> _listReservasi; // daftar seluruh reservasi

        // Aksi yang dilakukan berdasarkan status reservasi
        private Dictionary<StatusReservasiEnum, Action<DataReservasi>> _statusActions;

        // Konstruktor: inisialisasi data dan aksi status
        public PembatalanReservasi(List<DataReservasi> listReservasi)
        {
            _listReservasi = listReservasi;

            // Dictionary berisi aksi sesuai status
            _statusActions = new Dictionary<StatusReservasiEnum, Action<DataReservasi>>
            {
                { StatusReservasiEnum.Aktif, res => Console.WriteLine($"Reservasi aktif: {res.Tempat} - {res.Ruangan} oleh {res.jReservasi.NamaUser}") },
                { StatusReservasiEnum.Dibatalkan, res => Console.WriteLine($"Reservasi dibatalkan: {res.Tempat} - {res.Ruangan}, Alasan: {res.AlasanPembatalan}") }
            };
        }

        // Method untuk membatalkan reservasi berdasarkan parameter yang diberikan
        public bool Batalkan(string tempat, string ruangan, string tanggal, string jamMulai, string alasan)
        {
            try
            {
                // Cari reservasi yang cocok dan statusnya masih aktif
                var target = _listReservasi.FirstOrDefault(r =>
                    r.Tempat.Equals(tempat, StringComparison.OrdinalIgnoreCase) &&
                    r.Ruangan.Equals(ruangan, StringComparison.OrdinalIgnoreCase) &&
                    r.jReservasi.Tanggal == tanggal &&
                    r.jReservasi.Mulai == jamMulai &&
                    r.Status == StatusReservasiEnum.Aktif);

                // Jika tidak ditemukan, lempar error
                if (target == null)
                    throw new InvalidOperationException("Reservasi tidak ditemukan atau sudah dibatalkan.");

                // Validasi alasan pembatalan
                if (!Validators.Validasi.ValidasiAlasan(alasan))
                    throw new ArgumentException("Alasan pembatalan tidak valid.");

                // Update status dan simpan alasan
                target.Status = StatusReservasiEnum.Dibatalkan;
                target.AlasanPembatalan = alasan;

                Console.WriteLine("Reservasi berhasil dibatalkan.");

                // Jalankan aksi sesuai status baru
                JalankanAksiStatus(target);

                return true;
            }
            catch (Exception ex)
            {
                // Tampilkan error jika gagal
                Console.WriteLine($"Pembatalan gagal: {ex.Message}");
                return false;
            }
        }

        // Method untuk menjalankan aksi berdasarkan status reservasi
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
