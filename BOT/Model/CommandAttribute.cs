using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Model
{
    public class CommandAttribute
    {
        public string CommandType { get; set; }


        public string Target { get; set; }


        public string Params { get; set; }
    }
}
