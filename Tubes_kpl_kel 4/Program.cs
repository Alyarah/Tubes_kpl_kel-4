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

                        if (login.Status == StatusLogin.Berhasil)
                        {
                            bool logout = false;
                            while (!logout)
                            {
                                Console.WriteLine("\n=== MENU UTAMA ===");
                                Console.WriteLine("1. Lihat Daftar Kelas");
                                Console.WriteLine("2. Reservasi Kelas");
                                Console.WriteLine("3. Batalkan Reservasi");
                                Console.WriteLine("4. Status Reservasi");
                                Console.WriteLine("5. Riwayat");
                                Console.WriteLine("6. Feedback");
                                Console.WriteLine("7. Logout");
                                Console.Write("Pilih menu: ");
                                string menuLogin = Console.ReadLine();

                                switch (menuLogin)
                                {
                                    case "1":
                                        var kelas = new DaftarKelas("data.json");
                                        kelas.PrintDaftarKelas();
                                        break;

                                    case "2":
                                        Console.WriteLine("[Reservasi Kelas] Fitur belum diimplementasikan.");
                                        // Panggil fungsi atau kelas untuk melakukan reservasi
                                        break;

                                    case "3":
                                        Console.WriteLine("[Batalkan Reservasi] Fitur belum diimplementasikan.");
                                        // Panggil fungsi untuk membatalkan reservasi
                                        break;

                                    case "4":
                                        Console.WriteLine("[Status Reservasi] Fitur belum diimplementasikan.");
                                        // Panggil fungsi untuk melihat status reservasi
                                        break;

                                    case "5":
                                        Console.WriteLine("[Riwayat] Fitur belum diimplementasikan.");
                                        // Panggil fungsi untuk melihat riwayat
                                        break;

                                    case "6":
                                        Console.WriteLine("[Feedback] Fitur belum diimplementasikan.");
                                        // Panggil fungsi untuk memberikan feedback
                                        break;

                                    case "7":
                                        logout = true;
                                        Console.WriteLine("Logout berhasil. Kembali ke menu utama.");
                                        break;

                                    default:
                                        Console.WriteLine("Pilihan tidak valid. Silakan pilih angka 1-7.");
                                        break;
                                }
                            }
                        }

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
