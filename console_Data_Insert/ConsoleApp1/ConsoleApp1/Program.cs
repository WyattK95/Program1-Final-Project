using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using Npgsql;
using OfficeOpenXml;

public class Program
{
    // Entry point for the application
    public static async Task Main(string[] args)
    {
        // Path to your Excel file
        string excelFilePath = "path_to_your_excel_file.xlsx"; // Replace with actual file path
        
        // Create and populate the DataSet by reading the Excel file
        var data = await ReadExcelFileAsync(excelFilePath);

        // Call the method to insert data into the database
        await DatabaseHelper.InsertDataIntoDatabaseAsync(data);
    }

    // Method to read data from Excel file and populate DataSet
    public static async Task<DataSet> ReadExcelFileAsync(string filePath)
    {
        var dataSet = new DataSet();

        // Load the Excel file using EPPlus
        using (var package = new ExcelPackage(new FileInfo(filePath)))
        {
            var worksheet = package.Workbook.Worksheets[0]; // Get first worksheet
            int rowCount = worksheet.Dimension.Rows;
            int colCount = worksheet.Dimension.Columns;

            // Create DataTables for each sheet (can be customized if you have multiple sheets)
            var table = new DataTable("company"); // Example for one sheet
            for (int col = 1; col <= colCount; col++)
            {
                table.Columns.Add(worksheet.Cells[1, col].Text); // First row as column names
            }

            // Add rows to DataTable
            for (int row = 2; row <= rowCount; row++) // Start from row 2 (ignoring header row)
            {
                var newRow = table.NewRow();
                for (int col = 1; col <= colCount; col++)
                {
                    newRow[col - 1] = worksheet.Cells[row, col].Text; // Add cell data
                }
                table.Rows.Add(newRow);
            }

            dataSet.Tables.Add(table); // Add the DataTable to the DataSet
        }

        return dataSet;
    }
}

public class DatabaseHelper
{
    // Define the connection string to the PostgreSQL database
    private static readonly string connString = "Host=db-2024-bruhigita3932.cnsalab.net;Username=bruhigita3932;Password=yNIIwNNBO7MW4O7cUhzK;Database=NC_Database";

    // Asynchronous method to insert data into the database and query the inserted data
    public static async Task InsertDataIntoDatabaseAsync(DataSet data)
    {
        // Set of valid table names to process
        var validTables = new HashSet<string> { "company", "railroad", "incident_train", "incident", "incident_train_car" };

        // Open the connection to the database
        await using var conn = new NpgsqlConnection(connString);
        try
        {
            // Try to establish a connection to the database asynchronously
            await conn.OpenAsync();
            Console.WriteLine("Connection established successfully!");

            // Iterate through each DataTable in the DataSet
            foreach (DataTable table in data.Tables)
            {
                // Skip tables that are not in the valid list
                if (!validTables.Contains(table.TableName))
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
                                await InsertCompanyDataAsync(conn, row);
                                break;
                            case "railroad":
                                await InsertRailroadDataAsync(conn, row);
                                break;
                            case "incident_train":
                                await InsertIncidentTrainDataAsync(conn, row);
                                break;
                            case "incident":
                                await InsertIncidentDataAsync(conn, row);
                                break;
                            case "incident_train_car":
                                await InsertIncidentTrainCarDataAsync(conn, row);
                                break;
                            default:
                                Console.WriteLine($"Unknown table name: {table.TableName}");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any errors during the insert operation for a row
                        Console.WriteLine($"Error inserting data into {table.TableName}: {ex.Message}");
                    }
                }
            }

            // After inserting the data, query and print the inserted data from all tables
            await QueryAndPrintInsertedData(conn);
        }
        catch (Exception ex)
        {
            // Handle any database connection errors
            Console.WriteLine($"Database connection error: {ex.Message}");
        }
    }

    // Method to insert data into the 'company' table
    private static async Task InsertCompanyDataAsync(NpgsqlConnection conn, DataRow row)
    {
        // SQL query to insert data into the company table
        var query = "INSERT INTO company (company_name, org_type) VALUES (@company_name, @org_type)";
        
        // Create a command to execute the query on the database connection
        await using var cmd = new NpgsqlCommand(query, conn);
        // Add parameters to the command to prevent SQL injection
        cmd.Parameters.AddWithValue("company_name", row["company_name"]);
        cmd.Parameters.AddWithValue("org_type", row["org_type"]);
        
        // Execute the query asynchronously
        await cmd.ExecuteNonQueryAsync();
        // Output the inserted data to the console
        Console.WriteLine($"Inserted into company: {row["company_name"]}, {row["org_type"]}");
    }

    // Method to insert data into the 'railroad' table
    private static async Task InsertRailroadDataAsync(NpgsqlConnection conn, DataRow row)
    {
        // SQL query to insert data into the railroad table
        var query = "INSERT INTO railroad (railroad_name) VALUES (@railroad_name)";
        
        // Create a command to execute the query
        await using var cmd = new NpgsqlCommand(query, conn);
        // Add the railroad name as a parameter
        cmd.Parameters.AddWithValue("railroad_name", row["railroad_name"]);
        
        // Execute the query asynchronously
        await cmd.ExecuteNonQueryAsync();
        // Output the inserted data to the console
        Console.WriteLine($"Inserted into railroad: {row["railroad_name"]}");
    }

    // Method to insert data into the 'incident_train' table
    private static async Task InsertIncidentTrainDataAsync(NpgsqlConnection conn, DataRow row)
    {
        // SQL query to insert data into the incident_train table
        var query = "INSERT INTO incident_train (name_number, train_type, railroad_id) VALUES (@name_number, @train_type, @railroad_id)";
        
        // Create a command to execute the query
        await using var cmd = new NpgsqlCommand(query, conn);
        // Add parameters for each column in the table
        cmd.Parameters.AddWithValue("name_number", row["name_number"]);
        cmd.Parameters.AddWithValue("train_type", row["train_type"]);
        cmd.Parameters.AddWithValue("railroad_id", row["railroad_id"]);
        
        // Execute the query asynchronously
        await cmd.ExecuteNonQueryAsync();
        // Output the inserted data to the console
        Console.WriteLine($"Inserted into incident_train: {row["name_number"]}, {row["train_type"]}");
    }

    // Method to insert data into the 'incident' table
    private static async Task InsertIncidentDataAsync(NpgsqlConnection conn, DataRow row)
    {
        // SQL query to insert data into the incident table
        var query = @"INSERT INTO incident (date_time_received, date_time_complete, call_type, responsible_city, responsible_state, responsible_zip, 
                          description_of_incident, type_of_incident, incident_cause, injury_count, hospitalization_count, fatality_count, 
                          company_id, railroad_id, incident_train_id)
                      VALUES (@date_time_received, @date_time_complete, @call_type, @responsible_city, @responsible_state, @responsible_zip, 
                              @description_of_incident, @type_of_incident, @incident_cause, @injury_count, @hospitalization_count, @fatality_count, 
                              @company_id, @railroad_id, @incident_train_id)";
        
        // Create a command to execute the query
        await using var cmd = new NpgsqlCommand(query, conn);
        // Add parameters for each column in the table
        cmd.Parameters.AddWithValue("date_time_received", row["date_time_received"]);
        cmd.Parameters.AddWithValue("date_time_complete", row["date_time_complete"]);
        cmd.Parameters.AddWithValue("call_type", row["call_type"]);
        cmd.Parameters.AddWithValue("responsible_city", row["responsible_city"]);
        cmd.Parameters.AddWithValue("responsible_state", row["responsible_state"]);
        cmd.Parameters.AddWithValue("responsible_zip", row["responsible_zip"]);
        cmd.Parameters.AddWithValue("description_of_incident", row["description_of_incident"]);
        cmd.Parameters.AddWithValue("type_of_incident", row["type_of_incident"]);
        cmd.Parameters.AddWithValue("incident_cause", row["incident_cause"]);
        cmd.Parameters.AddWithValue("injury_count", row["injury_count"]);
        cmd.Parameters.AddWithValue("hospitalization_count", row["hospitalization_count"]);
        cmd.Parameters.AddWithValue("fatality_count", row["fatality_count"]);
        cmd.Parameters.AddWithValue("company_id", row["company_id"]);
        cmd.Parameters.AddWithValue("railroad_id", row["railroad_id"]);
        cmd.Parameters.AddWithValue("incident_train_id", row["incident_train_id"]);
        
        // Execute the query asynchronously
        await cmd.ExecuteNonQueryAsync();
        // Output the inserted data to the console
        Console.WriteLine($"Inserted into incident: {row["call_type"]}");
    }

    // Method to insert data into the 'incident_train_car' table
    private static async Task InsertIncidentTrainCarDataAsync(NpgsqlConnection conn, DataRow row)
    {
        // SQL query to insert data into the incident_train_car table
        var query = @"INSERT INTO incident_train_car (incident_id, train_car_type, number_of_train_cars_involved)
                      VALUES (@incident_id, @train_car_type, @number_of_train_cars_involved)";
        
        // Create a command to execute the query
        await using var cmd = new NpgsqlCommand(query, conn);
        // Add parameters for each column in the table
        cmd.Parameters.AddWithValue("incident_id", row["incident_id"]);
        cmd.Parameters.AddWithValue("train_car_type", row["train_car_type"]);
        cmd.Parameters.AddWithValue("number_of_train_cars_involved", row["number_of_train_cars_involved"]);
        
        // Execute the query asynchronously
        await cmd.ExecuteNonQueryAsync();
        // Output the inserted data to the console
        Console.WriteLine($"Inserted into incident_train_car: {row["train_car_type"]}");
    }

    // Method to query and print the inserted data from the database
    private static async Task QueryAndPrintInsertedData(NpgsqlConnection conn)
    {
        // Example to print data from all tables (modify queries as per your needs)
        var query = "SELECT * FROM company"; // Adjust this for other tables as needed
        
        // Create a command to execute the query
        await using var cmd = new NpgsqlCommand(query, conn);
        // Execute the query and get the data
        await using var reader = await cmd.ExecuteReaderAsync();
        
        // Print the results to the console
        while (await reader.ReadAsync())
        {
            Console.WriteLine($"Company: {reader["company_name"]}, {reader["org_type"]}");
        }
    }
}
