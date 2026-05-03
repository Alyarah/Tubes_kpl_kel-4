using System;
using System.Collections.Generic;
using Tubes_kpl_kel_4.Models;

namespace Tubes_kpl_kel_4.RiwayatReservasi
{
    public class KelasRiwayatReservasi
    {
        private List<DataReservasi> _listReservasi;
        private string _namaUser;

        private Dictionary<StatusReservasiEnum, Action<DataReservasi>> _printActions;

        public KelasRiwayatReservasi(List<DataReservasi> listReservasi, string namaUser)
        {
            _listReservasi = listReservasi;
            _namaUser = namaUser;

            _printActions = new Dictionary<StatusReservasiEnum, Action<DataReservasi>>
            {
                { StatusReservasiEnum.Dibatalkan, PrintDibatalkan },
                { StatusReservasiEnum.Aktif, PrintAktif }
            };
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

                    if (_printActions.TryGetValue(res.Status, out var printAction))
                    {
                        printAction(res);
                    }
                    else
                    {
                        Console.WriteLine("Status reservasi tidak dikenal.");
                    }

                    Console.WriteLine("----------------------------");
                }
            }
            if (!adaData)
            {
                Console.WriteLine("Belum ada riwayat reservasi.");
            }
        }

        private void PrintDibatalkan(DataReservasi res)
        {
            Console.WriteLine($"Tempat: {res.Tempat}, Ruangan: {res.Ruangan}, Kapasitas: {res.Kapasitas}");
            Console.WriteLine($"Tanggal: {res.jReservasi.Tanggal}, Jam: {res.jReservasi.Mulai} - {res.jReservasi.Selesai}");
            Console.WriteLine($"Status: {res.Status}");
            if (!string.IsNullOrWhiteSpace(res.AlasanPembatalan))
                Console.WriteLine($"Alasan Pembatalan: {res.AlasanPembatalan}");
        }

        private void PrintAktif(DataReservasi res)
        {
            Console.WriteLine($"Tempat: {res.Tempat}, Ruangan: {res.Ruangan}, Kapasitas: {res.Kapasitas}");
            Console.WriteLine($"Tanggal: {res.jReservasi.Tanggal}, Jam: {res.jReservasi.Mulai} - {res.jReservasi.Selesai}");
            Console.WriteLine($"Status: {res.Status}");
        }
    }
}
