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
    public class EntidadesGeoController : ApiController
    {
        // GET: api/EntidadesGeo
        public HttpResponseMessage Get()
        {
            var entidad = new List<EntidadesGeoDTO>();
            var resultado = new EntidadModels();
            var datos = new EstructuraEntidadModels();
            string respuestadetalle = "";
            int Estado = 0;
            try
            {
                entidad = GeoNeg.ConsultarEntidades(Utilidades.GetBaseUrl());
                resultado.Entidades = entidad;

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
                datos = new EstructuraEntidadModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }
            catch
            {
                respuestadetalle = Constantes.Respuestas.Error;
                Estado = (int)enumEstado.Error;
                resultado = new EntidadModels();
                datos = new EstructuraEntidadModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }

            return Request.CreateResponse<EstructuraEntidadModels>(HttpStatusCode.OK, datos);
        }

        // GET: api/EntidadesGeo/5
        [Route("api/EntidadesGeo/{id}")]
        public HttpResponseMessage Get(string id)
        {
            var entidad = new List<EntidadesGeoDTO>();
            var resultado = new EntidadModels();
            var datos = new EstructuraEntidadModels();
            string respuestadetalle = "";
            int Estado = 0;
            try
            {
                entidad = GeoNeg.ConsultarEntidades(Utilidades.GetBaseUrl(), id);
                resultado.Entidades = entidad;

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
                datos = new EstructuraEntidadModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }
            catch
            {
                respuestadetalle = Constantes.Respuestas.Error;
                Estado = (int)enumEstado.Error;
                resultado = new EntidadModels();
                datos = new EstructuraEntidadModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }

            return Request.CreateResponse<EstructuraEntidadModels>(HttpStatusCode.OK, datos);
        }

        // POST: api/EntidadesGeo
        [Route("api/EntidadesGeo/{value}")]
        public HttpResponseMessage Post(string value)
        {
            var entidad = new List<EntidadesGeoDTO>();
            var resultado = new EntidadModels();
            var datos = new EstructuraEntidadModels();
            string respuestadetalle = "";
            int Estado = 0;
            try
            {
                entidad = GeoNeg.ConsultarEntidades(Utilidades.GetBaseUrl(), value);
                resultado.Entidades = entidad;

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
                datos = new EstructuraEntidadModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }
            catch
            {
                respuestadetalle = Constantes.Respuestas.Error;
                Estado = (int)enumEstado.Error;
                resultado = new EntidadModels();
                datos = new EstructuraEntidadModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }

            return Request.CreateResponse<EstructuraEntidadModels>(HttpStatusCode.OK, datos);
        }

        // PUT: api/EntidadesGeo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EntidadesGeo/5
        public void Delete(int id)
        {
        }
    }
}
