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
    public class TextLogger : ALoggerBase
    {
        public TextLogger()
            :base(new TextLogStrategy())
        {

        }

        public TextLogger(LogLevel currentLevel, string path, string maxSize)
            :base(currentLevel, new TextLogStrategy(path, maxSize))
        {
        }
    }
}
