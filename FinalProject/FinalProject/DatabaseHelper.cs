using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace FinalProject
{
    public static class DatabaseHelper
    {
        private static readonly string _connectionString = Program.Configuration.GetConnectionString("DefaultConnection");

        public static void ExecuteNonQuery(string commandText, Action<SqlCommand> parameterize = null)
        {
            LogDatabaseOperation(commandText, () =>
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var command = new SqlCommand(commandText, connection))
                {
                    parameterize?.Invoke(command);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            });
        }

        public static T ExecuteScalar<T>(string commandText, Action<SqlCommand> parameterize = null)
        {
            return LogDatabaseOperation(commandText, () =>
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var command = new SqlCommand(commandText, connection))
                {
                    parameterize?.Invoke(command);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    return result != null && result != DBNull.Value ? (T)Convert.ChangeType(result, typeof(T)) : default;
                }
            });
        }

        public static void ExecuteReader(string commandText, Action<SqlDataReader> read, Action<SqlCommand> parameterize = null)
        {
            LogDatabaseOperation(commandText, () =>
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var command = new SqlCommand(commandText, connection))
                {
                    parameterize?.Invoke(command);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        read(reader);
                    }
                }
            });
        }

        private static void LogDatabaseOperation(string commandText, Action dbOperation)
        {
            var logEntry = new
            {
                timestamp = DateTime.Now.ToString("yyyyMMdd HH:mm:ss"),
                command = commandText,
                success = false
            };

            try
            {
                dbOperation();
                logEntry = new
                {
                    timestamp = logEntry.timestamp,
                    command = logEntry.command,
                    success = true
                };
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Database operation failed");
                throw;
            }
            finally
            {
                // Log the operation details
                Log.Information("{@LogEntry}", logEntry);
            }
        }

        private static T LogDatabaseOperation<T>(string commandText, Func<T> dbOperation)
        {
            var logEntry = new
            {
                timestamp = DateTime.Now.ToString("yyyyMMdd HH:mm:ss"),
                command = commandText,
                success = false
            };

            try
            {
                T result = dbOperation();
                logEntry = new
                {
                    timestamp = logEntry.timestamp,
                    command = logEntry.command,
                    success = true
                };
                return result;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Database operation failed");
                throw;
            }
            finally
            {
                // Log the operation details
                Log.Information("{@LogEntry}", logEntry);
            }
        }
    }
}
