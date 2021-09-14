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
    [BindTable("mem_mission", Description = "", ConnName = "BotDb", DbType = DatabaseType.None)]
    public partial class MemMission
    {
        #region 属性
        private Int32 _MIdx;
        /// <summary>自增idx</summary>
        [DisplayName("自增idx")]
        [Description("自增idx")]
        [DataObjectField(true, true, false, 255)]
        [BindColumn("m_idx", "自增idx", "int(255)")]
        public Int32 MIdx { get => _MIdx; set { if (OnPropertyChanging("MIdx", value)) { _MIdx = value; OnPropertyChanged("MIdx"); } } }

        private String _MId;
        /// <summary>随机32位任务码 (将分配给创建者)</summary>
        [DisplayName("随机32位任务码")]
        [Description("随机32位任务码 (将分配给创建者)")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("m_id", "随机32位任务码 (将分配给创建者)", "varchar(255)")]
        public String MId { get => _MId; set { if (OnPropertyChanging("MId", value)) { _MId = value; OnPropertyChanged("MId"); } } }

        private Int32 _MType;
        /// <summary>任务类型：0为识图，1为</summary>
        [DisplayName("任务类型：0为识图")]
        [Description("任务类型：0为识图，1为")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("m_type", "任务类型：0为识图，1为", "int(255)")]
        public Int32 MType { get => _MType; set { if (OnPropertyChanging("MType", value)) { _MType = value; OnPropertyChanged("MType"); } } }

        private Int32 _MTypeAux;
        /// <summary>辅助类型，补充说明</summary>
        [DisplayName("辅助类型")]
        [Description("辅助类型，补充说明")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("m_type_aux", "辅助类型，补充说明", "int(255)")]
        public Int32 MTypeAux { get => _MTypeAux; set { if (OnPropertyChanging("MTypeAux", value)) { _MTypeAux = value; OnPropertyChanged("MTypeAux"); } } }

        private String _MGroup;
        /// <summary>发起的群号</summary>
        [DisplayName("发起的群号")]
        [Description("发起的群号")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("m_group", "发起的群号", "varchar(255)")]
        public String MGroup { get => _MGroup; set { if (OnPropertyChanging("MGroup", value)) { _MGroup = value; OnPropertyChanged("MGroup"); } } }

        private String _MCreateMember;
        /// <summary>创建者QQ号</summary>
        [DisplayName("创建者QQ号")]
        [Description("创建者QQ号")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("m_create_member", "创建者QQ号", "varchar(255)")]
        public String MCreateMember { get => _MCreateMember; set { if (OnPropertyChanging("MCreateMember", value)) { _MCreateMember = value; OnPropertyChanged("MCreateMember"); } } }

        private String _MCreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("m_create_time", "创建时间", "varchar(255)")]
        public String MCreateTime { get => _MCreateTime; set { if (OnPropertyChanging("MCreateTime", value)) { _MCreateTime = value; OnPropertyChanged("MCreateTime"); } } }

        private String _MFinishTime;
        /// <summary>结束时间</summary>
        [DisplayName("结束时间")]
        [Description("结束时间")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("m_finish_time", "结束时间", "varchar(255)")]
        public String MFinishTime { get => _MFinishTime; set { if (OnPropertyChanging("MFinishTime", value)) { _MFinishTime = value; OnPropertyChanged("MFinishTime"); } } }

        private Int32 _MFinished;
        /// <summary>完成状态（1为完成，0为未完成）</summary>
        [DisplayName("完成状态")]
        [Description("完成状态（1为完成，0为未完成）")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("m_finished", "完成状态（1为完成，0为未完成）", "int(255)")]
        public Int32 MFinished { get => _MFinished; set { if (OnPropertyChanging("MFinished", value)) { _MFinished = value; OnPropertyChanged("MFinished"); } } }

        private String _MDataDesc;
        /// <summary>参数描述</summary>
        [DisplayName("参数描述")]
        [Description("参数描述")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("m_data_desc", "参数描述", "varchar(255)")]
        public String MDataDesc { get => _MDataDesc; set { if (OnPropertyChanging("MDataDesc", value)) { _MDataDesc = value; OnPropertyChanged("MDataDesc"); } } }

        private String _MData1;
        /// <summary>需要存储的参数1</summary>
        [DisplayName("需要存储的参数1")]
        [Description("需要存储的参数1")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("m_data1", "需要存储的参数1", "varchar(255)")]
        public String MData1 { get => _MData1; set { if (OnPropertyChanging("MData1", value)) { _MData1 = value; OnPropertyChanged("MData1"); } } }

        private String _MData2;
        /// <summary>需要存储的参数2</summary>
        [DisplayName("需要存储的参数2")]
        [Description("需要存储的参数2")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("m_data2", "需要存储的参数2", "varchar(255)")]
        public String MData2 { get => _MData2; set { if (OnPropertyChanging("MData2", value)) { _MData2 = value; OnPropertyChanged("MData2"); } } }

        private String _MData3;
        /// <summary>需要存储的参数3</summary>
        [DisplayName("需要存储的参数3")]
        [Description("需要存储的参数3")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("m_data3", "需要存储的参数3", "varchar(255)")]
        public String MData3 { get => _MData3; set { if (OnPropertyChanging("MData3", value)) { _MData3 = value; OnPropertyChanged("MData3"); } } }

        private String _MData4;
        /// <summary>需要存储的参数4</summary>
        [DisplayName("需要存储的参数4")]
        [Description("需要存储的参数4")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("m_data4", "需要存储的参数4", "varchar(255)")]
        public String MData4 { get => _MData4; set { if (OnPropertyChanging("MData4", value)) { _MData4 = value; OnPropertyChanged("MData4"); } } }

        private String _MData5;
        /// <summary>需要存储的参数5</summary>
        [DisplayName("需要存储的参数5")]
        [Description("需要存储的参数5")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("m_data5", "需要存储的参数5", "varchar(255)")]
        public String MData5 { get => _MData5; set { if (OnPropertyChanging("MData5", value)) { _MData5 = value; OnPropertyChanged("MData5"); } } }

        private String _MData6;
        /// <summary>需要存储的参数6</summary>
        [DisplayName("需要存储的参数6")]
        [Description("需要存储的参数6")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("m_data6", "需要存储的参数6", "varchar(255)")]
        public String MData6 { get => _MData6; set { if (OnPropertyChanging("MData6", value)) { _MData6 = value; OnPropertyChanged("MData6"); } } }
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
                    case "MTypeAux": return _MTypeAux;
                    case "MGroup": return _MGroup;
                    case "MCreateMember": return _MCreateMember;
                    case "MCreateTime": return _MCreateTime;
                    case "MFinishTime": return _MFinishTime;
                    case "MFinished": return _MFinished;
                    case "MDataDesc": return _MDataDesc;
                    case "MData1": return _MData1;
                    case "MData2": return _MData2;
                    case "MData3": return _MData3;
                    case "MData4": return _MData4;
                    case "MData5": return _MData5;
                    case "MData6": return _MData6;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "MIdx": _MIdx = value.ToInt(); break;
                    case "MId": _MId = Convert.ToString(value); break;
                    case "MType": _MType = value.ToInt(); break;
                    case "MTypeAux": _MTypeAux = value.ToInt(); break;
                    case "MGroup": _MGroup = Convert.ToString(value); break;
                    case "MCreateMember": _MCreateMember = Convert.ToString(value); break;
                    case "MCreateTime": _MCreateTime = Convert.ToString(value); break;
                    case "MFinishTime": _MFinishTime = Convert.ToString(value); break;
                    case "MFinished": _MFinished = value.ToInt(); break;
                    case "MDataDesc": _MDataDesc = Convert.ToString(value); break;
                    case "MData1": _MData1 = Convert.ToString(value); break;
                    case "MData2": _MData2 = Convert.ToString(value); break;
                    case "MData3": _MData3 = Convert.ToString(value); break;
                    case "MData4": _MData4 = Convert.ToString(value); break;
                    case "MData5": _MData5 = Convert.ToString(value); break;
                    case "MData6": _MData6 = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得MemMission字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>自增idx</summary>
            public static readonly Field MIdx = FindByName("MIdx");

            /// <summary>随机32位任务码 (将分配给创建者)</summary>
            public static readonly Field MId = FindByName("MId");

            /// <summary>任务类型：0为识图，1为</summary>
            public static readonly Field MType = FindByName("MType");

            /// <summary>辅助类型，补充说明</summary>
            public static readonly Field MTypeAux = FindByName("MTypeAux");

            /// <summary>发起的群号</summary>
            public static readonly Field MGroup = FindByName("MGroup");

            /// <summary>创建者QQ号</summary>
            public static readonly Field MCreateMember = FindByName("MCreateMember");

            /// <summary>创建时间</summary>
            public static readonly Field MCreateTime = FindByName("MCreateTime");

            /// <summary>结束时间</summary>
            public static readonly Field MFinishTime = FindByName("MFinishTime");

            /// <summary>完成状态（1为完成，0为未完成）</summary>
            public static readonly Field MFinished = FindByName("MFinished");

            /// <summary>参数描述</summary>
            public static readonly Field MDataDesc = FindByName("MDataDesc");

            /// <summary>需要存储的参数1</summary>
            public static readonly Field MData1 = FindByName("MData1");

            /// <summary>需要存储的参数2</summary>
            public static readonly Field MData2 = FindByName("MData2");

            /// <summary>需要存储的参数3</summary>
            public static readonly Field MData3 = FindByName("MData3");

            /// <summary>需要存储的参数4</summary>
            public static readonly Field MData4 = FindByName("MData4");

            /// <summary>需要存储的参数5</summary>
            public static readonly Field MData5 = FindByName("MData5");

            /// <summary>需要存储的参数6</summary>
            public static readonly Field MData6 = FindByName("MData6");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得MemMission字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>自增idx</summary>
            public const String MIdx = "MIdx";

            /// <summary>随机32位任务码 (将分配给创建者)</summary>
            public const String MId = "MId";

            /// <summary>任务类型：0为识图，1为</summary>
            public const String MType = "MType";

            /// <summary>辅助类型，补充说明</summary>
            public const String MTypeAux = "MTypeAux";

            /// <summary>发起的群号</summary>
            public const String MGroup = "MGroup";

            /// <summary>创建者QQ号</summary>
            public const String MCreateMember = "MCreateMember";

            /// <summary>创建时间</summary>
            public const String MCreateTime = "MCreateTime";

            /// <summary>结束时间</summary>
            public const String MFinishTime = "MFinishTime";

            /// <summary>完成状态（1为完成，0为未完成）</summary>
            public const String MFinished = "MFinished";

            /// <summary>参数描述</summary>
            public const String MDataDesc = "MDataDesc";

            /// <summary>需要存储的参数1</summary>
            public const String MData1 = "MData1";

            /// <summary>需要存储的参数2</summary>
            public const String MData2 = "MData2";

            /// <summary>需要存储的参数3</summary>
            public const String MData3 = "MData3";

            /// <summary>需要存储的参数4</summary>
            public const String MData4 = "MData4";

            /// <summary>需要存储的参数5</summary>
            public const String MData5 = "MData5";

            /// <summary>需要存储的参数6</summary>
            public const String MData6 = "MData6";
        }
        #endregion
    }
}