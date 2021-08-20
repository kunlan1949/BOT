using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Data.Modules;
using Mirai.Net.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mirai.Net.Utils.Extensions;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Utils.Extensions.Actions;
using BOT.Helper;

namespace BOT.Module
{
    public class TestModule : IModule
    {
        public bool? IsEnable { get; set; }

        public async void Execute(MessageReceiverBase @base,MessageBase executeMessage)
        {
            if (@base is GroupMessageReceiver receiver)
            {
                foreach (var message in receiver.MessageChain.WhereAndCast<PlainMessage>())
                {
                    
                    Console.WriteLine("message=" + message.Text);
                    var m = ParseHelper.GroupCommandAsync(message.Text,0,receiver);
                    if (m.Result != null)
                    {
                        Console.WriteLine($"指令发送:【{m.Result.CommandType}】【{m.Result.Target}】【{m.Result.Params}】");
                    }
                    else
                    {
                        Console.WriteLine($"{message.Text}");
                    }
                }
                //await receiver.SendGroupMessage("Hello, World".Append());
            }
        }
    }
}
