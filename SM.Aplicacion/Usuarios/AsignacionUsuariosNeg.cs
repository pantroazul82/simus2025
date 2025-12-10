using SM.Datos.Usuario;
using SM.LibreriaComun.DTO;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Aplicacion.Usuarios
{
    public static class AsignacionUsuariosNeg
    {
        #region Actualizacion
        public static void AgregarSolicitud(decimal EscuelaId, int UsuarioSolicitudId, string CodMunicipio)
        {

            try
            {
                int intEscuela = Convert.ToInt32(EscuelaId);
                var registro = new ART_MUSICA_SOLICITUD_USUARIOS
                {
                    EscuelaId = intEscuela,
                    FechaSolicitud = DateTime.Now,
                    UsuarioId = UsuarioSolicitudId,
                    EstadoId = 1,
                    CodMunicipio = CodMunicipio

                };

                ServicioAsignacionUsuario.Crear(registro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public static void AgregarSolicitudConciertos(int EventoId, int UsuarioSolicitudId, string CodMunicipio)
        {

            try
            {
                var registro = new ART_MUSICA_SOLICITUD_USUARIOS
                {
                    EventoId = EventoId,
                    FechaSolicitud = DateTime.Now,
                    UsuarioId = UsuarioSolicitudId,
                    EstadoId = 1,
                    CodMunicipio = CodMunicipio

                };

                ServicioAsignacionUsuario.Crear(registro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public static void AsignarUsuario(decimal EscuelaId, string Correo)
        {
            try
            {
                UsuarioDTOSIM objUsuario = SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.obtenerUsuarioporEmailCelebra(Correo);
                if (objUsuario != null)
                {
                    ART_MUSICA_ENTIDAD_IDENTIFICACION registro = ServicioAsignacionUsuario.ObtenerEscuelaIdentificacion(EscuelaId);
                    registro.USU_ID = objUsuario.IdSipa;
                    ServicioAsignacionUsuario.ActualizarEscuela(registro);
                }

            }
            catch (Exception ex)
            { throw ex; }
        }

        public static void ActualizarSolicitudUsuario(int Id, int UsuarioAprobadorId)
        {
            try
            {
                decimal UsuarioSipaId;
                ART_MUSICA_SOLICITUD_USUARIOS registro = ServicioAsignacionUsuario.ObtenerSolicitudUsuario(Id);
                registro.EstadoId = 2;
                registro.FechaAprobacion = DateTime.Now;
                registro.UsuarioAprobador = UsuarioAprobadorId;

                UsuarioDTOSIM objUsuario = SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.obtenerUsuarioporId(registro.UsuarioId);
                UsuarioSipaId = SM.Datos.Usuario.ServicioUsuario.obtenerUsuarioSipaxCorreo(objUsuario.Email);
                ServicioAsignacionUsuario.Actualizar(registro, UsuarioSipaId);
              
              
              
            }
            catch (Exception ex)
            { throw ex; }

        }

        public static void ActualizarSolicitudUsuarioEvento(int Id, int UsuarioAprobadorId)
        {
            try
            {
             
                ART_MUSICA_SOLICITUD_USUARIOS registro = ServicioAsignacionUsuario.ObtenerSolicitudUsuario(Id);
                registro.EstadoId = 2;
                registro.FechaAprobacion = DateTime.Now;
                registro.UsuarioAprobador = UsuarioAprobadorId;

                ServicioAsignacionUsuario.ActualizarEvento(registro);

            }
            catch (Exception ex)
            { throw ex; }

        }

        #endregion

        #region Consultas
        public static List<SolicitudUsuarioDTO> ConsultarUsuariosPorEstado(int EstadoId)
        {
            List<SolicitudUsuarioDTO> listSolicitud = new List<SolicitudUsuarioDTO>();
            List<SM.Datos.DTO.SolicitudResultadoDTO> listResultado = ServicioAsignacionUsuario.ConsultarUsuariosPorEstado(EstadoId);
            try
            {

                foreach (var item in listResultado)
                {
                    var datos = new SolicitudUsuarioDTO();
                    datos.Id = item.Id;
                    datos.EstadoId = item.EstadoId;
                    datos.Departamento = item.Departamento;
                    datos.EscuelaId = item.EscuelaId;
                    datos.Estado = item.Estado;
                    datos.FechaSolicitud = item.FechaSolicitud;
                    datos.Municipio = item.Municipio;
                    datos.NombreEscuela = item.NombreEscuela;
                    datos.NombreUsuario = item.NombreUsuario;
                    datos.UsuarioId = item.UsuarioId;
                    datos.FechaSolicitud = item.FechaSolicitud;
                    datos.CorreoUsuario = item.CorreoUsuario;
                    listSolicitud.Add(datos);

                }

                return listSolicitud;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public static List<SolicitudUsuarioDTO> ConsultarEventosUsuariosPorEstado(int EstadoId)
        {
            List<SolicitudUsuarioDTO> listSolicitud = new List<SolicitudUsuarioDTO>();
            List<SM.Datos.DTO.SolicitudCelebraResultadoDTO> listResultado = ServicioAsignacionUsuario.ConsultarEventosUsuariosPorEstado(EstadoId);
            try
            {

                foreach (var item in listResultado)
                {
                    var datos = new SolicitudUsuarioDTO();
                    datos.Id = item.Id;
                    datos.EstadoId = item.EstadoId;
                    datos.Departamento = item.Departamento;
                    datos.EventoId = item.EventoId;
                    datos.Estado = item.Estado;
                    datos.FechaSolicitud = item.FechaSolicitud;
                    datos.Municipio = item.Municipio;
                    datos.EntidadOrganizadora = item.EntidadOrganizadora;
                    datos.NombreUsuario = item.NombreUsuario;
                    datos.UsuarioId = item.UsuarioId;
                    datos.FechaSolicitud = item.FechaSolicitud;
                    datos.CorreoUsuario = item.CorreoUsuario;
                    listSolicitud.Add(datos);

                }

                return listSolicitud;
            }
            catch (Exception ex)
            { throw ex; }
        }
        #endregion
    }
}
