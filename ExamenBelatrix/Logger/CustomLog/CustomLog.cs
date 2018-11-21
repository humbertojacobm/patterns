using Logger.Common;
using Logger.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.CustomLog
{
    public class CustomLog : ILog
    {
        private ILogFactory logFactory;

        public CustomLog(ILogFactory logFactory)
        {
            this.logFactory = logFactory;
        }

        public void LogMessage(string message, params LogDestination[] destinations)
        {
            LogMessage(message, LogLevel.Message, destinations);
        }

        public void LogWarning(string message, params LogDestination[] destinations)
        {
            LogMessage(message, LogLevel.Warning, destinations);
        }

        public void LogError(string message, params LogDestination[] destinations)
        {
            LogMessage(message, LogLevel.Error, destinations);
        }

        public void LogMessage(string message, LogLevel level, params LogDestination[] destinations)
        {
            ILogger log = null;
            IList<LogDestination> loggedDestinations = new List<LogDestination>();
            foreach (var destination in destinations)
            {
                //Validates if we already logged to the destination for not saving twice
                if (loggedDestinations.Any(d => d == destination))
                {
                    continue;
                }
                log = logFactory.GetLog(destination);
                log.LogMessage(message, level);
                loggedDestinations.Add(destination);
            }
        }
    }
}
