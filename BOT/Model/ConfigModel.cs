using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Model
{
    public class ConfigModel
    {
        /// <summary>
        /// QQ
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 校验码
        /// </summary>
        public string VerifyKey { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

    }
}
