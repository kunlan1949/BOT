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
using BOT.Module.Message;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Mirai.Net.Sessions.Http.Concretes;
using BOT.Action;
using BOT.Utils;

namespace BOT
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //string message = "/exec -arg mm";
            //var parse = CommandParse.Parse(message);
            //Console.WriteLine(parse.First().Key);

            using IHost host = CreateHostBuilder(args).Build();
            
            var cc=ConfigHelper.GetInfo();

            Console.WriteLine($"Number={cc.Number}");
            Console.WriteLine($"VerifyKey={cc.VerifyKey}");



            using var bot = new MiraiBot
            {
                Address = cc.Address,
                QQ = long.Parse(cc.Number),
                VerifyKey = cc.VerifyKey
            };

            await bot.Launch().ContinueWith((e) => {
                Console.WriteLine("启动成功");

            });

            //var modules = CommandUtilities
            //    .LoadCommandModules("BOT.Module")
            //    .ExcludeDisabledModules()
            //    .ToList();
            var groupMsg = new GroupMessageModule();
            var friendMsg = new FriendMessageModule();
            ///消息处理
            ///
            ///好友消息
            bot.MessageReceived
               .WhereAndCast<FriendMessageReceiver>()
               .Subscribe(x =>
               {
                   friendMsg.Execute(x, x.MessageChain.First());
               });

            ///群聊消息
            bot.MessageReceived
                .WhereAndCast<GroupMessageReceiver>()
                .Subscribe(x =>
                {
                    groupMsg.Execute(x, x.MessageChain.First());
                });

            ///事件处理
            ///
            ///加好友请求
            bot.EventReceived.Where(x => x.Type == Events.NewFriendRequested)
            .Cast<NewFriendRequestedEvent>().Subscribe(x =>
            {

            });

            ///被邀请入群申请
            bot.EventReceived.Where(x => x.Type == Events.NewInvitationRequested)
            .Cast<NewInvitationRequestedEvent>().Subscribe(x =>
            {

            });

            //TimerAction.LatteryOpen();

            await host.RunAsync();
        }
        static IHostBuilder CreateHostBuilder(string[] args) =>
                    Host.CreateDefaultBuilder(args)
                        .ConfigureAppConfiguration(async (hostingContext, configuration) =>
                        {
                            configuration.Sources.Clear();

                            IHostEnvironment env = hostingContext.HostingEnvironment;

                            configuration
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);

                            IConfigurationRoot configurationRoot = configuration.Build();

                            
                        });

    }
}
