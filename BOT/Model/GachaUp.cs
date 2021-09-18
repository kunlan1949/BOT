using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Model
{
    class GachaUp
    {

        //Up角色
        public static int Role5Up = 6;
        public static int Role4Up = 51;

        //Up武器
        public static int Weapon5Up = 7;
        public static int Weapon4Up = 60;

        //常驻
        public static int Resident5 = 6;
        public static int Resident4 = 51;

        public static string star(int num)
        {
            var result = "";
            switch (num)
            {
                case 3: { result = "★★★"; break; }
                case 4: { result = "★★★★"; break; }
                case 5: { result = "★★★★★"; break; }
            }
            return result;
        }

    }
}
