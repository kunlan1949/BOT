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
        /// <summary>
        /// 清空5星低保并存储数据
        /// </summary>
        /// <param name="gen">Genshin数据表</param>
        /// <param name="gacha">Gacha记录</param>
        /// <param name="isProtect">是否为低保</param>
        public static void Role5Mark(Genshin gen,GachaValueReturn gacha,bool isProtect)
        {
           
            if (gacha.type == 0)
            {
                gen.ResidentRole5 += 1;
                if (isProtect)
                {
                    gen.PortectRole += 1;
                }
            }
            else
            {
                gen.ResidentWeapon5 += 1;
                if (isProtect)
                {
                    gen.PortectWeapon += 1;
                }
            }
                //重置低保计次
            //gen.Resident5Count = 0;
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
            //重置低保计次
            gen.Resident4Count = 0;
            gen.Update();
        }

        /// <summary>
        /// 更新常驻低保次数:10连
        /// </summary>
        /// <param name="gen"></param>
        public static void ResidentMark(Genshin gen)
        {
            gen.Resident4Count += 10;


            gen.Resident5Count += 10;
            gen.Update();
        }
        /// <summary>
        /// 更新常驻低保次数:单抽
        /// </summary>
        /// <param name="gen"></param>
        public static void ResidentOneMark(Genshin gen)
        {
            gen.Resident4Count += 1;
            gen.Resident5Count += 1;
            gen.Update();
        }

    }
}
