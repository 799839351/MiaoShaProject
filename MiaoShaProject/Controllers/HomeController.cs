using Beyondbit.Framework;
using BO;
using Common;
using Common.Cache;
using Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiaoShaProject.Controllers
{
    public class HomeController : Controller
    {

        private  readonly Lazy<MiaoShaUserBO> _lazyMiaoShaUserBO ;

        public HomeController()
        {
            _lazyMiaoShaUserBO = new Lazy<MiaoShaUserBO>(ProxyService.Create<MiaoShaUserBO>);
        }

        public MiaoShaUserBO MiaoShaUserBO
        {
            get { return _lazyMiaoShaUserBO.Value; }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Login(MiaoShaUser user)
        {
           var miaoshaUser= MiaoShaUserBO.Login(user);
            ResponseResult responseResult;
            if (miaoshaUser != null)
            {
                
                // Session["User"] = model;用redis分布式缓存模拟session
                String token = Guid.NewGuid().ToString();

                CacheHelper.AddCache(token, JsonConvert.SerializeObject(miaoshaUser), DateTime.Now.AddMinutes(20));

                //往客户端写入cookie
                Response.Cookies["token"].Value = token;

                responseResult = ResponseResult.Succeed(miaoshaUser);
            }
            else
            {
                responseResult=ResponseResult.Error(CodeMessage.LoginError);
            }
            return Json(responseResult);

        }


    }
}