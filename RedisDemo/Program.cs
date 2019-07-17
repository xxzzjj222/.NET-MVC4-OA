using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;
using System.Threading;
using Newtonsoft.Json;

namespace RedisDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = RedisManager.GetClient();
            HashSet<string> s = new HashSet<string>();
            s.Add("aa");
            s.Add("bb");
            foreach (var item in s)
            {
                Console.WriteLine(item);
            }
            ////排序集合
            //client.AddItemToSortedSet("u", "user1", 4);
            //client.AddItemToSortedSet("u", "user2", 3);
            //client.AddItemToSortedSet("u3", "user3", 2);

            //var list = client.GetRangeFromSortedSet("u", 0, 1);
            ////var list = client.GetRangeFromSortedSetDesc("u", 0, 1);
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}

            //client.Set<string>("u1", "nihao", DateTime.Now.AddMinutes(20));
            //var aa=client.Get<string>("u1");

            //client.EnqueueItemOnList("q1", "q11");
            //client.EnqueueItemOnList("q1", "q22");
            //for (int i = 0; i < client.GetListCount("q1"); i++)
            //{
            //    Console.WriteLine(client.DequeueItemFromList("q1"));
            //}

            //client.PushItemToList("w1", "w11");
            //client.PushItemToList("w1", "w22");
            //for (int i = 0; i < client.GetListCount("w1"); i++)
            //{
            //    Console.WriteLine(client.PopItemFromList("w1"));
            //}
            //Thread t1 = new Thread(Run);
            //t1.Start();
            //Thread t2 = new Thread(Get);
            //t2.Start();
            //for(int i=0;i<10;i++)
            //{
            //    client.SetEntryInHash("hash","test"+i,ServiceStack.Text.JsonSerializer.SerializeToString(new {
            //        id=i+1,
            //        name="xzj"+(i+1)
            //    }));
            //}
            //List<string> hashval = client.GetHashValues("hash");
            //Console.WriteLine(client.GetValueFromHash("hash","test1"));
            //foreach (var item in hashval)
            //{
            //    Console.WriteLine(item);
            //}
            Console.ReadKey();
        }
        public static void Run()
        {
            IRedisClient redisClient = RedisManager.GetClient();
            while (true)
            {
                redisClient.EnqueueItemOnList("queue", DateTime.Now.ToString());
                Thread.Sleep(1000);
            }
        }

        public static void Get()
        {
            IRedisClient redisClient = RedisManager.GetClient();
            while (true)
            {
                if (redisClient.GetListCount("queue") > 0)
                {
                    Console.WriteLine(redisClient.DequeueItemFromList("queue"));
                }
            }
        }
    }
}
