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
    public partial class RailroadincidentForm : Form
    {
        private readonly int _entityId;         // This will hold the companyId or railroadId.
        private readonly string _entityType;    // This will differentiate between "railroad" and "company".
        private readonly string _connectionString;

        public RailroadincidentForm(int entityId, string entityType)
        {
            InitializeComponent();

            _entityId = entityId;
            _entityType = entityType;
            _connectionString = Program.Configuration.GetConnectionString("DefaultConnection");

            // Load incident data when the form is initialized.
            LoadIncidentData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadIncidentData()
        {
            string query = "SELECT * FROM dbo.incident WHERE ";

            // Modify query based on entity type (railroad or company)
            if (_entityType == "railroad")
            {
                query += "railroad_id = @EntityId"; // Filter by railroad_id
            }
            else if (_entityType == "company")
            {
                query += "company_id = @EntityId";  // Filter by company_id
            }
            else
            {
                MessageBox.Show("Unknown entity type: " + _entityType);
                return;
            }

            DataTable incidentsTable = new DataTable();

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EntityId", _entityId);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(incidentsTable); // Fill DataTable with query result
                        }
                    }

                    // Bind the loaded incidents to a DataGridView
                    dataGridView1.DataSource = incidentsTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while fetching incidents: " + ex.Message);
                }
            }
        }
    }
}
