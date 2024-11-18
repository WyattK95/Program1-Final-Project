using System;
using System.Data;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class RailroadForm : Form
    {
        public RailroadForm()
        {
            InitializeComponent();

            // Set AutoGenerateColumns to false to manually define columns
            dataGridViewRailroads.AutoGenerateColumns = false;

            // Define and add columns manually
            dataGridViewRailroads.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "RailroadID",
                DataPropertyName = "railroad_id", 
                HeaderText = "Railroad ID",
            });
            dataGridViewRailroads.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "RailroadName",
                DataPropertyName = "railroad_name",
                HeaderText = "Railroad Name"
            });

            // Load data into the DataGridView
            LoadRailroadData();

            // Set up event handler for double-click
            dataGridViewRailroads.CellDoubleClick += DataGridViewRailroads_CellDoubleClick;
        }

        private void LoadRailroadData()
        {
            // Retrieve and load data from the database
            DataTable railroads = GetRailroads();
            dataGridViewRailroads.DataSource = railroads;
        }

        private DataTable GetRailroads()
        {
            string query = "SELECT railroad_id, railroad_name FROM dbo.railroad"; 
            DataTable railroadsTable = new DataTable();

            try
            {
                DatabaseHelper.ExecuteReader(query, reader =>
                {
                    railroadsTable.Load(reader); // Fill DataTable with query result
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching data: " + ex.Message);
            }

            return railroadsTable;
        }

        private void DataGridViewRailroads_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the railroad_id from the selected row's "RailroadID" column
                int railroadId = (int)dataGridViewRailroads.Rows[e.RowIndex].Cells["RailroadID"].Value;

                // Create and show the RailroadincidentForm with the selected railroadId and entity type "railroad"
                using (var railroadincidentForm = new RailroadincidentForm(railroadId, "railroad"))
                {
                    // Show the RailroadincidentForm as a modal dialog
                    railroadincidentForm.ShowDialog();
                }
            }
        }
    }
}
