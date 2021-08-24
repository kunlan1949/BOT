using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Db.Bot
{
    /// <summary></summary>
    [Serializable]
    [DataObject]
    [BindTable("lottery_ticket", Description = "", ConnName = "BotDb", DbType = DatabaseType.None)]
    public partial class LotteryTicket
    {
        #region 属性
        private Int32 _LeIdx;
        /// <summary>自增idx</summary>
        [DisplayName("自增idx")]
        [Description("自增idx")]
        [DataObjectField(true, true, false, 11)]
        [BindColumn("le_idx", "自增idx", "int(11)")]
        public Int32 LeIdx { get => _LeIdx; set { if (OnPropertyChanging("LeIdx", value)) { _LeIdx = value; OnPropertyChanged("LeIdx"); } } }

        private String _LeId;
        /// <summary>大乐透唯一标识码</summary>
        [DisplayName("大乐透唯一标识码")]
        [Description("大乐透唯一标识码")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("le_id", "大乐透唯一标识码", "varchar(255)")]
        public String LeId { get => _LeId; set { if (OnPropertyChanging("LeId", value)) { _LeId = value; OnPropertyChanged("LeId"); } } }

        private String _LeSn;
        /// <summary>大乐透兑换码</summary>
        [DisplayName("大乐透兑换码")]
        [Description("大乐透兑换码")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("le_sn", "大乐透兑换码", "varchar(255)")]
        public String LeSn { get => _LeSn; set { if (OnPropertyChanging("LeSn", value)) { _LeSn = value; OnPropertyChanged("LeSn"); } } }

        private Int32 _LeFinish;
        /// <summary>大乐透是否结束</summary>
        [DisplayName("大乐透是否结束")]
        [Description("大乐透是否结束")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("le_finish", "大乐透是否结束", "int(255)")]
        public Int32 LeFinish { get => _LeFinish; set { if (OnPropertyChanging("LeFinish", value)) { _LeFinish = value; OnPropertyChanged("LeFinish"); } } }

        private String _LeResult;
        /// <summary>大乐透开奖结果</summary>
        [DisplayName("大乐透开奖结果")]
        [Description("大乐透开奖结果")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("le_result", "大乐透开奖结果", "varchar(255)")]
        public String LeResult { get => _LeResult; set { if (OnPropertyChanging("LeResult", value)) { _LeResult = value; OnPropertyChanged("LeResult"); } } }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public override Object this[String name]
        {
            get
            {
                switch (name)
                {
                    case "LeIdx": return _LeIdx;
                    case "LeId": return _LeId;
                    case "LeSn": return _LeSn;
                    case "LeFinish": return _LeFinish;
                    case "LeResult": return _LeResult;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "LeIdx": _LeIdx = value.ToInt(); break;
                    case "LeId": _LeId = Convert.ToString(value); break;
                    case "LeSn": _LeSn = Convert.ToString(value); break;
                    case "LeFinish": _LeFinish = value.ToInt(); break;
                    case "LeResult": _LeResult = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得LotteryTicket字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>自增idx</summary>
            public static readonly Field LeIdx = FindByName("LeIdx");

            /// <summary>大乐透唯一标识码</summary>
            public static readonly Field LeId = FindByName("LeId");

            /// <summary>大乐透兑换码</summary>
            public static readonly Field LeSn = FindByName("LeSn");

            /// <summary>大乐透是否结束</summary>
            public static readonly Field LeFinish = FindByName("LeFinish");

            /// <summary>大乐透开奖结果</summary>
            public static readonly Field LeResult = FindByName("LeResult");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得LotteryTicket字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>自增idx</summary>
            public const String LeIdx = "LeIdx";

            /// <summary>大乐透唯一标识码</summary>
            public const String LeId = "LeId";

            /// <summary>大乐透兑换码</summary>
            public const String LeSn = "LeSn";

            /// <summary>大乐透是否结束</summary>
            public const String LeFinish = "LeFinish";

            /// <summary>大乐透开奖结果</summary>
            public const String LeResult = "LeResult";
        }
        #endregion
    }
}