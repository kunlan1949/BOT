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
    [BindIndex("PRIMARY", true, "member")]
    [BindTable("genshin", Description = "", ConnName = "BotDb", DbType = DatabaseType.None)]
    public partial class Genshin
    {
        #region 属性
        private String _Member;
        /// <summary>玩家qq号</summary>
        [DisplayName("玩家qq号")]
        [Description("玩家qq号")]
        [DataObjectField(true, false, false, 255)]
        [BindColumn("member", "玩家qq号", "varchar(255)")]
        public String Member { get => _Member; set { if (OnPropertyChanging("Member", value)) { _Member = value; OnPropertyChanged("Member"); } } }

        private String _Group;
        /// <summary>所属群组</summary>
        [DisplayName("所属群组")]
        [Description("所属群组")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("group", "所属群组", "varchar(255)")]
        public String Group { get => _Group; set { if (OnPropertyChanging("Group", value)) { _Group = value; OnPropertyChanged("Group"); } } }

        private Int32 _Primogem;
        /// <summary>原石数量</summary>
        [DisplayName("原石数量")]
        [Description("原石数量")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("primogem", "原石数量", "int(255)")]
        public Int32 Primogem { get => _Primogem; set { if (OnPropertyChanging("Primogem", value)) { _Primogem = value; OnPropertyChanged("Primogem"); } } }

        private Int32 _AcquaintFate;
        /// <summary>相遇之源数量</summary>
        [DisplayName("相遇之源数量")]
        [Description("相遇之源数量")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("acquaint_fate", "相遇之源数量", "int(255)")]
        public Int32 AcquaintFate { get => _AcquaintFate; set { if (OnPropertyChanging("AcquaintFate", value)) { _AcquaintFate = value; OnPropertyChanged("AcquaintFate"); } } }

        private Int32 _IntertwinedFate;
        /// <summary>纠缠之源数量</summary>
        [DisplayName("纠缠之源数量")]
        [Description("纠缠之源数量")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("intertwined_fate", "纠缠之源数量", "int(255)")]
        public Int32 IntertwinedFate { get => _IntertwinedFate; set { if (OnPropertyChanging("IntertwinedFate", value)) { _IntertwinedFate = value; OnPropertyChanged("IntertwinedFate"); } } }

        private Int32 _Resident5Count;
        /// <summary>抽取的常驻池五星次数（低保用）</summary>
        [DisplayName("抽取的常驻池五星次数")]
        [Description("抽取的常驻池五星次数（低保用）")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("resident5_count", "抽取的常驻池五星次数（低保用）", "int(255)")]
        public Int32 Resident5Count { get => _Resident5Count; set { if (OnPropertyChanging("Resident5Count", value)) { _Resident5Count = value; OnPropertyChanged("Resident5Count"); } } }

        private Int32 _Resident4Count;
        /// <summary>抽取的常驻池四星次数（低保用）</summary>
        [DisplayName("抽取的常驻池四星次数")]
        [Description("抽取的常驻池四星次数（低保用）")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("resident4_count", "抽取的常驻池四星次数（低保用）", "int(255)")]
        public Int32 Resident4Count { get => _Resident4Count; set { if (OnPropertyChanging("Resident4Count", value)) { _Resident4Count = value; OnPropertyChanged("Resident4Count"); } } }

        private Int32 _WeaponUp5Count;
        /// <summary>抽取的武器Up池五星次数（低保用）</summary>
        [DisplayName("抽取的武器Up池五星次数")]
        [Description("抽取的武器Up池五星次数（低保用）")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("weapon_up5_count", "抽取的武器Up池五星次数（低保用）", "int(255)")]
        public Int32 WeaponUp5Count { get => _WeaponUp5Count; set { if (OnPropertyChanging("WeaponUp5Count", value)) { _WeaponUp5Count = value; OnPropertyChanged("WeaponUp5Count"); } } }

        private Int32 _WeaponUp4Count;
        /// <summary>抽取的武器Up池四星次数（低保用）</summary>
        [DisplayName("抽取的武器Up池四星次数")]
        [Description("抽取的武器Up池四星次数（低保用）")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("weapon_up4_count", "抽取的武器Up池四星次数（低保用）", "int(255)")]
        public Int32 WeaponUp4Count { get => _WeaponUp4Count; set { if (OnPropertyChanging("WeaponUp4Count", value)) { _WeaponUp4Count = value; OnPropertyChanged("WeaponUp4Count"); } } }

        private Int32 _RoleUp5Count;
        /// <summary>抽取的角色Up池五星次数（低保用）</summary>
        [DisplayName("抽取的角色Up池五星次数")]
        [Description("抽取的角色Up池五星次数（低保用）")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("role_up5_count", "抽取的角色Up池五星次数（低保用）", "int(255)")]
        public Int32 RoleUp5Count { get => _RoleUp5Count; set { if (OnPropertyChanging("RoleUp5Count", value)) { _RoleUp5Count = value; OnPropertyChanged("RoleUp5Count"); } } }

        private Int32 _RoleUp4Count;
        /// <summary>抽取的角色Up池四星次数（低保用）</summary>
        [DisplayName("抽取的角色Up池四星次数")]
        [Description("抽取的角色Up池四星次数（低保用）")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("role_up4_count", "抽取的角色Up池四星次数（低保用）", "int(255)")]
        public Int32 RoleUp4Count { get => _RoleUp4Count; set { if (OnPropertyChanging("RoleUp4Count", value)) { _RoleUp4Count = value; OnPropertyChanged("RoleUp4Count"); } } }

        private Int32 _PortectWeapon;
        /// <summary>累计的5星武器保底次数</summary>
        [DisplayName("累计的5星武器保底次数")]
        [Description("累计的5星武器保底次数")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("portect_weapon", "累计的5星武器保底次数", "int(255)")]
        public Int32 PortectWeapon { get => _PortectWeapon; set { if (OnPropertyChanging("PortectWeapon", value)) { _PortectWeapon = value; OnPropertyChanged("PortectWeapon"); } } }

        private Int32 _PortectRole;
        /// <summary>累计的5星角色保底次数</summary>
        [DisplayName("累计的5星角色保底次数")]
        [Description("累计的5星角色保底次数")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("portect_role", "累计的5星角色保底次数", "int(255)")]
        public Int32 PortectRole { get => _PortectRole; set { if (OnPropertyChanging("PortectRole", value)) { _PortectRole = value; OnPropertyChanged("PortectRole"); } } }

        private Int32 _Resident;
        /// <summary>累计抽取的常驻池次数</summary>
        [DisplayName("累计抽取的常驻池次数")]
        [Description("累计抽取的常驻池次数")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("resident", "累计抽取的常驻池次数", "int(255)")]
        public Int32 Resident { get => _Resident; set { if (OnPropertyChanging("Resident", value)) { _Resident = value; OnPropertyChanged("Resident"); } } }

        private Int32 _WeaponUp;
        /// <summary>累计抽取的武器Up池次数</summary>
        [DisplayName("累计抽取的武器Up池次数")]
        [Description("累计抽取的武器Up池次数")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("weapon_up", "累计抽取的武器Up池次数", "int(255)")]
        public Int32 WeaponUp { get => _WeaponUp; set { if (OnPropertyChanging("WeaponUp", value)) { _WeaponUp = value; OnPropertyChanged("WeaponUp"); } } }

        private Int32 _RoleUp;
        /// <summary>累计抽取的角色Up池次数</summary>
        [DisplayName("累计抽取的角色Up池次数")]
        [Description("累计抽取的角色Up池次数")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("role_up", "累计抽取的角色Up池次数", "int(255)")]
        public Int32 RoleUp { get => _RoleUp; set { if (OnPropertyChanging("RoleUp", value)) { _RoleUp = value; OnPropertyChanged("RoleUp"); } } }

        private Int32 _ResidentWeapon5;
        /// <summary>累计抽到的常驻武器5星次数</summary>
        [DisplayName("累计抽到的常驻武器5星次数")]
        [Description("累计抽到的常驻武器5星次数")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("resident_weapon5", "累计抽到的常驻武器5星次数", "int(255)")]
        public Int32 ResidentWeapon5 { get => _ResidentWeapon5; set { if (OnPropertyChanging("ResidentWeapon5", value)) { _ResidentWeapon5 = value; OnPropertyChanged("ResidentWeapon5"); } } }

        private Int32 _ResidentWeapon4;
        /// <summary>累计抽到的常驻武器4星次数</summary>
        [DisplayName("累计抽到的常驻武器4星次数")]
        [Description("累计抽到的常驻武器4星次数")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("resident_weapon4", "累计抽到的常驻武器4星次数", "int(255)")]
        public Int32 ResidentWeapon4 { get => _ResidentWeapon4; set { if (OnPropertyChanging("ResidentWeapon4", value)) { _ResidentWeapon4 = value; OnPropertyChanged("ResidentWeapon4"); } } }

        private Int32 _ResidentWeapon3;
        /// <summary>累计抽到的常驻武器3星次数</summary>
        [DisplayName("累计抽到的常驻武器3星次数")]
        [Description("累计抽到的常驻武器3星次数")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("resident_weapon3", "累计抽到的常驻武器3星次数", "int(255)")]
        public Int32 ResidentWeapon3 { get => _ResidentWeapon3; set { if (OnPropertyChanging("ResidentWeapon3", value)) { _ResidentWeapon3 = value; OnPropertyChanged("ResidentWeapon3"); } } }

        private Int32 _ResidentRole5;
        /// <summary>累计抽到的常驻角色5星次数</summary>
        [DisplayName("累计抽到的常驻角色5星次数")]
        [Description("累计抽到的常驻角色5星次数")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("resident_role5", "累计抽到的常驻角色5星次数", "int(255)")]
        public Int32 ResidentRole5 { get => _ResidentRole5; set { if (OnPropertyChanging("ResidentRole5", value)) { _ResidentRole5 = value; OnPropertyChanged("ResidentRole5"); } } }

        private Int32 _ResidentRole4;
        /// <summary>累计抽到的常驻角色4星次数</summary>
        [DisplayName("累计抽到的常驻角色4星次数")]
        [Description("累计抽到的常驻角色4星次数")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("resident_role4", "累计抽到的常驻角色4星次数", "int(255)")]
        public Int32 ResidentRole4 { get => _ResidentRole4; set { if (OnPropertyChanging("ResidentRole4", value)) { _ResidentRole4 = value; OnPropertyChanged("ResidentRole4"); } } }

        private Int32 _UpWeapon5;
        /// <summary>累计抽到的武器Up池5星武器数量</summary>
        [DisplayName("累计抽到的武器Up池5星武器数量")]
        [Description("累计抽到的武器Up池5星武器数量")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("up_weapon5", "累计抽到的武器Up池5星武器数量", "int(255)")]
        public Int32 UpWeapon5 { get => _UpWeapon5; set { if (OnPropertyChanging("UpWeapon5", value)) { _UpWeapon5 = value; OnPropertyChanged("UpWeapon5"); } } }

        private Int32 _UpWeapon4;
        /// <summary>累计抽到的武器Up池4星武器数量</summary>
        [DisplayName("累计抽到的武器Up池4星武器数量")]
        [Description("累计抽到的武器Up池4星武器数量")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("up_weapon4", "累计抽到的武器Up池4星武器数量", "int(255)")]
        public Int32 UpWeapon4 { get => _UpWeapon4; set { if (OnPropertyChanging("UpWeapon4", value)) { _UpWeapon4 = value; OnPropertyChanged("UpWeapon4"); } } }

        private Int32 _UpWeapon3;
        /// <summary>累计抽到的武器Up池3星武器数量</summary>
        [DisplayName("累计抽到的武器Up池3星武器数量")]
        [Description("累计抽到的武器Up池3星武器数量")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("up_weapon3", "累计抽到的武器Up池3星武器数量", "int(255)")]
        public Int32 UpWeapon3 { get => _UpWeapon3; set { if (OnPropertyChanging("UpWeapon3", value)) { _UpWeapon3 = value; OnPropertyChanged("UpWeapon3"); } } }

        private Int32 _UpWeaponRole4;
        /// <summary>累计抽到的武器Up池4星角色数量</summary>
        [DisplayName("累计抽到的武器Up池4星角色数量")]
        [Description("累计抽到的武器Up池4星角色数量")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("up_weapon_role4", "累计抽到的武器Up池4星角色数量", "int(255)")]
        public Int32 UpWeaponRole4 { get => _UpWeaponRole4; set { if (OnPropertyChanging("UpWeaponRole4", value)) { _UpWeaponRole4 = value; OnPropertyChanged("UpWeaponRole4"); } } }

        private Int32 _UpRole5;
        /// <summary>累计抽到的角色Up池5星角色数量</summary>
        [DisplayName("累计抽到的角色Up池5星角色数量")]
        [Description("累计抽到的角色Up池5星角色数量")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("up_role5", "累计抽到的角色Up池5星角色数量", "int(255)")]
        public Int32 UpRole5 { get => _UpRole5; set { if (OnPropertyChanging("UpRole5", value)) { _UpRole5 = value; OnPropertyChanged("UpRole5"); } } }

        private Int32 _UpRole4;
        /// <summary>累计抽到的角色Up池4星角色数量</summary>
        [DisplayName("累计抽到的角色Up池4星角色数量")]
        [Description("累计抽到的角色Up池4星角色数量")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("up_role4", "累计抽到的角色Up池4星角色数量", "int(255)")]
        public Int32 UpRole4 { get => _UpRole4; set { if (OnPropertyChanging("UpRole4", value)) { _UpRole4 = value; OnPropertyChanged("UpRole4"); } } }

        private Int32 _UpRoleWeapon4;
        /// <summary>累计抽到的角色Up池4星武器数量</summary>
        [DisplayName("累计抽到的角色Up池4星武器数量")]
        [Description("累计抽到的角色Up池4星武器数量")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("up_role_weapon4", "累计抽到的角色Up池4星武器数量", "int(255)")]
        public Int32 UpRoleWeapon4 { get => _UpRoleWeapon4; set { if (OnPropertyChanging("UpRoleWeapon4", value)) { _UpRoleWeapon4 = value; OnPropertyChanged("UpRoleWeapon4"); } } }

        private Int32 _UpRoleWeapon3;
        /// <summary>累计抽到的角色Up池3星武器数量</summary>
        [DisplayName("累计抽到的角色Up池3星武器数量")]
        [Description("累计抽到的角色Up池3星武器数量")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("up_role_weapon3", "累计抽到的角色Up池3星武器数量", "int(255)")]
        public Int32 UpRoleWeapon3 { get => _UpRoleWeapon3; set { if (OnPropertyChanging("UpRoleWeapon3", value)) { _UpRoleWeapon3 = value; OnPropertyChanged("UpRoleWeapon3"); } } }
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
                    case "Member": return _Member;
                    case "Group": return _Group;
                    case "Primogem": return _Primogem;
                    case "AcquaintFate": return _AcquaintFate;
                    case "IntertwinedFate": return _IntertwinedFate;
                    case "Resident5Count": return _Resident5Count;
                    case "Resident4Count": return _Resident4Count;
                    case "WeaponUp5Count": return _WeaponUp5Count;
                    case "WeaponUp4Count": return _WeaponUp4Count;
                    case "RoleUp5Count": return _RoleUp5Count;
                    case "RoleUp4Count": return _RoleUp4Count;
                    case "PortectWeapon": return _PortectWeapon;
                    case "PortectRole": return _PortectRole;
                    case "Resident": return _Resident;
                    case "WeaponUp": return _WeaponUp;
                    case "RoleUp": return _RoleUp;
                    case "ResidentWeapon5": return _ResidentWeapon5;
                    case "ResidentWeapon4": return _ResidentWeapon4;
                    case "ResidentWeapon3": return _ResidentWeapon3;
                    case "ResidentRole5": return _ResidentRole5;
                    case "ResidentRole4": return _ResidentRole4;
                    case "UpWeapon5": return _UpWeapon5;
                    case "UpWeapon4": return _UpWeapon4;
                    case "UpWeapon3": return _UpWeapon3;
                    case "UpWeaponRole4": return _UpWeaponRole4;
                    case "UpRole5": return _UpRole5;
                    case "UpRole4": return _UpRole4;
                    case "UpRoleWeapon4": return _UpRoleWeapon4;
                    case "UpRoleWeapon3": return _UpRoleWeapon3;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Member": _Member = Convert.ToString(value); break;
                    case "Group": _Group = Convert.ToString(value); break;
                    case "Primogem": _Primogem = value.ToInt(); break;
                    case "AcquaintFate": _AcquaintFate = value.ToInt(); break;
                    case "IntertwinedFate": _IntertwinedFate = value.ToInt(); break;
                    case "Resident5Count": _Resident5Count = value.ToInt(); break;
                    case "Resident4Count": _Resident4Count = value.ToInt(); break;
                    case "WeaponUp5Count": _WeaponUp5Count = value.ToInt(); break;
                    case "WeaponUp4Count": _WeaponUp4Count = value.ToInt(); break;
                    case "RoleUp5Count": _RoleUp5Count = value.ToInt(); break;
                    case "RoleUp4Count": _RoleUp4Count = value.ToInt(); break;
                    case "PortectWeapon": _PortectWeapon = value.ToInt(); break;
                    case "PortectRole": _PortectRole = value.ToInt(); break;
                    case "Resident": _Resident = value.ToInt(); break;
                    case "WeaponUp": _WeaponUp = value.ToInt(); break;
                    case "RoleUp": _RoleUp = value.ToInt(); break;
                    case "ResidentWeapon5": _ResidentWeapon5 = value.ToInt(); break;
                    case "ResidentWeapon4": _ResidentWeapon4 = value.ToInt(); break;
                    case "ResidentWeapon3": _ResidentWeapon3 = value.ToInt(); break;
                    case "ResidentRole5": _ResidentRole5 = value.ToInt(); break;
                    case "ResidentRole4": _ResidentRole4 = value.ToInt(); break;
                    case "UpWeapon5": _UpWeapon5 = value.ToInt(); break;
                    case "UpWeapon4": _UpWeapon4 = value.ToInt(); break;
                    case "UpWeapon3": _UpWeapon3 = value.ToInt(); break;
                    case "UpWeaponRole4": _UpWeaponRole4 = value.ToInt(); break;
                    case "UpRole5": _UpRole5 = value.ToInt(); break;
                    case "UpRole4": _UpRole4 = value.ToInt(); break;
                    case "UpRoleWeapon4": _UpRoleWeapon4 = value.ToInt(); break;
                    case "UpRoleWeapon3": _UpRoleWeapon3 = value.ToInt(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得Genshin字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>玩家qq号</summary>
            public static readonly Field Member = FindByName("Member");

            /// <summary>所属群组</summary>
            public static readonly Field Group = FindByName("Group");

            /// <summary>原石数量</summary>
            public static readonly Field Primogem = FindByName("Primogem");

            /// <summary>相遇之源数量</summary>
            public static readonly Field AcquaintFate = FindByName("AcquaintFate");

            /// <summary>纠缠之源数量</summary>
            public static readonly Field IntertwinedFate = FindByName("IntertwinedFate");

            /// <summary>抽取的常驻池五星次数（低保用）</summary>
            public static readonly Field Resident5Count = FindByName("Resident5Count");

            /// <summary>抽取的常驻池四星次数（低保用）</summary>
            public static readonly Field Resident4Count = FindByName("Resident4Count");

            /// <summary>抽取的武器Up池五星次数（低保用）</summary>
            public static readonly Field WeaponUp5Count = FindByName("WeaponUp5Count");

            /// <summary>抽取的武器Up池四星次数（低保用）</summary>
            public static readonly Field WeaponUp4Count = FindByName("WeaponUp4Count");

            /// <summary>抽取的角色Up池五星次数（低保用）</summary>
            public static readonly Field RoleUp5Count = FindByName("RoleUp5Count");

            /// <summary>抽取的角色Up池四星次数（低保用）</summary>
            public static readonly Field RoleUp4Count = FindByName("RoleUp4Count");

            /// <summary>累计的5星武器保底次数</summary>
            public static readonly Field PortectWeapon = FindByName("PortectWeapon");

            /// <summary>累计的5星角色保底次数</summary>
            public static readonly Field PortectRole = FindByName("PortectRole");

            /// <summary>累计抽取的常驻池次数</summary>
            public static readonly Field Resident = FindByName("Resident");

            /// <summary>累计抽取的武器Up池次数</summary>
            public static readonly Field WeaponUp = FindByName("WeaponUp");

            /// <summary>累计抽取的角色Up池次数</summary>
            public static readonly Field RoleUp = FindByName("RoleUp");

            /// <summary>累计抽到的常驻武器5星次数</summary>
            public static readonly Field ResidentWeapon5 = FindByName("ResidentWeapon5");

            /// <summary>累计抽到的常驻武器4星次数</summary>
            public static readonly Field ResidentWeapon4 = FindByName("ResidentWeapon4");

            /// <summary>累计抽到的常驻武器3星次数</summary>
            public static readonly Field ResidentWeapon3 = FindByName("ResidentWeapon3");

            /// <summary>累计抽到的常驻角色5星次数</summary>
            public static readonly Field ResidentRole5 = FindByName("ResidentRole5");

            /// <summary>累计抽到的常驻角色4星次数</summary>
            public static readonly Field ResidentRole4 = FindByName("ResidentRole4");

            /// <summary>累计抽到的武器Up池5星武器数量</summary>
            public static readonly Field UpWeapon5 = FindByName("UpWeapon5");

            /// <summary>累计抽到的武器Up池4星武器数量</summary>
            public static readonly Field UpWeapon4 = FindByName("UpWeapon4");

            /// <summary>累计抽到的武器Up池3星武器数量</summary>
            public static readonly Field UpWeapon3 = FindByName("UpWeapon3");

            /// <summary>累计抽到的武器Up池4星角色数量</summary>
            public static readonly Field UpWeaponRole4 = FindByName("UpWeaponRole4");

            /// <summary>累计抽到的角色Up池5星角色数量</summary>
            public static readonly Field UpRole5 = FindByName("UpRole5");

            /// <summary>累计抽到的角色Up池4星角色数量</summary>
            public static readonly Field UpRole4 = FindByName("UpRole4");

            /// <summary>累计抽到的角色Up池4星武器数量</summary>
            public static readonly Field UpRoleWeapon4 = FindByName("UpRoleWeapon4");

            /// <summary>累计抽到的角色Up池3星武器数量</summary>
            public static readonly Field UpRoleWeapon3 = FindByName("UpRoleWeapon3");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得Genshin字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>玩家qq号</summary>
            public const String Member = "Member";

            /// <summary>所属群组</summary>
            public const String Group = "Group";

            /// <summary>原石数量</summary>
            public const String Primogem = "Primogem";

            /// <summary>相遇之源数量</summary>
            public const String AcquaintFate = "AcquaintFate";

            /// <summary>纠缠之源数量</summary>
            public const String IntertwinedFate = "IntertwinedFate";

            /// <summary>抽取的常驻池五星次数（低保用）</summary>
            public const String Resident5Count = "Resident5Count";

            /// <summary>抽取的常驻池四星次数（低保用）</summary>
            public const String Resident4Count = "Resident4Count";

            /// <summary>抽取的武器Up池五星次数（低保用）</summary>
            public const String WeaponUp5Count = "WeaponUp5Count";

            /// <summary>抽取的武器Up池四星次数（低保用）</summary>
            public const String WeaponUp4Count = "WeaponUp4Count";

            /// <summary>抽取的角色Up池五星次数（低保用）</summary>
            public const String RoleUp5Count = "RoleUp5Count";

            /// <summary>抽取的角色Up池四星次数（低保用）</summary>
            public const String RoleUp4Count = "RoleUp4Count";

            /// <summary>累计的5星武器保底次数</summary>
            public const String PortectWeapon = "PortectWeapon";

            /// <summary>累计的5星角色保底次数</summary>
            public const String PortectRole = "PortectRole";

            /// <summary>累计抽取的常驻池次数</summary>
            public const String Resident = "Resident";

            /// <summary>累计抽取的武器Up池次数</summary>
            public const String WeaponUp = "WeaponUp";

            /// <summary>累计抽取的角色Up池次数</summary>
            public const String RoleUp = "RoleUp";

            /// <summary>累计抽到的常驻武器5星次数</summary>
            public const String ResidentWeapon5 = "ResidentWeapon5";

            /// <summary>累计抽到的常驻武器4星次数</summary>
            public const String ResidentWeapon4 = "ResidentWeapon4";

            /// <summary>累计抽到的常驻武器3星次数</summary>
            public const String ResidentWeapon3 = "ResidentWeapon3";

            /// <summary>累计抽到的常驻角色5星次数</summary>
            public const String ResidentRole5 = "ResidentRole5";

            /// <summary>累计抽到的常驻角色4星次数</summary>
            public const String ResidentRole4 = "ResidentRole4";

            /// <summary>累计抽到的武器Up池5星武器数量</summary>
            public const String UpWeapon5 = "UpWeapon5";

            /// <summary>累计抽到的武器Up池4星武器数量</summary>
            public const String UpWeapon4 = "UpWeapon4";

            /// <summary>累计抽到的武器Up池3星武器数量</summary>
            public const String UpWeapon3 = "UpWeapon3";

            /// <summary>累计抽到的武器Up池4星角色数量</summary>
            public const String UpWeaponRole4 = "UpWeaponRole4";

            /// <summary>累计抽到的角色Up池5星角色数量</summary>
            public const String UpRole5 = "UpRole5";

            /// <summary>累计抽到的角色Up池4星角色数量</summary>
            public const String UpRole4 = "UpRole4";

            /// <summary>累计抽到的角色Up池4星武器数量</summary>
            public const String UpRoleWeapon4 = "UpRoleWeapon4";

            /// <summary>累计抽到的角色Up池3星武器数量</summary>
            public const String UpRoleWeapon3 = "UpRoleWeapon3";
        }
        #endregion
    }
}