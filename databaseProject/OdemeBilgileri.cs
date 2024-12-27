using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace databaseProject
{
    public partial class OdemeBilgileri : Form
    {
        private SQLiteConnection conn;  // SQLiteConnection formun bir üyesi olarak tanımlandı
        private SQLiteDataAdapter adap; // DataAdapter tanımlandı
        private DataSet ds;
        public OdemeBilgileri()
        {
            InitializeComponent();
        }

        private void anaMenuBtn_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private SQLiteConnection StartConnectionToDB()
        {
            string relativePath = "..\\..\\..\\..\\projectDB.db";
            string fullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
            string connectionString = $"Data Source={fullPath};Version=3;";
            return new SQLiteConnection(connectionString);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = StartConnectionToDB())
            {
                try
                {
                    conn.Open();

                    // Ödeme yapılmayan öğrencileri sorgula
                    string query = "SELECT TC FROM OdemeBilgileri WHERE DURUM = 0";
                    using (SQLiteCommand command = new SQLiteCommand(query, conn))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            StringBuilder mesaj = new StringBuilder();
                            while (reader.Read())
                            {
                                string tc = reader["TC"].ToString();

                                // Öğrencinin adını ogrenciBilgileri tablosundan al
                                string queryOgrenci = "SELECT ADI FROM ogrenciBilgileri WHERE TC = @tc";
                                using (SQLiteCommand studentCommand = new SQLiteCommand(queryOgrenci, conn))
                                {
                                    studentCommand.Parameters.AddWithValue("@tc", tc);
                                    object result = studentCommand.ExecuteScalar();

                                    if (result != null)
                                    {
                                        string ogrenciAdi = result.ToString();
                                        mesaj.AppendLine($"Öğrenci: {ogrenciAdi} (TC: {tc}) - Ödeme yapılmadı.");
                                    }
                                    else
                                    {
                                        mesaj.AppendLine($"TC: {tc} - Öğrenci bilgisi bulunamadı.");
                                    }
                                }
                            }

                            // Eğer ödeme yapılmayan öğrenci varsa mesaj göster
                            if (mesaj.Length > 0)
                            {
                                MessageBox.Show(mesaj.ToString(), "Ödeme Yapılmadı SMS Gönderimi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                MessageBox.Show("Tüm öğrencilerin ödemesi yapılmıştır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void loadData(string filter = "")
        {
            try
            {
                // Veritabanı bağlantısını başlat
                conn = StartConnectionToDB();
                conn.Open();
                string lastFilter = "";
                if (filter == "")
                    lastFilter = "";
                else
                    lastFilter = "where " + filter;


                // SQL sorgusu: Tablo verilerini çek
                string query = "SELECT * FROM odemeBilgileri " + lastFilter;

                //MessageBox.Show(query); hayat kurtarıcı
                // DataAdapter ve DataSet oluştur
                adap = new SQLiteDataAdapter(query, conn);
                ds = new DataSet();

                // Verileri DataSet'e yükle
                adap.Fill(ds, "odemeBilgileri");

                // DataGridView'i DataSet'e bağla
                dataGridView1.DataSource = ds.Tables["odemeBilgileri"];
            }
            catch (Exception ex)
            {
                // Hata durumunda mesaj göster
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void OdemeBilgileri_Load(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
