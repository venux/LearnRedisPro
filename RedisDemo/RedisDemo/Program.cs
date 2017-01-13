using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer connection = RedisHelper.Connection;

            bool isConnected = connection != null;
            Console.WriteLine("是否连接成功：{0}", isConnected == true ? "是" : "否");

            IDatabase database = connection.GetDatabase();
            
            if (database.StringSet("testkey1", "testvalue1", new TimeSpan(1000), When.NotExists, CommandFlags.None))
                Console.WriteLine("已成功添加键！");

            string value = database.StringGet("tesetkey1");
            Console.WriteLine("键testkey1的值为：" + value);

            Console.ReadLine();
        }


    }
}
