using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.DAL
{
    public interface ILoggerDAO
    {
        void Save(string message, string level);
    }
}
