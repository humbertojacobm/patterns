using Logger.Common;
using Logger.Common.Configuration;
using Logger.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.CustomLog
{
    public abstract class ALoggerBase : ILogger
    {
        protected ILogStrategy logStrategy;
        protected LogLevel currentLevel;

        public ALoggerBase(ILogStrategy logStrategy)
        {
            this.logStrategy = logStrategy;
            this.currentLevel = LogSettings.GetSettings().Level;
        }

        public ALoggerBase(LogLevel currentLevel, ILogStrategy logStrategy)
        {
            this.logStrategy = logStrategy;
            this.currentLevel = currentLevel;
        }

        public void LogMessage(string message, LogLevel level)
        {
            if (currentLevel <= level)
            {
                logStrategy.LogMessage(message, level);
            }
        }
    }
}
