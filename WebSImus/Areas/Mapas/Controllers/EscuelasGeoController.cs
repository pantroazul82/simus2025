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
    public class EscuelasGeoController : ApiController
    {
        // GET: api/Escuelas

        public HttpResponseMessage Get()
        {
            var escuelas = new List<EscuelaGeoDTO>();
            var resultado = new EscuelasModels();
            EstructuraModels datos = new EstructuraModels();
            string respuestadetalle = "";
            int Estado = 0;
            try
            {
                escuelas = GeoNeg.ConsultarEscuelas(Utilidades.GetBaseUrl());
                resultado.Escuelas = escuelas;

                if (escuelas.Count > 0)
                {
                    respuestadetalle = Constantes.Respuestas.Correcta;
                    Estado = (int)enumEstado.Correcto;
                }
                else if (escuelas.Count == 0)
                {
                    respuestadetalle = Constantes.Respuestas.Vacio;
                    Estado = (int)enumEstado.Vacio;
                }
                datos = new EstructuraModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }
            catch
            {
                respuestadetalle = Constantes.Respuestas.Error;
                Estado = (int)enumEstado.Error;
                resultado = new EscuelasModels();
                datos = new EstructuraModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }

            return Request.CreateResponse<EstructuraModels>(HttpStatusCode.OK, datos);
 
        }



        // GET: api/Escuelas/5
          [Route("api/EscuelasGeo/{id}")]
        public HttpResponseMessage Get(string id)
        {
            var escuelas = new List<EscuelaGeoDTO>();
            var resultado = new EscuelasModels();
            EstructuraModels datos = new EstructuraModels();
            string respuestadetalle = "";
            int Estado = 0;
            try
            {
                escuelas = GeoNeg.ConsultarEscuelasPorCodigoMunicipio(Utilidades.GetBaseUrl(), id);
                resultado.Escuelas = escuelas;

                if (escuelas.Count > 0)
                {
                    respuestadetalle = Constantes.Respuestas.Correcta;
                    Estado = (int)enumEstado.Correcto;
                }
                else if (escuelas.Count == 0)
                {
                    respuestadetalle = Constantes.Respuestas.Vacio;
                    Estado = (int)enumEstado.Vacio;
                }
                datos = new EstructuraModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }
            catch
            {
                respuestadetalle = Constantes.Respuestas.Error;
                Estado = (int)enumEstado.Error;
                resultado = new EscuelasModels();
                datos = new EstructuraModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }

            return Request.CreateResponse<EstructuraModels>(HttpStatusCode.OK, datos);
 
        }

        // POST: api/Escuelas

        [Route("api/EscuelasGeo/{value}")]
        public HttpResponseMessage Post(string value)
        {
            var escuelas = new List<EscuelaGeoDTO>();
            var resultado = new EscuelasModels();
            EstructuraModels datos = new EstructuraModels();
            string respuestadetalle = "";
            int Estado = 0;
            try
            {
                escuelas = GeoNeg.ConsultarEscuelasPorCodigoMunicipio(Utilidades.GetBaseUrl(), value);
                resultado.Escuelas = escuelas;

                if (escuelas.Count > 0)
                {
                    respuestadetalle = Constantes.Respuestas.Correcta;
                    Estado = (int)enumEstado.Correcto;
                }
                else if (escuelas.Count == 0)
                {
                    respuestadetalle = Constantes.Respuestas.Vacio;
                    Estado = (int)enumEstado.Vacio;
                }
                datos = new EstructuraModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }
            catch
            {
                respuestadetalle = Constantes.Respuestas.Error;
                Estado = (int)enumEstado.Error;
                resultado = new EscuelasModels();
                datos = new EstructuraModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }

            return Request.CreateResponse<EstructuraModels>(HttpStatusCode.OK, datos);
 
        }

        // PUT: api/Escuelas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Escuelas/5
        public void Delete(int id)
        {
        }
    }
}
