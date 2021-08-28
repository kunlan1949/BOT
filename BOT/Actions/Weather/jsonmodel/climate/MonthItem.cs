using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookServer.NodeParse.Weather.jsonmodel.climate
{
    public class MonthItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int month { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double maxTemp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double minTemp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double precipitation { get; set; }
    }
}
