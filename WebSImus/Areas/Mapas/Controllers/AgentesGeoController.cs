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

namespace WebSImus.Areas.Mapas.Controllers
{
    public class AgentesGeoController : ApiController
    {
        // GET: api/AgentesGeo
        public HttpResponseMessage Get()
        {
            var agente = new List<AgentesDptoDTO>();
            var resultado = new AgenteModels();
            var datos = new EstructuraAgenteModels();
            string respuestadetalle = "";
            int Estado = 0;
            try
            {
                agente = GeoNeg.ConsultarAgentesPorDepartamento();
                resultado.Agentes = agente;

                if (agente.Count > 0)
                {
                    respuestadetalle = Constantes.Respuestas.Correcta;
                    Estado = (int)enumEstado.Correcto;
                }
                else if (agente.Count == 0)
                {
                    respuestadetalle = Constantes.Respuestas.Vacio;
                    Estado = (int)enumEstado.Vacio;
                }
                datos = new EstructuraAgenteModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }
            catch
            {
                respuestadetalle = Constantes.Respuestas.Error;
                Estado = (int)enumEstado.Error;
                resultado = new AgenteModels();
                datos = new EstructuraAgenteModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }

            return Request.CreateResponse<EstructuraAgenteModels>(HttpStatusCode.OK, datos);
        }

        // GET: api/AgentesGeo/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AgentesGeo
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AgentesGeo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AgentesGeo/5
        public void Delete(int id)
        {
        }
    }
}
