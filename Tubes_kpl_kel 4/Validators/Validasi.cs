using System;
using System.Diagnostics.Contracts;
using Tubes_kpl_kel_4.Auth;
using Tubes_kpl_kel_4.Models;

namespace Tubes_kpl_kel_4.Validators
{
    public class Validasi
    {
        public static bool ValidasiNama(string nama)
        {
            Contract.Requires(nama != null, "Nama tidak boleh null");
            Contract.Ensures(Contract.Result<bool>() == (!string.IsNullOrWhiteSpace(nama) && nama.Length >= 3));

            return !string.IsNullOrWhiteSpace(nama) && nama.Length >= 3;
        }

        public static bool ValidasiEmail(string email)
        {
            Contract.Requires(email != null, "Email tidak boleh null");
            Contract.Ensures(Contract.Result<bool>() == (email.Contains("@") &&
                                                         (email.EndsWith(".com") || email.EndsWith(".ac.id"))));

            return email.Contains("@") && (email.EndsWith(".com") || email.EndsWith(".ac.id"));
        }

        public static bool ValidasiPassword(string password)
        {
            Contract.Requires(password != null, "Password tidak boleh null");
            Contract.Ensures(Contract.Result<bool>() == (!string.IsNullOrWhiteSpace(password) && password.Length >= 6));

            return !string.IsNullOrWhiteSpace(password) && password.Length >= 6;
        }

        public static bool ValidasiPembatalan(string kodeKelas, string alasan)
        {
            Contract.Requires(kodeKelas != null, "Kode kelas tidak boleh null");
            Contract.Requires(alasan != null, "Alasan tidak boleh null");

            bool validKode = ValidasiKelas(kodeKelas);
            bool validAlasan = ValidasiAlasan(alasan);

            TampilkanHasil("Kode Kelas", validKode);
            TampilkanHasil("Alasan", validAlasan);

            Contract.Ensures(Contract.Result<bool>() == (validKode && validAlasan));
            return validKode && validAlasan;
        }

        public static bool ValidasiTanggal(string tanggal, out DateTime result)
        {
            Contract.Requires(tanggal != null, "Tanggal tidak boleh null");
            bool parsed = DateTime.TryParse(tanggal, out result);
            Contract.Ensures(Contract.Result<bool>() == parsed);
            return parsed;
        }

        public static bool ValidasiAlasan(string alasan)
        {
            Contract.Requires(alasan != null, "Alasan tidak boleh null");
            Contract.Ensures(Contract.Result<bool>() == (!string.IsNullOrWhiteSpace(alasan) && alasan.Length >= 5));

            return !string.IsNullOrWhiteSpace(alasan) && alasan.Length >= 5;
        }

        public static bool ValidasiKelas(string kelas)
        {
            Contract.Requires(kelas != null, "Kelas tidak boleh null");
            Contract.Ensures(Contract.Result<bool>() == true); // sementara selalu true
            return true;
        }

        public static void TampilkanHasil(string namaField, bool hasil)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(namaField), "Nama field tidak boleh kosong");
            Console.WriteLine($"{namaField}: {(hasil ? "Valid" : "Tidak valid")}");
        }
    }
}
