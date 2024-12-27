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
using static databaseProject.Form1;

namespace databaseProject
{
    public partial class odalar : Form
    {
        public odalar()
        {
            InitializeComponent();
        }
        private void odalar_Load(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = StartConnectionToDB())
            {
                try
                {
                    // Open the connection
                    conn.Open();

                    // Define the SQL query to get all room data
                    string query = $"SELECT * FROM oda_durumu";

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

                    // Get doluluk oranları için SQL sorguları
                    string queryBlokA = $"SELECT COUNT(*) AS Total, SUM(CASE WHEN bosyatak = 0 THEN 1 ELSE 0 END) AS Dolu FROM oda_durumu WHERE blok = 'A'";
                    string queryBlokB = $"SELECT COUNT(*) AS Total, SUM(CASE WHEN bosyatak = 0 THEN 1 ELSE 0 END) AS Dolu FROM oda_durumu WHERE blok = 'B'";

                    // Blok A doluluk oranı
                    using (SQLiteCommand commandA = new SQLiteCommand(queryBlokA, conn))
                    {
                        using (SQLiteDataReader reader = commandA.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int totalRooms = Convert.ToInt32(reader["Total"]);
                                int occupiedRooms = Convert.ToInt32(reader["Dolu"]);
                                double occupancyRate = (totalRooms == 0) ? 0 : (double)occupiedRooms / totalRooms * 100;
                                labelBlokA.Text = $"Blok A Doluluk: {occupancyRate:F2}% ({occupiedRooms}/{totalRooms})";
                            }
                        }
                    }

                    // Blok B doluluk oranı
                    using (SQLiteCommand commandB = new SQLiteCommand(queryBlokB, conn))
                    {
                        using (SQLiteDataReader reader = commandB.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int totalRooms = Convert.ToInt32(reader["Total"]);
                                int occupiedRooms = Convert.ToInt32(reader["Dolu"]);
                                double occupancyRate = (totalRooms == 0) ? 0 : (double)occupiedRooms / totalRooms * 100;
                                labelBlokB.Text = $"Blok B Doluluk: {occupancyRate:F2}% ({occupiedRooms}/{totalRooms})";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions and display the error message
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }


        private void anaMenuBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
