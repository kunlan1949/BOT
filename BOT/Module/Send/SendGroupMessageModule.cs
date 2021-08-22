using BOT.Model;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Sessions;
using Mirai.Net.Sessions.Http.Concretes;
using Mirai.Net.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Module.Send
{
    class SendGroupMessageModule
    {
        public async void Executed(MiraiBot bot, MessageBase messageBase, MessageReceiverBase receiver)
        {
            if (receiver is GroupMessageReceiver groupMessage)
            {
                var mgr = bot.GetManager<MessageManager>();

               // await mgr.SendGroupMessage(groupMessage.Sender.Group.Id, "".Append(new AtMessage(groupMessage.Sender.Id)).Append(ErrorBackInfo.ErrorBack(commandType)));
            }
        }
    }
}
