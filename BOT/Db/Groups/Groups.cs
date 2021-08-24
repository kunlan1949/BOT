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
    [BindTable("groups", Description = "", ConnName = "BotDb", DbType = DatabaseType.None)]
    public partial class Groups
    {
        #region 属性
        private Int32 _GrpIdx;
        /// <summary>idx,自增</summary>
        [DisplayName("idx")]
        [Description("idx,自增")]
        [DataObjectField(true, true, false, 11)]
        [BindColumn("grp_idx", "idx,自增", "int(11)")]
        public Int32 GrpIdx { get => _GrpIdx; set { if (OnPropertyChanging("GrpIdx", value)) { _GrpIdx = value; OnPropertyChanged("GrpIdx"); } } }

        private String _GrpId;
        /// <summary>群号</summary>
        [DisplayName("群号")]
        [Description("群号")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("grp_id", "群号", "varchar(255)")]
        public String GrpId { get => _GrpId; set { if (OnPropertyChanging("GrpId", value)) { _GrpId = value; OnPropertyChanged("GrpId"); } } }

        private Int32 _GrpNumber;
        /// <summary>统计的群登记人数</summary>
        [DisplayName("统计的群登记人数")]
        [Description("统计的群登记人数")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("grp_number", "统计的群登记人数", "int(255)")]
        public Int32 GrpNumber { get => _GrpNumber; set { if (OnPropertyChanging("GrpNumber", value)) { _GrpNumber = value; OnPropertyChanged("GrpNumber"); } } }

        private String _GrpStatus;
        /// <summary>是否允许Bot发言</summary>
        [DisplayName("是否允许Bot发言")]
        [Description("是否允许Bot发言")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("grp_status", "是否允许Bot发言", "varchar(255)")]
        public String GrpStatus { get => _GrpStatus; set { if (OnPropertyChanging("GrpStatus", value)) { _GrpStatus = value; OnPropertyChanged("GrpStatus"); } } }

        private Int32 _GrpBotLimit;
        /// <summary>bot群内权限（0群主，1管理员，2成员）</summary>
        [DisplayName("bot群内权限")]
        [Description("bot群内权限（0群主，1管理员，2成员）")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("grp_bot_limit", "bot群内权限（0群主，1管理员，2成员）", "int(255)")]
        public Int32 GrpBotLimit { get => _GrpBotLimit; set { if (OnPropertyChanging("GrpBotLimit", value)) { _GrpBotLimit = value; OnPropertyChanged("GrpBotLimit"); } } }

        private String _GrpGuessnum;
        /// <summary>猜数字游戏（1为开启，0为关闭  -1为未授权）</summary>
        [DisplayName("猜数字游戏")]
        [Description("猜数字游戏（1为开启，0为关闭  -1为未授权）")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("grp_guessnum", "猜数字游戏（1为开启，0为关闭  -1为未授权）", "varchar(255)")]
        public String GrpGuessnum { get => _GrpGuessnum; set { if (OnPropertyChanging("GrpGuessnum", value)) { _GrpGuessnum = value; OnPropertyChanged("GrpGuessnum"); } } }

        private String _GrpChengyu;
        /// <summary>成语接龙（1为开启，0为关闭  -1为未授权）</summary>
        [DisplayName("成语接龙")]
        [Description("成语接龙（1为开启，0为关闭  -1为未授权）")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("grp_chengyu", "成语接龙（1为开启，0为关闭  -1为未授权）", "varchar(255)")]
        public String GrpChengyu { get => _GrpChengyu; set { if (OnPropertyChanging("GrpChengyu", value)) { _GrpChengyu = value; OnPropertyChanged("GrpChengyu"); } } }

        private String _GrpLottery;
        /// <summary>大乐透（1为开启，0为关闭  -1为未授权）</summary>
        [DisplayName("大乐透")]
        [Description("大乐透（1为开启，0为关闭  -1为未授权）")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("grp_lottery", "大乐透（1为开启，0为关闭  -1为未授权）", "varchar(255)")]
        public String GrpLottery { get => _GrpLottery; set { if (OnPropertyChanging("GrpLottery", value)) { _GrpLottery = value; OnPropertyChanged("GrpLottery"); } } }
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
                    case "GrpIdx": return _GrpIdx;
                    case "GrpId": return _GrpId;
                    case "GrpNumber": return _GrpNumber;
                    case "GrpStatus": return _GrpStatus;
                    case "GrpBotLimit": return _GrpBotLimit;
                    case "GrpGuessnum": return _GrpGuessnum;
                    case "GrpChengyu": return _GrpChengyu;
                    case "GrpLottery": return _GrpLottery;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "GrpIdx": _GrpIdx = value.ToInt(); break;
                    case "GrpId": _GrpId = Convert.ToString(value); break;
                    case "GrpNumber": _GrpNumber = value.ToInt(); break;
                    case "GrpStatus": _GrpStatus = Convert.ToString(value); break;
                    case "GrpBotLimit": _GrpBotLimit = value.ToInt(); break;
                    case "GrpGuessnum": _GrpGuessnum = Convert.ToString(value); break;
                    case "GrpChengyu": _GrpChengyu = Convert.ToString(value); break;
                    case "GrpLottery": _GrpLottery = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得Groups字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>idx,自增</summary>
            public static readonly Field GrpIdx = FindByName("GrpIdx");

            /// <summary>群号</summary>
            public static readonly Field GrpId = FindByName("GrpId");

            /// <summary>统计的群登记人数</summary>
            public static readonly Field GrpNumber = FindByName("GrpNumber");

            /// <summary>是否允许Bot发言</summary>
            public static readonly Field GrpStatus = FindByName("GrpStatus");

            /// <summary>bot群内权限（0群主，1管理员，2成员）</summary>
            public static readonly Field GrpBotLimit = FindByName("GrpBotLimit");

            /// <summary>猜数字游戏（1为开启，0为关闭  -1为未授权）</summary>
            public static readonly Field GrpGuessnum = FindByName("GrpGuessnum");

            /// <summary>成语接龙（1为开启，0为关闭  -1为未授权）</summary>
            public static readonly Field GrpChengyu = FindByName("GrpChengyu");

            /// <summary>大乐透（1为开启，0为关闭  -1为未授权）</summary>
            public static readonly Field GrpLottery = FindByName("GrpLottery");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得Groups字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>idx,自增</summary>
            public const String GrpIdx = "GrpIdx";

            /// <summary>群号</summary>
            public const String GrpId = "GrpId";

            /// <summary>统计的群登记人数</summary>
            public const String GrpNumber = "GrpNumber";

            /// <summary>是否允许Bot发言</summary>
            public const String GrpStatus = "GrpStatus";

            /// <summary>bot群内权限（0群主，1管理员，2成员）</summary>
            public const String GrpBotLimit = "GrpBotLimit";

            /// <summary>猜数字游戏（1为开启，0为关闭  -1为未授权）</summary>
            public const String GrpGuessnum = "GrpGuessnum";

            /// <summary>成语接龙（1为开启，0为关闭  -1为未授权）</summary>
            public const String GrpChengyu = "GrpChengyu";

            /// <summary>大乐透（1为开启，0为关闭  -1为未授权）</summary>
            public const String GrpLottery = "GrpLottery";
        }
        #endregion
    }
}