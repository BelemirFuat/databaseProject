﻿namespace databaseProject
{
    partial class Eftler
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            button1 = new Button();
            anaMenuBtn = new Button();
            button4 = new Button();
            textBox5 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.BackgroundColor = Color.FromArgb(65, 69, 89);
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(65, 69, 89);
            dataGridViewCellStyle4.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(65, 69, 89);
            dataGridViewCellStyle5.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            dataGridView1.GridColor = Color.FromArgb(65, 69, 89);
            dataGridView1.Location = new Point(25, 239);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(65, 69, 89);
            dataGridViewCellStyle6.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.DefaultCellStyle.BackColor = Color.FromArgb(65, 69, 89);
            dataGridView1.RowTemplate.DefaultCellStyle.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.Size = new Size(888, 540);
            dataGridView1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Small", 36F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Transparent;
            label1.Location = new Point(559, 12);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(288, 88);
            label1.TabIndex = 7;
            label1.Text = "EFTLER";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(245, 224, 220);
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold);
            button1.ForeColor = Color.Red;
            button1.Location = new Point(1087, 432);
            button1.Margin = new Padding(5);
            button1.Name = "button1";
            button1.Size = new Size(191, 108);
            button1.TabIndex = 18;
            button1.Text = "Bilgileri Güncelle";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
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
            anaMenuBtn.Location = new Point(0, 797);
            anaMenuBtn.Margin = new Padding(5);
            anaMenuBtn.Name = "anaMenuBtn";
            anaMenuBtn.Padding = new Padding(11, 13, 11, 13);
            anaMenuBtn.Size = new Size(1441, 64);
            anaMenuBtn.TabIndex = 20;
            anaMenuBtn.Text = "ANA MENÜYE DÖN";
            anaMenuBtn.UseVisualStyleBackColor = false;
            anaMenuBtn.Click += anaMenuBtn_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(245, 224, 220);
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold);
            button4.ForeColor = Color.Red;
            button4.Location = new Point(234, 173);
            button4.Margin = new Padding(5);
            button4.Name = "button4";
            button4.Size = new Size(191, 35);
            button4.TabIndex = 26;
            button4.Text = "FİLTRELEME";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // textBox5
            // 
            textBox5.BackColor = Color.FromArgb(65, 69, 89);
            textBox5.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold);
            textBox5.ForeColor = Color.FromArgb(202, 158, 230);
            textBox5.Location = new Point(48, 173);
            textBox5.Margin = new Padding(3, 4, 3, 4);
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = "TC";
            textBox5.Size = new Size(150, 31);
            textBox5.TabIndex = 25;
            // 
            // Eftler
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(69, 71, 90);
            ClientSize = new Size(1441, 861);
            Controls.Add(button4);
            Controls.Add(textBox5);
            Controls.Add(anaMenuBtn);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Eftler";
            Text = "Eftler";
            Load += Eftler_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Button button1;
        private Button anaMenuBtn;
        private Button button4;
        private TextBox textBox5;
    }
}