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
    public partial class Fiyatlar : Form
    {
        public Fiyatlar()
        {
            InitializeComponent();
        }

        private void anaMenuBtn_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Fiyatlar_Load(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = StartConnectionToDB())
            {
                try
                {
                    // Open the connection
                    conn.Open();
                    // Define the SQL query
                    string query = $"SELECT * FROM oda_fiyatlari";

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
    }
}
