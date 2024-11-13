using System;
using System.Data;
using Npgsql;
using ClosedXML.Excel;

public class Program
{
    // Entry point for the application
    public static string ConvertToString(DataSet dataSet)
    {
        var result = new System.Text.StringBuilder();

        foreach (DataTable table in dataSet.Tables)
        {
            result.AppendLine($"Table: {table.TableName}");
            foreach (DataColumn column in table.Columns)
            {
                result.Append($"{column.ColumnName}\t");
            }
            result.AppendLine();

            foreach (DataRow row in table.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    result.Append($"{item}\t");
                }
                result.AppendLine();
            }
            result.AppendLine();
        }

        return result.ToString();
    }

    public static void Main(string[] args)
    {
        // Path to your Excel file
        string excelFilePath = "CY22Test.xlsx"; // Replace with actual file path

        // Create and populate the DataSet by reading the Excel file
        var data = ReadExcelFile(excelFilePath);

        // Print the contents of the DataSet before inserting it into the database
       //Console.WriteLine("Data before insertion:\n" + ConvertToString(data));
        
        // Call the method to insert data into the database
        DatabaseHelper.InsertDataIntoDatabase(data);
        
        
    }

    // Method to read data from Excel file and populate DataSet
    public static DataSet ReadExcelFile(string filePath)
    {
        var dataSet = new DataSet();

        // Load the Excel file using ClosedXML
        using (var workbook = new XLWorkbook(filePath))
        {
            // Iterate through each worksheet in the Excel workbook
            foreach (var worksheet in workbook.Worksheets)
            {
                var table = new DataTable(worksheet.Name);
                Console.WriteLine("Loading");
                // Read the header row to create columns
                bool isFirstRow = true;
                foreach (var row in worksheet.RowsUsed())
                {
                    if (isFirstRow)
                    {
                        foreach (var cell in row.Cells())
                        {
                            table.Columns.Add(cell.Value.ToString());
                        }
                        isFirstRow = false;
                        //Console.WriteLine("Read the header");
                    }
                    else
                    {
                        var dataRow = table.NewRow();
                        for (int i = 0; i < table.Columns.Count; i++)
                        {
                            dataRow[i] = row.Cell(i + 1).Value.ToString();
                        }
                        table.Rows.Add(dataRow);
                        //Console.WriteLine("Read data row");
                    }
                }

                dataSet.Tables.Add(table); // Add the DataTable to the DataSet
            }
        }
        Console.WriteLine("The file was read successfully");
        
        return dataSet;
        
    }
}

public class DatabaseHelper
{
    // Define the connection string to the PostgreSQL database
    private static readonly string connString = "Host=db-2024-bruhigita3932.cnsalab.net;Username=bruhigita3932;Password=yNIIwNNBO7MW4O7cUhzK;Database=NC_Database";

    // Method to insert data into the database and query the inserted data
    public static void InsertDataIntoDatabase(DataSet data)
    {
        // Set of valid table names to process
        var validTables = new HashSet<string> { "COMPANY", "RAILROAD", "incident_train", "incident", "incident_train_car" };

        using (var conn = new NpgsqlConnection(connString))
        {
            try
            {
                conn.Open();
                Console.WriteLine("Connection established successfully!");

                // Iterate through each DataTable in the DataSet
                foreach (DataTable table in data.Tables)
                {
                    // Skip tables that are not in the valid list
                    if (validTables.Contains(table.TableName))
                    {
                        Console.WriteLine($"Reading table: {table.TableName}");
                    }
                    else
                    {
                        Console.WriteLine($"Skipping table: {table.TableName}");
                        continue; // Skip this table and continue to the next
                    }

                    // Iterate through each row of the current table
                    foreach (DataRow row in table.Rows)
                    {
                        try
                        {
                            // Depending on the table name, call the appropriate insert method
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
                                    Console.WriteLine($"Unknown table name: {table.TableName}");
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error inserting data into {table.TableName}: {ex.Message}");
                        }
                    }
                }

                // After inserting the data, query and print the inserted data from all tables
                QueryAndPrintInsertedData(conn);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database connection error: {ex.Message}");
            }
        }
    }

    private static void InsertCompanyData(NpgsqlConnection conn, DataRow row)
    {
        var query = "INSERT INTO company (company_name, org_type) VALUES (@company_name, @org_type)";
        using (var cmd = new NpgsqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("company_name", row["company_name"]);
            cmd.Parameters.AddWithValue("org_type", row["org_type"]);
            cmd.ExecuteNonQuery();
            Console.WriteLine($"Inserted into company: {row["company_name"]}, {row["org_type"]}");
        }
    }

    private static void InsertRailroadData(NpgsqlConnection conn, DataRow row)
    {
        var query = "INSERT INTO railroad (railroad_name) VALUES (@railroad_name)";
        using (var cmd = new NpgsqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("railroad_name", row["railroad_name"]);
            cmd.ExecuteNonQuery();
            Console.WriteLine($"Inserted into railroad: {row["railroad_name"]}");
        }
    }

    private static void InsertIncidentTrainData(NpgsqlConnection conn, DataRow row)
    {
        var query = "INSERT INTO incident_train (name_number, train_type, railroad_id) VALUES (@name_number, @train_type, @railroad_id)";
        using (var cmd = new NpgsqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("name_number", row["name_number"]);
            cmd.Parameters.AddWithValue("train_type", row["train_type"]);
            cmd.Parameters.AddWithValue("railroad_id", row["railroad_id"]);
            cmd.ExecuteNonQuery();
            Console.WriteLine($"Inserted into incident_train: {row["name_number"]}, {row["train_type"]}, {row["railroad_id"]}");
        }
    }
    
    private static void InsertIncidentData(NpgsqlConnection conn, DataRow row)
    {
        Console.WriteLine("We are about to insert");
        conn.Open(); // Open the connection if it's not already open
        if (conn is null)
        {
            Console.WriteLine("The connection is not made");
            throw new ArgumentNullException(nameof(conn));
        }
        else{
            Console.WriteLine("The connection is made");
        }

        var query = @"
            INSERT INTO incident (
                date_time_received, date_time_complete, call_type, responsible_city, 
                responsible_state, responsible_zip, description_of_incident, 
                type_of_incident, incident_cause, injury_count, hospitalization_count, 
                fatality_count, company_id, railroad_id, incident_train_id
            ) VALUES (
                @date_time_received, @date_time_complete, @call_type, @responsible_city, 
                @responsible_state, @responsible_zip, @description_of_incident, 
                @type_of_incident, @incident_cause, @injury_count, @hospitalization_count, 
                @fatality_count, @company_id, @railroad_id, @incident_train_id
            )";
        using (var cmd = new NpgsqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("date_time_received", row["date_time_received"]);
            cmd.Parameters.AddWithValue("date_time_complete", row["date_time_complete"]);
            cmd.Parameters.AddWithValue("call_type", row["call_type"]);
            cmd.Parameters.AddWithValue("responsible_city", row["responsible_city"]);
            cmd.Parameters.AddWithValue("responsible_state", row["responsible_state"]);
            cmd.Parameters.AddWithValue("responsible_zip", row["responsible_zip"]);
            cmd.Parameters.AddWithValue("description_of_incident", row["description_of_incident"]);
            cmd.Parameters.AddWithValue("type_of_incident", row["type_of_incident"]);
            cmd.ExecuteNonQuery();
            Console.WriteLine($"Inserted into incident: {row["description_of_incident"]}");
        }
        conn.Close();
    }

    private static void InsertIncidentTrainCarData(NpgsqlConnection conn, DataRow row)
    {
        conn.Open();
        var query = @"
            INSERT INTO incident_train_car (
                car_number, car_content, position_in_train, car_type, incident_train_id
            ) VALUES (
                @car_number, @car_content, @position_in_train, @car_type, @incident_train_id
            )";
        using (var cmd = new NpgsqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("car_number", row["car_number"]);
            cmd.Parameters.AddWithValue("car_content", row["car_content"]);
            cmd.Parameters.AddWithValue("position_in_train", row["position_in_train"]);
            cmd.Parameters.AddWithValue("car_type", row["car_type"]);
            cmd.ExecuteNonQuery();
            Console.WriteLine($"Inserted into incident_train_car: {row["car_number"]}");
        }
        conn.Close();
    }

    private static void QueryAndPrintInsertedData(NpgsqlConnection conn)
    {
        if (conn is null)
        {
            throw new ArgumentNullException(nameof(conn));
            Console.WriteLine("The connection is not made");
        }
        else{
            Console.WriteLine("The connection is made");
        }

        var query = "SELECT * FROM company"; // Adjust this for other tables as needed
        using (var cmd = new NpgsqlCommand(query, conn))
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                Console.WriteLine($"Company: {reader["company_name"]}, {reader["org_type"]}");
            }
        }
    }
}
