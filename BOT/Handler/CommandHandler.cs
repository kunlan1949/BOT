using BOT.Actions;
using BOT.Actions.image;
using BOT.Model;
using BOT.Module.Send;
using BOT.Utils;
using Db.Bot;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Utils.Scaffolds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Handler
{
    class CommandHandler
    {
        public static async Task<string> friendCommandAsync(CommandAttribute command, FriendMessageReceiver messageReceiver,bool exec)
        {

            if (command.CommandType.Contains(CommandType.EXEC))
            {
                if (command.Target.Contains(TargetType.HELP))
                {
                    await sendAsync(messageReceiver, "           帮助目录\n".Append(
                        "功能:            \t【1】\n" +
                        "开关:            \t【2】\n" +
                        "功能:            \t【3】\n" +
                        "功能:            \t【4】\n" +
                        "功能:            \t【5】\n" +
                        "请输入【/help】【num】"));
                }
                else if (command.Target.Contains(TargetType.ADDROOT))
                {
                    await RootAdminAction .AddRootAdminAsync(command, messageReceiver, exec);
                }
                else if (command.Target.Contains(TargetType.RMROOT))
                {
                    await RootAdminAction.RemoveRootAdminAsync(command, messageReceiver, exec);
                }
                
                else
                {

                }
            }
            else if (command.CommandType.Contains(CommandType.ADDADMIN))
            {
                await AdminAction.AddAdminAsync(command, messageReceiver, exec);
            }
            else if (command.CommandType.Contains(CommandType.RMADMIN))
            {
                await AdminAction.RemoveAdminAsync(command, messageReceiver, exec);
            }
            else if (command.CommandType.Contains(CommandType.HELP))
            {
                if (command.Target.Contains(TargetType.FUNC))
                {
                    if (command.Params== String.Empty)
                    {
                        await sendAsync(messageReceiver, "           功能目录\n\n".Append(
                         "【1】 添加删除根管理员\n" +
                         "【2】 添加删除管理员\n" +
                         "【3】 功能\n" +
                         "【4】 功能\n" +
                         "【5】 功能\n" +
                         "请输入【/help】+【1】基础上加上【num】来进行查询\n" +
                         "例如：/help 1 1"));
                    }
                    else
                    {
                        if (command.Params.Contains("1"))
                        {
                            await sendAsync(messageReceiver, "【添加删除根管理员】\n\n".Append(
                             "请输入【/exec】+【addroot】+【QQ】来进行添加\n" +
                             "例如：/exec addRoot 10001\n" +
                             "请输入【/exec】+【rmroot】+【QQ】来进行删除\n" +
                             "例如：/exec rmRoot 10001\n" +
                             "NOTE:只有根权限账号才能使用此项功能"));
                        }
                        else if (command.Params.Contains("2"))
                        {
                            await sendAsync(messageReceiver,"【添加删除管理员】\n\n".Append(
                             "请输入【/addadmin】+【】+【QQ】来进行添加\n" +
                             "例如：/exec addRoot 10001\n" +
                             "请输入【/addadmin】+【rmadmin】+【QQ】来进行删除\n" +
                             "例如：/exec rmadmin 10001\n" +
                             "NOTE:只有根权限账号才能使用此项功能"));
                        }
                        else
                        {
                          await errorAsync(messageReceiver, command);
                        }
                    }
                  
                }
                else
                {
                    await errorAsync(messageReceiver, command);
                }

            }
            else if (command.CommandType.Contains(CommandType.TEST))
            {
                await WebImageAction.TestAsync(command, messageReceiver, exec);
            }
            else
            { 
             
            }
            return "";
        }


        

        private static async Task sendAsync(FriendMessageReceiver receiver, string msg)
        {
            await SendFriendMessageModule.sendFriendAsync(receiver, msg);
        }
        private static async Task sendAsync(FriendMessageReceiver receiver, MessageBase[] msg)
        {
            await SendFriendMessageModule.sendFriendAsync(receiver, msg);
        }

        private static async Task errorAsync(FriendMessageReceiver receiver,CommandAttribute command)
        {
            await sendAsync(receiver,$"".Append($"未找到相关指令{command.CommandType}" + " " + $"{command.Target}" + " " + $"{command.Params}"));
        }

        private static async Task errorAsync(FriendMessageReceiver receiver, string errmsg)
        {
            await sendAsync(receiver, $"".Append(errmsg));
        }
    }
}
