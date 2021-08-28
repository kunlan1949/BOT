using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookServer.NodeParse.Weather
{
    public class WeatherModel
    {
        /// <summary>
        /// Time
        /// </summary>
        public string CurrentTime { get; set; }

        /// <summary>
        /// 当前温度
        /// </summary>
        public string CurrentTemp { get; set; }

        /// <summary>
        /// 体感温度
        /// </summary>
        public string RealFeelst { get; set; }

        /// <summary>
        /// 最高温度
        /// </summary>
        public string TempHigh { get; set; }

        /// <summary>
        /// 最低温度
        /// </summary>
        public string TempLow { get; set; }

        /// <summary>
        /// 降水量
        /// </summary>
        public string Rain { get; set; }

        /// <summary>
        /// 相对湿度
        /// </summary>
        public string RelativeHumidity { get; set; }

        /// <summary>
        /// 风
        /// </summary>
        public Windy wind { get; set; }

        /// <summary>
        /// 空气质量
        /// </summary>
        public string AirQuality { get; set; }

        /// <summary>
        /// 天气
        /// </summary>
        public string Weather { get; set; }

    }

    public class Windy
    {
        /// <summary>
        /// 风向
        /// </summary>
        public string WindDirect { get; set; }
        /// <summary>
        /// 风速
        /// </summary>
        public string WindSpeed{ get; set; }

    }
}
