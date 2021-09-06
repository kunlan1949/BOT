using BOT.Actions;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Sessions.Http.Managers;
using Mirai.Net.Utils.Scaffolds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Module.Send
{
    class SendFriendMessageModule
    {
        /// <summary>
        /// 推送指定群[字符串]
        /// </summary>
        /// <param name="target">QQ号</param>
        /// <param name="msg">消息</param>
        public static async void PostFriendMessageAsync(string target, string msg)
        {
            TimeConsumingCounter tcc = new TimeConsumingCounter();
            tcc.Start();
            await MessageManager.SendFriendMessageAsync(target, "".Append(msg)).ContinueWith((e) => {
                tcc.Over();
                Console.WriteLine("发送耗时" + tcc.Span());
            }); ;
        }
        /// <summary>
        /// 推送指定群[消息链]
        /// </summary>
        /// <param name="target">QQ号</param>
        /// <param name="msg">消息</param>
        public static async void PostFriendMessageAsync(string target, MessageBase[] msg)
        {
            TimeConsumingCounter tcc = new TimeConsumingCounter();
            tcc.Start();
            await MessageManager.SendFriendMessageAsync(target, msg).ContinueWith((e) => {
                tcc.Over();
                Console.WriteLine("发送耗时" + tcc.Span());
            }); ;
        }

        /// <summary>
        /// 发送普通消息，接收字符串格式
        /// </summary>
        /// <param name="receiver">群接收</param>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public static async Task sendFriendAsync(FriendMessageReceiver receiver, string msg)
        {
            TimeConsumingCounter tcc = new TimeConsumingCounter();
            tcc.Start();
            await receiver.SendFriendMessageAsync($"".Append(msg)).ContinueWith((e) => {
                tcc.Over();
                Console.WriteLine("发送耗时" + tcc.Span());
            });
        }
        /// <summary>
        /// 发送普通消息，接收消息链格式
        /// </summary>
        /// <param name="receiver">群接收</param>
        /// <param name="msg">消息</param>
        /// <returns></returns>

        public static async Task sendFriendAsync(FriendMessageReceiver receiver, MessageBase[] msg)
        {
            TimeConsumingCounter tcc = new TimeConsumingCounter();
            tcc.Start();
            await receiver.SendFriendMessageAsync(msg).ContinueWith((e) => {
                tcc.Over();
                Console.WriteLine("发送耗时" + tcc.Span());
            });
        }
    }
}
