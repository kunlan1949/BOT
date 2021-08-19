using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Model
{
    class ErrorBackInfo
    {
        public static string ErrorBack(string type)
        {
            string e = "";
            if(type==CommandType.EXEC)
            {
                e = $"你的{CommandType.EXEC}命令有错误,正确形式为:{CommandType.EXEC} target params";
            }
            return e;
        }
    }
}
