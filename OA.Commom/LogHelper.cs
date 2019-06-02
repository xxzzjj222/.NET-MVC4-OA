﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OA.Commom
{
    public class LogHelper
    {
        public static Queue<string> ExceptionStringQueue = new Queue<string>();
        public static List<ILogWriter> LogWriteList;
        public LogHelper()
        {
            ThreadPool.QueueUserWorkItem(o=>{
                while (true)
                {
                    lock (ExceptionStringQueue)
                    {
                        string exceptionText = ExceptionStringQueue.Dequeue();
                        foreach (ILogWriter item in LogWriteList)
                        {
                            item.WriteLogInfo(exceptionText);
                        }
                    }
                }
            });
        }

        public static void WriteLog(string exceptionText)
        {
            lock (ExceptionStringQueue)
            {
                ExceptionStringQueue.Enqueue(exceptionText);
            }
        }
    }
}
