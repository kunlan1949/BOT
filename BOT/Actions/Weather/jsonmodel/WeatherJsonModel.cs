using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookServer.NodeParse.Weather.jsonmodel
{
    public class WeatherJsonModel
    {
        /// <summary>
        /// 返回消息
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 状态码
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public Data data { get; set; }
    }
}
