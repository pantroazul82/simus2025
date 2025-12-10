using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebSImus.Areas.Mapas.Models;
using WebSImus.Areas.Mapas.Helps;
using SM.LibreriaComun.DTO.WSDepartamento;
using SM.Aplicacion.Agrupacion;

namespace WebSImus.Areas.Mapas.Controllers
{
    [Route("api/EscenarioDepartamento/")]
    public class EscenarioDepartamentoController : ApiController
    {
        
        public HttpResponseMessage Post([FromBody]UsuarioModel model)
        {

            var resultado = new EscenarioWSModels();
            var datos = new WSEstructuraEscenarioModels();
            string respuestadetalle = "";
            int Estado = 0;
            List<AgrupacionWSDTO> entidad = new List<AgrupacionWSDTO>();
            try
            {
                string Mensaje = "";
                entidad = AgrupacionNeg.ConsultarWebApiAgrupaciones(model.usuario, model.contrasena, out Mensaje);
                resultado.Escenarios = entidad;

                if (entidad.Count > 0)
                {
                    respuestadetalle = Constantes.Respuestas.Correcta;
                    Estado = (int)enumEstado.Correcto;
                }
                else if (entidad.Count == 0)
                {
                    if (string.IsNullOrEmpty(Mensaje))
                        respuestadetalle = Constantes.Respuestas.Vacio;
                    else
                        respuestadetalle = Mensaje;
                    Estado = (int)enumEstado.Vacio;
                }
                datos = new WSEstructuraEscenarioModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }
            catch
            {
                respuestadetalle = Constantes.Respuestas.Error;
                Estado = (int)enumEstado.Error;
                resultado = new EscenarioWSModels();
                datos = new WSEstructuraEscenarioModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }

            return Request.CreateResponse<WSEstructuraEscenarioModels>(HttpStatusCode.OK, datos);
        }
    }
}
