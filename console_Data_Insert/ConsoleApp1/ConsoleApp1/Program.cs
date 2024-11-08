using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using ExcelDataReader;

namespace SpreadsheetSpelunker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePathForThis = args.Length > 0 ? args[0] : "../CY22.xlsx";
            var data = ParseTheFile(filePathForThis);
            InsertDataIntoDatabase(data);
        }

        private static DataSet ParseTheFile(string filePathForThis = "../CY22.xlsx")
        {
            try
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                using (var stream = File.Open(filePathForThis, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet();
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        private static void InsertDataIntoDatabase(DataSet data)
        {
            string connString = "Server=REDOSKIC;Database=NC_TestServer;User Id=UserConsole;Password=CNSAcnsa1;";

            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                foreach (DataTable table in data.Tables)
                {
                    if (table.TableName == "Company")
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            string companyName = row["company_name"].ToString();
                            string orgType = row["org_type"].ToString();

                            using (var cmd = new SqlCommand())
                            {
                                cmd.Connection = conn;
                                cmd.CommandText = "INSERT INTO company (company_name, org_type) VALUES (@companyName, @orgType)";
                                cmd.Parameters.AddWithValue("@companyName", companyName);
                                cmd.Parameters.AddWithValue("@orgType", orgType);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    else if (table.TableName == "Railroad")
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            string railroadName = row["railroad_name"].ToString();

                            using (var cmd = new SqlCommand())
                            {
                                cmd.Connection = conn;
                                cmd.CommandText = "INSERT INTO railroad (railroad_name) VALUES (@railroadName)";
                                cmd.Parameters.AddWithValue("@railroadName", railroadName);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    else if (table.TableName == "Incident")
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            DateTime dateTimeReceived = DateTime.Parse(row["date_time_received"].ToString());
                            DateTime? dateTimeComplete = row["date_time_complete"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(row["date_time_complete"].ToString());
                            string callType = row["call_type"].ToString();
                            string responsibleCity = row["responsible_city"].ToString();
                            string responsibleState = row["responsible_state"].ToString();
                            string responsibleZip = row["responsible_zip"].ToString();
                            string descriptionOfIncident = row["description_of_incident"].ToString();
                            string typeOfIncident = row["type_of_incident"].ToString();
                            string incidentCause = row["incident_cause"].ToString();
                            int? injuryCount = row["injury_count"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["injury_count"]);
                            int? hospitalizationCount = row["hospitalization_count"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["hospitalization_count"]);
                            int? fatalityCount = row["fatality_count"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["fatality_count"]);
                            int? companyId = row["company_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["company_id"]);
                            int? railroadId = row["railroad_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["railroad_id"]);
                            int? incidentTrainId = row["incident_train_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["incident_train_id"]);

                            using (var cmd = new SqlCommand())
                            {
                                cmd.Connection = conn;
                                cmd.CommandText = "INSERT INTO incident (date_time_received, date_time_complete, call_type, responsible_city, responsible_state, responsible_zip, description_of_incident, type_of_incident, incident_cause, injury_count, hospitalization_count, fatality_count, company_id, railroad_id, incident_train_id) " +
                                    "VALUES (@dateTimeReceived, @dateTimeComplete, @callType, @responsibleCity, @responsibleState, @responsibleZip, @descriptionOfIncident, @typeOfIncident, @incidentCause, @injuryCount, @hospitalizationCount, @fatalityCount, @companyId, @railroadId, @incidentTrainId)";
                                cmd.Parameters.AddWithValue("@dateTimeReceived", dateTimeReceived);
                                cmd.Parameters.AddWithValue("@dateTimeComplete", dateTimeComplete.HasValue ? (object)dateTimeComplete.Value : DBNull.Value);
                                cmd.Parameters.AddWithValue("@callType", callType);
                                cmd.Parameters.AddWithValue("@responsibleCity", responsibleCity);
                                cmd.Parameters.AddWithValue("@responsibleState", responsibleState);
                                cmd.Parameters.AddWithValue("@responsibleZip", responsibleZip);
                                cmd.Parameters.AddWithValue("@descriptionOfIncident", descriptionOfIncident);
                                cmd.Parameters.AddWithValue("@typeOfIncident", typeOfIncident);
                                cmd.Parameters.AddWithValue("@incidentCause", incidentCause);
                                cmd.Parameters.AddWithValue("@injuryCount", injuryCount.HasValue ? (object)injuryCount.Value : DBNull.Value);
                                cmd.Parameters.AddWithValue("@hospitalizationCount", hospitalizationCount.HasValue ? (object)hospitalizationCount.Value : DBNull.Value);
                                cmd.Parameters.AddWithValue("@fatalityCount", fatalityCount.HasValue ? (object)fatalityCount.Value : DBNull.Value);
                                cmd.Parameters.AddWithValue("@companyId", companyId.HasValue ? (object)companyId.Value : DBNull.Value);
                                cmd.Parameters.AddWithValue("@railroadId", railroadId.HasValue ? (object)railroadId.Value : DBNull.Value);
                                cmd.Parameters.AddWithValue("@incidentTrainId", incidentTrainId.HasValue ? (object)incidentTrainId.Value : DBNull.Value);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    // Add similar blocks for other tables: incident_train, incident_train_car, etc.
                    else if (table.TableName == "incident_train")
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            string nameNumber = row["name_number"].ToString();
                            string trainType = row["train_type"].ToString();
                            int? railroadId = row["railroad_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["railroad_id"]);

                            using (var cmd = new SqlCommand())
                            {
                                cmd.Connection = conn;
                                cmd.CommandText = "INSERT INTO incident_train (name_number, train_type, railroad_id) VALUES (@nameNumber, @trainType, @railroadId)";
                                cmd.Parameters.AddWithValue("@nameNumber", nameNumber);
                                cmd.Parameters.AddWithValue("@trainType", trainType);
                                cmd.Parameters.AddWithValue("@railroadId", railroadId.HasValue ? (object)railroadId.Value : DBNull.Value);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }
    }
}
