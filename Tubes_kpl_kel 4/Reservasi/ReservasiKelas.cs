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
    private Tubes_kpl_kel_4.Reservasi.StatusReservasi _statusReservasi;
    private StatusHandler _statusHandler;

    public ReservasiRuangan(User user, List<Jadwal> jadwalList, List<DataReservasi> reservasiList, DaftarKelas daftarKelas, StatusHandler statusHandler, StatusReservasi statusReservasi)
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
        string hariDariTanggal = tanggalReservasi.ToString("dddd", new System.Globalization.CultureInfo("id-ID"));

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
        _statusReservasi.TambahReservasi(dataBaru);
        _statusHandler.TampilkanStatus(dataBaru, "Berhasil");
        return $"Sukses: Reservasi oleh {_user.Nama} untuk {tempat} {ruangan} pada {tanggal} {jamMulai}-{jamSelesai} berhasil.";
        SimpanRiwayat();

    }

    private void SimpanRiwayat()
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(new { Reservasi = _statusReservasi.DaftarReservasi }, options);
            File.WriteAllText(StatusReservasi.filePath, jsonString);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Gagal menyimpan riwayat: " + ex.Message);
        }
    }


}