using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Model
{
    public class CommandType
    {
        public static string YESNO = "/yn";


        public static string EXEC = "/exec";
        public static string HELP = "/help";
        public static string ON = "/on";
        public static string OFF = "/off";

        ///增加复读关键字
        ///【/copyread [你好,早上好]】
        public static string CopyRead = "/copyread";



    }
}
