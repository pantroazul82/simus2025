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
    public class CelebraMusicaGeoController : ApiController
    {
        // GET: api/CelebraMusicaGeo
        public HttpResponseMessage Get()
        {
            var celebra = new List<CelebraPorcentajeGeoDTO>();
            var resultado = new CelebraDataModels();
            EstructuraCelebraTematicooModels datos;
            string respuestadetalle = "";
            int Estado = 0;
            try
            {

                celebra = CelebraGeoNeg.ConsultarPorcentajeAvanceDepartamento(Utilidades.GetBaseUrl(),2017);
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
                datos = new EstructuraCelebraTematicooModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }
            catch
            {
                respuestadetalle = Constantes.Respuestas.Error;
                Estado = (int)enumEstado.Error;
                resultado = new CelebraDataModels();
                datos = new EstructuraCelebraTematicooModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }

            return Request.CreateResponse<EstructuraCelebraTematicooModels>(HttpStatusCode.OK, datos);

        }
        // GET: api/CelebraMusicaGeo/5
        public HttpResponseMessage Get(int id)
        {
            var celebra = new List<CelebraPorcentajeGeoDTO>();
            var resultado = new CelebraDataModels();
            EstructuraCelebraTematicooModels datos;
            string respuestadetalle = "";
            int Estado = 0;
            try
            {

                celebra = CelebraGeoNeg.ConsultarPorcentajeAvanceDepartamento(Utilidades.GetBaseUrl(), id);
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
                datos = new EstructuraCelebraTematicooModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }
            catch
            {
                respuestadetalle = Constantes.Respuestas.Error;
                Estado = (int)enumEstado.Error;
                resultado = new CelebraDataModels();
                datos = new EstructuraCelebraTematicooModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }

            return Request.CreateResponse<EstructuraCelebraTematicooModels>(HttpStatusCode.OK, datos);

        }

        // POST: api/CelebraMusicaGeo
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CelebraMusicaGeo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CelebraMusicaGeo/5
        public void Delete(int id)
        {
        }
    }
}
