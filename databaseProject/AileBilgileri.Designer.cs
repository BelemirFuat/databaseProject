﻿namespace databaseProject
{
    partial class AileBilgileri
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
            dataGridView1 = new DataGridView();
            label1 = new Label();
            button1 = new Button();
            anaMenuBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
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
            dataGridView1.Location = new Point(37, 175);
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(65, 69, 89);
            dataGridViewCellStyle3.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowTemplate.DefaultCellStyle.BackColor = Color.FromArgb(65, 69, 89);
            dataGridView1.RowTemplate.DefaultCellStyle.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.Size = new Size(741, 434);
            dataGridView1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Small", 36F, FontStyle.Bold | FontStyle.Italic);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(411, 25);
            label1.Name = "label1";
            label1.Size = new Size(453, 71);
            label1.TabIndex = 7;
            label1.Text = "AİLE İŞLEMLERİ";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(245, 224, 220);
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold);
            button1.ForeColor = Color.Red;
            button1.Location = new Point(946, 300);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(161, 73);
            button1.TabIndex = 8;
            button1.Text = "MESAJ GÖNDER";
            button1.UseVisualStyleBackColor = false;
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
            anaMenuBtn.Location = new Point(0, 625);
            anaMenuBtn.Margin = new Padding(4);
            anaMenuBtn.Name = "anaMenuBtn";
            anaMenuBtn.Padding = new Padding(10);
            anaMenuBtn.Size = new Size(1268, 48);
            anaMenuBtn.TabIndex = 18;
            anaMenuBtn.Text = "ANA MENÜYE DÖN";
            anaMenuBtn.UseVisualStyleBackColor = false;
            anaMenuBtn.Click += anaMenuBtn_Click;
            // 
            // AileBilgileri
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(69, 71, 90);
            ClientSize = new Size(1268, 673);
            Controls.Add(anaMenuBtn);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AileBilgileri";
            Text = "AileBilgileri";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Button button1;
        private Button anaMenuBtn;
    }
}