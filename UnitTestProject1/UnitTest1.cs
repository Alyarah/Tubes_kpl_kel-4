//using System;
//using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace UnitTestProject1
//{
//    [TestClass]
//    public class LoginTests
//    {
//        [TestInitialize]
//        public void SetUp()
//        {
//            // Reset data user sebelum setiap test dijalankan
//            typeof(UserStorage)
//                .GetField("daftarUser", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
//                .SetValue(null, new List<User>());
//        }

//        [TestMethod]
//        public void LoginUser_InputValid_DataDitemukan_LoginBerhasil()
//        {
//            // Arrange
//            var user = new User
//            {
//                Nama = "Budi",
//                Email = "budi@example.com",
//                Password = "Password123"
//            };
//            UserStorage.TambahUser(user);

//            var login = new Login();

//            // Act
//            string hasil = login.LoginUser(user.Nama, user.Email, user.Password);

//            // Assert
//            Assert.AreEqual(StatusLogin.Berhasil, login.Status);
//            Assert.IsTrue(hasil.Contains("Login berhasil"));
//        }

//        [TestMethod]
//        public void LoginUser_EmailTidakValid_LoginGagalKarenaValidasi()
//        {
//            // Arrange
//            var user = new User
//            {
//                Nama = "Siti",
//                Email = "email-tidak-valid",
//                Password = "Password123"
//            };
//            UserStorage.TambahUser(user);

//            var login = new Login();

//            // Act
//            string hasil = login.LoginUser(user.Nama, user.Email, user.Password);

//            // Assert
//            Assert.AreEqual(StatusLogin.Gagal, login.Status);
//            Assert.AreEqual("Login gagal. Inputan tidak valid.", hasil);
//        }

//        [TestMethod]
//        public void LoginUser_PasswordSalah_LoginGagal()
//        {
//            // Arrange
//            var user = new User
//            {
//                Nama = "Andi",
//                Email = "andi@example.com",
//                Password = "Benar123"
//            };
//            UserStorage.TambahUser(user);

//            var login = new Login();

//            // Act
//            string hasil = login.LoginUser(user.Nama, user.Email, "Salah456");

//            // Assert
//            Assert.AreEqual(StatusLogin.Gagal, login.Status);
//            Assert.AreEqual("Login gagal. Data tidak ditemukan atau salah.", hasil);
//        }

//        [TestMethod]
//        public void LoginUser_UserTidakAda_LoginGagal()
//        {
//            // Arrange
//            var login = new Login();

//            // Act
//            string hasil = login.LoginUser("Noname", "noname@example.com", "TidakAda123");

//            // Assert
//            Assert.AreEqual(StatusLogin.Gagal, login.Status);
//            Assert.AreEqual("Login gagal. Data tidak ditemukan atau salah.", hasil);
//        }
//    }
//}
