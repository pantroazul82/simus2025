using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSImus.Controllers
{
    public class LayoutControllerMaster: BaseController
    {


        public ActionResult Index()
        {
            ViewBag.nombreusuario = Session["$usuario"];
            return View();
        }
    }
}