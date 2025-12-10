using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SM.Datos.DTO;
using SM.SIPA;
using SM.Datos.Agentes;
using System.Data.SqlClient;
using SM.Datos.AuditoriaData;
using SM.LibreriaComun.DTO.WSDepartamento;
using SM.Datos.Helper;

namespace SM.Datos.Departamentos
{
    public class WSDepartamentoServicio
    {
        #region consultaWebAPI

        public static List<AgenteWSDTO> ConsultarWebApiAgentes(string usuario, string contrasena, out string mensajeError)
        {
            List<AgenteWSDTO> ListEntidades = new List<AgenteWSDTO>();
            string codigoDepartamento = "";
            try
            {
                codigoDepartamento = UsuarioWsService.ValidaUsuario(usuario, contrasena);

                if (string.IsNullOrEmpty(codigoDepartamento))
                {
                    mensajeError = "Usuario y/o contrasena invalido";

                }
                else
                {
                    mensajeError = "";
                    using (var context = new SIPAEntities())
                    {

                        ListEntidades = (from a in context.ART_MUSICA_AGENTE
                                         join z in context.BAS_ZONAS_GEOGRAFICAS on a.CodMunicipio equals z.ZON_ID
                                         join d in context.BAS_ZONAS_GEOGRAFICAS on a.CodigoDepartamento equals d.ZON_ID
                                         join t in context.BAS_TIPOS_DOCUMENTOS_IDENTIDAD on a.CodTipoDocumento equals t.DOC_ID
                                         where a.EstadoId == 2
                                         where a.CodigoDepartamento == codigoDepartamento
                                         select new AgenteWSDTO
                                         {
                                             AgenteId = a.ID,
                                             CodigoDepartamento = d.ZON_ID,
                                             CodigoMunicipio = a.CodMunicipio,
                                             CorreoElectronico = a.CorreoElectronico,
                                             Direccion = a.Direccion,
                                             FechaActualizacion = a.FechaActualizacion,
                                             FechaCreacion = a.FechaCreacion,
                                             PrimerNombre = a.PrimerNombre,
                                             SegundoNombre = a.SegundoNombre,
                                             PrimerApellido = a.PrimerApellido,
                                             SegundoApellido = a.SedundoApellido,
                                             LinkPortafolio = a.LinkPortafolio,
                                             Telefono = a.Telefono,
                                             Descripcion = a.Descripcion,
                                             Departamento = d.ZON_NOMBRE,
                                             Municipio = z.ZON_NOMBRE,
                                             CodigoTipoDocumento = t.CODIGO,
                                             Identificacion = a.Identificacion,
                                             NombreArtistico = a.NombreArtistico,
                                             FechaNacimiento = a.FechaNacimiento ?? DateTime.Now
                                         }).ToList();


                    }
                }
                return ListEntidades;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<WSEntidadDTO> ConsultarWebApiEntidades(string usuario, string contrasena, out string mensajeError)
        {
            List<WSEntidadDTO> ListEntidades = new List<WSEntidadDTO>();
            string codigoDepartamento = "";
            try
            {
                codigoDepartamento = UsuarioWsService.ValidaUsuario(usuario, contrasena);

                if (string.IsNullOrEmpty(codigoDepartamento))
                {
                    mensajeError = "Usuario y/o contrasena invalido";

                }
                else
                {
                    mensajeError = "";
                    using (var context = new SIPAEntities())
                    {

                        ListEntidades = (from a in context.ART_MUSICA_ENTIDADES
                                         join z in context.BAS_ZONAS_GEOGRAFICAS on a.CodigoMunicipio equals z.ZON_ID
                                         join d in context.BAS_ZONAS_GEOGRAFICAS on z.ZON_PADRE_ID equals d.ZON_ID
                                         where d.ZON_ID == codigoDepartamento
                                         select new WSEntidadDTO
                                         {
                                             EntidadId = a.Id,
                                             CodigoDepartamento = d.ZON_ID,
                                             CodigoMunicipio = z.ZON_ID,
                                             CorreoElectronico = a.CorreoElectronico,
                                             Direccion = a.Direccion,
                                             FechaActualizacion = a.FechaActualizacion,
                                             FechaCreacion = a.FechaCreacion,
                                             Nombre = a.Nombre,
                                             Nit = a.Nit,
                                             DigitoVerificacion = ((a.DigitoVerificacion == null) ? 0 : (int)a.DigitoVerificacion),
                                             LinkPortafolio = a.LinkPortafolio,
                                             Telefono = a.Telefono,
                                             Descripcion = a.Descripcion,
                                             TipoEntidad = ""

                                         }).ToList();


                    }
                }
                return ListEntidades;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<WSEscuelaDTO> ConsultarWebApiEscuelas(string usuario, string contrasena, out string mensajeError)
        {
            List<WSEscuelaDTO> ListEntidades = new List<WSEscuelaDTO>();
            string codigoDepartamento = "";
            try
            {
                codigoDepartamento = UsuarioWsService.ValidaUsuario(usuario, contrasena);

                if (string.IsNullOrEmpty(codigoDepartamento))
                {
                    mensajeError = "Usuario y/o contrasena invalido";

                }
                else
                {
                    mensajeError = "";
                    using (var context = new SIPAEntities())
                    {

                        ListEntidades = (from a in context.ART_ENTIDADES_ARTES
                                         join u in context.ART_ENTIDAD_UBICACION on a.ENT_ID equals u.ENT_ID
                                         join i in context.ART_MUSICA_ENTIDAD_IDENTIFICACION on a.ENT_ID equals i.ENT_ID
                                         join z in context.BAS_ZONAS_GEOGRAFICAS on u.ZON_ID equals z.ZON_ID
                                         join d in context.BAS_ZONAS_GEOGRAFICAS on z.ZON_PADRE_ID equals d.ZON_ID
                                         where d.ZON_ID == codigoDepartamento
                                         where a.ENT_TIPO == "E"
                                         where i.EstadoId == 2
                                         select new WSEscuelaDTO
                                        {
                                            AnoConstitucion = a.ENT_ANO_CONSTITUCION ?? 0,
                                            Area = (u.ARE_ID == 5 ? "Rural" : "Urbana"),
                                            CargoContacto = a.ENT_CARGO_CONTACTO,
                                            CodigoDepartamento = d.ZON_ID,
                                            CodigoMunicipio = z.ZON_ID,
                                            CorreoElectronicoContacto = i.ENT_CONTACTO_CORREO,
                                            CorreoElectronicoEscuela = u.ENT_CORREO_ELECTRONICO_ENTIDAD,
                                            Direccion = u.ENT_DIRECCION,
                                            EscuelaId = a.ENT_ID,
                                            Nit = a.ENT_NIT,
                                            NombreContacto = a.ENT_NOMBRE_CONTACTO,
                                            NombreEscuela = a.ENT_NOMBRE,
                                            Resena = a.ENT_RESENA,
                                            SitioWeb = u.ENT_PAGINA_WEB,
                                            TelefonoContacto = i.ENT_TELEFONOS,
                                            Telefono = u.ENT_TELEFONO,
                                            FechaActualizacion = a.ENT_FECHA_ACTUALIZACION
                                        }).ToList();

                    }
                }
                return ListEntidades;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<WSEventoDTO> ConsultarWebApiEventos(string usuario, string contrasena, out string mensajeError)
        {
            List<WSEventoDTO> ListEntidades = new List<WSEventoDTO>();
            string codigoDepartamento = "";
            try
            {
                codigoDepartamento = UsuarioWsService.ValidaUsuario(usuario, contrasena);

                if (string.IsNullOrEmpty(codigoDepartamento))
                {
                    mensajeError = "Usuario y/o contrasena invalido";

                }
                else
                {
                    mensajeError = "";
                    using (var context = new SIPAEntities())
                    {

                        ListEntidades = (from e in context.ART_MUSICA_MODULO_SERVICIOS
                                         join p in context.ART_MUSICA_PARAMETROS_SERVICIOS on e.TipoEventoId equals p.Id
                                         where e.EstadoId == 2
                                         where e.EsActivo == true
                                         where e.TipoServicioId == 50
                                         where e.CodDepto == codigoDepartamento
                                         orderby e.Titulo
                                         select new WSEventoDTO
                                 {
                                    Clasificacion = p.Nombre,
                                    CodigoDepartamento = e.CodDepto,
                                    CodigoMunicipio = e.CodMunicipio,
                                    CorreoElectronico = e.Email,
                                    Contacto = e.Contacto,
                                    EntidadOrganizadora = e.NombreActor,
                                    Departamento = e.Departamento,
                                    Descripcion = e.Descripcion,
                                    Direccion = e.Direccion,
                                    FechaActualizacion = e.FechaActualizacion,
                                    FechaCreacion = e.FechaCreacion,
                                    FechaFinal = e.FechaFin,
                                    FechaInicio = e.FechaInicio,
                                    EventoId = e.Id,
                                    Municipio = e.Municipio,
                                    Telefono = e.Telefono,
                                    Titulo = e.Titulo,
                                    TipoActor = e.TipoActor,
                                    PaginaWeb = e.PaginaWeb 
                                 }).ToList();

                        return ListEntidades;

                    }
                }
                return ListEntidades;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
