using DemoProject.Services.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Logger.Info("Demo Project starting");
                CreateHostBuilder(args).Build().Run();
            }
            catch(Exception ex)
            {
                Logger.Fatal(ex, "The Project has failed to start!:" + ex.Message);
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
            .UseSerilog();
    }
}
