using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Utils
{
    class WeatherUtil
    {
        public static string AirQuality(string AQI)
        {
            int aqi = int.Parse(AQI);
            var aq = "";
            if (aqi <= 50 && aqi>=0)
            {
                aq = "优";
            }
            else if (aqi <= 100 && aqi >= 51)
            {
                aq = "良";
            }
            else if (aqi <= 150 && aqi >= 101)
            {
                aq = "轻度污染";
            }
            else if (aqi <= 200 && aqi >= 151)
            {
                aq = "中度污染";
            }
            else if (aqi <= 300 && aqi >= 200)
            {
                aq = "重度污染";
            }
            else if (aqi > 300)
            {
                aq = "严重污染";
            }

            return aq;
        }
    }
}
