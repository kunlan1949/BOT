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
    [BindIndex("PRIMARY", true, "w_idx,w_name")]
    [BindIndex("PRIMARY", true, "w_idx,w_name")]
    [BindTable("word", Description = "", ConnName = "BotDb", DbType = DatabaseType.None)]
    public partial class Word
    {
        #region 属性
        private Int32 _WIdx;
        /// <summary>自增idx</summary>
        [DisplayName("自增idx")]
        [Description("自增idx")]
        [DataObjectField(true, true, false, 255)]
        [BindColumn("w_idx", "自增idx", "int(255)")]
        public Int32 WIdx { get => _WIdx; set { if (OnPropertyChanging("WIdx", value)) { _WIdx = value; OnPropertyChanged("WIdx"); } } }

        private String _WName;
        /// <summary>字名</summary>
        [DisplayName("字名")]
        [Description("字名")]
        [DataObjectField(true, false, false, 255)]
        [BindColumn("w_name", "字名", "varchar(255)")]
        public String WName { get => _WName; set { if (OnPropertyChanging("WName", value)) { _WName = value; OnPropertyChanged("WName"); } } }

        private String _WTName;
        /// <summary>繁体名</summary>
        [DisplayName("繁体名")]
        [Description("繁体名")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("w_t_name", "繁体名", "varchar(255)")]
        public String WTName { get => _WTName; set { if (OnPropertyChanging("WTName", value)) { _WTName = value; OnPropertyChanged("WTName"); } } }

        private Int32 _WStrokes;
        /// <summary>笔画数量</summary>
        [DisplayName("笔画数量")]
        [Description("笔画数量")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("w_strokes", "笔画数量", "int(255)")]
        public Int32 WStrokes { get => _WStrokes; set { if (OnPropertyChanging("WStrokes", value)) { _WStrokes = value; OnPropertyChanged("WStrokes"); } } }

        private String _WPy;
        /// <summary>拼音</summary>
        [DisplayName("拼音")]
        [Description("拼音")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("w_py", "拼音", "varchar(255)")]
        public String WPy { get => _WPy; set { if (OnPropertyChanging("WPy", value)) { _WPy = value; OnPropertyChanged("WPy"); } } }

        private String _WRadicals;
        /// <summary>偏旁</summary>
        [DisplayName("偏旁")]
        [Description("偏旁")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("w_radicals", "偏旁", "varchar(255)")]
        public String WRadicals { get => _WRadicals; set { if (OnPropertyChanging("WRadicals", value)) { _WRadicals = value; OnPropertyChanged("WRadicals"); } } }

        private String _WExplain;
        /// <summary>释义</summary>
        [DisplayName("释义")]
        [Description("释义")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("w_explain", "释义", "longtext")]
        public String WExplain { get => _WExplain; set { if (OnPropertyChanging("WExplain", value)) { _WExplain = value; OnPropertyChanged("WExplain"); } } }
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
                    case "WIdx": return _WIdx;
                    case "WName": return _WName;
                    case "WTName": return _WTName;
                    case "WStrokes": return _WStrokes;
                    case "WPy": return _WPy;
                    case "WRadicals": return _WRadicals;
                    case "WExplain": return _WExplain;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "WIdx": _WIdx = value.ToInt(); break;
                    case "WName": _WName = Convert.ToString(value); break;
                    case "WTName": _WTName = Convert.ToString(value); break;
                    case "WStrokes": _WStrokes = value.ToInt(); break;
                    case "WPy": _WPy = Convert.ToString(value); break;
                    case "WRadicals": _WRadicals = Convert.ToString(value); break;
                    case "WExplain": _WExplain = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得Word字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>自增idx</summary>
            public static readonly Field WIdx = FindByName("WIdx");

            /// <summary>字名</summary>
            public static readonly Field WName = FindByName("WName");

            /// <summary>繁体名</summary>
            public static readonly Field WTName = FindByName("WTName");

            /// <summary>笔画数量</summary>
            public static readonly Field WStrokes = FindByName("WStrokes");

            /// <summary>拼音</summary>
            public static readonly Field WPy = FindByName("WPy");

            /// <summary>偏旁</summary>
            public static readonly Field WRadicals = FindByName("WRadicals");

            /// <summary>释义</summary>
            public static readonly Field WExplain = FindByName("WExplain");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得Word字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>自增idx</summary>
            public const String WIdx = "WIdx";

            /// <summary>字名</summary>
            public const String WName = "WName";

            /// <summary>繁体名</summary>
            public const String WTName = "WTName";

            /// <summary>笔画数量</summary>
            public const String WStrokes = "WStrokes";

            /// <summary>拼音</summary>
            public const String WPy = "WPy";

            /// <summary>偏旁</summary>
            public const String WRadicals = "WRadicals";

            /// <summary>释义</summary>
            public const String WExplain = "WExplain";
        }
        #endregion
    }
}