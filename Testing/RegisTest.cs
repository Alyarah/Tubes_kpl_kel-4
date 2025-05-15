using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tubes_kpl_kel_4.Auth;
using Tubes_kpl_kel_4.Models;

namespace Tubes_kpl_kel_4.Tests
{
    [TestClass]
    public class RegistrasiTest
    {
        [TestInitialize]
        public void SetUp()
        {
            typeof(UserStorage)
                .GetField("daftarUser", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                .SetValue(null, new List<User>());
        }

        [TestMethod]
        public void Register_InputValid_UserBelumAda_RegistrasiBerhasil()
        {
            var registrasi = new Registrasi<User>
            {
                Nama = "Agus",
                Email = "agus@example.com",
                Password = "Agus12345"
            };

            string hasil = registrasi.Register();

            Assert.AreEqual("Registrasi berhasil untuk: Agus", hasil);
        }

        [TestMethod]
        public void Register_InputTidakValid_RegistrasiGagal()
        {
            var registrasi = new Registrasi<User>
            {
                Nama = "", // Nama tidak valid
                Email = "email-salah", // Email tidak valid
                Password = "123" // Password tidak valid
            };

            string hasil = registrasi.Register();

            Assert.AreEqual("Registrasi gagal. Inputan tidak valid.", hasil);
        }

        [TestMethod]
        public void Register_UserSudahAda_RegistrasiGagal()
        {
            var user = new User
            {
                Nama = "Dina",
                Email = "dina@example.com",
                Password = "DinaPass123"
            };
            UserStorage.TambahUser(user); // Simulasi user sudah ada

            var registrasi = new Registrasi<User>
            {
                Nama = "Dina",
                Email = "dina@example.com",
                Password = "DinaPass123"
            };

            string hasil = registrasi.Register();

            Assert.AreEqual("Registrasi gagal. User dengan nama dan email ini sudah terdaftar.", hasil);
        }
    }
}
