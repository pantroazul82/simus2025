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
    public class PatGeoController : ApiController
    {
        // GET: api/PatGeo
        public HttpResponseMessage Get()
        {
            var patrimonio = new List<PatGeoDTO>();
            var resultado = new PatModels();
            var datos = new PatEstructuraModels();
            string respuestadetalle = "";
            int Estado = 0;
            try
            {
                patrimonio = PatNeg.ConsultarInmuebles();
                resultado.Inmuebles = patrimonio;

                if (patrimonio.Count > 0)
                {
                    respuestadetalle = Constantes.Respuestas.Correcta;
                    Estado = (int)enumEstado.Correcto;
                }
                else if (patrimonio.Count == 0)
                {
                    respuestadetalle = Constantes.Respuestas.Vacio;
                    Estado = (int)enumEstado.Vacio;
                }
                datos = new PatEstructuraModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }
            catch
            {
                respuestadetalle = Constantes.Respuestas.Error;
                Estado = (int)enumEstado.Error;
                resultado = new PatModels();
                datos = new PatEstructuraModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }

            return Request.CreateResponse<PatEstructuraModels>(HttpStatusCode.OK, datos);

        }

        // GET: api/PatGeo/5
          [Route("api/PatGeo/{id}")]
        public HttpResponseMessage Get(string id)
        {
            var patrimonio = new List<PatGeoDTO>();
            var resultado = new PatModels();
            var datos = new PatEstructuraModels();
            string respuestadetalle = "";
            int Estado = 0;
            try
            {
                patrimonio = PatNeg.ConsultarInmueblesPorCodigoMunicipio(id);
                resultado.Inmuebles = patrimonio;

                if (patrimonio.Count > 0)
                {
                    respuestadetalle = Constantes.Respuestas.Correcta;
                    Estado = (int)enumEstado.Correcto;
                }
                else if (patrimonio.Count == 0)
                {
                    respuestadetalle = Constantes.Respuestas.Vacio;
                    Estado = (int)enumEstado.Vacio;
                }
                datos = new PatEstructuraModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }
            catch
            {
                respuestadetalle = Constantes.Respuestas.Error;
                Estado = (int)enumEstado.Error;
                resultado = new PatModels();
                datos = new PatEstructuraModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }

            return Request.CreateResponse<PatEstructuraModels>(HttpStatusCode.OK, datos);

        }

        // POST: api/PatGeo
          [Route("api/PatGeo/{value}")]
        public HttpResponseMessage Post(string value)
        {
            var patrimonio = new List<PatGeoDTO>();
            var resultado = new PatModels();
            var datos = new PatEstructuraModels();
            string respuestadetalle = "";
            int Estado = 0;
            try
            {
                patrimonio = PatNeg.ConsultarInmueblesPorCodigoMunicipio(value);
                resultado.Inmuebles = patrimonio;

                if (patrimonio.Count > 0)
                {
                    respuestadetalle = Constantes.Respuestas.Correcta;
                    Estado = (int)enumEstado.Correcto;
                }
                else if (patrimonio.Count == 0)
                {
                    respuestadetalle = Constantes.Respuestas.Vacio;
                    Estado = (int)enumEstado.Vacio;
                }
                datos = new PatEstructuraModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }
            catch
            {
                respuestadetalle = Constantes.Respuestas.Error;
                Estado = (int)enumEstado.Error;
                resultado = new PatModels();
                datos = new PatEstructuraModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }

            return Request.CreateResponse<PatEstructuraModels>(HttpStatusCode.OK, datos);
        }

        // PUT: api/PatGeo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PatGeo/5
        public void Delete(int id)
        {
        }
    }
}
