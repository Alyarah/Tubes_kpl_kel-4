using System;
using System.Collections.Generic;

namespace Tubes_kpl_kel_4.Feedback
{
    public class FeedbackManager
    {
        private List<string> feedbacks = new List<string>();

        // Menambahkan feedback ke dalam daftar
        public void TambahFeedback(string feedback)
        {
            feedbacks.Add(feedback);
            Console.WriteLine("Terima kasih atas feedback Anda!");
        }

        // Menampilkan seluruh feedback yang sudah ditambahkan
        public void TampilkanFeedback()
        {
            Console.WriteLine("\n=== Daftar Feedback ===");

            if (feedbacks.Count == 0)
            {
                Console.WriteLine("Belum ada feedback.");
                return;
            }

            int nomor = 1;
            foreach (var fb in feedbacks)
            {
                Console.WriteLine($"{nomor}. {fb}");
                nomor++;
            }
        }
    }
}
