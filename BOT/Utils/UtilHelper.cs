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
    }
    
}
