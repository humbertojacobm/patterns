using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Common.Configuration
{
    public class TextLogSettings : ConfigurationElement
    {
        [ConfigurationProperty("path", IsRequired = true)]
        public string Path
        {
            get { return base["path"].ToString(); }
        }

        [ConfigurationProperty("maxSize", IsRequired = true)]
        public string MaxSize
        {
            get { return base["maxSize"].ToString(); }
        }
    }
}
