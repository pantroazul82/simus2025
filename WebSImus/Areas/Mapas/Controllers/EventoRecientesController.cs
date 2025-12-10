using SM.Aplicacion.Eventos;
using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebSImus.Areas.Mapas.Helps;
using WebSImus.Areas.Mapas.Models;

namespace WebSImus.Areas.Mapas.Controllers
{
    public class EventoRecientesController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var eventos = new List<ConciertosRecientesDTO>();
            var resultado = new EventoModels();
            var datos = new EstructuraEventoRecienteModels();
            string respuestadetalle = "";
            int Estado = 0;
            try
            {

                eventos = EventosNeg.ConsultarUltimosConciertosCreados(2018);
              
                if (eventos.Count > 0)
                {
                    respuestadetalle = Constantes.Respuestas.Correcta;
                    Estado = (int)enumEstado.Correcto;
                }
                else if (eventos.Count == 0)
                {
                    respuestadetalle = Constantes.Respuestas.Vacio;
                    Estado = (int)enumEstado.Vacio;
                }
                datos = new EstructuraEventoRecienteModels() { data = eventos, responseDetails = respuestadetalle, responseStatus = Estado };
            }
            catch
            {
                respuestadetalle = Constantes.Respuestas.Error;
                Estado = (int)enumEstado.Error;
                eventos = new List<ConciertosRecientesDTO>();
                datos = new EstructuraEventoRecienteModels() { data = eventos, responseDetails = respuestadetalle, responseStatus = Estado };
            }

            return Request.CreateResponse<EstructuraEventoRecienteModels>(HttpStatusCode.OK, datos);

        }
    }
}
