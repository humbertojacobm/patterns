using Logger.Common;
using Logger.CustomLog.Strategies;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Logger.Test.CustomLog.Strategies
{
    [TestFixture]
    public class TextLogStrategyTest
    {
        private TextLogStrategy textLogStrategy;
        private string fullPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "tmp", "Log.log");
        private string maxSize = "1 KB";

        [OneTimeSetUp]
        public void SetUp()
        {
            textLogStrategy = new TextLogStrategy(fullPath, maxSize);
        }

        [Test]
        public void WriteToTextFile()
        {
            string messageToLog = "This is a message.";
            textLogStrategy.LogMessage(messageToLog, LogLevel.Error);
            string loggedMessage = File.ReadAllText(fullPath);
            Assert.IsTrue(loggedMessage.Contains(messageToLog));
            File.Delete(fullPath);
        }

        [Test]
        public void MultiWritesToTextFileAtSameTime()
        {
            string messageToLog1 = "This is message 1.";
            string messageToLog2 = "This is message 2.";
            string messageToLog3 = "This is message 3.";
            string messageToLog4 = "This is message 4.";
            string messageToLog5 = "This is message 5.";

            Parallel.Invoke(
                () =>
                {
                    textLogStrategy.LogMessage(messageToLog1, LogLevel.Error);
                },
                () =>
                {
                    textLogStrategy.LogMessage(messageToLog2, LogLevel.Warning);
                },
                () =>
                {
                    textLogStrategy.LogMessage(messageToLog3, LogLevel.Message);
                },
                () =>
                {
                    textLogStrategy.LogMessage(messageToLog4, LogLevel.Warning);
                },
                () =>
                {
                    textLogStrategy.LogMessage(messageToLog5, LogLevel.Error);
                }
            );
            string loggedMessage = File.ReadAllText(fullPath);
            Assert.IsTrue(loggedMessage.Contains(messageToLog1));
            Assert.IsTrue(loggedMessage.Contains(messageToLog2));
            Assert.IsTrue(loggedMessage.Contains(messageToLog3));
            Assert.IsTrue(loggedMessage.Contains(messageToLog4));
            Assert.IsTrue(loggedMessage.Contains(messageToLog5));
        }

        [Test]
        public void ValidateNewLogCreationOnMaxSize()
        {
            var auxMessage = new string('A', 1024);
            var realMessage = "This is a real message.";
            textLogStrategy.LogMessage(auxMessage, LogLevel.Message);
            textLogStrategy.LogMessage(realMessage, LogLevel.Message);

            var lastLogText = File.ReadAllText(fullPath);

            Assert.IsFalse(lastLogText.Contains(auxMessage));
            Assert.IsTrue(lastLogText.Contains(realMessage));
        }
    }
}