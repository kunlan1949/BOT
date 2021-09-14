using BOT.Actions;
using BOT.Handler.Func;
using BOT.Helper;
using BOT.Model;
using BOT.Model.Game;
using BOT.Module.Send;
using BOT.Utils;
using Db.Bot;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Utils.Scaffolds;
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
            
            #region 存在注册成员
            if (exist_m)
            {
                #region @BOT
                if (command.CommandType.Contains(CommandType.BOT))
                {

                    #region 注册
                    if (command.Target.Contains(TargetType.REGISTER))
                    {
                        var m = Members.Find(Members._.MemQq == messageReceiver.Sender.Id & Members._.MemGroup == messageReceiver.Sender.Group.Id);
                        if (m != null)
                        {
                            await sendGroupAsync(messageReceiver, $"成员已注册！");
                        }
                    }
                    #endregion

                    #region 猜数字
                    else if (command.Target.Contains(TargetType.GUSSNUM))
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
                    #endregion

                    #region 识图
                    else if (command.Target.Contains(TargetType.SIMAGE))
                    {
                        await SImageHandler.exeAsync(mem,g,command,messageReceiver);
                    }
                    #endregion

                    #region 帮助菜单
                    else if (command.Target.Contains(TargetType.FORHELP))
                    {
                        await HelpHandler.execAsync(mem, g, command, messageReceiver);
                    }
                    #endregion
                }
                #endregion

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

                                var gnum = command.Target.ToList();
                                var gcnum = new List<char>();


                                var tnum = game.GameParams.ToList();
                                var utnum = tnum.Distinct().ToList();

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
                                        gcnum.Add(gnum[k]);
                                    }
                                }
                                var ugnum = gcnum.Distinct().ToList();
                                for (int j = 0; j < utnum.Count; j++)
                                {
                                    for (int m = 0; m < ugnum.Count; m++)
                                    {
                                        if (utnum[j] == ugnum[m])//比较这两个数组相应的值是否相等
                                        {
                                            Bcount++;
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

                    if (command.Params != null && command.Params != "" && RegUtil.IsUint(command.Params) && command.Target.Length == 7 && command.Params.Length == 3)
                    {
                        if (RegUtil.IsUint(command.Target) && !g.GrpLottery.Contains("-1"))
                        {
                            if (mem.MemPoint > 1000)
                            {
                                var ticket = LotteryTicket.Find(LotteryTicket._.LeId == mem.MemLotteryId & LotteryTicket._.LeFinish == 0 & LotteryTicket._.LeBet == 1);
                                //查询是否已投注
                                if (ticket == null)
                                {
                                    var l = LotteryTicket.Find(LotteryTicket._.LeFinish == 0 & LotteryTicket._.LeBet == 1);
                                    if (l != null)
                                    {
                                        var point = mem.MemPoint;
                                        mem.MemPoint = point - 1000;
                                        mem.MemLotteryId = l.LeId;
                                        mem.MemLottery = command.Target + "*" + command.Params;
                                        mem.Update();
                                        await sendGroupAsync(messageReceiver, $"已投注，请牢记兑换码{l.LeSn}!", false);
                                    }
                                    else
                                    {
                                        await sendGroupAsync(messageReceiver, $"大乐透已停止投注");
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

                #region 兑奖
                else if (command.CommandType.Contains(CommandType.CASHPRIZE))
                {
                    if (command.Target.Length == 4 && command.Target != "")
                    {
                        var ticket = LotteryTicket.Find(LotteryTicket._.LeId == mem.MemLotteryId & LotteryTicket._.LeFinish == 0);
                        //查询是否已投注
                        if (ticket != null)
                        {
                            if (mem.MemLottery != "0")
                            {
                                if (ticket.LeOpen == 1)
                                {
                                    try
                                    {
                                        var rednum = mem.MemLottery.Split("*")[0].ToArray();
                                        var bluenum = mem.MemLottery.Split("*")[1].ToArray();
                                        var tnum = ticket.LeResult.ToList();
                                        var trnum = tnum.GetRange(0, 7);
                                        var tbnum = tnum.GetRange(7, 3);
                                        int Acount = 0;
                                        int Bcount = 0;
                                        for (int k = 0; k < 7; k++)
                                        {
                                            if (trnum[k] == rednum[k])
                                            {
                                                Acount++;
                                            }
                                        }
                                        for (int k = 0; k < 3; k++)
                                        {
                                            if (tbnum[k] == bluenum[k])
                                            {
                                                Bcount++;
                                            }
                                        }
                                        var getRed = UtilHelper.ToPoint(Acount, true);
                                        var getBlue = UtilHelper.ToPoint(Bcount, false);

                                        var point = int.Parse(getRed) * int.Parse(getBlue);
                                        var pp = mem.MemPoint;
                                        mem.MemPoint = pp + point;
                                        mem.MemLottery = "0";
                                        mem.Update();

                                        await sendGroupAsync(messageReceiver, $"你中了{Acount}个红球和{Bcount}个蓝球，您的本次奖金一共是{point}积分!\n" +
                                            $"积分已转入您的账户中,当前余额【{mem.MemPoint}】");
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                }
                                else
                                {
                                    await sendGroupAsync(messageReceiver, $"错误，还未开奖!");
                                }
                            }
                            else
                            {
                                await sendGroupAsync(messageReceiver, $"错误，您已兑奖!");
                            }

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

                #region 天气
                else if (command.CommandType.Contains(CommandType.WEATHER))
                {
                    await WeatherHandler.execAsync(mem, g, command, messageReceiver);
                }
                #endregion

                #region 翻译
                else if (command.CommandType.Contains(CommandType.TRANS))
                {
                    await TranslateHandler.execAsync(mem, g, command, messageReceiver);
                }
                #endregion

                #region 查游戏
                else if (command.CommandType.Contains(CommandType.SGAME))
                {
                    await SteamHandler.execAsync(mem, g, command, messageReceiver);
                }
                #endregion

                #region 运势
                else if (command.CommandType.Contains(CommandType.LUCKY))
                {
                    await ConstellationHandler.execAsync(mem, g, command, messageReceiver);
                }
                #endregion

                #region 二十一点
                else if (command.CommandType.Contains(CommandType.TWENTYONE))
                {
                    await TwentyOneHandler.startAsync(mem, g, command, messageReceiver);
                }
                #endregion
            }
            #endregion


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
                            nm.SimageLimit = 5;
                            nm.ImgTime = UtilHelper.GetTimeUnix().ToString();
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
            await SendGroupMessageModule.sendGroupAsync(receiver,msg);
        }
        private static async Task sendGroupAsync(GroupMessageReceiver receiver, string msg,bool atMsgPosition)
        {
            await SendGroupMessageModule.sendGroupAtAsync(receiver,msg,atMsgPosition);
        }
    }

}
