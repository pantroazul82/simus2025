using SM.Aplicacion.Geo;
using SM.LibreriaComun.DTO.GEO;
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
    public class CelebraGeoController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var celebra = new List<CelebraGeoDTO>();
            var resultado = new CelebraModels();
            EstructuraCelebraModels datos;
            string respuestadetalle = "";
            int Estado = 0;
            try
            {

                celebra = CelebraGeoNeg.ConsultarDatosCelebra(Utilidades.GetBaseUrl(), 2017);
                resultado.Celebra = celebra;
                if (celebra.Count > 0)
                {
                    respuestadetalle = Constantes.Respuestas.Correcta;
                    Estado = (int)enumEstado.Correcto;
                }
                else if (celebra.Count == 0)
                {
                    respuestadetalle = Constantes.Respuestas.Vacio;
                    Estado = (int)enumEstado.Vacio;
                }
                datos = new EstructuraCelebraModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }
            catch
            {
                respuestadetalle = Constantes.Respuestas.Error;
                Estado = (int)enumEstado.Error;
                resultado = new CelebraModels();
                datos = new EstructuraCelebraModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }

            return Request.CreateResponse<EstructuraCelebraModels>(HttpStatusCode.OK, datos);

        }
        // GET: api/CelebraGeo/5
        public HttpResponseMessage Get(int id)
        {
            var celebra = new List<CelebraGeoDTO>();
            var resultado = new CelebraModels();
            EstructuraCelebraModels datos;
            string respuestadetalle = "";
            int Estado = 0;
            try
            {

                celebra = CelebraGeoNeg.ConsultarDatosCelebra(Utilidades.GetBaseUrl(), id);
                resultado.Celebra = celebra;
                if (celebra.Count > 0)
                {
                    respuestadetalle = Constantes.Respuestas.Correcta;
                    Estado = (int)enumEstado.Correcto;
                }
                else if (celebra.Count == 0)
                {
                    respuestadetalle = Constantes.Respuestas.Vacio;
                    Estado = (int)enumEstado.Vacio;
                }
                datos = new EstructuraCelebraModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }
            catch
            {
                respuestadetalle = Constantes.Respuestas.Error;
                Estado = (int)enumEstado.Error;
                resultado = new CelebraModels();
                datos = new EstructuraCelebraModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }

            return Request.CreateResponse<EstructuraCelebraModels>(HttpStatusCode.OK, datos);
        }

        // POST: api/CelebraGeo
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CelebraGeo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CelebraGeo/5
        public void Delete(int id)
        {
        }
    }
}
