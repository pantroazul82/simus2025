using SM.Datos.Agentes;
using SM.Datos.DTO;
using SM.Datos.EntidadesOperadoras;
using SM.Datos.Servicios;
using SM.LibreriaComun.DTO.EntidadesOperadoras;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SM.Aplicacion.EntidadesOpeadoras
{
    public class AsistenciaNeg
    {

        #region actualizar

        public static int Crear(AsistenciaDTO datos, int UsuarioId)
        {
            int registroId = 0;

            try
            {


                var registro = new ART_MUSICA_ASISTENCIA
                {
                    Asistio = datos.Asistio,
                    CronogramaId = datos.CronogramaId,
                    FechaAsistencia = Convert.ToDateTime(datos.FechaAsistencia),
                    ParticipanteId = Convert.ToInt32(datos.ParticipanteId),
                    FechaActualizacion = DateTime.Now,
                    FechaCreacion = DateTime.Now,
                    UsuarioCreadorId = UsuarioId,

                };



                registroId = AsistenciaServicio.Crear(registro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return registroId;
        }

        public static int CrearAutoEvaluacion(RespuestaDTO datos)
        {
            int registroId = 0;

            try
            {


                var registro = new ART_MUSICA_AUTOEVALUACION_RESPUESTA
                {

                    CronogramaId = datos.CronogramaId,
                    PreguntaId = datos.PreguntaId,
                    ParticipanteId = Convert.ToInt32(datos.ParticipanteId),
                    respondio = datos.respuesta,
                    FechaCreacion = DateTime.Now,
                    UsuarioId = datos.UsuarioId,

                };



                registroId = AsistenciaServicio.CrearAuto(registro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return registroId;
        }

        public static int CrearEvaluacion(EvaluacionDTO datos)
        {
            int registroId = 0;

            try
            {


                var registro = new ART_MUSICA_EVALUACION
                {
                    ParticipanteId = datos.ParticipanteId,
                    CronogramaId = datos.CronogramaId,
                    Descripcion = datos.Descripcion,
                    Evaluacion = datos.Evaluacion,
                    FechaActualizacion = DateTime.Today,
                    FechaCreacion = DateTime.Today,

                    UsuarioId = datos.UsuarioId

                };



                registroId = AsistenciaServicio.CrearEvaluacion(registro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return registroId;
        }

        public static void Agregar(string FechaAsistencia, int UsuarioId, int cronogramaId)
        {
            var listBasica = new List<Parametro>();

            listBasica = CronogramaServicio.ConsultarAgentesCronograma(cronogramaId, 2);
            try
            {
                foreach (var item in listBasica)
                {
                    var registro = new ART_MUSICA_ASISTENCIA
                    {
                        Asistio = false,
                        CronogramaId = cronogramaId,
                        FechaAsistencia = Convert.ToDateTime(FechaAsistencia),
                        ParticipanteId = Convert.ToInt32(item.Id),
                        FechaActualizacion = DateTime.Now,
                        FechaCreacion = DateTime.Now,
                        UsuarioCreadorId = UsuarioId,

                    };
                    AsistenciaServicio.AgregarAsistente(registro);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static void Actualizar(int Id, AsistenciaDTO model, int UsuarioId)
        {
            try
            {

                AsistenciaServicio.Actualizar(Id, model, UsuarioId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Consulta


        public static List<AsistenciaDTO> ConsultarPorCronogramaFecha(int Id, string fecha)
        {
            try
            {
                var listdoentidad = new List<AsistenciaDTO>();
                var listado = AsistenciaServicio.ConsultarPorCronogramaFecha(Id, fecha);


                if (listado != null)
                {
                    foreach (var datos in listado)
                    {
                        var entidad = new AsistenciaDTO();
                        entidad.CronogramaId = datos.CronogramaId;
                        entidad.Asistio = (bool)datos.Asistio;
                        entidad.FechaAsistencia = datos.FechaAsistencia.ToString("yyyy-MM-dd");
                        entidad.Id = datos.Id;
                        entidad.FechaActualizacion = datos.FechaActualizacion;
                        entidad.FechaCreacion = datos.FechaCreacion;
                        entidad.UsuarioCreadorId = datos.UsuarioCreadorId;

                        listdoentidad.Add(entidad);
                    }
                }


                return listdoentidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static AgregarAsistenciaDTO ConsultarAsistenciaPorAgente(int CronogramaId, int agenteId)
        {
            try
            {
                DateTime Fechainicial = DateTime.Now;
                DateTime FechaFinal = DateTime.Now;
                var registro = new AgregarAsistenciaDTO();
                var listado = AsistenciaServicio.ConsultarAsistenciaporAgenteId(CronogramaId, agenteId);
                var registroCronograma = CronogramaServicio.ConsultarPorId(CronogramaId);
                List<AsistenciaDiasDTO> listadodiasAsistencia = new List<AsistenciaDiasDTO>();

                registro.CronogramaId = CronogramaId;
                registro.ParticipanteId = agenteId;
                registro.NombreCompleto = AgenteServicio.ObtenerNombreAgente(agenteId);
                if (registroCronograma != null)
                {
                    Fechainicial = registroCronograma.FechaInicio;
                    FechaFinal = registroCronograma.FechaFin;
                    FechaFinal = FechaFinal.AddDays(1);
                }
                DateTime fechaItem = Fechainicial;
                int i = 0;
                while (fechaItem < FechaFinal)
                {
                    var item = new AsistenciaDiasDTO();
                    i++;
                    item.asistio = "No";
                    item.FechaAsistenciaNueva = fechaItem;
                    foreach (var t in listado)
                    {
                        if (fechaItem == t.FechaAsistencia)
                        {
                            item.asistio = "SI";
                            item.boolasistio = true;
                            item.ParticipanteIdAsistente = t.AgenteId;
                        }
                    }


                    item.Id = i;
                    item.ParticipanteIdAsistente = agenteId;
                    fechaItem = fechaItem.AddDays(1);
                    listadodiasAsistencia.Add(item);
                }
                registro.listadoFechas = listadodiasAsistencia;
                return registro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<AsistenciaDTO> ConsultarPorCronograma(int Id)
        {
            try
            {
                var listdoentidad = new List<AsistenciaDTO>();
                var listado = AsistenciaServicio.ConsultarParticipantesdelCronograma(Id);
                var listadoAsistencia = AsistenciaServicio.ConsultarAsistentes(Id);
                DateTime Fechainicial = DateTime.Now;
                DateTime FechaFinal = DateTime.Now;


                if (listado != null)
                {
                    foreach (var datos in listado)
                    {
                        var entidad = new AsistenciaDTO();
                        entidad.CronogramaId = datos.CronogramaId;
                        entidad.Identificacion = datos.Identificacion;
                        entidad.Apellidos = datos.Apellidos;
                        entidad.Nombres = datos.Nombres;
                        entidad.ParticipanteId = datos.AgenteId;
                        entidad.FechaInicio = datos.FechaInicio;
                        entidad.FechaFin = datos.FechaFin;
                        Fechainicial = entidad.FechaInicio;
                        FechaFinal = entidad.FechaFin;
                        FechaFinal = FechaFinal.AddDays(1);
                        DateTime fechaItem = Fechainicial;
                        int i = 0;
                        List<AsistenciaDiasDTO> listadodiasAsistencia = new List<AsistenciaDiasDTO>();
                        if (listadoAsistencia == null)
                        {
                            while (fechaItem < FechaFinal)
                            {
                                var item = new AsistenciaDiasDTO();
                                i++;
                                item.asistio = "No";
                                item.FechaAsistenciaNueva = fechaItem;
                                item.Id = i;
                                item.ParticipanteIdAsistente = datos.AgenteId;
                                fechaItem = fechaItem.AddDays(1);
                                listadodiasAsistencia.Add(item);
                            }
                            entidad.Cantidad = i;
                            entidad.Dias = listadodiasAsistencia;
                        }
                        else
                        {
                            var listadotemportal = listadoAsistencia.Where(y => y.AgenteId == entidad.ParticipanteId).ToList();
                            if (listadotemportal != null)
                            {
                                while (fechaItem < FechaFinal)
                                {
                                    var item = new AsistenciaDiasDTO();
                                    i++;
                                    item.asistio = "No";
                                    item.FechaAsistenciaNueva = fechaItem;
                                    foreach (var t in listadotemportal)
                                    {
                                        if (fechaItem == t.FechaAsistencia)
                                        { item.asistio = "SI"; }
                                    }


                                    item.Id = i;
                                    item.ParticipanteIdAsistente = datos.AgenteId;
                                    fechaItem = fechaItem.AddDays(1);
                                    listadodiasAsistencia.Add(item);
                                }
                                entidad.Dias = listadodiasAsistencia;
                            }
                        }
                        listdoentidad.Add(entidad);
                    }
                }




                return listdoentidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Evaluacion
        public static List<AsistenciaDTO> ConsultarParticipantesEvaluacion(int Id)
        {
            try
            {
                var listdoentidad = new List<AsistenciaDTO>();
                var listado = AsistenciaServicio.ConsultarParticipantesdelCronograma(Id);
                DateTime Fechainicial = DateTime.Now;
                DateTime FechaFinal = DateTime.Now;


                if (listado != null)
                {
                    foreach (var datos in listado)
                    {
                        var entidad = new AsistenciaDTO();
                        entidad.CronogramaId = datos.CronogramaId;
                        entidad.Identificacion = datos.Identificacion;
                        entidad.Apellidos = datos.Apellidos;
                        entidad.Nombres = datos.Nombres;
                        entidad.ParticipanteId = datos.AgenteId;
                        entidad.FechaInicio = datos.FechaInicio;
                        entidad.FechaFin = datos.FechaFin;
                        listdoentidad.Add(entidad);
                    }

                }


                return listdoentidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static EvaluacionDTO ConsultarEvaluacionPorAgenteId(int CronogramaId, int AgenteId)
        {
            try
            {
                var entidad = new EvaluacionDTO();
                var datos = AsistenciaServicio.ConsultarEvaluacionPorAgenteId(CronogramaId, AgenteId);


                if (datos != null)
                {
                    entidad.CronogramaId = datos.CronogramaId;
                    entidad.Descripcion = datos.Descripcion;
                    entidad.Evaluacion = datos.Evaluacion;
                    entidad.Id = datos.Id;
                    entidad.ParticipanteId = datos.ParticipanteId;
                    entidad.UsuarioId = datos.UsuarioId;

                }

                entidad.NombreCompleto = AgenteServicio.ObtenerNombreAgente(AgenteId);

                return entidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion

        #region AutoEvaluacion

        public static AutoEvaluacionDTO ConsultarPreguntasAutoEvaluacion(int CronogramaId, int agenteId)
        {
            try
            {

                var registro = new AutoEvaluacionDTO();
                var listado = AsistenciaServicio.ConsultarPreguntasAutoEvaluacion();
                var listadoPreguntas = new List<PreguntaParticipanteDTO>();

                registro.CronogramaId = CronogramaId;
                registro.ParticipanteId = agenteId;
                registro.NombreCompleto = AgenteServicio.ObtenerNombreAgente(agenteId);

                if (listado != null)
                {
                    listadoPreguntas = listado.ConvertAll(x => new PreguntaParticipanteDTO
                    {
                        boolrespondio = false,
                        preguntaId = x.Id,
                        Pregunta = x.Pregunta

                    });
                }

                registro.listadoPreguntas = listadoPreguntas;
                return registro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
