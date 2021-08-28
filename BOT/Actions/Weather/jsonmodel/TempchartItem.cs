using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookServer.NodeParse.Weather.jsonmodel
{
    public class TempchartItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double max_temp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double min_temp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string day_img { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string day_text { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string night_img { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string night_text { get; set; }
    }
}
