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
    [BindTable("constellation", Description = "", ConnName = "BotDb", DbType = DatabaseType.None)]
    public partial class Constellation
    {
        #region 属性
        private Int32 _Idx;
        /// <summary>自增，idx</summary>
        [DisplayName("自增")]
        [Description("自增，idx")]
        [DataObjectField(true, true, false, 255)]
        [BindColumn("idx", "自增，idx", "int(255)")]
        public Int32 Idx { get => _Idx; set { if (OnPropertyChanging("Idx", value)) { _Idx = value; OnPropertyChanged("Idx"); } } }

        private String _Sign;
        /// <summary>星座</summary>
        [DisplayName("星座")]
        [Description("星座")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("sign", "星座", "varchar(255)")]
        public String Sign { get => _Sign; set { if (OnPropertyChanging("Sign", value)) { _Sign = value; OnPropertyChanged("Sign"); } } }

        private String _UpdateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("update_time", "更新时间", "varchar(255)")]
        public String UpdateTime { get => _UpdateTime; set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } } }

        private String _LuckResult;
        /// <summary>运势内容</summary>
        [DisplayName("运势内容")]
        [Description("运势内容")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("luck_result", "运势内容", "varchar(255)")]
        public String LuckResult { get => _LuckResult; set { if (OnPropertyChanging("LuckResult", value)) { _LuckResult = value; OnPropertyChanged("LuckResult"); } } }
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
                    case "Idx": return _Idx;
                    case "Sign": return _Sign;
                    case "UpdateTime": return _UpdateTime;
                    case "LuckResult": return _LuckResult;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Idx": _Idx = value.ToInt(); break;
                    case "Sign": _Sign = Convert.ToString(value); break;
                    case "UpdateTime": _UpdateTime = Convert.ToString(value); break;
                    case "LuckResult": _LuckResult = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得Constellation字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>自增，idx</summary>
            public static readonly Field Idx = FindByName("Idx");

            /// <summary>星座</summary>
            public static readonly Field Sign = FindByName("Sign");

            /// <summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName("UpdateTime");

            /// <summary>运势内容</summary>
            public static readonly Field LuckResult = FindByName("LuckResult");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得Constellation字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>自增，idx</summary>
            public const String Idx = "Idx";

            /// <summary>星座</summary>
            public const String Sign = "Sign";

            /// <summary>更新时间</summary>
            public const String UpdateTime = "UpdateTime";

            /// <summary>运势内容</summary>
            public const String LuckResult = "LuckResult";
        }
        #endregion
    }
}