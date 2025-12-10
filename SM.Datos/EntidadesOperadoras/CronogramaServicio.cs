using SM.Datos.DTO;
using SM.Datos.DTO.Servicios;
using SM.LibreriaComun.DTO;
using SM.LibreriaComun.DTO.EntidadesOperadoras;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SM.Datos.EntidadesOperadoras
{
    public class CronogramaServicio
    {
        #region actualizacion
        public static int Crear(ART_MUSICA_CRONOGRAMA registro)
        {
            int DotacionId = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_CRONOGRAMA.Add(registro);
                    context.SaveChanges();
                    DotacionId = registro.Id;

                }

                return DotacionId;
            }
            catch (Exception)
            {
                throw;
            }
        }



        public static void Actualizar(int cronogramaId, CronogramaDTO datos, int UsuarioId)
        {
            try
            {

                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_CRONOGRAMA.Where(x => x.Id == cronogramaId).FirstOrDefault();



                    if (entidad != null)
                    {
                        entidad.ActividadId = Convert.ToInt32(datos.ActividadId);
                        entidad.Cod_departamento = datos.Cod_departamento;
                        entidad.Cod_municipio = datos.Cod_municipio;
                        entidad.Cupo = Convert.ToInt32(datos.Cupo);
                        entidad.FechaCreacion = DateTime.Now;
                        entidad.FechaActualizacion = DateTime.Now;
                        entidad.FechaInicio = Convert.ToDateTime(datos.FechaInicio);
                        entidad.FechaFin = Convert.ToDateTime(datos.FechaFin);
                        entidad.Nombre = datos.Nombre;
                        entidad.EscuelaId = Convert.ToDecimal(datos.Escuela);
                        entidad.UsuarioCreadorId = UsuarioId;

                    }
                    context.SaveChanges();

                }
            }
            catch (Exception)
            { throw; }
        }
        #endregion



        #region Consulta
        public static CronogramaEntidadDTO ConsultarNombreEntidad(decimal EscuelaId)
        {
            var listResultado = new CronogramaEntidadDTO();
            try
            {
                using (var context = new SIPAEntities())
                {
                    listResultado = context.Database.SqlQuery<CronogramaEntidadDTO>(@"EXEC ART_MUSICA_DATOS_ENTIDAD_CONVENIO @EscuelaId", new SqlParameter("EscuelaId", EscuelaId)).FirstOrDefault();

                }
                return listResultado;

            }
            catch (Exception)
            { throw; }
        }
        public static List<CronogramaReporteDTO> ConsultarResponsableCronogramas(int UsuarioId)
        {
            var listResultado = new List<CronogramaReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    listResultado = context.Database.SqlQuery<CronogramaReporteDTO>(@"EXEC ART_MUSICA_RESPONSABLE_CRONOGRAMA @UsuarioId", new SqlParameter("UsuarioId", UsuarioId)).ToList();

                }
                return listResultado;

            }
            catch (Exception)
            { throw; }
        }



        public static List<CronogramaReporteDTO> ConsultaCoordinadorCronograma()
        {
            var listResultado = new List<CronogramaReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    listResultado = context.Database.SqlQuery<CronogramaReporteDTO>(@"EXEC ART_MUSICA_COORDINADOR_CONVENIO").ToList();

                }
                return listResultado;

            }
            catch (Exception)
            { throw; }
        }
        public static string ObtenerNombreActividad(int Id)
        {
            string Nombre = "";
            int actividadId = 0;

            try
            {
                using (var context = new SIPAEntities())
                {
                    actividadId = context.ART_MUSICA_CRONOGRAMA.Where(x => x.Id == Id).FirstOrDefault().ActividadId;

                    if (actividadId > 0)
                    {
                        Nombre = context.ART_MUSICA_ACTIVIDADES.Where(x => x.Id == actividadId).FirstOrDefault().Nombre;
                    }

                }
                return Nombre;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ART_MUSICA_ACTIVIDADES ObtenerActividadPorCronogramaid(int Id)
        {
            var registro = new ART_MUSICA_ACTIVIDADES();
            int actividadId = 0;

            try
            {
                using (var context = new SIPAEntities())
                {
                    actividadId = context.ART_MUSICA_CRONOGRAMA.Where(x => x.Id == Id).FirstOrDefault().ActividadId;

                    if (actividadId > 0)
                    {
                        registro = context.ART_MUSICA_ACTIVIDADES.Where(x => x.Id == actividadId).FirstOrDefault();
                    }

                }
                return registro;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<ART_MUSICA_CRONOGRAMA> ConsultarPorActividadId(int Id)
        {
            var listado = new List<ART_MUSICA_CRONOGRAMA>();

            try
            {
                using (var context = new SIPAEntities())
                {
                    listado = context.ART_MUSICA_CRONOGRAMA.Where(x => x.ActividadId == Id).ToList();
                }
                return listado;
            }
            catch (Exception)
            { throw; }
        }
        public static ART_MUSICA_CRONOGRAMA ConsultarPorId(int Id)
        {

            var registro = new ART_MUSICA_CRONOGRAMA();

            try
            {
                using (var context = new SIPAEntities())
                {

                    registro = context.ART_MUSICA_CRONOGRAMA.Where(x => x.Id == Id).FirstOrDefault();


                }
                return registro;

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
        #region reporteParticipantes
        public static CronogramaConvenioDTO ConsultarDatosConvenioPorCronogramaId(int cronogramaId)
        {
            var listBasica = new CronogramaConvenioDTO();
            try
            {
                using (var context = new SIPAEntities())
                {
                    listBasica = (from c in context.ART_MUSICA_CRONOGRAMA
                                  join a in context.ART_MUSICA_ACTIVIDADES on c.ActividadId equals a.Id
                                  join v in context.ART_MUSICA_CONVENIOS on a.ConvenioId equals v.Id
                                  join e in context.ART_MUSICA_ENTIDADES on v.EntidadId equals e.Id
                                  join d in context.BAS_ZONAS_GEOGRAFICAS on c.Cod_departamento equals d.ZON_ID
                                  join m in context.BAS_ZONAS_GEOGRAFICAS on c.Cod_municipio equals m.ZON_ID
                                  where c.Id == cronogramaId
                                  select new CronogramaConvenioDTO
                                  {
                                      ActividadId = a.Id,
                                      Actividad = a.Nombre,
                                      Convenio = v.Nombre,
                                      Cronograma = c.Nombre,
                                      CronogramaId = c.Id,
                                      Departamento = d.ZON_NOMBRE,
                                      Municipio = m.ZON_NOMBRE,
                                      Entidad = e.Nombre,
                                      EntidadId = e.Id,
                                      FechaFin = c.FechaFin,
                                      FechaInicio = c.FechaInicio
                                  }).FirstOrDefault();



                }
                return listBasica;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region agentesxcronograma
        public static List<Parametro> ConsultarAgentesCronograma(int cronogramaId, int TipoId)
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    listBasica = (from g in context.ART_MUSICA_CRONOGRAMAXAGENTE
                                  join a in context.ART_MUSICA_AGENTE on g.AgenteId equals a.ID
                                  where g.CronogramaId == cronogramaId
                                  where g.TipoId == TipoId
                                  select new Parametro
                                  {
                                      Id = g.Id,
                                      Nombre = a.PrimerNombre + " " + a.SegundoNombre + " " + a.PrimerApellido + " " + a.SedundoApellido ?? " "
                                  }).ToList();



                }
                return listBasica;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool ValidaCronogramaXEscuelaId(int escuelaId)
        {
            bool boolBloquear = false;
            try
            {
                using (var context = new SIPAEntities())
                {
                    var listBasica = (from g in context.ART_MUSICA_CRONOGRAMA
                                      join a in context.ART_MUSICA_ACTIVIDADES on g.ActividadId equals a.Id
                                      join c in context.ART_MUSICA_CONVENIOS on a.ConvenioId equals c.Id
                                      where g.EscuelaId == escuelaId
                                      select new DatosAsesoria
                                      {
                                          Id = g.Id,
                                          FechaInicioCronograma = g.FechaInicio,
                                          FechaFinConvenio = c.FechaFin
                                      }).FirstOrDefault();

                    if (listBasica != null && listBasica.Id > 0)
                    {
                        if ((listBasica.FechaInicioCronograma <= DateTime.Today) && (listBasica.FechaFinConvenio >= DateTime.Today))
                        { boolBloquear = true; }

                    }

                }
                return boolBloquear;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void EliminarAgente(int Id)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_CRONOGRAMAXAGENTE.Remove(context.ART_MUSICA_CRONOGRAMAXAGENTE.Where(x => x.Id == Id).FirstOrDefault());
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void AgregarAgente(ART_MUSICA_CRONOGRAMAXAGENTE registro)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_CRONOGRAMAXAGENTE.Add(registro);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
