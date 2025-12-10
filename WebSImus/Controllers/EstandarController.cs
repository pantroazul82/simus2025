using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSImus.Controllers
{
    public class EstandarController : Controller
    {
        //F
        // GET: /Estandar/
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult perfilAudio()
		{
			var file = Server.MapPath("~/assets/audio/TheBeatles.mp3");
			return File(file, "audio/mp3");
		}

        public ActionResult Formularios()
        {
            return View();
        }

        public ActionResult login()
        {
            return View();
        }

        public ActionResult Grillas()
        {
            return View();
        }
        public ActionResult pruebas_d3js()
        {
            return View();
        }
        public ActionResult pruebas_autocompletar()
        {
            return View();
        }
        public ActionResult editarPerfil()
        {
            return View();
        }
        public ActionResult verPerfil()
        {
            return View();
        }
        public ActionResult MensajesNotificacion()
        {
            return View();
        }
        public ActionResult completarPerfil()
        {
            return View();
        }
        public ActionResult crearPublicaciones()
        {
            return View();
        }
        public ActionResult entidadesAgrupaciones()
        {
            return View();
        }
        public ActionResult grillaEntidades()
        {
            return View();
        }
        public ActionResult grillaParticipaciones()
        {
            return View();
        }
        public ActionResult grillaPublicaciones()
        {
            return View();
        }
        public ActionResult registrarse()
        {
            return View();
        }
        public ActionResult formulariosdinamicosAgregar()
        {
            return View();
        }
        public ActionResult formulariosdinamicosCampos()
        {
            return View();
        }
        public ActionResult formulariosdinamicosEditar()
        {
            return View();
        }
        public ActionResult formulariosdinamicosSeccion()
        {
            return View();
        }
        public ActionResult caracterizacion()
        {
            return View();
        }
        public ActionResult dashboard()
        {
            return View();
        }

        public ActionResult proximosEventos()
        {
            return View();
        }

        public ActionResult todoslosEventos()
        {
            return View();
        }
        public ActionResult caracterizacionEditar()
        {
            return View();
        }
        public ActionResult verFomulariosdinamicos()
        {
            return View();
        }
        



        public JsonResult GetD3(string departamento = null)
        {
            int[] array = { 10, 15, 26, 30, 8 };
            var data = array;
            return Json(data, JsonRequestBehavior.AllowGet);
        }
	}
}