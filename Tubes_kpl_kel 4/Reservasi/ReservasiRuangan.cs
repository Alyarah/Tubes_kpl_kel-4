using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
using Tubes_kpl_kel_4;
using Tubes_kpl_kel_4.Models;
using Tubes_kpl_kel_4.Reservasi;
using Tubes_kpl_kel_4.RiwayatReservasi;

public class ReservasiRuangan
{
    private User _user;
    private List<Jadwal> _jadwalList;
    private List<DataReservasi> _reservasiList;
    private DaftarKelas _daftarKelas;
    private StatusReservasi _statusReservasi;
    private StatusReservasiHandler _statusHandler;

    public ReservasiRuangan(User user, List<Jadwal> jadwalList, List<DataReservasi> reservasiList, DaftarKelas daftarKelas, StatusReservasiHandler statusHandler, StatusReservasi statusReservasi)
    {
        _user = user;
        _jadwalList = jadwalList;
        _reservasiList = reservasiList;
        _daftarKelas = daftarKelas;
        _statusHandler = statusHandler;
        _statusReservasi = statusReservasi;
    }

    public string LakukanReservasi(string tempat, string ruangan, int kapasitas, string tanggal, string jamMulai, string jamSelesai)
    {
        DateTime tanggalReservasi = DateTime.Parse(tanggal);
        string hariDariTanggal = tanggalReservasi.ToString("dddd", new CultureInfo("id-ID"));

        foreach (var jadwal in _jadwalList)
        {
            if (jadwal.Tempat == tempat && jadwal.Ruangan == ruangan && jadwal.Hari.Equals(hariDariTanggal, StringComparison.OrdinalIgnoreCase))
            {
                if (jamMulai.CompareTo(jadwal.Selesai) < 0 && jamSelesai.CompareTo(jadwal.Mulai) > 0)
                {
                    return $"Gagal: Jadwal tetap di {tempat} {ruangan} bentrok dengan waktu {jadwal.Mulai}-{jadwal.Selesai}.";
                }
            }
        }

        foreach (var reservasi in _reservasiList)
        {
            if (reservasi.Tempat == tempat && reservasi.Ruangan == ruangan && reservasi.jReservasi.Tanggal == tanggal)
            {
                if (jamMulai.CompareTo(reservasi.jReservasi.Selesai) < 0 && jamSelesai.CompareTo(reservasi.jReservasi.Mulai) > 0)
                {
                    return $"Gagal: Sudah dipesan oleh {reservasi.jReservasi.NamaUser} dari {reservasi.jReservasi.Mulai} sampai {reservasi.jReservasi.Selesai}.";
                }
            }
        }

        var jadwalReservasiBaru = new JadwalReservasi
        {
            NamaUser = _user.Nama,
            Tanggal = tanggal,
            Mulai = jamMulai,
            Selesai = jamSelesai
        };

        var dataBaru = new DataReservasi
        {
            Tempat = tempat,
            Ruangan = ruangan,
            Kapasitas = kapasitas,
            jReservasi = jadwalReservasiBaru
        };

        _reservasiList.Add(dataBaru);
        _statusHandler.TambahReservasi(dataBaru);

        return $"Sukses: Reservasi oleh {_user.Nama} untuk {tempat} {ruangan} pada {tanggal} {jamMulai}-{jamSelesai} berhasil.";
    }

    private void SimpanRiwayat()
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(new { Reservasi = _reservasiList }, options); // ✅ serialize dari list internal
            File.WriteAllText(StatusReservasiHandler.filePath, jsonString); // ✅ ganti class enum ke handler
        }
        catch (Exception ex)
        {
            Console.WriteLine("Gagal menyimpan riwayat: " + ex.Message);
        }
    }
}
