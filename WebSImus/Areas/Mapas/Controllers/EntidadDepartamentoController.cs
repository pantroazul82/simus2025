using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebSImus.Areas.Mapas.Models;
using WebSImus.Areas.Mapas.Helps;
using SM.LibreriaComun.DTO.WSDepartamento;
using SM.Aplicacion.Agrupacion;
using SM.Aplicacion.Departamento;


namespace WebSImus.Areas.Mapas.Controllers
{
       [Route("api/EntidadDepartamento/")]
    public class EntidadDepartamentoController : ApiController
    {
     
        [HttpPost]
        public HttpResponseMessage Post([FromBody]UsuarioModel model)
        {

            var resultado = new EntidadWSModels();
            var datos = new WSEstructuraEntidadModels();
            string respuestadetalle = "";
            int Estado = 0;
            List<WSEntidadDTO> entidad = new List<WSEntidadDTO>();
            try
            {
                string Mensaje = "";
                entidad = WSDepartamentoNeg.ConsultarWebApiEntidades(model.usuario, model.contrasena, out Mensaje);
                resultado.Entidades = entidad;

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
                datos = new WSEstructuraEntidadModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }
            catch
            {
                respuestadetalle = Constantes.Respuestas.Error;
                Estado = (int)enumEstado.Error;
                resultado = new EntidadWSModels();
                datos = new WSEstructuraEntidadModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }

            return Request.CreateResponse<WSEstructuraEntidadModels>(HttpStatusCode.OK, datos);
        }
    }
}
