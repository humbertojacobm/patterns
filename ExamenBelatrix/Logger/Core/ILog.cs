using Logger.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Core
{
    public interface ILog
    {
        /// <summary>
        /// Method for writing to the specified <remark>destinations</remark> with its level as Message
        /// </summary>
        /// <param name="message">String to log</param>
        /// <param name="destinations">Destinations to log</param>
        void LogMessage(string message, params LogDestination[] destination);

        /// <summary>
        /// Method for writing to the specified <remark>destinations</remark> with its level as Warning
        /// </summary>
        /// <param name="message">String to log</param>
        /// <param name="destinations">Destinations to log</param>
        void LogWarning(string message, params LogDestination[] destination);

        /// <summary>
        /// Method for writing to the specified <remark>destinations</remark> with its level as Error
        /// </summary>
        /// <param name="message">String to log</param>
        /// <param name="destinations">Destinations to log</param>
        void LogError(string message, params LogDestination[] destination);

        /// <summary>
        /// Method for writing to the specified <remark>destinations</remark> with the specified <remark>level</remark>
        /// </summary>
        /// <param name="message">String to log</param>
        /// <param name="level">Level for logging</param>
        /// <param name="destinations">Destinations to log</param>
        void LogMessage(string message, LogLevel level, params LogDestination[] destination);
    }
}
