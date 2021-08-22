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
    [BindTable("t_mission", Description = "", ConnName = "BotDb", DbType = DatabaseType.None)]
    public partial class TMission
    {
        #region 属性
        private Int32 _MIdx;
        /// <summary>任务idx</summary>
        [DisplayName("任务idx")]
        [Description("任务idx")]
        [DataObjectField(true, true, false, 255)]
        [BindColumn("m_idx", "任务idx", "int(255)")]
        public Int32 MIdx { get => _MIdx; set { if (OnPropertyChanging("MIdx", value)) { _MIdx = value; OnPropertyChanged("MIdx"); } } }

        private String _MId;
        /// <summary>任务所属QQ</summary>
        [DisplayName("任务所属QQ")]
        [Description("任务所属QQ")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("m_id", "任务所属QQ", "varchar(255)")]
        public String MId { get => _MId; set { if (OnPropertyChanging("MId", value)) { _MId = value; OnPropertyChanged("MId"); } } }

        private String _MType;
        /// <summary>任务命令类型。。</summary>
        [DisplayName("任务命令类型")]
        [Description("任务命令类型。。")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("m_type", "任务命令类型。。", "varchar(255)")]
        public String MType { get => _MType; set { if (OnPropertyChanging("MType", value)) { _MType = value; OnPropertyChanged("MType"); } } }

        private String _MTarget;
        /// <summary>任务命令目标</summary>
        [DisplayName("任务命令目标")]
        [Description("任务命令目标")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("m_target", "任务命令目标", "varchar(255)")]
        public String MTarget { get => _MTarget; set { if (OnPropertyChanging("MTarget", value)) { _MTarget = value; OnPropertyChanged("MTarget"); } } }

        private String _MParam;
        /// <summary>任务命令参数</summary>
        [DisplayName("任务命令参数")]
        [Description("任务命令参数")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("m_param", "任务命令参数", "varchar(255)")]
        public String MParam { get => _MParam; set { if (OnPropertyChanging("MParam", value)) { _MParam = value; OnPropertyChanged("MParam"); } } }

        private String _MFinish;
        /// <summary>任务是否完成</summary>
        [DisplayName("任务是否完成")]
        [Description("任务是否完成")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("m_finish", "任务是否完成", "varchar(255)")]
        public String MFinish { get => _MFinish; set { if (OnPropertyChanging("MFinish", value)) { _MFinish = value; OnPropertyChanged("MFinish"); } } }
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
                    case "MIdx": return _MIdx;
                    case "MId": return _MId;
                    case "MType": return _MType;
                    case "MTarget": return _MTarget;
                    case "MParam": return _MParam;
                    case "MFinish": return _MFinish;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "MIdx": _MIdx = value.ToInt(); break;
                    case "MId": _MId = Convert.ToString(value); break;
                    case "MType": _MType = Convert.ToString(value); break;
                    case "MTarget": _MTarget = Convert.ToString(value); break;
                    case "MParam": _MParam = Convert.ToString(value); break;
                    case "MFinish": _MFinish = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得TMission字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>任务idx</summary>
            public static readonly Field MIdx = FindByName("MIdx");

            /// <summary>任务所属QQ</summary>
            public static readonly Field MId = FindByName("MId");

            /// <summary>任务命令类型。。</summary>
            public static readonly Field MType = FindByName("MType");

            /// <summary>任务命令目标</summary>
            public static readonly Field MTarget = FindByName("MTarget");

            /// <summary>任务命令参数</summary>
            public static readonly Field MParam = FindByName("MParam");

            /// <summary>任务是否完成</summary>
            public static readonly Field MFinish = FindByName("MFinish");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得TMission字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>任务idx</summary>
            public const String MIdx = "MIdx";

            /// <summary>任务所属QQ</summary>
            public const String MId = "MId";

            /// <summary>任务命令类型。。</summary>
            public const String MType = "MType";

            /// <summary>任务命令目标</summary>
            public const String MTarget = "MTarget";

            /// <summary>任务命令参数</summary>
            public const String MParam = "MParam";

            /// <summary>任务是否完成</summary>
            public const String MFinish = "MFinish";
        }
        #endregion
    }
}