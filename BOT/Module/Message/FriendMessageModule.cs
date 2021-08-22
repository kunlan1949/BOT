using BOT.Handler;
using BOT.Helper;
using BOT.Model;
using Db.Bot;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Modules;
using Mirai.Net.Sessions;
using Mirai.Net.Sessions.Http.Concretes;
using Mirai.Net.Utils.Extensions;
using Mirai.Net.Utils.Extensions.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Module.Message
{
    class FriendMessageModule: IModule
    {
        public bool? IsEnable { get; set; }

        public void Execute(MessageReceiverBase @base, MessageBase executeMessage)
        {

            if (@base is FriendMessageReceiver receiver)
            {
                foreach (var message in receiver.MessageChain.WhereAndCast<PlainMessage>())
                {
                    Console.WriteLine("message=" + message.Text);
                    
                    
                    //校验是否为根管理员发布的指令
                    var r = RootAdmin.Find(RootAdmin._.AdminQq == receiver.Sender.Id);
                    if (r!=null)
                    {
                        var f = ParseHelper.FriendCommandAsync(message.Text, receiver);
                        if (f.IsCompletedSuccessfully)
                        {
                            f.ContinueWith ((m) => {
                                if (m.Result != null)
                                {
                                    Console.WriteLine($"指令发送:【{m.Result.CommandType}】【{m.Result.Target}】【{m.Result.Params}】");
                                    var mission = TMission.Find(TMission._.MId == receiver.Sender.Id & TMission._.MFinish == "0");
                                    if (mission != null)
                                    {
                                        if (m.Result.CommandType.Contains(CommandType.YESNO))
                                        {
                                            if (m.Result.Target.Contains(TargetType.YES))
                                            {
                                                var command = new CommandAttribute()
                                                {
                                                    CommandType = mission.MType,
                                                    Target = mission.MTarget,
                                                    Params = mission.MParam
                                                };
                                                CommandHandler.friendCommandAsync(command, receiver, true);
                                            }
                                            else
                                            {

                                            }
                                        }
                                        else
                                        {
                                            receiver.SendFriendMessage("".Append(
                                            $"您有尚未解决的操作{mission.MType +" "+ mission.MTarget+" "+mission.MParam}\n" +
                                            $"此操作需要您确认/yn 1 或者/yn 0"));
                                        }
                                      
                                    }
                                    else
                                    {
                                        CommandHandler.friendCommandAsync(m.Result, receiver,false);
                                    }
                                }
                               else
                               {
                                   Console.WriteLine($"【根管理员】{r.AdminQq}：{message.Text}");
                               }

                            });
                        }
                        else
                        {

                        }
                          
                        
                    }
                    else
                    {
                        Console.WriteLine($"【非根管理员】{receiver.Sender.Id}：{message.Text}");
                    }
                  
                }
            }
        }
    }
}
