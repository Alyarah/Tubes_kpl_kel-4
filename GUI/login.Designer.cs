namespace GUI
{
    partial class login
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
            textBox_email = new TextBox();
            textBox_nama = new TextBox();
            textBox_pass = new TextBox();
            label_nama = new Label();
            label2 = new Label();
            label3 = new Label();
            button_login = new Button();
            button_back = new Button();
            SuspendLayout();
            // 
            // textBox_email
            // 
            textBox_email.Location = new Point(39, 127);
            textBox_email.Margin = new Padding(2, 2, 2, 2);
            textBox_email.Name = "textBox_email";
            textBox_email.Size = new Size(492, 23);
            textBox_email.TabIndex = 0;
            textBox_email.TextChanged += textBox_email_TextChanged;
            // 
            // textBox_nama
            // 
            textBox_nama.Location = new Point(39, 73);
            textBox_nama.Margin = new Padding(2, 2, 2, 2);
            textBox_nama.Name = "textBox_nama";
            textBox_nama.Size = new Size(492, 23);
            textBox_nama.TabIndex = 1;
            textBox_nama.TextChanged += textBox_nama_TextChanged;
            // 
            // textBox_pass
            // 
            textBox_pass.Location = new Point(39, 179);
            textBox_pass.Margin = new Padding(2, 2, 2, 2);
            textBox_pass.Name = "textBox_pass";
            textBox_pass.Size = new Size(492, 23);
            textBox_pass.TabIndex = 2;
            textBox_pass.TextChanged += textBox_pass_TextChanged;
            // 
            // label_nama
            // 
            label_nama.AutoSize = true;
            label_nama.Location = new Point(39, 46);
            label_nama.Margin = new Padding(2, 0, 2, 0);
            label_nama.Name = "label_nama";
            label_nama.Size = new Size(39, 15);
            label_nama.TabIndex = 3;
            label_nama.Text = "Nama";
            label_nama.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 101);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 4;
            label2.Text = "Email";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 156);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 5;
            label3.Text = "Password";
            label3.Click += label3_Click;
            // 
            // button_login
            // 
            button_login.Location = new Point(225, 219);
            button_login.Margin = new Padding(2, 2, 2, 2);
            button_login.Name = "button_login";
            button_login.Size = new Size(127, 26);
            button_login.TabIndex = 6;
            button_login.Text = "Masuk";
            button_login.UseVisualStyleBackColor = true;
            button_login.Click += button_login_Click;
            // 
            // button_back
            // 
            button_back.Location = new Point(8, 14);
            button_back.Margin = new Padding(2, 2, 2, 2);
            button_back.Name = "button_back";
            button_back.Size = new Size(43, 21);
            button_back.TabIndex = 7;
            button_back.Text = "back";
            button_back.UseVisualStyleBackColor = true;
            button_back.Click += button_back_Click;
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 270);
            Controls.Add(button_back);
            Controls.Add(button_login);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label_nama);
            Controls.Add(textBox_pass);
            Controls.Add(textBox_nama);
            Controls.Add(textBox_email);
            Margin = new Padding(2, 2, 2, 2);
            Name = "login";
            Text = "login";
            Load += login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_email;
        private TextBox textBox_nama;
        private TextBox textBox_pass;
        private Label label_nama;
        private Label label2;
        private Label label3;
        private Button button_login;
        private Button button_back;
    }
}