using Db.Bot;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Actions.genshin
{
    class GenshinDataAction
    {
        public static void Role5Mark(Genshin gen,GachaValueReturn gacha)
        {
            if (gacha.type == 0)
            {
                gen.ResidentRole5 += 1;
                gen.PortectRole += 1;
            }
            else
            {
                gen.ResidentWeapon5 += 1;
                gen.PortectWeapon += 1;
            }
            gen.Update();
        }

        public static void Role4Mark(Genshin gen, GachaValueReturn gacha)
        {
            if (gacha.type == 0)
            {
                gen.ResidentRole4 += 1;
            }
            else
            {
                gen.ResidentWeapon4 += 1;
            }
            gen.Update();
        }
    }
}
