using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using ClosedXML.Excel;

namespace FinalDataLoader
{
    class DataLoader
    {
        private string InputFilePath { get; set; }
        private string ConnectionString { get; set; }

        // Dictionaries to store loaded data
        public Dictionary<string, Company> companies = new Dictionary<string, Company>();
        public Dictionary<int, Incident> incidents = new Dictionary<int, Incident>();
        public Dictionary<string, Railroad> railroads = new Dictionary<string, Railroad>();
        public Dictionary<string, IncidentTrain> trains = new Dictionary<string, IncidentTrain>();
        public Dictionary<string, IncidentTrainCar> trainCars = new Dictionary<string, IncidentTrainCar>();

        public DataLoader(string inputFilePath, string connectionString)
        {
            this.InputFilePath = inputFilePath;
            this.ConnectionString = connectionString;
        }

        // Helper method to safely get DateTime from a cell
        public DateTime? GetDateTime(IXLCell cell)
        {
            try
            {
                return cell.GetDateTime();
            }
            catch
            {
                // Handle exception or return null if the cell doesn't contain a valid DateTime
            }
            return null;
        }

        // Main method to load data from the Excel file
        public bool LoadData()
        {
            try
            {
                XLWorkbook wbook = new XLWorkbook(this.InputFilePath);

                foreach (IXLWorksheet ws in wbook.Worksheets)
                {
                    Console.WriteLine($"Processing worksheet: {ws.Name}");
                    if (ws.Name.Equals("CALLS", StringComparison.OrdinalIgnoreCase))
                    {
                        LoadIncidentsFromCalls(ws);
                    }
                    else if (ws.Name.Equals("INCIDENT_COMMONS", StringComparison.OrdinalIgnoreCase))
                    {
                        LoadIncidentsFromCommons(ws);
                    }
                    else if (ws.Name.Equals("INCIDENT_DETAILS", StringComparison.OrdinalIgnoreCase))
                    {
                        LoadIncidentsFromDetails(ws);
                    }
                    else if (ws.Name.Equals("TRAINS_DETAIL", StringComparison.OrdinalIgnoreCase))
                    {
                        LoadRailroadsAndIncidentTrainsFromTrainsDetail(ws);
                    }
                    else if (ws.Name.Equals("DERAILED_UNITS", StringComparison.OrdinalIgnoreCase))
                    {
                        LoadIncidentTrainCarsFromDerailedUnits(ws);
                    }
                }

                // After loading all data, associate incidents with railroads
                AssociateIncidentsWithRailroads();

                Console.WriteLine($"Total Companies Loaded: {companies.Count}");
                Console.WriteLine($"Total Incidents Loaded: {incidents.Count}");
                Console.WriteLine($"Total Railroads Loaded: {railroads.Count}");
                Console.WriteLine($"Total Trains Loaded: {trains.Count}");
                Console.WriteLine($"Total Train Cars Loaded: {trainCars.Count}");

                if (incidents.Count > 0)
                {
                    var sampleIncident = incidents.Values.First();
                    Console.WriteLine($"Sample Incident SEQNOS: {sampleIncident.Seqnos}, Description: {sampleIncident.DescriptionOfIncident}");
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading data: {ex.Message}");
                return false;
            }
        }

        // Method to load incidents from the CALLS worksheet
        public void LoadIncidentsFromCalls(IXLWorksheet ws)
        {
            IXLRow lastRow = ws.LastRowUsed();
            int lastRowNumber = lastRow.RowNumber();
            Console.WriteLine($"Total rows in CALLS: {lastRowNumber}");

            for (int i = 2; i <= lastRowNumber; i++)
            {
                IXLRow row = ws.Row(i);
                string seqnosStr = row.Cell(1).GetString().Trim();
                if (string.IsNullOrEmpty(seqnosStr))
                {
                    break;
                }

                if (!int.TryParse(seqnosStr, out int seqnos))
                {
                    Console.WriteLine($"Invalid SEQNOS at row {i}. Skipping.");
                    continue;
                }

                // Get DateTimeReceived and DateTimeComplete
                DateTime? dateTimeReceived = GetDateTime(row.Cell(2));
                DateTime? dateTimeComplete = GetDateTime(row.Cell(3));

                // Get CallType and provide a default if missing
                string callTypeValue = row.Cell(4).GetString().Trim();
                if (string.IsNullOrWhiteSpace(callTypeValue))
                {
                    callTypeValue = "Unknown"; 
                }

                string companyName = row.Cell(5).GetString().Trim();
                string orgType = row.Cell(6).GetString().Trim();
                string responsibleCity = row.Cell(7).GetString().Trim();
                string responsibleState = row.Cell(8).GetString().Trim();
                string responsibleZip = row.Cell(9).GetString().Trim();

                // Create or retrieve the Company object and normalize name
                string companyNameNormalized = companyName.Trim().ToUpperInvariant();
                Company company = null;
                if (!string.IsNullOrEmpty(companyName))
                {
                    if (!companies.TryGetValue(companyNameNormalized, out company))
                    {
                        company = new Company
                        {
                            CompanyId = 0, // Placeholder; will be set after insertion into DB
                            CompanyName = companyName.Trim(),
                            OrgType = orgType
                        };
                        companies[companyNameNormalized] = company;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(company.OrgType))
                        {
                            company.OrgType = orgType;
                        }
                    }

                }

                // Create the Incident object
                Incident incident = new Incident
                {
                    Seqnos = seqnos,
                    DateTimeReceived = dateTimeReceived,
                    DateTimeComplete = dateTimeComplete,
                    CallType = callTypeValue,
                    ResponsibleCity = !string.IsNullOrWhiteSpace(responsibleCity) ? responsibleCity : "Unknown",
                    ResponsibleState = !string.IsNullOrWhiteSpace(responsibleState) ? responsibleState : "Unknown",
                    ResponsibleZip = !string.IsNullOrWhiteSpace(responsibleZip) ? responsibleZip : "Unknown",
                    ResponsibleCompany = company // Set the reference to the Company object
                };

                // Add the incident to the incidents dictionary
                incidents[incident.Seqnos] = incident;
            }
        }

        // Method to load incident details from the INCIDENT_COMMONS worksheet
        public void LoadIncidentsFromCommons(IXLWorksheet ws)
        {
            IXLRow lastRow = ws.LastRowUsed();
            int lastRowNumber = lastRow.RowNumber();
            Console.WriteLine($"Total rows in INCIDENT_COMMONS: {lastRowNumber}");

            for (int i = 2; i <= lastRowNumber; i++)
            {
                IXLRow row = ws.Row(i);
                string seqnosStr = row.Cell(1).GetString().Trim();
                if (string.IsNullOrEmpty(seqnosStr))
                {
                    break;
                }

                if (!int.TryParse(seqnosStr, out int seqnos))
                {
                    Console.WriteLine($"Invalid SEQNOS at row {i}. Skipping.");
                    continue;
                }

                if (!incidents.TryGetValue(seqnos, out Incident incident))
                {
                    Console.WriteLine($"Incident with SEQNOS {seqnos} not found.");
                    continue;
                }

                incident.DescriptionOfIncident = row.Cell(2).GetString().Trim();

                // Set TypeOfIncident
                string typeOfIncidentValue = row.Cell(3).GetString().Trim();
                if (string.IsNullOrWhiteSpace(typeOfIncidentValue))
                {
                    typeOfIncidentValue = "Unknown"; 
                }
                incident.TypeOfIncident = typeOfIncidentValue;

                string incidentCauseValue = row.Cell(4).GetString().Trim();
                incident.IncidentCause = !string.IsNullOrWhiteSpace(incidentCauseValue) ? incidentCauseValue : "Unknown";

                Console.WriteLine($"Loaded description and type for incident {seqnos}");
            }
        }

        public void LoadIncidentsFromDetails(IXLWorksheet ws)
        {
            IXLRow lastRow = ws.LastRowUsed();
            int lastRowNumber = lastRow.RowNumber();
            Console.WriteLine($"Total rows in INCIDENT_DETAILS: {lastRowNumber}");

            // Map column names to indices
            IXLRow headerRow = ws.Row(1);
            Dictionary<string, int> columnIndices = MapColumnIndices(headerRow);

            // Get indices for required columns
            int seqnosCol = GetColumnIndex(columnIndices, "SEQNOS");
            int numberInjuredCol = GetColumnIndex(columnIndices, "NUMBER_INJURED");
            int numberHospitalizedCol = GetColumnIndex(columnIndices, "NUMBER_HOSPITALIZED");
            int numberFatalitiesCol = GetColumnIndex(columnIndices, "NUMBER_FATALITIES");

            // Check for required columns
            if (seqnosCol == -1)
            {
                Console.WriteLine("Required columns not found in INCIDENT_DETAILS sheet.");
                return;
            }

            for (int i = 2; i <= lastRowNumber; i++)
            {
                IXLRow row = ws.Row(i);

                string seqnosStr = row.Cell(seqnosCol).GetString().Trim();
                if (string.IsNullOrEmpty(seqnosStr))
                {
                    break;
                }

                if (!int.TryParse(seqnosStr, out int seqnos))
                {
                    Console.WriteLine($"Invalid SEQNOS at row {i}. Skipping.");
                    continue;
                }

                if (!incidents.TryGetValue(seqnos, out Incident incident))
                {
                    Console.WriteLine($"Incident with SEQNOS {seqnos} not found.");
                    continue;
                }

                // Read NUMBER_INJURED
                string numberInjuredStr = numberInjuredCol != -1 ? row.Cell(numberInjuredCol).GetString().Trim() : null;
                if (int.TryParse(numberInjuredStr, out int numberInjured))
                {
                    incident.InjuryCount = numberInjured;
                }

                // Read NUMBER_HOSPITALIZED
                string numberHospitalizedStr = numberHospitalizedCol != -1 ? row.Cell(numberHospitalizedCol).GetString().Trim() : null;
                if (int.TryParse(numberHospitalizedStr, out int numberHospitalized))
                {
                    incident.HospitalizationCount = numberHospitalized;
                }

                // Read NUMBER_FATALITIES
                string numberFatalitiesStr = numberFatalitiesCol != -1 ? row.Cell(numberFatalitiesCol).GetString().Trim() : null;
                if (int.TryParse(numberFatalitiesStr, out int numberFatalities))
                {
                    incident.FatalityCount = numberFatalities;
                }

                Console.WriteLine($"Updated incident {seqnos} with injury/hospitalization/fatality counts.");
            }
        }

        // Method to load railroads and incident trains from the TRAINS_DETAIL worksheet
        public void LoadRailroadsAndIncidentTrainsFromTrainsDetail(IXLWorksheet ws)
        {
            // Map column names to indices
            IXLRow headerRow = ws.Row(1);
            Dictionary<string, int> columnIndices = MapColumnIndices(headerRow);

            // Get indices for required columns
            int seqnosCol = GetColumnIndex(columnIndices, "SEQNOS");
            int railroadNameCol = GetColumnIndex(columnIndices, "RAILROAD_NAME");
            int trainNameNumberCol = GetColumnIndex(columnIndices, "TRAIN_NAME_NUMBER");
            int trainTypeCol = GetColumnIndex(columnIndices, "TRAIN_TYPE");

            if (seqnosCol == -1 || railroadNameCol == -1 || trainNameNumberCol == -1 || trainTypeCol == -1)
            {
                Console.WriteLine("Required columns not found in TRAINS_DETAIL sheet.");
                return;
            }

            IXLRow lastRow = ws.LastRowUsed();
            int lastRowNumber = lastRow.RowNumber();

            for (int i = 2; i <= lastRowNumber; i++)
            {
                IXLRow row = ws.Row(i);

                string seqnosStr = row.Cell(seqnosCol).GetString().Trim();
                string railroadName = row.Cell(railroadNameCol).GetString().Trim();
                string trainNameNumber = row.Cell(trainNameNumberCol).GetString().Trim();
                string trainType = row.Cell(trainTypeCol).GetString().Trim();

                if (string.IsNullOrWhiteSpace(seqnosStr) || string.IsNullOrWhiteSpace(railroadName) || string.IsNullOrWhiteSpace(trainNameNumber))
                    continue;

                if (!int.TryParse(seqnosStr, out int seqnos))
                    continue;

                if (!incidents.ContainsKey(seqnos))
                {
                    Console.WriteLine($"Incident with SEQNOS {seqnos} not found.");
                    continue;
                }

                // Add Railroad
                if (!railroads.ContainsKey(railroadName))
                {
                    Railroad railroad = new Railroad
                    {
                        RailroadId = 0, // Placeholder; will be set after insertion into DB
                        RailroadName = railroadName
                    };
                    railroads[railroadName] = railroad;
                }

                // Generate unique key for IncidentTrain
                string trainKey = $"{seqnos}_{trainNameNumber}";
                if (!trains.ContainsKey(trainKey))
                {
                    IncidentTrain train = new IncidentTrain
                    {
                        TrainId = 0, // Placeholder; will be set after insertion into DB
                        TrainNameNumber = trainNameNumber,
                        TrainType = trainType,
                        IncidentId = seqnos,
                        RailroadName = railroadName // Temporarily store the railroad name
                    };
                    trains[trainKey] = train;
                }
            }
        }

        // Method to load incident train cars from the DERAILED_UNITS worksheet
        public void LoadIncidentTrainCarsFromDerailedUnits(IXLWorksheet ws)
        {
            // Map column names to indices
            IXLRow headerRow = ws.Row(1);
            Dictionary<string, int> columnIndices = MapColumnIndices(headerRow);

            // Get indices for required columns
            int seqnosCol = GetColumnIndex(columnIndices, "SEQNOS");
            int trainNameNumberCol = GetColumnIndex(columnIndices, "TRAIN_NAME_NUMBER");
            int carNumberCol = GetColumnIndex(columnIndices, "CAR_NUMBER");
            int carContentCol = GetColumnIndex(columnIndices, "CAR_CONTENT");
            int positionInTrainCol = GetColumnIndex(columnIndices, "POSITION_IN_TRAIN");
            int carTypeCol = GetColumnIndex(columnIndices, "DERAILED_TYPE");

            if (seqnosCol == -1 || trainNameNumberCol == -1 || carNumberCol == -1 || carContentCol == -1 || positionInTrainCol == -1 || carTypeCol == -1)
            {
                Console.WriteLine("Required columns not found in DERAILED_UNITS sheet.");
                return;
            }

            IXLRow lastRow = ws.LastRowUsed();
            int lastRowNumber = lastRow.RowNumber();

            for (int i = 2; i <= lastRowNumber; i++)
            {
                IXLRow row = ws.Row(i);

                string seqnosStr = row.Cell(seqnosCol).GetString().Trim();
                string trainNameNumber = row.Cell(trainNameNumberCol).GetString().Trim();
                string carNumber = row.Cell(carNumberCol).GetString().Trim();
                string carContent = row.Cell(carContentCol).GetString().Trim();
                string positionInTrainStr = row.Cell(positionInTrainCol).GetString().Trim();
                string carType = row.Cell(carTypeCol).GetString().Trim();

                if (!int.TryParse(seqnosStr, out int seqnos))
                    continue;

                if (string.IsNullOrWhiteSpace(trainNameNumber) || string.IsNullOrWhiteSpace(carNumber))
                    continue;

                // Generate unique key for IncidentTrain
                string trainKey = $"{seqnos}_{trainNameNumber}";
                if (!trains.ContainsKey(trainKey))
                {
                    Console.WriteLine($"IncidentTrain with SEQNOS {seqnos} and TRAIN_NAME_NUMBER {trainNameNumber} not found.");
                    continue;
                }

                if (!int.TryParse(positionInTrainStr, out int positionInTrain))
                    positionInTrain = 0;  // Default value if parsing fails

                // Generate unique key for IncidentTrainCar
                string trainCarKey = $"{carNumber}_{positionInTrain}_{trains[trainKey].TrainId}";
                if (!trainCars.ContainsKey(trainCarKey))
                {
                    IncidentTrainCar trainCar = new IncidentTrainCar
                    {
                        TrainCarId = 0, // Placeholder; will be set after insertion into DB
                        CarNumber = carNumber,
                        CarContent = carContent,
                        PositionInTrain = positionInTrain,
                        CarType = carType,
                        IncidentTrainKey = trainKey // Temporarily store the train key
                    };
                    trainCars[trainCarKey] = trainCar;
                }
            }
        }

        // Helper method to map column names to indices
        private Dictionary<string, int> MapColumnIndices(IXLRow headerRow)
        {
            Dictionary<string, int> columnIndices = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            int columnNumber = 1;
            foreach (IXLCell cell in headerRow.CellsUsed())
            {
                string columnName = cell.GetString().Trim();
                columnIndices[columnName] = columnNumber;
                columnNumber++;
            }
            return columnIndices;
        }

        // Helper method to get column index safely
        private int GetColumnIndex(Dictionary<string, int> columnIndices, string columnName)
        {
            return columnIndices.TryGetValue(columnName, out int index) ? index : -1;
        }

        // Method to associate incidents with railroads
        public void AssociateIncidentsWithRailroads()
        {
            foreach (var incident in incidents.Values)
            {
                // Find trains associated with the incident
                var trainsForIncident = trains.Values.Where(t => t.IncidentId == incident.Seqnos);

                if (trainsForIncident.Any())
                {
                    // Get the railroad IDs from the trains
                    var railroadIds = trainsForIncident.Select(t => t.RailroadId).Distinct().Where(id => id.HasValue).Select(id => id.Value);

                    if (railroadIds.Count() == 1)
                    {
                        // If all trains have the same RailroadId, set it
                        incident.RailroadId = railroadIds.First();
                    }
                    else if (railroadIds.Count() > 1)
                    {
                        // Handle cases where there are multiple railroads (if applicable)
                        // For simplicity, select the first one
                        incident.RailroadId = railroadIds.First();
                    }
                    else
                    {
                        // Trains have not been assigned RailroadIds yet
                        incident.RailroadId = null;
                    }
                }
                else
                {
                    // No trains associated with the incident
                    incident.RailroadId = null;
                }
            }
        }

        // Method to insert data into the database
        public void InsertDataIntoDatabase()
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        InsertCompanies(connection, transaction);
                        UpdateIncidentCompanyIds();
                        InsertRailroads(connection, transaction);
                        InsertIncidentTrains(connection, transaction);
                        AssociateIncidentsWithRailroads();
                        InsertIncidents(connection, transaction);
                        InsertIncidentTrainCars(connection, transaction);

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred during database insertion: {ex.Message}");
                        Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                        transaction.Rollback();
                    }
                }
            }
        }


        private void InsertCompanies(SqlConnection connection, SqlTransaction transaction)
        {
            string selectCompanySql = @"
        SELECT company_id FROM company WHERE company_name = @CompanyName AND org_type = @OrgType;";

            string insertCompanySql = @"
        INSERT INTO company (company_name, org_type)
        OUTPUT INSERTED.company_id
        VALUES (@CompanyName, @OrgType);";

            foreach (var company in companies.Values)
            {
                using (SqlCommand selectCmd = new SqlCommand(selectCompanySql, connection, transaction))
                {
                    selectCmd.Parameters.AddWithValue("@CompanyName", company.CompanyName);
                    selectCmd.Parameters.AddWithValue("@OrgType", company.OrgType ?? (object)DBNull.Value);

                    object result = selectCmd.ExecuteScalar();
                    if (result != null)
                    {
                        // Company exists, use existing company_id
                        company.CompanyId = (int)result;
                    }
                    else
                    {
                        // Insert new company
                        using (SqlCommand insertCmd = new SqlCommand(insertCompanySql, connection, transaction))
                        {
                            insertCmd.Parameters.AddWithValue("@CompanyName", company.CompanyName);
                            insertCmd.Parameters.AddWithValue("@OrgType", company.OrgType ?? (object)DBNull.Value);

                            Console.WriteLine($"Inserting Company: {company.CompanyName} with OrgType: {company.OrgType}");

                            int companyId = (int)insertCmd.ExecuteScalar();
                            company.CompanyId = companyId;

                            Console.WriteLine($"Inserted Company ID: {companyId}");
                        }
                    }
                }
            }
        }

        public void UpdateIncidentCompanyIds()
        {
            foreach (var incident in incidents.Values)
            {
                if (incident.ResponsibleCompany != null)
                {
                    incident.ResponsibleCompanyId = incident.ResponsibleCompany.CompanyId;
                }
                else
                {
                    incident.ResponsibleCompanyId = null;
                }
            }
        }

        private void InsertRailroads(SqlConnection connection, SqlTransaction transaction)
        {
            string insertRailroadSql = @"
                INSERT INTO railroad (railroad_name)
                OUTPUT INSERTED.railroad_id
                VALUES (@RailroadName);";

            foreach (var railroad in railroads.Values)
            {
                using (SqlCommand cmd = new SqlCommand(insertRailroadSql, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@RailroadName", railroad.RailroadName);

                    int railroadId = (int)cmd.ExecuteScalar();
                    railroad.RailroadId = railroadId; // Update the railroad object with the generated ID
                }
            }
        }

        private void InsertIncidentTrains(SqlConnection connection, SqlTransaction transaction)
        {
            string insertTrainSql = @"
                INSERT INTO incident_train (name_number, train_type, railroad_id)
                OUTPUT INSERTED.train_id
                VALUES (@NameNumber, @TrainType, @RailroadId);";

            foreach (var train in trains.Values)
            {
                using (SqlCommand cmd = new SqlCommand(insertTrainSql, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@NameNumber", train.TrainNameNumber);
                    cmd.Parameters.AddWithValue("@TrainType", train.TrainType);

                    // Get the RailroadId from the railroads dictionary
                    if (railroads.TryGetValue(train.RailroadName, out Railroad railroad))
                    {
                        cmd.Parameters.AddWithValue("@RailroadId", railroad.RailroadId);
                        train.RailroadId = railroad.RailroadId;
                    }
                    else
                    {
                        // Handle the case where the railroad is not found
                        cmd.Parameters.AddWithValue("@RailroadId", DBNull.Value);
                        train.RailroadId = null;
                    }

                    int trainId = (int)cmd.ExecuteScalar();
                    train.TrainId = trainId; // Update the train object with the generated ID
                }
            }
        }

        private void InsertIncidents(SqlConnection connection, SqlTransaction transaction)
        {
            string insertIncidentSql = @"
        INSERT INTO incident (
            seqnos, date_time_received, date_time_complete, call_type, responsible_city, responsible_state,
            responsible_zip, description_of_incident, type_of_incident, incident_cause, injury_count,
            hospitalization_count, fatality_count, company_id, railroad_id, incident_train_id
        )
        VALUES (
            @Seqnos, @DateTimeReceived, @DateTimeComplete, @CallType, @ResponsibleCity, @ResponsibleState,
            @ResponsibleZip, @DescriptionOfIncident, @TypeOfIncident, @IncidentCause, @InjuryCount,
            @HospitalizationCount, @FatalityCount, @CompanyId, @RailroadId, @IncidentTrainId
        );";

            foreach (var incident in incidents.Values)
            {
                using (SqlCommand cmd = new SqlCommand(insertIncidentSql, connection, transaction))
                {
                    // Set parameters for incident fields
                    cmd.Parameters.AddWithValue("@Seqnos", incident.Seqnos);
                    cmd.Parameters.AddWithValue("@DateTimeReceived", incident.DateTimeReceived ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateTimeComplete", incident.DateTimeComplete ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CallType", incident.CallType ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ResponsibleCity", incident.ResponsibleCity ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ResponsibleState", incident.ResponsibleState ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ResponsibleZip", incident.ResponsibleZip ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DescriptionOfIncident", incident.DescriptionOfIncident ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TypeOfIncident", incident.TypeOfIncident ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IncidentCause", incident.IncidentCause ?? (object)DBNull.Value);

                    cmd.Parameters.AddWithValue("@InjuryCount", incident.InjuryCount.HasValue ? (object)incident.InjuryCount.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@HospitalizationCount", incident.HospitalizationCount.HasValue ? (object)incident.HospitalizationCount.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@FatalityCount", incident.FatalityCount.HasValue ? (object)incident.FatalityCount.Value : DBNull.Value);

                    // Use the updated ResponsibleCompanyId
                    cmd.Parameters.AddWithValue("@CompanyId", incident.ResponsibleCompanyId.HasValue ? (object)incident.ResponsibleCompanyId.Value : DBNull.Value);

                    cmd.Parameters.AddWithValue("@RailroadId", incident.RailroadId.HasValue ? (object)incident.RailroadId.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@IncidentTrainId", incident.IncidentTrainId.HasValue ? (object)incident.IncidentTrainId.Value : DBNull.Value);

                    // Execute the insert command
                    cmd.ExecuteNonQuery();

                }
            }
        }


        private void InsertIncidentTrainCars(SqlConnection connection, SqlTransaction transaction)
        {
            string insertTrainCarSql = @"
                INSERT INTO incident_train_car (car_number, car_content, position_in_train, car_type, incident_train_id)
                OUTPUT INSERTED.train_car_id
                VALUES (@CarNumber, @CarContent, @PositionInTrain, @CarType, @IncidentTrainId);";

            foreach (var trainCar in trainCars.Values)
            {
                using (SqlCommand cmd = new SqlCommand(insertTrainCarSql, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@CarNumber", trainCar.CarNumber);
                    cmd.Parameters.AddWithValue("@CarContent", trainCar.CarContent);
                    cmd.Parameters.AddWithValue("@PositionInTrain", trainCar.PositionInTrain);
                    cmd.Parameters.AddWithValue("@CarType", trainCar.CarType);

                    // Get the IncidentTrainId from the trains dictionary
                    if (trains.TryGetValue(trainCar.IncidentTrainKey, out IncidentTrain train))
                    {
                        cmd.Parameters.AddWithValue("@IncidentTrainId", train.TrainId);
                        trainCar.IncidentTrainId = train.TrainId;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@IncidentTrainId", DBNull.Value);
                        trainCar.IncidentTrainId = null;
                    }

                    int trainCarId = (int)cmd.ExecuteScalar();
                    trainCar.TrainCarId = trainCarId; // Update the train car object with the generated ID
                }
            }
        }
    }
}