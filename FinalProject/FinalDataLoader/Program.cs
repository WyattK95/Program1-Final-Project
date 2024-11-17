using System;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FinalDataLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("nrc-etl");

            if (args.Length != 1)
            {
                Console.WriteLine("Please provide a path to the spreadsheet as the first argument");
                return;
            }

            string filepath = args[0];

            // Build configuration
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Set the base path for the configuration file
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // Add the JSON configuration file
                .Build();

            // Get the connection string
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                Console.WriteLine("Connection string 'DefaultConnection' not found.");
                return;
            }

            DataLoader dl = new DataLoader(filepath, connectionString);

            if (dl.LoadData())
            {
                Console.WriteLine("Data loaded successfully.");

                // Insert data into the database
                dl.InsertDataIntoDatabase();
                Console.WriteLine("Data inserted into the database successfully.");
            }
            else
            {
                Console.WriteLine("Data loading failed.");
            }
        }
    }
}
