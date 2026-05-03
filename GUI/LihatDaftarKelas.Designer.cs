namespace GUI
{
    partial class LihatDaftarKelas
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
            label1 = new Label();
            buttonBack = new Button();
            label2 = new Label();
            listBoxDaftarKelas = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F);
            label1.Location = new Point(282, 41);
            label1.Name = "label1";
            label1.Size = new Size(179, 30);
            label1.TabIndex = 0;
            label1.Text = "Lihat Daftar Kelas";
            label1.Click += label1_Click;
            // 
            // buttonBack
            // 
            buttonBack.Location = new Point(25, 23);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(50, 29);
            buttonBack.TabIndex = 1;
            buttonBack.Text = "Back";
            buttonBack.UseVisualStyleBackColor = true;
            buttonBack.Click += buttonBack_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 122);
            label2.Name = "label2";
            label2.Size = new Size(149, 20);
            label2.TabIndex = 2;
            label2.Text = "Daftar Kelas Tersedia";
            label2.Click += label2_Click;
            // 
            // listBoxDaftarKelas
            // 
            listBoxDaftarKelas.FormattingEnabled = true;
            listBoxDaftarKelas.Location = new Point(40, 161);
            listBoxDaftarKelas.Name = "listBoxDaftarKelas";
            listBoxDaftarKelas.Size = new Size(538, 244);
            listBoxDaftarKelas.TabIndex = 3;
            listBoxDaftarKelas.SelectedIndexChanged += listBoxDaftarKelas_SelectedIndexChanged;
            // 
            // LihatDaftarKelas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listBoxDaftarKelas);
            Controls.Add(label2);
            Controls.Add(buttonBack);
            Controls.Add(label1);
            Name = "LihatDaftarKelas";
            Text = "LihatDaftarKelas";
            Load += LihatDaftarKelas_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button buttonBack;
        private Label label2;
        private ListBox listBoxDaftarKelas;
    }
}