using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOT.Model.Func
{
    public class SteamInfoModel
    {
        /// <summary>
        /// 游戏名
        /// </summary>
        public string GameName { get; set; } 
        /// <summary>
        /// 游戏描述
        /// </summary>
        public string GameDesc { get; set; }

        /// <summary>
        /// 在线人数
        /// </summary>
        public string GameOnline { get; set; }

        /// <summary>
        /// 正常价格
        /// </summary>
        public string GamePrice { get; set; } = "-1";
        /// <summary>
        /// 打折后价格
        /// </summary>
        public string GameDcPrice { get; set; } = "-1";
        /// <summary>
        /// 打折前价格
        /// </summary>
        public string GameBdcPrice { get; set; } = "-1";

        /// <summary>
        /// 折扣力度
        /// </summary>
        public string GameDcPercent { get; set; } = "-1";

        /// <summary>
        /// 总体评价
        /// </summary>
        public string GameEvaStatus { get; set; } = "褒贬不一";

        /// <summary>
        /// 评价数量
        /// </summary>
        public string GameEvaCount { get; set; } = "0";

        /// <summary>
        /// 链接
        /// </summary>
        public string GameUrl { get; set; }

        /// <summary>
        /// 图片链接
        /// </summary>
        public string GameImgUrl { get; set; }

        /// <summary>
        ///游戏ID
        /// </summary>
        public string GameId { get; set; }
    }
}
