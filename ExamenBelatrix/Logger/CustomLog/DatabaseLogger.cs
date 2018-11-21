using Logger.Common;
using Logger.Core;
using Logger.CustomLog.Strategies;
using Logger.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.CustomLog
{
    public class DatabaseLogger : ALoggerBase
    {
        public DatabaseLogger()
            :base(new DatabaseLogStrategy(new LoggerDAO()))
        {
        }

        public DatabaseLogger(LogLevel currentLevel, ILoggerDAO loggerDAO)
            :base(currentLevel, new DatabaseLogStrategy(loggerDAO))
        {

        }
    }
}
