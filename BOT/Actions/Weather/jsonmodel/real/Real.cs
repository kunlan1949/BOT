using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookServer.NodeParse.Weather.jsonmodel;
using BookServer.NodeParse.Weather.jsonmodel.real;

namespace BookServer.NodeParse.Weather.jsonmodel
{
    public class Real
    {
        /// <summary>
        /// 
        /// </summary>
        public Station station { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string publish_time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Weather weather { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Wind wind { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Warn warn { get; set; }
    }
}
