using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Common.Configuration
{
    public class DatabaseLogSettings : ConfigurationElement
    {
        [ConfigurationProperty("databaseLogKey", IsRequired = true)]
        public string DatabaseLogKey
        {
            get { return this["databaseLogKey"].ToString(); }
        }
    }
}
