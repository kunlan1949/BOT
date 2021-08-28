using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookServer.NodeParse.Weather.jsonmodel
{
    public class PassedchartItem
    {
        /// <summary>
        /// 
        /// </summary>
        public double rain1h { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double rain24h { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double rain12h { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double rain6h { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double temperature { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string tempDiff { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double humidity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double pressure { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double windDirection { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double windSpeed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string time { get; set; }
    }
}
