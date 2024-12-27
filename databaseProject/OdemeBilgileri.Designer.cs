namespace databaseProject
{
    partial class OdemeBilgileri
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
            button1_MESAJ = new Button();
            anaMenuBtn = new Button();
            button2 = new Button();
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
            dataGridView1.Location = new Point(30, 167);
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
            dataGridView1.Size = new Size(915, 636);
            dataGridView1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Small", 36F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Transparent;
            label1.Location = new Point(453, 37);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(631, 87);
            label1.TabIndex = 9;
            label1.Text = "ÖDEME BİLGİLERİ";
            // 
            // button1_MESAJ
            // 
            button1_MESAJ.BackColor = Color.FromArgb(245, 224, 220);
            button1_MESAJ.FlatStyle = FlatStyle.Popup;
            button1_MESAJ.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold);
            button1_MESAJ.ForeColor = Color.Red;
            button1_MESAJ.Location = new Point(1102, 314);
            button1_MESAJ.Margin = new Padding(5);
            button1_MESAJ.Name = "button1_MESAJ";
            button1_MESAJ.Size = new Size(191, 108);
            button1_MESAJ.TabIndex = 12;
            button1_MESAJ.Text = "ÖDEME YAPMAYANLARA MESAJ GÖNDER";
            button1_MESAJ.UseVisualStyleBackColor = false;
            button1_MESAJ.Click += button1_Click;
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
            anaMenuBtn.Location = new Point(0, 832);
            anaMenuBtn.Margin = new Padding(5);
            anaMenuBtn.Name = "anaMenuBtn";
            anaMenuBtn.Padding = new Padding(11, 13, 11, 13);
            anaMenuBtn.Size = new Size(1440, 64);
            anaMenuBtn.TabIndex = 13;
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
            button2.Location = new Point(1102, 504);
            button2.Margin = new Padding(5);
            button2.Name = "button2";
            button2.Size = new Size(191, 108);
            button2.TabIndex = 14;
            button2.Text = "YENİ DÖNEME GEÇ ";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // OdemeBilgileri
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(69, 71, 90);
            ClientSize = new Size(1440, 896);
            Controls.Add(button2);
            Controls.Add(anaMenuBtn);
            Controls.Add(button1_MESAJ);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "OdemeBilgileri";
            Text = "OdemeBilgileri";
            Load += OdemeBilgileri_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Button button1_MESAJ;
        private Button anaMenuBtn;
        private Button button2;
    }
}