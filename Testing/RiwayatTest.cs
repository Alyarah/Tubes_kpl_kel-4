using Tubes_kpl_kel_4.Models;
using Tubes_kpl_kel_4.RiwayatReservasi;
using Tubes_kpl_kel_4;

namespace Tubes_kpl_kel_4.Tests
{

    [TestClass]
    public class RiwayatTest
    {
        private List<DataReservasi> reservasiList;

        [TestInitialize]
        public void Setup()
        {
            reservasiList = new List<DataReservasi>
        {
            new DataReservasi
            {
                Tempat = "Gedung A",
                Ruangan = "101",
                Kapasitas = 20,
                Status = StatusReservasiEnum.Aktif,
                jReservasi = new JadwalReservasi
                {
                    NamaUser = "Budi",
                    Tanggal = "2025-05-19",
                    Mulai = "08:00",
                    Selesai = "10:00"
                }
            },
            new DataReservasi
            {
                Tempat = "Gedung B",
                Ruangan = "102",
                Kapasitas = 15,
                Status = StatusReservasiEnum.Dibatalkan,
                AlasanPembatalan = "Sakit",
                jReservasi = new JadwalReservasi
                {
                    NamaUser = "Budi",
                    Tanggal = "2025-05-20",
                    Mulai = "10:00",
                    Selesai = "12:00"
                }
            },
            new DataReservasi
            {
                Tempat = "Gedung C",
                Ruangan = "103",
                Kapasitas = 30,
                Status = StatusReservasiEnum.Aktif,
                jReservasi = new JadwalReservasi
                {
                    NamaUser = "Andi",
                    Tanggal = "2025-05-21",
                    Mulai = "14:00",
                    Selesai = "16:00"
                }
            }
        };
        }

        [TestMethod]
        public void TestPrintRiwayatAdaData()
        {
            // Arrange
            var riwayat = new KelasRiwayatReservasi(reservasiList, "Budi");
            var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            riwayat.PrintRiwayat();
            var output = sw.ToString();

            // Assert
            Assert.IsTrue(output.Contains("=== Riwayat Reservasi untuk Budi ==="));
            Assert.IsTrue(output.Contains("Tempat: Gedung A, Ruangan: 101, Kapasitas: 20"));
            Assert.IsTrue(output.Contains("Tanggal: 2025-05-19, Jam: 08:00 - 10:00"));
            Assert.IsTrue(output.Contains("Status: Aktif"));

            Assert.IsTrue(output.Contains("Tempat: Gedung B, Ruangan: 102, Kapasitas: 15"));
            Assert.IsTrue(output.Contains("Tanggal: 2025-05-20, Jam: 10:00 - 12:00"));
            Assert.IsTrue(output.Contains("Status: Dibatalkan"));
            Assert.IsTrue(output.Contains("Alasan Pembatalan: Sakit"));
        }

    }
}