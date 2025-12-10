using SM.Datos.Basicas;
using SM.Datos.EntidadesOperadoras;
using SM.LibreriaComun.DTO.EntidadesOperadoras;
using System;
using SM.Datos.EntidadesOperadoras;
using SM.LibreriaComun.DTO.EntidadesOperadoras;
using SM.SIPA;
using System;
using System.Collections.Generic;

namespace SM.Aplicacion.EntidadesOpeadoras
{
    public class DotacionConvenioNeg
    {
        #region actualizar

        public static int Crear(DotacionDTO datos, int UsuarioId)
        {
            int registroId = 0;

            try
            {


                var registro = new ART_MUSICA_CONVENIO_DOTACION
                {
                    CronogramaId = Convert.ToInt32(datos.CronogramaId),
                    FechaActualizacion = DateTime.Now,
                    FechaCreacion = DateTime.Now,
                    Serial = datos.Serial,
                    Diagnostico = datos.Diagnostico,
                    Aprobado = datos.Aprobado,
                    Marca = datos.Marca,
                    Garantia = datos.Garantia,
                    Referencia = datos.Referencia,
                    TipoId = Convert.ToInt32(datos.TipoId),
                    ElementoId = Convert.ToInt32(datos.ElementoId),
                    FormatoId = Convert.ToInt32(datos.FormatoId),
                    Precio = datos.Precio,
                    UsuarioCreadorId = UsuarioId,
                    Prooveedor = datos.Proveedor,
                    Descripcion = datos.Descripcion
                };



                registroId = DotacionConvenioServicio.Crear(registro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return registroId;
        }
        public static void Actualizar(int Id, DotacionDTO model, int UsuarioId)
        {
            try
            {

                DotacionConvenioServicio.Actualizar(Id, model, UsuarioId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion
        #region Consulta
        public static List<DotacionDTO> ConsultarPorCronogramaId(int Id)
        {
            try
            {
                var listdoentidad = new List<DotacionDTO>();
                var listado = DotacionConvenioServicio.ConsultarPorCronogramaId(Id);

                if (listado != null)
                {
                    foreach (var datos in listado)
                    {
                        var entidad = new DotacionDTO();
                        entidad.CronogramaId = Id.ToString();
                        entidad.Id = datos.Id;
                        entidad.Elemento = ServicioBasicas.obtenerNombreParametro(datos.ElementoId);
                        entidad.FechaActualizacion = datos.FechaActualizacion;
                        entidad.Fechacreacion = datos.FechaCreacion;
                        entidad.Formato = ServicioBasicas.obtenerNombreParametro(datos.FormatoId);
                        entidad.Tipo = ServicioBasicas.obtenerNombreParametro(datos.TipoId);
                        entidad.TipoId = datos.TipoId.ToString();
                        entidad.UsuarioId = datos.UsuarioCreadorId;
                        entidad.Proveedor = datos.Prooveedor;
                        entidad.Descripcion = datos.Descripcion;
                        entidad.Marca = datos.Marca;
                        entidad.Referencia = datos.Referencia;
                        entidad.Serial = datos.Serial;
                        entidad.Garantia = datos.Garantia;
                        entidad.Precio = (decimal)datos.Precio;
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
        public static DotacionDTO ConsultarPorId(int Id)
        {
            try
            {
                var entidad = new DotacionDTO();
                var datos = DotacionConvenioServicio.ConsultarPorId(Id);
                if (datos != null)
                {
                    entidad.CronogramaId = datos.CronogramaId.ToString();
                    entidad.Id = datos.Id;
                    //entidad.Elemento = ServicioBasicas.obtenerNombreParametro(datos.ElementoId);
                    entidad.FechaActualizacion = datos.FechaActualizacion;
                    entidad.Fechacreacion = datos.FechaCreacion;
                    //entidad.Formato = ServicioBasicas.obtenerNombreParametro(datos.FormatoId);
                    //entidad.Tipo = ServicioBasicas.obtenerNombreParametro(datos.TipoId);
                    entidad.TipoId = datos.TipoId.ToString();
                    entidad.FormatoId = datos.FormatoId.ToString();
                    entidad.ElementoId = datos.ElementoId.ToString();
                    entidad.Marca = datos.Marca;
                    entidad.Precio = Convert.ToDecimal(datos.Precio);
                    entidad.Referencia = datos.Referencia;
                    entidad.Serial = datos.Serial;
                    entidad.Garantia = datos.Garantia;
                    entidad.Diagnostico = datos.Diagnostico;
                    entidad.UsuarioId = datos.UsuarioCreadorId;
                    entidad.Aprobado = (bool)datos.Aprobado;
                    entidad.Proveedor = datos.Prooveedor;
                    entidad.Descripcion = datos.Descripcion;
                }


                return entidad;
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

                DotacionConvenioServicio.Eliminar(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
    }
}
