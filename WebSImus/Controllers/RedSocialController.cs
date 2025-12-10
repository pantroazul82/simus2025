using SM.Aplicacion.RedSocial;
using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSImus.Controllers
{
    public class RedSocialController : Controller
    {

        public ActionResult Index()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Guardar(string facebook, string twitter, string instagram, string flick, string youtube, string sound, string registroId, string tipo)
        {
            var model = new List<RedSocialDTO>();

            model = SM.Aplicacion.RedSocial.RedSocialNeg.ObtenerRedSocial();

            foreach (var item in model)
            {
                if (item.Nombre == "Facebook")
                    item.valor = facebook;
                else if (item.Nombre == "Twitter")
                    item.valor = twitter;
                else if (item.Nombre == "Instagram")
                    item.valor = instagram;
                else if (item.Nombre == "flick")
                    item.valor = twitter;
                else if (item.Nombre == "Youtube")
                    item.valor = youtube;
                else if (item.Nombre == "Sound")
                    item.valor = sound;
                
            }

            if (tipo == "Agente")
                RedSocialNeg.InsertarRedesSocialAgente(model, Convert.ToInt32(registroId));
            else if (tipo == "Agrupacion")
                RedSocialNeg.InsertarRedesSocialAgrupacion(model, Convert.ToInt32(registroId));
            else if (tipo == "Entidad")
                RedSocialNeg.InsertarRedesSocialEntidad(model, Convert.ToInt32(registroId));

            return View();
        }

        public ActionResult _DatosRedes(string Id,string Tipo)
        {
            var model = new List<RedSocialDTO>();
            int RegstroId = Convert.ToInt32(Id);

            model = SM.Aplicacion.RedSocial.RedSocialNeg.ObtenerRedSocialporActor(RegstroId, Tipo);

            return PartialView("_DatosRedes", model);
        }

    }
}