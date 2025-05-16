using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tubes_kpl_kel_4.Auth;
using Tubes_kpl_kel_4.Models;

namespace Tubes_kpl_kel_4.Tests
{
    [TestClass]
    public class LoginTest
    {
        [TestInitialize]
        public void SetUp()
        {
            // Reset data user sebelum setiap test dijalankan
            typeof(UserStorage)
                .GetField("daftarUser", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                .SetValue(null, new List<User>());
        }

        [TestMethod]
        public void LoginUser_InputValid_DataDitemukan_LoginBerhasil()
        {
            var user = new User
            {
                Nama = "Budi",
                Email = "budi@example.com",
                Password = "Password123"
            };
            UserStorage.TambahUser(user);

            var login = new Login();

            string hasil = login.LoginUser(user.Nama, user.Email, user.Password);

            Assert.AreEqual(StatusLogin.Berhasil, login.Status);
            Assert.IsTrue(hasil.Contains("Login berhasil"));
        }

        [TestMethod]
        public void LoginUser_EmailTidakValid_LoginGagalKarenaValidasi()
        {
            var login = new Login();

            string hasil = login.LoginUser("Siti", "email-tidak-valid", "Password123");

            Assert.AreEqual(StatusLogin.Gagal, login.Status);
            Assert.AreEqual("Login gagal. Inputan tidak valid.", hasil);
        }

        [TestMethod]
        public void LoginUser_PasswordTidakValid_LoginGagalKarenaValidasi()
        {
            var login = new Login();

            string hasil = login.LoginUser("Joko", "joko@gmail.com", "123");

            Assert.AreEqual(StatusLogin.Gagal, login.Status);
            Assert.AreEqual("Login gagal. Inputan tidak valid.", hasil);
        }

        [TestMethod]
        public void LoginUser_UserTidakAda_LoginGagal()
        {

            var login = new Login();

            string hasil = login.LoginUser("Noname", "noname@gamil.com", "TidakAda123");

            Assert.AreEqual(StatusLogin.Gagal, login.Status);
            Assert.AreEqual("Login gagal. Data tidak ditemukan atau salah.", hasil);
        }
    }
}
