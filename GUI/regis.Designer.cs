namespace GUI
{
    partial class regis
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
            button_back = new Button();
            button_regis = new Button();
            label3 = new Label();
            label2 = new Label();
            label_nama = new Label();
            textBox_pass = new TextBox();
            textBox_nama = new TextBox();
            textBox_email = new TextBox();
            SuspendLayout();
            // 
            // button_back
            // 
            button_back.Location = new Point(28, 32);
            button_back.Name = "button_back";
            button_back.Size = new Size(62, 35);
            button_back.TabIndex = 15;
            button_back.Text = "back";
            button_back.UseVisualStyleBackColor = true;
            button_back.Click += button_back_Click;
            // 
            // button_login
            // 
            button_regis.Location = new Point(337, 374);
            button_regis.Name = "button_login";
            button_regis.Size = new Size(181, 44);
            button_regis.TabIndex = 14;
            button_regis.Text = "Daftar";
            button_regis.UseVisualStyleBackColor = true;
            button_regis.Click += button_regis_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(72, 269);
            label3.Name = "label3";
            label3.Size = new Size(87, 25);
            label3.TabIndex = 13;
            label3.Text = "Password";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 178);
            label2.Name = "label2";
            label2.Size = new Size(54, 25);
            label2.TabIndex = 12;
            label2.Text = "Email";
            label2.Click += label2_Click;
            // 
            // label_nama
            // 
            label_nama.AutoSize = true;
            label_nama.Location = new Point(72, 85);
            label_nama.Name = "label_nama";
            label_nama.Size = new Size(59, 25);
            label_nama.TabIndex = 11;
            label_nama.Text = "Nama";
            label_nama.Click += label_nama_Click;
            // 
            // textBox_pass
            // 
            textBox_pass.Location = new Point(72, 308);
            textBox_pass.Name = "textBox_pass";
            textBox_pass.Size = new Size(701, 31);
            textBox_pass.TabIndex = 10;
            textBox_pass.TextChanged += textBox_pass_TextChanged;
            // 
            // textBox_nama
            // 
            textBox_nama.Location = new Point(72, 131);
            textBox_nama.Name = "textBox_nama";
            textBox_nama.Size = new Size(701, 31);
            textBox_nama.TabIndex = 9;
            textBox_nama.TextChanged += textBox_nama_TextChanged;
            // 
            // textBox_email
            // 
            textBox_email.Location = new Point(72, 221);
            textBox_email.Name = "textBox_email";
            textBox_email.Size = new Size(701, 31);
            textBox_email.TabIndex = 8;
            textBox_email.TextChanged += textBox_email_TextChanged;
            // 
            // regis
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button_back);
            Controls.Add(button_regis);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label_nama);
            Controls.Add(textBox_pass);
            Controls.Add(textBox_nama);
            Controls.Add(textBox_email);
            Name = "regis";
            Text = "regis";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_back;
        private Button button_regis;
        private Label label3;
        private Label label2;
        private Label label_nama;
        private TextBox textBox_pass;
        private TextBox textBox_nama;
        private TextBox textBox_email;
    }
}