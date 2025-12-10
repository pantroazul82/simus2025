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
    public class ContenidoServicio
    {
        public static int Crear(ART_MUSICA_CONTENIDOS registro)
        {
            int DotacionId = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_CONTENIDOS.Add(registro);
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

        public static void Actualizar(int Id, ContenidoDTO datos, int UsuarioId)
        {
            try
            {

                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_CONTENIDOS.Where(x => x.Id == Id).FirstOrDefault();



                    if (entidad != null)
                    {
                        entidad.ActividadId = Convert.ToInt32(datos.ActividadId);
                        entidad.Descripcion = datos.DescripcionContenido;
                        entidad.FechaActualizacion = DateTime.Now;
                        entidad.Fechacreacion = DateTime.Now;
                        entidad.Nombre = datos.NombreContenido;
                        entidad.UsuarioId = UsuarioId;

                    }
                    context.SaveChanges();

                }
            }
            catch (Exception)
            { throw; }
        }

        public static void Eliminar(int Id)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_CONTENIDOS.Remove(context.ART_MUSICA_CONTENIDOS.Where(x => x.Id == Id).FirstOrDefault());
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #region Consulta

        public static List<ART_MUSICA_CONTENIDOS> ConsultarPorActividadId(int Id)
        {
            var listado = new List<ART_MUSICA_CONTENIDOS>();

            try
            {
                using (var context = new SIPAEntities())
                {
                    listado = context.ART_MUSICA_CONTENIDOS.Where(x => x.ActividadId == Id).ToList();
                }
                return listado;
            }
            catch (Exception)
            { throw; }
        }
        public static ART_MUSICA_CONTENIDOS ConsultarPorId(int Id)
        {

            var registro = new ART_MUSICA_CONTENIDOS();

            try
            {
                using (var context = new SIPAEntities())
                {

                    registro = context.ART_MUSICA_CONTENIDOS.Where(x => x.Id == Id).FirstOrDefault();


                }
                return registro;

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region reporte
        public static List<DotacionReporteDTO> ReporteDotacion()
        {

            var listResultado = new List<DotacionReporteDTO>();

            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = context.Database.SqlQuery<DotacionReporteDTO>(@"EXEC ART_MUSICA_REPORTE_CONVENIO_DOTACION").ToList();

                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ActividadReporteDTO> ReporteActividad()
        {

            var listResultado = new List<ActividadReporteDTO>();

            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = context.Database.SqlQuery<ActividadReporteDTO>(@"EXEC ART_MUSICA_PARTICIPANTES_POR_ACTIVIDAD").ToList();

                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ParticipanteReporteDTO> ReporteParticipantesxActividad()
        {

            var listResultado = new List<ParticipanteReporteDTO>();

            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = context.Database.SqlQuery<ParticipanteReporteDTO>(@"EXEC ART_MUISCA_ACTIVIDADES_PARTICIPANTES").ToList();

                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<DotacionEscuelaReporteDTO> ReporteEntidadEscuela()
        {

            var listResultado = new List<DotacionEscuelaReporteDTO>();

            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = context.Database.SqlQuery<DotacionEscuelaReporteDTO>(@"EXEC ART_MUSICA_ENTIDAD_POR_ESCUELA").ToList();

                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ParticipanteXMunicipioReporteDTO> ReporteParticipanteXMunicipio()
        {

            var listResultado = new List<ParticipanteXMunicipioReporteDTO>();

            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = context.Database.SqlQuery<ParticipanteXMunicipioReporteDTO>(@"EXEC ART_MUSICA_REPORTE_PARTICIPANTES_POR_MUNICIPIO").ToList();

                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
