using BOT.Actions;
using BOT.Actions.Constellation;
using BOT.Model;
using BOT.Model.Game;
using BOT.Module.Send;
using BOT.Utils;
using Db.Bot;
using HtmlAgilityPack;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Handler.Func
{
    class ConstellationHandler
    {
        public static async Task execAsync(Members mem, Groups g, CommandAttribute command, GroupMessageReceiver messageReceiver)
        {
            var c = Constellation.Find(Constellation._.Sign == command.Target);
            if (c!=null)
            {
                if (UtilHelper.ISTODAY(c.UpdateTime))
                {
                    Console.WriteLine("存在，数据库获取");
                    await SendGroupMessageModule.sendGroupAtAsync(messageReceiver, c.LuckResult, true);
                }else
                {
                    Console.WriteLine("过时，网页重新获取");
                    var m = dic(command.Target);

                    var result = "";
                    var web = new HtmlWeb();
                    var htmlDocument = ConstellationParse.MainParseAsync().Result;
                    var parse = ConstellationParse.Parse((SignModel.Sign)m);
                    result = ConstellationParse.luckResultAsync(parse, htmlDocument).Result;

                    await SendGroupMessageModule.sendGroupAtAsync(messageReceiver, result, true);
                    c.LuckResult = result;
                    c.UpdateTime = UtilHelper.GetUTCTimeUnix().ToString();
                    c.Update();
                }
            }
            else
            {
                Console.WriteLine("不存在，网页获取");
                var m = dic(command.Target);

                var result = "";
                var web = new HtmlWeb();
                var htmlDocument = ConstellationParse.MainParseAsync().Result;
                var parse = ConstellationParse.Parse((SignModel.Sign)m);
                result = ConstellationParse.luckResultAsync(parse, htmlDocument).Result;
                await SendGroupMessageModule.sendGroupAtAsync(messageReceiver, result, true);
                var nc = new Constellation();
                nc.Sign = command.Target;
                nc.LuckResult = result;
                nc.UpdateTime = UtilHelper.GetUTCTimeUnix().ToString();
                nc.Insert();
            }
        }

        private static int dic(string target)
        {
            var value = 0;
            if (TargetType.Sign.ContainsKey(target))
            {
                value = TargetType.Sign[target];
            }
            else
            {
                value = TargetType.Sign[target];
            }
            return value;
        }

        
    }
}
