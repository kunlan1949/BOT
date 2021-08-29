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
    [BindTable("citys", Description = "", ConnName = "BotDb", DbType = DatabaseType.None)]
    public partial class Citys
    {
        #region 属性
        private Int32 _CityIdx;
        /// <summary>自增，idx</summary>
        [DisplayName("自增")]
        [Description("自增，idx")]
        [DataObjectField(true, true, false, 255)]
        [BindColumn("city_idx", "自增，idx", "int(255)")]
        public Int32 CityIdx { get => _CityIdx; set { if (OnPropertyChanging("CityIdx", value)) { _CityIdx = value; OnPropertyChanged("CityIdx"); } } }

        private String _CityProvince;
        /// <summary>城市所属省份</summary>
        [DisplayName("城市所属省份")]
        [Description("城市所属省份")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("city_province", "城市所属省份", "varchar(255)")]
        public String CityProvince { get => _CityProvince; set { if (OnPropertyChanging("CityProvince", value)) { _CityProvince = value; OnPropertyChanged("CityProvince"); } } }

        private String _CityName;
        /// <summary>城市名</summary>
        [DisplayName("城市名")]
        [Description("城市名")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("city_name", "城市名", "varchar(255)")]
        public String CityName { get => _CityName; set { if (OnPropertyChanging("CityName", value)) { _CityName = value; OnPropertyChanged("CityName"); } } }

        private String _CityUrl;
        /// <summary>城市对应url</summary>
        [DisplayName("城市对应url")]
        [Description("城市对应url")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("city_url", "城市对应url", "varchar(255)")]
        public String CityUrl { get => _CityUrl; set { if (OnPropertyChanging("CityUrl", value)) { _CityUrl = value; OnPropertyChanged("CityUrl"); } } }

        private String _CityCode;
        /// <summary>城市代码</summary>
        [DisplayName("城市代码")]
        [Description("城市代码")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("city_code", "城市代码", "varchar(255)")]
        public String CityCode { get => _CityCode; set { if (OnPropertyChanging("CityCode", value)) { _CityCode = value; OnPropertyChanged("CityCode"); } } }
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
                    case "CityProvince": return _CityProvince;
                    case "CityName": return _CityName;
                    case "CityUrl": return _CityUrl;
                    case "CityCode": return _CityCode;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "CityIdx": _CityIdx = value.ToInt(); break;
                    case "CityProvince": _CityProvince = Convert.ToString(value); break;
                    case "CityName": _CityName = Convert.ToString(value); break;
                    case "CityUrl": _CityUrl = Convert.ToString(value); break;
                    case "CityCode": _CityCode = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得Citys字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>自增，idx</summary>
            public static readonly Field CityIdx = FindByName("CityIdx");

            /// <summary>城市所属省份</summary>
            public static readonly Field CityProvince = FindByName("CityProvince");

            /// <summary>城市名</summary>
            public static readonly Field CityName = FindByName("CityName");

            /// <summary>城市对应url</summary>
            public static readonly Field CityUrl = FindByName("CityUrl");

            /// <summary>城市代码</summary>
            public static readonly Field CityCode = FindByName("CityCode");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得Citys字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>自增，idx</summary>
            public const String CityIdx = "CityIdx";

            /// <summary>城市所属省份</summary>
            public const String CityProvince = "CityProvince";

            /// <summary>城市名</summary>
            public const String CityName = "CityName";

            /// <summary>城市对应url</summary>
            public const String CityUrl = "CityUrl";

            /// <summary>城市代码</summary>
            public const String CityCode = "CityCode";
        }
        #endregion
    }
}