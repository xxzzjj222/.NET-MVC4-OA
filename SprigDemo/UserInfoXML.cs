using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprigDemo
{
    public class UserInfoXML:IUserInfo
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public UserInfoXML(int age)
        {
            this.Age = age;
        }
        public void Show()
        {
            Console.WriteLine("XML"+Name+Age);
        }
    }
}
