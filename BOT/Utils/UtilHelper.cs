using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Utils
{
    class UtilHelper
    {
            /// <summary>
            /// 获取标准UTC时间
            /// </summary>
            /// <returns></returns>
            public static long GetUTCTimeUnix()
            {
                long time = ToUnixTimestampBySeconds(DateTime.UtcNow);
                return time;
            }
            /// <summary>
            /// 获取标准本地时间
            /// </summary>
            /// <returns></returns>
            public static long GetTimeUnix()
            {
                long time = ToUnixTimestampBySeconds(DateTime.Now);
                return time;
            }


            public static string RandomGen(int length, bool useNum, bool useLow, bool useUpp)
            {
                byte[] b = new byte[4];
                new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
                Random r = new Random(BitConverter.ToInt32(b, 0));
                string s = null, str = "";
                if (useNum == true) { str += "0123456789"; }
                if (useLow == true) { str += "abcdefghijklmnopqrstuvwxyz"; }
                if (useUpp == true) { str += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; }
                for (int i = 0; i < length; i++)
                {
                    s += str.Substring(r.Next(0, str.Length - 1), 1);
                }
                return s;
            }

        public static long ToUnixTimestampBySeconds(DateTime dt)
        {
            DateTimeOffset dto = new DateTimeOffset(dt);
            return dto.ToUnixTimeSeconds();
        }

        public static string ToPoint(int num,bool pow)
        {
            int p = 1;
            var addon = 0;
            if (pow)
            {
                addon = (int)Math.Pow(10, num - 1);
                p = p * addon;
            }
            else
            {
                addon = num+1;
                p = p * addon;
            }

            return p.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool ISTODAY(string time)
        {
            var istoday = false;
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(double.Parse(time)).ToLocalTime();
            

            DateTime now = DateTime.Now;
            DateTime next = DateTime.Now.AddDays(1);
            DateTime today = new DateTime(now.Year, now.Month, now.Day);//当天的零时零分
            DateTime nextday = new DateTime(next.Year, next.Month, next.Day);//次日的零时零分
            if (dtDateTime > today)
            {
                if (dtDateTime < nextday)
                {
                    istoday = true;
                }
            }
            return istoday;
        }

        public static string ConvertFirstUpper(string str)
        {
            var sStr = str.ToLower();
            var dStr = "";
            if (sStr.Length > 1)
            {
                dStr = sStr.Substring(0, 1).ToUpper() + sStr.Substring(1);
            }
            else
            {
                dStr = str;
            }
           
            return dStr;
        }
    }
    
}
