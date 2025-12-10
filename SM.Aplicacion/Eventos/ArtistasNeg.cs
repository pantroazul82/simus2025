using System;
using System.Collections.Generic;
using SM.Datos.Eventos;
using SM.SIPA;
using SM.LibreriaComun.DTO;
using SM.Datos.DTO;


namespace SM.Aplicacion.Eventos
{
    public class ArtistasNeg
    {
        #region Actualización
        public static void EliminarArtista(int ArtistaId)
        {
            try
            {
                ArtistasServicio.EliminarArtista(ArtistaId);
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static int CrearArtista(ArtistaDTO artista)
        {
            int ArtistaId = 0;
            try
            {

                ArtistaId = ArtistasServicio.CrearArtistas(artista.UsuarioId,
                                               artista.EventoId,
                                               artista.Nombre,
                                               artista.Contacto,
                                               artista.Enlace,
                                               artista.Telefono,
                                               artista.Email,
                                               artista.Orden,
                                               artista.CantidadMiembros,
                                               artista.ProcesoId,
                                               artista.CategoriaId,
                                               artista.Imagen,
                                               artista.Resena,
                                               artista.EsGrupo);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ArtistaId;
        }

        public static void ActualizarArtista(ArtistaDTO artista)
        {
            try
            {

                ArtistasServicio.ActualizarArtistas(artista.Id,
                                                  artista.Nombre,
                                               artista.Contacto,
                                               artista.Enlace,
                                               artista.Telefono,
                                               artista.Email,
                                               artista.Orden,
                                               artista.CantidadMiembros,
                                               artista.ProcesoId,
                                               artista.CategoriaId,
                                               artista.Imagen,
                                               artista.Resena,
                                               artista.EsGrupo);

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        #endregion

        #region Consulta

        public static List<MunicipiosParticipantesDataDTO> ConsultarMunicipiosParticipantes()
        {
            try
            {
                var model = new List<MunicipiosParticipantesDTO>();
                var listResultado = new List<MunicipiosParticipantesDataDTO>();
                model = ArtistasServicio.ConsultarMunicipiosParticipantes();

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

        public static int CantidadMunicipioParticipantes()
        {
            int intResultado = 0;
            try
            {
                var model = new List<MunicipiosParticipantesDTO>();

                model = ArtistasServicio.ConsultarMunicipiosParticipantes();

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

        public static int ConsultarCantidadConciertos()
        {
            int intResultado = 0;
            try
            {

                intResultado = ArtistasServicio.ConsultarCantidadConciertos();

                return intResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int ConsultarCantidadArtistas()
        {
            int intResultado = 0;
            try
            {

                intResultado = ArtistasServicio.ConsultarCantidadArtistas();

                return intResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int ConsultarCantidadGrupos()
        {
            int intResultado = 0;
            try
            {

                intResultado = ArtistasServicio.ConsultarCantidadGrupos();

                return intResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static ArtistaDTO ConsultarArtistaPorId(int artistaId)
        {
            try
            {
                var model = new ART_MUSICA_ARTISTAS_CELEBRA();
                var datos = new ArtistaDTO();
                model = ArtistasServicio.ConsultarArtistaPorId(artistaId);

                if (model != null)
                {
                    datos.Id = model.Id;
                    datos.CantidadMiembros = model.CantidadMiembros;
                    datos.CategoriaId = model.CategoriaId;
                    datos.Contacto = model.Contacto;
                    datos.Email = model.Email;
                    datos.Enlace = model.Enlace;
                    datos.EsGrupo = model.EsGrupo;
                    datos.EventoId = model.EventoId;
                    datos.FechaCreacion = model.FechaCreacion;
                    datos.FechaModificacion = model.FechaModificacion;
                    datos.FechaPresentacion = model.FechaPresentacion;
                    datos.Imagen = model.Imagen;
                    datos.Nombre = model.Nombre;
                    datos.Orden = model.Orden;
                    datos.ProcesoId = model.ProcesoId;
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

        public static ArtistaDTO ConsultarArtistaPorEventoId(int eventoId)
        {
            try
            {
                var model = new ART_MUSICA_ARTISTAS_CELEBRA();
                var datos = new ArtistaDTO();
                model = ArtistasServicio.ConsultarArtistaPorEventoId(eventoId);

                if (model != null)
                {
                    datos.Id = model.Id;
                    datos.CantidadMiembros = model.CantidadMiembros;
                    datos.CategoriaId = model.CategoriaId;
                    datos.Contacto = model.Contacto;
                    datos.Email = model.Email;
                    datos.Enlace = model.Enlace;
                    datos.EsGrupo = model.EsGrupo;
                    datos.EventoId = model.EventoId;
                    //datos.FechaCreacion = model.FechaCreacion;
                    //datos.FechaModificacion = model.FechaModificacion;
                    //datos.FechaPresentacion = model.FechaPresentacion;
                    //datos.Imagen = model.Imagen;
                    datos.Nombre = model.Nombre;
                    datos.Orden = model.Orden;
                    datos.ProcesoId = model.ProcesoId;
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
        public static List<SM.LibreriaComun.DTO.ArtistaPublicoDTO> ConsultaArtistasPorEventoId(int eventoId)
        {
            try
            {
                var model = new List<ArtistaConsultaDTO>();
                var listResultado = new List<SM.LibreriaComun.DTO.ArtistaPublicoDTO>();
                model = ArtistasServicio.ConsultaArtistasPorEventoId(eventoId);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new SM.LibreriaComun.DTO.ArtistaPublicoDTO();
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
        public static string ConsultarMunicipio(int EventoId)
        {
            string codigoMunicipio = "";
            try
            {

                codigoMunicipio = ArtistasServicio.ConsultarMunicipio(EventoId);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return codigoMunicipio;
        }
        #endregion
    }
}
