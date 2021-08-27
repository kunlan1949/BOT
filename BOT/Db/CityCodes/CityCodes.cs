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
    [BindTable("city_codes", Description = "", ConnName = "BotDb", DbType = DatabaseType.None)]
    public partial class CityCodes
    {
        #region 属性
        private Int32 _CityIdx;
        /// <summary>自增，idx</summary>
        [DisplayName("自增")]
        [Description("自增，idx")]
        [DataObjectField(true, true, false, 255)]
        [BindColumn("city_idx", "自增，idx", "int(255)")]
        public Int32 CityIdx { get => _CityIdx; set { if (OnPropertyChanging("CityIdx", value)) { _CityIdx = value; OnPropertyChanged("CityIdx"); } } }

        private String _CityName;
        /// <summary>城市名称</summary>
        [DisplayName("城市名称")]
        [Description("城市名称")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("city_name", "城市名称", "varchar(255)")]
        public String CityName { get => _CityName; set { if (OnPropertyChanging("CityName", value)) { _CityName = value; OnPropertyChanged("CityName"); } } }

        private Int32 _CityCode;
        /// <summary>城市代码</summary>
        [DisplayName("城市代码")]
        [Description("城市代码")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("city_code", "城市代码", "int(255)")]
        public Int32 CityCode { get => _CityCode; set { if (OnPropertyChanging("CityCode", value)) { _CityCode = value; OnPropertyChanged("CityCode"); } } }
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
                    case "CityIdx": return _CityIdx;
                    case "CityName": return _CityName;
                    case "CityCode": return _CityCode;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "CityIdx": _CityIdx = value.ToInt(); break;
                    case "CityName": _CityName = Convert.ToString(value); break;
                    case "CityCode": _CityCode = value.ToInt(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得CityCodes字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>自增，idx</summary>
            public static readonly Field CityIdx = FindByName("CityIdx");

            /// <summary>城市名称</summary>
            public static readonly Field CityName = FindByName("CityName");

            /// <summary>城市代码</summary>
            public static readonly Field CityCode = FindByName("CityCode");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得CityCodes字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>自增，idx</summary>
            public const String CityIdx = "CityIdx";

            /// <summary>城市名称</summary>
            public const String CityName = "CityName";

            /// <summary>城市代码</summary>
            public const String CityCode = "CityCode";
        }
        #endregion
    }
}