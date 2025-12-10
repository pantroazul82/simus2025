using SM.Datos.DTO;
using SM.Datos.DTO.Servicios;
using SM.LibreriaComun.DTO.EntidadesOperadoras;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SM.Datos.EntidadesOperadoras
{
    public class AsistenciaServicio
    {
        #region actualizacion
        public static int Crear(ART_MUSICA_ASISTENCIA registro)
        {
            int Id = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_ASISTENCIA.Where(x => x.CronogramaId == registro.CronogramaId && x.ParticipanteId == registro.ParticipanteId && x.FechaAsistencia == registro.FechaAsistencia).FirstOrDefault();
                    if (entidad != null && entidad.Id > 0)
                    {
                        context.ART_MUSICA_ASISTENCIA.Remove(entidad);
                        context.SaveChanges();
                    }

                    context.ART_MUSICA_ASISTENCIA.Add(registro);
                    context.SaveChanges();
                    Id = registro.Id;

                }

                return Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int CrearAuto(ART_MUSICA_AUTOEVALUACION_RESPUESTA registro)
        {
            int Id = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_AUTOEVALUACION_RESPUESTA.Where(x => x.CronogramaId == registro.CronogramaId && x.ParticipanteId == registro.ParticipanteId && x.PreguntaId == registro.PreguntaId).FirstOrDefault();
                    if (entidad != null && entidad.Id > 0)
                    {
                        context.ART_MUSICA_AUTOEVALUACION_RESPUESTA.Remove(entidad);
                        context.SaveChanges();
                    }

                    context.ART_MUSICA_AUTOEVALUACION_RESPUESTA.Add(registro);
                    context.SaveChanges();
                    Id = registro.Id;

                }

                return Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int CrearEvaluacion(ART_MUSICA_EVALUACION registro)
        {
            int Id = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_EVALUACION.Where(x => x.CronogramaId == registro.CronogramaId && x.ParticipanteId == registro.ParticipanteId).FirstOrDefault();
                    if (entidad != null && entidad.Id > 0)
                    {
                        context.ART_MUSICA_EVALUACION.Remove(entidad);
                        context.SaveChanges();
                    }

                    context.ART_MUSICA_EVALUACION.Add(registro);
                    context.SaveChanges();
                    Id = registro.Id;

                }

                return Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void AgregarAsistente(ART_MUSICA_ASISTENCIA registro)
        {

            try
            {
                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_ASISTENCIA.Where(x => x.ParticipanteId == registro.ParticipanteId &&  x.FechaAsistencia == registro.FechaAsistencia).FirstOrDefault();

                    if (entidad != null)
                    {
                        entidad = registro;
                    }
                    else
                        Crear(registro);

                }


            }
            catch (Exception)
            {
                throw;
            }
        }


      
        public static void Actualizar(int Id, AsistenciaDTO datos, int UsuarioId)
        {
            try
            {

                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_ASISTENCIA.Where(x => x.Id == Id).FirstOrDefault();



                    if (entidad != null)
                    {
                        entidad.FechaAsistencia = Convert.ToDateTime(datos.FechaAsistencia);
                        entidad.Id = datos.Id;
                        entidad.ParticipanteId = Convert.ToInt32(datos.ParticipanteId);
                        entidad.CronogramaId = datos.CronogramaId;
                        entidad.FechaActualizacion = DateTime.Now;
                        entidad.FechaCreacion = DateTime.Now;
                        entidad.UsuarioCreadorId = UsuarioId;
                        entidad.Asistio = datos.Asistio;

                    }
                    context.SaveChanges();

                }
            }
            catch (Exception)
            { throw; }
        }
        #endregion

        #region Consulta
        public static List<ART_MUSICA_ASISTENCIA> ConsultarPorCronogramaId(int Id)
        {
            var listado = new List<ART_MUSICA_ASISTENCIA>();

            try
            {
                using (var context = new SIPAEntities())
                {
                    listado = context.ART_MUSICA_ASISTENCIA.Where(x => x.CronogramaId == Id).ToList();
                }
                return listado;
            }
            catch (Exception)
            { throw; }
        }

        public static List<ART_MUSICA_ASISTENCIA> ConsultarPorCronogramaFecha(int Id, string fecha)
        {
            var listado = new List<ART_MUSICA_ASISTENCIA>();

            try
            {
                using (var context = new SIPAEntities())
                {
                    listado = context.ART_MUSICA_ASISTENCIA.Where(x => x.CronogramaId == Id && x.FechaAsistencia.ToString("yyyy-MM-dd") == fecha).ToList();
                }
                return listado;
            }
            catch (Exception)
            { throw; }
        }

        public static List<AsistenteResultadoDTO> ConsultarAsistentes(int CronogramaId)
        {

            List<AsistenteResultadoDTO> listado;
            try
            {
                using (var context = new SIPAEntities())
                {

                    listado = (from E in context.ART_MUSICA_ASISTENCIA
                               where E.CronogramaId == CronogramaId
                               select new AsistenteResultadoDTO
                               {
                                   AsistenciaId = E.Id,
                                   AgenteId = E.ParticipanteId,
                                   FechaAsistencia = E.FechaAsistencia,
                                   CronogramaId = E.CronogramaId

                               }).ToList();



                }
                return listado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<AsistenteResultadoDTO> ConsultarAsistenciaporAgenteId(int CronogramaId, int AgenteId)
        {

            List<AsistenteResultadoDTO> listado;
            try
            {
                using (var context = new SIPAEntities())
                {

                    listado = (from E in context.ART_MUSICA_ASISTENCIA
                               join C in context.ART_MUSICA_CRONOGRAMA on E.CronogramaId equals C.Id
                               where E.CronogramaId == CronogramaId
                               where E.ParticipanteId == AgenteId
                               select new AsistenteResultadoDTO
                               {
                                   AsistenciaId = E.Id,
                                   AgenteId = E.ParticipanteId,
                                   FechaAsistencia = E.FechaAsistencia,
                                   CronogramaId = E.CronogramaId,
                                   FechaInicio = C.FechaInicio,
                                   FechaFin = C.FechaFin

                               }).ToList();



                }
                return listado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ParticipantesResultadoDTO> ConsultarParticipantesdelCronograma(int CronogramaId)
        {

            List<ParticipantesResultadoDTO> listado;
            try
            {
                using (var context = new SIPAEntities())
                {

                    listado = (from E in context.ART_MUSICA_CRONOGRAMAXAGENTE
                               join A in context.ART_MUSICA_AGENTE on E.AgenteId equals A.ID
                               join C in context.ART_MUSICA_CRONOGRAMA on E.CronogramaId equals C.Id
                               where E.CronogramaId == CronogramaId
                               where E.TipoId == 2
                               select new ParticipantesResultadoDTO
                               {
                                   AsistenciaId = E.Id,
                                   AgenteId = E.AgenteId,
                                   CronogramaId = E.CronogramaId,
                                   Nombres = A.PrimerNombre + " " + A.SegundoNombre,
                                   Apellidos = A.PrimerApellido + " " + A.SedundoApellido,
                                   Cronograma = C.Nombre,
                                   Identificacion = A.Identificacion,
                                   ActividadId = C.ActividadId,
                                   FechaInicio = C.FechaInicio,
                                   FechaFin = C.FechaFin
                               }).ToList();



                }
                return listado;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region evaluacion
        public static ART_MUSICA_EVALUACION ConsultarEvaluacionPorAgenteId(int CronogramaId, int AgenteId)
        {

            ART_MUSICA_EVALUACION listado = new ART_MUSICA_EVALUACION();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listado = context.ART_MUSICA_EVALUACION.Where(X=> X.CronogramaId==CronogramaId && X.ParticipanteId == AgenteId).FirstOrDefault();
                            
        
                }
                return listado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ART_MUSICA_EVALUACION_PREGUNTAS> ConsultarPreguntasAutoEvaluacion()
        {

            var listado = new List<ART_MUSICA_EVALUACION_PREGUNTAS>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listado = context.ART_MUSICA_EVALUACION_PREGUNTAS.Where(X => X.Activo == true).ToList(); 


                }
                return listado;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
