﻿using BOT.Model;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Sessions;
using Mirai.Net.Sessions.Http.Concretes;
using Mirai.Net.Utils;
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
        public static async void Executed(string group,string msg)
        {
            await MiraiBotFactory.Bot
                .GetManager<MessageManager>()
                .SendGroupMessage(group, "".Append(msg));
        }
    }
}
