using SM.Aplicacion.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebSImus.Areas.Mapas.Helps;
using WebSImus.Areas.Mapas.Models;
using WebSImus.Translator;

namespace WebSImus.Areas.Mapas.Controllers
{
    public class AgendaController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var eventos = new List<AgendaModels>();
            try
            {
                var resultado = UtilidadNeg.ConsultarEventosAgenda();
                eventos = TranslatorUtilidad.TranslatorUtilidadAgendaModel(resultado);

                if (eventos.Count > 0)
                {
                    // Estado = (int)enumEstado.Correcto; // Removed unused variable
                }
                else if (eventos.Count == 0)
                {
                    // Estado = (int)enumEstado.Vacio; // Removed unused variable
                }
            }
            catch
            {
                // Estado = (int)enumEstado.Error; // Removed unused variable
            }

            return Request.CreateResponse<List<AgendaModels>>(HttpStatusCode.OK, eventos);
        }
    }
}
