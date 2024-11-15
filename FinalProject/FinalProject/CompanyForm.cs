using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;

namespace FinalProject
{
    public partial class CompanyForm : Form
    {

        private readonly string _connectionString;
        public CompanyForm()
        {
            InitializeComponent();
            _connectionString = Program.Configuration.GetConnectionString("DefaultConnection");
            dataGridViewCompanies.AutoGenerateColumns = false;

            // Define and add columns manually
            dataGridViewCompanies.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "CompanyID",
                DataPropertyName = "company_id", // This should match the column name from your database
                HeaderText = "Company ID",
                
            });
            dataGridViewCompanies.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "CompanyName",
                DataPropertyName = "company_name", // This should match the column name from your database
                HeaderText = "Company Name"
            });
            dataGridViewCompanies.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "OrgType",
                DataPropertyName = "org_type", // This should match the column name from your database
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

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.Fill(companiesTable); // Fill DataTable with query result
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while fetching data: " + ex.Message);
                }
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
                RailroadincidentForm RailroadincidentForm = new RailroadincidentForm(companyId, "company");
                RailroadincidentForm.ShowDialog();
            }
        }


        private void dataGridViewCompanies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Placeholder for any specific cell click logic if needed
        }

        private void dataGridViewCompanies_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
