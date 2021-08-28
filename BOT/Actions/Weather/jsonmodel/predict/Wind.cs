using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookServer.NodeParse.Weather.jsonmodel.predict
{
    public class Wind
    {
        /// <summary>
        /// 无持续风向
        /// </summary>
        public string direct { get; set; }
        /// <summary>
        /// 微风
        /// </summary>
        public string power { get; set; }
    }

}
