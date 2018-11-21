﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Core
{
    public interface ILogFactory
    {
        ILogger GetLog(LogDestination destination);
    }
}