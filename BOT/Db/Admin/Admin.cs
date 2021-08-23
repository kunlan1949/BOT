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
    /// <summary>Admin,管理员表</summary>
    [Serializable]
    [DataObject]
    [Description("Admin,管理员表")]
    [BindTable("t_admin", Description = "Admin,管理员表", ConnName = "BotDb", DbType = DatabaseType.None)]
    public partial class TAdmin
    {
        #region 属性
        private Int32 _AdminIdx;
        /// <summary>管理员idx，自增</summary>
        [DisplayName("管理员idx")]
        [Description("管理员idx，自增")]
        [DataObjectField(true, true, false, 255)]
        [BindColumn("admin_idx", "管理员idx，自增", "int(255)")]
        public Int32 AdminIdx { get => _AdminIdx; set { if (OnPropertyChanging("AdminIdx", value)) { _AdminIdx = value; OnPropertyChanged("AdminIdx"); } } }

        private String _AdminId;
        /// <summary>管理员QQ号</summary>
        [DisplayName("管理员QQ号")]
        [Description("管理员QQ号")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("admin_id", "管理员QQ号", "varchar(255)")]
        public String AdminId { get => _AdminId; set { if (OnPropertyChanging("AdminId", value)) { _AdminId = value; OnPropertyChanged("AdminId"); } } }

        private String _AdminProtect;
        /// <summary>管理员是否收到保护</summary>
        [DisplayName("管理员是否收到保护")]
        [Description("管理员是否收到保护")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("admin_protect", "管理员是否收到保护", "varchar(255)")]
        public String AdminProtect { get => _AdminProtect; set { if (OnPropertyChanging("AdminProtect", value)) { _AdminProtect = value; OnPropertyChanged("AdminProtect"); } } }

        private String _AdminIdentify;
        /// <summary>管理识别Id</summary>
        [DisplayName("管理识别Id")]
        [Description("管理识别Id")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("admin_identify", "管理识别Id", "varchar(255)")]
        public String AdminIdentify { get => _AdminIdentify; set { if (OnPropertyChanging("AdminIdentify", value)) { _AdminIdentify = value; OnPropertyChanged("AdminIdentify"); } } }

        private String _AdminName;
        /// <summary>管理员命名名称，方便管理</summary>
        [DisplayName("管理员命名名称")]
        [Description("管理员命名名称，方便管理")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("admin_name", "管理员命名名称，方便管理", "varchar(255)")]
        public String AdminName { get => _AdminName; set { if (OnPropertyChanging("AdminName", value)) { _AdminName = value; OnPropertyChanged("AdminName"); } } }

        private String _AdminNickName;
        /// <summary>管理员对应的QQ昵称</summary>
        [DisplayName("管理员对应的QQ昵称")]
        [Description("管理员对应的QQ昵称")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("admin_nick_name", "管理员对应的QQ昵称", "varchar(255)")]
        public String AdminNickName { get => _AdminNickName; set { if (OnPropertyChanging("AdminNickName", value)) { _AdminNickName = value; OnPropertyChanged("AdminNickName"); } } }

        private String _AdminCreateTime;
        /// <summary>管理员创建的时间</summary>
        [DisplayName("管理员创建的时间")]
        [Description("管理员创建的时间")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("admin_create_time", "管理员创建的时间", "varchar(255)")]
        public String AdminCreateTime { get => _AdminCreateTime; set { if (OnPropertyChanging("AdminCreateTime", value)) { _AdminCreateTime = value; OnPropertyChanged("AdminCreateTime"); } } }

        private String _AdminLimitAuthority;
        /// <summary>管理员权限等级</summary>
        [DisplayName("管理员权限等级")]
        [Description("管理员权限等级")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("admin_limit_authority", "管理员权限等级", "varchar(255)")]
        public String AdminLimitAuthority { get => _AdminLimitAuthority; set { if (OnPropertyChanging("AdminLimitAuthority", value)) { _AdminLimitAuthority = value; OnPropertyChanged("AdminLimitAuthority"); } } }
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
                    case "AdminIdx": return _AdminIdx;
                    case "AdminId": return _AdminId;
                    case "AdminProtect": return _AdminProtect;
                    case "AdminIdentify": return _AdminIdentify;
                    case "AdminName": return _AdminName;
                    case "AdminNickName": return _AdminNickName;
                    case "AdminCreateTime": return _AdminCreateTime;
                    case "AdminLimitAuthority": return _AdminLimitAuthority;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "AdminIdx": _AdminIdx = value.ToInt(); break;
                    case "AdminId": _AdminId = Convert.ToString(value); break;
                    case "AdminProtect": _AdminProtect = Convert.ToString(value); break;
                    case "AdminIdentify": _AdminIdentify = Convert.ToString(value); break;
                    case "AdminName": _AdminName = Convert.ToString(value); break;
                    case "AdminNickName": _AdminNickName = Convert.ToString(value); break;
                    case "AdminCreateTime": _AdminCreateTime = Convert.ToString(value); break;
                    case "AdminLimitAuthority": _AdminLimitAuthority = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得Admin字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>管理员idx，自增</summary>
            public static readonly Field AdminIdx = FindByName("AdminIdx");

            /// <summary>管理员QQ号</summary>
            public static readonly Field AdminId = FindByName("AdminId");

            /// <summary>管理员是否收到保护</summary>
            public static readonly Field AdminProtect = FindByName("AdminProtect");

            /// <summary>管理识别Id</summary>
            public static readonly Field AdminIdentify = FindByName("AdminIdentify");

            /// <summary>管理员命名名称，方便管理</summary>
            public static readonly Field AdminName = FindByName("AdminName");

            /// <summary>管理员对应的QQ昵称</summary>
            public static readonly Field AdminNickName = FindByName("AdminNickName");

            /// <summary>管理员创建的时间</summary>
            public static readonly Field AdminCreateTime = FindByName("AdminCreateTime");

            /// <summary>管理员权限等级</summary>
            public static readonly Field AdminLimitAuthority = FindByName("AdminLimitAuthority");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得Admin字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>管理员idx，自增</summary>
            public const String AdminIdx = "AdminIdx";

            /// <summary>管理员QQ号</summary>
            public const String AdminId = "AdminId";

            /// <summary>管理员是否收到保护</summary>
            public const String AdminProtect = "AdminProtect";

            /// <summary>管理识别Id</summary>
            public const String AdminIdentify = "AdminIdentify";

            /// <summary>管理员命名名称，方便管理</summary>
            public const String AdminName = "AdminName";

            /// <summary>管理员对应的QQ昵称</summary>
            public const String AdminNickName = "AdminNickName";

            /// <summary>管理员创建的时间</summary>
            public const String AdminCreateTime = "AdminCreateTime";

            /// <summary>管理员权限等级</summary>
            public const String AdminLimitAuthority = "AdminLimitAuthority";
        }
        #endregion
    }
}