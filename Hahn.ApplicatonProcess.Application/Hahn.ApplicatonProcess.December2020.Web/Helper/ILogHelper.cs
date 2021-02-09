using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Web.Helper
{
    public interface ILogHelper
    {
        void Information(string logText);
        void Warning(string logText);
        void Error(string logText);
        void Debug(string logText);
        void Fatal(string logText);
    }
}
