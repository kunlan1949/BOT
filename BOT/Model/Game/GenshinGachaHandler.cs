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
                        Gen = new Genshin();
                        Gen.Member = mem.MemQq;
                        Gen.Group = mem.MemGroup;
                        Gen.Primogem = 0;
                        Gen.AcquaintFate = 0;
                        Gen.IntertwinedFate = 0;
                        Gen.Resident5Count = 0;
                        Gen.Resident4Count = 0;
                        Gen.WeaponUp5Count = 0;
                        Gen.WeaponUp4Count = 0;
                        Gen.RoleUp5Count = 0;
                        Gen.RoleUp4Count = 0;

                        Gen.Insert();
                    }
                    if (Gen.Resident5Count / 90 >= 1)
                    {
                        Gen.Resident5Count = 0;
                    }
                    //低保计数+10
                    GenshinDataAction.ResidentMark(Gen);
                    //统计总次数+10
                    Gen.Resident+= 10;
                    Gen.Update();

                    var isProtect = false;

                    await SendGroupMessageModule.sendGroupAsync(messageReceiver, "祈愿已开始!祝你好运!");
                    //金保底
                    if ((Gen.Resident5Count / 90.0) >= 1)
                    {
                        resultList = GenshinGachaAction.residentGachaTen(Gen,true);
                        isProtect = true;
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
                    var rp5List = new List<string>();
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
                            }
                            rp5List.Add(result.value);
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

                    
                    var star5Msg = $"{genStar5List(rp5List, Gen.Resident5Count)}";
                    if (rp5List.Count > 0)
                    {
                        Gen.Resident5Count = 0;
                        Gen.Update();
                    }
                    msg = "".Append("\n【奔行世间 · 十连结果】\n")
                         .Append(new ImageMessage() { Base64 = ImageSplitHelper.Splice10(resultList), Type = Messages.Image })
                         .Append($"5星保底：还要抽{90-Gen.Resident5Count}次\n")
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

        private static string genStar5List(List<string> rp5List, int count)
        {
            var re = "";
            if (rp5List.Count>0)
            {
                var loser = $"";
                if (count==0)
                {
                    re = "《》\n";
                }
                else if (count >= 90)
                {
                    re = "《至少没得歪》\n";
                }
                else if (count >= 80 && count <90 )
                {
                    re = "《我要这保底有何用》\n";
                }
                else if (count >= 40 && count < 80)
                {
                    re = "《沉默的大多数》\n";
                }
                else if(count >= 20 && count<40)
                {
                    re = "《这池子挺浅啊》\n";
                }
                else if (count >= 10 && count < 20)
                {
                    re = "《这不是有手就行》\n";
                }
                re += $"[{count}连] 时出货\n";
            }

            return re;
        }
    }
}
