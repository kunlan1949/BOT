using BOT.Model;
using BOT.Utils;
using Db.Bot;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Sessions.Http.Concretes;
using Mirai.Net.Utils.Extensions;
using Mirai.Net.Utils.Extensions.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Actions
{
    class AdminAction
    {
        public static async Task AddAdminAsync(CommandAttribute command, FriendMessageReceiver messageReceiver, bool exec)
        {
            if (command.Params != String.Empty)
            {
                if (RegUtil.IsUint(command.Target))
                {
                    if (RegUtil.IsUint(command.Params) && int.Parse(command.Params)<10)
                    {
                        if (exec)
                        {
                            var root = TAdmin.Find(TAdmin._.AdminId == command.Target);
                            if (root == null)
                            {

                                AccountManager account = new();
                                var a = await account.GetFriendProfile(command.Target);
                                var r = new TAdmin();
                                r.AdminId = command.Target;
                                r.AdminIdentify = "";
                                r.AdminNickName = a.NickName;
                                r.AdminCreateTime = UtilHelper.GetTimeUnix().ToString();
                                r.AdminLimitAuthority = command.Params;
                                r.AdminProtect = "0";
                                r.Insert();

                                await messageReceiver.SendFriendMessage("".Append(
                               $"已成功添加管理员：{command.Target}\n"));
                            }
                            else
                            {
                                await messageReceiver.SendFriendMessage("".Append(
                               $"已存在管理员：{command.Params}，添加失败\n"));
                            }

                            var mission = TMission.Find(TMission._.MId == messageReceiver.Sender.Id & TMission._.MFinish == "0");
                            mission.MFinish = "1";
                            mission.Update();
                        }
                        else
                        {
                            var m = new TMission();
                            m.MId = messageReceiver.Sender.Id;
                            m.MType = command.CommandType;
                            m.MTarget = command.Target;
                            m.MParam = command.Params;
                            m.MFinish = "0";
                            m.Insert();
                            await messageReceiver.SendFriendMessage("".Append(
                                $"是否确认要增加管理员：{command.Target}?\n" +
                                $"确认操作输入/y,取消操作输入/n "));
                        }
                    }
                    else
                    {
                        await errorAsync(messageReceiver, $"错误的权限格式，权限等级为1-10以内的数字");
                    }

                }
                else
                {
                    await errorAsync(messageReceiver, $"错误的QQ号格式，请检查后重试");
                }
            }
            else
            {
                await errorAsync(messageReceiver, command);
            }
        }

        public static async Task RemoveAdminAsync(CommandAttribute command, FriendMessageReceiver messageReceiver, bool exec)
        {
            if (RegUtil.IsUint(command.Target))
            {
                if (exec)
                {
                    var root = TAdmin.Find(TAdmin._.AdminId == command.Target);
                    if (root == null)
                    {
                        await messageReceiver.SendFriendMessage("".Append(
                    $"不存在管理员：{command.Params}，删除失败\n"));
                    }
                    else
                    {
                        var isProtect = false;
                        if (root.AdminProtect.Contains("1"))
                        {
                            if (!messageReceiver.Sender.Id.Contains("2048437217"))
                            {
                                isProtect = true;
                            }
                        }
                        else
                        {
                            isProtect = false;
                        }

                        if (isProtect)
                        {
                            await messageReceiver.SendFriendMessage("".Append(
                            $"此管理员：{command.Target}收到保护，无法删除！\n"));

                        }
                        else
                        {
                            root.Delete();
                            await messageReceiver.SendFriendMessage("".Append(
                        $"已成功删除管理员：{command.Target}\n"));
                        }
                                
                    }

                    var mission = TMission.Find(TMission._.MId == messageReceiver.Sender.Id & TMission._.MFinish == "0");
                    mission.MFinish = "1";
                    mission.Update();
                }
                else
                {
                    var m = new TMission();
                    m.MId = messageReceiver.Sender.Id;
                    m.MType = command.CommandType;
                    m.MTarget = command.Target;
                    if (command.Params != null && !command.Params.Contains(""))
                    {
                        m.MParam = command.Params;
                    }
                    m.MFinish = "0";
                    m.Insert();
                    await messageReceiver.SendFriendMessage("".Append(
                        $"是否确认要删除管理员：{command.Target}?\n" +
                        $"确认操作输入/y,取消操作输入/n "));
                }
                

            }
            else
            {
                await errorAsync(messageReceiver, $"错误的QQ号格式，请检查后重试");
            }
            
        }


        private static async Task errorAsync(FriendMessageReceiver receiver, string errmsg)
        {
            await receiver.SendFriendMessage($"".Append(errmsg));
        }
        private static async Task errorAsync(FriendMessageReceiver receiver, CommandAttribute command)
        {
            await receiver.SendFriendMessage($"".Append($"未找到相关指令{command.CommandType}" + " " + $"{command.Target}" + " " + $"{command.Params}"));
        }
    }
}
