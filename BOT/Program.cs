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
using BOT.Module.Event;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace BOT
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Application code should start here.

            //string message = "/exec -arg mm";
            //var parse = CommandParse.Parse(message);
            //Console.WriteLine(parse.First().Key);
            var bot = Init.Instance();

            await bot.Launch().ContinueWith((e) => {
                Console.WriteLine("启动成功");
            });

            var modules = CommandUtilities
                .LoadCommandModules("BOT.Module")
                .ExcludeDisabledModules()
                .ToList();
            var groupMessage = new GroupMessageModule();
            var newFriendRequested = new NewFriendRequestedModule();
            //传播订阅到模块
            bot.MessageReceived
                .WhereAndCast<GroupMessageReceiver>()
                .Subscribe(x =>
                {
                    groupMessage.Execute(x, x.MessageChain.First());
                });

            bot.EventReceived.Where(x => x.Type == Events.NewFriendRequested)
            .Cast<NewFriendRequestedEvent>().Subscribe(x =>
            {
                newFriendRequested.Execute(x);
            });
            bot.EventReceived.Where(x => x.Type == Events.NewInvitationRequested)
            .Cast<NewInvitationRequestedEvent>().Subscribe(x =>
            {
                //do things
            });


            using IHost host = CreateHostBuilder(args).Build();

            await host.RunAsync();
        }
        static IHostBuilder CreateHostBuilder(string[] args) =>
                    Host.CreateDefaultBuilder(args)
                        .ConfigureAppConfiguration((hostingContext, configuration) =>
                        {
                            configuration.Sources.Clear();

                            IHostEnvironment env = hostingContext.HostingEnvironment;

                            configuration
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);

                            IConfigurationRoot configurationRoot = configuration.Build();

                            TransientFaultHandlingOptions options = new();
                            configurationRoot.GetSection(nameof(TransientFaultHandlingOptions))
                                             .Bind(options);

                            Console.WriteLine($"TransientFaultHandlingOptions.Enabled={options.Enabled}");
                            Console.WriteLine($"TransientFaultHandlingOptions.AutoRetryDelay={options.AutoRetryDelay}");
                        });

        //static async Task Main(string[] args)
        //{

        //}
    }
}
