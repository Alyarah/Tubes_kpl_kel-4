using System;
using System.Collections.Generic;
using Tubes_kpl_kel_4.Models;
using Tubes_kpl_kel_4.Reservasi;

namespace Tubes_kpl_kel_4
{
    public class ReservasiRuangan
    {
        private User _user;
        private List<Jadwal> _jadwalList;
        private List<DataReservasi> _reservasiList;
        private DaftarKelas _daftarKelas;

        public ReservasiRuangan(User user, List<Jadwal> jadwalList, List<DataReservasi> reservasiList, DaftarKelas daftarKelas)
        {
            _user = user;
            _jadwalList = jadwalList;
            _reservasiList = reservasiList;
            _daftarKelas = daftarKelas;
        }

        public string LakukanReservasi(string namaTempat, string namaRuangan, int kapasitas, string tanggal, string jamMulai, string jamSelesai)
        {
            DateTime tanggalReservasi = DateTime.Parse(tanggal);
            string hariDariTanggal = tanggalReservasi.ToString("dddd", new System.Globalization.CultureInfo("id-ID"));

            // Cek bentrok dengan jadwal tetap
            foreach (var jadwal in _jadwalList)
            {
                if (jadwal.NamaTempat == namaTempat &&
                    jadwal.NamaRuangan == namaRuangan &&
                    jadwal.Hari.Equals(hariDariTanggal, StringComparison.OrdinalIgnoreCase))
                {
                    if (jamMulai.CompareTo(jadwal.JamSelesai) < 0 && jamSelesai.CompareTo(jadwal.JamMulai) > 0)
                    {
                        return $"Gagal: Jadwal tetap di {namaTempat} {namaRuangan} bentrok dengan waktu {jadwal.JamMulai}-{jadwal.JamSelesai}.";
                    }
                }
            }

            // Cek bentrok dengan reservasi lain
            foreach (var reservasi in _reservasiList)
            {
                if (reservasi.NamaTempat == namaTempat &&
                    reservasi.NamaRuangan == namaRuangan &&
                    reservasi.JadwalDetail.Tanggal == tanggal)
                {
                    if (jamMulai.CompareTo(reservasi.JadwalDetail.JamSelesai) < 0 &&
                        jamSelesai.CompareTo(reservasi.JadwalDetail.JamMulai) > 0)
                    {
                        return $"Gagal: Sudah dipesan oleh {reservasi.JadwalDetail.NamaUser} dari {reservasi.JadwalDetail.JamMulai} sampai {reservasi.JadwalDetail.JamSelesai}.";
                    }
                }
            }

            // Buat reservasi baru
            JadwalReservasi jadwalReservasiBaru = new JadwalReservasi
            {
                NamaUser = _user.Nama,
                Tanggal = tanggal,
                JamMulai = jamMulai,
                JamSelesai = jamSelesai
            };

            DataReservasi dataBaru = new DataReservasi
            {
                NamaTempat = namaTempat,
                NamaRuangan = namaRuangan,
                KapasitasRuangan = kapasitas,
                JadwalDetail = jadwalReservasiBaru
            };

            _reservasiList.Add(dataBaru);

            return $"Sukses: Reservasi oleh {_user.Nama} untuk {namaTempat} {namaRuangan} pada {tanggal} {jamMulai}-{jamSelesai} berhasil.";
        }
    }
}
