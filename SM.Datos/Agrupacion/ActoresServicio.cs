using SM.Datos.DTO;
using SM.LibreriaComun.DTO.Certificacion;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.Agrupacion
{
    /// <summary>
    /// Clase de datos para consultar los actores:  agentes, agrupaciones, escuelas y entidades para el home publico de SIMUS
    /// </summary>
    public class ActoresServicio
    {
        #region Escuelas
        public static List<ActoresHomeDTO> ConsultarEscuelasHome()
        {

            var listResultado = new List<ActoresHomeDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<ActoresHomeDTO>(@"EXEC ART_MUSICA_ESCUELAS_HOME_TODOS").ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ActoresHomeDTO> ConsultarEscuelasHomePorDepartamento(string codDepto)
        {

            var listResultado = new List<ActoresHomeDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<ActoresHomeDTO>(@"EXEC ART_MUSICA_ESCUELAS_HOME_COD_DEPTO @CodDepto", new SqlParameter("CodDepto", codDepto)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ActoresHomeDTO> ConsultarEscuelasHomePorMunicipio(string codMunicipio)
        {

            var listResultado = new List<ActoresHomeDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<ActoresHomeDTO>(@"EXEC ART_MUSICA_ESCUELAS_HOME_COD_MUNICIPIO @CodMunicipio", new SqlParameter("CodMunicipio", codMunicipio)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ActoresHomeDTO> ConsultarEscuelasHomePorTipo(int TipoId)
        {

            var listResultado = new List<ActoresHomeDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<ActoresHomeDTO>(@"EXEC ART_MUSICA_ESCUELAS_HOME_TIPO @TIPO", new SqlParameter("TIPO", TipoId)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Entidades
        public static List<ActoresHomeDTO> ConsultarEntidadesHome()
        {

            var listResultado = new List<ActoresHomeDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<ActoresHomeDTO>(@"EXEC ART_MUSICA_ENTIDADES_HOME_TODOS").ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ActoresHomeDTO> ConsultarEntidadesHomePorDepartamento(string codDepto)
        {

            var listResultado = new List<ActoresHomeDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<ActoresHomeDTO>(@"EXEC ART_MUSICA_ENTIDADES_HOME_COD_DEPTO @CodDepto", new SqlParameter("CodDepto", codDepto)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ActoresHomeDTO> ConsultarEntidadesHomePorMunicipio(string codMunicipio)
        {

            var listResultado = new List<ActoresHomeDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<ActoresHomeDTO>(@"EXEC ART_MUSICA_ENTIDADES_HOME_COD_MUNICIPIO @CodMunicipio", new SqlParameter("CodMunicipio", codMunicipio)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Agentes
        public static List<ActoresHomeDTO> ConsultarAgentesHome()
        {

            var listResultado = new List<ActoresHomeDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<ActoresHomeDTO>(@"EXEC ART_MUSICA_AGENTES_HOME_TODOS").ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ActoresHomeDTO> ConsultarAgentesHomePorDepartamento(string codDepto)
        {

            var listResultado = new List<ActoresHomeDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<ActoresHomeDTO>(@"EXEC ART_MUSICA_AGENTES_HOME_DEPARTAMENTO @CodDepto", new SqlParameter("CodDepto", codDepto)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ActoresHomeDTO> ConsultarAgentesHomePorMunicipio(string codMunicipio)
        {

            var listResultado = new List<ActoresHomeDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<ActoresHomeDTO>(@"EXEC ART_MUSICA_AGENTES_HOME_MUNICIPIO @CodMunicipio", new SqlParameter("CodMunicipio", codMunicipio)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Certificacion
        public static CertificacionDTO ConsultarCertificacionEscuelas(decimal EscuelaId)
        {
            var registro = new CertificacionDTO();
            try
            {
                using (var context = new SIPAEntities())
                {

                    registro = (from e in context.ART_ENTIDADES_ARTES
                                join i in context.ART_MUSICA_ENTIDAD_IDENTIFICACION on e.ENT_ID equals i.ENT_ID
                                join s in context.ART_MUSICA_ESTADOS on i.EstadoId equals s.Id
                                join ub in context.ART_ENTIDAD_UBICACION on e.ENT_ID equals ub.ENT_ID
                                join m in context.BAS_ZONAS_GEOGRAFICAS on ub.ZON_ID equals m.ZON_ID
                                join d in context.BAS_ZONAS_GEOGRAFICAS on m.ZON_PADRE_ID equals d.ZON_ID

                                where e.ENT_ID == EscuelaId
                                select new CertificacionDTO
                                {
                                    Id = e.ENT_ID.ToString(),
                                    Nombre = e.ENT_NOMBRE,
                                    estadoId = s.Id,
                                    Estado = s.Nombre,
                                    datFechaRegistro = e.ENT_FECHA_DILIGENCIAMIENTO,
                                    datFechaActualizacion = (DateTime)e.ENT_FECHA_ACTUALIZACION,

                                    Departamento = d.ZON_NOMBRE, 
                                    Municipio = m.ZON_NOMBRE,

                                }).FirstOrDefault();

                }
                return registro;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static CertificacionDTO ConsultarCertificacionAgentes(int AgenteId)
        {
            var registro = new CertificacionDTO();
            try
            {
                using (var context = new SIPAEntities())
                {

                    registro = (from e in context.ART_MUSICA_AGENTE
                                join s in context.ART_MUSICA_ESTADOS on e.EstadoId equals s.Id
                                where e.ID == AgenteId
                                select new CertificacionDTO
                                {
                                    Id = e.ID.ToString(),
                                    Nombre = e.PrimerNombre + " " + e.SegundoNombre + " " + e.PrimerApellido + " " + e.SedundoApellido,
                                    Estado = s.Nombre,
                                    estadoId = s.Id,
                                    datFechaRegistro = e.FechaCreacion,
                                    datFechaActualizacion = e.FechaActualizacion,

                                    Departamento = e.CodigoDepartamento,
                                    Municipio = e.CodMunicipio

                                }).FirstOrDefault();

                }
                return registro;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static CertificacionDTO ConsultarCertificacionAgrupacion(int AgrupacionId)
        {
            var registro = new CertificacionDTO();
            try
            {
                using (var context = new SIPAEntities())
                {

                    registro = (from e in context.ART_MUSICA_AGRUPACION
                                join s in context.ART_MUSICA_ESTADOS on e.EstadoId equals s.Id
                                where e.Id == AgrupacionId
                                select new CertificacionDTO
                                {
                                    Id = e.Id.ToString(),
                                    Nombre = e.Nombre,
                                    Estado = s.Nombre,
                                    estadoId = s.Id,
                                    datFechaRegistro = e.FechaCreacion,
                                    datFechaActualizacion = e.FechaActualizacion,

                                    Departamento = e.CodigoDepartamento,
                                    Municipio = e.CodigoMunicipio
                                }).FirstOrDefault();

                }
                return registro;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static CertificacionDTO ConsultarCertificacionEntidad(int entidadId)
        {
            var registro = new CertificacionDTO();
            try
            {
                using (var context = new SIPAEntities())
                {

                    registro = (from e in context.ART_MUSICA_ENTIDADES
                                join s in context.ART_MUSICA_ESTADOS on e.EstadoId equals s.Id
                                where e.Id == entidadId
                                select new CertificacionDTO
                                {
                                    Id = e.Id.ToString(),
                                    Nombre = e.Nombre,
                                    Estado = s.Nombre,
                                    estadoId = s.Id,
                                    datFechaRegistro = e.FechaCreacion,
                                    datFechaActualizacion = e.FechaActualizacion
                                }).FirstOrDefault();

                }
                return registro;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
