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
using OfficeOpenXml;

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
                    try
                    {

                        conn.Open();
                        OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                        // 1. Excel dosyasına yedek alma
                        string backupFileName = $"{DateTime.Now.Year}-{DateTime.Now.Month} Donemi Giriş Çıkış ve Eftler.xlsx";
                        string backupFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\", backupFileName);


                        using (var package = new OfficeOpenXml.ExcelPackage())
                        {
                            // sure_tablosu yedeği
                            string sureQuery = "SELECT * FROM sure_tablosu";
                            var sureTable = new DataTable();
                            using (var adapter = new SQLiteDataAdapter(sureQuery, conn))
                            {
                                adapter.Fill(sureTable);
                            }
                            var sureSheet = package.Workbook.Worksheets.Add("sure_tablosu");
                            sureSheet.Cells["A1"].LoadFromDataTable(sureTable, true);

                            // eftler yedeği
                            string eftlerQuery = "SELECT * FROM eftler";
                            var eftlerTable = new DataTable();
                            using (var adapter = new SQLiteDataAdapter(eftlerQuery, conn))
                            {
                                adapter.Fill(eftlerTable);
                            }
                            var eftlerSheet = package.Workbook.Worksheets.Add("eftler");
                            eftlerSheet.Cells["A1"].LoadFromDataTable(eftlerTable, true);

                            package.SaveAs(new FileInfo(backupFilePath));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Excel tablosuna kayıtta sorun {ex}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }

                    // 2. Yeni öğrencileri sure_tablosu'na ekleme
                    string newStudentsQuery = "SELECT TC, date('now') as giris FROM ogrenciBilgileri WHERE TC NOT IN (SELECT TC FROM sure_tablosu)";
                    using (SQLiteCommand cmd = new SQLiteCommand(newStudentsQuery, conn))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tc = reader["TC"].ToString();
                            string giris = reader["giris"].ToString();
                            string insertQuery = "INSERT INTO sure_tablosu (TC, giris, cikis) VALUES (@tc, @giris, NULL)";
                            using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@tc", tc);
                                insertCmd.Parameters.AddWithValue("@giris", giris);
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    // 3. yeni öğrencileri ödeme bilgileri tablosuna ekleme
                    newStudentsQuery = @"SELECT TC FROM ogrenciBilgileri WHERE TC NOT IN (SELECT TC FROM odemeBilgileri)";
                    using (SQLiteCommand cmd = new SQLiteCommand(newStudentsQuery, conn))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tc = reader["TC"].ToString();
                            string insertQuery = @"INSERT INTO odemeBilgileri (TC, ALINACAK, ALINAN, KALAN, SONODEME, DURUM, DONEM)
                               VALUES (@tc, 0, 0, 0, 0, 0, 1)";
                            using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@tc", tc);
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    // 4. Ödeme bilgilerini güncelleme
                    // Ödeme bilgilerini güncelleme
                    string updatePaymentsQuery = @"SELECT odemeBilgileri.TC, ogrenciBilgileri.ODA, ogrenciBilgileri.BLOK, oda_durumu.yataksayi, oda_fiyatlari.fiyat,
                        CASE WHEN sure_tablosu.cikis IS NULL THEN oda_fiyatlari.fiyat
                             ELSE (CAST(strftime('%d', sure_tablosu.cikis) AS INT) / 30.0) * oda_fiyatlari.fiyat END AS yeniFiyat
                        FROM odemeBilgileri
                        JOIN ogrenciBilgileri ON odemeBilgileri.TC = ogrenciBilgileri.TC
                        JOIN oda_durumu ON ogrenciBilgileri.BLOK = oda_durumu.blok AND ogrenciBilgileri.ODA = oda_durumu.numara
                        JOIN oda_fiyatlari ON oda_durumu.yataksayi = oda_fiyatlari.yataksayi
                        LEFT JOIN sure_tablosu ON odemeBilgileri.TC = sure_tablosu.TC";
                    using (SQLiteCommand cmd = new SQLiteCommand(updatePaymentsQuery, conn))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tc = reader["TC"].ToString();
                            int yeniFiyat = Convert.ToInt32(reader["yeniFiyat"]);

                            // Mevcut KALAN değeri sorgulama
                            string selectCurrentPaymentQuery = "SELECT KALAN FROM odemeBilgileri WHERE TC = @tc";
                            using (SQLiteCommand selectCmd = new SQLiteCommand(selectCurrentPaymentQuery, conn))
                            {
                                selectCmd.Parameters.AddWithValue("@tc", tc);
                                using (SQLiteDataReader paymentReader = selectCmd.ExecuteReader())
                                {
                                    if (paymentReader.Read())
                                    {
                                        int kalan = paymentReader.GetInt32(0); // Önceki KALAN değeri

                                        // Yeni KALAN değeri = Eski KALAN + Yeni ALINACAK değeri
                                        int yeniKalan = kalan + yeniFiyat;

                                        // Ödeme bilgilerini güncelleme
                                        string updateQuery = @"UPDATE odemeBilgileri SET 
                                          ALINACAK = @alinacak,
                                          ALINAN = 0,
                                          KALAN = @kalan,
                                          SONODEME = @sonOdeme,
                                          DURUM = 0,
                                          DONEM = CASE WHEN DONEM = 12 THEN 1 ELSE DONEM + 1 END
                                          WHERE TC = @tc";
                                        DateTime sonOdeme = DateTime.Now.Month == 12
                                            ? new DateTime(DateTime.Now.Year + 1, 1, 1)  // Eğer Aralık ayında isek, Ocak ayının 1. günü
                                            : new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1);  // Diğer aylar için ayın 1. günü

                                        using (SQLiteCommand updateCmd = new SQLiteCommand(updateQuery, conn))
                                        {
                                            updateCmd.Parameters.AddWithValue("@alinacak", yeniFiyat);
                                            updateCmd.Parameters.AddWithValue("@kalan", yeniKalan); // Kalan değeri güncelleniyor
                                            updateCmd.Parameters.AddWithValue("@sonOdeme", sonOdeme); // Son ödeme tarihini ekliyoruz
                                            updateCmd.Parameters.AddWithValue("@tc", tc);
                                            updateCmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                        }
                    }

                    MessageBox.Show("Yeni döneme geçiş başarıyla tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        

        private void OdemeBilgileri_Load(object sender, EventArgs e)
        {
            loadData();
        }

    }
}
