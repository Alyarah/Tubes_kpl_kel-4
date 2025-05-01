//using System;
//using Tubes_kpl_kel_4;

//class Program
//{
//    static void Main(string[] args)
//    {
//        Console.WriteLine("=== Room4U - Login ===");

//        Console.Write("Masukkan nama: ");
//        string nama = Console.ReadLine();

//        Console.Write("Masukkan email: ");
//        string email = Console.ReadLine();

//        Console.Write("Masukkan password: ");
//        string password = Console.ReadLine();

//        Login login = new Login();
//        string hasilLogin = login.LoginUser(nama, email, password);
//        Console.WriteLine("\n" + hasilLogin);

//        if (login.Status == StatusLogin.Berhasil)
//        {
//            Console.WriteLine("\n=== Menu ===");
//            Console.WriteLine("1. Lihat Daftar Kelas (simulasi)");
//            Console.WriteLine("2. Batalkan Reservasi");
//            Console.WriteLine("3. Keluar");
//            Console.Write("Pilih menu [1-3]: ");
//            string pilihan = Console.ReadLine();

//            switch (pilihan)
//            {
//                case "1":
//                    Console.WriteLine("\nDaftar kelas: R101, R102, R201, R301 (simulasi)");
//                    break;

//                case "2":
//                    JalankanPembatalan();
//                    break;

//                case "3":
//                    Console.WriteLine("Terima kasih telah menggunakan Room4U.");
//                    break;

//                default:
//                    Console.WriteLine("Pilihan tidak valid.");
//                    break;
//            }
//        }
//        else
//        {
//            Console.WriteLine("Silakan coba login lagi.");
//        }

//        Console.WriteLine("\nTekan sembarang tombol untuk keluar...");
//        Console.ReadKey();
//    }

//    static void JalankanPembatalan()
//    {
//        Console.WriteLine("\n=== Pembatalan Reservasi ===");

//        PembatalanReservasi reservasi = new PembatalanReservasi();

//        Console.Write("Yakin ingin membatalkan reservasi? (ya/tidak): ");
//        string konfirmasi = Console.ReadLine()?.ToLower();

//        if (konfirmasi == "ya")
//        {
//            reservasi.Batalkan();
//            Console.WriteLine("Reservasi berhasil dibatalkan.");
//        }
//        else
//        {
//            Console.WriteLine("Reservasi tetap aktif.");
//        }
//    }
//}

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseDeveloperExceptionPage();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
