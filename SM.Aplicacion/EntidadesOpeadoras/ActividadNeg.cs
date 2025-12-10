using SM.Aplicacion.Documentos;
using SM.Datos.EntidadesOperadoras;
using SM.Datos.Servicios;
using SM.LibreriaComun.DTO.EntidadesOperadoras;
using SM.SIPA;
using System;
using System.Collections.Generic;

namespace SM.Aplicacion.EntidadesOpeadoras
{
    public class ActividadNeg
    {
        #region actualizar

        public static int Crear(ActividadDTO datos, int UsuarioId)
        {
            int registroId = 0;

            try
            {


                var registro = new ART_MUSICA_ACTIVIDADES
                {
                    ConvenioId = datos.ConvenioId,
                    Descripcion = datos.Descripcion,
                    EstadoId = Convert.ToInt32(datos.EstadoId),
                    ValorEjecutado = Convert.ToDecimal(datos.ValorEjecutado),
                    ValorProgramado = Convert.ToDecimal(datos.ValorProgramado),
                    TipoActividadId = Convert.ToInt32(datos.TipoActividadId),
                    FechaActualizacion = DateTime.Now,
                    FechaCreacion = DateTime.Now,
                    Nombre = datos.Nombre,
                    Minimo_Dias = Convert.ToInt32(datos.NumeroDias),
                    UsuarioCreadorId = UsuarioId,

                };



                registroId = ActividadServicio.Crear(registro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return registroId;
        }

        public static void ActualizarDocumento(int Id, int DocumentoId)
        {
            try
            {
                ActividadServicio.ActualizarDocumento(Id, DocumentoId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Actualizar(int Id, ActividadDTO model, int UsuarioId)
        {
            try
            {

                ActividadServicio.Actualizar(Id, model, UsuarioId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Consulta
        public static ActividadDTO ConsultarPorId(int Id)
        {
            try
            {
                var entidad = new ActividadDTO();
                var datos = ActividadServicio.ConsultarPorId(Id);

                if (datos != null)
                {
                    entidad.TipoActividadId = datos.TipoActividadId.ToString();
                    entidad.ValorEjecutado = datos.ValorEjecutado.ToString();
                    entidad.ValorProgramado = datos.ValorProgramado.ToString();
                    entidad.ConvenioId = datos.ConvenioId;
                    entidad.EstadoId = datos.EstadoId.ToString();
                    entidad.Id = datos.Id;
                    entidad.Descripcion = datos.Descripcion;
                    entidad.FechaActualizacion = datos.FechaActualizacion;
                    entidad.FechaCreacion = datos.FechaCreacion;
                    entidad.Nombre = datos.Nombre;
                    entidad.NumeroDias = datos.Minimo_Dias.ToString();
                    entidad.UsuarioCreadorId = datos.UsuarioCreadorId;
                    if (datos.DocumentoId > 0)
                    {
                        entidad.DocumentoId = datos.DocumentoId ?? 0;
                        entidad.documentoArchivo = DocumentosNeg.ConsultarDocumento(entidad.DocumentoId);
                    }
                    else
                        entidad.DocumentoId = 0;
                   
                }


                return entidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ActividadDTO> ConsultarPorConvenioId(int Id)
        {
            try
            {
                var listdoentidad = new List<ActividadDTO>();
                var listado = ActividadServicio.ConsultarPorConvenioId(Id);

                if (listado != null)
                {
                    foreach (var datos in listado)
                    {
                        var entidad = new ActividadDTO();
                        entidad.TipoActividadId = datos.TipoActividadId.ToString();
                        entidad.ValorEjecutado = datos.ValorEjecutado.ToString();
                        entidad.ValorProgramado = datos.ValorProgramado.ToString();
                        entidad.ConvenioId = datos.ConvenioId;
                        entidad.EstadoId = datos.EstadoId.ToString();
                        entidad.Id = datos.Id;
                        entidad.Descripcion = datos.Descripcion;
                        entidad.FechaActualizacion = datos.FechaActualizacion;
                        entidad.FechaCreacion = datos.FechaCreacion;
                        entidad.Nombre = datos.Nombre;
                        entidad.NumeroDias = datos.Minimo_Dias.ToString();
                        entidad.UsuarioCreadorId = datos.UsuarioCreadorId;
                        entidad.NombreTipoActividad = ConvocatoriaServicio.ObtenerNombreEstado(datos.TipoActividadId);
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
        #endregion
    }
}
