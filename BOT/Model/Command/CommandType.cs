using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Model
{
    public class CommandType
    {
        public static string BOT = "AAA";

        public static string YESNO = "/yn";

        //根管理员关键字
        public static string EXEC = "/exec";
        public static string HELP = "/help";
        public static string BOTON = "/boton";
        public static string BOTOFF = "/botoff";

        public static string ADDADMIN = "/addadmin";
        public static string RMADMIN = "/rmadmin";
        //管理员关键字
        //开关机器人回应
        public static string SPEAK= "/speak";



        //通用关键字
        public static string GUSSNUM = "猜数字";


        ///增加复读关键字
        ///【/copyread [你好,早上好]】
        public static string CopyRead = "/copyread";



    }
}
