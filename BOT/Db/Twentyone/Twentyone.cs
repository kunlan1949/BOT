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
    [BindIndex("PRIMARY", true, "to_idex")]
    [BindTable("twentyone", Description = "", ConnName = "BotDb", DbType = DatabaseType.None)]
    public partial class Twentyone
    {
        #region 属性
        private Int32 _ToIdex;
        /// <summary>idx，自增</summary>
        [DisplayName("idx")]
        [Description("idx，自增")]
        [DataObjectField(true, false, false, 255)]
        [BindColumn("to_idex", "idx，自增", "int(255)")]
        public Int32 ToIdex { get => _ToIdex; set { if (OnPropertyChanging("ToIdex", value)) { _ToIdex = value; OnPropertyChanged("ToIdex"); } } }

        private String _ToId;
        /// <summary>每一局的唯一ID</summary>
        [DisplayName("每一局的唯一ID")]
        [Description("每一局的唯一ID")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("to_id", "每一局的唯一ID", "varchar(255)")]
        public String ToId { get => _ToId; set { if (OnPropertyChanging("ToId", value)) { _ToId = value; OnPropertyChanged("ToId"); } } }

        private String _ToGroup;
        /// <summary>来自哪一组</summary>
        [DisplayName("来自哪一组")]
        [Description("来自哪一组")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("to_group", "来自哪一组", "varchar(255)")]
        public String ToGroup { get => _ToGroup; set { if (OnPropertyChanging("ToGroup", value)) { _ToGroup = value; OnPropertyChanged("ToGroup"); } } }

        private String _ToFinish;
        /// <summary>是否结束</summary>
        [DisplayName("是否结束")]
        [Description("是否结束")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("to_finish", "是否结束", "varchar(255)")]
        public String ToFinish { get => _ToFinish; set { if (OnPropertyChanging("ToFinish", value)) { _ToFinish = value; OnPropertyChanged("ToFinish"); } } }

        private String _ToBanker;
        /// <summary>庄家</summary>
        [DisplayName("庄家")]
        [Description("庄家")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("to_banker", "庄家", "varchar(255)")]
        public String ToBanker { get => _ToBanker; set { if (OnPropertyChanging("ToBanker", value)) { _ToBanker = value; OnPropertyChanged("ToBanker"); } } }

        private String _ToP1;
        /// <summary>P1玩家QQ</summary>
        [DisplayName("P1玩家QQ")]
        [Description("P1玩家QQ")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("to_p1", "P1玩家QQ", "varchar(255)")]
        public String ToP1 { get => _ToP1; set { if (OnPropertyChanging("ToP1", value)) { _ToP1 = value; OnPropertyChanged("ToP1"); } } }

        private String _ToP2;
        /// <summary>P2玩家QQ</summary>
        [DisplayName("P2玩家QQ")]
        [Description("P2玩家QQ")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("to_p2", "P2玩家QQ", "varchar(255)")]
        public String ToP2 { get => _ToP2; set { if (OnPropertyChanging("ToP2", value)) { _ToP2 = value; OnPropertyChanged("ToP2"); } } }

        private String _ToP3;
        /// <summary>P3玩家QQ</summary>
        [DisplayName("P3玩家QQ")]
        [Description("P3玩家QQ")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("to_p3", "P3玩家QQ", "varchar(255)")]
        public String ToP3 { get => _ToP3; set { if (OnPropertyChanging("ToP3", value)) { _ToP3 = value; OnPropertyChanged("ToP3"); } } }

        private String _ToP4;
        /// <summary>P4玩家QQ</summary>
        [DisplayName("P4玩家QQ")]
        [Description("P4玩家QQ")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("to_p4", "P4玩家QQ", "varchar(255)")]
        public String ToP4 { get => _ToP4; set { if (OnPropertyChanging("ToP4", value)) { _ToP4 = value; OnPropertyChanged("ToP4"); } } }

        private String _BankerInitCard;
        /// <summary>庄家初始牌</summary>
        [DisplayName("庄家初始牌")]
        [Description("庄家初始牌")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("banker_init_card", "庄家初始牌", "varchar(255)")]
        public String BankerInitCard { get => _BankerInitCard; set { if (OnPropertyChanging("BankerInitCard", value)) { _BankerInitCard = value; OnPropertyChanged("BankerInitCard"); } } }

        private String _P1InitCard;
        /// <summary>P1初始牌</summary>
        [DisplayName("P1初始牌")]
        [Description("P1初始牌")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("p1_init_card", "P1初始牌", "varchar(255)")]
        public String P1InitCard { get => _P1InitCard; set { if (OnPropertyChanging("P1InitCard", value)) { _P1InitCard = value; OnPropertyChanged("P1InitCard"); } } }

        private String _P2InitCard;
        /// <summary>P2初始牌</summary>
        [DisplayName("P2初始牌")]
        [Description("P2初始牌")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("p2_init_card", "P2初始牌", "varchar(255)")]
        public String P2InitCard { get => _P2InitCard; set { if (OnPropertyChanging("P2InitCard", value)) { _P2InitCard = value; OnPropertyChanged("P2InitCard"); } } }

        private String _P3InitCard;
        /// <summary>P3初始牌</summary>
        [DisplayName("P3初始牌")]
        [Description("P3初始牌")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("p3_init_card", "P3初始牌", "varchar(255)")]
        public String P3InitCard { get => _P3InitCard; set { if (OnPropertyChanging("P3InitCard", value)) { _P3InitCard = value; OnPropertyChanged("P3InitCard"); } } }

        private String _P4InitCard;
        /// <summary>P4初始牌</summary>
        [DisplayName("P4初始牌")]
        [Description("P4初始牌")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("p4_init_card", "P4初始牌", "varchar(255)")]
        public String P4InitCard { get => _P4InitCard; set { if (OnPropertyChanging("P4InitCard", value)) { _P4InitCard = value; OnPropertyChanged("P4InitCard"); } } }

        private String _BankerCard;
        /// <summary>庄家当前牌</summary>
        [DisplayName("庄家当前牌")]
        [Description("庄家当前牌")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("banker_card", "庄家当前牌", "varchar(255)")]
        public String BankerCard { get => _BankerCard; set { if (OnPropertyChanging("BankerCard", value)) { _BankerCard = value; OnPropertyChanged("BankerCard"); } } }

        private String _P1Card;
        /// <summary>P1当前牌</summary>
        [DisplayName("P1当前牌")]
        [Description("P1当前牌")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("p1_card", "P1当前牌", "varchar(255)")]
        public String P1Card { get => _P1Card; set { if (OnPropertyChanging("P1Card", value)) { _P1Card = value; OnPropertyChanged("P1Card"); } } }

        private String _P2Card;
        /// <summary>P2当前牌</summary>
        [DisplayName("P2当前牌")]
        [Description("P2当前牌")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("p2_card", "P2当前牌", "varchar(255)")]
        public String P2Card { get => _P2Card; set { if (OnPropertyChanging("P2Card", value)) { _P2Card = value; OnPropertyChanged("P2Card"); } } }

        private String _P3Card;
        /// <summary>P3当前牌</summary>
        [DisplayName("P3当前牌")]
        [Description("P3当前牌")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("p3_card", "P3当前牌", "varchar(255)")]
        public String P3Card { get => _P3Card; set { if (OnPropertyChanging("P3Card", value)) { _P3Card = value; OnPropertyChanged("P3Card"); } } }

        private String _P4Card;
        /// <summary>P4当前牌</summary>
        [DisplayName("P4当前牌")]
        [Description("P4当前牌")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("p4_card", "P4当前牌", "varchar(255)")]
        public String P4Card { get => _P4Card; set { if (OnPropertyChanging("P4Card", value)) { _P4Card = value; OnPropertyChanged("P4Card"); } } }

        private String _P1Num;
        /// <summary>P1当前牌点数总大小</summary>
        [DisplayName("P1当前牌点数总大小")]
        [Description("P1当前牌点数总大小")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("p1_num", "P1当前牌点数总大小", "varchar(255)")]
        public String P1Num { get => _P1Num; set { if (OnPropertyChanging("P1Num", value)) { _P1Num = value; OnPropertyChanged("P1Num"); } } }

        private String _P2Num;
        /// <summary>P2当前牌点数总大小</summary>
        [DisplayName("P2当前牌点数总大小")]
        [Description("P2当前牌点数总大小")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("p2_num", "P2当前牌点数总大小", "varchar(255)")]
        public String P2Num { get => _P2Num; set { if (OnPropertyChanging("P2Num", value)) { _P2Num = value; OnPropertyChanged("P2Num"); } } }

        private String _P3Num;
        /// <summary>P3当前牌点数总大小</summary>
        [DisplayName("P3当前牌点数总大小")]
        [Description("P3当前牌点数总大小")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("p3_num", "P3当前牌点数总大小", "varchar(255)")]
        public String P3Num { get => _P3Num; set { if (OnPropertyChanging("P3Num", value)) { _P3Num = value; OnPropertyChanged("P3Num"); } } }

        private String _P4Num;
        /// <summary>P4当前牌点数总大小</summary>
        [DisplayName("P4当前牌点数总大小")]
        [Description("P4当前牌点数总大小")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("p4_num", "P4当前牌点数总大小", "varchar(255)")]
        public String P4Num { get => _P4Num; set { if (OnPropertyChanging("P4Num", value)) { _P4Num = value; OnPropertyChanged("P4Num"); } } }
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
                    case "ToIdex": return _ToIdex;
                    case "ToId": return _ToId;
                    case "ToGroup": return _ToGroup;
                    case "ToFinish": return _ToFinish;
                    case "ToBanker": return _ToBanker;
                    case "ToP1": return _ToP1;
                    case "ToP2": return _ToP2;
                    case "ToP3": return _ToP3;
                    case "ToP4": return _ToP4;
                    case "BankerInitCard": return _BankerInitCard;
                    case "P1InitCard": return _P1InitCard;
                    case "P2InitCard": return _P2InitCard;
                    case "P3InitCard": return _P3InitCard;
                    case "P4InitCard": return _P4InitCard;
                    case "BankerCard": return _BankerCard;
                    case "P1Card": return _P1Card;
                    case "P2Card": return _P2Card;
                    case "P3Card": return _P3Card;
                    case "P4Card": return _P4Card;
                    case "P1Num": return _P1Num;
                    case "P2Num": return _P2Num;
                    case "P3Num": return _P3Num;
                    case "P4Num": return _P4Num;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "ToIdex": _ToIdex = value.ToInt(); break;
                    case "ToId": _ToId = Convert.ToString(value); break;
                    case "ToGroup": _ToGroup = Convert.ToString(value); break;
                    case "ToFinish": _ToFinish = Convert.ToString(value); break;
                    case "ToBanker": _ToBanker = Convert.ToString(value); break;
                    case "ToP1": _ToP1 = Convert.ToString(value); break;
                    case "ToP2": _ToP2 = Convert.ToString(value); break;
                    case "ToP3": _ToP3 = Convert.ToString(value); break;
                    case "ToP4": _ToP4 = Convert.ToString(value); break;
                    case "BankerInitCard": _BankerInitCard = Convert.ToString(value); break;
                    case "P1InitCard": _P1InitCard = Convert.ToString(value); break;
                    case "P2InitCard": _P2InitCard = Convert.ToString(value); break;
                    case "P3InitCard": _P3InitCard = Convert.ToString(value); break;
                    case "P4InitCard": _P4InitCard = Convert.ToString(value); break;
                    case "BankerCard": _BankerCard = Convert.ToString(value); break;
                    case "P1Card": _P1Card = Convert.ToString(value); break;
                    case "P2Card": _P2Card = Convert.ToString(value); break;
                    case "P3Card": _P3Card = Convert.ToString(value); break;
                    case "P4Card": _P4Card = Convert.ToString(value); break;
                    case "P1Num": _P1Num = Convert.ToString(value); break;
                    case "P2Num": _P2Num = Convert.ToString(value); break;
                    case "P3Num": _P3Num = Convert.ToString(value); break;
                    case "P4Num": _P4Num = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得Twentyone字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>idx，自增</summary>
            public static readonly Field ToIdex = FindByName("ToIdex");

            /// <summary>每一局的唯一ID</summary>
            public static readonly Field ToId = FindByName("ToId");

            /// <summary>来自哪一组</summary>
            public static readonly Field ToGroup = FindByName("ToGroup");

            /// <summary>是否结束</summary>
            public static readonly Field ToFinish = FindByName("ToFinish");

            /// <summary>庄家</summary>
            public static readonly Field ToBanker = FindByName("ToBanker");

            /// <summary>P1玩家QQ</summary>
            public static readonly Field ToP1 = FindByName("ToP1");

            /// <summary>P2玩家QQ</summary>
            public static readonly Field ToP2 = FindByName("ToP2");

            /// <summary>P3玩家QQ</summary>
            public static readonly Field ToP3 = FindByName("ToP3");

            /// <summary>P4玩家QQ</summary>
            public static readonly Field ToP4 = FindByName("ToP4");

            /// <summary>庄家初始牌</summary>
            public static readonly Field BankerInitCard = FindByName("BankerInitCard");

            /// <summary>P1初始牌</summary>
            public static readonly Field P1InitCard = FindByName("P1InitCard");

            /// <summary>P2初始牌</summary>
            public static readonly Field P2InitCard = FindByName("P2InitCard");

            /// <summary>P3初始牌</summary>
            public static readonly Field P3InitCard = FindByName("P3InitCard");

            /// <summary>P4初始牌</summary>
            public static readonly Field P4InitCard = FindByName("P4InitCard");

            /// <summary>庄家当前牌</summary>
            public static readonly Field BankerCard = FindByName("BankerCard");

            /// <summary>P1当前牌</summary>
            public static readonly Field P1Card = FindByName("P1Card");

            /// <summary>P2当前牌</summary>
            public static readonly Field P2Card = FindByName("P2Card");

            /// <summary>P3当前牌</summary>
            public static readonly Field P3Card = FindByName("P3Card");

            /// <summary>P4当前牌</summary>
            public static readonly Field P4Card = FindByName("P4Card");

            /// <summary>P1当前牌点数总大小</summary>
            public static readonly Field P1Num = FindByName("P1Num");

            /// <summary>P2当前牌点数总大小</summary>
            public static readonly Field P2Num = FindByName("P2Num");

            /// <summary>P3当前牌点数总大小</summary>
            public static readonly Field P3Num = FindByName("P3Num");

            /// <summary>P4当前牌点数总大小</summary>
            public static readonly Field P4Num = FindByName("P4Num");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得Twentyone字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>idx，自增</summary>
            public const String ToIdex = "ToIdex";

            /// <summary>每一局的唯一ID</summary>
            public const String ToId = "ToId";

            /// <summary>来自哪一组</summary>
            public const String ToGroup = "ToGroup";

            /// <summary>是否结束</summary>
            public const String ToFinish = "ToFinish";

            /// <summary>庄家</summary>
            public const String ToBanker = "ToBanker";

            /// <summary>P1玩家QQ</summary>
            public const String ToP1 = "ToP1";

            /// <summary>P2玩家QQ</summary>
            public const String ToP2 = "ToP2";

            /// <summary>P3玩家QQ</summary>
            public const String ToP3 = "ToP3";

            /// <summary>P4玩家QQ</summary>
            public const String ToP4 = "ToP4";

            /// <summary>庄家初始牌</summary>
            public const String BankerInitCard = "BankerInitCard";

            /// <summary>P1初始牌</summary>
            public const String P1InitCard = "P1InitCard";

            /// <summary>P2初始牌</summary>
            public const String P2InitCard = "P2InitCard";

            /// <summary>P3初始牌</summary>
            public const String P3InitCard = "P3InitCard";

            /// <summary>P4初始牌</summary>
            public const String P4InitCard = "P4InitCard";

            /// <summary>庄家当前牌</summary>
            public const String BankerCard = "BankerCard";

            /// <summary>P1当前牌</summary>
            public const String P1Card = "P1Card";

            /// <summary>P2当前牌</summary>
            public const String P2Card = "P2Card";

            /// <summary>P3当前牌</summary>
            public const String P3Card = "P3Card";

            /// <summary>P4当前牌</summary>
            public const String P4Card = "P4Card";

            /// <summary>P1当前牌点数总大小</summary>
            public const String P1Num = "P1Num";

            /// <summary>P2当前牌点数总大小</summary>
            public const String P2Num = "P2Num";

            /// <summary>P3当前牌点数总大小</summary>
            public const String P3Num = "P3Num";

            /// <summary>P4当前牌点数总大小</summary>
            public const String P4Num = "P4Num";
        }
        #endregion
    }
}