using SM.Aplicacion.Eventos;
using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.Web.Http;
using WebSImus.Models;
using WebSImus.Translator;

namespace WebSImus.Controllers
{
    /// <summary>
    /// Controlador API REST para gestionar Eventos Musicales y de Danza.
    /// Expone endpoints para consultas públicas de eventos registrados en el sistema SIMUS.
    /// </summary>
    [RoutePrefix("api/eventos")]
    public class EventosApiController : ApiController
    {
        /// <summary>
        /// Obtiene todos los eventos de un tipo específico.
        /// </summary>
        /// <param name="tipo">Tipo de evento (Música/Danza)</param>
        /// <param name="ano">Año del evento (opcional)</param>
        /// <returns>Lista de eventos del tipo especificado</returns>
        /// <example>GET /api/eventos?tipo=Música&ano=2024</example>
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetEventos([FromUri] string tipo = "Música", [FromUri] int? ano = null)
        {
            try
            {
                int filtroAno = ano ?? DateTime.Now.Year;
                List<EventoDataModels> eventos = TranslatorEventos.ConsultarEventosTodosPorTipo(tipo, filtroAno);
                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Obtiene un evento específico por su ID.
        /// </summary>
        /// <param name="id">ID del evento</param>
        /// <returns>Información detallada del evento</returns>
        /// <example>GET /api/eventos/123</example>
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetEvento(int id)
        {
            try
            {
                EventoModels evento = TranslatorEventos.ConsultaEventoPorId(id);

                if (evento == null)
                {
                    return NotFound();
                }

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Obtiene la programación de conciertos de música por año y municipio.
        /// </summary>
        /// <param name="ano">Año del evento</param>
        /// <param name="municipio">Código del municipio (opcional)</param>
        /// <returns>Lista de conciertos programados</returns>
        /// <example>GET /api/eventos/conciertos?ano=2024</example>
        [HttpGet]
        [Route("conciertos")]
        public IHttpActionResult GetConciertos([FromUri] int ano, [FromUri] string municipio = "")
        {
            try
            {
                List<EventoPadreModels> conciertos = TranslatorEventos.ConsultarProgramacionConciertosMusica(
                    ano.ToString(),
                    municipio
                );
                return Ok(conciertos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Obtiene los artistas asociados a un evento.
        /// </summary>
        /// <param name="id">ID del evento</param>
        /// <returns>Lista de artistas del evento</returns>
        /// <example>GET /api/eventos/123/artistas</example>
        [HttpGet]
        [Route("{id:int}/artistas")]
        public IHttpActionResult GetArtistas(int id)
        {
            try
            {
                List<ArtistaPublicoModels> artistas = TranslatorEventos.ConsultaArtistasPorEventoId(id);
                return Ok(artistas);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Obtiene los grupos asociados a un evento.
        /// </summary>
        /// <param name="id">ID del evento</param>
        /// <returns>Lista de grupos del evento</returns>
        /// <example>GET /api/eventos/123/grupos</example>
        [HttpGet]
        [Route("{id:int}/grupos")]
        public IHttpActionResult GetGrupos(int id)
        {
            try
            {
                List<GrupoPublicoModels> grupos = TranslatorEventos.ConsultarGruposPorEventoId(id);
                return Ok(grupos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Obtiene eventos filtrados por departamento.
        /// </summary>
        /// <param name="departamento">Código del departamento</param>
        /// <param name="ano">Año del evento</param>
        /// <param name="tipo">Tipo de evento (Música/Danza)</param>
        /// <returns>Lista de eventos del departamento</returns>
        /// <example>GET /api/eventos/departamento/05?ano=2024</example>
        [HttpGet]
        [Route("departamento/{departamento}")]
        public IHttpActionResult GetEventosPorDepartamento(
            string departamento,
            [FromUri] int? ano = null,
            [FromUri] string tipo = "Música")
        {
            try
            {
                int filtroAno = ano ?? DateTime.Now.Year;
                List<EventoDataModels> eventos = TranslatorEventos.ConsultarEventosTodosPorTipo(tipo, filtroAno);

                var resultado = eventos.FindAll(e =>
                    e.CodDepartamento != null && e.CodDepartamento == departamento
                );

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Obtiene eventos filtrados por municipio.
        /// </summary>
        /// <param name="municipio">Código del municipio</param>
        /// <param name="ano">Año del evento</param>
        /// <param name="tipo">Tipo de evento (Música/Danza)</param>
        /// <returns>Lista de eventos del municipio</returns>
        /// <example>GET /api/eventos/municipio/05001?ano=2024</example>
        [HttpGet]
        [Route("municipio/{municipio}")]
        public IHttpActionResult GetEventosPorMunicipio(
            string municipio,
            [FromUri] int? ano = null,
            [FromUri] string tipo = "Música")
        {
            try
            {
                int filtroAno = ano ?? DateTime.Now.Year;
                List<EventoDataModels> eventos = TranslatorEventos.ConsultarEventosTodosPorTipo(tipo, filtroAno);

                var resultado = eventos.FindAll(e =>
                    e.CodMunicipio != null && e.CodMunicipio == municipio
                );

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Obtiene eventos destacados.
        /// </summary>
        /// <param name="tipo">Tipo de evento (Música/Danza)</param>
        /// <param name="ano">Año del evento</param>
        /// <returns>Lista de eventos destacados</returns>
        /// <example>GET /api/eventos/destacados?tipo=Música&ano=2024</example>
        [HttpGet]
        [Route("destacados")]
        public IHttpActionResult GetEventosDestacados(
            [FromUri] string tipo = "Música",
            [FromUri] int? ano = null)
        {
            try
            {
                int filtroAno = ano ?? DateTime.Now.Year;
                List<EventoDataModels> eventos = TranslatorEventos.ConsultarEventosTodosPorTipo(tipo, filtroAno);

                // Filtrar solo eventos destacados (si tienen esta propiedad)
                // Ajustar según la propiedad exacta en tu modelo
                var resultado = eventos.FindAll(e => e.EventoId > 0); // Placeholder - ajustar según necesidad

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Busca eventos por nombre o entidad organizadora.
        /// </summary>
        /// <param name="q">Término de búsqueda</param>
        /// <param name="tipo">Tipo de evento (Música/Danza)</param>
        /// <param name="ano">Año del evento</param>
        /// <returns>Lista de eventos que coinciden con la búsqueda</returns>
        /// <example>GET /api/eventos/buscar?q=Festival&tipo=Música&ano=2024</example>
        [HttpGet]
        [Route("buscar")]
        public IHttpActionResult BuscarEventos(
            [FromUri] string q,
            [FromUri] string tipo = "Música",
            [FromUri] int? ano = null)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(q))
                {
                    return BadRequest("El parámetro de búsqueda 'q' es requerido");
                }

                int filtroAno = ano ?? DateTime.Now.Year;
                List<EventoDataModels> eventos = TranslatorEventos.ConsultarEventosTodosPorTipo(tipo, filtroAno);

                var resultado = eventos.FindAll(e =>
                    (e.Nombre != null && e.Nombre.ToLower().Contains(q.ToLower())) ||
                    (e.EntidadOrganizadora != null && e.EntidadOrganizadora.ToLower().Contains(q.ToLower()))
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
