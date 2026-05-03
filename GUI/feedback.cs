using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tubes_kpl_kel_4.Feedback;
using Tubes_kpl_kel_4.Models;

namespace GUI
{
    public partial class feedback : Form
    {

        private User _user;

        public feedback(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void label_feedback_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox_feedback_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_submit_Click(object sender, EventArgs e)
        {
            string feedbackText = textBox_feedback.Text.Trim();

            if (string.IsNullOrEmpty(feedbackText))
            {
                MessageBox.Show("Feedback tidak boleh kosong.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FeedbackManager fbMan = new FeedbackManager();
            fbMan.TambahFeedback(feedbackText);
            MessageBox.Show("Terima kasih atas feedback Anda!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            textBox_feedback.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu menuUtama = new menu(_user);
            menuUtama.Show();
            this.Hide();
        }

        private void feedback_Load(object sender, EventArgs e)
        {

        }
    }
}
