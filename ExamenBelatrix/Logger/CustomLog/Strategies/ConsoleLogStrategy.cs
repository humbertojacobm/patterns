using Logger.Common;
using Logger.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.CustomLog.Strategies
{
    public class ConsoleLogStrategy : ILogStrategy
    {
        public void LogMessage(string message, LogLevel level)
        {
            Console.ForegroundColor = GetColorByLevel(level);
            Console.WriteLine(message);
        }

        private ConsoleColor GetColorByLevel(LogLevel level)
        {
            ConsoleColor color;
            switch (level)
            {
                case LogLevel.Warning:
                    color = ConsoleColor.Yellow;
                    break;
                case LogLevel.Error:
                    color = ConsoleColor.Red;
                    break;
                case LogLevel.Message:
                default:
                    color = ConsoleColor.White;
                    break;
            }
            return color;
        }
    }
}
