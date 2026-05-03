using Tubes_kpl_kel_4.Models;
using Tubes_kpl_kel_4;

namespace Tubes_kpl_kel_4.Tests
{

    [TestClass]
    public class PembatalanTest
    {
        [TestClass]
        public class PembatalanReservasiTest
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
            }
        };
            }

            [TestMethod]
            public void TestPembatalanBerhasil()
            {
                var pembatalan = new PembatalanReservasi(reservasiList);

                bool result = pembatalan.Batalkan("Gedung A", "101", "2025-05-19", "08:00", "Tidak bisa hadir");

                Assert.IsTrue(result, "Pembatalan harus berhasil");
                Assert.AreEqual(StatusReservasiEnum.Dibatalkan, reservasiList[0].Status);
                Assert.AreEqual("Tidak bisa hadir", reservasiList[0].AlasanPembatalan);
            }

            [TestMethod]
            public void TestPembatalanGagalReservasiTidakDitemukan()
            {
                var pembatalan = new PembatalanReservasi(reservasiList);

                bool result = pembatalan.Batalkan("Gedung B", "102", "2025-05-19", "08:00", "Alasan apapun");

                Assert.IsFalse(result, "Pembatalan harus gagal karena reservasi tidak ditemukan");
            }

            [TestMethod]
            public void TestPembatalanGagalAlasanTidakValid()
            {
                var pembatalan = new PembatalanReservasi(reservasiList);

                bool result = pembatalan.Batalkan("Gedung A", "101", "2025-05-19", "08:00", "");

                Assert.IsFalse(result, "Pembatalan harus gagal karena alasan tidak valid");
            }
        }
    }
}
