using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static databaseProject.Form1;
using static databaseProject.AileBilgileri;


namespace databaseProject
{
    public partial class OgrenciBilgileri : Form
    {
        private SQLiteConnection conn;  // SQLiteConnection formun bir üyesi olarak tanımlandı
        private SQLiteDataAdapter adap; // DataAdapter tanımlandı
        private DataSet ds;             // DataSet tanımlandı

        public OgrenciBilgileri()
        {
            InitializeComponent();
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
                string query = "SELECT * FROM ogrenciBilgileri " + lastFilter;

                //MessageBox.Show(query); hayat kurtarıcı
                // DataAdapter ve DataSet oluştur
                adap = new SQLiteDataAdapter(query, conn);
                ds = new DataSet();

                // Verileri DataSet'e yükle
                adap.Fill(ds, "ogrenciBilgileri");

                // DataGridView'i DataSet'e bağla
                dataGridView1.DataSource = ds.Tables["ogrenciBilgileri"];
            }
            catch (Exception ex)
            {
                // Hata durumunda mesaj göster
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }

        private void OgrenciBilgileri_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Yeni veya değiştirilen satırları kontrol edin
                DataTable changes = ds.Tables["ogrenciBilgileri"].GetChanges();
                if (changes != null)
                {
                    foreach (DataRow row in changes.Rows)
                    {
                        if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified)
                        {
                            string blok = row["BLOK"].ToString();
                            string oda = row["ODA"].ToString();

                            // Oda kontrolü
                            if (!CheckEmptyBeds(blok, oda))
                            {
                                MessageBox.Show($"Seçilen oda ({blok}-{oda}) dolu! Lütfen başka bir oda seçin.");
                                return;
                            }
                        }
                    }
                }

                // Eğer kontrol geçtiyse değişiklikleri kaydedin
                SQLiteCommandBuilder cmdb1 = new SQLiteCommandBuilder(adap);
                adap.Update(ds, "ogrenciBilgileri");

                // Başarı mesajı
                MessageBox.Show("Değişiklikler başarıyla kaydedildi!");
            }
            catch (Exception ex)
            {
                // Hata mesajı
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }
        private bool CheckEmptyBeds(string blok, string oda)
        {
            try
            {
                // SQL sorgusu ile boş yatak sayısını kontrol et
                string query = $"SELECT bosyatak FROM oda_durumu WHERE BLOK = @blok AND numara = @oda";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@blok", blok);
                cmd.Parameters.AddWithValue("@oda", oda);

                // Sorguyu çalıştır ve boş yatak sayısını al
                int bosYatak = Convert.ToInt32(cmd.ExecuteScalar());

                if (bosYatak > 0)
                {
                    // Eğer boş yatak varsa, yatak sayısını düşür
                    string updateQuery = $"UPDATE oda_durumu SET BosYatak = BosYatak - 1 WHERE BLOK = @blok AND numara = @oda";
                    SQLiteCommand updateCmd = new SQLiteCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@blok", blok);
                    updateCmd.Parameters.AddWithValue("@oda", oda);
                    updateCmd.ExecuteNonQuery();

                    return true; // İşlem başarılı
                }

                return false; // Boş yatak yok
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Oda kontrolünde hata: {ex.Message}");
                return false;
            }
        }

        private SQLiteConnection StartConnectionToDB()
        {
            string relativePath = "..\\..\\..\\..\\projectDB.db";
            string fullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
            string connectionString = $"Data Source={fullPath};Version=3;";
            return new SQLiteConnection(connectionString);
        }

        private void OgrenciBilgileri_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Form kapanırken bağlantıyı kapat
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        private void anaMenuBtn_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //FILTRELEME
            string filter = "";
            int count = 0;
            if (textBox1.Text.Length > 0)
                count++;
            if (textBox2.Text.Length > 0)
                count++;

            if (textBox3.Text.Length > 0)
                count++;

            if (textBox4.Text.Length > 0)
                count++;

            if (textBox5.Text.Length > 0)
                count++;



            if (textBox1.Text.Length > 0)
            {
                filter += $"TC like '{textBox1.Text}%' ";
                if (--count > 0)
                    filter += " AND ";

            }
            if (textBox2.Text.Length > 0)
            {
                filter += $"ADI = '{textBox2.Text}%' ";
                if (--count > 0)
                    filter += " AND ";

            }
            if (textBox3.Text.Length > 0)
            {

                filter += $"TELEFON like '{textBox3.Text}%' ";
                if (--count > 0)
                    filter += " AND ";
            }
            if (textBox4.Text.Length > 0)
            {

                filter += $"BLOK like '{textBox4.Text}%' ";
                if (--count > 0)
                    filter += " AND ";
            }
            if (textBox5.Text.Length > 0)
                filter += $"ODA like '{textBox5.Text}%' ";

            loadData(filter);

        }

        private void dataGridView1_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // AileBilgileri formunun bir nesnesini oluşturun
            AileBilgileri aileBilgileri = new AileBilgileri();

            // Tıklanan öğrencinin TC'sini (örneğin, DataGridView'den) al
            string tiklananOgrenciTC = dataGridView1.SelectedCells[0].Value.ToString(); // Örneğin, TC'yi alıyoruz

            aileBilgileri.setTC(tiklananOgrenciTC);

            // Formu aç
            aileBilgileri.Show();

            // Button4'ü tıklanmış gibi simüle et
            aileBilgileri.performFilter();
        }
    }
}