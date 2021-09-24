using BOT.Model;
using BOT.Module.Send;
using BOT.Utils;
using Db.Bot;
using Mirai.Net.Data.Messages.Receivers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Handler.Game
{
    public class ChengyuHandler
    {
        public static async Task execAsync(Members mem, Groups g, CommandAttribute command, GroupMessageReceiver messageReceiver)
        {
            if(command.Target!=null && command.Target != "")
            {
                var gs = GamesStatus.Find(GamesStatus._.GameGroup == g.GrpId & GamesStatus._.GameType == 1 & GamesStatus._.GameStatus == 0);
                if (gs == null)
                {
                    var cyc = Chengyu.FindCount();
                    var num = UtilHelper.getRandomNum((int)cyc);
                    var cy = Chengyu.Find(Chengyu._.CyIdx == num);
                    var cy_word = getLastWord(cy.CyPy);
                    var ngs = new GamesStatus()
                    {
                        GameCount = 60,
                        GameGroup = g.GrpId,
                        GameParams = cy_word,
                        GameStarter = mem.MemQq,
                        GameStatus = "0",
                        GameType = "1",
                    };
                    ngs.Insert();
                    g.GrpChengyu = "1";
                    g.Update();
                    await SendGroupMessageModule.sendGroupAtAsync(messageReceiver, $"成语接龙开始!\n成语为：{cy.CyName}=>请接【{cy_word}】", true);
                }
                else
                {
                    
                    await SendGroupMessageModule.sendGroupAtAsync(messageReceiver, $"成语接龙已开始\n如需重开请结束后再开始\n当前接龙:{gs.GameParams}", true);
                }
                
            }
        }
        public static async Task SoliAsync(Members mem, Groups g, CommandAttribute command, GroupMessageReceiver messageReceiver)
        { 
            if(command.Target!="" && command.Target != null)
            {
                var gs = GamesStatus.Find(GamesStatus._.GameGroup == g.GrpId & GamesStatus._.GameType ==1 & GamesStatus._.GameStatus == 0);
                if (gs != null)
                {
                    //首个字的拼音
                    var fw_py = Word.Find(Word._.WName == command.Target.First());
                    if (fw_py != null)
                    {
                        //所有的音标g替换为字母g
                        var w = fw_py.WPy.ToString().Replace("ɡ", "g");
                        var m = gs.GameParams.ToString();
                        var wpy = UtilHelper.StringToUnicode(w);
                        var gpy = UtilHelper.StringToUnicode(m);
                        
                        //拼音是否吻合
                        if (String.Compare(wpy, gpy, CultureInfo.InvariantCulture, CompareOptions.IgnoreNonSpace) == 0)
                        {
                            var cy = Chengyu.Find(Chengyu._.CyName==command.Target);
                            if (cy != null)
                            {
                                gs.GameParams = getLastWord(cy.CyPy);
                                var c=gs.GameCount;
                                gs.GameCount = c - 1;
                                gs.Update();
                                var p = mem.MemPoint;
                                mem.MemPoint = p + 50;
                                mem.Update();
                                await SendGroupMessageModule.sendGroupAtAsync(messageReceiver, $"回答正确！积分+50!\n当前成语[{command.Target}]\n请接=>【{gs.GameParams}】", true);
                            }
                            else
                            {
                                await SendGroupMessageModule.sendGroupAtAsync(messageReceiver, $"错误，未在数据库中找到对应成语！\n 请接【{gs.GameParams}】", true);
                            }
                        }
                        else
                        {
                            await SendGroupMessageModule.sendGroupAtAsync(messageReceiver, $"错误：当前成语[{gs.GameParams}]\n您的成语[{fw_py.WPy}]", true);
                        }
                    }
                    else
                    {

                    }
                }
                else
                {
                    await SendGroupMessageModule.sendGroupAtAsync(messageReceiver, $"未存在成语接龙对局\n如需开始请输入指令", true);
                }
              
            }
        }
            private static string getLastWord(string py)
        {
            string word = "";
            word = py.Replace("【", "").Replace("】", "").Split(" ").Last().ToString();
            return word;
        }
        
    }
}
