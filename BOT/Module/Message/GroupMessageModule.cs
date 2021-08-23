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
using Mirai.Net.Sessions;
using Mirai.Net.Sessions.Http.Concretes;
using BOT.Model;
using BOT.Module.Send;
using BOT.Handler;

namespace BOT.Module
{
    public class GroupMessageModule
    {

        public void Execute(MessageReceiverBase @base,MessageBase executeMessage)
        {
            if (@base is GroupMessageReceiver receiver)
            {
                
                foreach (var message in receiver.MessageChain.WhereAndCast<PlainMessage>())
                {
                    Console.WriteLine("message=" + message.Text);
                    var m = ParseHelper.GroupCommandAsync(message.Text,receiver);
                    if (m.Result != null)
                    {
                        Console.WriteLine($"指令发送:【{m.Result.CommandType}】【{m.Result.Target}】【{m.Result.Params}】");
                        if (m.Result.CommandType.Contains(CommandType.BOT))
                        {
                            Console.WriteLine("互动模式");
                            InteractHandler.CommandAsync(m.Result, receiver, false);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{message.Text}");
                        var i = receiver.MessageChain.WhereAndCast<ImageMessage>();
                        if (i.Length>0)
                        {
                            Console.WriteLine(i[0].Url);
                        }

                    }
                }
                //await receiver.SendGroupMessage("Hello, World".Append());
            }
        }
    }
}
