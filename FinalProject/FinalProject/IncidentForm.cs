using System;
using System.Data;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class IncidentForm : Form
    {
        private AddIncident AddIncident;

        public IncidentForm()
        {
            InitializeComponent();
            LoadData();

            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
        }

        private void LoadData()
        {
            try
            {
                string query = @"
                    SELECT 
                        seqnos AS Seqnos, 
                        date_time_received AS DataTimeReceived, 
                        call_type AS CallType, 
                        responsible_state AS ResponsibleState, 
                        type_of_incident AS TypeOfIncident 
                    FROM incident;";

                DataTable dataTable = new DataTable();

                DatabaseHelper.ExecuteReader(query, reader =>
                {
                    dataTable.Load(reader);
                    dataGridView1.DataSource = dataTable;
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Ensure the double-clicked row index is valid
                if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
                {
                    // Attempt to retrieve the "Seqnos" value from the selected row
                    var cellValue = dataGridView1.Rows[e.RowIndex].Cells["Seqnos"].Value;

                    if (cellValue != null && int.TryParse(cellValue.ToString(), out int seqnos))
                    {
                        // Open the IncidentDetailsForm with the selected seqnos
                        using (var detailsForm = new IncidentDetailsForm(seqnos))
                        {
                            detailsForm.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Seqnos value. Please check the data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any unexpected exceptions gracefully
                MessageBox.Show("An error occurred while opening incident details:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text;
            try
            {
                string query = @"
                    SELECT 
                        seqnos AS Seqnos, 
                        date_time_received AS DataTimeReceived, 
                        call_type AS CallType, 
                        responsible_state AS ResponsibleState, 
                        type_of_incident AS TypeOfIncident 
                    FROM incident 
                    WHERE responsible_state LIKE @State OR seqnos LIKE @State;";

                DataTable dataTable = new DataTable();

                DatabaseHelper.ExecuteReader(query, reader =>
                {
                    dataTable.Load(reader);
                    dataGridView1.DataSource = dataTable;
                }, command =>
                {
                    command.Parameters.AddWithValue("@State", $"%{searchText}%");
                });
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
