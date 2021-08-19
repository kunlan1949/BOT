using Mirai.Net.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BOT
{
    class Init
    {
        public static MiraiBot Instance()
        {
            var bot = new MiraiBot
            {
                Address = "localhost:8080",
                QQ = 1432119304,
                VerifyKey = "2048437217"
            };
            if (bot == null)
            {
                lock (bot)
                {
                    if (bot == null)
                    {
                        Thread.Sleep(10000);
                        Console.WriteLine("被创建");
                        new MiraiBot
                        {
                            Address = "localhost:8080",
                            QQ = 1432119304,
                            VerifyKey = "2048437217"
                        };
                    }
                    else
                        Console.WriteLine("路过");
                }
            }
            return bot;
        }
    }
}
