using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSImus.Controllers
{
    public class EstaticoController : Controller
    {
        //
        // GET: /Estatico/
        public ActionResult Politicas()
        {
            return View();
        }

        //
        // GET: /Estatico/
        public ActionResult Acercade()
        {
            return View();
        }

        public ActionResult Contactenos()
        {
            return View();
        }

        public ActionResult OtrosSistemas()
        {
            return View();
        }

        public ActionResult GrupoMusica()
        {
            return View();
        }

        public ActionResult Busqueda()
        {
            return View();
        }
	}
}