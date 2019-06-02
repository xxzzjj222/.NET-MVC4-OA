using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Commom
{
    public interface ILogWriter
    {
        void WriteLogInfo(string str);
    }
}
