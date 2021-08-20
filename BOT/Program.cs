using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Sessions;
using Mirai.Net.Utils;
using System;
using System.Threading.Tasks;
using Mirai.Net.Utils.Extensions;
using System.Linq;
using BOT.Helper;
using BOT.Module;
using Mirai.Net.Data.Events.Concretes.Request;
using System.Reactive.Linq;
using Mirai.Net.Data.Events;

namespace BOT
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //string message = "/exec -arg mm";
            //var parse = CommandParse.Parse(message);
            //Console.WriteLine(parse.First().Key);
            var bot = Init.Instance();

            await bot.Launch().ContinueWith((e)=>{
                Console.WriteLine("启动成功");
            });

            var modules = CommandUtilities
                .LoadCommandModules("BOT.Module")
                .ExcludeDisabledModules()
                .ToList();
            var module1 = new TestModule();
            //传播订阅到模块
            bot.MessageReceived
                .WhereAndCast<GroupMessageReceiver>()
                .Subscribe(x =>
                {
                    module1.Execute(x, x.MessageChain.First());
                });

            bot.EventReceived.Where(x => x.Type == Events.NewFriendRequested)
            .Cast<NewFriendRequestedEvent>().Subscribe(x =>
            {
                //do things
            });
            bot.EventReceived.Where(x => x.Type == Events.NewInvitationRequested)
            .Cast<NewInvitationRequestedEvent>().Subscribe(x =>
            {
                //do things
            });

            while (true)
            {
                if (Console.ReadLine() == "exit")
                {
                    return;
                }
            }
        }
    }
}
