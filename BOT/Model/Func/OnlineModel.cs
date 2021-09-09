using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOT.Model.Func
{
    public class OnlineModel
    {
       
        public Response response { get; set; }
        
    }

    public class Response
    {

        /// <summary>
        /// 
        /// </summary>
        public int player_count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int result { get; set; }
    }
}
