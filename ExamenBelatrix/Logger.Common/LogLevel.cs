using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Common
{
    public enum LogLevel
    {
        [Description("MESSAGE")]
        Message = 1,
        [Description("WARNING")]
        Warning = 2,
        [Description("ERROR")]
        Error = 3
    }
}
