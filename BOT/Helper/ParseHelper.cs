using AHpx.Extensions.StringExtensions;
using BOT.Model;
using BOT.Module.Send;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Data.Modules;
using Mirai.Net.Sessions;
using Mirai.Net.Utils;
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

        public static async Task<CommandAttribute> GroupCommandAsync(string command, GroupMessageReceiver messageReceiver)
        {
            List<string> c = CommandStringParse(command);
            var commandType = "";
            bool needParam = true;
            var commandRight = true;
            if (c[0].Contains(CommandType.EXEC))
            {
                commandType = CommandType.EXEC;
            }
            else if (c[0].Contains(CommandType.BOTON))
            {
                commandType = CommandType.BOTON;
            }
            else if (c[0].Contains(CommandType.BOTOFF))
            {
                commandType = CommandType.BOTOFF;
            }
            else if (c[0].Contains(CommandType.CopyRead))
            {
                commandType = CommandType.CopyRead;
            }
            else if (c[0].Contains(CommandType.LOTTERY))
            {
                commandType = CommandType.LOTTERY;
            }
            else if (c[0].Contains(CommandType.CASHPRIZE))
            {
                commandType = CommandType.CASHPRIZE;
            }
            else if (c[0].Contains(CommandType.WEATHER))
            {
                commandType = CommandType.WEATHER;
            }
            else if(c[0].Contains(CommandType.BOT))
            {
                commandType = CommandType.BOT;
            }
            else if (c[0].Contains(CommandType.LUCKY))
            {
                commandType = CommandType.LUCKY;
            }
            else if (c[0].Contains(CommandType.IGUSS))
            {
                commandType = CommandType.IGUSS;
            }
            else if (c[0].Contains(CommandType.ISOLI))
            {
                commandType = CommandType.ISOLI;
            }
            else if (c[0].Contains(CommandType.TWENTYONE))
            {
                commandType = CommandType.TWENTYONE;
            }
            else if (c[0].Contains(CommandType.CANCEL))
            {
                commandType = CommandType.CANCEL;
            }
            else if (c[0].Contains(CommandType.TRANS))
            {
                needParam = false;
                commandType = CommandType.TRANS;
            }
            else if (c[0].Contains(CommandType.PLAYSONG))
            {
                needParam = false;
                commandType = CommandType.PLAYSONG;
            }
            else if (c[0].Contains(CommandType.SGAME))
            {
                needParam = false;
                commandType = CommandType.SGAME;
            }
            else if (c[0].Contains(CommandType.GENSHIN))
            {
                needParam = false;
                commandType = CommandType.GENSHIN;
            }
            else
            {
                return null;
            }

            if (c.Count <=1)
            {
                commandRight = false;
                await SendGroupMessageModule.sendGroupAtAsync(messageReceiver, ErrorBackInfo.ErrorBack(commandType),false);
                //}
                //else
                //{
                //    await mgr.SendFriendMessage("","".Append());
                //}
              
            }

            if (commandRight)
            {
                var p = "";
                var tar = c[1];
                if (c.Count <= 2)
                {
                    p = "";
                }
                else
                {
                    p = c[2];
                }
                if (!needParam)
                {
                    if (commandType.Contains(CommandType.TRANS))
                    {
                        tar = command.Replace($"{CommandType.TRANS} ", "");
                    }
                    else if (commandType.Contains(CommandType.SGAME))
                    {
                        tar = command.Replace($"{CommandType.SGAME} ", "");
                    }
                    p = "";
                }
                var attribute = new CommandAttribute
                {
                    CommandType = commandType,
                    Target = tar,
                    Params = p
                };
                return attribute;
            }
            else
            {
                return null;
            }
        }
        public static async Task<CommandAttribute> FriendCommandAsync(string command, FriendMessageReceiver messageReceiver)
        {
            List<string> c = CommandStringParse(command);
            var commandType = "";
            var commandRight = true;
            if (c[0].Contains(CommandType.EXEC))
            {
                commandType = CommandType.EXEC;
                if (c.Count <= 1)
                {
                    commandRight = false;
                    await SendFriendMessageModule.sendFriendAsync(messageReceiver, ErrorBackInfo.ErrorBack(commandType));
                }
            }
            else if (c[0].Contains(CommandType.BOTON))
            {
                commandType = CommandType.BOTON;
            }
            else if (c[0].Contains(CommandType.BOTOFF))
            {
                commandType = CommandType.BOTOFF;
            }
            else if (c[0].Contains(CommandType.CopyRead))
            {
                commandType = CommandType.CopyRead;
            }
            else if (c[0].Contains(CommandType.HELP))
            {
                commandType = CommandType.HELP;
            }
            else if (c[0].Contains(CommandType.YESNO))
            {
                commandType = CommandType.YESNO;
            }
            else if (c[0].Contains(CommandType.ADDADMIN))
            {
                commandType = CommandType.ADDADMIN;
            }
            else if (c[0].Contains(CommandType.RMADMIN))
            {
                commandType = CommandType.RMADMIN;
            }
            else if (c[0].Contains(CommandType.TEST))
            {
                commandType = CommandType.TEST;
            }
            else
            {
                return null;
            }

            

            if (commandRight)
            {
                var p = "";
                if (c.Count <= 2)
                {
                    p = "";
                }
                else
                {
                    p = c[2];
                }
                var attribute = new CommandAttribute
                {
                    CommandType = commandType,
                    Target = c[1],
                    Params = p

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
