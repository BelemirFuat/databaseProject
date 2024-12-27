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
            using (SQLiteConnection conn = StartConnectionToDB())
            {
                try
                {
                    conn.Open();

                    // Tüm öğrencilerin TC, Blok ve Oda bilgilerini sorgula
                    string query = "SELECT TC, Blok, Oda FROM ogrenciBilgileri";
                    using (SQLiteCommand command = new SQLiteCommand(query, conn))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Öğrenci bilgilerini oku
                                string tc = reader["TC"].ToString();
                                string blok = reader["Blok"].ToString();
                                string odaNumarasi = reader["Oda"].ToString();

                                // Oda durumu tablosundan yatak sayısını al
                                int yatakSayisi = GetYatakSayisi(conn, blok, odaNumarasi);

                                if (yatakSayisi == 0)
                                {
                                    MessageBox.Show($"Yatak sayısı bulunamadı: Blok={blok}, Oda={odaNumarasi}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    continue;
                                }

                                // Oda fiyatları tablosundan fiyat bilgisi al
                                decimal fiyat = GetOdaFiyati(conn, yatakSayisi);

                                if (fiyat == 0)
                                {
                                    MessageBox.Show($"Oda fiyatı bulunamadı: Yatak Sayısı={yatakSayisi}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    continue;
                                }

                                // Çıkış durumu ve gün sayısına göre borcu hesapla
                                decimal borc = CalculateBorc(conn, tc, fiyat);

                                // Borcu ödeme bilgileri tablosuna yaz
                                InsertOrUpdateOdemeBilgisi(conn, tc, borc);
                            }
                        }
                    }

                    MessageBox.Show("Tüm öğrencilerin borç bilgileri hesaplandı ve güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int GetYatakSayisi(SQLiteConnection conn, string blok, string odaNumarasi)
        {
            string query = "SELECT yataksayi FROM oda_durumu WHERE blok = @blok AND numara = @odaNumarasi";
            using (SQLiteCommand command = new SQLiteCommand(query, conn))
            {
                command.Parameters.AddWithValue("@blok", blok);
                command.Parameters.AddWithValue("@odaNumarasi", odaNumarasi);

                object result = command.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        private decimal GetOdaFiyati(SQLiteConnection conn, int yatakSayisi)
        {
            string query = "SELECT fiyat FROM oda_fiyatlari WHERE yataksayi = @yatakSayisi";
            using (SQLiteCommand command = new SQLiteCommand(query, conn))
            {
                command.Parameters.AddWithValue("@yatakSayisi", yatakSayisi);

                object result = command.ExecuteScalar();
                return result != null ? Convert.ToDecimal(result) : 0;
            }
        }

        private decimal CalculateBorc(SQLiteConnection conn, string tc, decimal fiyat)
        {
            string query = "SELECT cikis FROM sure_tablosu WHERE TC = @tc";
            using (SQLiteCommand command = new SQLiteCommand(query, conn))
            {
                command.Parameters.AddWithValue("@tc", tc);

                object result = command.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                {
                    // Çıkış tarihi yoksa tam fiyatı döndür
                    return fiyat;
                }
                else
                {
                    // Çıkış tarihi varsa gün sayısını hesapla ve borcu döndür
                    DateTime cikisTarihi = Convert.ToDateTime(result);
                    int gunSayisi = (DateTime.Now - cikisTarihi).Days;
                    return gunSayisi * (fiyat / 30); // Günlük fiyat üzerinden hesaplama (30 gün varsayılan)
                }
            }
        }

        private void InsertOrUpdateOdemeBilgisi(SQLiteConnection conn, string tc, decimal borc)
        {
            // Girilen ay ve yıl bilgisine göre son ödeme tarihini hesapla
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;

            DateTime sonOdemeTarihi = new DateTime(year, month, DateTime.DaysInMonth(year, month));

            string query = @"
        INSERT INTO OdemeBilgileri (TC, Donem, ALINACAK, DURUM, ALINAN, KALAN, SONODEME) 
        VALUES (@tc, @donem, @alinacak, 0, 0, @alinacak, @sonOdeme)
        ON CONFLICT(TC, Donem) 
        DO UPDATE SET 
            ALINACAK = @alinacak,
            DURUM = 0,
            SONODEME = @sonOdeme";

            using (SQLiteCommand command = new SQLiteCommand(query, conn))
            {
                command.Parameters.AddWithValue("@tc", tc);
                command.Parameters.AddWithValue("@donem", $"{year}-{month:D2}");
                command.Parameters.AddWithValue("@alinacak", borc);
                command.Parameters.AddWithValue("@sonOdeme", sonOdemeTarihi.ToString("yyyy-MM-dd"));

                command.ExecuteNonQuery();
            }
        }


        private void OdemeBilgileri_Load(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
