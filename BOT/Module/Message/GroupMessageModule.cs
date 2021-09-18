using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Data.Modules;
using Mirai.Net.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mirai.Net.Data.Messages.Concretes;
using BOT.Helper;
using Mirai.Net.Sessions;
using BOT.Model;
using BOT.Module.Send;
using BOT.Handler;
using Db.Bot;
using BOT.Action;
using BOT.Actions;
using Mirai.Net.Utils.Scaffolds;
using static BOT.Model.TypeHelper;

namespace BOT.Module
{
    public class GroupMessageModule
    {

        public async Task ExecuteAsync(MessageReceiverBase @base, MessageBase executeMessage)
        {
            if (@base is GroupMessageReceiver receiver)
            {
                //var me = receiver.MessageChain.WhereAndCast<FaceMessage>();
                //if (me != null)
                //{
                //    Console.WriteLine(me[0].FaceId + "|" + me[0].Name);
                //}

                foreach (var message in receiver.MessageChain.WhereAndCast<PlainMessage>())
                {
                    TimeConsumingCounter tcc = new TimeConsumingCounter();
                    tcc.Start();
                    Console.WriteLine("message=" + message.Text);
                    var m = ParseHelper.GroupCommandAsync(message.Text, receiver);
                    if (m.Result != null)
                    {
                        Console.WriteLine($"指令发送:【{m.Result.CommandType}】【{m.Result.Target}】【{m.Result.Params}】");
                        if (m.Result.CommandType.Contains(CommandType.BOT) || m.Result.CommandType.Contains(CommandType.IGUSS)
                            || m.Result.CommandType.Contains(CommandType.CANCEL) || m.Result.CommandType.Contains(CommandType.LOTTERY)
                            || m.Result.CommandType.Contains(CommandType.CASHPRIZE) || m.Result.CommandType.Contains(CommandType.LUCKY) 
                            || m.Result.CommandType.Contains(CommandType.WEATHER) || m.Result.CommandType.Contains(CommandType.TWENTYONE) 
                            || m.Result.CommandType.Contains(CommandType.TRANS) || m.Result.CommandType.Contains(CommandType.SGAME)
                            || m.Result.CommandType.Contains(CommandType.GENSHIN))
                        {
                            var g = Groups.Find(Groups._.GrpId == receiver.Sender.Group.Id);
                            Console.WriteLine("互动模式");
                            if (g != null)
                            {
                                var member = Members.Find(Members._.MemQq == receiver.Sender.Id & Members._.MemGroup == receiver.Sender.Group.Id );
                                if (member != null)
                                {
                                    await InteractHandler.CommandAsync(member, g, m.Result, receiver, false);
                                }
                                else
                                {
                                    await InteractHandler.CommandAsync(null, g, m.Result, receiver, false);
                                }

                            }
                            else
                            {
                              await SendGroupMessageModule.sendGroupAsync(receiver,"".Append("错误，此QQ群组未被授权"));
                                //TimerAction.LatteryOpen();
                            }
                        }
                        else
                        {
                            Console.WriteLine("命令模式");
                        }
                    }
                    else
                    {
                        

                    }
                    tcc.Over();
                    Console.WriteLine("操作耗时" + tcc.Span());
                }
                foreach (var message in receiver.MessageChain.WhereAndCast<ImageMessage>())
                {

                    if (receiver.MessageChain.WhereAndCast<PlainMessage>().Length <= 0)
                    {
                        var member = Members.Find(Members._.MemQq == receiver.Sender.Id & Members._.MemGroup == receiver.Sender.Group.Id);
                        if (member != null)
                        {
                            if (member.MissionId != "")
                            {
                                await MissionHelper.SelectTypeAsync(member, receiver);
                            }
                        }
                        else
                        {
                            Console.WriteLine(message.Url);
                        }
                    }
                    
                }
                    //await receiver.SendGroupMessage("Hello, World".Append());
            }
        }
    }

}
