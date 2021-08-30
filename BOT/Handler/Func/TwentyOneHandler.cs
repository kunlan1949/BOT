using BOT.Model;
using BOT.Module.Send;
using BOT.Utils;
using Db.Bot;
using Mirai.Net.Data.Messages.Receivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Handler.Func
{
    class TwentyOneHandler
    {
        public static async Task startAsync(Members mem, Groups g, CommandAttribute command, GroupMessageReceiver messageReceiver)
        {
            var t = Twentyone.Find(Twentyone._.ToFinish == 0 & Twentyone._.ToGroup==g.GrpId);
            if (t == null)
            {
                if(command.Target !=null && command.Target != "" && RegUtil.IsUint(command.Target))
                {
                    var pNum = int.Parse(command.Target);
                    if(pNum <= 4)
                    {
                        if (pNum >= 2)
                        {
                            var nt = new Twentyone();
                            nt.BankerInitCard = 
                        }
                        else
                        {
                            await SendGroupMessageModule.sendGroupAsync(messageReceiver, "至少需要两名玩家!");
                        }
                    }
                    else
                    {
                        await SendGroupMessageModule.sendGroupAsync(messageReceiver, "最多四名玩家!");
                    }
                }
                else
                {
                    await SendGroupMessageModule.sendGroupAsync(messageReceiver, "参数输入不正确，请输入正确格式!");
                }
            }
            else
            {
                await SendGroupMessageModule.sendGroupAsync(messageReceiver, "已存在二十一点对局，请等待结束后再开新局!");
            }
        }
    }
}
