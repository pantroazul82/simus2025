using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSImus.Controllers
{
    public sealed class ErrorController : Controller
    {
        //
        // GET: /Error/
        public ActionResult FailWhale()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }

        public ActionResult NotFound()
        {
            ActionResult result;

            object model = Request.Url.PathAndQuery;

            if (!Request.IsAjaxRequest())
                result = View(model);
            else
                result = PartialView("_NotFound", model);

            return result;
        }
	}
}