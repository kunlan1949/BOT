using BOT.Actions.Trans;
using BOT.Helper;
using BOT.Model;
using BOT.Module.Send;
using Db.Bot;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Utils.Scaffolds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Handler.Func
{
    class TranslateHandler
    {
        public static async Task execAsync(Members mem, Groups g, CommandAttribute command, GroupMessageReceiver messageReceiver)
        {
            if(command.Target!=null && command.Target != "")
            {
                string result = TranslateAction.GetTranslate(command.Target);
                MessageBase[] msg = { };
                msg = ""
                    .Append("\n【翻译来源：有道翻译】\n")
                    .Append($"[翻译原文]：{command.Target}\n[翻译结果]：{result}\n");
                await SendGroupMessageModule.sendGroupAtAsync(messageReceiver, msg,true);

            }
            else
            {
                await SendGroupMessageModule.sendGroupAsync(messageReceiver, "输入的指令错误！请检查后重试");
            }
        }
    }
}
