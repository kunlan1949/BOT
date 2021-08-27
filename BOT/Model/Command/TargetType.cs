using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Model
{
    class TargetType
    {
        public static string NO = "0";
        public static string YES = "1";

        /// 帮助条目        
        public static string HELP = "help";
        public static string FUNC = "1";
        public static string ONOFF = "2";

        //管理员管理
        public static string ADDROOT = "addroot";
        public static string RMROOT = "rmroot";


        //互动
        public static string REGISTER = "注册";
        public static string DELETE = "注销";
        public static string GUSSNUM = "猜数字";
        public static string CHENGYU = "成语接龙";


        public static Dictionary<string, int> Sign = new Dictionary<string, int>
        {
            {"白羊", 0},
            {"金牛", 1},
            {"双子", 2},
            {"巨蟹", 3},
            {"狮子", 4},
            {"处女", 5},
            {"天秤", 6},
            {"天蝎", 7},
            {"射手", 8},
            {"魔羯", 9},
            {"水瓶", 10},
            {"双鱼", 11},
        };

        public enum SIGN{
            /// <summary>
            /// 白羊座
            /// </summary>
            Aries,
            /// <summary>
            /// 金牛座
            /// </summary>
            Taurus = 0xFFA500,
            /// <summary>
            /// 双子座
            /// </summary>
            Gemini = 0xFFFF00,
            /// <summary>
            /// 巨蟹座
            /// </summary>
            Cancer = 0x00FF00,
            /// <summary>
            /// 狮子座
            /// </summary>
            Leo= 0x00FFFF,
            /// <summary>
            /// 处女座
            /// </summary>
            Virgo= 0x0000FF,
            /// <summary>
            /// 天秤座 
            /// </summary>
            Libra = 0x00FFFF,
            /// <summary>
            /// 天蝎座
            /// </summary>
            Scorpio= 0x0000FF,
            /// <summary>
            /// 射手座
            /// </summary>
            Sagittarius = 0x800080,
             /// <summary>
            /// 魔羯座
            /// </summary>
            Capricorn= 0x800080,
            /// <summary>
            /// 水瓶座
            /// </summary>
            Aquarius= 0x800080,
            /// <summary>
            /// 双鱼座
            /// </summary>
            Pisces= 0x800080
        }
    }
}
          
           
          
            
          
            
           
