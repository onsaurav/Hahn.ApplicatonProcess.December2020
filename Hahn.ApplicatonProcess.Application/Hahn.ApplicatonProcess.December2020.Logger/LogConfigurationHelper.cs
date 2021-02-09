using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.December2020.Logger
{
    public class LogConfigurationHelper
    {
        private readonly IConfigurationRoot configurationRoot;
        public LogConfigurationHelper()
        {
            configurationRoot = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                .Build();
        }

        public string GetSerilogLogPathString()
        {
            return GetConfigValue("SerilogLogPath");
        }

        public string GetConfigValue(string key)
        {
            return !string.IsNullOrEmpty(key) ? configurationRoot.GetSection(key).Value : "";
        }

        public List<string> GetConfigValues(string key)
        {
            List<string> values = new List<string>();
            IConfigurationSection myArraySection = configurationRoot.GetSection(key);
            var itemArray = myArraySection.AsEnumerable();
            foreach (var item in itemArray)
            {
                values.Add(item.Value);
            }
            if (values.Count > 0)
                values.RemoveAt(0);
            return values;
        }
    }
}
