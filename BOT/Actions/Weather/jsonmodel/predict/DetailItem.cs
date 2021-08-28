using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookServer.NodeParse.Weather.jsonmodel.predict
{
    public class DetailItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Day day { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Night night { get; set; }
    }
}
