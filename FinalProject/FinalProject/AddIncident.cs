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
    public partial class AddIncident : Form
    {
        private readonly string _connectionString;
        public AddIncident()
        {
            InitializeComponent();
            _connectionString = Program.Configuration.GetConnectionString("DefaultConnection");
        }



        private void dataTimeReceived_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataTimeComplete_ValueChanged(object sender, EventArgs e)
        {

        }

        private void resposibleCity_TextChanged(object sender, EventArgs e)
        {

        }

        private void resposibleStates_TextChanged(object sender, EventArgs e)
        {

        }

        private void resposibleZip_TextChanged(object sender, EventArgs e)
        {

        }

        private void descriptionOfIncident_TextChanged(object sender, EventArgs e)
        {

        }

        private void typeIncident_TextChanged(object sender, EventArgs e)
        {

        }

        private void IncidentCase_TextChanged(object sender, EventArgs e)
        {

        }

        private void InjuryCount_ValueChanged(object sender, EventArgs e)
        {

        }

        private void hospitalizationCount_ValueChanged(object sender, EventArgs e)
        {

        }

        private void fatalityCount_ValueChanged(object sender, EventArgs e)
        {

        }

        private void companyId_ValueChanged(object sender, EventArgs e)
        {

        }

        private void railroadId_ValueChanged(object sender, EventArgs e)
        {

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
            int injuryCount = (int)InjuryCount.Value;
            int HospitalizationCount = (int)hospitalizationCount.Value;
            int FatalityCount = (int)fatalityCount.Value;

            // Inputs for names instead of IDs
            string companyName = companyNameInput.Text; // Company name input
            string railroadName = railroadNameInput.Text; // Railroad name input

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Ensure the company and railroad exist and get their IDs
                    int companyId = GetOrInsertCompanyId(connection, companyName);
                    int? railroadId = string.IsNullOrWhiteSpace(railroadName)
                        ? null
                        : (int?)GetOrInsertRailroadId(connection, railroadName);

                    // Get the last seqnos value for incrementing
                    int newSeqnos;
                    using (SqlCommand getLastSeqnosCommand = new SqlCommand("SELECT ISNULL(MAX(seqnos), 0) + 1 FROM incident", connection))
                    {
                        newSeqnos = (int)getLastSeqnosCommand.ExecuteScalar();
                    }

                    // SQL insert query without the incident_train_id
                    string insertQuery = @"
                INSERT INTO incident 
                (seqnos, date_time_received, date_time_complete, call_type, responsible_city, responsible_state, responsible_zip, 
                description_of_incident, type_of_incident, incident_cause, injury_count, hospitalization_count, fatality_count, 
                company_id, railroad_id) 
                VALUES (@Seqnos, @ReceiveTime, @CompleteTime, @CallType, @City, @State, @Zip, @Description, @Type, @Cause, 
                @Injuries, @Hospitalizations, @Fatalities, @CompanyId, @RailroadId)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Add parameters to the command
                        command.Parameters.AddWithValue("@Seqnos", newSeqnos);
                        command.Parameters.AddWithValue("@ReceiveTime", receiveTime);
                        command.Parameters.AddWithValue("@CompleteTime", completeTime ?? (object)DBNull.Value); // Nullable DateTime
                        command.Parameters.AddWithValue("@CallType", callType);
                        command.Parameters.AddWithValue("@City", responsibleCity);
                        command.Parameters.AddWithValue("@State", responsibleState);
                        command.Parameters.AddWithValue("@Zip", responsibleZip);
                        command.Parameters.AddWithValue("@Description", description);
                        command.Parameters.AddWithValue("@Type", type);
                        command.Parameters.AddWithValue("@Cause", incidentCause);
                        command.Parameters.AddWithValue("@Injuries", injuryCount);
                        command.Parameters.AddWithValue("@Hospitalizations", HospitalizationCount);
                        command.Parameters.AddWithValue("@Fatalities", FatalityCount);
                        command.Parameters.AddWithValue("@CompanyId", companyId);
                        command.Parameters.AddWithValue("@RailroadId", railroadId ?? (object)DBNull.Value);

                        // Execute the command
                        command.ExecuteNonQuery();
                        MessageBox.Show("Incident added successfully with Seqnos: " + newSeqnos);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private int GetOrInsertCompanyId(SqlConnection connection, string companyName)
        {
            string selectQuery = "SELECT company_id FROM company WHERE company_name = @CompanyName";
            using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
            {
                selectCommand.Parameters.AddWithValue("@CompanyName", companyName);
                var existingCompanyId = selectCommand.ExecuteScalar();
                if (existingCompanyId != null)
                {
                    return (int)existingCompanyId;
                }
            }

            string insertQuery = "INSERT INTO company (company_name, org_type) OUTPUT INSERTED.company_id VALUES (@CompanyName, 'Unknown')";
            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
            {
                insertCommand.Parameters.AddWithValue("@CompanyName", companyName);
                return (int)insertCommand.ExecuteScalar();
            }
        }

        private int GetOrInsertRailroadId(SqlConnection connection, string railroadName)
        {
            string selectQuery = "SELECT railroad_id FROM railroad WHERE railroad_name = @RailroadName";
            using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
            {
                selectCommand.Parameters.AddWithValue("@RailroadName", railroadName);
                var existingRailroadId = selectCommand.ExecuteScalar();
                if (existingRailroadId != null)
                {
                    return (int)existingRailroadId;
                }
            }

            string insertQuery = "INSERT INTO railroad (railroad_name) OUTPUT INSERTED.railroad_id VALUES (@RailroadName)";
            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
            {
                insertCommand.Parameters.AddWithValue("@RailroadName", railroadName);
                return (int)insertCommand.ExecuteScalar();
            }
        }

        private int GetOrInsertIncidentTrainId(SqlConnection connection, string trainName)
        {
            string selectQuery = "SELECT train_id FROM incident_train WHERE name_number = @TrainName";
            using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
            {
                selectCommand.Parameters.AddWithValue("@TrainName", trainName);
                var existingTrainId = selectCommand.ExecuteScalar();
                if (existingTrainId != null)
                {
                    return (int)existingTrainId;
                }
            }

            string insertQuery = @"
                                INSERT INTO incident_train (name_number, train_type) 
                                OUTPUT INSERTED.train_id 
                                VALUES (@TrainName, 'Unknown')";
            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
            {
                insertCommand.Parameters.AddWithValue("@TrainName", trainName);
                return (int)insertCommand.ExecuteScalar();
            }
        }

        private void InsertButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            InsertIncident();
        }

        private void InsertButton_Click_1(object sender, EventArgs e)
        {
            InsertIncident();
        }

    }
}
