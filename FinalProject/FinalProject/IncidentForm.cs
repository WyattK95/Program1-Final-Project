using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class IncidentForm : Form
    {
        private readonly string _connectionString;
        private AddIncident AddIncident;
        public IncidentForm()
        {
            InitializeComponent();
            _connectionString = Program.Configuration.GetConnectionString("DefaultConnection");
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT seqnos AS Seqnos, date_time_received AS DataTimeReceived, call_type AS CallType, responsible_state AS ResponsibleState, type_of_incident AS TypeOfIncident from incident;";
                    using (var command = new SqlCommand(query, connection))
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            dataGridView1.DataSource = dataTable;
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred" + ex.Message);
            }

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void searchButton_Click(object sender, EventArgs e)
        {

            string searchText = textBox1.Text;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT seqnos AS Seqnos, date_time_received AS DataTimeReceived, call_type AS CallType, responsible_state AS ResponsibleState, type_of_incident AS TypeOfIncident FROM incident WHERE responsible_state LIKE @State OR seqnos LIKE @State;";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@State", $"%{searchText}");
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                    //Console.WriteLine(adapter.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddIncident = new AddIncident();
            AddIncident.FormClosed += (s, args) => this.Show();
            AddIncident.Show();
        }
    }
}
