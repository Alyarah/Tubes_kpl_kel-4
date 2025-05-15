using Tubes_kpl_kel_4.Models;

namespace Tubes_kpl_kel_4.Auth
{
    public static class UserStorage
    {
        private static List<User> daftarUser = new List<User>();

        public static void TambahUser(User user)
        {
            daftarUser.Add(user);
        }

        public static bool CekUserSudahAda(string nama, string email)
        {
            return daftarUser.Any(u => u.Nama == nama && u.Email == email);
        }

        public static bool CariUser(string nama, string email, string password)
        {
            return daftarUser.Any(u => u.Nama == nama && u.Email == email && u.Password == password);
        }
    }
}