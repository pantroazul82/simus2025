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
      [Route("api/EventoDepartamento/")]
    public class EventoDepartamentoController : ApiController
    {

          public HttpResponseMessage Post([FromBody]UsuarioModel model)
        {

            var resultado = new EventoWSModels();
            var datos = new WSEstructuraEventoModels();
            string respuestadetalle = "";
            int Estado = 0;
            List<WSEventoDTO> entidad = new List<WSEventoDTO>();
            try
            {
                string Mensaje = "";
                entidad = WSDepartamentoNeg.ConsultarWebApiEventos(model.usuario, model.contrasena, out Mensaje);
                resultado.Eventos = entidad;

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
                datos = new WSEstructuraEventoModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }
            catch
            {
                respuestadetalle = Constantes.Respuestas.Error;
                Estado = (int)enumEstado.Error;
                resultado = new EventoWSModels();
                datos = new WSEstructuraEventoModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }

            return Request.CreateResponse<WSEstructuraEventoModels>(HttpStatusCode.OK, datos);
        }
    }
}
