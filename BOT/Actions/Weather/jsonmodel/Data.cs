using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookServer.NodeParse.Weather.jsonmodel
{

    public class Data
    {
        /// <summary>
        /// 目前值
        /// </summary>
        public Real real { get; set; }
        /// <summary>
        /// 预测值
        /// </summary>
        public Predict predict { get; set; }
        /// <summary>
        /// 空气
        /// </summary>
        public Air air { get; set; }
        /// <summary>
        /// 温度表
        /// </summary>
        public List<TempchartItem> tempchart { get; set; }
        /// <summary>
        /// 通行表
        /// </summary>
        public List<PassedchartItem> passedchart { get; set; }
        /// <summary>
        /// 气候背景
        /// </summary>
        public Climate climate { get; set; }
        /// <summary>
        /// 雷达
        /// </summary>
        public Radar radar { get; set; }
    }
    
}
