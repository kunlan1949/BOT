using Db.Bot;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Events.Concretes.Request;
using Mirai.Net.Data.Messages;
using Mirai.Net.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Module.Event
{
    class NewFriendRequestedModule 
    {
        public bool? IsEnable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Execute(RequestedEventBase @base)
        {
            if (@base is NewFriendRequestedEvent receiver)
            {
                Console.WriteLine(receiver.FromId);
                Console.WriteLine(receiver.Message);
                var m =RootAdmin.Find(RootAdmin._.AdminQq == receiver.FromId);
                if (m != null)
                {
                    Console.Write("属于根管理员");

                }
                else
                {
                    Console.Write("不属于根管理员");
                }
            }
        }
    }
}
