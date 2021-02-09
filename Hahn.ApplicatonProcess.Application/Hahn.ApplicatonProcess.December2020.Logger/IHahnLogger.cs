using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.December2020.Logger
{
    public interface IHahnLogger
    {
        void Information(string logText);
        void Warning(string logText);
        void Error(string logText);
        void Debug(string logText);
        void Fatal(string logText);
    }
}
