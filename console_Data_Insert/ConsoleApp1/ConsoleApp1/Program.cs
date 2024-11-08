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
            if (data != null)
            {
                InsertDataIntoDatabase(data);
            }
            else
            {
                Console.WriteLine("No data to insert.");
            }
        }

        private static DataSet ParseTheFile(string filePathForThis)
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
                Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
                return null;
            }
        }

        private static void InsertDataIntoDatabase(DataSet data)
        {
            string connString = "Server=REDOSKIC;Database=NC_TestServer;User Id=UserConsole;Password=CNSAcnsa1;";


            try
            {
                using (var conn = new SqlConnection(connString))
                {
                    conn.Open();
                    foreach (DataTable table in data.Tables)
                    {
                        if (table.TableName == "Company")
                        {
                            InsertCompanyData(conn, table);
                        }
                        else if (table.TableName == "Railroad")
                        {
                            InsertRailroadData(conn, table);
                        }
                        else if (table.TableName == "Incident")
                        {
                            InsertIncidentData(conn, table);
                        }
                        else if (table.TableName == "incident_train_car")
                        {
                            InsertIncidentData(conn, table);
                        }
                        // Add additional else-if blocks for other tables here
                    }
                }
                Console.WriteLine("Data inserted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while inserting data: {ex.Message}");
            }
        }

        private static void InsertCompanyData(SqlConnection conn, DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                using (var cmd = new SqlCommand("INSERT INTO company (company_name, org_type) VALUES (@companyName, @orgType)", conn))
                {
                    cmd.Parameters.AddWithValue("@companyName", row["company_name"].ToString());
                    cmd.Parameters.AddWithValue("@orgType", row["org_type"].ToString());
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static void InsertRailroadData(SqlConnection conn, DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                using (var cmd = new SqlCommand("INSERT INTO railroad (railroad_name) VALUES (@railroadName)", conn))
                {
                    cmd.Parameters.AddWithValue("@railroadName", row["railroad_name"].ToString());
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static void InsertIncidentData(SqlConnection conn, DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                using (var cmd = new SqlCommand("INSERT INTO incident (date_time_received, call_type) VALUES (@dateTimeReceived, @callType)", conn))
                {
                    cmd.Parameters.AddWithValue("@dateTimeReceived", DateTime.Parse(row["date_time_received"].ToString()));
                    cmd.Parameters.AddWithValue("@callType", row["call_type"].ToString());
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
