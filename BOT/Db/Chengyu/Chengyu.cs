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
    [BindTable("chengyu", Description = "", ConnName = "BotDb", DbType = DatabaseType.None)]
    public partial class Chengyu
    {
        #region 属性
        private Int32 _CyIdx;
        /// <summary>自增idx</summary>
        [DisplayName("自增idx")]
        [Description("自增idx")]
        [DataObjectField(true, true, false, 255)]
        [BindColumn("cy_idx", "自增idx", "int(255)")]
        public Int32 CyIdx { get => _CyIdx; set { if (OnPropertyChanging("CyIdx", value)) { _CyIdx = value; OnPropertyChanged("CyIdx"); } } }

        private String _CyName;
        /// <summary>成语名</summary>
        [DisplayName("成语名")]
        [Description("成语名")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("cy_name", "成语名", "varchar(255)")]
        public String CyName { get => _CyName; set { if (OnPropertyChanging("CyName", value)) { _CyName = value; OnPropertyChanged("CyName"); } } }

        private String _CyExplain;
        /// <summary>释义</summary>
        [DisplayName("释义")]
        [Description("释义")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("cy_explain", "释义", "varchar(255)")]
        public String CyExplain { get => _CyExplain; set { if (OnPropertyChanging("CyExplain", value)) { _CyExplain = value; OnPropertyChanged("CyExplain"); } } }

        private String _CyPy;
        /// <summary>拼音</summary>
        [DisplayName("拼音")]
        [Description("拼音")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("cy_py", "拼音", "varchar(255)")]
        public String CyPy { get => _CyPy; set { if (OnPropertyChanging("CyPy", value)) { _CyPy = value; OnPropertyChanged("CyPy"); } } }

        private String _CyFrom;
        /// <summary>出处</summary>
        [DisplayName("出处")]
        [Description("出处")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("cy_from", "出处", "varchar(255)")]
        public String CyFrom { get => _CyFrom; set { if (OnPropertyChanging("CyFrom", value)) { _CyFrom = value; OnPropertyChanged("CyFrom"); } } }

        private Int32 _CyType;
        /// <summary>开头拼音顺序</summary>
        [DisplayName("开头拼音顺序")]
        [Description("开头拼音顺序")]
        [DataObjectField(false, false, false, 11)]
        [BindColumn("cy_type", "开头拼音顺序", "int(11)")]
        public Int32 CyType { get => _CyType; set { if (OnPropertyChanging("CyType", value)) { _CyType = value; OnPropertyChanged("CyType"); } } }
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
                    case "CyIdx": return _CyIdx;
                    case "CyName": return _CyName;
                    case "CyExplain": return _CyExplain;
                    case "CyPy": return _CyPy;
                    case "CyFrom": return _CyFrom;
                    case "CyType": return _CyType;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "CyIdx": _CyIdx = value.ToInt(); break;
                    case "CyName": _CyName = Convert.ToString(value); break;
                    case "CyExplain": _CyExplain = Convert.ToString(value); break;
                    case "CyPy": _CyPy = Convert.ToString(value); break;
                    case "CyFrom": _CyFrom = Convert.ToString(value); break;
                    case "CyType": _CyType = value.ToInt(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得Chengyu字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>自增idx</summary>
            public static readonly Field CyIdx = FindByName("CyIdx");

            /// <summary>成语名</summary>
            public static readonly Field CyName = FindByName("CyName");

            /// <summary>释义</summary>
            public static readonly Field CyExplain = FindByName("CyExplain");

            /// <summary>拼音</summary>
            public static readonly Field CyPy = FindByName("CyPy");

            /// <summary>出处</summary>
            public static readonly Field CyFrom = FindByName("CyFrom");

            /// <summary>开头拼音顺序</summary>
            public static readonly Field CyType = FindByName("CyType");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得Chengyu字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>自增idx</summary>
            public const String CyIdx = "CyIdx";

            /// <summary>成语名</summary>
            public const String CyName = "CyName";

            /// <summary>释义</summary>
            public const String CyExplain = "CyExplain";

            /// <summary>拼音</summary>
            public const String CyPy = "CyPy";

            /// <summary>出处</summary>
            public const String CyFrom = "CyFrom";

            /// <summary>开头拼音顺序</summary>
            public const String CyType = "CyType";
        }
        #endregion
    }
}