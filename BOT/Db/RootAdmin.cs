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
    [BindTable("root_admin", Description = "", ConnName = "BotDb", DbType = DatabaseType.None)]
    public partial class RootAdmin
    {
        #region 属性
        private Int32 _Idx;
        /// <summary>自增idx</summary>
        [DisplayName("自增idx")]
        [Description("自增idx")]
        [DataObjectField(true, true, false, 11)]
        [BindColumn("idx", "自增idx", "int(11)")]
        public Int32 Idx { get => _Idx; set { if (OnPropertyChanging("Idx", value)) { _Idx = value; OnPropertyChanged("Idx"); } } }

        private String _AdminId;
        /// <summary>根管理员id</summary>
        [DisplayName("根管理员id")]
        [Description("根管理员id")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("admin_id", "根管理员id", "varchar(255)")]
        public String AdminId { get => _AdminId; set { if (OnPropertyChanging("AdminId", value)) { _AdminId = value; OnPropertyChanged("AdminId"); } } }

        private String _AdminQq;
        /// <summary>根管理员QQ</summary>
        [DisplayName("根管理员QQ")]
        [Description("根管理员QQ")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("admin_qq", "根管理员QQ", "varchar(255)")]
        public String AdminQq { get => _AdminQq; set { if (OnPropertyChanging("AdminQq", value)) { _AdminQq = value; OnPropertyChanged("AdminQq"); } } }
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
                    case "Idx": return _Idx;
                    case "AdminId": return _AdminId;
                    case "AdminQq": return _AdminQq;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Idx": _Idx = value.ToInt(); break;
                    case "AdminId": _AdminId = Convert.ToString(value); break;
                    case "AdminQq": _AdminQq = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得RootAdmin字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>自增idx</summary>
            public static readonly Field Idx = FindByName("Idx");

            /// <summary>根管理员id</summary>
            public static readonly Field AdminId = FindByName("AdminId");

            /// <summary>根管理员QQ</summary>
            public static readonly Field AdminQq = FindByName("AdminQq");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得RootAdmin字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>自增idx</summary>
            public const String Idx = "Idx";

            /// <summary>根管理员id</summary>
            public const String AdminId = "AdminId";

            /// <summary>根管理员QQ</summary>
            public const String AdminQq = "AdminQq";
        }
        #endregion
    }
}