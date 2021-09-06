using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BookServer.NodeParse.Weather.jsonmodel
{
    public class Air
    {
        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        public string forecasttime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        public double aqi { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        public double aq { get; set; }
        /// <summary>
        /// 优
        /// </summary>
        [DefaultValue("")]
        public string text { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        public string aqiCode { get; set; }
    }
}
