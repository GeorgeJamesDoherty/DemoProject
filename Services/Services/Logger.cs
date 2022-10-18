using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using Serilog;

namespace DemoProject.Services.Services
{
    public static class Logger
    {
        private static Serilog.Core.Logger log;

        static Logger()
        {
            try
            {
                Serilog.Debugging.SelfLog.Enable(msg => System.Diagnostics.Debug.WriteLine(msg));

                var _configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

                var defaultLogLevel = _configuration["Serilog:MinimumLevel"];
                var connectionString = _configuration.GetConnectionString("DemoContext").ToString();

                var logLevel = (LogEventLevel)Enum.Parse(typeof(LogEventLevel), defaultLogLevel);
                var levelSwitch = new LoggingLevelSwitch(logLevel);

                log = new LoggerConfiguration()
                    .WriteTo.MSSqlServer(connectionString, sinkOptions: new MSSqlServerSinkOptions { TableName = "DemoLog", AutoCreateSqlTable = true })
                    .MinimumLevel.ControlledBy(levelSwitch)
                    .Enrich.WithProperty("Application", "Demo Project")
                    .CreateLogger();


                System.Diagnostics.Debug.WriteLine("");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void Info(string message)
        {
            log.Information(message);
        }

        public static void Error(string message)
        {
            log.Error(message);
        }

        public static void Error(Exception ex, string message)
        {
            log.Error(ex, message);
        }

        public static void Fatal(string message)
        {
            log.Fatal(message);
        }

        public static void Fatal(Exception ex, string message)
        {
            log.Fatal(ex, message);
        }
    }
}
