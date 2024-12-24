using System.Data;
using System.Data.SQLite;

namespace databaseProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static public SQLiteConnection StartConnectionToDB()
        {
            // Define the relative path to the database file
            string relativePath = "..\\..\\..\\..\\projectDB.db";

            // Convert the relative path to an absolute path
            string fullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

            // Create the connection string
            string connectionString = $"Data Source={fullPath};Version=3;";

            // Initialize the SQLite connection
            SQLiteConnection connection = new SQLiteConnection(connectionString);

            return connection;
        }

        private string tabloIsimDondur(string text)
        {
            //Aile Bilgileri
            //Odalar
            //Süre
            //Fiyat
            //Ödemeler
            //Eftler
            //Öğrenciler
            if (text == "Aile Bilgileri")
                return "aile_bilgileri";
            else if (text == "Eftler")
                return "eftler";
            else if (text == "Odalar")
                return "oda_fiyatlari";
            else if (text == "Ödemeler")
                return "odemeBilgileri";
            else if (text == "Öğrenciler")
                return "ogrenciBilgileri";
            else if (text == "Süre")
                return "sure_tablosu";
            else if (text == "Fiyat")
                return "fiyat";
            else
                throw new ArgumentException("Geçersiz tablo adı: " + text);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = StartConnectionToDB())
            {
                try
                {
                    // Open the connection
                    conn.Open();
                    // Define the SQL query
                    string query = $"SELECT {textBox1.Text} FROM {tabloIsimDondur(comboBox1.SelectedItem.ToString())}";

                    // Create a DataTable to store the query results
                    DataTable dataTable = new DataTable();

                    // Execute the query and load the results into the DataTable
                    using (SQLiteCommand command = new SQLiteCommand(query, conn))
                    {
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }

                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    // Handle exceptions and display the error message
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
        // öğrenci tablosu
        // aile tablosu
        // odalar tablosu
        // ödeme tablosu
    }
}
