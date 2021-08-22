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

namespace BOT.Action
{
    class RootAdminAction
    {
        public static async Task AddRootAdminAsync(CommandAttribute command, FriendMessageReceiver messageReceiver, bool exec)
        {
            if (command.Params != String.Empty)
            {
                if (RegUtil.IsUint(command.Params))
                {
                    if (exec)
                    {
                        var root = RootAdmin.Find(RootAdmin._.AdminQq == command.Params);
                        if (root == null)
                        {
                            AccountManager account = new();
                            var a = await account.GetFriendProfile(command.Params);
                            var r = new RootAdmin();
                            r.AdminId = "0";
                            r.AdminQq = command.Params;
                            r.AdminNick =a.NickName;
                            r.AdminCreateTime = UtilHelper.GetTimeUnix().ToString();
                            r.Insert();
                          
                            await messageReceiver.SendFriendMessage("".Append(
                           $"已成功添加根管理员：{command.Params}\n"));
                        }
                        else
                        {
                            await messageReceiver.SendFriendMessage("".Append(
                           $"已存在根管理员：{command.Params}，添加失败\n"));
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
                            $"是否确认要增加管理员：{command.Params}?\n" +
                            $"确认操作输入/y,取消操作输入/n "));
                    }

                }
                else
                {
                    await errorAsync(messageReceiver, $"错误的QQ号格式");
                }
            }
            else
            {
                await errorAsync(messageReceiver, command);
            }
        }

        public static async Task RemoveRootAdminAsync(CommandAttribute command, FriendMessageReceiver messageReceiver, bool exec)
        {
            if (command.Params != String.Empty)
            {
                if (RegUtil.IsUint(command.Params))
                {
                    if (exec)
                    {
                        var root = RootAdmin.Find(RootAdmin._.AdminQq == command.Params);
                        if (root == null)
                        {
                            await messageReceiver.SendFriendMessage("".Append(
                          $"不存在根管理员：{command.Params}，删除失败\n"));
                        }
                        else
                        {
                            if (root.AdminQq.Contains("2048437217"))
                            {
                                await messageReceiver.SendFriendMessage("".Append(
                           $"此根管理员：{command.Params}收到保护，无法删除！\n"));
                            }
                            else
                            {
                                root.Delete();
                                await messageReceiver.SendFriendMessage("".Append(
                         $"已成功删除根管理员：{command.Params}\n"));
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
                        m.MParam = command.Params;
                        m.MFinish = "0";
                        m.Insert();
                        await messageReceiver.SendFriendMessage("".Append(
                            $"是否确认要删除根管理员：{command.Params}?\n" +
                            $"确认操作输入/y,取消操作输入/n "));
                    }

                }
                else
                {
                    await errorAsync(messageReceiver, $"错误的QQ号格式");
                }
            }
            else
            {
                await errorAsync(messageReceiver, command);
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
