using System;
using System.Data;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class CompanyForm : Form
    {
        public CompanyForm()
        {
            InitializeComponent();

            dataGridViewCompanies.AutoGenerateColumns = false;

            // Define and add columns manually
            dataGridViewCompanies.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "CompanyID",
                DataPropertyName = "company_id", 
                HeaderText = "Company ID",
            });
            dataGridViewCompanies.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "CompanyName",
                DataPropertyName = "company_name", 
                HeaderText = "Company Name"
            });
            dataGridViewCompanies.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "OrgType",
                DataPropertyName = "org_type", 
                HeaderText = "Organization Type"
            });

            LoadCompanyData();
            dataGridViewCompanies.CellDoubleClick += DataGridViewCompanies_CellDoubleClick;
        }

        private void LoadCompanyData()
        {
            // Retrieve and load data from the database
            DataTable companies = GetCompanies();
            dataGridViewCompanies.DataSource = companies;
        }

        private DataTable GetCompanies()
        {
            // SQL query to select data from the Companies table
            string query = "SELECT company_id, company_name, org_type FROM dbo.company";

            DataTable companiesTable = new DataTable();

            try
            {
                DatabaseHelper.ExecuteReader(query, reader =>
                {
                    companiesTable.Load(reader); // Fill DataTable with query result
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching data: " + ex.Message);
            }

            return companiesTable;
        }

        private void DataGridViewCompanies_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is double-clicked
            {
                // Get the company_id from the selected row
                int companyId = (int)dataGridViewCompanies.Rows[e.RowIndex].Cells["CompanyID"].Value;

                // Open the RailroadincidentForm for the selected company
                RailroadincidentForm railroadIncidentForm = new RailroadincidentForm(companyId, "company");
                railroadIncidentForm.ShowDialog();
            }
        }

        private void dataGridViewCompanies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
