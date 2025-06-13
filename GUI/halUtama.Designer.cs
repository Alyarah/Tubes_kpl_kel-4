namespace GUI
{
    partial class halUtama
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label_namaApp = new Label();
            button_regis = new Button();
            button_login = new Button();
            button_selesai = new Button();
            SuspendLayout();
            // 
            // label_namaApp
            // 
            label_namaApp.AutoSize = true;
            label_namaApp.Font = new Font("Segoe UI", 45F);
            label_namaApp.Location = new Point(205, 42);
            label_namaApp.Name = "label_namaApp";
            label_namaApp.Size = new Size(396, 120);
            label_namaApp.TabIndex = 0;
            label_namaApp.Text = "Room4U";
            label_namaApp.Click += label1_Click;
            // 
            // button_regis
            // 
            button_regis.Location = new Point(210, 207);
            button_regis.Name = "button_regis";
            button_regis.Size = new Size(390, 52);
            button_regis.TabIndex = 1;
            button_regis.Text = "Registrasi";
            button_regis.UseVisualStyleBackColor = true;
            button_regis.Click += button_regis_Click;
            // 
            // button_login
            // 
            button_login.Location = new Point(210, 278);
            button_login.Name = "button_login";
            button_login.Size = new Size(390, 52);
            button_login.TabIndex = 2;
            button_login.Text = "Login";
            button_login.UseVisualStyleBackColor = true;
            button_login.Click += button_login_Click;
            // 
            // button_selesai
            // 
            button_selesai.Location = new Point(210, 351);
            button_selesai.Name = "button_selesai";
            button_selesai.Size = new Size(390, 52);
            button_selesai.TabIndex = 3;
            button_selesai.Text = "Selesai";
            button_selesai.UseVisualStyleBackColor = true;
            button_selesai.Click += button1_Click;
            // 
            // halUtama
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button_selesai);
            Controls.Add(button_login);
            Controls.Add(button_regis);
            Controls.Add(label_namaApp);
            Name = "halUtama";
            Text = "Form1";
            Load += halUtama_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_namaApp;
        private Button button_regis;
        private Button button_login;
        private Button button_selesai;
    }
}
