using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookServer.NodeParse.Weather.jsonmodel
{
    public class Air
    {
        /// <summary>
        /// 
        /// </summary>
        public string forecasttime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double aqi { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double aq { get; set; }
        /// <summary>
        /// 优
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string aqiCode { get; set; }
    }
}
