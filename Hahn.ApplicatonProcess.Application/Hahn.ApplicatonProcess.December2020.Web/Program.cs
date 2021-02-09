using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            using (var loggerFactory = LoggerFactory.Create(builder =>
            {
                //builder.ClearProviders();
                builder.AddFilter("Microsoft", LogLevel.Warning);
                builder.AddFilter("System", LogLevel.Warning);
                builder.AddConsole();
                builder.AddEventLog();
            }))
            {
                ILogger logger = loggerFactory.CreateLogger<Program>();
                logger.LogInformation("Program is being started");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
