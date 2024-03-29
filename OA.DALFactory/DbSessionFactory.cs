﻿using OA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace OA.DALFactory
{
    public class DbSessionFactory
    {
         public static IDbSession GetCurrentDbSession()
        {
            IDbSession dbSession=CallContext.GetData("DbSession") as IDbSession;
            if (dbSession == null)
            {
                dbSession=new DbSession();
                CallContext.SetData("DbSession", dbSession);
            }
            return dbSession;
        }
    }
}
