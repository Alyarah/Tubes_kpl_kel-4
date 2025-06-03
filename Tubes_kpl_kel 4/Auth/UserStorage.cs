using Tubes_kpl_kel_4.Models;
using System.Collections.Generic;
using System.Linq;

namespace Tubes_kpl_kel_4.Auth
{
    public static class UserStorage
    {
        private static List<User> daftarUser = new List<User>();

        // Menambahkan user baru ke dalam daftar
        public static void TambahUser(User user)
        {
            daftarUser.Add(user);
        }

        // Mengecek apakah user dengan nama dan email tertentu sudah terdaftar
        public static bool CekUserSudahAda(string nama, string email)
        {
            return daftarUser.Any(u => u.Nama == nama && u.Email == email);
        }

        // Mencari user berdasarkan nama, email, dan password
        public static bool CariUser(string nama, string email, string password)
        {
            return daftarUser.Any(u => u.Nama == nama && u.Email == email && u.Password == password);
        }
    }
}
