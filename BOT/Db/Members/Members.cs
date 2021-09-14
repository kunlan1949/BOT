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
    [BindTable("members", Description = "", ConnName = "BotDb", DbType = DatabaseType.None)]
    public partial class Members
    {
        #region 属性
        private Int32 _MemIdx;
        /// <summary>自增，idx</summary>
        [DisplayName("自增")]
        [Description("自增，idx")]
        [DataObjectField(true, true, false, 255)]
        [BindColumn("mem_idx", "自增，idx", "int(255)")]
        public Int32 MemIdx { get => _MemIdx; set { if (OnPropertyChanging("MemIdx", value)) { _MemIdx = value; OnPropertyChanged("MemIdx"); } } }

        private String _MemGroup;
        /// <summary>成员所属群组号</summary>
        [DisplayName("成员所属群组号")]
        [Description("成员所属群组号")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("mem_group", "成员所属群组号", "varchar(255)")]
        public String MemGroup { get => _MemGroup; set { if (OnPropertyChanging("MemGroup", value)) { _MemGroup = value; OnPropertyChanged("MemGroup"); } } }

        private Int32 _MemExist;
        /// <summary>是否已经注销 0为否，1为是（数据不删除，可恢复性）</summary>
        [DisplayName("是否已经注销0为否")]
        [Description("是否已经注销 0为否，1为是（数据不删除，可恢复性）")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("mem_exist", "是否已经注销 0为否，1为是（数据不删除，可恢复性）", "int(255)")]
        public Int32 MemExist { get => _MemExist; set { if (OnPropertyChanging("MemExist", value)) { _MemExist = value; OnPropertyChanged("MemExist"); } } }

        private String _MemNicknumber;
        /// <summary>成员群昵称</summary>
        [DisplayName("成员群昵称")]
        [Description("成员群昵称")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("mem_nicknumber", "成员群昵称", "varchar(255)")]
        public String MemNicknumber { get => _MemNicknumber; set { if (OnPropertyChanging("MemNicknumber", value)) { _MemNicknumber = value; OnPropertyChanged("MemNicknumber"); } } }

        private String _MemQq;
        /// <summary>成员QQ号</summary>
        [DisplayName("成员QQ号")]
        [Description("成员QQ号")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("mem_QQ", "成员QQ号", "varchar(255)")]
        public String MemQq { get => _MemQq; set { if (OnPropertyChanging("MemQq", value)) { _MemQq = value; OnPropertyChanged("MemQq"); } } }

        private Int32 _MemLimit;
        /// <summary>成员权限</summary>
        [DisplayName("成员权限")]
        [Description("成员权限")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("mem_limit", "成员权限", "int(255)")]
        public Int32 MemLimit { get => _MemLimit; set { if (OnPropertyChanging("MemLimit", value)) { _MemLimit = value; OnPropertyChanged("MemLimit"); } } }

        private Int32 _SimageLimit;
        /// <summary>每日识图次数</summary>
        [DisplayName("每日识图次数")]
        [Description("每日识图次数")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("sImage_limit", "每日识图次数", "int(255)")]
        public Int32 SimageLimit { get => _SimageLimit; set { if (OnPropertyChanging("SimageLimit", value)) { _SimageLimit = value; OnPropertyChanged("SimageLimit"); } } }

        private String _ImgTime;
        /// <summary>识图的时间</summary>
        [DisplayName("识图的时间")]
        [Description("识图的时间")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("img_time", "识图的时间", "varchar(255)")]
        public String ImgTime { get => _ImgTime; set { if (OnPropertyChanging("ImgTime", value)) { _ImgTime = value; OnPropertyChanged("ImgTime"); } } }

        private String _MissionId;
        /// <summary>任务id</summary>
        [DisplayName("任务id")]
        [Description("任务id")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("mission_id", "任务id", "varchar(255)")]
        public String MissionId { get => _MissionId; set { if (OnPropertyChanging("MissionId", value)) { _MissionId = value; OnPropertyChanged("MissionId"); } } }

        private Int32 _MemPoint;
        /// <summary>成员积分</summary>
        [DisplayName("成员积分")]
        [Description("成员积分")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("mem_point", "成员积分", "int(255)")]
        public Int32 MemPoint { get => _MemPoint; set { if (OnPropertyChanging("MemPoint", value)) { _MemPoint = value; OnPropertyChanged("MemPoint"); } } }

        private String _MemLottery;
        /// <summary>参加大乐透的号码</summary>
        [DisplayName("参加大乐透的号码")]
        [Description("参加大乐透的号码")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("mem_lottery", "参加大乐透的号码", "varchar(255)")]
        public String MemLottery { get => _MemLottery; set { if (OnPropertyChanging("MemLottery", value)) { _MemLottery = value; OnPropertyChanged("MemLottery"); } } }

        private String _MemLotteryId;
        /// <summary>参加大乐透给予的id</summary>
        [DisplayName("参加大乐透给予的id")]
        [Description("参加大乐透给予的id")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("mem_lottery_id", "参加大乐透给予的id", "varchar(255)")]
        public String MemLotteryId { get => _MemLotteryId; set { if (OnPropertyChanging("MemLotteryId", value)) { _MemLotteryId = value; OnPropertyChanged("MemLotteryId"); } } }

        private Int32 _MemWarnC;
        /// <summary>警告次数</summary>
        [DisplayName("警告次数")]
        [Description("警告次数")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("mem_warn_c", "警告次数", "int(255)")]
        public Int32 MemWarnC { get => _MemWarnC; set { if (OnPropertyChanging("MemWarnC", value)) { _MemWarnC = value; OnPropertyChanged("MemWarnC"); } } }
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
                    case "MemIdx": return _MemIdx;
                    case "MemGroup": return _MemGroup;
                    case "MemExist": return _MemExist;
                    case "MemNicknumber": return _MemNicknumber;
                    case "MemQq": return _MemQq;
                    case "MemLimit": return _MemLimit;
                    case "SimageLimit": return _SimageLimit;
                    case "ImgTime": return _ImgTime;
                    case "MissionId": return _MissionId;
                    case "MemPoint": return _MemPoint;
                    case "MemLottery": return _MemLottery;
                    case "MemLotteryId": return _MemLotteryId;
                    case "MemWarnC": return _MemWarnC;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "MemIdx": _MemIdx = value.ToInt(); break;
                    case "MemGroup": _MemGroup = Convert.ToString(value); break;
                    case "MemExist": _MemExist = value.ToInt(); break;
                    case "MemNicknumber": _MemNicknumber = Convert.ToString(value); break;
                    case "MemQq": _MemQq = Convert.ToString(value); break;
                    case "MemLimit": _MemLimit = value.ToInt(); break;
                    case "SimageLimit": _SimageLimit = value.ToInt(); break;
                    case "ImgTime": _ImgTime = Convert.ToString(value); break;
                    case "MissionId": _MissionId = Convert.ToString(value); break;
                    case "MemPoint": _MemPoint = value.ToInt(); break;
                    case "MemLottery": _MemLottery = Convert.ToString(value); break;
                    case "MemLotteryId": _MemLotteryId = Convert.ToString(value); break;
                    case "MemWarnC": _MemWarnC = value.ToInt(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得Members字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>自增，idx</summary>
            public static readonly Field MemIdx = FindByName("MemIdx");

            /// <summary>成员所属群组号</summary>
            public static readonly Field MemGroup = FindByName("MemGroup");

            /// <summary>是否已经注销 0为否，1为是（数据不删除，可恢复性）</summary>
            public static readonly Field MemExist = FindByName("MemExist");

            /// <summary>成员群昵称</summary>
            public static readonly Field MemNicknumber = FindByName("MemNicknumber");

            /// <summary>成员QQ号</summary>
            public static readonly Field MemQq = FindByName("MemQq");

            /// <summary>成员权限</summary>
            public static readonly Field MemLimit = FindByName("MemLimit");

            /// <summary>每日识图次数</summary>
            public static readonly Field SimageLimit = FindByName("SimageLimit");

            /// <summary>识图的时间</summary>
            public static readonly Field ImgTime = FindByName("ImgTime");

            /// <summary>任务id</summary>
            public static readonly Field MissionId = FindByName("MissionId");

            /// <summary>成员积分</summary>
            public static readonly Field MemPoint = FindByName("MemPoint");

            /// <summary>参加大乐透的号码</summary>
            public static readonly Field MemLottery = FindByName("MemLottery");

            /// <summary>参加大乐透给予的id</summary>
            public static readonly Field MemLotteryId = FindByName("MemLotteryId");

            /// <summary>警告次数</summary>
            public static readonly Field MemWarnC = FindByName("MemWarnC");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得Members字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>自增，idx</summary>
            public const String MemIdx = "MemIdx";

            /// <summary>成员所属群组号</summary>
            public const String MemGroup = "MemGroup";

            /// <summary>是否已经注销 0为否，1为是（数据不删除，可恢复性）</summary>
            public const String MemExist = "MemExist";

            /// <summary>成员群昵称</summary>
            public const String MemNicknumber = "MemNicknumber";

            /// <summary>成员QQ号</summary>
            public const String MemQq = "MemQq";

            /// <summary>成员权限</summary>
            public const String MemLimit = "MemLimit";

            /// <summary>每日识图次数</summary>
            public const String SimageLimit = "SimageLimit";

            /// <summary>识图的时间</summary>
            public const String ImgTime = "ImgTime";

            /// <summary>任务id</summary>
            public const String MissionId = "MissionId";

            /// <summary>成员积分</summary>
            public const String MemPoint = "MemPoint";

            /// <summary>参加大乐透的号码</summary>
            public const String MemLottery = "MemLottery";

            /// <summary>参加大乐透给予的id</summary>
            public const String MemLotteryId = "MemLotteryId";

            /// <summary>警告次数</summary>
            public const String MemWarnC = "MemWarnC";
        }
        #endregion
    }
}