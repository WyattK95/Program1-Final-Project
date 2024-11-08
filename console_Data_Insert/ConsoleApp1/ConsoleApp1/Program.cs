using Npgsql;
using System;
using System.IO;
using System.Data;
using ExcelDataReader;
using Microsoft.Extensions.Logging;

namespace SpreadsheetSpelunker
{
    internal class Program
    {
        private static readonly ILogger<Program> _logger;

        static Program()
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                builder.AddDebug();
            });

            _logger = loggerFactory.CreateLogger<Program>();
        }

        static void Main(string[] args)
        {
            string filePathForThis = args.Length > 0 ? args[0] : "../CY22.xlsx";
            var data = ParseTheFile(filePathForThis);
            if (data != null)
            {
                InsertDataIntoDatabase(data);
            }
            else
            {
                _logger.LogError("Failed to parse the file.");
            }
        }

        private static DataSet? ParseTheFile(string filePathForThis)
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
                _logger.LogError($"An error occurred while parsing the file: {ex.Message}");
                return null;
            }
        }

        private static void InsertDataIntoDatabase(DataSet data)
        {
            string connString = "Host=db-2024-bruhigita3932.cnsalab.net;Username=bruhigita3932;Password=yNIIwNNBO7MW4O7cUhzK;Database=NC_Database";

            using (var conn = new NpgsqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    foreach (DataTable table in data.Tables)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            try
                            {
                                switch (table.TableName)
                                {
                                    case "company":
                                        InsertCompanyData(conn, row);
                                        break;
                                    case "railroad":
                                        InsertRailroadData(conn, row);
                                        break;
                                    case "incident_train":
                                        InsertIncidentTrainData(conn, row);
                                        break;
                                    case "incident":
                                        InsertIncidentData(conn, row);
                                        break;
                                    case "incident_train_car":
                                        InsertIncidentTrainCarData(conn, row);
                                        break;
                                    default:
                                        // Log a warning for unknown tables
                                        _logger.LogWarning($"Unknown table name: {table.TableName}");
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError($"Error inserting data into {table.TableName}: {ex.Message}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Database connection error: {ex.Message}");
                }
            }
        }


        private static void InsertCompanyData(NpgsqlConnection conn, DataRow row)
        {
            string companyName = row["company_name"].ToString();
            string orgType = row["org_type"].ToString();

            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO company (company_name, org_type) VALUES (@companyName, @orgType)";
                cmd.Parameters.AddWithValue("companyName", companyName);
                cmd.Parameters.AddWithValue("orgType", orgType);
                cmd.ExecuteNonQuery();
            }
        }

        private static void InsertRailroadData(NpgsqlConnection conn, DataRow row)
        {
            string railroadName = row["railroad_name"].ToString();

            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO railroad (railroad_name) VALUES (@railroadName)";
                cmd.Parameters.AddWithValue("railroadName", railroadName);
                cmd.ExecuteNonQuery();
            }
        }

        private static void InsertIncidentTrainData(NpgsqlConnection conn, DataRow row)
        {
            string nameNumber = row["name_number"].ToString();
            string trainType = row["train_type"].ToString();
            int railroadId = Convert.ToInt32(row["railroad_id"]);

            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO incident_train (name_number, train_type, railroad_id) VALUES (@nameNumber, @trainType, @railroadId)";
                cmd.Parameters.AddWithValue("nameNumber", nameNumber);
                cmd.Parameters.AddWithValue("trainType", trainType);
                cmd.Parameters.AddWithValue("railroadId", railroadId);
                cmd.ExecuteNonQuery();
            }
        }

        private static void InsertIncidentData(NpgsqlConnection conn, DataRow row)
        {
            DateTime dateTimeReceived = row["date_time_received"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["date_time_received"]);
            DateTime? dateTimeComplete = row["date_time_complete"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["date_time_complete"]);
            string callType = row["call_type"]?.ToString() ?? string.Empty;
            string responsibleCity = row["responsible_city"]?.ToString() ?? string.Empty;
            string responsibleState = row["responsible_state"]?.ToString() ?? string.Empty;
            string responsibleZip = row["responsible_zip"]?.ToString() ?? string.Empty;
            string descriptionOfIncident = row["description_of_incident"]?.ToString() ?? string.Empty;
            string typeOfIncident = row["type_of_incident"]?.ToString() ?? string.Empty;
            string incidentCause = row["incident_cause"]?.ToString() ?? string.Empty;
            int injuryCount = row["injury_count"] == DBNull.Value ? 0 : Convert.ToInt32(row["injury_count"]);
            int hospitalizationCount = row["hospitalization_count"] == DBNull.Value ? 0 : Convert.ToInt32(row["hospitalization_count"]);
            int fatalityCount = row["fatality_count"] == DBNull.Value ? 0 : Convert.ToInt32(row["fatality_count"]);
            int companyId = row["company_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["company_id"]);
            int railroadId = row["railroad_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["railroad_id"]);
            int incidentTrainId = row["incident_train_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["incident_train_id"]);

            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO incident (date_time_received, date_time_complete, call_type, responsible_city, responsible_state, responsible_zip, description_of_incident, type_of_incident, incident_cause, injury_count, hospitalization_count, fatality_count, company_id, railroad_id, incident_train_id) VALUES (@dateTimeReceived, @dateTimeComplete, @callType, @responsibleCity, @responsibleState, @responsibleZip, @descriptionOfIncident, @typeOfIncident, @incidentCause, @injuryCount, @hospitalizationCount, @fatalityCount, @companyId, @railroadId, @incidentTrainId)";
                cmd.Parameters.AddWithValue("dateTimeReceived", dateTimeReceived);
                cmd.Parameters.AddWithValue("dateTimeComplete", dateTimeComplete ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("callType", callType);
                cmd.Parameters.AddWithValue("responsibleCity", responsibleCity);
                cmd.Parameters.AddWithValue("responsibleState", responsibleState);
                cmd.Parameters.AddWithValue("responsibleZip", responsibleZip);
                cmd.Parameters.AddWithValue("descriptionOfIncident", descriptionOfIncident);
                cmd.Parameters.AddWithValue("typeOfIncident", typeOfIncident);
                cmd.Parameters.AddWithValue("incidentCause", incidentCause);
                cmd.Parameters.AddWithValue("injuryCount", injuryCount);
                cmd.Parameters.AddWithValue("hospitalizationCount", hospitalizationCount);
                cmd.Parameters.AddWithValue("fatalityCount", fatalityCount);
                cmd.Parameters.AddWithValue("companyId", companyId);
                cmd.Parameters.AddWithValue("railroadId", railroadId);
                cmd.Parameters.AddWithValue("incidentTrainId", incidentTrainId);
                cmd.ExecuteNonQuery();
            }
        }


        private static void InsertIncidentTrainCarData(NpgsqlConnection conn, DataRow row)
        {
            string carNumber = row["car_number"].ToString();
            string carContent = row["car_content"].ToString();
            int positionInTrain = Convert.ToInt32(row["position_in_train"]);
            string carType = row["car_type"].ToString();
            int incidentTrainId = Convert.ToInt32(row["incident_train_id"]);

            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO incident_train_car (car_number, car_content, position_in_train, car_type, incident_train_id) VALUES (@carNumber, @carContent, @positionInTrain, @carType, @incidentTrainId)";
                cmd.Parameters.AddWithValue("carNumber", carNumber);
                cmd.Parameters.AddWithValue("carContent", carContent);
                cmd.Parameters.AddWithValue("positionInTrain", positionInTrain);
                cmd.Parameters.AddWithValue("carType", carType);
                cmd.Parameters.AddWithValue("incidentTrainId", incidentTrainId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
