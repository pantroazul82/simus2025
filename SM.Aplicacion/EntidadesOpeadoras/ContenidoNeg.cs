using SM.Datos.DTO.Servicios;
using SM.Datos.EntidadesOperadoras;
using SM.LibreriaComun.DTO.EntidadesOperadoras;
using SM.LibreriaComun.DTO.Servicios;
using SM.SIPA;
using System;
using System.Collections.Generic;

namespace SM.Aplicacion.EntidadesOpeadoras
{
    public class ContenidoNeg
    {
        #region actualizar

        public static int Crear(ContenidoDTO datos, int UsuarioId)
        {
            int registroId = 0;

            try
            {


                var registro = new ART_MUSICA_CONTENIDOS
                {
                    ActividadId = Convert.ToInt32(datos.ActividadId),
                    Descripcion = datos.DescripcionContenido,
                    FechaActualizacion = DateTime.Now,
                    Fechacreacion = DateTime.Now,
                    Nombre = datos.NombreContenido,
                    UsuarioId = UsuarioId

                };



                registroId = ContenidoServicio.Crear(registro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return registroId;
        }
        public static void Actualizar(int Id, ContenidoDTO model, int UsuarioId)
        {
            try
            {

                ContenidoServicio.Actualizar(Id, model, UsuarioId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void Eliminar(int Id)
        {
            try
            {

                ContenidoServicio.Eliminar(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Consulta
        public static List<ContenidoDTO> ConsultarPorActividadId(int Id)
        {
            try
            {
                var listdoentidad = new List<ContenidoDTO>();
                var listado = ContenidoServicio.ConsultarPorActividadId(Id);

                if (listado != null)
                {
                    foreach (var datos in listado)
                    {
                        var entidad = new ContenidoDTO();
                        entidad.ActividadId = datos.ActividadId.ToString();
                        entidad.Id = datos.Id;
                        entidad.DescripcionContenido = datos.Descripcion;
                        entidad.FechaActualizacion = datos.FechaActualizacion;
                        entidad.Fechacreacion = datos.Fechacreacion;
                        entidad.NombreContenido = datos.Nombre;
                        entidad.UsuarioId = datos.UsuarioId;

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
        public static ContenidoDTO ConsultarPorId(int Id)
        {
            try
            {
                var entidad = new ContenidoDTO();
                var datos = ContenidoServicio.ConsultarPorId(Id);
                if (datos != null)
                {
                    entidad.ActividadId = datos.ActividadId.ToString();
                    entidad.Id = datos.Id;
                    entidad.DescripcionContenido = datos.Descripcion;
                    entidad.FechaActualizacion = datos.FechaActualizacion;
                    entidad.Fechacreacion = datos.Fechacreacion;
                    entidad.NombreContenido = datos.Nombre;
                    entidad.UsuarioId = datos.UsuarioId;
                }


                return entidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region reporte
        public static List<DotacionListadoDTO> ReporteDotacion()
        {
            try
            {
                var listResultado = new List<DotacionListadoDTO>();
                List<DotacionReporteDTO> listado = ContenidoServicio.ReporteDotacion();

                listResultado = listado.ConvertAll(x => new DotacionListadoDTO
                    {
                        Actividad = x.Actividad,
                        CodigoDane = x.CodigoDane,
                        Cronograma = x.Cronograma,
                        Convenio = x.Convenio,
                        Departamento = x.Departamento,
                        Elemento = x.Elemento,
                        Entidad = x.Entidad,
                        FechaInicio = x.FechaInicio.ToString("dd/MM/yyyy"),
                        FechaFin = x.FechaFin.ToString("dd/MM/yyyy"),
                        Formato = x.Formato,
                        Fuente = x.Fuente,
                        Id = x.Id,
                        Municipio = x.Municipio,
                        Periodo = x.Periodo,
                        Tipo = x.Tipo,
                        TipoActividad = x.TipoActividad,
                        TipoActividadId = x.TipoActividadId,
                        Valor = x.Valor,
                        Cantidad = x.Cantidad
                    });

                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ActividadListadoDTO> ReporteActividad()
        {
            try
            {
                var listResultado = new List<ActividadListadoDTO>();
                List<ActividadReporteDTO> listado = ContenidoServicio.ReporteActividad();

                listResultado = listado.ConvertAll(x => new ActividadListadoDTO
                {
                    Actividad = x.Actividad,
                    Entidad = x.Entidad,
                    Cantidad = x.Cantidad

                });

                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ParticipanteListadoDTO> ReporteParticipantesxActividad()
        {
            try
            {
                var listResultado = new List<ParticipanteListadoDTO>();
                List<ParticipanteReporteDTO> listado = ContenidoServicio.ReporteParticipantesxActividad();

                listResultado = listado.ConvertAll(x => new ParticipanteListadoDTO
                {
                    Actividad = x.Actividad,
                    CodigoDane = x.CodigoDane,
                    Departamento = x.Departamento,
                    Entidad = x.Entidad,
                    Municipio = x.Municipio,
                    Cronograma = x.Cronograma,
                    Convenio = x.Convenio,
                    CorreoElectronico = x.CorreoElectronico,
                    DepartamentoResidencia = x.DepartamentoResidencia,
                    FechaInicio = x.FechaInicio.ToString("dd/MM/yyyy"),
                    FechaFin = x.FechaFin.ToString("dd/MM/yyyy"),
                    Identificacion = x.Identificacion,
                    MunicipioResidencia = x.MunicipioResidencia,
                    Participante = x.Participante,
                    Telefono = x.Telefono,
                    TipoActividad = x.TipoActividad,
                    Periodo = x.Periodo
                });

                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<DotacionEscuelaListadoDTO> ReporteEntidadEscuela()
        {
            try
            {
                var listResultado = new List<DotacionEscuelaListadoDTO>();
                List<DotacionEscuelaReporteDTO> listado = ContenidoServicio.ReporteEntidadEscuela();

                listResultado = listado.ConvertAll(x => new DotacionEscuelaListadoDTO
                {
                    Actividad = x.Actividad,
                    CodigoDane = x.CodigoDane,
                    Departamento = x.Departamento,
                    Entidad = x.Entidad,
                    Municipio = x.Municipio,
                    Cronograma = x.Cronograma,
                    Convenio = x.Convenio,
                    FechaInicio = x.FechaInicio.ToString("dd/MM/yyyy"),
                    FechaFin = x.FechaFin.ToString("dd/MM/yyyy"),
                    Escuela = x.Escuela,
                    Operatividad = x.Operatividad,
                    OperatividadId = x.OperatividadId

                });

                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ParticipanteXMunicipioListadoDTO> ReporteParticipanteXMunicipio()
        {
            try
            {
                var listResultado = new List<ParticipanteXMunicipioListadoDTO>();
                List<ParticipanteXMunicipioReporteDTO> listado = ContenidoServicio.ReporteParticipanteXMunicipio();

                listResultado = listado.ConvertAll(x => new ParticipanteXMunicipioListadoDTO
                {

                    CodigoDane = x.CodigoDane,
                    Departamento = x.Departamento,
                    Municipio = x.Municipio,
                    Cantidad = x.Cantidad
                });

                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
