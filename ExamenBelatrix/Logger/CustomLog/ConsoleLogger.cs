using Logger.Common;
using Logger.Core;
using Logger.CustomLog.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.CustomLog
{
    public class ConsoleLogger : ALoggerBase
    {
        public ConsoleLogger()
            :base(new ConsoleLogStrategy())
        {
        }
        public ConsoleLogger(LogLevel currentLevel, ILogStrategy logStrategy)
            : base(currentLevel, logStrategy)
        {
        }
    }
}
