using SM.Aplicacion.Escuelas;
using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebSImus.Models;
using WebSImus.Translator;

namespace WebSImus.Controllers
{
    /// <summary>
    /// Controlador API REST para gestionar Escuelas de Música.
    /// Expone endpoints para consultas públicas de escuelas registradas en el sistema SIMUS.
    /// NOTA: Este controlador está temporalmente simplificado debido a problemas con tablas faltantes en BD.
    /// </summary>
    [RoutePrefix("api/escuelas")]
    public class EscuelasApiController : ApiController
    {
        /// <summary>
        /// Obtiene todas las escuelas registradas en el sistema.
        /// NOTA TEMPORAL: Devuelve solo un mensaje indicando que se debe usar el endpoint específico por ID.
        /// </summary>
        /// <returns>Mensaje informativo</returns>
        /// <example>GET /api/escuelas</example>
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetEscuelas()
        {
            try
            {
                // NOTA: Esta implementación está temporalmente simplificada debido a que la tabla
                // ART_TIPOS_ESCUELAS no existe en la base de datos actual.
                // Para obtener una escuela específica, usa: GET /api/escuelas/{id}

                return Ok(new
                {
                    mensaje = "API de Escuelas disponible. Use GET /api/escuelas/{id} para obtener una escuela específica.",
                    endpointsDisponibles = new[]
                    {
                        "GET /api/escuelas/{id} - Obtiene una escuela por ID",
                        "GET /api/escuelas/{id}/practicas - Obtiene prácticas musicales",
                        "GET /api/escuelas/{id}/institucionalidad - Obtiene datos institucionales",
                        "GET /api/escuelas/{id}/formacion - Obtiene datos de formación"
                    }
                });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Obtiene una escuela específica por su ID.
        /// </summary>
        /// <param name="id">ID de la escuela</param>
        /// <returns>Información detallada de la escuela</returns>
        /// <example>GET /api/escuelas/123</example>
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetEscuela(int id)
        {
            try
            {
                Escuelas escuela = TranslatorEscuelas.CargarDatosBasicos(id);

                if (escuela == null || escuela.EscuelaId == 0)
                {
                    return NotFound();
                }

                return Ok(escuela);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Obtiene las prácticas musicales (instrumentos/áreas) de una escuela.
        /// </summary>
        /// <param name="id">ID de la escuela</param>
        /// <returns>Lista de prácticas musicales de la escuela</returns>
        /// <example>GET /api/escuelas/123/practicas</example>
        [HttpGet]
        [Route("{id:int}/practicas")]
        public IHttpActionResult GetPracticas(int id)
        {
            try
            {
                List<EstandarDTO> practicas = EscuelasLogica.ConsultarPracticaPorEscuela(id);
                return Ok(practicas);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Obtiene información de institucionalidad de una escuela.
        /// </summary>
        /// <param name="id">ID de la escuela</param>
        /// <returns>Datos institucionales de la escuela</returns>
        /// <example>GET /api/escuelas/123/institucionalidad</example>
        [HttpGet]
        [Route("{id:int}/institucionalidad")]
        public IHttpActionResult GetInstitucionalidad(int id)
        {
            try
            {
                Institucionalidad institucionalidad = TranslatorEscuelas.CargarInstitucionalidad(id);

                if (institucionalidad == null)
                {
                    return NotFound();
                }

                return Ok(institucionalidad);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Obtiene información de formación de una escuela.
        /// </summary>
        /// <param name="id">ID de la escuela</param>
        /// <returns>Datos de formación musical de la escuela</returns>
        /// <example>GET /api/escuelas/123/formacion</example>
        [HttpGet]
        [Route("{id:int}/formacion")]
        public IHttpActionResult GetFormacion(int id)
        {
            try
            {
                FormacionModel formacion = TranslatorEscuelas.CargarFormacion(id);

                if (formacion == null)
                {
                    return NotFound();
                }

                return Ok(formacion);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // NOTA: Los siguientes endpoints están temporalmente deshabilitados debido a problemas
        // con tablas faltantes en la base de datos (ART_TIPOS_ESCUELAS)

        /*
        /// <summary>
        /// Busca escuelas por nombre.
        /// </summary>
        [HttpGet]
        [Route("buscar")]
        public IHttpActionResult BuscarEscuelas([FromUri] string q)
        {
            return BadRequest("Este endpoint está temporalmente deshabilitado. Use GET /api/escuelas/{id} para obtener una escuela específica.");
        }

        /// <summary>
        /// Obtiene escuelas filtradas por departamento.
        /// </summary>
        [HttpGet]
        [Route("departamento/{departamento}")]
        public IHttpActionResult GetEscuelasPorDepartamento(string departamento)
        {
            return BadRequest("Este endpoint está temporalmente deshabilitado. Use GET /api/escuelas/{id} para obtener una escuela específica.");
        }
        */
    }
}
