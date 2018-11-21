using Logger.Common;
using Logger.Core;
using Logger.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Logger.CustomLog.Strategies
{
    public class DatabaseLogStrategy : ILogStrategy
    {
        private readonly ILoggerDAO loggerDAO;

        public DatabaseLogStrategy(ILoggerDAO loggerDAO)
        {
            this.loggerDAO = loggerDAO;
        }

        public void LogMessage(string message, LogLevel level)
        {
            using(TransactionScope ts = new TransactionScope())
            {
                loggerDAO.Save(message, level.GetDescription());
                ts.Complete();
            }
        }
    }
}
