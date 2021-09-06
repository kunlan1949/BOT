using BOT.Module.Send;
using BOT.Utils;
using Db.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Model
{
    class DelayMission
    {
        public enum Type{
            Lottery
        }; 

        public static void lattery()
        {
            var l = LotteryTicket.Find(LotteryTicket._.LeFinish == 0);
            if (l != null)
            {
                //先公布
                var gl = Groups.FindAll(Groups._.GrpLottery == "1");
                if (gl != null)
                {
                    var result = UtilHelper.RandomGen(10, true, false, false);
                    var resultList = result.ToList();

                    foreach (var g in gl)
                    {
                        SendGroupMessageModule.PostMessageAsync(g.GrpId, $"大乐透开奖结果:【{resultList[0]}】【{resultList[1]}】【{resultList[2]}】【{resultList[3]}】 " +
                            $"【{resultList[4]}】【{resultList[5]}】【{resultList[6]}】*【{resultList[7]}】【{resultList[8]}】【{resultList[9]}】\n" +
                            "大家中奖了吗？快来领取你的大乐透奖励吧!");
                    }
                    
                    l.LeOpen = 1;
                    l.LeFinish = 1;
                    l.LeResult = result;
                    l.Update();

                    var ticket = new LotteryTicket();
                    ticket.LeFinish = 0;
                    ticket.LeSn = UtilHelper.RandomGen(4, true, true, true);
                    ticket.LeId = UtilHelper.RandomGen(12, true, true, false);
                    ticket.Insert();
                }
            }
            else
            {
                var ticket = new LotteryTicket();
                ticket.LeFinish = 0;
                l.LeOpen = 0;
                l.LeBet = 1;
                ticket.LeSn = UtilHelper.RandomGen(4, true, true, true);
                ticket.LeId = UtilHelper.RandomGen(12, true, true, false);
                ticket.Insert();
            }
        }
    }
}
