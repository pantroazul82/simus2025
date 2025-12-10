using SM.Aplicacion.Eventos;
using System;
using System.Collections.Generic;
using System.Web.Http;
using WebSImus.Models;
using WebSImus.Translator;

namespace WebSImus.Controllers
{
    /// <summary>
    /// Controlador API REST para gestionar datos de Celebra la Música.
    /// Expone endpoints con estadísticas y datos de municipios participantes.
    /// </summary>
    [RoutePrefix("api/celebra")]
    public class CelebraApiController : ApiController
    {
        /// <summary>
        /// Obtiene estadísticas generales de Celebra la Música.
        /// </summary>
        /// <returns>Objeto con todas las estadísticas de Celebra</returns>
        /// <example>GET /api/celebra/estadisticas</example>
        [HttpGet]
        [Route("estadisticas")]
        public IHttpActionResult GetEstadisticas()
        {
            try
            {
                var estadisticas = new
                {
                    musica = new
                    {
                        municipiosParticipantes = ArtistasNeg.CantidadMunicipioParticipantes(),
                        conciertos = ArtistasNeg.ConsultarCantidadConciertos(),
                        artistas = ArtistasNeg.ConsultarCantidadArtistas(),
                        agrupaciones = ArtistasNeg.ConsultarCantidadGrupos()
                    },
                    danza = new
                    {
                        municipiosParticipantes = EventosNeg.CantidadMunicipioParticipantesDanza(),
                        departamentosParticipantes = EventosNeg.CantidadDepartamentoParticipantesDanza(),
                        eventos = EventosNeg.ConsultarCantidadEventosDanza()
                    }
                };

                return Ok(estadisticas);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Obtiene la cantidad de municipios participantes en Celebra la Música.
        /// </summary>
        /// <returns>Número de municipios participantes</returns>
        /// <example>GET /api/celebra/musica/municipios</example>
        [HttpGet]
        [Route("musica/municipios")]
        public IHttpActionResult GetMunicipiosParticipantes()
        {
            try
            {
                int cantidad = ArtistasNeg.CantidadMunicipioParticipantes();
                return Ok(new { cantidad });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Obtiene la lista detallada de municipios participantes en Celebra la Música.
        /// </summary>
        /// <returns>Lista de municipios con sus datos</returns>
        /// <example>GET /api/celebra/musica/municipios/detalle</example>
        [HttpGet]
        [Route("musica/municipios/detalle")]
        public IHttpActionResult GetMunicipiosParticipantesDetalle()
        {
            try
            {
                List<MunicipioCelebraModels> municipios = TranslatorEventos.MunicipioParticipantesCelebralaMusica();
                return Ok(municipios);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Obtiene la cantidad de conciertos realizados en Celebra la Música.
        /// </summary>
        /// <returns>Número de conciertos</returns>
        /// <example>GET /api/celebra/musica/conciertos</example>
        [HttpGet]
        [Route("musica/conciertos")]
        public IHttpActionResult GetCantidadConciertos()
        {
            try
            {
                int cantidad = ArtistasNeg.ConsultarCantidadConciertos();
                return Ok(new { cantidad });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Obtiene la cantidad de artistas participantes en Celebra la Música.
        /// </summary>
        /// <returns>Número de artistas</returns>
        /// <example>GET /api/celebra/musica/artistas</example>
        [HttpGet]
        [Route("musica/artistas")]
        public IHttpActionResult GetCantidadArtistas()
        {
            try
            {
                int cantidad = ArtistasNeg.ConsultarCantidadArtistas();
                return Ok(new { cantidad });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Obtiene la cantidad de agrupaciones participantes en Celebra la Música.
        /// </summary>
        /// <returns>Número de agrupaciones</returns>
        /// <example>GET /api/celebra/musica/agrupaciones</example>
        [HttpGet]
        [Route("musica/agrupaciones")]
        public IHttpActionResult GetCantidadAgrupaciones()
        {
            try
            {
                int cantidad = ArtistasNeg.ConsultarCantidadGrupos();
                return Ok(new { cantidad });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Obtiene la cantidad de municipios participantes en eventos de Danza.
        /// </summary>
        /// <returns>Número de municipios participantes en danza</returns>
        /// <example>GET /api/celebra/danza/municipios</example>
        [HttpGet]
        [Route("danza/municipios")]
        public IHttpActionResult GetMunicipiosDanza()
        {
            try
            {
                int cantidad = EventosNeg.CantidadMunicipioParticipantesDanza();
                return Ok(new { cantidad });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Obtiene la cantidad de departamentos participantes en eventos de Danza.
        /// </summary>
        /// <returns>Número de departamentos participantes en danza</returns>
        /// <example>GET /api/celebra/danza/departamentos</example>
        [HttpGet]
        [Route("danza/departamentos")]
        public IHttpActionResult GetDepartamentosDanza()
        {
            try
            {
                int cantidad = EventosNeg.CantidadDepartamentoParticipantesDanza();
                return Ok(new { cantidad });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Obtiene la cantidad de eventos de Danza realizados.
        /// </summary>
        /// <returns>Número de eventos de danza</returns>
        /// <example>GET /api/celebra/danza/eventos</example>
        [HttpGet]
        [Route("danza/eventos")]
        public IHttpActionResult GetEventosDanza()
        {
            try
            {
                int cantidad = EventosNeg.ConsultarCantidadEventosDanza();
                return Ok(new { cantidad });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Obtiene todas las estadísticas de música en un solo objeto.
        /// </summary>
        /// <returns>Estadísticas completas de música</returns>
        /// <example>GET /api/celebra/musica/estadisticas</example>
        [HttpGet]
        [Route("musica/estadisticas")]
        public IHttpActionResult GetEstadisticasMusica()
        {
            try
            {
                var estadisticas = new
                {
                    municipiosParticipantes = ArtistasNeg.CantidadMunicipioParticipantes(),
                    conciertos = ArtistasNeg.ConsultarCantidadConciertos(),
                    artistas = ArtistasNeg.ConsultarCantidadArtistas(),
                    agrupaciones = ArtistasNeg.ConsultarCantidadGrupos()
                };

                return Ok(estadisticas);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Obtiene todas las estadísticas de danza en un solo objeto.
        /// </summary>
        /// <returns>Estadísticas completas de danza</returns>
        /// <example>GET /api/celebra/danza/estadisticas</example>
        [HttpGet]
        [Route("danza/estadisticas")]
        public IHttpActionResult GetEstadisticasDanza()
        {
            try
            {
                var estadisticas = new
                {
                    municipiosParticipantes = EventosNeg.CantidadMunicipioParticipantesDanza(),
                    departamentosParticipantes = EventosNeg.CantidadDepartamentoParticipantesDanza(),
                    eventos = EventosNeg.ConsultarCantidadEventosDanza()
                };

                return Ok(estadisticas);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
