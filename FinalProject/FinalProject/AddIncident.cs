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

        private void InsertButton_Click(object sender, EventArgs e)
        {
            DateTime receiveTime = dataTimeReceived.Value;
            DateTime? completeTime = dataTimeComplete.Value;  // Use nullable DateTime if completion is optional            
            string responsibleCity = resposibleCity.Text;
            string responsibleState = resposibleStates.Text;
            string responsibleZip = resposibleZip.Text;
            string description = descriptionOfIncident.Text;
            string type = typeIncident.Text;
            string incidentCause = IncidentCase.Text; // Assuming this is a text field
            String CallType = "INC";
            int injuryCount = (int)InjuryCount.Value;
            int HospitalizationCount = (int)hospitalizationCount.Value;
            int FatalityCount = (int)fatalityCount.Value;
            int CompanyId = (int)companyId.Value;
            int RailroadId = (int)railroadId.Value;
            //int IncidentTrainId = (int)incidentTrainId.Value;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string InsertQuery = @"INSERT INTO incident 
                                        (date_time_received, date_time_complete, call_type, responsible_city, responsible_state, responsible_zip, 
                                        description_of_incident, type_of_incident, incident_cause, injury_count, hospitalization_count, fatality_count, 
                                        company_id, railroad_id, incident_train_id) VALUES (@ReceiveTime, @CompleteTime, @CallType, @City, @State, @Zip, @Description, @Type, @Cause, @Injuries, 
                                        @Hospitalizations, @Fatalities, @CompanyId, @RailroadId, @TrainId)";
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.Parameters.AddWithValue("@ReceiveTime", receiveTime);
                        if (completeTime.HasValue)
                        {
                            command.Parameters.AddWithValue("@CompleteTime", completeTime.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@CompleteTime", DBNull.Value);
                        }
                        command.Parameters.AddWithValue("@CallType", CallType);
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
                        command.Parameters.AddWithValue("@RailroadId", RailroadId);
                        //command.Parameters.AddWithValue("@TrainId", IncidentTrainId);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Incident added successfully. ");
                        

                    }


                }
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show("Error:" + ex.Message);
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
           
            dataTimeReceived.Value = DateTime.Now;
            dataTimeComplete.Value = DateTime.Now;
            descriptionOfIncident.Clear();
            typeIncident.Clear();
            //IncidentCase.Value = 0;
            InjuryCount.Value = 0;
            hospitalizationCount.Value = 0;
            fatalityCount.Value = 0;
            companyId.Value = 0;
            railroadId.Value = 0;
            resposibleCity.Clear();
            //resposibleState.Clear();
            resposibleZip.Clear();
        }
    }
}
