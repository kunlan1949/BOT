using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookServer.NodeParse.Weather.jsonmodel
{
    public class Weather
    {
        /// <summary>
        /// 
        /// </summary>
        public double temperature { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double temperatureDiff { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double airpressure { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double humidity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double rain { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double rcomfort { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double icomfort { get; set; }
        /// <summary>
        /// 小雨
        /// </summary>
        public string info { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string img { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double feelst { get; set; }
    }
}
