using System;
using System.Collections.Generic;
using Tubes_kpl_kel_4.Reservasi;

namespace Tubes_kpl_kel_4.RiwayatReservasi
{
    public class KelasRiwayatReservasi
    {
        private List<DataReservasi> _listReservasi;
        private string _namaUser;

        public KelasRiwayatReservasi(List<DataReservasi> listReservasi, string namaUser)
        {
            _listReservasi = listReservasi;
            _namaUser = namaUser;
        }

        public void PrintRiwayat()
        {
            Console.WriteLine($"\n=== Riwayat Reservasi untuk {_namaUser} ===");
            bool adaData = false;
            foreach (var res in _listReservasi)
            {
                if (res.jReservasi.NamaUser.Equals(_namaUser, StringComparison.OrdinalIgnoreCase))
                {
                    adaData = true;
                    Console.WriteLine($"Tempat: {res.Tempat}, Ruangan: {res.Ruangan}, Kapasitas: {res.Kapasitas}");
                    Console.WriteLine($"Tanggal: {res.jReservasi.Tanggal}, Jam: {res.jReservasi.Mulai} - {res.jReservasi.Selesai}");
                    Console.WriteLine($"Status: {res.Status}");
                    if (res.Status == StatusReservasiEnum.Dibatalkan && !string.IsNullOrWhiteSpace(res.AlasanPembatalan))
                        Console.WriteLine($"Alasan Pembatalan: {res.AlasanPembatalan}");
                    Console.WriteLine("----------------------------");
                }
            }
            if (!adaData)
            {
                Console.WriteLine("Belum ada riwayat reservasi.");
            }
        }
    }
}
