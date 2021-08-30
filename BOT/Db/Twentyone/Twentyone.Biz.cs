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
    public partial class Twentyone : Entity<Twentyone>
    {
        #region 对象操作
        static Twentyone()
        {

            // 过滤器 UserModule、TimeModule、IPModule
        }

        /// <summary>验证并修补数据，通过抛出异常的方式提示验证失败。</summary>
        /// <param name="isNew">是否插入</param>
        public override void Valid(Boolean isNew)
        {
            // 如果没有脏数据，则不需要进行任何处理
            if (!HasDirty) return;

            // 这里验证参数范围，建议抛出参数异常，指定参数名，前端用户界面可以捕获参数异常并聚焦到对应的参数输入框
            if (ToId.IsNullOrEmpty()) throw new ArgumentNullException(nameof(ToId), "每一局的唯一ID不能为空！");
            if (ToGroup.IsNullOrEmpty()) throw new ArgumentNullException(nameof(ToGroup), "来自哪一组不能为空！");
            if (ToFinish.IsNullOrEmpty()) throw new ArgumentNullException(nameof(ToFinish), "是否结束不能为空！");
            if (ToBanker.IsNullOrEmpty()) throw new ArgumentNullException(nameof(ToBanker), "庄家不能为空！");
            if (ToP1.IsNullOrEmpty()) throw new ArgumentNullException(nameof(ToP1), "P1玩家QQ不能为空！");
            if (ToP2.IsNullOrEmpty()) throw new ArgumentNullException(nameof(ToP2), "P2玩家QQ不能为空！");
            if (BankerInitCard.IsNullOrEmpty()) throw new ArgumentNullException(nameof(BankerInitCard), "庄家初始牌不能为空！");
            if (P1InitCard.IsNullOrEmpty()) throw new ArgumentNullException(nameof(P1InitCard), "P1初始牌不能为空！");
            if (P2InitCard.IsNullOrEmpty()) throw new ArgumentNullException(nameof(P2InitCard), "P2初始牌不能为空！");
            if (BankerCard.IsNullOrEmpty()) throw new ArgumentNullException(nameof(BankerCard), "庄家当前牌不能为空！");
            if (P1Card.IsNullOrEmpty()) throw new ArgumentNullException(nameof(P1Card), "P1当前牌不能为空！");
            if (P2Card.IsNullOrEmpty()) throw new ArgumentNullException(nameof(P2Card), "P2当前牌不能为空！");
            if (P1Num.IsNullOrEmpty()) throw new ArgumentNullException(nameof(P1Num), "P1当前牌点数总大小不能为空！");
            if (P2Num.IsNullOrEmpty()) throw new ArgumentNullException(nameof(P2Num), "P2当前牌点数总大小不能为空！");

            // 建议先调用基类方法，基类方法会做一些统一处理
            base.Valid(isNew);

            // 在新插入数据或者修改了指定字段时进行修正

            // 检查唯一索引
            // CheckExist(isNew, nameof(ToIdex));
        }

        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected override void InitData()
        //{
        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    if (Meta.Session.Count > 0) return;

        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化Twentyone[Twentyone]数据……");

        //    var entity = new Twentyone();
        //    entity.ToIdex = 0;
        //    entity.ToId = "abc";
        //    entity.ToGroup = "abc";
        //    entity.ToFinish = "abc";
        //    entity.ToBanker = "abc";
        //    entity.ToP1 = "abc";
        //    entity.ToP2 = "abc";
        //    entity.ToP3 = "abc";
        //    entity.ToP4 = "abc";
        //    entity.BankerInitCard = "abc";
        //    entity.P1InitCard = "abc";
        //    entity.P2InitCard = "abc";
        //    entity.P3InitCard = "abc";
        //    entity.P4InitCard = "abc";
        //    entity.BankerCard = "abc";
        //    entity.P1Card = "abc";
        //    entity.P2Card = "abc";
        //    entity.P3Card = "abc";
        //    entity.P4Card = "abc";
        //    entity.P1Num = "abc";
        //    entity.P2Num = "abc";
        //    entity.P3Num = "abc";
        //    entity.P4Num = "abc";
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化Twentyone[Twentyone]数据！");
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
        /// <summary>根据idx查找</summary>
        /// <param name="toIdex">idx</param>
        /// <returns>实体对象</returns>
        public static Twentyone FindByToIdex(Int32 toIdex)
        {
            if (toIdex <= 0) return null;

            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.ToIdex == toIdex);

            // 单对象缓存
            return Meta.SingleCache[toIdex];

            //return Find(_.ToIdex == toIdex);
        }
        #endregion

        #region 高级查询

        // Select Count(Id) as Id,Category From twentyone Where CreateTime>'2020-01-24 00:00:00' Group By Category Order By Id Desc limit 20
        //static readonly FieldCache<Twentyone> _CategoryCache = new FieldCache<Twentyone>(nameof(Category))
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