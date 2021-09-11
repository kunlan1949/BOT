using BOT.Model.Func;
using BOT.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace BOT.Actions.Trans
{
    class TranslateAction
    {
        public static string GetTranslate(string word)
        {
            string trans = "";
            try
            {
                var url = "http://fanyi.youdao.com/translate?smartresult=dict&smartresult=rule";
                var headers = new WebHeaderCollection();
                headers["Content-Type"] = "application/x-www-form-urlencoded";
                headers["user-agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36";
                headers["Referer"] = "https://www.lagou.com/jobs/list_unity3d?labelWords=&fromSearch=true&suginput=";

                var p = GetParam(word);
                var dict = new Dictionary<string, string>()
                {
                    {"i",word.Replace(" ","+") },
                    {"from","AUTO" },
                    {"to","AUTO" },
                    {"smartresult","dict" },
                    {"client", "fanyideskweb" },
                    {"salt",p.Salt },
                    {"sign",p.Sign },
                    {"ts" ,p.Ts },
                    {"bv",p.Bv},
                    {"doctype","json" },
                    {"version","2.1"},
                    {"keyfrom","fanyi.web"},
                    {"action","FY_BY_REALTlME" }
                };
                var str = PostInf(url, headers, GetPostArgs(dict));

                using (var dt = JsonDocument.Parse(str))
                {
                    for(int i=0;i< dt.RootElement.GetProperty("translateResult")[0].GetArrayLength(); i++)
                    {
                        trans+= dt.RootElement.GetProperty("translateResult")[0][i].GetProperty("tgt").ToString();
                    }
                        
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return trans;
        }



        private static ParamModel GetParam(string searchWord)
        {
            //时间戳+四位随机
            var salt = "";

            //时间戳+四位随机中的前三位(TimeStamp)
            var ts = "";

            // md5加密 【fanyideskweb】（固定）+ 【翻译单词】 + 【salt】 + 【n%A-rKaT5fb[Gy?;N5@Tj】（固定）
            var sign = "";

            //根据浏览器版本生成的字串（BrowserVersion）
            //【Firefox Version】: 5.0 (Windows) 
            //【Chrome Version】: 5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/92.0.4515.159 Safari/537.36
            //通过navigator.appVersion函数获取后MD5加密
            //【Chrome MD5】89e18957825871c419be045180c67d3b
            //【Firefox MD5】e2a78ed30c66e16a857c5b6486a1d326
            var bv = "";

            var rand = UtilHelper.RandomGen(4, true, false, false);
            var time = UtilHelper.GetTimeUnix().ToString();

            salt = time + rand;
            ts = time + rand.Substring(0, 3);
            sign = $"fanyideskweb+{searchWord}+{salt}+n%A-rKaT5fb[Gy?;N5@Tj";
            bv = "e2a78ed30c66e16a857c5b6486a1d326";

            var p = new ParamModel() { Ts = ts, Salt = salt, Sign = sign, Bv = bv };
            return p;
        }




        /// <summary>
        /// 把字典转化为请求字符串
        /// </summary>
        /// <param name="dict">参数字典</param>
        /// <returns>返回请求字符串</returns>
        private static string GetPostArgs(Dictionary<string, string> dict)
        {
            StringBuilder sb = new StringBuilder();
            bool first = true;
            foreach (var item in dict)
            {
                if (first)
                {
                    sb.Append(item.Key);
                    sb.Append("=");
                    sb.Append(item.Value);
                    first = false;
                }
                else
                {
                    sb.Append("&");
                    sb.Append(item.Key);
                    sb.Append("=");
                    sb.Append(item.Value);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 发送Post请求
        /// </summary>
        /// <param name="url">连接</param>
        /// <param name="headers">HTTP头</param>
        /// <param name="str">请求字符串</param>
        /// <returns>返回结果</returns>
        private static string PostInf(string url, WebHeaderCollection headers, string str)
        {
            //创建HTTP请求
            var re = WebRequest.Create(url) as HttpWebRequest;
            //设置请求头
            //re.Headers = headers;
            re.ContentType = "application/x-www-form-urlencoded";
            re.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36";
            re.Referer = "https://www.lagou.com/jobs/list_unity3d?labelWords=&fromSearch=true&suginput=";
            //设置访问类型为POST
            re.Method = "POST";
            //写入请求信息
            using (StreamWriter sw = new StreamWriter(re.GetRequestStream()))
            {
                sw.WriteLine(str);
            }
            //获取相应内容
            var ans = re.GetResponse();
            using (var st = new StreamReader(ans.GetResponseStream()))
            {
                return st.ReadToEnd();
            }
        }
    }


}
