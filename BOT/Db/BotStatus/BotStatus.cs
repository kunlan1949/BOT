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
    [BindTable("bot_status", Description = "", ConnName = "BotDb", DbType = DatabaseType.None)]
    public partial class BotStatus
    {
        #region 属性
        private String _BotName;
        /// <summary>bot的唤起名</summary>
        [DisplayName("bot的唤起名")]
        [Description("bot的唤起名")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("bot_name", "bot的唤起名", "varchar(255)")]
        public String BotName { get => _BotName; set { if (OnPropertyChanging("BotName", value)) { _BotName = value; OnPropertyChanged("BotName"); } } }

        private String _BotGroup;
        /// <summary>bot所加入的群号</summary>
        [DisplayName("bot所加入的群号")]
        [Description("bot所加入的群号")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("bot_group", "bot所加入的群号", "varchar(255)")]
        public String BotGroup { get => _BotGroup; set { if (OnPropertyChanging("BotGroup", value)) { _BotGroup = value; OnPropertyChanged("BotGroup"); } } }

        private String _BotInTime;
        /// <summary>bot加入群的时间</summary>
        [DisplayName("bot加入群的时间")]
        [Description("bot加入群的时间")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("bot_in_time", "bot加入群的时间", "varchar(255)")]
        public String BotInTime { get => _BotInTime; set { if (OnPropertyChanging("BotInTime", value)) { _BotInTime = value; OnPropertyChanged("BotInTime"); } } }

        private String _BotIdDoc;
        /// <summary>bot的群内权限（0为群主，1为管理员，2为群众）</summary>
        [DisplayName("bot的群内权限")]
        [Description("bot的群内权限（0为群主，1为管理员，2为群众）")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("bot_id_doc", "bot的群内权限（0为群主，1为管理员，2为群众）", "varchar(255)")]
        public String BotIdDoc { get => _BotIdDoc; set { if (OnPropertyChanging("BotIdDoc", value)) { _BotIdDoc = value; OnPropertyChanged("BotIdDoc"); } } }

        private Int32 _BotOnoff;
        /// <summary>bot是否交互</summary>
        [DisplayName("bot是否交互")]
        [Description("bot是否交互")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("bot_onoff", "bot是否交互", "int(255)")]
        public Int32 BotOnoff { get => _BotOnoff; set { if (OnPropertyChanging("BotOnoff", value)) { _BotOnoff = value; OnPropertyChanged("BotOnoff"); } } }

        private String _GenshinRoleUp;
        /// <summary>角色Up池名字</summary>
        [DisplayName("角色Up池名字")]
        [Description("角色Up池名字")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("genshin_role_up", "角色Up池名字", "varchar(255)")]
        public String GenshinRoleUp { get => _GenshinRoleUp; set { if (OnPropertyChanging("GenshinRoleUp", value)) { _GenshinRoleUp = value; OnPropertyChanged("GenshinRoleUp"); } } }
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
                    case "BotName": return _BotName;
                    case "BotGroup": return _BotGroup;
                    case "BotInTime": return _BotInTime;
                    case "BotIdDoc": return _BotIdDoc;
                    case "BotOnoff": return _BotOnoff;
                    case "GenshinRoleUp": return _GenshinRoleUp;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "BotName": _BotName = Convert.ToString(value); break;
                    case "BotGroup": _BotGroup = Convert.ToString(value); break;
                    case "BotInTime": _BotInTime = Convert.ToString(value); break;
                    case "BotIdDoc": _BotIdDoc = Convert.ToString(value); break;
                    case "BotOnoff": _BotOnoff = value.ToInt(); break;
                    case "GenshinRoleUp": _GenshinRoleUp = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得BotStatus字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>bot的唤起名</summary>
            public static readonly Field BotName = FindByName("BotName");

            /// <summary>bot所加入的群号</summary>
            public static readonly Field BotGroup = FindByName("BotGroup");

            /// <summary>bot加入群的时间</summary>
            public static readonly Field BotInTime = FindByName("BotInTime");

            /// <summary>bot的群内权限（0为群主，1为管理员，2为群众）</summary>
            public static readonly Field BotIdDoc = FindByName("BotIdDoc");

            /// <summary>bot是否交互</summary>
            public static readonly Field BotOnoff = FindByName("BotOnoff");

            /// <summary>角色Up池名字</summary>
            public static readonly Field GenshinRoleUp = FindByName("GenshinRoleUp");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得BotStatus字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>bot的唤起名</summary>
            public const String BotName = "BotName";

            /// <summary>bot所加入的群号</summary>
            public const String BotGroup = "BotGroup";

            /// <summary>bot加入群的时间</summary>
            public const String BotInTime = "BotInTime";

            /// <summary>bot的群内权限（0为群主，1为管理员，2为群众）</summary>
            public const String BotIdDoc = "BotIdDoc";

            /// <summary>bot是否交互</summary>
            public const String BotOnoff = "BotOnoff";

            /// <summary>角色Up池名字</summary>
            public const String GenshinRoleUp = "GenshinRoleUp";
        }
        #endregion
    }
}