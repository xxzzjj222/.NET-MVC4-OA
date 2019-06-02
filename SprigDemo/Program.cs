using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spring.Context;
using Spring.Context.Support;

namespace SprigDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            IApplicationContext ctx = ContextRegistry.GetContext();
            IUserInfo UserInfo = ctx.GetObject("UserInfoXML") as IUserInfo;
            UserInfo.Show();
            Console.ReadKey();
        }
    }
}
