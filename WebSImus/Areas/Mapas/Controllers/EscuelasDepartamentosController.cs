using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebSImus.Areas.Mapas.Models;
using WebSImus.Areas.Mapas.Helps;
using SM.LibreriaComun.DTO.WSDepartamento;
using SM.Aplicacion.Departamento;

namespace WebSImus.Areas.Mapas.Controllers
{
    [Route("api/EscuelasDepartamentos/")]
    public class EscuelasDepartamentosController : ApiController
    {
       
        public HttpResponseMessage Post([FromBody]UsuarioModel model)
        {

            var resultado = new EscuelasWSModels();
            var datos = new WSEstructuraEscuelaModels();
            string respuestadetalle = "";
            int Estado = 0;
            List<WSEscuelaDTO> entidad = new List<WSEscuelaDTO>();
            try
            {
                string Mensaje = "";
                entidad = WSDepartamentoNeg.ConsultarWebApiEscuelas(model.usuario, model.contrasena, out Mensaje);
                resultado.Escuelas = entidad;

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
                datos = new WSEstructuraEscuelaModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }
            catch
            {
                respuestadetalle = Constantes.Respuestas.Error;
                Estado = (int)enumEstado.Error;
                resultado = new EscuelasWSModels();
                datos = new WSEstructuraEscuelaModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }

            return Request.CreateResponse<WSEstructuraEscuelaModels>(HttpStatusCode.OK, datos);
        }
    }
}
