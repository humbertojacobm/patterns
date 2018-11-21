using Logger.CustomLog;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Test.CustomLog
{
    [TestFixture]
    public class CustomLogFactoryTest
    {
        private CustomLoggerFactory factory;

        [OneTimeSetUp]
        public void SetUp()
        {
            factory = new CustomLoggerFactory();
        }

        [Test]
        public void ReturnConsoleLog()
        {
            var log = factory.GetLog(Core.LogDestination.Console);
            Assert.IsInstanceOf<ConsoleLogger>(log);
        }

        [Test]
        public void ReturnTextFileLog()
        {
            var log = factory.GetLog(Core.LogDestination.TextFile);
            Assert.IsInstanceOf<TextLogger>(log);
        }

        [Test]
        public void ReturnDatabaseLog()
        {
            var log = factory.GetLog(Core.LogDestination.Database);
            Assert.IsInstanceOf<DatabaseLogger>(log);
        }

        [Test]
        public void InvalidLog()
        {
            TestDelegate getLog = () => {
                var log = factory.GetLog(0);
            };
            Assert.Throws<NotImplementedException>(getLog);
        }
    }
}
