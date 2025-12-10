using Newtonsoft.Json.Linq;
using SM.Aplicacion.Geo;
using SM.LibreriaComun.DTO.GEO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using WebSImus.Areas.Mapas.Models;
using WebSImus.Areas.Mapas.Helps;
using SM.Aplicacion.Servicios;

namespace WebSImus.Areas.Mapas.Controllers
{
    public class EventosGeoController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var eventos = new List<EventosGeoDTO>();
            var resultado = new EventoModels();
            var datos = new EstructuraEventoModels();
            string respuestadetalle = "";
            int Estado = 0;
            try
            {
                int TipoUtilidadId = ConvocatoriaNeg.ObtenerId(Comunes.ConstantesRecursosBD.NOMBRE_UTILIDAD_EVENTO);
                eventos = UtilidadNeg.ConsultarEventosGeo(Utilidades.GetBaseUrl(), TipoUtilidadId);
                resultado.eventos = eventos;

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
                datos = new EstructuraEventoModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }
            catch
            {
                respuestadetalle = Constantes.Respuestas.Error;
                Estado = (int)enumEstado.Error;
                resultado = new EventoModels();
                datos = new EstructuraEventoModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }

            return Request.CreateResponse<EstructuraEventoModels>(HttpStatusCode.OK, datos);

        }



        // GET: api/Escuelas/5
        [Route("api/EscuelasGeo/{id}")]
        public HttpResponseMessage Get(string id)
        {
            var eventos = new List<EventosGeoDTO>();
            var resultado = new EventoModels();
            var datos = new EstructuraEventoModels();
            string respuestadetalle = "";
            int Estado = 0;
            try
            {
                int TipoUtilidadId = ConvocatoriaNeg.ObtenerId(Comunes.ConstantesRecursosBD.NOMBRE_UTILIDAD_EVENTO);
                eventos = UtilidadNeg.ConsultarEventosGeoPorMunicipio(Utilidades.GetBaseUrl(), TipoUtilidadId, id);
                resultado.eventos = eventos;

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
                datos = new EstructuraEventoModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }
            catch
            {
                respuestadetalle = Constantes.Respuestas.Error;
                Estado = (int)enumEstado.Error;
                resultado = new EventoModels();
                datos = new EstructuraEventoModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }

            return Request.CreateResponse<EstructuraEventoModels>(HttpStatusCode.OK, datos);

        }

        // POST: api/Escuelas

        [Route("api/EscuelasGeo/{value}")]
        public HttpResponseMessage Post(string value)
        {
            var eventos = new List<EventosGeoDTO>();
            var resultado = new EventoModels();
            var datos = new EstructuraEventoModels();
            string respuestadetalle = "";
            int Estado = 0;
            try
            {
                int TipoUtilidadId = ConvocatoriaNeg.ObtenerId(Comunes.ConstantesRecursosBD.NOMBRE_UTILIDAD_EVENTO);
                eventos = UtilidadNeg.ConsultarEventosGeoPorMunicipio(Utilidades.GetBaseUrl(), TipoUtilidadId, value);
                resultado.eventos = eventos;

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
                datos = new EstructuraEventoModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }
            catch
            {
                respuestadetalle = Constantes.Respuestas.Error;
                Estado = (int)enumEstado.Error;
                resultado = new EventoModels();
                datos = new EstructuraEventoModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }

            return Request.CreateResponse<EstructuraEventoModels>(HttpStatusCode.OK, datos);

        }
    }
}
