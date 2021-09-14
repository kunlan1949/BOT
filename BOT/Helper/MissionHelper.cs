using BOT.Handler.Func;
using BOT.Utils;
using Db.Bot;
using Mirai.Net.Data.Messages.Receivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BOT.Model.TypeHelper;

namespace BOT.Helper
{
    class MissionHelper
    {

        public static async Task SelectTypeAsync(Members member,GroupMessageReceiver receiver)
        {
            var m = missionExist(member.MissionId);
            if (m != null)
            {
                if (m.MType == (int)MissionType.SIMAGE)
                {
                    if (m.MTypeAux == 0)
                    {
                        await SImageHandler.exeAsync(member, receiver, 0);
                    }
                    else if (m.MTypeAux == 1)
                    {
                        await SImageHandler.exeAsync(member, receiver, 1);
                    }
                }
            }
        }

        public static void createMission(Members mem, GroupMessageReceiver messageReceiver,int mType,int aux)
        {
            var rand = UtilHelper.RandomGen(32, true, true, true);
            var mission = new MemMission()
            {
                MCreateMember = messageReceiver.Sender.Id,
                MGroup = messageReceiver.Sender.Group.Id,
                MType = mType,
                MTypeAux = aux,
                MCreateTime = UtilHelper.GetTimeUnix().ToString(),
                MFinishTime = "-1",
                MFinished = 0,
                MId = rand
            };
            mem.MissionId = rand;
            mission.Insert();
            mem.Update();
        }

        public static void endMission(Members mem,string id)
        {
            var mission = MemMission.Find(MemMission._.MId == id & MemMission._.MFinished == 0);
            if (mission != null)
            {
                mission.MFinished = 1;
                mission.MFinishTime = UtilHelper.GetTimeUnix().ToString();
                mission.Update();

                mem.MissionId = "";
                mem.Update();
            }
            else
            {
                Console.WriteLine("数据不存在，更新失败");
            }
        }

        public static MemMission missionExist(string id)
        {
            var mission = MemMission.Find(MemMission._.MId == id & MemMission._.MFinished == 0);

            return mission;
        }
    }
}
