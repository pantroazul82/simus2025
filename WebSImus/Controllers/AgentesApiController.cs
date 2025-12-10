using SM.Aplicacion.Agentes;
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
    /// Controlador API REST para gestionar Agentes (Artistas/Músicos).
    /// Expone endpoints para consultas públicas de agentes registrados en el sistema.
    /// </summary>
    [RoutePrefix("api/agentes")]
    public class AgentesApiController : ApiController
    {
        /// <summary>
        /// Obtiene todos los agentes publicados (estado aprobado).
        /// </summary>
        /// <returns>Lista de agentes con información pública</returns>
        /// <example>GET /api/agentes</example>
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAgentes()
        {
            try
            {
                // Código de estado "Publicado" - consulta solo agentes aprobados
                int estadoPublicado = 3; // Ajustar según tu BD
                List<AgentePublicoModels> agentes = TranslatorAgentes.ConsultarAgentesPorEstadoId(estadoPublicado);
                return Ok(agentes);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Obtiene un agente específico por su ID.
        /// </summary>
        /// <param name="id">ID del agente</param>
        /// <returns>Información detallada del agente</returns>
        /// <example>GET /api/agentes/123</example>
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetAgente(int id)
        {
            try
            {
                AgentePublicoModels agente = TranslatorAgentes.ConsultarDatosAgentePorId(id);

                if (agente == null)
                {
                    return NotFound();
                }

                return Ok(agente);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Obtiene las ocupaciones (oficios musicales) de un agente específico.
        /// </summary>
        /// <param name="id">ID del agente</param>
        /// <returns>Lista de ocupaciones del agente</returns>
        /// <example>GET /api/agentes/123/ocupaciones</example>
        [HttpGet]
        [Route("{id:int}/ocupaciones")]
        public IHttpActionResult GetOcupaciones(int id)
        {
            try
            {
                List<OcupacionDTO> ocupaciones = AgentesNeg.ConsultarOcupacionPorAgenteId(id);
                return Ok(ocupaciones);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Obtiene los servicios ofrecidos por un agente.
        /// </summary>
        /// <param name="id">ID del agente</param>
        /// <returns>Lista de servicios del agente</returns>
        /// <example>GET /api/agentes/123/servicios</example>
        [HttpGet]
        [Route("{id:int}/servicios")]
        public IHttpActionResult GetServicios(int id)
        {
            try
            {
                List<EstandarDTO> servicios = AgentesNeg.ConsultarServicioPorAgenteId(id);
                return Ok(servicios);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Busca agentes por nombre o criterios específicos.
        /// </summary>
        /// <param name="q">Término de búsqueda</param>
        /// <returns>Lista de agentes que coinciden con la búsqueda</returns>
        /// <example>GET /api/agentes/buscar?q=Juan</example>
        [HttpGet]
        [Route("buscar")]
        public IHttpActionResult BuscarAgentes([FromUri] string q)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(q))
                {
                    return BadRequest("El parámetro de búsqueda 'q' es requerido");
                }

                // Obtener todos los agentes y filtrar por nombre
                int estadoPublicado = 3;
                List<AgentePublicoModels> agentes = TranslatorAgentes.ConsultarAgentesPorEstadoId(estadoPublicado);

                // Filtrar por nombre completo, nombres o apellidos
                var resultado = agentes.FindAll(a =>
                    (a.NombreCompleto != null && a.NombreCompleto.ToLower().Contains(q.ToLower())) ||
                    (a.Nombres != null && a.Nombres.ToLower().Contains(q.ToLower())) ||
                    (a.Apellidos != null && a.Apellidos.ToLower().Contains(q.ToLower()))
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
