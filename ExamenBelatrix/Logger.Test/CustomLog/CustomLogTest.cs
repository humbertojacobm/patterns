using Logger.Common;
using Logger.Core;
using Logger.CustomLog;
using NSubstitute;
using NUnit.Framework;
using System;


namespace Logger.Test.CustomLog
{
    [TestFixture]
    public class CustomLogTest
    {
        ILog log;
        ILogFactory factory;
        ILogger logger;

        [OneTimeSetUp]
        public void SetUp()
        {
            logger = Substitute.For<ILogger>();
            factory = Substitute.For<ILogFactory>();
            factory.GetLog(Arg.Any<LogDestination>()).Returns(logger);
            log = new Logger.CustomLog.CustomLog(factory);
        }

        [Test]
        public void LogToOneDestination()
        {
            log.LogMessage("This is a test", LogLevel.Message, LogDestination.Console);
            factory.Received().GetLog(Arg.Any<LogDestination>());
            logger.Received().LogMessage(Arg.Any<string>(), Arg.Any<LogLevel>());
        }

        [Test]
        public void LogToAllDestinations()
        {
            ResetReceivedCalls();
            log.LogMessage("This is a test", LogLevel.Message, LogDestination.Console, LogDestination.Database, LogDestination.TextFile);
            factory.Received(3).GetLog(Arg.Any<LogDestination>());
            logger.Received(3).LogMessage(Arg.Any<string>(), Arg.Any<LogLevel>());
        }

        [Test]
        public void LogToAllDestinationsWithRepetitions()
        {
            ResetReceivedCalls();
            log.LogMessage("This is a test", LogLevel.Message, LogDestination.Console, LogDestination.Console, LogDestination.Database, LogDestination.Database, LogDestination.TextFile, LogDestination.TextFile, LogDestination.Console, LogDestination.Database, LogDestination.TextFile);
            factory.Received(3).GetLog(Arg.Any<LogDestination>());
            logger.Received(3).LogMessage(Arg.Any<string>(), Arg.Any<LogLevel>());
        }

        private void ResetReceivedCalls()
        {
            factory.ClearReceivedCalls();
            logger.ClearReceivedCalls();
        }
    }
}
