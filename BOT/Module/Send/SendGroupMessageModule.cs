using BOT.Actions;
using BOT.Model;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Sessions;
using Mirai.Net.Sessions.Http.Concretes;
using Mirai.Net.Utils;
using Mirai.Net.Utils.Extensions;
using Mirai.Net.Utils.Extensions.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Module.Send
{
    class SendGroupMessageModule
    {
        public static async void Executed(string group,string msg)
        {
            TimeConsumingCounter tcc = new TimeConsumingCounter();
            tcc.Start();
            await MiraiBotFactory.Bot
                .GetManager<MessageManager>()
                .SendGroupMessage(group, "".Append(msg)).ContinueWith((e) => {
                    tcc.Over();
                    Console.WriteLine("发送耗时" + tcc.Span());
                }); ;
        }


        public static async Task sendGroupAtAsync(GroupMessageReceiver receiver, string msg, bool atMsgPosition)
        {
            TimeConsumingCounter tcc = new TimeConsumingCounter();
            tcc.Start();
            if (atMsgPosition)
            {
                await receiver.SendGroupMessage($"".Append(new AtMessage(receiver.Sender.Id)).Append(msg)).ContinueWith((e) => {
                    tcc.Over();
                    Console.WriteLine("发送耗时" + tcc.Span());
                });
            }
            else
            {
                await receiver.SendGroupMessage($"".Append(msg).Append(new AtMessage(receiver.Sender.Id))).ContinueWith((e) => {
                    tcc.Over();
                    Console.WriteLine("发送耗时" + tcc.Span());
                });
            }

        }

        public static async Task sendGroupAtAsync(GroupMessageReceiver receiver, MessageBase[] msg, bool atMsgPosition)
        {
            TimeConsumingCounter tcc = new TimeConsumingCounter();
            tcc.Start();
            if (atMsgPosition)
            {
                await receiver.SendGroupMessage(msg).ContinueWith((e) => {
                    tcc.Over();
                    Console.WriteLine("发送耗时" + tcc.Span());
                });
            }
            else
            {
                await receiver.SendGroupMessage($"".Append(msg).Append(new AtMessage(receiver.Sender.Id))).ContinueWith((e) => {
                    tcc.Over();
                    Console.WriteLine("发送耗时" + tcc.Span());
                });
            }

        }
    }
}
