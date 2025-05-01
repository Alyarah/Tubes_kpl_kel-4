using System;
using System.Collections.Generic;
using Tubes_kpl_kel_4;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Hasil Registrasi ---");

        // Registrasi Mahasiswa
        var formMahasiswa = new RegistrasiForm<Mahasiswa>
        {
            UserData = new Mahasiswa { NIM = "103022300099", Prodi = "Rekayasa Perangkat Lunak" }
        };
        Console.WriteLine(formMahasiswa.Register());

        // Registrasi Dosen
        var formDosen = new RegistrasiForm<Dosen>
        {
            UserData = new Dosen { NIP = "9876543210", Fakultas = "Informatika" }
        };
        Console.WriteLine(formDosen.Register());

        // Registrasi Staf
        var formStaf = new RegistrasiForm<Staf>
        {
            UserData = new Staf { Divisi = "Keuangan", Jabatan = "Bendahara" }
        };
        Console.WriteLine(formStaf.Register());

        Console.WriteLine("\n--- Hasil Reservasi Ruangan ---");

        // Reservasi Rapat
        var reservasiRapat = new ReservasiRuangan<Rapat>
        {
            NamaRuangan = "Auditorium GKU Lt. 2",
            Waktu = DateTime.Now.AddHours(3),
            Kegiatan = new Rapat
            {
                Topik = "Pembahasan Fitur Aplikasi Mobile",
                Peserta = new List<string> { "Tim Mobile Dev", "Project Manager" }
            }
        };
        Console.WriteLine(reservasiRapat.Reservasi());

        // Reservasi Kelas
        var reservasiKelas = new ReservasiRuangan<Kelas>
        {
            NamaRuangan = "TULT 0702",
            Waktu = new DateTime(2025, 5, 5, 10, 0, 0),
            Kegiatan = new Kelas
            {
                MataKuliah = "Konstruksi Perangkat Lunak",
                DosenPengajar = "Dr. Raisa Anggraini, S.T., M.Kom"
            }
        };
        Console.WriteLine(reservasiKelas.Reservasi());
        Console.ReadLine();
    }
}

