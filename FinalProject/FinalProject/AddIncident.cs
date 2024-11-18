using System;
using System.Data;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class AddIncident : Form
    {
        public AddIncident()
        {
            InitializeComponent();
        }

        private void InsertIncident()
        {
            // Initialize values from the form fields
            DateTime receiveTime = dataTimeReceived.Value;
            DateTime? completeTime = dataTimeComplete.Value;
            string responsibleCity = resposibleCity.Text;
            string responsibleState = resposibleStates.Text;
            string responsibleZip = resposibleZip.Text;
            string description = descriptionOfIncident.Text;
            string type = typeIncident.Text;
            string incidentCause = IncidentCase.Text;
            string callType = "INC";  // Default call type value

            int injuryCountValue = (int)InjuryCount.Value;
            int hospitalizationCountValue = (int)hospitalizationCount.Value;
            int fatalityCountValue = (int)fatalityCount.Value;

            // Inputs for names instead of IDs
            string companyName = companyNameInput.Text; 
            string railroadName = railroadNameInput.Text; 

            try
            {
                int companyId = GetOrInsertCompanyId(companyName);
                int? railroadId = string.IsNullOrWhiteSpace(railroadName)
                    ? null
                    : (int?)GetOrInsertRailroadId(railroadName);

                // Get the last seqnos value for incrementing
                string seqnosQuery = "SELECT ISNULL(MAX(seqnos), 0) + 1 FROM incident";
                int newSeqnos = DatabaseHelper.ExecuteScalar<int>(seqnosQuery);

                // SQL insert query without the incident_train_id
                string insertQuery = @"
                    INSERT INTO incident 
                    (seqnos, date_time_received, date_time_complete, call_type, responsible_city, responsible_state, responsible_zip, 
                    description_of_incident, type_of_incident, incident_cause, injury_count, hospitalization_count, fatality_count, 
                    company_id, railroad_id) 
                    VALUES (@Seqnos, @ReceiveTime, @CompleteTime, @CallType, @City, @State, @Zip, @Description, @Type, @Cause, 
                    @Injuries, @Hospitalizations, @Fatalities, @CompanyId, @RailroadId)";

                DatabaseHelper.ExecuteNonQuery(insertQuery, command =>
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@Seqnos", newSeqnos);
                    command.Parameters.AddWithValue("@ReceiveTime", receiveTime);
                    command.Parameters.AddWithValue("@CompleteTime", completeTime ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CallType", callType);
                    command.Parameters.AddWithValue("@City", responsibleCity);
                    command.Parameters.AddWithValue("@State", responsibleState);
                    command.Parameters.AddWithValue("@Zip", responsibleZip);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@Type", type);
                    command.Parameters.AddWithValue("@Cause", incidentCause);
                    command.Parameters.AddWithValue("@Injuries", injuryCountValue);
                    command.Parameters.AddWithValue("@Hospitalizations", hospitalizationCountValue);
                    command.Parameters.AddWithValue("@Fatalities", fatalityCountValue);
                    command.Parameters.AddWithValue("@CompanyId", companyId);
                    command.Parameters.AddWithValue("@RailroadId", railroadId ?? (object)DBNull.Value);
                });

                MessageBox.Show("Incident added successfully with Seqnos: " + newSeqnos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private int GetOrInsertCompanyId(string companyName)
        {
            // Check if company exists
            string selectQuery = "SELECT company_id FROM company WHERE company_name = @CompanyName";
            object existingCompanyId = DatabaseHelper.ExecuteScalar<object>(selectQuery, command =>
            {
                command.Parameters.AddWithValue("@CompanyName", companyName);
            });

            if (existingCompanyId != null && existingCompanyId != DBNull.Value)
            {
                return Convert.ToInt32(existingCompanyId);
            }

            // Insert new company
            string insertQuery = "INSERT INTO company (company_name, org_type) OUTPUT INSERTED.company_id VALUES (@CompanyName, 'Unknown')";
            int newCompanyId = DatabaseHelper.ExecuteScalar<int>(insertQuery, command =>
            {
                command.Parameters.AddWithValue("@CompanyName", companyName);
            });

            return newCompanyId;
        }

        private int GetOrInsertRailroadId(string railroadName)
        {
            // Check if railroad exists
            string selectQuery = "SELECT railroad_id FROM railroad WHERE railroad_name = @RailroadName";
            object existingRailroadId = DatabaseHelper.ExecuteScalar<object>(selectQuery, command =>
            {
                command.Parameters.AddWithValue("@RailroadName", railroadName);
            });

            if (existingRailroadId != null && existingRailroadId != DBNull.Value)
            {
                return Convert.ToInt32(existingRailroadId);
            }

            // Insert new railroad
            string insertQuery = "INSERT INTO railroad (railroad_name) OUTPUT INSERTED.railroad_id VALUES (@RailroadName)";
            int newRailroadId = DatabaseHelper.ExecuteScalar<int>(insertQuery, command =>
            {
                command.Parameters.AddWithValue("@RailroadName", railroadName);
            });

            return newRailroadId;
        }

        private void InsertButton_Click_1(object sender, EventArgs e)
        {
            InsertIncident();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // Clear form fields
            dataTimeReceived.Value = DateTime.Now;
            dataTimeComplete.Value = DateTime.Now;
            resposibleCity.Clear();
            resposibleStates.Clear();
            resposibleZip.Clear();
            descriptionOfIncident.Clear();
            typeIncident.Clear();
            IncidentCase.Clear();
            InjuryCount.Value = 0;
            hospitalizationCount.Value = 0;
            fatalityCount.Value = 0;
            companyNameInput.Clear();
            railroadNameInput.Clear();
        }
    }
}
