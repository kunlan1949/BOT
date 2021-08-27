﻿using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Data.Modules;
using Mirai.Net.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mirai.Net.Utils.Extensions;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Utils.Extensions.Actions;
using BOT.Helper;
using Mirai.Net.Sessions;
using Mirai.Net.Sessions.Http.Concretes;
using BOT.Model;
using BOT.Module.Send;
using BOT.Handler;
using Db.Bot;
using BOT.Action;
using BOT.Actions;

namespace BOT.Module
{
    public class GroupMessageModule
    {

        public void Execute(MessageReceiverBase @base, MessageBase executeMessage)
        {
            if (@base is GroupMessageReceiver receiver)
            {
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
                            || m.Result.CommandType.Contains(CommandType.CASHPRIZE) || m.Result.CommandType.Contains(CommandType.LUCKY))
                        {
                            var g = Groups.Find(Groups._.GrpId == receiver.Sender.Group.Id);
                            Console.WriteLine("互动模式");
                            if (g != null)
                            {
                                var member = Members.Find(Members._.MemQq == receiver.Sender.Id);
                                if (member != null)
                                {
                                    InteractHandler.CommandAsync(member, g, m.Result, receiver, false);
                                }
                                else
                                {
                                    InteractHandler.CommandAsync(null, g, m.Result, receiver, false);
                                }

                            }
                            else
                            {
                                receiver.SendGroupMessage("".Append("错误，此QQ群组未被授权"));
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
                        Console.WriteLine($"{message.Text}");
                        var i = receiver.MessageChain.WhereAndCast<ImageMessage>();
                        if (i.Length > 0)
                        {
                            Console.WriteLine(i[0].Url);
                        }

                    }
                    tcc.Over();
                    Console.WriteLine("操作耗时" + tcc.Span());

                }
                //await receiver.SendGroupMessage("Hello, World".Append());
            }
        }
    }

}
