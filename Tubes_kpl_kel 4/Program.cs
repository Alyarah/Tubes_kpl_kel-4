using System;
using Tubes_kpl_kel_4.Auth;
using Tubes_kpl_kel_4.Models;
using Tubes_kpl_kel_4.Reservasi;
using Tubes_kpl_kel_4.RiwayatReservasi;
using Tubes_kpl_kel_4.Feedback;

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
                            var currentUser = new User { Nama = nama, Email = email };
                            var daftarKelas = new DaftarKelas("data.json");
                            var listJadwal = daftarKelas.ListKelas;
                            var listReservasi = new List<DataReservasi>();

                            var reservasiRuangan = new ReservasiRuangan(currentUser, listJadwal, listReservasi, daftarKelas);

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
                                        daftarKelas.PrintDaftarKelas();
                                        break;

                                    case "2":
                                        Console.WriteLine("Masukkan tempat: ");
                                        string tempat = Console.ReadLine();

                                        Console.WriteLine("Masukkan ruangan: ");
                                        string ruangan = Console.ReadLine();

                                        Console.WriteLine("Masukkan kapasitas: ");
                                        int kapasitas = int.Parse(Console.ReadLine());

                                        Console.WriteLine("Masukkan tanggal (yyyy-MM-dd): ");
                                        string tanggal = Console.ReadLine();

                                        Console.WriteLine("Masukkan jam mulai (HH:mm): ");
                                        string jamMulai = Console.ReadLine();

                                        Console.WriteLine("Masukkan jam selesai (HH:mm): ");
                                        string jamSelesai = Console.ReadLine();

                                        // Panggil fungsi LakukanReservasi untuk mencoba melakukan reservasi
                                        string hasilReservasi = reservasiRuangan.LakukanReservasi(
                                            tempat, ruangan, kapasitas, tanggal, jamMulai, jamSelesai);
                                        Console.WriteLine(hasilReservasi);
                                        break;

                                    case "3":
                                        Console.WriteLine("Masukkan tempat:");
                                        string tempatBatal = Console.ReadLine();

                                        Console.WriteLine("Masukkan ruangan:");
                                        string ruanganBatal = Console.ReadLine();

                                        Console.WriteLine("Masukkan tanggal (yyyy-MM-dd):");
                                        string tanggalBatal = Console.ReadLine();

                                        Console.WriteLine("Masukkan jam mulai (HH:mm):");
                                        string jamMulaiBatal = Console.ReadLine();

                                        Console.WriteLine("Masukkan alasan pembatalan:");
                                        string alasan = Console.ReadLine();

                                        var pembatal = new PembatalanReservasi(listReservasi);
                                        bool berhasilBatal = pembatal.Batalkan(tempatBatal, ruanganBatal, tanggalBatal, jamMulaiBatal, alasan);
                                        break;

                                    case "4":
                                        var statusReservasi = new StatusReservasi();
                                        statusReservasi.PrintStatusReservasi();
                                        break;

                                    case "5":
                                        var riwayat = new KelasRiwayatReservasi(listReservasi, currentUser.Nama);
                                        riwayat.PrintRiwayat();
                                        break;


                                    case "6":
                                        var feedbackManager = new FeedbackManager();

                                        Console.WriteLine("Masukkan feedback Anda:");
                                        string feedback = Console.ReadLine();

                                        feedbackManager.TambahFeedback(feedback);
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