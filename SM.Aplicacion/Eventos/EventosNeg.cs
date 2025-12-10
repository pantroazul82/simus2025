using System;
using System.Collections.Generic;
using SM.Datos.Eventos;
using SM.SIPA;
using SM.LibreriaComun.DTO;
using SM.Datos.DTO;
using System.Linq;

namespace SM.Aplicacion.Eventos
{
    public class EventosNeg
    {
        #region Consultas
        public static EventoDTO ConsultarEventoPorId(int eventoId)
        {
            try
            {
                var model = new ART_MUSICA_EVENTOS();
                var datos = new EventoDTO();
                model = EventoServicios.ConsultarEventoPorId(eventoId);

                if (model != null)
                {
                    datos.AnoEvento = model.AnoEvento;
                    datos.AreaArtisticaId = model.AreaArtisticaId;
                    datos.CodDepartamento = model.CodDepartamento;
                    datos.CodMunicipio = model.CodMunicipio;
                    datos.Descripción = model.Descripción;
                    datos.EntidadOrganizadora = model.EntidadOrganizadora;
                    datos.FechaCreacion = model.FechaCreacion;
                    datos.FechaModificacion = model.FechaModificacion;
                    datos.FechaEvento = model.FechaEvento;
                    datos.Id = model.Id;
                    datos.Imagen = model.Imagen;
                    datos.LugarEvento = model.LugarEvento;
                    datos.Nombre = model.Nombre;
                    datos.Tipo = model.Tipo;
                    datos.UsuarioId = model.UsuarioId;
                    datos.EstadoId = model.EstadoId;
                    datos.NombreMunicipio = model.NombreMunicipio;
                    datos.NombreDepartamento = model.NombreDepartamento;
                    datos.FechaEventoFinal = model.FechaEventoFinal;
                    datos.EsNacional = model.EsNacional ?? false;
                    datos.DocumentoId = model.DocumentoId ?? 0;
                    datos.Telefono = model.Telefono;
                    datos.Email = model.Email;
                    datos.Destacado = model.Destacado ?? false;
                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string obtenerNombreEntidad(int eventoId)
        {
            try
            {
                var model = new ART_MUSICA_EVENTOS();
                string nombre = "";
                model = EventoServicios.ConsultarEventoPorId(eventoId);

                if (model != null)
                {
                    nombre = model.EntidadOrganizadora;

                }


                return nombre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ReporteDepartamentoDTO> GenerarReportePorcentajePorDepartamento(int anoEvento)
        {
            try
            {
                var listadodepartamento = new List<DepartamentoDTO>();
                var listadodepartamentoPeriodo = new List<DepartamentoDTO>();
                var listResultado = new List<ReporteDepartamentoDTO>();
                listadodepartamento = EventoServicios.ConsultarDepartamentoXMunicipio();
                listadodepartamentoPeriodo = EventoServicios.ConsultarDepartamentoXMunicipioPeriodo(anoEvento);


                foreach (var item in listadodepartamento)
                {
                    var datos = new ReporteDepartamentoDTO();
                    datos.Periodo = anoEvento.ToString();
                    datos.Codigo = item.CODIGO;
                    datos.Departamento = item.DEPARTAMENTO;
                    datos.CantidadMunicipios = item.CANTIDAD;
                    var resultado = listadodepartamentoPeriodo.Where(x => x.CODIGO == item.CODIGO).FirstOrDefault();
                    if (resultado != null)
                    {
                        datos.CantidadMunConEventos = resultado.CANTIDAD;
                        datos.Porcentaje = (resultado.CANTIDAD * 100) / item.CANTIDAD;
                    }
                    listResultado.Add(datos);
                }



                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<EventoDTO> ConsultarProgramacionConciertosMusica(int anoEvento, string codigoMunicipio)
        {
            try
            {
                var model = new List<ART_MUSICA_EVENTOS>();
                var listResultado = new List<EventoDTO>();
                model = EventoServicios.ConsultarProgramacionConciertos(anoEvento, codigoMunicipio);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new EventoDTO();
                        datos.AnoEvento = item.AnoEvento;
                        datos.AreaArtisticaId = item.AreaArtisticaId;
                        datos.CodDepartamento = item.CodDepartamento;
                        datos.CodMunicipio = item.CodMunicipio;
                        datos.Descripción = item.Descripción;
                        datos.EntidadOrganizadora = item.EntidadOrganizadora;
                        datos.FechaEvento = item.FechaEvento;
                        datos.Id = item.Id;
                        datos.Imagen = item.Imagen;
                        datos.LugarEvento = item.LugarEvento;
                        datos.Nombre = item.Nombre;
                        datos.Tipo = item.Tipo;
                        datos.NombreMunicipio = item.NombreMunicipio;
                        datos.NombreDepartamento = item.NombreDepartamento;
                        datos.Telefono = item.Telefono;
                        datos.Email = item.Email;
                        datos.Destacado = item.Destacado ?? false;
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

        public static List<GrupoDTO> ConsultarGrupoPorEventoId(int eventoId)
        {
            try
            {
                var model = new List<ART_MUSICA_GRUPOS>();
                var listGrupos = new List<GrupoDTO>();
                model = EventoServicios.ConsultarGrupos(eventoId);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new GrupoDTO();
                        datos.CantidadMiembros = item.CantidadMiembros;
                        datos.Contacto = item.Contacto;
                        datos.Enlace = item.Enlace;
                        datos.EsGrupo = item.EsGrupo == 1 ? true : false;
                        datos.Id = item.Id;
                        datos.Imagen = item.Imagen;
                        datos.Nombre = item.Nombre;
                        datos.Orden = item.Orden;
                        datos.Reseña = item.Reseña;
                        datos.Telefono = item.Telefono;
                        listGrupos.Add(datos);
                    }

                }


                return listGrupos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EventoDataDTO> ConsultarConciertorPorMunicipio(string codigoMunicipio, int periodo, int UsuarioActualId)
        {
            try
            {
                var model = new List<EventoResultadoDTO>();
                var listResultado = new List<EventoDataDTO>();
                model = EventoServicios.ConsultarConciertorPorMunicipio(codigoMunicipio, periodo);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new EventoDataDTO();
                        datos.AnoEvento = item.AnoEvento;
                        datos.EntidadOrganizadora = item.EntidadOrganizadora;
                        datos.EventoId = item.EventoId;
                        datos.FechaCreacion = item.FechaCreacion;
                        datos.FechaEvento = item.FechaEvento;
                        datos.LugarEvento = item.LugarEvento;
                        datos.NombreDepartamento = item.NombreDepartamento;
                        datos.NombreMunicipio = item.NombreMunicipio;
                        datos.Tipo = item.Tipo;
                        datos.UsuarioId = item.UsuarioId;
                        datos.UsuarioActualId = UsuarioActualId;
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
        public static List<EventoDataDTO> ConsultarEventosTodos()
        {
            try
            {
                var model = new List<EventoResultadoDTO>();
                var listResultado = new List<EventoDataDTO>();
                model = EventoServicios.ConsultarEventosTodos();

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new EventoDataDTO();
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
                        datos.FechaEventoFinal = item.FechaEventoFinal;
                        datos.EsNacional = item.EsNacional;
                        datos.UsuarioId = item.UsuarioId;
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

        public static List<EventoDataDTO> ConsultarEventoPorDepartamento(string codDepartamento, string tipo)
        {
            try
            {
                var model = new List<EventoResultadoDTO>();
                var listResultado = new List<EventoDataDTO>();
                model = EventoServicios.ConsultarEventoPorDepartamento(codDepartamento, tipo);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new EventoDataDTO();
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
                        datos.FechaEventoFinal = item.FechaEventoFinal;
                        datos.EsNacional = item.EsNacional;
                        datos.Tipo = item.Tipo;
                        datos.UsuarioId = item.UsuarioId;
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

        public static List<EventoDataDTO> ConsultarEventoPorEstadoId(int EstadoId, string Tipo)
        {
            try
            {
                var model = new List<EventoResultadoDTO>();
                var listResultado = new List<EventoDataDTO>();
                model = EventoServicios.ConsultarEventoPorEstadoId(EstadoId, Tipo);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new EventoDataDTO();
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
                        datos.FechaEventoFinal = item.FechaEventoFinal;
                        datos.EsNacional = item.EsNacional;
                        datos.UsuarioId = item.UsuarioId;
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

        public static List<ConciertosRecientesDTO> ConsultarUltimosConciertosCreados(int periodo)
        {
            try
            {
                var model = new List<EventoResultadoDTO>();
                var listResultado = new List<ConciertosRecientesDTO>();
                model = EventoServicios.ConsultarUltimosConciertosCreados(periodo);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new ConciertosRecientesDTO();
          
                        datos.Entidad = item.EntidadOrganizadora;
                        datos.EventoId = item.EventoId;
                        datos.HoraEvento = item.FechaEvento.ToString("HH:mm tt") ;
                       
                        datos.Departamento = item.NombreDepartamento;
                        datos.Municipio = item.NombreMunicipio;
                
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
        public static List<EventoDataDTO> ConsultarEventoPorMunicipio(int UsuarioId, string Tipo)
        {
            try
            {
                var model = new List<EventoResultadoDTO>();
                var listResultado = new List<EventoDataDTO>();
                model = EventoServicios.ConsultarEventoPorMunicipio(UsuarioId, Tipo);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new EventoDataDTO();
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
                        datos.FechaEventoFinal = item.FechaEventoFinal;
                        datos.EsNacional = item.EsNacional;
                        datos.Tipo = item.Tipo;
                        datos.UsuarioId = item.UsuarioId;
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


        public static List<EventoDataDTO> ConsultarEventosTodosPorTipo(string Tipo, int filtroAno)
        {
            try
            {
                var model = new List<EventoResultadoDTO>();
                var listResultado = new List<EventoDataDTO>();
                model = EventoServicios.ConsultarEventosTodosPorTipo(Tipo, filtroAno);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new EventoDataDTO();
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
                        datos.FechaEventoFinal = item.FechaEventoFinal;
                        datos.EsNacional = item.EsNacional;
                        datos.Tipo = item.Tipo;
                        datos.UsuarioId = item.UsuarioId;
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

        public static List<EventoDataDTO> ConsultarEventosCapitales(int filtroAno)
        {
            try
            {
                var model = new List<EventoResultadoDTO>();
                var listResultado = new List<EventoDataDTO>();
                model = EventoServicios.ConsultarEventosCapitales(filtroAno);


                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new EventoDataDTO();

                        datos.artistas = "";
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
                        datos.FechaEventoFinal = item.FechaEventoFinal;
                        datos.EsNacional = item.EsNacional;
                        datos.Tipo = item.Tipo;
                        datos.UsuarioId = item.UsuarioId;
                        datos.Email = item.Email;
                        datos.Imagen = item.Imagen;
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

        public static List<EventoDataDTO> ConsultarEventosPorCodigoMunicipio(int filtroAno, string CodMunicipio)
        {
            try
            {
                var model = new List<EventoResultadoDTO>();
                var listResultado = new List<EventoDataDTO>();
                model = EventoServicios.ConsultarEventosPorCodigoMunicipio(filtroAno, CodMunicipio);


                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new EventoDataDTO();
                        //var registrosArtistas = new List<string>();
                        //registrosArtistas = (from l in listadoArtistas where l.Id == item.EventoId select l.Nombre).ToList();
                        //if (registrosArtistas.Count > 0)
                        //    datos.artistas = ConsultarArtistasPorRegistro(registrosArtistas);
                        datos.artistas = "";
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
                        datos.FechaEventoFinal = item.FechaEventoFinal;
                        datos.EsNacional = item.EsNacional;
                        datos.Tipo = item.Tipo;
                        datos.UsuarioId = item.UsuarioId;
                        datos.Email = item.Email;
                        datos.Imagen = item.Imagen;
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

        public static List<EventoDataDTO> ConsultarEventosPorCodigoDepto(int filtroAno, string CodDepto)
        {
            try
            {
                var model = new List<EventoResultadoDTO>();
                var listResultado = new List<EventoDataDTO>();
                model = EventoServicios.ConsultarEventosPorCodigoDepto(filtroAno, CodDepto);


                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new EventoDataDTO();
                        //var registrosArtistas = new List<string>();
                        //registrosArtistas = (from l in listadoArtistas where l.Id == item.EventoId select l.Nombre).ToList();
                        //if (registrosArtistas.Count > 0)
                        //    datos.artistas = ConsultarArtistasPorRegistro(registrosArtistas);
                        datos.artistas = "";
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
                        datos.FechaEventoFinal = item.FechaEventoFinal;
                        datos.EsNacional = item.EsNacional;
                        datos.Tipo = item.Tipo;
                        datos.UsuarioId = item.UsuarioId;
                        datos.Email = item.Email;
                        datos.Imagen = item.Imagen;
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

        public static List<BasicaDTO> ConsultarArtistasPorEventoId(int eventoId)
        {
            try
            {
                var model = new List<Parametro>();
                var listResultado = new List<BasicaDTO>();
                model = EventoServicios.ConsultarArtistasPorEventoId(eventoId);


                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new BasicaDTO();
                        datos.text = item.Nombre;
                        datos.value = item.Id.ToString();
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

        public static string ConsultarArtistasPorRegistro(List<string> model)
        {
            try
            {
                string NombreArtistas = "";
                foreach (var item in model)
                {
                    NombreArtistas = item + " , " + NombreArtistas;

                }

                NombreArtistas = NombreArtistas.Substring(0, NombreArtistas.Length - 2);
                return NombreArtistas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EventoDataDTO> ConsultarEventosPorUsuarioId(int UsuarioId, string Tipo)
        {
            try
            {
                var model = new List<EventoResultadoDTO>();
                var listResultado = new List<EventoDataDTO>();
                model = EventoServicios.ConsultarEventosPorUsuarioId(UsuarioId, Tipo);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new EventoDataDTO();
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
                        datos.FechaEventoFinal = item.FechaEventoFinal;
                        datos.EsNacional = item.EsNacional;
                        datos.Tipo = item.Tipo;
                        datos.UsuarioId = item.UsuarioId;
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

        public static List<EventoDataDTO> ConsultarEventoPorArea(int UsuarioId, string tipo)
        {
            try
            {
                var model = new List<EventoResultadoDTO>();
                var listResultado = new List<EventoDataDTO>();
                model = EventoServicios.ConsultarEventoPorArea(UsuarioId, tipo);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new EventoDataDTO();
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
                        datos.FechaEventoFinal = item.FechaEventoFinal;
                        datos.EsNacional = item.EsNacional;
                        datos.Tipo = item.Tipo;
                        datos.UsuarioId = item.UsuarioId;
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

        /// <summary>
        /// procedimiento para traer el detalle de conciertos
        /// </summary>
        /// <param name="CodigoMunicipio"></param>
        /// <returns></returns>

        public static List<EventoDataDTO> ConsultarDetalleEventos(decimal AreaArtisticaId, int anoEvento, string Tipo)
        {
            try
            {
                var model = new List<ConciertoResultadoDTO>();
                string ImagenPublicaConcierto = "~/img/logo_crear_concierto.png";
                var listResultado = new List<EventoDataDTO>();
                model = EventoServicios.ConsultarDetalleEventos(AreaArtisticaId, anoEvento, Tipo);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new EventoDataDTO();
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
                        datos.NombreDepartamento = item.NombreDepartamento + " - " + item.NombreMunicipio;
                        datos.NombreMunicipio = item.NombreMunicipio;
                        datos.FechaEventoFinal = item.FechaEventoFinal;
                        datos.EsNacional = item.EsNacional;
                        datos.Tipo = item.Tipo;
                        datos.UsuarioId = item.UsuarioId;
                        if (item.Imagen != null)
                        {
                            string imageBase64Data = Convert.ToBase64String(item.Imagen);
                            string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                            datos.imageDataURL = imageDataURL;

                        }
                        else
                            datos.imageDataURL = ImagenPublicaConcierto;
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

        /// <summary>
        /// procedimiento para traer el detalle de artistas de celebra la música
        /// </summary>
        /// <param name="CodigoMunicipio"></param>
        /// <returns></returns>

        public static List<ArtistaDetalleDTO> ConsultarDetalleArtistas(int anoEvento)
        {
            try
            {
                var model = new List<SM.Datos.DTO.ArtistaPublicoDTO>();
                var listResultado = new List<ArtistaDetalleDTO>();
                model = EventoServicios.ConsultarDetalleArtistas(anoEvento);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new ArtistaDetalleDTO();
                        datos.CantidadMiembros = item.CantidadMiembros;
                        datos.Categoria = item.Categoria;
                        datos.Contacto = item.Contacto;
                        datos.Email = item.Email;
                        datos.Enlace = item.Enlace;
                        datos.EntidadOrganizadora = item.EntidadOrganizadora;
                        datos.EsGrupo = item.EsGrupo;
                        datos.EventoId = item.EventoId;
                        datos.Id = item.Id;
                        datos.imagen = item.imagen;
                        datos.LugarEvento = item.LugarEvento;
                        datos.Nombre = item.Nombre;
                        datos.NombreDepartamento = item.NombreDepartamento;
                        datos.NombreMunicipio = item.NombreMunicipio;
                        datos.Orden = item.Orden;
                        datos.Proceso = item.Proceso;
                        datos.Resena = item.Resena;
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

        /// <summary>
        /// procedimiento para traer el detalle de los grupos de celebra la música
        /// </summary>
        /// <param name="CodigoMunicipio"></param>
        /// <returns></returns>

        public static List<ArtistaDetalleDTO> ConsultarDetalleGrupos(int anoEvento)
        {
            try
            {
                var model = new List<SM.Datos.DTO.ArtistaPublicoDTO>();
                var listResultado = new List<ArtistaDetalleDTO>();
                model = EventoServicios.ConsultarDetalleGrupos(anoEvento);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new ArtistaDetalleDTO();
                        datos.CantidadMiembros = item.CantidadMiembros;
                        datos.Categoria = item.Categoria;
                        datos.Contacto = item.Contacto;
                        datos.Email = item.Email;
                        datos.Enlace = item.Enlace;
                        datos.EntidadOrganizadora = item.EntidadOrganizadora;
                        datos.EsGrupo = item.EsGrupo;
                        datos.EventoId = item.EventoId;
                        datos.Id = item.Id;
                        datos.imagen = item.imagen;
                        datos.LugarEvento = item.LugarEvento;
                        datos.Nombre = item.Nombre;
                        datos.NombreDepartamento = item.NombreDepartamento;
                        datos.NombreMunicipio = item.NombreMunicipio;
                        datos.Orden = item.Orden;
                        datos.Proceso = item.Proceso;
                        datos.Resena = item.Resena;
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
        /// <summary>
        /// Procedimiento que trae el listado de municipios faltantes por conciertos celebra la música
        /// </summary>
        /// <returns></returns>
        public static List<MunicipiosParticipantesDataDTO> ConsultarMunicipiosFaltantes(int anoEvento)
        {
            try
            {
                var model = new List<MunicipiosParticipantesDTO>();
                var listResultado = new List<MunicipiosParticipantesDataDTO>();
                model = EventoServicios.ConsultarMunicipiosFaltantes(anoEvento);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new MunicipiosParticipantesDataDTO();
                        datos.cantidad = item.cantidad;
                        datos.CodDepartamento = item.CodDepartamento;
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
        public static List<BasicaDTO> ConsultarListadoAno(string CodigoMunicipio)
        {
            try
            {
                var model = new List<ListadoAnosDTO>();
                var listResultado = new List<BasicaDTO>();
                model = EventoServicios.ConsultarListadoAno(CodigoMunicipio);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new BasicaDTO();
                        datos.text = item.AnoEvento.ToString();
                        datos.value = item.AnoEvento.ToString();
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

        public static int CantidadMunicipioParticipantesDanza()
        {
            int intResultado = 0;
            try
            {
                var model = new List<MunicipiosParticipantesDTO>();

                model = EventoServicios.ConsultarCantidadMunicipiosDanza();

                if (model != null)
                {

                    intResultado = model.Count;
                }


                return intResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int CantidadDepartamentoParticipantesDanza()
        {
            int intResultado = 0;
            try
            {
                var model = new List<DepartamentosParticipantesDTO>();

                model = EventoServicios.ConsultarCantidadDepartamentosDanza();

                if (model != null)
                {

                    intResultado = model.Count;
                }


                return intResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int ConsultarCantidadEventosDanza()
        {
            int intResultado = 0;
            try
            {

                intResultado = EventoServicios.ConsultarCantidadEventosDanza();

                return intResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Actualizacion

        public static void EliminarGrupo(int GrupoId)
        {
            try
            {
                EventoServicios.EliminarGrupo(GrupoId);
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static int CrearEvento(EventoDTO evento)
        {
            int EventoId = 0;
            try
            {

                EventoId = EventoServicios.CrearEvento(evento.UsuarioId,
                                              evento.AreaArtisticaId,
                                              evento.Nombre,
                                              evento.EntidadOrganizadora,
                                              evento.CodMunicipio,
                                              evento.CodDepartamento,
                                              evento.LugarEvento,
                                              evento.FechaEvento,
                                              evento.Tipo,
                                              evento.Imagen,
                                              evento.Descripción,
                                              evento.Telefono,
                                              evento.Email);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return EventoId;
        }

        public static int DuplicarEvento(int intEventoId, int ArtMusicaUsuarioId, DateTime FechaEvento, string NombreUsuario, string strIP)
        {
            int EventoId = 0;
            try
            {

                EventoId = EventoServicios.DuplicarEvento(intEventoId, ArtMusicaUsuarioId, FechaEvento, NombreUsuario, strIP);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return EventoId;
        }
        public static int CrearEventoDanza(EventoDTO evento)
        {
            int EventoId = 0;
            try
            {
                if (evento.DocumentoId > 0)
                {
                    EventoId = EventoServicios.CrearEventoDanzaDocumento(evento.UsuarioId,
                                                  evento.AreaArtisticaId,
                                                  evento.Nombre,
                                                  evento.EntidadOrganizadora,
                                                  evento.CodMunicipio,
                                                  evento.CodDepartamento,
                                                  evento.LugarEvento,
                                                  evento.FechaEvento,
                                                  evento.Tipo,
                                                  evento.Imagen,
                                                  evento.Descripción,
                                                  evento.EsNacional,
                                                  Convert.ToDateTime(evento.FechaEventoFinal),
                                                  evento.DocumentoId,
                                                  evento.Telefono,
                                                  evento.Email);
                }
                else
                {
                    EventoId = EventoServicios.CrearEventoDanza(evento.UsuarioId,
                                                   evento.AreaArtisticaId,
                                                   evento.Nombre,
                                                   evento.EntidadOrganizadora,
                                                   evento.CodMunicipio,
                                                   evento.CodDepartamento,
                                                   evento.LugarEvento,
                                                   evento.FechaEvento,
                                                   evento.Tipo,
                                                   evento.Imagen,
                                                   evento.Descripción,
                                                   evento.EsNacional,
                                                   Convert.ToDateTime(evento.FechaEventoFinal),
                                                   evento.Telefono,
                                                   evento.Email);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return EventoId;
        }

        public static void ActualizarEvento(EventoDTO evento, bool Cambiar)
        {

            try
            {
                if (Cambiar)
                {
                    EventoServicios.ActualizarEventoCambiarEstado(evento.Id,
                                                  evento.UsuarioId,
                                                evento.AreaArtisticaId,
                                                evento.Nombre,
                                                evento.EntidadOrganizadora,
                                                evento.CodMunicipio,
                                                evento.CodDepartamento,
                                                evento.LugarEvento,
                                                evento.FechaEvento,
                                                evento.Tipo,
                                                evento.Imagen,
                                                evento.Descripción,
                                                evento.EstadoId,
                                                evento.Telefono,
                                                evento.Email,
                                                evento.Destacado);
                }
                else
                {
                    EventoServicios.ActualizarEvento(evento.Id,
                                                   evento.UsuarioId,
                                                 evento.AreaArtisticaId,
                                                 evento.Nombre,
                                                 evento.EntidadOrganizadora,
                                                 evento.CodMunicipio,
                                                 evento.CodDepartamento,
                                                 evento.LugarEvento,
                                                 evento.FechaEvento,
                                                 evento.Tipo,
                                                 evento.Imagen,
                                                 evento.Descripción,
                                                 evento.Telefono,
                                                evento.Email);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static void ActualizarEventoDanza(EventoDTO evento, bool Cambiar)
        {

            try
            {
                if (Cambiar)
                {
                    EventoServicios.ActualizarEventoDanzaEstado(evento.Id,
                                                   evento.UsuarioId,
                                                 evento.AreaArtisticaId,
                                                 evento.Nombre,
                                                 evento.EntidadOrganizadora,
                                                 evento.CodMunicipio,
                                                 evento.CodDepartamento,
                                                 evento.LugarEvento,
                                                 evento.FechaEvento,
                                                 evento.Tipo,
                                                 evento.Imagen,
                                                 evento.Descripción,
                                                 evento.EsNacional,
                                                 Convert.ToDateTime(evento.FechaEventoFinal),
                                                 evento.DocumentoId,
                                                 evento.EstadoId,
                                                 evento.Telefono,
                                                 evento.Email,
                                                 evento.Destacado);
                }
                else
                {
                    EventoServicios.ActualizarEventoDanza(evento.Id,
                                                   evento.UsuarioId,
                                                 evento.AreaArtisticaId,
                                                 evento.Nombre,
                                                 evento.EntidadOrganizadora,
                                                 evento.CodMunicipio,
                                                 evento.CodDepartamento,
                                                 evento.LugarEvento,
                                                 evento.FechaEvento,
                                                 evento.Tipo,
                                                 evento.Imagen,
                                                 evento.Descripción,
                                                 evento.EsNacional,
                                                 Convert.ToDateTime(evento.FechaEventoFinal),
                                                 evento.DocumentoId,
                                                 evento.Telefono,
                                                 evento.Email);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public static void CrearGrupo(GrupoDTO grupo)
        {
            try
            {
                EventoServicios.CrearGrupo(grupo.EventoId,
                                           grupo.Nombre,
                                           grupo.Enlace,
                                           grupo.Contacto,
                                           grupo.Telefono,
                                           grupo.Orden,
                                           grupo.CantidadMiembros,
                                           grupo.EsGrupo,
                                           grupo.Imagen,
                                           grupo.Reseña);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void EliminarEvento(int eventoId,
                            int UsuarioId,
                            string NombreUsuario,
                            string strIP)
        {

            try
            {

                EventoServicios.Eliminar(eventoId, UsuarioId, NombreUsuario, strIP);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
    }
}
