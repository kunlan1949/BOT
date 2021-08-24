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
    }
}
