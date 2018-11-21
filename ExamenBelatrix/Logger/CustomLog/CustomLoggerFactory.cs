using Logger.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.CustomLog
{
    public class CustomLoggerFactory : ILogFactory
    {
        public ILogger GetLog(LogDestination destination)
        {
            ILogger log = null;
            switch (destination)
            {
                case LogDestination.TextFile:
                    log = new TextLogger();
                    break;
                case LogDestination.Database:
                    log = new DatabaseLogger();
                    break;
                case LogDestination.Console:
                    log = new ConsoleLogger();
                    break;
                default:
                    throw new NotImplementedException("The log destination is not implemented");
            }
            return log;
        }
    }
}
