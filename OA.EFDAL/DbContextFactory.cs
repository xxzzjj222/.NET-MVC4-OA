using OA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace OA.EFDAL
{
    public class DbContextFactory
    {
        public static DbContext GetCurrentDbContext()
        {
            DbContext dbContext=CallContext.GetData("DbContainer") as DbContext;
            if (dbContext == null)
            {
                dbContext = new DbContainer();
                CallContext.SetData("DbContainer", dbContext);
            }
            return dbContext;
        }
    }
}
