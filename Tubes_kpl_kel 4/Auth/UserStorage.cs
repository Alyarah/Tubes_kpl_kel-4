using Tubes_kpl_kel_4.Models;
using System.Collections.Generic;
using System.Linq;

namespace Tubes_kpl_kel_4.Auth
{
    public static class UserStorage
    {
        private static List<User> daftarUser = new List<User>();

        // Tambahkan user baru
        public static void TambahUser(User user)
        {
            daftarUser.Add(user);
        }

        // Cek apakah user sudah ada berdasarkan email saja
        public static bool CekUserSudahAda(string email)
        {
            return daftarUser.Any(u => u.Email == email);
        }

        // Cek login berdasarkan email dan password (sudah di-hash)
        public static bool CariUserDenganHash(string email, string hashedPassword)
        {
            return daftarUser.Any(u => u.Email == email && u.Password == hashedPassword);
        }

        // (Opsional) Ambil data user berdasarkan email
        public static User AmbilUserByEmail(string email)
        {
            return daftarUser.FirstOrDefault(u => u.Email == email);
        }
    }
}
