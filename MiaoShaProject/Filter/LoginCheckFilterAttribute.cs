using Common.Cache;
using Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiaoShaProject.Filter
{
    public class LoginCheckFilterAttribute:AuthorizeAttribute
    {
        public Boolean IsCheck { set; get; }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (IsCheck)
            {
                if (filterContext.HttpContext.Request.Cookies["token"] == null)
                {
                    filterContext.HttpContext.Response.Redirect("/Account/Login");
                    return;
                }
                else
                {
                    if (filterContext.HttpContext.Request.Cookies["token"].Value == null)
                    {
                        filterContext.HttpContext.Response.Redirect("/Account/Login");
                        return;
                    }
                    String token = filterContext.HttpContext.Request.Cookies["token"].Value;
                    var user = JsonConvert.DeserializeObject<MiaoShaUser>(CacheHelper.GetCache(token).ToString());
                    if (user == null)
                    {
                        filterContext.HttpContext.Response.Redirect("/Account/Login");
                        return;
                    }
                    CacheHelper.SetCache(token, JsonConvert.SerializeObject(user), DateTime.Now.AddMinutes(20));
                }

            }
        }
    }
}