﻿namespace databaseProject
{
    partial class OgrenciBilgileri
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button3 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            button4 = new Button();
            anaMenuBtn = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Small", 36F, FontStyle.Bold | FontStyle.Italic);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(467, 67);
            label1.Name = "label1";
            label1.Size = new Size(715, 87);
            label1.TabIndex = 0;
            label1.Text = "ÖĞRENCİ İŞLEMLERİ";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.BackgroundColor = Color.FromArgb(65, 69, 89);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(65, 69, 89);
            dataGridViewCellStyle1.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(65, 69, 89);
            dataGridViewCellStyle2.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.GridColor = Color.FromArgb(65, 69, 89);
            dataGridView1.Location = new Point(14, 251);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(65, 69, 89);
            dataGridViewCellStyle3.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.DefaultCellStyle.BackColor = Color.FromArgb(65, 69, 89);
            dataGridView1.RowTemplate.DefaultCellStyle.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.Size = new Size(1126, 713);
            dataGridView1.TabIndex = 6;
            dataGridView1.Click += dataGridView1_Click;
            dataGridView1.ChangeUICues += dataGridView1_ChangeUICues;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(245, 224, 220);
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold);
            button1.ForeColor = Color.Red;
            button1.Location = new Point(1227, 388);
            button1.Margin = new Padding(5, 5, 5, 5);
            button1.Name = "button1";
            button1.Size = new Size(191, 108);
            button1.TabIndex = 7;
            button1.Text = "ÖĞRENCİ BİLGİLERİ GÜNCELLE";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(245, 224, 220);
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold);
            button3.ForeColor = Color.Red;
            button3.Location = new Point(1227, 548);
            button3.Margin = new Padding(5, 5, 5, 5);
            button3.Name = "button3";
            button3.Size = new Size(191, 108);
            button3.TabIndex = 9;
            button3.Text = "ÖĞRENCİ BİLGİLERİNİ AYRINTILI GÖSTER";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(65, 69, 89);
            textBox1.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold);
            textBox1.ForeColor = Color.FromArgb(202, 158, 230);
            textBox1.Location = new Point(67, 193);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "TC ";
            textBox1.Size = new Size(114, 31);
            textBox1.TabIndex = 10;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(65, 69, 89);
            textBox2.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold);
            textBox2.ForeColor = Color.FromArgb(202, 158, 230);
            textBox2.Location = new Point(217, 193);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "AD-SOYAD";
            textBox2.Size = new Size(114, 31);
            textBox2.TabIndex = 11;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.FromArgb(65, 69, 89);
            textBox3.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold);
            textBox3.ForeColor = Color.FromArgb(202, 158, 230);
            textBox3.Location = new Point(378, 193);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "TELEFON NUMARASI";
            textBox3.Size = new Size(114, 31);
            textBox3.TabIndex = 12;
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.FromArgb(65, 69, 89);
            textBox4.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold);
            textBox4.ForeColor = Color.FromArgb(202, 158, 230);
            textBox4.Location = new Point(526, 193);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "BLOK";
            textBox4.Size = new Size(114, 31);
            textBox4.TabIndex = 13;
            // 
            // textBox5
            // 
            textBox5.BackColor = Color.FromArgb(65, 69, 89);
            textBox5.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold);
            textBox5.ForeColor = Color.FromArgb(202, 158, 230);
            textBox5.Location = new Point(647, 193);
            textBox5.Margin = new Padding(3, 4, 3, 4);
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = "ODA";
            textBox5.Size = new Size(114, 31);
            textBox5.TabIndex = 14;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(245, 224, 220);
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold);
            button4.ForeColor = Color.Red;
            button4.Location = new Point(839, 193);
            button4.Margin = new Padding(5, 5, 5, 5);
            button4.Name = "button4";
            button4.Size = new Size(191, 35);
            button4.TabIndex = 15;
            button4.Text = "FİLTRELEME";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // anaMenuBtn
            // 
            anaMenuBtn.BackColor = Color.FromArgb(245, 224, 220);
            anaMenuBtn.BackgroundImageLayout = ImageLayout.None;
            anaMenuBtn.Dock = DockStyle.Bottom;
            anaMenuBtn.FlatAppearance.BorderColor = Color.Cyan;
            anaMenuBtn.FlatStyle = FlatStyle.Popup;
            anaMenuBtn.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold);
            anaMenuBtn.ForeColor = Color.Red;
            anaMenuBtn.Location = new Point(0, 973);
            anaMenuBtn.Margin = new Padding(5, 5, 5, 5);
            anaMenuBtn.Name = "anaMenuBtn";
            anaMenuBtn.Padding = new Padding(11, 13, 11, 13);
            anaMenuBtn.Size = new Size(1478, 64);
            anaMenuBtn.TabIndex = 17;
            anaMenuBtn.Text = "ANA MENÜYE DÖN";
            anaMenuBtn.UseVisualStyleBackColor = false;
            anaMenuBtn.Click += anaMenuBtn_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(245, 224, 220);
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold);
            button2.ForeColor = Color.Red;
            button2.Location = new Point(1227, 693);
            button2.Margin = new Padding(5);
            button2.Name = "button2";
            button2.Size = new Size(191, 108);
            button2.TabIndex = 18;
            button2.Text = "ÖĞRENCİ ÇIKIŞINI VER";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // OgrenciBilgileri
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(69, 71, 90);
            ClientSize = new Size(1478, 1037);
            Controls.Add(button2);
            Controls.Add(anaMenuBtn);
            Controls.Add(button4);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "OgrenciBilgileri";
            Text = "OgrenciBilgileri";
            Load += OgrenciBilgileri_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private Button button1;
        private Button button3;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Button button4;
        private Button anaMenuBtn;
        private Button button2;
    }
}