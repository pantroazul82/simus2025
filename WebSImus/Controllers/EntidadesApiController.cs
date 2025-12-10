using SM.Aplicacion.Entidades;
using SM.Aplicacion.Basicas;
using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.Web.Http;
using WebSImus.Models;
using WebSImus.Translator;

namespace WebSImus.Controllers
{
    /// <summary>
    /// Controlador API REST para gestionar Entidades (organizaciones culturales).
    /// Expone endpoints para consultas públicas de entidades registradas en el sistema SIMUS.
    /// </summary>
    [RoutePrefix("api/entidades")]
    public class EntidadesApiController : ApiController
    {
        /// <summary>
        /// Obtiene todas las entidades publicadas (estado aprobado).
        /// </summary>
        /// <returns>Lista de entidades con información básica</returns>
        /// <example>GET /api/entidades</example>
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetEntidades()
        {
            try
            {
                // Estado 3 = Publicado (ajustar según tu BD)
                int estadoPublicado = 3;
                List<EntidadDatosModels> entidades = TranslatorEntidades.ConsultarEntidadPorEstado(estadoPublicado);
                return Ok(entidades);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Obtiene una entidad específica por su ID.
        /// </summary>
        /// <param name="id">ID de la entidad</param>
        /// <returns>Información detallada de la entidad</returns>
        /// <example>GET /api/entidades/123</example>
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetEntidad(int id)
        {
            try
            {
                EntidadDatosModels entidad = TranslatorEntidades.ConsultarDatosEntidadPorId(id);

                if (entidad == null)
                {
                    return NotFound();
                }

                return Ok(entidad);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Obtiene los tipos de entidad asociados a una entidad específica.
        /// </summary>
        /// <param name="id">ID de la entidad</param>
        /// <returns>Lista de tipos de entidad</returns>
        /// <example>GET /api/entidades/123/tipos</example>
        [HttpGet]
        [Route("{id:int}/tipos")]
        public IHttpActionResult GetTiposEntidad(int id)
        {
            try
            {
                List<EstandarDTO> tipos = CaracterizacionMusicalNeg.ConsultarTipoEntidadSeleccionada(id);
                return Ok(tipos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // NOTA: Este endpoint está comentado porque la funcionalidad de escenarios no está implementada
        // Si necesitas esta funcionalidad, debes implementar la lógica en la capa de negocio
        /*
        /// <summary>
        /// Obtiene los escenarios asociados a una entidad.
        /// </summary>
        /// <param name="id">ID de la entidad</param>
        /// <returns>Lista de escenarios de la entidad</returns>
        /// <example>GET /api/entidades/123/escenarios</example>
        [HttpGet]
        [Route("{id:int}/escenarios")]
        public IHttpActionResult GetEscenarios(int id)
        {
            try
            {
                // TODO: Implementar ConsultarEscenarioPorEntidadId en la capa de negocio
                // List<EscenarioDTO> escenarios = EscenarioNeg.ConsultarEscenarioPorEntidadId(id);
                // return Ok(escenarios);
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        */

        /// <summary>
        /// Busca entidades por nombre o NIT.
        /// </summary>
        /// <param name="q">Término de búsqueda (nombre o NIT)</param>
        /// <returns>Lista de entidades que coinciden con la búsqueda</returns>
        /// <example>GET /api/entidades/buscar?q=Fundación</example>
        [HttpGet]
        [Route("buscar")]
        public IHttpActionResult BuscarEntidades([FromUri] string q)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(q))
                {
                    return BadRequest("El parámetro de búsqueda 'q' es requerido");
                }

                // Obtener todas las entidades publicadas y filtrar
                int estadoPublicado = 3;
                List<EntidadDatosModels> entidades = TranslatorEntidades.ConsultarEntidadPorEstado(estadoPublicado);

                var resultado = entidades.FindAll(e =>
                    (e.Nombre != null && e.Nombre.ToLower().Contains(q.ToLower())) ||
                    (e.Nit != null && e.Nit.ToString().Contains(q))
                );

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Obtiene entidades filtradas por departamento.
        /// </summary>
        /// <param name="departamento">Nombre del departamento</param>
        /// <returns>Lista de entidades del departamento especificado</returns>
        /// <example>GET /api/entidades/departamento/Cundinamarca</example>
        [HttpGet]
        [Route("departamento/{departamento}")]
        public IHttpActionResult GetEntidadesPorDepartamento(string departamento)
        {
            try
            {
                int estadoPublicado = 3;
                List<EntidadDatosModels> entidades = TranslatorEntidades.ConsultarEntidadPorEstado(estadoPublicado);

                var resultado = entidades.FindAll(e =>
                    e.Departamento != null && e.Departamento.ToLower() == departamento.ToLower()
                );

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Obtiene entidades filtradas por naturaleza (pública/privada).
        /// </summary>
        /// <param name="naturaleza">Naturaleza de la entidad</param>
        /// <returns>Lista de entidades de la naturaleza especificada</returns>
        /// <example>GET /api/entidades/naturaleza/Pública</example>
        [HttpGet]
        [Route("naturaleza/{naturaleza}")]
        public IHttpActionResult GetEntidadesPorNaturaleza(string naturaleza)
        {
            try
            {
                int estadoPublicado = 3;
                List<EntidadDatosModels> entidades = TranslatorEntidades.ConsultarEntidadPorEstado(estadoPublicado);

                var resultado = entidades.FindAll(e =>
                    e.Naturaleza != null && e.Naturaleza.ToLower() == naturaleza.ToLower()
                );

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
