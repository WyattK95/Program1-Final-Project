using System;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Formatting.Json;

namespace FinalProject
{
    static class Program
    {
        public static IConfiguration Configuration { get; private set; }

        [STAThread]
        static void Main()
        {
            // Configure Serilog
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(
                    formatter: new JsonFormatter(),
                    path: "logs\\db-queries.json",
                    rollingInterval: RollingInterval.Day,
                    fileSizeLimitBytes: null,
                    shared: true)
                .CreateLogger();

            var builder = new ConfigurationBuilder()
                  .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                  .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginScreen());
            Log.CloseAndFlush();
        }
    }
}