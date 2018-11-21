using Logger.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.DAL
{
    public class LoggerDAO : ILoggerDAO
    {
        private const string MessageColumn = "ApplicationLogMessage";
        private const string LevelColumn = "LogLevel";

        private readonly string databaseKey;
        private Database db;

        public LoggerDAO()
        {
            this.databaseKey = LogSettings.GetSettings().DatabaseLog.DatabaseLogKey;
            SetUpDAO();
        }

        public LoggerDAO(string databaseKey)
        {
            this.databaseKey = databaseKey;
            SetUpDAO();
        }

        private void SetUpDAO()
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(databaseKey);
        }

        public void Save(string message, string level)
        {
            const string SaveLogProcedure = "ApplicationLogInsert";
            using(DbCommand command = db.GetStoredProcCommand(SaveLogProcedure))
            {
                db.AddInParameter(command, MessageColumn, System.Data.DbType.String, message);
                db.AddInParameter(command, LevelColumn, System.Data.DbType.String, level);
                db.ExecuteNonQuery(command);
            }
        }
    }
}
