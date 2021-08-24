using BOT.Actions;
using BOT.Model;
using BOT.Model.Game;
using BOT.Utils;
using Db.Bot;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Utils.Extensions;
using Mirai.Net.Utils.Extensions.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Handler
{
    class InteractHandler
    {
        public static async Task<string> CommandAsync(Members mem,Groups g,CommandAttribute command, GroupMessageReceiver messageReceiver, bool exec)
        {
            var exist_m = false;
            if (mem != null)
            {
                exist_m = true;
            }
            else
            {
                exist_m = false;
            }

            if (exist_m)
            {
                #region 存在注册成员
                if (command.CommandType.Contains(CommandType.BOT))
                {
                    if (command.Target.Contains(TargetType.GUSSNUM))
                    {

                        if (!g.GrpGuessnum.Contains("-1"))
                        {
                            if (mem.MemPoint >= 20)
                            {
                                if (g.GrpGuessnum.Contains("1"))
                                {
                                    await sendGroupAsync(messageReceiver, "对局已经存在!请等待结束后再开新局!");
                                }
                                else
                                {
                                    mem.MemPoint = mem.MemPoint - 20;
                                    mem.Update();
                                    g.GrpGuessnum = "1";
                                    g.Update();

                                    var num = UtilHelper.RandomGen(4, true, false, false);
                                    var game = new GamesStatus();
                                    game.GameGroup = messageReceiver.Sender.Group.Id;
                                    game.GameType = "0";
                                    game.GameStatus = "0";
                                    game.GameStarter = messageReceiver.Sender.Id;
                                    game.GameParams = num;
                                    game.GameCount = GameCount.gussNumCount;
                                    game.Insert();
                                    await sendGroupAsync(messageReceiver, "嘿嘿，我已经想好一个4位数字啦，快来猜猜看吧【积分已扣除20】");
                                }
                            }
                            else
                            {
                                await sendGroupAsync(messageReceiver, $"需要20积分，请努力攒够积分吧! \n您的剩余积分【{mem.MemPoint}】");
                            }

                        }
                        else
                        {
                            await sendGroupAsync(messageReceiver, $"游戏{command.CommandType}未开启，请管理员开启后开始游戏");
                        }
                    }
                    else if (command.Target.Contains(TargetType.REGISTER))
                    {
                        var m = Members.Find(Members._.MemQq == messageReceiver.Sender.Id & Members._.MemGroup == messageReceiver.Sender.Group.Id);
                        if (m != null)
                        {
                            await sendGroupAsync(messageReceiver, $"成员已注册！");
                        }
                    }

                }
                #region 我猜
                else if (command.CommandType.Contains(CommandType.IGUSS))
                {
                    if (g.GrpGuessnum.Contains("1"))
                    {
                        var game = GamesStatus.Find(GamesStatus._.GameGroup == g.GrpId);
                        if (game != null)
                        {
                            var count = game.GameCount - 1;
                            if (command.Target.Length == 4 && RegUtil.IsUint(command.Target))
                            {
                                var gnum = command.Target.ToArray();
                                var tnum = game.GameParams.ToArray();
                                int Acount = 0;
                                int Bcount = 0;
                                for (int k = 0; k < 4; k++)
                                {
                                    if (tnum[k] == gnum[k])
                                    {
                                        Acount++;
                                    }
                                    else
                                    {
                                        for (int m = 0; m < 4; m++)
                                        {
                                            if (tnum[k] == gnum[m])//比较这两个数组相应的值是否相等
                                            {
                                                Bcount++;
                                            }
                                        }
                                    }
                                }
                                game.GameCount = count;
                                if (count > -1)
                                {
                                    if (Acount == 4)
                                    {
                                        await sendGroupAsync(messageReceiver, $"你猜对了!游戏结束!,想再开始请再对我说：{CommandType.BOT} {TargetType.GUSSNUM}");
                                        game.GameStatus = "1";
                                        g.GrpGuessnum = "0";
                                        g.Update();
                                    }
                                    else
                                    {
                                        await sendGroupAsync(messageReceiver, $"猜测结果为{Acount}A{Bcount}B,还有{count}次机会");
                                    }

                                }
                                else
                                {
                                    await sendGroupAsync(messageReceiver, $"机会耗尽，游戏结束,数字为：{game.GameParams}");
                                    g.GrpGuessnum = "0";
                                    game.GameStatus = "1";
                                    g.Update();
                                }
                                game.Update();
                            }
                            else
                            {
                                await sendGroupAsync(messageReceiver, "你猜的数字格式错误");
                            }
                        }

                    }
                    else if (g.GrpGuessnum.Contains("0"))
                    {
                        await sendGroupAsync(messageReceiver, $"对局不存在!请开新局再回复{command.CommandType} {command.Target}!");
                    }

                }
                #endregion
                #region 取消
                else if (command.CommandType.Contains(CommandType.CANCEL))
                {

                    if (TargetType.GUSSNUM.Contains(command.Target) && !g.GrpGuessnum.Contains("-1"))
                    {
                        if (g.GrpGuessnum.Contains("1"))
                        {
                            await sendGroupAsync(messageReceiver, $"已结束{TargetType.GUSSNUM}!");
                            var game = GamesStatus.Find(GamesStatus._.GameGroup == g.GrpId);
                            game.GameStatus = "1";
                            g.GrpGuessnum = "0";
                            game.Update();
                            g.Update();
                        }
                        else
                        {
                            await sendGroupAsync(messageReceiver, $"错误，{TargetType.GUSSNUM}未开始!");
                        }
                    }
                    else if (TargetType.CHENGYU.Contains(command.Target) && !g.GrpChengyu.Contains("-1"))
                    {

                    }
                    else
                    {
                        await sendGroupAsync(messageReceiver, $"错误，{command.Target}未开启或不存在!");
                    }
                }
                #endregion
                #region 大乐透
                else if (command.CommandType.Contains(CommandType.LOTTERY))
                {
                    
                    if (command.Params!=null && command.Params!="" && RegUtil.IsUint(command.Params))
                    {
                        if (RegUtil.IsUint(command.Target) && !g.GrpLottery.Contains("-1"))
                        {
                            if (mem.MemPoint > 1000)
                            {
                                var ticket = LotteryTicket.Find(LotteryTicket._.LeId == mem.MemLotteryId & LotteryTicket._.LeFinish==0);
                                //查询是否已投注
                                if (ticket == null)
                                {
                                    var l = LotteryTicket.Find(LotteryTicket._.LeFinish == 0);
                                    if (l != null)
                                    {
                                        var point = mem.MemPoint;
                                        mem.MemPoint = point - 1000;
                                        mem.MemLotteryId = l.LeId;
                                        mem.MemLottery = command.Target + "|" + command.Params;
                                        mem.Update();
                                        await sendGroupAsync(messageReceiver, $"已投注，请牢记兑换码{l.LeSn}!", false);
                                    }
                                    else
                                    {
                                        await sendGroupAsync(messageReceiver, $"没有正在进行的大乐透活动");
                                    }
                                }
                                else
                                {
                                    await sendGroupAsync(messageReceiver, $"您已经投注过了!");
                                }
                                
                            }
                            else
                            {
                                await sendGroupAsync(messageReceiver, $"需要1000积分，请努力攒够积分吧! \n您的剩余积分【{mem.MemPoint}】");
                            }
                        }
                        else
                        {
                            await sendGroupAsync(messageReceiver, $"错误，{command.CommandType}未开启或不存在!");
                        }
                    }
                    else
                    {
                        await sendGroupAsync(messageReceiver, $"错误，请检查指令格式!");
                    }
                }
                #endregion
                else if (command.CommandType.Contains(CommandType.CASHPRIZE))
                {
                    if (command.Target.Length== 4 && command.Target != "" && RegUtil.IsUint(command.Target))
                    {
                        var ticket = LotteryTicket.Find(LotteryTicket._.LeId == mem.MemLotteryId & LotteryTicket._.LeFinish == 1);
                        //查询是否已投注
                        if (ticket != null)
                        {
                            var rednum = mem.MemLottery.Split("|")[0].ToArray();
                            var bluenum = mem.MemLottery.Split("|")[0].ToArray();
                            var tnum = ticket.LeResult.ToArray();
                            int Acount = 0;
                            int Bcount = 0;
                            for (int k = 0; k < 7; k++)
                            {
                                if (tnum[k] == rednum[k])
                                {
                                    Acount++;
                                }
                            }
                            for (int k = 0; k < 3; k++)
                            {
                                if (tnum[k] == bluenum[k])
                                {
                                    Bcount++;
                                }
                            }
                            var getRed = UtilHelper.ToPoint(Acount);
                            var getBlue = UtilHelper.ToPoint(Bcount);

                            var point = int.Parse(getRed) * int.Parse(getBlue);
                            var pp = mem.MemPoint;
                            mem.MemPoint = pp + point;
                            mem.MemLotteryId = "";
                            mem.MemLottery = "";
                            mem.Update();

                            await sendGroupAsync(messageReceiver, $"恭喜您!你的中了{Acount}个红球和{Bcount}个蓝球，您的本次奖金一共是{point}积分!\n" +
                                $"积分已转入您的账户中,当前余额【{mem.MemPoint}】");
                        }
                        else
                        {
                            await sendGroupAsync(messageReceiver, $"错误，你没有参加本期投注!");
                        }
                    }
                    else
                    {
                        await sendGroupAsync(messageReceiver, $"错误，请检查指令格式!");
                    }
                }
                    #endregion
            }
            else
            {
                if (command.CommandType.Contains(CommandType.BOT)){
                    if (command.Target.Contains(TargetType.REGISTER))
                    {
                        var m = Members.Find(Members._.MemQq == messageReceiver.Sender.Id & Members._.MemGroup == messageReceiver.Sender.Group.Id);
                        if (m != null)
                        {
                            await sendGroupAsync(messageReceiver, $"成员已注册！");
                        }
                        else
                        {
                            var nm = new Members();
                            nm.MemGroup = messageReceiver.Sender.Group.Id;
                            nm.MemNicknumber = messageReceiver.Sender.Name;
                            nm.MemPoint = 200;
                            nm.MemExist = 0;
                            nm.MemLimit = 5;
                            nm.MemQq = messageReceiver.Sender.Id;
                            nm.Insert();
                            var num = g.GrpNumber;
                            num+= 1;
                            g.GrpNumber = num;
                            g.Update();
                            await sendGroupAsync(messageReceiver, $"注册成功！初始200积分已经到账!", true);
                        }
                    }
                    else
                    {
                        await sendGroupAsync(messageReceiver, $"您尚未注册，请注册后使用", true);
                    }
                }
                else
                {
                    await sendGroupAsync(messageReceiver, $"您尚未注册，请注册后使用", true);
                }
            }

            return "";
        }


        private static async Task sendGroupAsync(GroupMessageReceiver receiver, string msg)
        {
            TimeConsumingCounter tcc = new TimeConsumingCounter();
            tcc.Start();
            await receiver.SendGroupMessage($"".Append(msg)).ContinueWith((e)=> {
                tcc.Over();
                Console.WriteLine("发送耗时" + tcc.Span());
            });
          
        }
        private static async Task sendGroupAsync(GroupMessageReceiver receiver, string msg,bool atMsgPosition)
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
    }

}
