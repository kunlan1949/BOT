using AHpx.Extensions.StringExtensions;
using BOT.Model;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Data.Modules;
using Mirai.Net.Sessions.Http.Concretes;
using Mirai.Net.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Helper
{
    static class ParseHelper
    {

        public static List<String> CommandStringParse(string command)
        {
            List<string> c = command.Split(" ").ToList();

            return c;
        }

        public static async Task<CommandAttribute> GroupCommandAsync(string command,int type, GroupMessageReceiver messageReceiver)
        {
            List<string> c = CommandStringParse(command);
            var commandType = "";
            var commandRight = false;
            var msg = "";
            if (c[0].Contains(CommandType.EXEC))
            {
                commandType = CommandType.EXEC;
            }
            else if (c[0].Contains(CommandType.ON))
            {
                commandType = CommandType.ON;
            }
            else if (c[0].Contains(CommandType.OFF))
            {
                commandType = CommandType.OFF;
            }
            else if (c[0].Contains(CommandType.CopyRead))
            {
                commandType = CommandType.CopyRead;
            }
            else
            {
                return null;
            }

            if (c.Count !=3)
            {
                var bot = Init.Instance();
                msg = commandType + " target params";
                var mgr = bot.GetManager<MessageManager>();
                if (type == 0)
                {
                    await mgr.SendGroupMessage(messageReceiver.Sender.Group.Id, "".Append(new AtMessage(messageReceiver.Sender.Id)).Append(ErrorBackInfo.ErrorBack(commandType)));
                }
                else
                {
                    await mgr.SendFriendMessage("","".Append());
                }
              
            }
            else
            {
                return null;
            }

            if (commandRight)
            {
                var attribute = new CommandAttribute
                {
                    CommandType = commandType,
                    Target = c[1],
                    Params = c[2]

                };
                return attribute;
            }
            else
            {
                return null;
            }
        }
    }

    //    public static IDictionary<string, string[]> Parse(string s)
    //    {
    //        var split = s
    //            .Empty($"{CommandTriggerAttribute.Prefix}{CommandTriggerAttribute.Name}")
    //            .Trim()
    //            .Split(' ')
    //            .Where(x => x.IsNotNullOrEmpty())
    //            .ToList();

        //        var re = new Dictionary<string, string[]>();
        //        var indexes = new List<int>();

        //        split
        //            .Where(x => x.StartsWith(CommandTriggerAttribute.ArgsSeparator))
        //            .ToList()
        //            .ForEach(x => indexes.Add(split.IndexOf(x)));

        //        foreach (var index in indexes)
        //        {
        //            int next;
        //            if (indexes.IndexOf(index) + 1 >= indexes.Count)
        //                next = split.Count - 1;
        //            else
        //                next = indexes[indexes.IndexOf(index) + 1];

        //            var range = next != split.Count - 1
        //                ? split.GetRange(index, next - index)
        //                : split.GetRange(index, split.Count - index);

        //            re.Add(range.First(), range.GetRange(1, range.Count - 1).ToArray());
        //        }

        //        return re;
        //    }
        //}
    }
