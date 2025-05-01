using System;
using Tubes_kpl_kel_4;

class Program
{
    static void Main()
    {
        Login login = new Login();

        Console.Write("Nama: ");
        string nama = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Password: ");
        string password = Console.ReadLine();

        string hasil = login.LoginUser(nama, email, password);
        Console.WriteLine(hasil);
    }
}
