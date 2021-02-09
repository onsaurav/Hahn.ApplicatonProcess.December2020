using Hahn.ApplicatonProcess.December2020.Logger;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Web.Helper
{
    public class LogHelper : ILogHelper
    {
        ILogger _Logger;
        IHahnLogger _HahnLogger;

        public LogHelper(ILogger<LogHelper> logger, IHahnLogger hahnLogger)
        {
            _Logger = logger;
            _HahnLogger = hahnLogger;
        }

        public void Debug(string logText)
        {
            _Logger.LogDebug(logText);
            _HahnLogger.Debug(logText);
        }

        public void Error(string logText)
        {
            _Logger.LogError(logText);
            _HahnLogger.Error(logText);
        }

        public void Fatal(string logText)
        {
            _Logger.LogCritical(logText);
            _HahnLogger.Fatal(logText);
        }

        public void Information(string logText)
        {
            _Logger.LogInformation(logText);
            _HahnLogger.Information(logText);
        }

        public void Warning(string logText)
        {
            _Logger.LogWarning(logText);
            _HahnLogger.Warning(logText);
        }
    }
}
