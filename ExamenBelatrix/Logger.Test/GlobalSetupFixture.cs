using NUnit.Framework;
using System;
using System.IO;

namespace Logger.Test
{
    [SetUpFixture]
    public class GlobalSetupFixture
    {
        private string fullPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "tmp");

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            if (!Directory.Exists(fullPath)) {
                Directory.CreateDirectory(fullPath);
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            if (Directory.Exists(fullPath))
            {
                Directory.Delete(fullPath, true);
            }
        }
    }
}