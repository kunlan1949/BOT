using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public class GachaValueReturn
    {
        /// <summary>
        /// 物品名
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// 0为角色，1为武器
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 品级
        /// </summary>
        public int level { get; set; }
    }
}
