using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.Datos.Entidades;
using SM.SIPA;
using SM.LibreriaComun.DTO;
using SM.Datos.DTO;
using SM.Datos.Agrupacion;
using SM.LibreriaComun.DTO.WSDepartamento;

namespace SM.Aplicacion.Agrupacion
{
    public class AgrupacionNeg
    {

        #region WEBAPI
        public static List<AgrupacionWSDTO> ConsultarWebApiAgrupaciones(string usuario, string contrasena, out string Mensaje)
        {
            var lisParametro = new List<AgrupacionWSDTO>();
            try
            {
                string strMensajeError = "";
                lisParametro = AgrupacionServicio.ConsultarWebApiAgrupaciones(usuario, contrasena, out strMensajeError);
                lisParametro = lisParametro.OrderBy(d => d.Nombre).ToList();
                Mensaje = strMensajeError;
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lisParametro;
        }

        #endregion
        #region Consultas

        public static void AgregarGenero(int AgrupacionId,
                                     string strAtributo)
        {
            int GeneroId = 0;
            try
            {
                GeneroId = SM.Datos.Basicas.CaracterizacionMusicalServicio.ObtenerGeneroId(strAtributo);

                var registro = new ART_MUSICA_AGRUPACION_GENEROS();
                registro.AgrupacionId = AgrupacionId;
                registro.GeneroId = GeneroId;
                registro.Atributo = strAtributo;
                AgrupacionServicio.AgregarAgrupacionGenero(registro);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EstandarDTO> ConsultarGenerosPorAgrupacionId(int AgrupacionId)
        {
            var lisParametro = new List<EstandarDTO>();
            try
            {
                List<Parametro> Parametrodatos = AgrupacionServicio.ConsultarGenerosPorAgrupacionId(AgrupacionId);

                foreach (var item in Parametrodatos)
                {
                    EstandarDTO objParametro = new EstandarDTO();
                    objParametro.Id = item.Id.ToString();
                    objParametro.Nombre = item.Nombre;
                    lisParametro.Add(objParametro);
                }

                lisParametro = lisParametro.OrderBy(d => d.Nombre).ToList();

                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<AgrupacionDataDTO> ConsultarAgrupacionTodos()
        {
            try
            {
                var model = new List<AgrupacionResultadoDTO>();
                var listResultado = new List<AgrupacionDataDTO>();
                model = AgrupacionServicio.ConsultarAgrupacionObtenerTodos();

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new AgrupacionDataDTO();
                        datos.AgrupacionId = item.AgrupacionId;
                        datos.Departamento = item.Departamento;
                        datos.Municipio = item.Municipio;
                        datos.Nombre = item.Nombre;
                        datos.TipoAgrupacion = item.TipoAgrupacion;
                        datos.Estado = item.Estado;
                        datos.FechaActualizacion = item.FechaActualizacion;
                        datos.FechaCreacion = item.FechaCreacion;
                        listResultado.Add(datos);
                    }

                }


                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<AgrupacionHomeDataDTO> ConsultarAgrupacionHomeTodos()
        {
            try
            {
                var model = new List<AgrupacionHomeDTO>();
                var listResultado = new List<AgrupacionHomeDataDTO>();
                model = AgrupacionServicio.ConsultarAgrupacionHome();

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new AgrupacionHomeDataDTO();
                        datos.ID = item.ID;
                        datos.CodigoDepartamento = item.CodigoDepartamento;
                        datos.CodigoMunicipio = item.CodigoMunicipio;
                        datos.CodigoPais = item.CodigoPais;
                        datos.Imagen = item.Imagen;
                        datos.PaginaWeb = item.PaginaWeb;
                        datos.Departamento = item.Departamento;
                        datos.Pais = item.Pais;
                        datos.Municipio = item.Municipio;
                        datos.Nombres = item.Nombres;
                        datos.PerfilFacebook = item.PerfilFacebook;
                        datos.PerfilSoundCloud = item.PerfilSoundCloud;
                        datos.PerfilTwitter = item.PerfilTwitter;
                        datos.CanalYoutube = item.CanalYoutube;
                        datos.Genero = item.Genero;
                        datos.Tipo = item.Tipo;
                        datos.TipoAgrupacionId = item.TipoAgrupacionId;
                        listResultado.Add(datos);
                    }

                }


                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<AgrupacionHomeDataDTO> ConsultarAgrupacionHomePorDepartamento(string codDepto)
        {
            try
            {
                var model = new List<AgrupacionHomeDTO>();
                var listResultado = new List<AgrupacionHomeDataDTO>();
                model = AgrupacionServicio.ConsultarAgrupacionHomePorDepartamento(codDepto);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new AgrupacionHomeDataDTO();
                        datos.ID = item.ID;
                        datos.CodigoDepartamento = item.CodigoDepartamento;
                        datos.CodigoMunicipio = item.CodigoMunicipio;
                        datos.CodigoPais = item.CodigoPais;
                        datos.Imagen = item.Imagen;
                        datos.PaginaWeb = item.PaginaWeb;
                        datos.Departamento = item.Departamento;
                        datos.Pais = item.Pais;
                        datos.Municipio = item.Municipio;
                        datos.Nombres = item.Nombres;
                        datos.PerfilFacebook = item.PerfilFacebook;
                        datos.PerfilSoundCloud = item.PerfilSoundCloud;
                        datos.PerfilTwitter = item.PerfilTwitter;
                        datos.CanalYoutube = item.CanalYoutube;
                        datos.Genero = item.Genero;
                        datos.Tipo = item.Tipo;
                        datos.TipoAgrupacionId = item.TipoAgrupacionId;
                        listResultado.Add(datos);
                    }

                }


                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<AgrupacionHomeDataDTO> ConsultarAgrupacionHomePorMunicipio(string codMunicipio)
        {
            try
            {
                var model = new List<AgrupacionHomeDTO>();
                var listResultado = new List<AgrupacionHomeDataDTO>();
                model = AgrupacionServicio.ConsultarAgrupacionHomePorMunicipio(codMunicipio);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new AgrupacionHomeDataDTO();
                        datos.ID = item.ID;
                        datos.CodigoDepartamento = item.CodigoDepartamento;
                        datos.CodigoMunicipio = item.CodigoMunicipio;
                        datos.CodigoPais = item.CodigoPais;
                        datos.Imagen = item.Imagen;
                        datos.PaginaWeb = item.PaginaWeb;
                        datos.Departamento = item.Departamento;
                        datos.Pais = item.Pais;
                        datos.Municipio = item.Municipio;
                        datos.Nombres = item.Nombres;
                        datos.PerfilFacebook = item.PerfilFacebook;
                        datos.PerfilSoundCloud = item.PerfilSoundCloud;
                        datos.PerfilTwitter = item.PerfilTwitter;
                        datos.CanalYoutube = item.CanalYoutube;
                        datos.Genero = item.Genero;
                        datos.Tipo = item.Tipo;
                        datos.TipoAgrupacionId = item.TipoAgrupacionId;
                        listResultado.Add(datos);
                    }

                }


                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int ObteneragenteId(int tipodocumentoId, string identificacion)
        {
            try
            {
                int AgenteId = 0;

                AgenteId = AgrupacionServicio.ObteneragenteId(tipodocumentoId, identificacion);

                return AgenteId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static AgenteDTO ObteneragentePorDocumento(int tipodocumentoId, string identificacion)
        {
            try
            {
                var model = new ART_MUSICA_AGENTE();
                var datos = new AgenteDTO();
                model = AgrupacionServicio.ObteneragentePorDocumento(tipodocumentoId, identificacion);

                if (model != null)
                {
                    datos.PrimerApellido = model.PrimerApellido;
                    datos.PrimerNombre = model.PrimerNombre;
                    datos.SegundoApellido = model.SedundoApellido;
                    datos.SegundoNombre = model.SegundoNombre;
                }

                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<AgrupacionDataDTO> ConsultarAgrupacionPorEstadoId(int EstadoId)
        {
            try
            {
                var model = new List<AgrupacionResultadoDTO>();
                var listResultado = new List<AgrupacionDataDTO>();
                model = AgrupacionServicio.ConsultarAgrupacionPorEstadoId(EstadoId);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new AgrupacionDataDTO();
                        datos.AgrupacionId = item.AgrupacionId;
                        datos.CodigoDepartamento = item.CodigoDepartamento;
                        datos.CodigoMunicipio = item.CodigoMunicipio;
                        datos.CodigoPais = item.CodigoPais;
                        datos.CorreoElectronico = item.CorreoElectronico;
                        datos.Direccion = item.Direccion;
                        datos.Imagen = item.Imagen;
                        datos.LinkPortafolio = item.LinkPortafolio;
                        datos.Departamento = item.Departamento;
                        datos.Pais = item.Pais;
                        datos.Municipio = item.Municipio;
                        datos.CODIGO = item.CODIGO;
                        datos.DOC_NOMBRE = item.DOC_NOMBRE;
                        datos.Identificacion = item.Identificacion;
                        datos.Descripcion = item.Descripcion;
                        datos.NombreDirector = item.NombreDirector;
                        datos.ApellidoDirector = item.ApellidoDirector;
                        datos.Nombre = item.Nombre;
                        datos.TipoAgrupacion = item.TipoAgrupacion;
                        datos.Telefono = item.Telefono;
                        datos.Estado = item.Estado;
                        datos.FechaActualizacion = item.FechaActualizacion;
                        datos.FechaCreacion = item.FechaCreacion;
                        listResultado.Add(datos);
                    }

                }


                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<AgrupacionDataDTO> ConsultarAgrupacionPorMunicipio(int UsuarioID)
        {
            try
            {
                var model = new List<AgrupacionResultadoDTO>();
                var listResultado = new List<AgrupacionDataDTO>();
                model = AgrupacionServicio.ConsultarAgrupacionPorMunicipioNuevo(UsuarioID);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new AgrupacionDataDTO();
                        datos.AgrupacionId = item.AgrupacionId;
                        datos.Departamento = item.Departamento;
                        datos.Municipio = item.Municipio;
                        datos.Nombre = item.Nombre;
                        datos.TipoAgrupacion = item.TipoAgrupacion;
                        datos.Estado = item.Estado;
                        datos.FechaActualizacion = item.FechaActualizacion;
                        datos.FechaCreacion = item.FechaCreacion;
                        listResultado.Add(datos);
                    }

                }


                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<AgrupacionDataDTO> ConsultarAgrupacionPorUsuarioId(int UsuarioID)
        {
            try
            {
                var model = new List<AgrupacionResultadoDTO>();
                var listResultado = new List<AgrupacionDataDTO>();
                model = AgrupacionServicio.ConsultarAgrupacionPorUsuarioId(UsuarioID);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new AgrupacionDataDTO();
                        datos.AgrupacionId = item.AgrupacionId;
                        datos.CodigoDepartamento = item.CodigoDepartamento;
                        datos.CodigoMunicipio = item.CodigoMunicipio;
                        datos.CodigoPais = item.CodigoPais;
                        datos.CorreoElectronico = item.CorreoElectronico;
                        datos.Direccion = item.Direccion;
                        datos.Imagen = item.Imagen;
                        datos.LinkPortafolio = item.LinkPortafolio;
                        datos.Departamento = item.Departamento;
                        datos.Pais = item.Pais;
                        datos.Municipio = item.Municipio;
                        datos.CODIGO = item.CODIGO;
                        datos.DOC_NOMBRE = item.DOC_NOMBRE;
                        datos.Identificacion = item.Identificacion;
                        datos.Descripcion = item.Descripcion;
                        datos.NombreDirector = item.NombreDirector;
                        datos.ApellidoDirector = item.ApellidoDirector;
                        datos.Nombre = item.Nombre;
                        datos.TipoAgrupacion = item.TipoAgrupacion;
                        datos.Telefono = item.Telefono;
                        datos.Estado = item.Estado;
                        datos.FechaActualizacion = item.FechaActualizacion;
                        datos.FechaCreacion = item.FechaCreacion;
                        listResultado.Add(datos);
                    }

                }


                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static AgrupacionDTO ConsultarAgrupacionPorId(int agrupacionId)
        {
            try
            {
                var model = new ART_MUSICA_AGRUPACION();
                var datos = new AgrupacionDTO();
                model = AgrupacionServicio.ConsultarAgrupacionPorId(agrupacionId);

                if (model != null)
                {
                    datos.ArtMusicaUsuarioId = model.ArtMusicaUsuarioId;
                    datos.CodigoDepartamento = model.CodigoDepartamento;
                    datos.CodigoMunicipio = model.CodigoMunicipio;
                    datos.CodigoPais = model.CodigoPais;
                    datos.CorreoElectronico = model.CorreoElectronico;
                    datos.Descripcion = model.Descripcion;
                    datos.Direccion = model.Direccion;
                    datos.EstadoId = model.EstadoId;
                    datos.FechaActualizacion = model.FechaActualizacion;
                    datos.FechaCreacion = model.FechaCreacion;
                    datos.AgrupacionId = model.Id;
                    datos.imagen = model.Imagen;
                    datos.Latitud = model.Latitud;
                    datos.linkPortafolio = model.LinkPortafolio;
                    datos.Longitud = model.Longitud;
                    datos.TipoAgrupacionId = model.TipoAgrupacionId;
                    datos.Nombre = model.Nombre;
                    datos.Telefono = model.Telefono;
                    datos.DocumentoId = model.DocumentoId ?? 0;
                    datos.NaturalezaId = model.NaturalezaId;
                    datos.AreaId = model.ARE_ID ?? 0;
                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static AgrupacionDataDTO ConsultarDatosAgrupacionPorId(int agrupacionId)
        {
            try
            {
                var model = new AgrupacionResultadoDTO();
                var datos = new AgrupacionDataDTO();
                model = AgrupacionServicio.ConsultarDatosAgrupacionPorId(agrupacionId);

                if (model != null)
                {
                    datos.AgrupacionId = model.AgrupacionId;
                    datos.CodigoDepartamento = model.CodigoDepartamento;
                    datos.CodigoMunicipio = model.CodigoMunicipio;
                    datos.CodigoPais = model.CodigoPais;
                    datos.CorreoElectronico = model.CorreoElectronico;
                    datos.Direccion = model.Direccion;
                    datos.Imagen = model.Imagen;
                    datos.LinkPortafolio = model.LinkPortafolio;
                    datos.Departamento = model.Departamento;
                    datos.Pais = model.Pais;
                    datos.Municipio = model.Municipio;
                    datos.CODIGO = model.CODIGO;
                    datos.DOC_NOMBRE = model.DOC_NOMBRE;
                    datos.Identificacion = model.Identificacion;
                    datos.Descripcion = model.Descripcion;
                    datos.NombreDirector = model.NombreDirector;
                    datos.ApellidoDirector = model.ApellidoDirector;
                    datos.Nombre = model.Nombre;
                    datos.TipoAgrupacion = model.TipoAgrupacion;
                    datos.Telefono = model.Telefono;
                    datos.Estado = model.Estado;
                    datos.FechaActualizacion = model.FechaActualizacion;
                    datos.FechaCreacion = model.FechaCreacion;
                    datos.DocumentoId = model.DocumentoId ?? 0;
                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Actualizacion

        public static void EliminarAgrupaciongenero(int AgrupacionGeneroId)
        {
            try
            { AgrupacionServicio.EliminarAgrupaciongenero(AgrupacionGeneroId); }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void AgregarAgente(int AgrupacionId, int AgenteId)
        {
            try
            {
                AgrupacionServicio.AgregarAgente(AgrupacionId, AgenteId);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void ActualizarAgrupacionDocumento(int AgrupacionId, int DocumentoId)
        {
            try
            {
                AgrupacionServicio.ActualizarAgrupacionDocumento(AgrupacionId, DocumentoId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int CrearAgrupacion(AgrupacionDTO agrupacion, string NombreUsuario, string strIP)
        {
            int AgrupacionId = 0;
            try
            {

                AgrupacionId = AgrupacionServicio.CrearAgrupacion(agrupacion.ArtMusicaUsuarioId,
                                                     agrupacion.Nombre,
                                                     agrupacion.TipoAgrupacionId,
                                                     agrupacion.CodigoPais,
                                                     agrupacion.CodigoMunicipio,
                                                     agrupacion.CodigoDepartamento,
                                                     agrupacion.Direccion,
                                                     agrupacion.CorreoElectronico,
                                                     agrupacion.Telefono,
                                                     agrupacion.linkPortafolio,
                                                     agrupacion.imagen,
                                                     agrupacion.Descripcion,
                                                     agrupacion.NaturalezaId,
                                                     agrupacion.AreaId,
                                                     NombreUsuario,
                                                     strIP);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return AgrupacionId;
        }

        public static void ActualizarAgrupacion(AgrupacionDTO agrupacion, int AgrupacionId, bool cambiar, string NombreUsuario, string strIP)
        {
            try
            {

                if (cambiar)
                {
                    AgrupacionServicio.ActualizarAgrupacionEstado(AgrupacionId,
                                                    agrupacion.ArtMusicaUsuarioId,
                                                    agrupacion.Nombre,
                                                    agrupacion.TipoAgrupacionId,
                                                    agrupacion.CodigoPais,
                                                    agrupacion.CodigoMunicipio,
                                                    agrupacion.CodigoDepartamento,
                                                    agrupacion.Direccion,
                                                    agrupacion.CorreoElectronico,
                                                    agrupacion.Telefono,
                                                    agrupacion.linkPortafolio,
                                                    agrupacion.imagen,
                                                    agrupacion.Descripcion,
                                                    agrupacion.EstadoId,
                                                    agrupacion.NaturalezaId,
                                                      NombreUsuario,
                                                    strIP);
                }
                else
                {
                    AgrupacionServicio.ActualizarAgrupacion(AgrupacionId,
                                                        agrupacion.ArtMusicaUsuarioId,
                                                        agrupacion.Nombre,
                                                        agrupacion.TipoAgrupacionId,
                                                        agrupacion.CodigoPais,
                                                        agrupacion.CodigoMunicipio,
                                                        agrupacion.CodigoDepartamento,
                                                        agrupacion.Direccion,
                                                        agrupacion.CorreoElectronico,
                                                        agrupacion.Telefono,
                                                        agrupacion.linkPortafolio,
                                                        agrupacion.imagen,
                                                        agrupacion.Descripcion,
                                                        agrupacion.NaturalezaId,
                                                        agrupacion.AreaId,
                                                        NombreUsuario,
                                                        strIP);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public static void EliminarAgenteAgrupacion(int AgenteAgrupacionId)
        {
            try
            {
                AgrupacionServicio.EliminarAgenteAgrupacion(AgenteAgrupacionId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
