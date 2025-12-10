using SM.Datos.Basicas;
using SM.Datos.Entidades;
using SM.Datos.Eventos;
using SM.Datos.Servicios;
using SM.LibreriaComun.DTO;
using SM.LibreriaComun.DTO.Circulacion;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Aplicacion.Eventos
{
    public class EventosPeriodicosNeg
    {
        #region Actualizacion
        public static int Crear(EventoPeriodicoNuevoDTO model, int UsuarioId)
        {
            int registroId = 0;
            try
            {

                var registro = new ART_MUSICA_EVENTOS_PERIODICOS
                {
                    UrlVideoYoutube = model.UrlVideoYoutube,
                    ClasificacionId = Convert.ToInt32(model.TipoEventoId),
                    CodDepto = model.CodDepartamento,
                    CodMunicipio = model.codMunicipio,
                    CorreoElectronico = model.CorreoElectronico,
                    Telefono = model.Telefono,
                    Descripcion = model.Descripcion,
                    Lugar = model.lugar,
                    Version = model.Version,
                    EntidadId = Convert.ToInt32(model.ActorId),
                    EsActivo = model.EsActivo,
                    EstadoId = 1,
                    Nombre = model.Nombre,
                    PaginaWeb = model.PaginaWeb,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now,
                    UsuarioId = UsuarioId

                };

                registro.NombreEntidad = ConvocatoriaServicio.ObtenerNombreEntidad(Convert.ToInt32(model.ActorId));
                registro.Departamento = ServicioBasicas.obtenerNombreDepartamento(model.CodDepartamento);
                registro.Municipio = ServicioBasicas.obtenerNombreMunicipio(model.codMunicipio);

                registroId = EventosPeriodicosServicio.Agregar(registro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return registroId;
        }

        public static void Actualizar(int Id, EventoPeriodicoNuevoDTO model, int UsuarioId)
        {
            try
            {

                EventosPeriodicosServicio.Actualizar(Id, model, UsuarioId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Consultas
        public static EventoPeriodicoNuevoDTO ConsultarPorId(int Id)
        {
            try
            {
                var datos = new EventoPeriodicoNuevoDTO();
                var model = EventosPeriodicosServicio.ConsultarPorId(Id);

                if (model != null)
                {

                    datos.ActorId = model.EntidadId.ToString();


                    datos.Descripcion = model.Descripcion;
                    datos.NombreEstado = ConvocatoriaServicio.ObtenerNombreEstadoSIMUS(model.EstadoId);
                    datos.EstadoId = model.EstadoId.ToString();
                    datos.Id = model.Id;
                    datos.Nombre = model.Nombre;
                    datos.Tipo = "7";
                    datos.TipoEventoId = model.ClasificacionId.ToString();
                    datos.CodDepartamento = model.CodDepto;
                    datos.codMunicipio = model.CodMunicipio;
                    datos.UrlVideoYoutube = model.UrlVideoYoutube;
                    datos.CorreoElectronico = model.CorreoElectronico;
                    datos.lugar = model.Lugar;
                    datos.EsActivo = (bool)model.EsActivo;
                    datos.Version = model.Version;
                    datos.Telefono = model.Telefono;
                    datos.PaginaWeb = model.PaginaWeb;
                    datos.UsuarioId = model.UsuarioId;
                    datos.NombreEstado = ConvocatoriaServicio.ObtenerNombreEstadoSIMUS(model.EstadoId);
                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static EventosPeriodicosHomeDTO ConsultarEventosFichaId(int Id)
        {
            try
            {
                var model = new ART_MUSICA_EVENTOS_PERIODICOS();
                var datos = new EventosPeriodicosHomeDTO();
                model = EventosPeriodicosServicio.ConsultarEventosPeriodicosPorId(Id);
                List<ImagenesBanner> listado = new List<ImagenesBanner>();
                List<ART_MUSICA_IMAGENES> listadoimagenes = new List<ART_MUSICA_IMAGENES>();

                if (model != null)
                {
                    datos.EntidadId = model.EntidadId;
                    datos.Claasificacion = EscenariosServicios.ConsultarClasificacionNombre(model.ClasificacionId);
                    datos.CodDepto = model.CodDepto;
                    datos.Departamento = model.Departamento;
                    datos.Municipio = model.Municipio;
                    datos.Nombre = model.Nombre;
                    datos.NombreEntidad = model.NombreEntidad;
                    datos.PaginaWeb = model.PaginaWeb;
                    datos.Telefono = model.Telefono;
                    datos.CorreoElectronico = model.CorreoElectronico;
                    datos.Version = model.Version;
                    datos.Descripcion = model.Descripcion;
                    datos.Lugar = model.Lugar;
                    listadoimagenes = EventosPeriodicosServicio.ConsultarImagenesEventos(Id);

                    if (listadoimagenes != null)
                    {
                        foreach (var x in listadoimagenes)
                        {
                            ImagenesBanner item = new ImagenesBanner();
                            item.imagen = x.Imagen;
                            listado.Add(item);
                        }

                        datos.banner = listado;
                    }
                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EventosPeriodicosDTO> ConsultarPorUsuarioId(int UsuarioID)
        {
            try
            {

                var listResultado = new List<EventosPeriodicosDTO>();
                listResultado = EventosPeriodicosServicio.ConsultarPorUsuarioId(UsuarioID);
                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EventosPeriodicosDTO> ConsultarPorEstadoId(int EstadoId)
        {
            try
            {

                var listResultado = new List<EventosPeriodicosDTO>();
                listResultado = EventosPeriodicosServicio.ConsultarPorEstadoId(EstadoId);
                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EventosPeriodicosDTO> ConsultarPorMunicipio(int UsuarioID)
        {
            try
            {

                var listResultado = new List<EventosPeriodicosDTO>();
                listResultado = EventosPeriodicosServicio.ConsultarPorMunicipio(UsuarioID);
                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EventosPeriodicosDTO> ConsultarTodos()
        {
            try
            {

                var listResultado = new List<EventosPeriodicosDTO>();
                listResultado = EventosPeriodicosServicio.ConsultarTodos();
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
