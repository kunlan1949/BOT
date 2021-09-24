using BOT.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Model
{
    public class CommandType
    {
        public static string BOT = ConfigHelper.BName();

        public static string YESNO = "/yn";

        //根管理员关键字
        public static string EXEC = "/exec";
        public static string HELP = "/help";
        public static string BOTON = "/boton";
        public static string BOTOFF = "/botoff";

        public static string ADDADMIN = "/addadmin";
        public static string RMADMIN = "/rmadmin";
        //管理员关键字
        public static string TEST = "/test";

        //开关机器人回应
        public static string SPEAK= "/speak";



        //通用关键字
       
        public static string WEATHER = "天气";
        public static string IGUSS = "我猜";
        public static string ISOLI = "我接";
        public static string CANCEL = "结束";
        public static string LOTTERY = "大乐透";
        public static string CASHPRIZE = "兑奖";
        public static string TWENTYONE = "二十一点";
        public static string LUCKY = "运势";
        public static string TRANS = "翻译";
        public static string SGAME = "查游戏";
        public static string PLAYSONG = "点歌";
        public static string GENSHIN = "祈愿";

        ///增加复读关键字
        ///【/copyread [你好,早上好]】
        public static string CopyRead = "/copyread";

       

    }
}
