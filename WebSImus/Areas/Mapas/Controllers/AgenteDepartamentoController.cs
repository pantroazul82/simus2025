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
      [Route("api/AgenteDepartamento/")]
    public class AgenteDepartamentoController : ApiController
    {

          public HttpResponseMessage Post([FromBody]UsuarioModel model)
        {

            var resultado = new AgenteWSModels();
            var datos = new WSEstructuraAgenteModels();
            string respuestadetalle = "";
            int Estado = 0;
            List<AgenteWSDTO> entidad = new List<AgenteWSDTO>();
            try
            {
                string Mensaje = "";
                entidad = WSDepartamentoNeg.ConsultarWebApiAgentes(model.usuario, model.contrasena, out Mensaje);
                resultado.Agentes = entidad;

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
                datos = new WSEstructuraAgenteModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }
            catch
            {
                respuestadetalle = Constantes.Respuestas.Error;
                Estado = (int)enumEstado.Error;
                resultado = new AgenteWSModels();
                datos = new WSEstructuraAgenteModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }

            return Request.CreateResponse<WSEstructuraAgenteModels>(HttpStatusCode.OK, datos);
        }

    }
}
