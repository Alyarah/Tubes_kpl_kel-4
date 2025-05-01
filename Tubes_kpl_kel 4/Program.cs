using System;
using Tubes_kpl_kel_4.Auth;
using Tubes_kpl_kel_4.Models;

namespace Tubes_kpl_kel_4
{
    class Program
    {
        static void Main(string[] args)
        {
            bool selesai = false;

            while (!selesai)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1. Registrasi");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Selesai");
                Console.Write("Pilih menu: ");
                string pilihan = Console.ReadLine();

                switch (pilihan)
                {
                    case "1":
                        Registrasi<User> registrasi = new Registrasi<User>();

                        Console.Write("Masukkan Nama: ");
                        registrasi.Nama = Console.ReadLine();

                        Console.Write("Masukkan Email: ");
                        registrasi.Email = Console.ReadLine();

                        Console.Write("Masukkan Password (minimal 6 karakter): ");
                        registrasi.Password = Console.ReadLine();

                        string hasilRegistrasi = registrasi.Register();
                        Console.WriteLine(hasilRegistrasi);
                        break;

                    case "2":
                        Login login = new Login();

                        Console.Write("Masukkan Nama: ");
                        string nama = Console.ReadLine();

                        Console.Write("Masukkan Email: ");
                        string email = Console.ReadLine();

                        Console.Write("Masukkan Password (minimal 6 karakter): ");
                        string password = Console.ReadLine();

                        string hasilLogin = login.LoginUser(nama, email, password);
                        Console.WriteLine(hasilLogin);
                        break;

                    case "3":
                        selesai = true;
                        Console.WriteLine("Terima kasih! Program selesai.");
                        break;

                    default:
                        Console.WriteLine("Pilihan tidak valid. Silakan pilih 1, 2, atau 3.");
                        break;
                }
            }
        }
    }
}
