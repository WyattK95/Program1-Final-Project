using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace FinalProject
{
    public partial class RailroadincidentForm : Form
    {
        private readonly int _entityId;      // Holds the companyId or railroadId.
        private readonly string _entityType; // Differentiates between "railroad" and "company".

        public RailroadincidentForm(int entityId, string entityType)
        {
            InitializeComponent();

            _entityId = entityId;
            _entityType = entityType;

            // Load incident data when the form is initialized.
            LoadIncidentData();
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

            try
            {
                DatabaseHelper.ExecuteReader(query, reader =>
                {
                    incidentsTable.Load(reader); // Fill DataTable with query result
                },
                command =>
                {
                    command.Parameters.AddWithValue("@EntityId", _entityId);
                });

                // Bind the loaded incidents to the DataGridView
                dataGridView1.DataSource = incidentsTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching incidents: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
