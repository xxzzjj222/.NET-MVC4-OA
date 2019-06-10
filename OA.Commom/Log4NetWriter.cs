using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Commom
{
    public class Log4NetWriter:ILogWriter
    {
        public void WriteLogInfo(string str)
        {
            ILog LogWriter = log4net.LogManager.GetLogger("Demo");
            LogWriter.Error(str);
        }
    }
}
