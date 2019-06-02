using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprigDemo
{
    public class UserInfo:IUserInfo
    {
        public void Show()
        {
            Console.WriteLine("你好");
        }
    }
}
