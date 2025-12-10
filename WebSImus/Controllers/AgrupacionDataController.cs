
using SM.Aplicacion.Agrupacion;
using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebSImus.Controllers
{
    /// <summary>
    /// Controlador API para gestionar las Agrupaciones.
    /// Este controlador responde a peticiones HTTP y devuelve datos en formato JSON.
    /// </summary>
    // [EnableCors(origins: "*", headers: "*", methods: "*")] // CORS se maneja globalmente en WebApiConfig.cs
    // [RoutePrefix("api/agrupacion")] // Eliminado para usar enrutamiento convencional
    [RoutePrefix("api/agrupaciondata")]
    public class AgrupacionDataController : ApiController
    {
        [HttpGet]
        [Route("")]
        /// <summary>
        /// Obtiene todas las agrupaciones asociadas a un ID de usuario.
        /// </summary>
        /// <param name="id">El ID del usuario.</param>
        /// <returns>Una lista de agrupaciones en formato JSON.</returns>
        // Ruta esperada: GET api/Agrupacion/{id}
        public IHttpActionResult Get()
        {
            try
            {
                // Old code:
                // List<AgrupacionDataDTO> agrupaciones = AgrupacionNeg.ConsultarAgrupacionPorUsuarioId(id);

                List<AgrupacionHomeDataDTO> agrupaciones = AgrupacionNeg.ConsultarAgrupacionHomeTodos();
                return Ok(agrupaciones);
            }
            catch (Exception ex)
            {
                // 3. Si algo sale mal, devolvemos un error 500 con el mensaje.
                // Es importante registrar este error en un sistema de logs.
                return InternalServerError(ex);
            }
        }

        // AQUÍ SE AÑADIRÍAN OTROS MÉTODOS (endpoints) PARA EL CRUD:
        
        // POST api/Agrupacion  (para crear una nueva agrupación)
        /*
        [HttpPost]
        public IHttpActionResult Post([FromBody] AgrupacionDTO nuevaAgrupacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            // Lógica para llamar a AgrupacionNeg.CrearAgrupacion(...)
            
            int nuevoId = AgrupacionNeg.CrearAgrupacion(nuevaAgrupacion, "UsuarioApi", Request.GetOwinContext().Request.RemoteIpAddress);

            return Created(new Uri(Request.RequestUri + "/" + nuevoId), new { AgrupacionId = nuevoId });
        }
        */
    }
}
