namespace databaseProject
{
    partial class AnaMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaMenu));
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Small", 36F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Transparent;
            label1.Location = new Point(387, 20);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(674, 71);
            label1.TabIndex = 0;
            label1.Text = "KYK YURT OTOMASYONU";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(245, 224, 220);
            button1.FlatStyle = FlatStyle.Popup;
            button1.ForeColor = Color.Red;
            button1.Location = new Point(862, 214);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(167, 81);
            button1.TabIndex = 1;
            button1.Text = "ÖĞRENCİ İŞLEMLERİ";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(245, 224, 220);
            button2.FlatStyle = FlatStyle.Popup;
            button2.ForeColor = Color.Red;
            button2.Location = new Point(862, 325);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(167, 81);
            button2.TabIndex = 2;
            button2.Text = "AİLE BİLGİLERİ";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(245, 224, 220);
            button3.FlatStyle = FlatStyle.Popup;
            button3.ForeColor = Color.Red;
            button3.Location = new Point(1114, 325);
            button3.Margin = new Padding(4);
            button3.Name = "button3";
            button3.Size = new Size(167, 81);
            button3.TabIndex = 3;
            button3.Text = "EFTLER";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(245, 224, 220);
            button4.FlatStyle = FlatStyle.Popup;
            button4.ForeColor = Color.Red;
            button4.Location = new Point(1114, 214);
            button4.Margin = new Padding(4);
            button4.Name = "button4";
            button4.Size = new Size(167, 81);
            button4.TabIndex = 4;
            button4.Text = "FİYATLAR";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(245, 224, 220);
            button6.FlatStyle = FlatStyle.Popup;
            button6.ForeColor = Color.Red;
            button6.Location = new Point(862, 446);
            button6.Margin = new Padding(4);
            button6.Name = "button6";
            button6.Size = new Size(167, 81);
            button6.TabIndex = 6;
            button6.Text = "ODALAR";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(245, 224, 220);
            button7.FlatStyle = FlatStyle.Popup;
            button7.ForeColor = Color.Red;
            button7.Location = new Point(1114, 446);
            button7.Margin = new Padding(4);
            button7.Name = "button7";
            button7.Size = new Size(167, 81);
            button7.TabIndex = 7;
            button7.Text = "ÖDEME BİLGİLERİ";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.FromArgb(245, 224, 220);
            button8.FlatStyle = FlatStyle.Popup;
            button8.ForeColor = Color.Red;
            button8.Location = new Point(999, 574);
            button8.Margin = new Padding(4);
            button8.Name = "button8";
            button8.Size = new Size(167, 81);
            button8.TabIndex = 8;
            button8.Text = "GİRİŞ/ÇIKIŞ";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(15, 136);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(733, 561);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // AnaMenu
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(69, 71, 90);
            ClientSize = new Size(1415, 837);
            Controls.Add(pictureBox1);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Font = new Font("Cascadia Code SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.DarkRed;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4);
            Name = "AnaMenu";
            Text = "AnaMenu";
            Load += AnaMenu_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button6;
        private Button button7;
        private Button button8;
        private PictureBox pictureBox1;
    }
}