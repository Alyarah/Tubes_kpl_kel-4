using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Tubes_kpl_kel_4.Validators;

namespace Tubes_kpl_kel_4.Feedback
{
    public class FeedbackManager
    {
        private readonly List<string> _feedbacks = new();

        /// Menambahkan feedback pengguna setelah melalui proses validasi dan sanitasi.
        public void TambahFeedback(string feedback)
        {
            if (!Validasi.ValidasiAlasan(feedback))
            {
                Console.WriteLine("Feedback tidak valid. Minimal 5 karakter dan tidak boleh kosong.");
                return;
            }

            if (feedback.Length > 500)
            {
                Console.WriteLine("Feedback terlalu panjang. Maksimal 500 karakter.");
                return;
            }

            string bersih = Sanitize(feedback);

            if (IsDuplicate(bersih))
            {
                Console.WriteLine("Feedback sudah pernah dikirim.");
                return;
            }

            _feedbacks.Add(bersih);
            Console.WriteLine("Terima kasih atas feedback Anda!");
        }

        /// Menampilkan seluruh feedback yang telah disimpan.
        public void TampilkanFeedback()
        {
            Console.WriteLine("\n=== Daftar Feedback ===");

            if (_feedbacks.Count == 0)
            {
                Console.WriteLine("Belum ada feedback.");
                return;
            }

            int nomor = 1;
            foreach (var fb in _feedbacks)
                Console.WriteLine($"{nomor++}. {fb}");
        }

        /// Mengecek apakah feedback sudah pernah dikirim sebelumnya.
        private bool IsDuplicate(string feedback) =>
            _feedbacks.Contains(feedback, StringComparer.OrdinalIgnoreCase);

        /// Menghapus tag HTML untuk mencegah potensi injeksi.
        private string Sanitize(string input) =>
            Regex.Replace(input.Trim(), "<.*?>", string.Empty);
    }
}
