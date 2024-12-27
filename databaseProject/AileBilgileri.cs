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
using static databaseProject.Form1;


namespace databaseProject
{
    public partial class AileBilgileri : Form
    {
        private SQLiteConnection conn;  // SQLiteConnection formun bir üyesi olarak tanımlandı
        private SQLiteDataAdapter adap; // DataAdapter tanımlandı
        private DataSet ds;

        public AileBilgileri()
        {
            InitializeComponent();
        }

        private void anaMenuBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AileBilgileri_Load(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = StartConnectionToDB())
            {
                try
                {
                    // Bağlantıyı aç
                    conn.Open();

                    // SQL sorgusu: aile_bilgileri ile ogrenciBilgileri tablosunu birleştir ve öğrenci adını getir
                    string query = @"
                                    SELECT 
                                        aile_bilgileri.*,
                                        ogrenciBilgileri.ADI AS OgrenciAdi
                                    FROM 
                                        aile_bilgileri
                                    LEFT JOIN 
                                        ogrenciBilgileri
                                    ON 
                                        aile_bilgileri.TC = ogrenciBilgileri.TC";

                    // Sorgu sonuçlarını tutmak için DataTable oluştur
                    DataTable dataTable = new DataTable();

                    // SQLiteCommand ve SQLiteDataAdapter ile sorguyu çalıştır
                    using (SQLiteCommand command = new SQLiteCommand(query, conn))
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        // Sorgu sonuçlarını DataTable'a doldur
                        adapter.Fill(dataTable);
                    }

                    // DataGridView'e bağla
                    dataGridView1.DataSource = dataTable;

                    // Kullanıcı dostu kolon adları ayarlanabilir
                    dataGridView1.Columns["OgrenciAdi"].HeaderText = "Öğrenci Adı";
                }
                catch (Exception ex)
                {
                    // Hata durumunda mesaj göster
                    MessageBox.Show($"Hata: {ex.Message}");
                }
            }

        }
        public void setTC(string tc)
        {
            textBox1.Text = tc;
        }
        public void performFilter()
        {
            button4.PerformClick();
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

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
            if (textBox6.Text.Length > 0)
                count++;


            if (textBox1.Text.Length > 0)
            {
                filter += $"TC like '{textBox1.Text}%' ";
                if (--count > 0)
                    filter += " AND ";

            }
            if (textBox2.Text.Length > 0)
            {
                filter += $"ANNEAD = '{textBox2.Text}%' ";
                if (--count > 0)
                    filter += " AND ";

            }
            if (textBox3.Text.Length > 0)
            {

                filter += $"ANNETELEFON like '{textBox3.Text}%' ";
                if (--count > 0)
                    filter += " AND ";
            }
            if (textBox4.Text.Length > 0)
            {

                filter += $"BABATELEFON like '{textBox4.Text}%' ";
                if (--count > 0)
                    filter += " AND ";
            }
            if (textBox5.Text.Length > 0)
            {

                filter += $"ADRES like '{textBox5.Text}%' ";
                if (--count > 0)
                    filter += " AND ";
            }
            if (textBox6.Text.Length > 0)
            {

                filter += $"BABAAD like '{textBox6.Text}%' ";
                if (--count > 0)
                    filter += " AND ";
            }
            


            loadData(filter);

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
                string query = "SELECT * FROM aile_bilgileri " + lastFilter;

                //MessageBox.Show(query); hayat kurtarıcı
                // DataAdapter ve DataSet oluştur
                adap = new SQLiteDataAdapter(query, conn);
                ds = new DataSet();

                // Verileri DataSet'e yükle
                adap.Fill(ds, "aile_bilgileri");

                // DataGridView'i DataSet'e bağla
                dataGridView1.DataSource = ds.Tables["aile_bilgileri"];
            }
            catch (Exception ex)
            {
                // Hata durumunda mesaj göster
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Yeni veya değiştirilen satırları kontrol edin
                DataTable changes = ds.Tables["aile_bilgileri"].GetChanges();


                // Eğer kontrol geçtiyse değişiklikleri kaydedin
                SQLiteCommandBuilder cmdb1 = new SQLiteCommandBuilder(adap);
                adap.Update(ds, "aile_bilgileri");

                // Başarı mesajı
                MessageBox.Show("Değişiklikler başarıyla kaydedildi!");
            }
            catch (Exception ex)
            {
                // Hata mesajı
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Seçili hücreleri kontrol edin
            if (dataGridView1.SelectedCells.Count > 0)
            {
                // SMS mesajını almak için kullanıcıdan girdi alın
                string mesaj = Microsoft.VisualBasic.Interaction.InputBox(
                    "Göndermek istediğiniz mesajı girin:",
                    "SMS Gönder",
                    "Varsayılan mesaj içeriği"
                );

                if (string.IsNullOrEmpty(mesaj))
                {
                    MessageBox.Show("Mesaj boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // İşlenecek telefon numaralarını saklamak için bir liste oluşturun
                HashSet<string> telefonNumaralari = new HashSet<string>();

                // Seçili hücreler üzerinden geçiş yap
                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {
                    if ((cell.OwningColumn.Name == "ANNETELEFON" ||cell.OwningColumn.Name == "BABATELEFON") && (cell.Value != null)) // Sadece "TELEFON" sütunundaki hücreler işlenir
                    {
                        string telefon = cell.Value.ToString();
                        telefonNumaralari.Add(telefon); // Aynı numarayı birden fazla kez eklememek için HashSet kullanıldı
                    }
                }

                if (telefonNumaralari.Count > 0)
                {
                    // SMS gönderim işlemini simüle et (örneğin, konsola yazdır)
                    foreach (string telefon in telefonNumaralari)
                    {
                        Console.WriteLine($"Telefon: {telefon}, Mesaj: {mesaj}");
                    }

                    // Başarılı işlem sonrası mesaj göster
                    MessageBox.Show("Seçili kişilere SMS gönderildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Eğer geçerli bir telefon numarası bulunamadıysa kullanıcıyı bilgilendir
                    MessageBox.Show("Seçili hücrelerde geçerli bir telefon numarası bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // Eğer hiçbir hücre seçilmediyse kullanıcıyı bilgilendir
                MessageBox.Show("Lütfen SMS göndermek için bir hücre seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        
    }
}
