using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSImus
{
    public class SessionExpireAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;

           
            // check  sessions here
            if (HttpContext.Current.Session["$usuario"] == null)
            {
                filterContext.Result = new RedirectResult("~/Cuenta/Login");
                return;
            }

            base.OnActionExecuting(filterContext);


        }
    }
}