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
    public class EscuelaDepartamentoController : ApiController
    {
        // GET: api/EscuelaDepartamento
        public HttpResponseMessage Get()
        {
            var escuelas = new List<EscuelaDepartamentoDTO>();
            var resultado = new EscuelaDataModels();
            EscuelaTematicoModel datos;
            string respuestadetalle = "";
            int Estado = 0;
            try
            {

                escuelas = GeoNeg.ConsultarEscuelasPorDepartamento(Utilidades.GetBaseUrl());
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
                datos = new EscuelaTematicoModel() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }
            catch
            {
                respuestadetalle = Constantes.Respuestas.Error;
                Estado = (int)enumEstado.Error;
                resultado = new EscuelaDataModels();
                datos = new EscuelaTematicoModel() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }

            return Request.CreateResponse<EscuelaTematicoModel>(HttpStatusCode.OK, datos);
        }

        // GET: api/EscuelaDepartamento/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/EscuelaDepartamento
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/EscuelaDepartamento/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EscuelaDepartamento/5
        public void Delete(int id)
        {
        }
    }
}
