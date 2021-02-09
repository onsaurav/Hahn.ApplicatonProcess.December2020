using Serilog;
using System;
using System.IO;

namespace Hahn.ApplicatonProcess.December2020.Logger
{
    public class HahnLogger : IHahnLogger
    {
        static ILogger _logger;
        static string _filePath = "";

        public HahnLogger()
        {
            LogConfigurationHelper logConfiguration = new LogConfigurationHelper();
            _filePath = logConfiguration.GetSerilogLogPathString();

            if (_logger == null)
            {
                _logger = new LoggerConfiguration()
                    .MinimumLevel.Information()
                    .WriteTo.Console()
                    .WriteTo.File(
                        path: _filePath,
                        rollingInterval: RollingInterval.Day,
                        fileSizeLimitBytes: 10485760,
                        rollOnFileSizeLimit: true,
                        retainedFileCountLimit: 3)
                    .CreateLogger();
            }
        }

        public void Information(string logText)
        {
            _logger.Information(logText);
        }

        public void Warning(string logText)
        {
            _logger.Warning(logText);
        }

        public void Error(string logText)
        {
            _logger.Error(logText);
        }

        public void Debug(string logText)
        {
            _logger.Debug(logText);
        }

        public void Fatal(string logText)
        {
            _logger.Fatal(logText);
        }
    }
}
