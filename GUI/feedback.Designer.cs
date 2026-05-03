namespace GUI
{
    partial class feedback
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
            label_feedback = new Label();
            label1 = new Label();
            textBox_feedback = new TextBox();
            button_submit = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // label_feedback
            // 
            label_feedback.AutoSize = true;
            label_feedback.Font = new Font("Segoe UI", 30F);
            label_feedback.Location = new Point(197, 54);
            label_feedback.Margin = new Padding(2, 0, 2, 0);
            label_feedback.Name = "label_feedback";
            label_feedback.Size = new Size(236, 67);
            label_feedback.TabIndex = 0;
            label_feedback.Text = "Feedback";
            label_feedback.Click += label_feedback_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 148);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(178, 20);
            label1.TabIndex = 1;
            label1.Text = "Masukkan Feedback anda";
            label1.Click += label1_Click_1;
            // 
            // textBox_feedback
            // 
            textBox_feedback.Location = new Point(38, 189);
            textBox_feedback.Margin = new Padding(2, 2, 2, 2);
            textBox_feedback.Name = "textBox_feedback";
            textBox_feedback.Size = new Size(561, 27);
            textBox_feedback.TabIndex = 2;
            textBox_feedback.TextChanged += textBox_feedback_TextChanged;
            // 
            // button_submit
            // 
            button_submit.Location = new Point(247, 265);
            button_submit.Margin = new Padding(2, 2, 2, 2);
            button_submit.Name = "button_submit";
            button_submit.Size = new Size(115, 35);
            button_submit.TabIndex = 3;
            button_submit.Text = "Submit";
            button_submit.UseVisualStyleBackColor = true;
            button_submit.Click += button_submit_Click;
            // 
            // button1
            // 
            button1.Location = new Point(22, 21);
            button1.Margin = new Padding(2, 2, 2, 2);
            button1.Name = "button1";
            button1.Size = new Size(48, 28);
            button1.TabIndex = 4;
            button1.Text = "back";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // feedback
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 360);
            Controls.Add(button1);
            Controls.Add(button_submit);
            Controls.Add(textBox_feedback);
            Controls.Add(label1);
            Controls.Add(label_feedback);
            Margin = new Padding(2, 2, 2, 2);
            Name = "feedback";
            Text = "feedback";
            Load += feedback_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_feedback;
        private Label label1;
        private TextBox textBox_feedback;
        private Button button_submit;
        private Button button1;
    }
}