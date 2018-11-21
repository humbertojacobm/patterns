using Logger.Common;
using Logger.CustomLog.Strategies;
using Logger.DAL;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Test.CustomLog.Strategies
{
    [TestFixture]
    public class DatabaseLogStrategyTest
    {
        private DatabaseLogStrategy databaseLogStrategy;
        private ILoggerDAO loggerDAO;

        [OneTimeSetUp]
        public void SetUp()
        {
            loggerDAO = Substitute.For<ILoggerDAO>();
            databaseLogStrategy = new DatabaseLogStrategy(loggerDAO);
        }

        [Test]
        public void LogToDatabase()
        {
            databaseLogStrategy.LogMessage("This is a message.", LogLevel.Message);
            loggerDAO.Received().Save(Arg.Any<string>(), Arg.Any<string>());
        }

        [Test]
        public void LogToDatabaseMoreThanOnce()
        {
            loggerDAO.ClearReceivedCalls();
            databaseLogStrategy.LogMessage("This is a message 1.", LogLevel.Message);
            databaseLogStrategy.LogMessage("This is a message 2.", LogLevel.Message);
            loggerDAO.Received().Save(Arg.Any<string>(), Arg.Any<string>());
        }
    }
}
