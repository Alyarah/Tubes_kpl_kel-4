using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using Tubes_kpl_kel_4;
using Tubes_kpl_kel_4.Models;
using Tubes_kpl_kel_4.Reservasi;

namespace Tubes_kpl_kel_4.Tests
{
    [TestClass]
    public class ReservasiTest
    {
        [TestMethod]
        public void TestReservasiBerhasil()
        {
            var user = new User { Nama = "Budi" };
            var jadwalList = new List<Jadwal>
            {
                new Jadwal
                {
                    Tempat = "Gedung A",
                    Ruangan = "101",
                    Hari = "Senin",
                    Mulai = "08:00",
                    Selesai = "10:00"
                }
            };

            var reservasiList = new List<DataReservasi>();
            var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kelas", "ListKelas.json");
            var daftarKelas = new DaftarKelas(configPath);
            var statusReservasi = new StatusReservasi();

            var reservasiRuangan = new ReservasiRuangan(user, jadwalList, reservasiList, daftarKelas, statusReservasi);
            string hasil = reservasiRuangan.LakukanReservasi("Gedung A", "101", 20, "2025-05-19", "10:00", "12:00");

            Assert.IsTrue(hasil.StartsWith("Sukses"), "Reservasi seharusnya berhasil.");
        }

        [TestMethod]
        public void TestReservasiBentrokJadwalTetap()
        {
            var user = new User { Nama = "Budi" };
            var jadwalList = new List<Jadwal>
            {
                new Jadwal
                {
                    Tempat = "Gedung A",
                    Ruangan = "101",
                    Hari = "Senin",
                    Mulai = "08:00",
                    Selesai = "10:00"
                }
            };

            var reservasiList = new List<DataReservasi>();
            var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kelas", "ListKelas.json");
            var daftarKelas = new DaftarKelas(configPath);
            var statusReservasi = new StatusReservasi();

            var reservasiRuangan = new ReservasiRuangan(user, jadwalList, reservasiList, daftarKelas, statusReservasi);
            string hasil = reservasiRuangan.LakukanReservasi("Gedung A", "101", 20, "2025-05-19", "09:00", "11:00");

            Assert.IsTrue(hasil.StartsWith("Gagal: Jadwal tetap"), "Reservasi seharusnya gagal karena bentrok jadwal tetap.");
        }

        [TestMethod]
        public void TestReservasiBentrokDenganReservasiLain()
        {
            var user = new User { Nama = "Budi" };
            var jadwalList = new List<Jadwal>();
            var reservasiList = new List<DataReservasi>
            {
                new DataReservasi
                {
                    Tempat = "Gedung A",
                    Ruangan = "101",
                    Kapasitas = 20,
                    jReservasi = new JadwalReservasi
                    {
                        NamaUser = "Andi",
                        Tanggal = "2025-05-19",
                        Mulai = "10:00",
                        Selesai = "12:00"
                    }
                }
            };

            var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kelas", "ListKelas.json");
            var daftarKelas = new DaftarKelas(configPath);
            var statusReservasi = new StatusReservasi();

            var reservasiRuangan = new ReservasiRuangan(user, jadwalList, reservasiList, daftarKelas, statusReservasi);
            string hasil = reservasiRuangan.LakukanReservasi("Gedung A", "101", 20, "2025-05-19", "11:00", "13:00");

            Assert.IsTrue(hasil.StartsWith("Gagal: Sudah dipesan"), "Reservasi seharusnya gagal karena bentrok dengan reservasi sebelumnya.");
        }
    }
}
