using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookServer.NodeParse.Weather.jsonmodel.predict;

namespace BookServer.NodeParse.Weather.jsonmodel
{
    public class Predict
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
        public List<DetailItem> detail { get; set; }
    }
}
