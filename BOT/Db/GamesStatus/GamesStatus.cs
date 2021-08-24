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
    [BindTable("games_status", Description = "", ConnName = "BotDb", DbType = DatabaseType.None)]
    public partial class GamesStatus
    {
        #region 属性
        private Int32 _GameIdx;
        /// <summary>idx，自增</summary>
        [DisplayName("idx")]
        [Description("idx，自增")]
        [DataObjectField(true, true, false, 255)]
        [BindColumn("game_idx", "idx，自增", "int(255)")]
        public Int32 GameIdx { get => _GameIdx; set { if (OnPropertyChanging("GameIdx", value)) { _GameIdx = value; OnPropertyChanged("GameIdx"); } } }

        private String _GameType;
        /// <summary>游戏类型：0为猜数字</summary>
        [DisplayName("游戏类型：0为猜数字")]
        [Description("游戏类型：0为猜数字")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("game_type", "游戏类型：0为猜数字", "varchar(255)")]
        public String GameType { get => _GameType; set { if (OnPropertyChanging("GameType", value)) { _GameType = value; OnPropertyChanged("GameType"); } } }

        private String _GameParams;
        /// <summary>游戏参数</summary>
        [DisplayName("游戏参数")]
        [Description("游戏参数")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("game_params", "游戏参数", "varchar(255)")]
        public String GameParams { get => _GameParams; set { if (OnPropertyChanging("GameParams", value)) { _GameParams = value; OnPropertyChanged("GameParams"); } } }

        private String _GameStatus;
        /// <summary>游戏状态 0为结束，1为开始</summary>
        [DisplayName("游戏状态0为结束")]
        [Description("游戏状态 0为结束，1为开始")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("game_status", "游戏状态 0为结束，1为开始", "varchar(255)")]
        public String GameStatus { get => _GameStatus; set { if (OnPropertyChanging("GameStatus", value)) { _GameStatus = value; OnPropertyChanged("GameStatus"); } } }

        private String _GameGroup;
        /// <summary>发起游戏的群号</summary>
        [DisplayName("发起游戏的群号")]
        [Description("发起游戏的群号")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("game_group", "发起游戏的群号", "varchar(255)")]
        public String GameGroup { get => _GameGroup; set { if (OnPropertyChanging("GameGroup", value)) { _GameGroup = value; OnPropertyChanged("GameGroup"); } } }

        private Int32 _GameCount;
        /// <summary>互动剩余次数</summary>
        [DisplayName("互动剩余次数")]
        [Description("互动剩余次数")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("game_count", "互动剩余次数", "int(255)")]
        public Int32 GameCount { get => _GameCount; set { if (OnPropertyChanging("GameCount", value)) { _GameCount = value; OnPropertyChanged("GameCount"); } } }

        private String _GameStarter;
        /// <summary>游戏发起人QQ</summary>
        [DisplayName("游戏发起人QQ")]
        [Description("游戏发起人QQ")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("game_starter", "游戏发起人QQ", "varchar(255)")]
        public String GameStarter { get => _GameStarter; set { if (OnPropertyChanging("GameStarter", value)) { _GameStarter = value; OnPropertyChanged("GameStarter"); } } }
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
                    case "GameIdx": return _GameIdx;
                    case "GameType": return _GameType;
                    case "GameParams": return _GameParams;
                    case "GameStatus": return _GameStatus;
                    case "GameGroup": return _GameGroup;
                    case "GameCount": return _GameCount;
                    case "GameStarter": return _GameStarter;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "GameIdx": _GameIdx = value.ToInt(); break;
                    case "GameType": _GameType = Convert.ToString(value); break;
                    case "GameParams": _GameParams = Convert.ToString(value); break;
                    case "GameStatus": _GameStatus = Convert.ToString(value); break;
                    case "GameGroup": _GameGroup = Convert.ToString(value); break;
                    case "GameCount": _GameCount = value.ToInt(); break;
                    case "GameStarter": _GameStarter = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得GamesStatus字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>idx，自增</summary>
            public static readonly Field GameIdx = FindByName("GameIdx");

            /// <summary>游戏类型：0为猜数字</summary>
            public static readonly Field GameType = FindByName("GameType");

            /// <summary>游戏参数</summary>
            public static readonly Field GameParams = FindByName("GameParams");

            /// <summary>游戏状态 0为结束，1为开始</summary>
            public static readonly Field GameStatus = FindByName("GameStatus");

            /// <summary>发起游戏的群号</summary>
            public static readonly Field GameGroup = FindByName("GameGroup");

            /// <summary>互动剩余次数</summary>
            public static readonly Field GameCount = FindByName("GameCount");

            /// <summary>游戏发起人QQ</summary>
            public static readonly Field GameStarter = FindByName("GameStarter");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得GamesStatus字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>idx，自增</summary>
            public const String GameIdx = "GameIdx";

            /// <summary>游戏类型：0为猜数字</summary>
            public const String GameType = "GameType";

            /// <summary>游戏参数</summary>
            public const String GameParams = "GameParams";

            /// <summary>游戏状态 0为结束，1为开始</summary>
            public const String GameStatus = "GameStatus";

            /// <summary>发起游戏的群号</summary>
            public const String GameGroup = "GameGroup";

            /// <summary>互动剩余次数</summary>
            public const String GameCount = "GameCount";

            /// <summary>游戏发起人QQ</summary>
            public const String GameStarter = "GameStarter";
        }
        #endregion
    }
}