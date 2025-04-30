using System;
using System.Collections.Generic;
using Tubes_kpl_kel_4;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Hasil Registrasi ---");

        // Registrasi Mahasiswa
        var formMahasiswa = new RegistrationForm<Mahasiswa>
        {
            UserData = new Mahasiswa { NIM = "1302223111", Prodi = "Rekayasa Perangkat Lunak" }
        };
        Console.WriteLine(formMahasiswa.Register());

        // Registrasi Dosen
        var formDosen = new RegistrationForm<Dosen>
        {
            UserData = new Dosen { NIP = "9876543210", Fakultas = "Ilmu Terapan" }
        };
        Console.WriteLine(formDosen.Register());

        // Registrasi Staf
        var formStaf = new RegistrationForm<Staf>
        {
            UserData = new Staf { Divisi = "Keuangan", Jabatan = "Bendahara" }
        };
        Console.WriteLine(formStaf.Register());

        Console.WriteLine("\n--- Hasil Reservasi Ruangan ---");

        // Reservasi Rapat
        var reservasiRapat = new ReservasiRuangan<Rapat>
        {
            NamaRuangan = "Ruang Diskusi Lt. 5",
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
            NamaRuangan = "Auditorium Gd. A",
            Waktu = new DateTime(2025, 5, 5, 10, 0, 0),
            Kegiatan = new Kelas
            {
                MataKuliah = "Basis Data Lanjut",
                DosenPengajar = "Ibu Dr. Aisyah"
            }
        };
        Console.WriteLine(reservasiKelas.Reservasi());

        Console.WriteLine("\nTekan tombol Enter untuk keluar...");
        Console.ReadLine();
    }
}
