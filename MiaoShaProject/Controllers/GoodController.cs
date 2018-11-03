using Beyondbit.Framework;
using BO;
using Common;
using Common.Cache;
using Entity;
using MiaoShaProject.Filter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiaoShaProject.Controllers
{
    //[LoginCheckFilter(IsCheck = true)]
    public class GoodController : Controller
    {

        private readonly Lazy<GoodBO> _lazyGoodBO;
        private readonly Lazy<MiaoShaOrderBO> _lazyMiaoShaOrderBO;
        private readonly Lazy<OrderInfoBO> _lazyOrderInfoBO;
        private readonly RedisCacheWriter cache = new RedisCacheWriter();

        public GoodController()
        {

            _lazyGoodBO = new Lazy<GoodBO>(ProxyService.Create<GoodBO>);
            _lazyMiaoShaOrderBO = new Lazy<MiaoShaOrderBO>(ProxyService.Create<MiaoShaOrderBO>);
            _lazyOrderInfoBO = new Lazy<OrderInfoBO>(ProxyService.Create<OrderInfoBO>);
        }

        public GoodBO GoodBO
        {
            get { return _lazyGoodBO.Value; }
        }

        public MiaoShaOrderBO MiaoShaOrderBO
        {
            get { return _lazyMiaoShaOrderBO.Value; }
        }
        public OrderInfoBO OrderInfoBO
        {
            get { return _lazyOrderInfoBO.Value; }
        }

        // GET: Good
        public ActionResult Index()
        {
            var model = GoodBO.GetGood();
            return View(model);
        }

        /// <summary>
        /// 商品详情页
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GoodDetail(Int64? id)
        {
            String token = this.HttpContext.Request.Cookies["token"].Value;
            var user = JsonConvert.DeserializeObject<MiaoShaUser>(CacheHelper.GetCache(token).ToString());
            var good = GoodBO.GetGoodById(Convert.ToInt64(id));
            GoodDetailView model = new GoodDetailView();
            double remainSeconds;
            int miaoshaStatus = 0;
            if (DateTime.Now < good.StartDate)
            {//秒杀还没开始，倒计时
                miaoshaStatus = 0;
                remainSeconds = (good.StartDate.Value - good.EndDate.Value).TotalMilliseconds;
            }
            else if (DateTime.Now > good.EndDate)
            {//秒杀已经结束
                miaoshaStatus = 2;
                remainSeconds = -1;
            }
            else
            {//秒杀进行中
                miaoshaStatus = 1;
                remainSeconds = 0;
            }
            model.Good = good;
            model.MiaoShaStatus = miaoshaStatus;
            model.RemainSeconds = remainSeconds;
            model.User = user;
            return View(model);
        }


        /// <summary>
        /// 秒杀功能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult MiaoSha(Int64 goodsId)
        {
            String token = this.HttpContext.Request.Cookies["token"].Value;
            var user = JsonConvert.DeserializeObject<MiaoShaUser>(CacheHelper.GetCache(token).ToString());
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            #region 优化前代码
            ////判断库存
            //Good good = GoodBO.GetGoodById(goodsId);
            //int stock = good.StockCount;
            //if (stock <= 0)
            //{
            //    return Json(ResponseResult.Error(CodeMessage.MiaoShaOverError));
            //}
            ////判断是否已经秒杀到了
            //MiaoShaOrder order = MiaoShaOrderBO.GetMiaoshaOrderByUserIdGoodsId(user.Id, goodsId);
            //if (order != null)
            //{
            //    return Json(ResponseResult.Error(CodeMessage.MiaoShaRepeat));
            //}
            ////减库存 下订单 写入秒杀订单
            //var orderInfo = OrderInfoBO.MiaoSha(user, good);
            //if (orderInfo != null)
            //{
            //    return Json(ResponseResult.Succeed(orderInfo));
            //}
            //else
            //{
            //    return Json(ResponseResult.Error(CodeMessage.MiaoShaOverError));
            //}

            #endregion

            #region 优化后代码
            //内存标记，减少redis访问
            //预减库存
            var stock = Convert.ToInt64(cache.GetCache("GoodId" + goodsId));
            if (stock < 0)
            {
                return Json(ResponseResult.Error(CodeMessage.MiaoShaOverError));
            }

            //判断是否已经秒杀到了
            MiaoShaOrder order = MiaoShaOrderBO.GetMiaoshaOrderByUserIdGoodsId(user.Id, goodsId);
            if (order != null)
            {
                return Json(ResponseResult.Error(CodeMessage.MiaoShaRepeat));
            }
            //入队
            MiaoShaMessage mm = new MiaoShaMessage();
            mm.MiaoShaUser = user;
            mm.GoodId = goodsId;
            MQSender ms = new MQSender();
            MQReceiver mr = new MQReceiver();
            ms.sendMiaoshaMessage(mm);
            mr.Consumer();
            return Json(ResponseResult.Succeed("成功"));
            #endregion

        }
    }
}