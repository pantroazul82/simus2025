using SM.Datos.Notificaciones;
using SM.LibreriaComun.DTO.Notificacion;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Aplicacion.Notificacion
{
    public class NotificacionNeg
    {
        #region Actualizacion

        public static int Crear(NotificacionDTO model)
        {
            int registroId = 0;
            try
            {


                var registro = new ART_MUSICA_MOTIVO_HISTORICO
                {
                    EstadoId = model.EstadoId,
                    NombreEstado = model.NombreEstado,
                    Modulo = model.Modulo,
                    Motivo = model.Motivo,
                    NombreUsuario = model.NombreUsuario,
                    FechaRegistro = DateTime.Now,
                    Tipo = model.Tipo,
                    UsuarioId = model.UsuarioId

                };

                if (model.Modulo == "Agentes")
                    registro.AgenteId = model.RegistroId;
                else if (model.Modulo == "Agrupaciones")
                    registro.AgrupacionId = model.RegistroId;
                else if (model.Modulo == "Entidades")
                    registro.EntidadId = model.RegistroId;
                else if (model.Modulo == "Escuelas")
                    registro.EscuelaId = model.RegistroId;

                registroId = NotificacionServicio.Agregar(registro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return registroId;
        }

        #endregion

        #region Consulta

        public static NotificacionDTO ConsultarPorId(int Id)
        {
            try
            {
                var datos = new NotificacionDTO();
                var model = NotificacionServicio.ConsultarPorId(Id);

                if (model != null)
                {

                    if (model.AgenteId != null && model.AgenteId > 0)
                        datos.RegistroId = model.AgenteId ?? 0;
                    else if (model.AgrupacionId != null && model.AgrupacionId > 0)
                        datos.RegistroId = model.AgrupacionId ?? 0;
                    else if (model.EntidadId != null && model.EntidadId > 0)
                        datos.RegistroId = model.EntidadId ?? 0;
                    else if (model.EscuelaId != null && model.EscuelaId > 0)
                        datos.RegistroId = Convert.ToInt32(model.EscuelaId);

                    datos.Modulo = model.Modulo;
                    datos.Motivo = model.Motivo;
                    datos.NombreEstado = model.NombreEstado;
                    datos.NombreUsuario = model.NombreUsuario;
                    datos.Tipo = model.Tipo;
                    datos.UsuarioId = model.UsuarioId;
                    datos.FechaRegistro = model.FechaRegistro.ToString("dd/MM/yyyy");
                    datos.Id = model.Id;
                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<NotificacionDTO> ConsultarPorAgrupacionId(int Id)
        {
            try
            {
                var listado = new List<NotificacionDTO>();
                var model = NotificacionServicio.ConsultarPorAgrupacionId(Id);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new NotificacionDTO();
                        datos.Modulo = item.Modulo;
                        datos.Motivo = item.Motivo;
                        datos.NombreEstado = item.NombreEstado;
                        datos.NombreUsuario = item.NombreUsuario;
                        datos.Tipo = item.Tipo;
                        datos.UsuarioId = item.UsuarioId;
                        datos.FechaRegistro = item.FechaRegistro.ToString("dd/MM/yyyy");
                        datos.RegistroId = item.AgrupacionId ?? 0;
                        datos.Id = item.Id;
                        listado.Add(datos);
                    }
                   
                  
                }


                return listado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<NotificacionDTO> ConsultarPorAgenteId(int Id)
        {
            try
            {
                var listado = new List<NotificacionDTO>();
                var model = NotificacionServicio.ConsultarPorAgenteId(Id);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new NotificacionDTO();
                        datos.Modulo = item.Modulo;
                        datos.Motivo = item.Motivo;
                        datos.NombreEstado = item.NombreEstado;
                        datos.NombreUsuario = item.NombreUsuario;
                        datos.Tipo = item.Tipo;
                        datos.UsuarioId = item.UsuarioId;
                        datos.FechaRegistro = item.FechaRegistro.ToString("dd/MM/yyyy");
                        datos.RegistroId = item.AgrupacionId ?? 0;
                        datos.Id = item.Id;
                        listado.Add(datos);
                    }


                }


                return listado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<NotificacionDTO> ConsultarPorEntidadId(int Id)
        {
            try
            {
                var listado = new List<NotificacionDTO>();
                var model = NotificacionServicio.ConsultarPorEntidadId(Id);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new NotificacionDTO();
                        datos.Modulo = item.Modulo;
                        datos.Motivo = item.Motivo;
                        datos.NombreEstado = item.NombreEstado;
                        datos.NombreUsuario = item.NombreUsuario;
                        datos.Tipo = item.Tipo;
                        datos.UsuarioId = item.UsuarioId;
                        datos.FechaRegistro = item.FechaRegistro.ToString("dd/MM/yyyy");
                        datos.RegistroId = item.AgrupacionId ?? 0;
                        datos.Id = item.Id;
                        listado.Add(datos);
                    }


                }


                return listado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<NotificacionDTO> ConsultarPorEscuelaId(int Id)
        {
            try
            {
                var listado = new List<NotificacionDTO>();
                var model = NotificacionServicio.ConsultarPorEscuelaId(Id);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new NotificacionDTO();
                        datos.Modulo = item.Modulo;
                        datos.Motivo = item.Motivo;
                        datos.NombreEstado = item.NombreEstado;
                        datos.NombreUsuario = item.NombreUsuario;
                        datos.Tipo = item.Tipo;
                        datos.UsuarioId = item.UsuarioId;
                        datos.FechaRegistro = item.FechaRegistro.ToString("dd/MM/yyyy");
                        datos.RegistroId = item.AgrupacionId ?? 0;
                        datos.Id = item.Id;
                        listado.Add(datos);
                    }


                }


                return listado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
