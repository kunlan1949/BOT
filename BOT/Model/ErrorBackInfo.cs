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
       
            e = $"错误的{type}命令,正确形式为: 【{type}】【target】 [params] NOTE：【必填】[选填]）";
            
            return e;
        }
    }
}
