using BOT.Actions.genshin;
using BOT.Module.Send;
using Db.Bot;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Utils.Scaffolds;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Model.Game
{
    class GenshinGachaHandler
    {
        public static async Task startAsync(Members mem, Groups g, CommandAttribute command, GroupMessageReceiver messageReceiver)
        {
            if(command.Target!=null && command.Target != "")
            {
                //常驻祈愿
                if (command.Target.Contains(TargetType.GACHA))
                {
                    var Gen = Genshin.Find(Genshin._.Member == mem.MemQq & Genshin._.Group == mem.MemGroup);
                    var resultList = new List<GachaValueReturn>();
                    
                    if (Gen == null)
                    {
                        Gen.Member = mem.MemQq;
                        Gen.Group = mem.MemGroup;
                        Gen.Primogem = 0;
                        Gen.AcquaintFate = 0;
                        Gen.IntertwinedFate = 0;
                        Gen.ResidentProtect5 = 1;
                        Gen.Role5Protect5 = 1;
                        Gen.Role5Protect5Up = 1;
                        Gen.Weapon5Protect5 = 1;
                        Gen.Weapon5Protect5Up = 1;
                        Gen.Insert();
                    }

                    //低保计数+10
                    Gen.ResidentCount += 10;
                    //统计总次数+10
                    Gen.Resident+= 10;
                    Gen.Update();

                    var isProtect = false;

                    await SendGroupMessageModule.sendGroupAsync(messageReceiver, "祈愿已开始!祝你好运!");
                    //金保底
                    if ((Gen.Resident % 90.0) == 0 && Gen.ResidentProtect5 ==1)
                    {
                        resultList = GenshinGachaAction.residentGachaTen(Gen,true);
                        isProtect = true;
                       
                        Gen.ResidentProtect5 = 0;
                        Gen.Update();
                    }
                    else
                    {
                        resultList = GenshinGachaAction.residentGachaTen(Gen, false);
                    }

                    var star5 = 0;
                    var star4 = 0;
                    var rWeapon5 = 0;
                    var rWeapon4 = 0;
                    var rWeapon3 = 0;
                    var rRole5 = 0;
                    var rRole4 = 0;
                    var weapon5List = new List<string>();
                    foreach (var result in resultList)
                    {
                        if (result.level == 5)
                        {
                            if (result.type == 0)
                            {
                                rRole5 += 1;
                            }
                            else
                            {
                                rWeapon5 += 1;
                                weapon5List.Add(result.value);
                            }
                        }
                        else if (result.level == 4)
                        {
                            if (result.type == 0)
                            {
                                rRole4 += 1;
                            }
                            else
                            {
                                rWeapon4 += 1;
                            }
                        }
                        else if (result.level == 3)
                        {
                            rWeapon3 += 1;
                        }

                    }

                    star5 = rWeapon5 + rRole5;
                    star4 = rWeapon4 + rRole4;
                    MessageBase[] msg = { };

                    var star5Msg = $"{genStar5List(weapon5List)}";
                    var loser = $"";
                    if (isProtect)
                    {

                    }
                    msg = "".Append("\n【奔行世间 · 十连结果】\n")
                         .Append(new ImageMessage() { Base64 = ImageSplitHelper.Splice10(resultList), Type = Messages.Image })
                         .Append(star5Msg)
                         .Append($"角色：[{rRole5}]五星，[{rRole4}]四星\n")
                         .Append($"武器：[{rWeapon5}]五星，[{rWeapon4}]四星，[{rWeapon3}]三星\n");
                    await SendGroupMessageModule.sendGroupAtAsync(messageReceiver, msg,true);
                    
                }
            }
            else
            {
                await SendGroupMessageModule.sendGroupAsync(messageReceiver,"错误的指令，请检查后重试！");
            }
        }

        private static string genStar5List(List<string> resultList)
        {
            var re = "";
            if (resultList.Count>0)
            {
                re = "出货啦！你获得了";
                foreach (var result in resultList)
                {
                    re += $"【{result}】 ";
                }
            }

            return re;
        }
    }
}
