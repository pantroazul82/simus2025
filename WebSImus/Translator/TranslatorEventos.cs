using SM.Aplicacion.Eventos;
using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSImus.Models;

namespace WebSImus.Translator
{
    public class TranslatorEventos
    {
        const string ImagenPublicaConcierto = "~/img/logo_crear_concierto.png";
        public static EventoModels ConsultaEventoPorId(int Id)
        {
            try
            {
                var model = new EventoDTO();
                var datos = new EventoModels();
                model = EventosNeg.ConsultarEventoPorId(Id);

                if (model != null)
                {
                    datos.ArtMusicaUsuarioId = model.UsuarioId;
                    datos.CodigoDepartamento = model.CodDepartamento;
                    datos.CodigoMunicipio = model.CodMunicipio;
                    datos.Descripcion = model.Descripción;
                    datos.EstadoId = model.EstadoId.ToString();
                    datos.FechaEvento = model.FechaEvento.ToString("yyy-MM-dd");
                    datos.HoraEvento = model.FechaEvento.ToString("hh:mm tt");
                    datos.Imagen = model.Imagen;
                    datos.Nombre = model.Nombre;
                    datos.EntidadOrganizadora = model.EntidadOrganizadora;
                    datos.LugarEvento = model.LugarEvento;
                    datos.Departamento = model.NombreDepartamento;
                    datos.Municipio = model.NombreMunicipio;
                    datos.Tipo = model.Tipo;
                    datos.Id = model.Id;
                    datos.Telefono = model.Telefono;
                    datos.Email = model.Email;
                    datos.EsDestacado = model.Destacado;
                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EventoPadreModels> ConsultarProgramacionConciertosMusica(string anoEvento, string codigoMunicipio)
        {
            try
            {
                var model = new List<EventoDTO>();
                var listResultado = new List<EventoPadreModels>();
                model = EventosNeg.ConsultarProgramacionConciertosMusica(Convert.ToInt32(anoEvento), codigoMunicipio);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new EventoModels();
                        var padre = new EventoPadreModels();
                        datos.ArdId = item.AreaArtisticaId;
                        datos.CodigoDepartamento = item.CodDepartamento;
                        datos.CodigoMunicipio = item.CodMunicipio;
                        datos.Descripcion = item.Descripción;
                        datos.EntidadOrganizadora = item.EntidadOrganizadora;
                        datos.FechaEvento = item.FechaEvento.ToString("yyyy-MM-dd");
                        datos.HoraEvento = item.FechaEvento.ToString("hh:mm tt");
                        datos.Id = item.Id;
                        if (item.Imagen != null)
                        {
                            string imageBase64Data = Convert.ToBase64String(item.Imagen);
                            string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                            datos.imageDataURL = imageDataURL;

                        }
                        else
                            datos.imageDataURL = ImagenPublicaConcierto;
                        datos.LugarEvento = item.LugarEvento;
                        datos.Nombre = item.Nombre;
                        datos.Tipo = item.Tipo;
                        datos.Municipio = item.NombreMunicipio;
                        datos.Departamento = item.NombreDepartamento;
                        datos.Telefono = item.Telefono;
                        datos.Email = item.Email;
                        datos.EsDestacado = item.Destacado;

                        padre.DatosBasicos = datos;
                        padre.listArtista = ConsultaArtistasPorEventoId(datos.Id);
                        listResultado.Add(padre);
                    }
                }


                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static EventoDanzaModels ConsultaDanzaEventoPorId(int Id)
        {
            try
            {
                var model = new EventoDTO();
                var datos = new EventoDanzaModels();
                model = EventosNeg.ConsultarEventoPorId(Id);
                DateTime datFechaFinal;

                if (model != null)
                {
                    datFechaFinal = Convert.ToDateTime(model.FechaEventoFinal);
                    datos.ArtMusicaUsuarioId = model.UsuarioId;
                    datos.CodigoDepartamento = model.CodDepartamento;
                    datos.CodigoMunicipio = model.CodMunicipio;
                    datos.Descripcion = model.Descripción;
                    datos.EstadoId = model.EstadoId.ToString();
                    datos.FechaEvento = model.FechaEvento.ToString("yyyy-MM-dd");
                    datos.HoraEvento = model.FechaEvento.ToString("hh:mm tt");
                    datos.Imagen = model.Imagen;
                    datos.Nombre = model.Nombre;
                    datos.EntidadOrganizadora = model.EntidadOrganizadora;
                    datos.LugarEvento = model.LugarEvento;
                    datos.Departamento = model.NombreDepartamento;
                    datos.Municipio = model.NombreMunicipio;
                    datos.Tipo = model.Tipo;
                    datos.Id = model.Id;
                    datos.FechaEventoFinal = datFechaFinal.ToString("yyyy-MM-dd");
                    datos.HoraEventoFinal = datFechaFinal.ToString("hh:mm tt");
                    datos.DocumentoId = model.DocumentoId;
                    datos.Telefono = model.Telefono;
                    datos.Email = model.Email;
                    datos.EsDestacado = model.Destacado;
                    if (model.EsNacional)
                    {
                        datos.Nacional = 1;
                        datos.Departamento = "Nacional";
                        datos.Municipio = "Nacional";
                    }
                    else
                        datos.Nacional = 2;

                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<MunicipioCelebraModels> MunicipioParticipantesCelebralaMusica()
        {
            try
            {
                var model = new List<MunicipiosParticipantesDataDTO>();
                var listResultado = new List<MunicipioCelebraModels>();

                model = ArtistasNeg.ConsultarMunicipiosParticipantes();

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new MunicipioCelebraModels();
                        datos.CodDepartamento = item.CodDepartamento;
                        datos.cantidad = item.cantidad;
                        datos.CodMunicipio = item.CodMunicipio;
                        datos.NombreDepartamento = item.NombreDepartamento;
                        datos.NombreMunicipio = item.NombreMunicipio;
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
        public static List<GrupoPublicoModels> ConsultarGruposPorEventoId(int EventoId)
        {
            try
            {
                var model = new List<GrupoDTO>();
                var listResultado = new List<GrupoPublicoModels>();

                model = EventosNeg.ConsultarGrupoPorEventoId(EventoId);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new GrupoPublicoModels();
                        datos.CantidadMiembros = item.CantidadMiembros;
                        datos.Contacto = item.Contacto;
                        datos.Enlace = item.Enlace;
                        datos.GrupoId = item.Id;
                        datos.Nombre = item.Nombre;
                        datos.Telefono = item.Telefono;
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

        public static List<EventoDataModels> ConsultarEventosTodosPorTipo(string Tipo, int filtroAno)
        {
            try
            {
                var model = new List<EventoDataDTO>();
                var listResultado = new List<EventoDataModels>();

                model = EventosNeg.ConsultarEventosTodosPorTipo(Tipo, filtroAno);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new EventoDataModels();
                        datos.AnoEvento = item.AnoEvento;
                        datos.CodDepartamento = item.CodDepartamento;
                        datos.CodMunicipio = item.CodMunicipio;
                        datos.EntidadOrganizadora = item.EntidadOrganizadora;
                        datos.Estado = item.Estado;
                        datos.EventoId = item.EventoId;
                        datos.TextoFechaCreacion = item.FechaCreacion.ToString("dd/MM/yyyy");
                        datos.FechaEvento = item.FechaEvento;
                        datos.FechaCreacion = item.FechaCreacion;
                        if (item.FechaModificacion != null)
                        {
                            DateTime datFecha = Convert.ToDateTime(item.FechaModificacion);
                            datos.FechaActualizacion = datFecha.ToString("dd/MM/yyyy");
                        }
                        datos.LugarEvento = item.LugarEvento;
                        datos.Nombre = item.Nombre;
                        datos.NombreDepartamento = item.NombreDepartamento;
                        datos.NombreMunicipio = item.NombreMunicipio;
                        datos.Tipo = item.Tipo;
                        datos.UsuarioId = item.UsuarioId;
                        datos.FechaEventoFinal = item.FechaEventoFinal;
                        datos.EsNacional = item.EsNacional;
                        datos.Email = item.Email;
                        datos.TieneImagen = item.TieneImagen;
                        datos.TieneArtistas = item.TieneArtistas;
                        datos.Usuario = item.Usuario;
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

        public static List<EventoDataModels> ConsultarEventosCapitales(int filtroAno)
        {
            try
            {
                var model = new List<EventoDataDTO>();
                var listResultado = new List<EventoDataModels>();

                model = EventosNeg.ConsultarEventosCapitales(filtroAno);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new EventoDataModels();
                        datos.AnoEvento = item.AnoEvento;
                        datos.CodDepartamento = item.CodDepartamento;
                        datos.CodMunicipio = item.CodMunicipio;
                        datos.EntidadOrganizadora = item.EntidadOrganizadora;
                        datos.Estado = item.Estado;
                        datos.EventoId = item.EventoId;
                        datos.FechaCreacion = item.FechaCreacion;
                        datos.FechaEvento = item.FechaEvento;
                        datos.FechaModificacion = item.FechaModificacion;
                        datos.LugarEvento = item.LugarEvento;
                        datos.Nombre = item.Nombre;
                        datos.NombreDepartamento = item.NombreDepartamento + "-";
                        datos.NombreMunicipio = item.NombreMunicipio;
                        datos.Tipo = item.Tipo;
                        datos.UsuarioId = item.UsuarioId;
                        datos.FechaEventoFinal = item.FechaEventoFinal;
                        datos.artistas = item.artistas;

                        if (item.Imagen != null)
                            datos.Imagen = item.Imagen;
                        else
                            datos.rutaFoto = "../img/evento_generica.jpg";
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

        public static List<EventoDataModels> ConsultarEventosPorCodigoMunicipio(int filtroAno, string CodMunicipio)
        {
            try
            {
                var model = new List<EventoDataDTO>();
                var listResultado = new List<EventoDataModels>();

                model = EventosNeg.ConsultarEventosPorCodigoMunicipio(filtroAno, CodMunicipio);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new EventoDataModels();
                        datos.AnoEvento = item.AnoEvento;
                        datos.CodDepartamento = item.CodDepartamento;
                        datos.CodMunicipio = item.CodMunicipio;
                        datos.EntidadOrganizadora = item.EntidadOrganizadora;
                        datos.Estado = item.Estado;
                        datos.EventoId = item.EventoId;
                        datos.FechaCreacion = item.FechaCreacion;
                        datos.FechaEvento = item.FechaEvento;
                        datos.FechaModificacion = item.FechaModificacion;
                        datos.LugarEvento = item.LugarEvento;
                        datos.Nombre = item.Nombre;
                        datos.NombreDepartamento = item.NombreDepartamento + "-";
                        datos.NombreMunicipio = item.NombreMunicipio;
                        datos.Tipo = item.Tipo;
                        datos.UsuarioId = item.UsuarioId;
                        datos.FechaEventoFinal = item.FechaEventoFinal;
                        datos.EsNacional = item.EsNacional;
                        datos.artistas = item.artistas;
                        if (item.Imagen != null)
                            datos.Imagen = item.Imagen;
                        else
                            datos.rutaFoto = "../img/evento_generica.jpg";
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

        public static List<EventoDataModels> ConsultarEventosPorCodigoDepto(int filtroAno, string CodDepto)
        {
            try
            {
                var model = new List<EventoDataDTO>();
                var listResultado = new List<EventoDataModels>();

                model = EventosNeg.ConsultarEventosPorCodigoDepto(filtroAno, CodDepto);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new EventoDataModels();
                        datos.AnoEvento = item.AnoEvento;
                        datos.CodDepartamento = item.CodDepartamento;
                        datos.CodMunicipio = item.CodMunicipio;
                        datos.EntidadOrganizadora = item.EntidadOrganizadora;
                        datos.Estado = item.Estado;
                        datos.EventoId = item.EventoId;
                        datos.FechaCreacion = item.FechaCreacion;
                        datos.FechaEvento = item.FechaEvento;
                        datos.FechaModificacion = item.FechaModificacion;
                        datos.LugarEvento = item.LugarEvento;
                        datos.Nombre = item.Nombre;
                        datos.NombreDepartamento = item.NombreDepartamento + "-";
                        datos.NombreMunicipio = item.NombreMunicipio;
                        datos.Tipo = item.Tipo;
                        datos.UsuarioId = item.UsuarioId;
                        datos.FechaEventoFinal = item.FechaEventoFinal;
                        datos.EsNacional = item.EsNacional;
                        datos.artistas = item.artistas;
                        if (item.Imagen != null)
                            datos.Imagen = item.Imagen;
                        else
                            datos.rutaFoto = "../img/evento_generica.jpg";
                      
                       
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
        public static List<EventoDataModels> ConsultarEventosPorUsuarioId(int UsuarioId, string Tipo)
        {
            try
            {
                var model = new List<EventoDataDTO>();
                var listResultado = new List<EventoDataModels>();

                model = EventosNeg.ConsultarEventosPorUsuarioId(UsuarioId, Tipo);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new EventoDataModels();
                        datos.AnoEvento = item.AnoEvento;
                        datos.CodDepartamento = item.CodDepartamento;
                        datos.CodMunicipio = item.CodMunicipio;
                        datos.EntidadOrganizadora = item.EntidadOrganizadora;
                        datos.Estado = item.Estado;
                        datos.EventoId = item.EventoId;
                        datos.FechaCreacion = item.FechaCreacion;
                        datos.FechaEvento = item.FechaEvento;
                        datos.FechaModificacion = item.FechaModificacion;
                        datos.LugarEvento = item.LugarEvento;
                        datos.Nombre = item.Nombre;
                        datos.NombreDepartamento = item.NombreDepartamento;
                        datos.NombreMunicipio = item.NombreMunicipio;
                        datos.Tipo = item.Tipo;
                        datos.UsuarioId = item.UsuarioId;
                        datos.FechaEventoFinal = item.FechaEventoFinal;
                        datos.EsNacional = item.EsNacional;
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

        public static List<EventoDataModels> ConsultarEventoPorMunicipio(int UsuarioId, string Tipo)
        {
            try
            {
                var model = new List<EventoDataDTO>();
                var listResultado = new List<EventoDataModels>();

                model = EventosNeg.ConsultarEventoPorMunicipio(UsuarioId, Tipo);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new EventoDataModels();
                        datos.AnoEvento = item.AnoEvento;
                        datos.CodDepartamento = item.CodDepartamento;
                        datos.CodMunicipio = item.CodMunicipio;
                        datos.EntidadOrganizadora = item.EntidadOrganizadora;
                        datos.Estado = item.Estado;
                        datos.EventoId = item.EventoId;
                        datos.FechaCreacion = item.FechaCreacion;
                        datos.FechaEvento = item.FechaEvento;
                        datos.FechaModificacion = item.FechaModificacion;
                        datos.LugarEvento = item.LugarEvento;
                        datos.Nombre = item.Nombre;
                        datos.NombreDepartamento = item.NombreDepartamento;
                        datos.NombreMunicipio = item.NombreMunicipio;
                        datos.Tipo = item.Tipo;
                        datos.UsuarioId = item.UsuarioId;
                        datos.FechaEventoFinal = item.FechaEventoFinal;
                        datos.EsNacional = item.EsNacional;
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

        public static List<EventoDataModels> ConsultarEventoPorEstadoId(int EstadoId, string Tipo)
        {
            try
            {
                var model = new List<EventoDataDTO>();
                var listResultado = new List<EventoDataModels>();

                model = EventosNeg.ConsultarEventoPorEstadoId(EstadoId, Tipo);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new EventoDataModels();
                        datos.AnoEvento = item.AnoEvento;
                        datos.CodDepartamento = item.CodDepartamento;
                        datos.CodMunicipio = item.CodMunicipio;
                        datos.EntidadOrganizadora = item.EntidadOrganizadora;
                        datos.Estado = item.Estado;
                        datos.EventoId = item.EventoId;
                        datos.FechaCreacion = item.FechaCreacion;
                        datos.FechaEvento = item.FechaEvento;
                        datos.FechaModificacion = item.FechaModificacion;
                        datos.LugarEvento = item.LugarEvento;
                        datos.Nombre = item.Nombre;
                        datos.NombreDepartamento = item.NombreDepartamento;
                        datos.NombreMunicipio = item.NombreMunicipio;
                        datos.Tipo = item.Tipo;
                        datos.UsuarioId = item.UsuarioId;
                        datos.FechaEventoFinal = item.FechaEventoFinal;
                        datos.EsNacional = item.EsNacional;
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

        public static List<EventoDataModels> ConsultarEventosTodos()
        {
            try
            {
                var model = new List<EventoDataDTO>();
                var listResultado = new List<EventoDataModels>();

                model = EventosNeg.ConsultarEventosTodos();

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new EventoDataModels();
                        datos.AnoEvento = item.AnoEvento;
                        datos.CodDepartamento = item.CodDepartamento;
                        datos.CodMunicipio = item.CodMunicipio;
                        datos.EntidadOrganizadora = item.EntidadOrganizadora;
                        datos.Estado = item.Estado;
                        datos.EventoId = item.EventoId;
                        datos.FechaCreacion = item.FechaCreacion;
                        datos.FechaEvento = item.FechaEvento;
                        datos.FechaModificacion = item.FechaModificacion;
                        datos.LugarEvento = item.LugarEvento;
                        datos.Nombre = item.Nombre;
                        datos.NombreDepartamento = item.NombreDepartamento;
                        datos.NombreMunicipio = item.NombreMunicipio;
                        datos.Tipo = item.Tipo;
                        datos.UsuarioId = item.UsuarioId;
                        datos.FechaEventoFinal = item.FechaEventoFinal;
                        datos.EsNacional = item.EsNacional;
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
        public static List<EventoDataModels> ConsultarEventoPorDepartamento(string codigoDepartamento, string tipo)
        {
            try
            {
                var model = new List<EventoDataDTO>();
                var listResultado = new List<EventoDataModels>();

                model = EventosNeg.ConsultarEventoPorDepartamento(codigoDepartamento, tipo);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new EventoDataModels();
                        datos.AnoEvento = item.AnoEvento;
                        datos.CodDepartamento = item.CodDepartamento;
                        datos.CodMunicipio = item.CodMunicipio;
                        datos.EntidadOrganizadora = item.EntidadOrganizadora;
                        datos.Estado = item.Estado;
                        datos.EventoId = item.EventoId;
                        datos.FechaCreacion = item.FechaCreacion;
                        datos.FechaEvento = item.FechaEvento;
                        datos.FechaModificacion = item.FechaModificacion;
                        datos.LugarEvento = item.LugarEvento;
                        datos.Nombre = item.Nombre;
                        datos.Tipo = item.Tipo;
                        datos.UsuarioId = item.UsuarioId;
                        datos.FechaEventoFinal = item.FechaEventoFinal;
                        datos.EsNacional = item.EsNacional;
                        if (item.EsNacional)
                        {
                            datos.NombreDepartamento = "Nacional";
                            datos.NombreMunicipio = "Nacional";
                        }
                        else
                        {
                            datos.NombreDepartamento = item.NombreDepartamento;
                            datos.NombreMunicipio = item.NombreMunicipio;
                        }
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

        public static List<EventoDataModels> ConsultarEventoPorArea(int UsuarioId, string tipo)
        {
            try
            {
                var model = new List<EventoDataDTO>();
                var listResultado = new List<EventoDataModels>();

                model = EventosNeg.ConsultarEventoPorArea(UsuarioId, tipo);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new EventoDataModels();
                        datos.AnoEvento = item.AnoEvento;
                        datos.CodDepartamento = item.CodDepartamento;
                        datos.CodMunicipio = item.CodMunicipio;
                        datos.EntidadOrganizadora = item.EntidadOrganizadora;
                        datos.Estado = item.Estado;
                        datos.EventoId = item.EventoId;
                        datos.FechaCreacion = item.FechaCreacion;
                        datos.FechaEvento = item.FechaEvento;
                        datos.FechaModificacion = item.FechaModificacion;
                        datos.LugarEvento = item.LugarEvento;
                        datos.Nombre = item.Nombre;
                        datos.NombreDepartamento = item.NombreDepartamento;
                        datos.NombreMunicipio = item.NombreMunicipio;
                        datos.Tipo = item.Tipo;
                        datos.UsuarioId = item.UsuarioId;
                        datos.FechaEventoFinal = item.FechaEventoFinal;
                        datos.EsNacional = item.EsNacional;
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

        #region Artistas
        public static ArtistaModels ConsultaArtistaPorId(int Id)
        {
            try
            {
                var model = new ArtistaDTO();
                var datos = new ArtistaModels();
                model = ArtistasNeg.ConsultarArtistaPorId(Id);

                if (model != null)
                {
                    datos.Id = model.Id;
                    datos.CantidadMiembros = model.CantidadMiembros.ToString();
                    datos.CategoriaId = model.CategoriaId.ToString();
                    datos.Contacto = model.Contacto;
                    datos.Email = model.Email;
                    datos.Enlace = model.Enlace;
                    if (model.EsGrupo == true)
                        datos.EsGrupo = 1;
                    else
                        datos.EsGrupo = 2;
                    datos.EventoId = model.EventoId;
                    datos.imagen = model.Imagen;
                    datos.Nombre = model.Nombre;
                    datos.Orden = model.Orden.ToString();
                    datos.ProcesoId = model.ProcesoId.ToString();
                    datos.Resena = model.Resena;
                    datos.Telefono = model.Telefono;
                    datos.UsuarioId = model.UsuarioId;
                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ArtistaModels ConsultarArtistaPorEventoId(int Id)
        {
            try
            {
                var model = new ArtistaDTO();
                var datos = new ArtistaModels();
                model = ArtistasNeg.ConsultarArtistaPorEventoId(Id);

                if (model != null)
                {
                    datos.Contacto = model.Contacto;
                    datos.Email = model.Email;
                    datos.Enlace = model.Enlace;
                    if (model.EsGrupo == true)
                        datos.EsGrupo = 1;
                    else
                        datos.EsGrupo = 2;
                    datos.EventoId = model.EventoId;
                    datos.Telefono = model.Telefono;
                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<ArtistaPublicoModels> ConsultaArtistasPorEventoId(int EventoId)
        {
            try
            {
                var model = new List<ArtistaPublicoDTO>();
                var listResultado = new List<ArtistaPublicoModels>();

                model = ArtistasNeg.ConsultaArtistasPorEventoId(EventoId);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new ArtistaPublicoModels();
                        datos.CantidadMiembros = item.CantidadMiembros;
                        datos.Contacto = item.Contacto;
                        datos.Enlace = item.Enlace;
                        datos.EsGrupo = item.EsGrupo;
                        datos.Id = item.Id;
                        datos.Nombre = item.Nombre;
                        datos.Orden = item.Orden;
                        datos.Categoria = item.Categoria;
                        datos.Email = item.Email;
                        datos.EventoId = item.EventoId;
                        datos.Proceso = item.Proceso;
                        datos.Telefono = item.Telefono;
                        datos.Resena = item.Resena;
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
        #endregion
    }
}