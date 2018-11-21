using Logger.Core;
using Logger.CustomLog;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Test.CustomLog
{
    [TestFixture]
    public class LoggersTest
    {
        [Test]
        public void CheckLogAtErrorLevel()
        {
            var strategy = Substitute.For<ILogStrategy>();

            var logger = new ConsoleLogger(Common.LogLevel.Error, strategy);

            logger.LogMessage("Testing level", Common.LogLevel.Error);
            logger.LogMessage("Testing level", Common.LogLevel.Message);
            logger.LogMessage("Testing level", Common.LogLevel.Warning);
            strategy.Received().LogMessage(Arg.Any<String>(), Arg.Is<Common.LogLevel>(Common.LogLevel.Error));
            strategy.DidNotReceive().LogMessage(Arg.Any<String>(), Arg.Is<Common.LogLevel>(Common.LogLevel.Warning));
            strategy.DidNotReceive().LogMessage(Arg.Any<String>(), Arg.Is<Common.LogLevel>(Common.LogLevel.Message));
        }

        [Test]
        public void CheckLogAtWarningLevel()
        {
            var strategy = Substitute.For<ILogStrategy>();
            var logger = new ConsoleLogger(Common.LogLevel.Warning, strategy);

            logger.LogMessage("Testing level", Common.LogLevel.Error);
            logger.LogMessage("Testing level", Common.LogLevel.Message);
            logger.LogMessage("Testing level", Common.LogLevel.Warning);
            strategy.Received().LogMessage(Arg.Any<String>(), Arg.Is<Common.LogLevel>(Common.LogLevel.Error));
            strategy.Received().LogMessage(Arg.Any<String>(), Arg.Is<Common.LogLevel>(Common.LogLevel.Warning));
            strategy.DidNotReceive().LogMessage(Arg.Any<String>(), Arg.Is<Common.LogLevel>(Common.LogLevel.Message));
        }

        [Test]
        public void CheckLogAtMessageLevel()
        {
            var strategy = Substitute.For<ILogStrategy>();

            var logger = new ConsoleLogger(Common.LogLevel.Message, strategy);

            logger.LogMessage("Testing level", Common.LogLevel.Error);
            logger.LogMessage("Testing level", Common.LogLevel.Message);
            logger.LogMessage("Testing level", Common.LogLevel.Warning);
            strategy.Received().LogMessage(Arg.Any<String>(), Arg.Is<Common.LogLevel>(Common.LogLevel.Error));
            strategy.Received().LogMessage(Arg.Any<String>(), Arg.Is<Common.LogLevel>(Common.LogLevel.Warning));
            strategy.Received().LogMessage(Arg.Any<String>(), Arg.Is<Common.LogLevel>(Common.LogLevel.Message));
        }
    }
}
