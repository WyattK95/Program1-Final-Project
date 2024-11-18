using System;
using System.Data;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class IncidentDetailsForm : Form
    {
        private readonly int _seqnos;

        public IncidentDetailsForm(int seqnos)
        {
            InitializeComponent();
            _seqnos = seqnos;

            // Load incident details when the form is initialized.
            LoadIncidentDetails();
        }

        private void LoadIncidentDetails()
        {
            try
            {
                string query = @"
            SELECT 
                i.seqnos AS Seqnos, 
                i.date_time_received AS DateTimeReceived, 
                i.date_time_complete AS DateTimeComplete, 
                i.call_type AS CallType, 
                i.responsible_city AS ResponsibleCity, 
                i.responsible_state AS ResponsibleState, 
                i.responsible_zip AS ResponsibleZip, 
                i.description_of_incident AS DescriptionOfIncident, 
                i.type_of_incident AS TypeOfIncident, 
                i.incident_cause AS IncidentCause, 
                i.injury_count AS InjuryCount, 
                i.hospitalization_count AS HospitalizationCount, 
                i.fatality_count AS FatalityCount, 
                c.company_name AS CompanyName, 
                r.railroad_name AS RailroadName 
            FROM 
                incident i
            LEFT JOIN 
                company c ON i.company_id = c.company_id
            LEFT JOIN 
                railroad r ON i.railroad_id = r.railroad_id
            WHERE 
                i.seqnos = @Seqnos";

                DataTable incidentTable = new DataTable();

                DatabaseHelper.ExecuteReader(query, reader =>
                {
                    incidentTable.Load(reader);
                }, command =>
                {
                    command.Parameters.AddWithValue("@Seqnos", _seqnos);
                });

                if (incidentTable.Rows.Count > 0)
                {
                    DataRow row = incidentTable.Rows[0];
                    seqnosTextBox.Text = row["Seqnos"]?.ToString() ?? "N/A";
                    dateTimeReceivedTextBox.Text = row["DateTimeReceived"]?.ToString() ?? "N/A";
                    dateTimeCompleteTextBox.Text = row["DateTimeComplete"]?.ToString() ?? "N/A";
                    callTypeTextBox.Text = row["CallType"]?.ToString() ?? "N/A";
                    responsibleCityTextBox.Text = row["ResponsibleCity"]?.ToString() ?? "N/A";
                    responsibleStateTextBox.Text = row["ResponsibleState"]?.ToString() ?? "N/A";
                    responsibleZipTextBox.Text = row["ResponsibleZip"]?.ToString() ?? "N/A";
                    descriptionTextBox.Text = row["DescriptionOfIncident"]?.ToString() ?? "N/A";
                    typeOfIncidentTextBox.Text = row["TypeOfIncident"]?.ToString() ?? "N/A";
                    incidentCauseTextBox.Text = row["IncidentCause"]?.ToString() ?? "N/A";
                    injuryCountTextBox.Text = row["InjuryCount"]?.ToString() ?? "0";
                    hospitalizationCountTextBox.Text = row["HospitalizationCount"]?.ToString() ?? "0";
                    fatalityCountTextBox.Text = row["FatalityCount"]?.ToString() ?? "0";
                    companyIdTextBox.Text = row["CompanyName"]?.ToString() ?? "N/A";
                    railroadIdTextBox.Text = row["RailroadName"]?.ToString() ?? "N/A";
                }
                else
                {
                    MessageBox.Show("Incident not found. Please check the Seqnos value.", "No Data Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
