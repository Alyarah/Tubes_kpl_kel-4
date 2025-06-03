namespace GUI
{
    partial class menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button_logout = new Button();
            label1 = new Label();
            button_daftarKelas = new Button();
            button2 = new Button();
            button_batalkan = new Button();
            button_status = new Button();
            button_reservasi = new Button();
            button_feedback = new Button();
            SuspendLayout();
            // 
            // button_logout
            // 
            button_logout.Location = new Point(602, 12);
            button_logout.Name = "button_logout";
            button_logout.Size = new Size(186, 41);
            button_logout.TabIndex = 0;
            button_logout.Text = "Log Out";
            button_logout.UseVisualStyleBackColor = true;
            button_logout.Click += button_logout_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F);
            label1.Location = new Point(25, 26);
            label1.Name = "label1";
            label1.Size = new Size(314, 67);
            label1.TabIndex = 1;
            label1.Text = "Menu Utama";
            label1.Click += label1_Click;
            // 
            // button_daftarKelas
            // 
            button_daftarKelas.Location = new Point(39, 123);
            button_daftarKelas.Name = "button_daftarKelas";
            button_daftarKelas.Size = new Size(728, 34);
            button_daftarKelas.TabIndex = 2;
            button_daftarKelas.Text = "Lihat Daftar Kelas";
            button_daftarKelas.UseVisualStyleBackColor = true;
            button_daftarKelas.Click += button_daftarKelas_Click;
            // 
            // button2
            // 
            button2.Location = new Point(39, 175);
            button2.Name = "button2";
            button2.Size = new Size(728, 34);
            button2.TabIndex = 3;
            button2.Text = "Reservasi Kelas";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button_batalkan
            // 
            button_batalkan.Location = new Point(39, 225);
            button_batalkan.Name = "button_batalkan";
            button_batalkan.Size = new Size(728, 34);
            button_batalkan.TabIndex = 4;
            button_batalkan.Text = "Batalkan Reservasi";
            button_batalkan.UseVisualStyleBackColor = true;
            button_batalkan.Click += button_batalkan_Click;
            // 
            // button_status
            // 
            button_status.Location = new Point(39, 281);
            button_status.Name = "button_status";
            button_status.Size = new Size(728, 34);
            button_status.TabIndex = 5;
            button_status.Text = "Status Reservasi";
            button_status.UseVisualStyleBackColor = true;
            button_status.Click += button_status_Click;
            // 
            // button_reservasi
            // 
            button_reservasi.Location = new Point(39, 330);
            button_reservasi.Name = "button_reservasi";
            button_reservasi.Size = new Size(728, 34);
            button_reservasi.TabIndex = 6;
            button_reservasi.Text = "Riwayat Reservasi";
            button_reservasi.UseVisualStyleBackColor = true;
            button_reservasi.Click += button_reservasi_Click;
            // 
            // button_feedback
            // 
            button_feedback.Location = new Point(39, 382);
            button_feedback.Name = "button_feedback";
            button_feedback.Size = new Size(728, 34);
            button_feedback.TabIndex = 7;
            button_feedback.Text = "Feedback";
            button_feedback.UseVisualStyleBackColor = true;
            button_feedback.Click += button_feedback_Click;
            // 
            // menu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button_feedback);
            Controls.Add(button_reservasi);
            Controls.Add(button_status);
            Controls.Add(button_batalkan);
            Controls.Add(button2);
            Controls.Add(button_daftarKelas);
            Controls.Add(label1);
            Controls.Add(button_logout);
            Name = "menu";
            Text = "menu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_logout;
        private Label label1;
        private Button button_daftarKelas;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button_batalkan;
        private Button button_status;
        private Button button_reservasi;
        private Button button_feedback;
    }
}