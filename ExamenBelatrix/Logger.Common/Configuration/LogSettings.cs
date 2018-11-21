using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Common.Configuration
{
    public class LogSettings : ConfigurationSection
    {
        private static LogSettings settings;

        [ConfigurationProperty("level")]
        public LogLevel Level
        {
            get { return (LogLevel)base["level"]; }
        }

        [ConfigurationProperty("TextLog")]
        public TextLogSettings TextLog
        {
            get { return (TextLogSettings)base["TextLog"]; }
        }

        [ConfigurationProperty("DatabaseLog")]
        public DatabaseLogSettings DatabaseLog
        {
            get { return (DatabaseLogSettings)base["DatabaseLog"]; }
        }

        public static LogSettings GetSettings()
        {
            if (settings == null)
            {
                settings = ConfigurationManager.GetSection("CustomLog") as
                            LogSettings;
                if (settings == null)
                {
                    throw new ConfigurationErrorsException("The <CustomLog> section is not defined in your .config file");
                }
            }
            return settings;
        }
    }
}
