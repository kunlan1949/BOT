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
        /// 数据库IP
        /// </summary>
        public string DataBaseIp { get; set; }

        /// <summary>
        /// 数据库端口
        /// </summary>
        public string DataBasePort{ get; set; }

        /// <summary>
        /// 数据库用户名
        /// </summary>
        public string DataBaseUid { get; set; }

        /// <summary>
        /// 数据库密码
        /// </summary>
        public string DataBasePwd { get; set; }

    }
}
