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
    public class AgrupacionesGeoController : ApiController
    {
        // GET: api/AgrupacionesGeo
        public HttpResponseMessage Get()
        {
            var entidad = new List<EntidadesGeoDTO>();
            var resultado = new AgrupacionModels();
            var datos = new EstructuraAgrupacionModel();
            string respuestadetalle = "";
            int Estado = 0;
            try
            {
                entidad = GeoNeg.ConsultarAgrupaciones(Utilidades.GetBaseUrl());
                resultado.Agrupaciones = entidad;

                if (entidad.Count > 0)
                {
                    respuestadetalle = Constantes.Respuestas.Correcta;
                    Estado = (int)enumEstado.Correcto;
                }
                else if (entidad.Count == 0)
                {
                    respuestadetalle = Constantes.Respuestas.Vacio;
                    Estado = (int)enumEstado.Vacio;
                }
                datos = new EstructuraAgrupacionModel() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }
            catch
            {
                respuestadetalle = Constantes.Respuestas.Error;
                Estado = (int)enumEstado.Error;
                resultado = new AgrupacionModels();
                datos = new EstructuraAgrupacionModel() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }

            return Request.CreateResponse<EstructuraAgrupacionModel>(HttpStatusCode.OK, datos);
        }

        // GET: api/AgrupacionesGeo/5
          [Route("api/AgrupacionesGeo/{id}")]
        public HttpResponseMessage Get(string id)
        {
            var entidad = new List<EntidadesGeoDTO>();
            var resultado = new AgrupacionModels();
            var datos = new EstructuraAgrupacionModel();
            string respuestadetalle = "";
            int Estado = 0;
            try
            {
                entidad = GeoNeg.ConsultarAgrupaciones(Utilidades.GetBaseUrl(),id);
                resultado.Agrupaciones = entidad;

                if (entidad.Count > 0)
                {
                    respuestadetalle = Constantes.Respuestas.Correcta;
                    Estado = (int)enumEstado.Correcto;
                }
                else if (entidad.Count == 0)
                {
                    respuestadetalle = Constantes.Respuestas.Vacio;
                    Estado = (int)enumEstado.Vacio;
                }
                datos = new EstructuraAgrupacionModel() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }
            catch
            {
                respuestadetalle = Constantes.Respuestas.Error;
                Estado = (int)enumEstado.Error;
                resultado = new AgrupacionModels();
                datos = new EstructuraAgrupacionModel() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }

            return Request.CreateResponse<EstructuraAgrupacionModel>(HttpStatusCode.OK, datos);
        }

    
           [Route("api/AgrupacionesGeo/{value}")]
        public HttpResponseMessage Post(string value)
        {
            var entidad = new List<EntidadesGeoDTO>();
            var resultado = new AgrupacionModels();
            var datos = new EstructuraAgrupacionModel();
            string respuestadetalle = "";
            int Estado = 0;
            try
            {
                entidad = GeoNeg.ConsultarAgrupaciones(Utilidades.GetBaseUrl(), value);
                resultado.Agrupaciones = entidad;

                if (entidad.Count > 0)
                {
                    respuestadetalle = Constantes.Respuestas.Correcta;
                    Estado = (int)enumEstado.Correcto;
                }
                else if (entidad.Count == 0)
                {
                    respuestadetalle = Constantes.Respuestas.Vacio;
                    Estado = (int)enumEstado.Vacio;
                }
                datos = new EstructuraAgrupacionModel() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }
            catch
            {
                respuestadetalle = Constantes.Respuestas.Error;
                Estado = (int)enumEstado.Error;
                resultado = new AgrupacionModels();
                datos = new EstructuraAgrupacionModel() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }

            return Request.CreateResponse<EstructuraAgrupacionModel>(HttpStatusCode.OK, datos);
        }

        // PUT: api/AgrupacionesGeo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AgrupacionesGeo/5
        public void Delete(int id)
        {
        }
    }
}
