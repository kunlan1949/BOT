using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using NewLife;
using NewLife.Data;
using NewLife.Log;
using NewLife.Model;
using NewLife.Reflection;
using NewLife.Threading;
using NewLife.Web;
using XCode;
using XCode.Cache;
using XCode.Configuration;
using XCode.DataAccessLayer;
using XCode.Membership;

namespace Db.Bot
{
    /// <summary></summary>
    public partial class Constellation : Entity<Constellation>
    {
        #region 对象操作
        static Constellation()
        {

            // 过滤器 UserModule、TimeModule、IPModule
            Meta.Modules.Add<TimeModule>();
        }

        /// <summary>验证并修补数据，通过抛出异常的方式提示验证失败。</summary>
        /// <param name="isNew">是否插入</param>
        public override void Valid(Boolean isNew)
        {
            // 如果没有脏数据，则不需要进行任何处理
            if (!HasDirty) return;

            // 这里验证参数范围，建议抛出参数异常，指定参数名，前端用户界面可以捕获参数异常并聚焦到对应的参数输入框
            if (Sign.IsNullOrEmpty()) throw new ArgumentNullException(nameof(Sign), "星座不能为空！");
            if (UpdateTime.IsNullOrEmpty()) throw new ArgumentNullException(nameof(UpdateTime), "更新时间不能为空！");
            if (LuckResult.IsNullOrEmpty()) throw new ArgumentNullException(nameof(LuckResult), "运势内容不能为空！");

            // 建议先调用基类方法，基类方法会做一些统一处理
            base.Valid(isNew);

            // 在新插入数据或者修改了指定字段时进行修正
            //if (!Dirtys[nameof(UpdateTime)]) UpdateTime = DateTime.Now;
        }

        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected override void InitData()
        //{
        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    if (Meta.Session.Count > 0) return;

        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化Constellation[Constellation]数据……");

        //    var entity = new Constellation();
        //    entity.Idx = 0;
        //    entity.Sign = "abc";
        //    entity.UpdateTime = "abc";
        //    entity.LuckResult = "abc";
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化Constellation[Constellation]数据！");
        //}

        ///// <summary>已重载。基类先调用Valid(true)验证数据，然后在事务保护内调用OnInsert</summary>
        ///// <returns></returns>
        //public override Int32 Insert()
        //{
        //    return base.Insert();
        //}

        ///// <summary>已重载。在事务保护范围内处理业务，位于Valid之后</summary>
        ///// <returns></returns>
        //protected override Int32 OnDelete()
        //{
        //    return base.OnDelete();
        //}
        #endregion

        #region 扩展属性
        #endregion

        #region 扩展查询
        /// <summary>根据自增查找</summary>
        /// <param name="idx">自增</param>
        /// <returns>实体对象</returns>
        public static Constellation FindByIdx(Int32 idx)
        {
            if (idx <= 0) return null;

            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.Idx == idx);

            // 单对象缓存
            return Meta.SingleCache[idx];

            //return Find(_.Idx == idx);
        }
        #endregion

        #region 高级查询

        // Select Count(Idx) as Idx,Category From constellation Where CreateTime>'2020-01-24 00:00:00' Group By Category Order By Idx Desc limit 20
        //static readonly FieldCache<Constellation> _CategoryCache = new FieldCache<Constellation>(nameof(Category))
        //{
        //Where = _.CreateTime > DateTime.Today.AddDays(-30) & Expression.Empty
        //};

        ///// <summary>获取类别列表，字段缓存10分钟，分组统计数据最多的前20种，用于魔方前台下拉选择</summary>
        ///// <returns></returns>
        //public static IDictionary<String, String> GetCategoryList() => _CategoryCache.FindAllName();
        #endregion

        #region 业务操作
        #endregion
    }
}