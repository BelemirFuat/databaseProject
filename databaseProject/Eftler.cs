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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace databaseProject
{
    public partial class Eftler : Form
    {
        private SQLiteConnection conn;  // SQLiteConnection formun bir üyesi olarak tanımlandı
        private SQLiteDataAdapter adap; // DataAdapter tanımlandı
        private DataSet ds;
        public Eftler()
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
                string query = "SELECT * FROM eftler " + lastFilter;

                //MessageBox.Show(query); hayat kurtarıcı
                // DataAdapter ve DataSet oluştur
                adap = new SQLiteDataAdapter(query, conn);
                ds = new DataSet();

                // Verileri DataSet'e yükle
                adap.Fill(ds, "eftler");

                // DataGridView'i DataSet'e bağla
                dataGridView1.DataSource = ds.Tables["eftler"];
            }
            catch (Exception ex)
            {
                // Hata durumunda mesaj göster
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }
        private void anaMenuBtn_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Eftler_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private SQLiteConnection StartConnectionToDB()
        {
            string relativePath = "..\\..\\..\\..\\projectDB.db";
            string fullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
            string connectionString = $"Data Source={fullPath};Version=3;";
            return new SQLiteConnection(connectionString);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string filter = "";

            filter += $"ACIKLAMA like '{textBox5.Text}%' ";

            loadData(filter);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Yeni veya değiştirilen satırları kontrol edin
                DataTable changes = ds.Tables["eftler"].GetChanges();
                if (changes != null)
                {
                    foreach (DataRow row in changes.Rows)
                    {
                        if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified)
                        {
                            string blok = row["ACIKLAMA"].ToString();
                            string oda = row["MIKTAR"].ToString();
                        }
                    }
                }

                // Eğer kontrol geçtiyse değişiklikleri kaydedin
                SQLiteCommandBuilder cmdb1 = new SQLiteCommandBuilder(adap);
                adap.Update(ds, "eftler");

                // Başarı mesajı
                MessageBox.Show("Değişiklikler başarıyla kaydedildi!");
            }
            catch (Exception ex)
            {
                // Hata mesajı
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
