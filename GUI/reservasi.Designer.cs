namespace GUI
{
    partial class reservasi
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
            lbl_reservasi = new Label();
            label_tempat = new Label();
            tempat = new TextBox();
            textBox_ruangan = new TextBox();
            label_ruangan = new Label();
            textBox_tanggal = new TextBox();
            label_tanggal = new Label();
            textBox_mulai = new TextBox();
            label_jam = new Label();
            textBox_selesai = new TextBox();
            label_selesai = new Label();
            label_mulai = new Label();
            textBox_kapasitas = new TextBox();
            label_kapasitas = new Label();
            buttonS = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // lbl_reservasi
            // 
            lbl_reservasi.AutoSize = true;
            lbl_reservasi.Font = new Font("Segoe UI", 15F);
            lbl_reservasi.Location = new Point(411, 30);
            lbl_reservasi.Margin = new Padding(4, 0, 4, 0);
            lbl_reservasi.Name = "lbl_reservasi";
            lbl_reservasi.Size = new Size(139, 41);
            lbl_reservasi.TabIndex = 0;
            lbl_reservasi.Text = "Reservasi";
            // 
            // label_tempat
            // 
            label_tempat.AutoSize = true;
            label_tempat.Location = new Point(75, 96);
            label_tempat.Margin = new Padding(4, 0, 4, 0);
            label_tempat.Name = "label_tempat";
            label_tempat.Size = new Size(70, 25);
            label_tempat.TabIndex = 1;
            label_tempat.Text = "Tempat";
            label_tempat.Click += label_tempat_Click;
            // 
            // tempat
            // 
            tempat.Location = new Point(75, 131);
            tempat.Margin = new Padding(4, 4, 4, 4);
            tempat.Name = "tempat";
            tempat.Size = new Size(878, 31);
            tempat.TabIndex = 2;
            tempat.TextChanged += tempat_TextChanged;
            // 
            // textBox_ruangan
            // 
            textBox_ruangan.Location = new Point(75, 210);
            textBox_ruangan.Margin = new Padding(4, 4, 4, 4);
            textBox_ruangan.Name = "textBox_ruangan";
            textBox_ruangan.Size = new Size(878, 31);
            textBox_ruangan.TabIndex = 4;
            // 
            // label_ruangan
            // 
            label_ruangan.AutoSize = true;
            label_ruangan.Location = new Point(75, 174);
            label_ruangan.Margin = new Padding(4, 0, 4, 0);
            label_ruangan.Name = "label_ruangan";
            label_ruangan.Size = new Size(82, 25);
            label_ruangan.TabIndex = 3;
            label_ruangan.Text = "Ruangan";
            // 
            // textBoxt_tanggal
            // 
            textBox_tanggal.Location = new Point(75, 370);
            textBox_tanggal.Margin = new Padding(4, 4, 4, 4);
            textBox_tanggal.Name = "textBoxt_tanggal";
            textBox_tanggal.Size = new Size(878, 31);
            textBox_tanggal.TabIndex = 6;
            textBox_tanggal.TextChanged += textBoxt_tanggal_TextChanged;
            // 
            // label_tanggal
            // 
            label_tanggal.AutoSize = true;
            label_tanggal.Location = new Point(72, 329);
            label_tanggal.Margin = new Padding(4, 0, 4, 0);
            label_tanggal.Name = "label_tanggal";
            label_tanggal.Size = new Size(192, 25);
            label_tanggal.TabIndex = 5;
            label_tanggal.Text = "Tanggal (yyyy-mm-dd)";
            // 
            // textBox_mulai
            // 
            textBox_mulai.Location = new Point(200, 428);
            textBox_mulai.Margin = new Padding(4, 4, 4, 4);
            textBox_mulai.Name = "textBox_mulai";
            textBox_mulai.Size = new Size(220, 31);
            textBox_mulai.TabIndex = 8;
            textBox_mulai.TextChanged += textBox_mulai_TextChanged;
            // 
            // label_jam
            // 
            label_jam.AutoSize = true;
            label_jam.Location = new Point(739, 22);
            label_jam.Margin = new Padding(4, 0, 4, 0);
            label_jam.Name = "label_jam";
            label_jam.Size = new Size(0, 25);
            label_jam.TabIndex = 7;
            label_jam.Click += label_jam_Click;
            // 
            // textBox_selesai
            // 
            textBox_selesai.Location = new Point(656, 429);
            textBox_selesai.Margin = new Padding(4, 4, 4, 4);
            textBox_selesai.Name = "textBox_selesai";
            textBox_selesai.Size = new Size(232, 31);
            textBox_selesai.TabIndex = 10;
            textBox_selesai.TextChanged += textBox_selesai_TextChanged;
            // 
            // label_selesai
            // 
            label_selesai.AutoSize = true;
            label_selesai.Location = new Point(545, 434);
            label_selesai.Margin = new Padding(4, 0, 4, 0);
            label_selesai.Name = "label_selesai";
            label_selesai.Size = new Size(99, 25);
            label_selesai.TabIndex = 9;
            label_selesai.Text = "Jam selesai";
            label_selesai.Click += label_selesai_Click;
            // 
            // label_mulai
            // 
            label_mulai.AutoSize = true;
            label_mulai.Location = new Point(72, 432);
            label_mulai.Margin = new Padding(4, 0, 4, 0);
            label_mulai.Name = "label_mulai";
            label_mulai.Size = new Size(91, 25);
            label_mulai.TabIndex = 11;
            label_mulai.Text = "Jam mulai";
            // 
            // textBox_kapasitas
            // 
            textBox_kapasitas.Location = new Point(75, 288);
            textBox_kapasitas.Margin = new Padding(4, 4, 4, 4);
            textBox_kapasitas.Name = "textBox_kapasitas";
            textBox_kapasitas.Size = new Size(878, 31);
            textBox_kapasitas.TabIndex = 13;
            // 
            // label_kapasitas
            // 
            label_kapasitas.AutoSize = true;
            label_kapasitas.Location = new Point(75, 251);
            label_kapasitas.Margin = new Padding(4, 0, 4, 0);
            label_kapasitas.Name = "label_kapasitas";
            label_kapasitas.Size = new Size(86, 25);
            label_kapasitas.TabIndex = 12;
            label_kapasitas.Text = "Kapasitas";
            // 
            // buttonS
            // 
            buttonS.Location = new Point(421, 496);
            buttonS.Margin = new Padding(4, 4, 4, 4);
            buttonS.Name = "buttonS";
            buttonS.Size = new Size(118, 36);
            buttonS.TabIndex = 14;
            buttonS.Text = "Submit";
            buttonS.UseVisualStyleBackColor = true;
            buttonS.Click += button_submit_Click;
            // 
            // button2
            // 
            button2.Location = new Point(30, 26);
            button2.Margin = new Padding(4, 4, 4, 4);
            button2.Name = "button2";
            button2.Size = new Size(71, 31);
            button2.TabIndex = 15;
            button2.Text = "Back";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // reservasi
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 562);
            Controls.Add(button2);
            Controls.Add(buttonS);
            Controls.Add(textBox_kapasitas);
            Controls.Add(label_kapasitas);
            Controls.Add(label_mulai);
            Controls.Add(textBox_selesai);
            Controls.Add(label_selesai);
            Controls.Add(textBox_mulai);
            Controls.Add(label_jam);
            Controls.Add(textBox_tanggal);
            Controls.Add(label_tanggal);
            Controls.Add(textBox_ruangan);
            Controls.Add(label_ruangan);
            Controls.Add(tempat);
            Controls.Add(label_tempat);
            Controls.Add(lbl_reservasi);
            Margin = new Padding(4, 4, 4, 4);
            Name = "reservasi";
            Text = "reservasi";
            Load += reservasi_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_reservasi;
        private Label label_tempat;
        private TextBox tempat;
        private TextBox textBox_ruangan;
        private Label label_ruangan;
        private TextBox textBox_tanggal;
        private Label label_tanggal;
        private TextBox textBox_mulai;
        private Label label_jam;
        private TextBox textBox_selesai;
        private Label label_selesai;
        private Label label_mulai;
        private TextBox textBox_kapasitas;
        private Label label_kapasitas;
        private Button buttonS;
        private Button button2;
    }
}