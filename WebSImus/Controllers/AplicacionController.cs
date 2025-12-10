using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSImus.Controllers
{
    public class AplicacionController : Controller
    {
        // GET: Aplicacion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Asistencia()
        {
            return View();
        }
    }
}