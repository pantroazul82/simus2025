using SM.Datos.Basicas;
using SM.Datos.DTO;
using SM.Datos.Servicios;
using SM.LibreriaComun.DTO.Circulacion;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SM.Datos.Eventos
{
    public class EventosPeriodicosServicio
    {
        #region Actualización
        public static int Agregar(ART_MUSICA_EVENTOS_PERIODICOS registro)
        {
            int registroId = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_EVENTOS_PERIODICOS.Add(registro);
                    context.SaveChanges();
                    registroId = registro.Id;

                }

                return registroId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Actualizar(int registroId, EventoPeriodicoNuevoDTO datos, int UsuarioId)
                                 
        {
            try
            {

                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_EVENTOS_PERIODICOS.Where(x => x.Id == registroId).FirstOrDefault();

                    if (entidad != null)
                    {
                        entidad.Nombre = datos.Nombre;
                        entidad.Descripcion = datos.Descripcion;
                        entidad.EstadoId = Convert.ToInt32(datos.EstadoId);
                        entidad.Lugar = datos.lugar;
                        entidad.ClasificacionId = Convert.ToInt32(datos.TipoEventoId);
                        entidad.CodDepto = datos.CodDepartamento;
                        entidad.CodMunicipio = datos.codMunicipio; 
                        entidad.CorreoElectronico = datos.CorreoElectronico;
                        entidad.Departamento = ServicioBasicas.obtenerNombreDepartamento(datos.CodDepartamento);
                        entidad.Municipio = ServicioBasicas.obtenerNombreMunicipio(datos.codMunicipio);
                        entidad.EsActivo = datos.EsActivo;
                        entidad.PaginaWeb = datos.PaginaWeb;
                        entidad.UrlVideoYoutube = datos.UrlVideoYoutube;
                        entidad.Telefono = datos.Telefono;
                        entidad.FechaActualizacion = DateTime.Now;
                        entidad.Version = datos.Version;
                        entidad.EntidadId = Convert.ToInt32(datos.ActorId);
                        entidad.NombreEntidad = ConvocatoriaServicio.ObtenerNombreEntidad(Convert.ToInt32(datos.ActorId));
                     
                      
                    }
                    context.SaveChanges();

                }
            }
            catch (Exception)
            { throw; }
        }
        #endregion

        #region consulta

        public static ART_MUSICA_EVENTOS_PERIODICOS ConsultarPorId(int Id)
        {

            var registro = new ART_MUSICA_EVENTOS_PERIODICOS();

            try
            {
                using (var context = new SIPAEntities())
                {

                    registro = context.ART_MUSICA_EVENTOS_PERIODICOS.Where(x => x.Id == Id).FirstOrDefault();


                }
                return registro;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<EventosPeriodicosDTO> ConsultarPorUsuarioId(int UsuarioId)
        {

            List<EventosPeriodicosDTO> listResultado = new List<EventosPeriodicosDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<EventosPeriodicosDTO>(@"EXEC ART_MUSICA_EVENTOS_PERIODICOS_POR_USUARIO @UsuarioId", new SqlParameter("UsuarioId", UsuarioId)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<EventosPeriodicosDTO> ConsultarPorEstadoId(int EstadoId)
        {

            List<EventosPeriodicosDTO> listResultado = new List<EventosPeriodicosDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<EventosPeriodicosDTO>(@"EXEC ART_MUSICA_EVENTOS_PERIODICOS_POR_ESTADO @EstadoId", new SqlParameter("EstadoId", EstadoId)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<EventosPeriodicosDTO> ConsultarPorMunicipio(int UsuarioId)
        {

            List<EventosPeriodicosDTO> listResultado = new List<EventosPeriodicosDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<EventosPeriodicosDTO>(@"EXEC ART_MUSICA_EVENTOS_PERIODICOS_COORDINADOR @UsuarioId", new SqlParameter("UsuarioId", UsuarioId)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<EventosPeriodicosDTO> ConsultarTodos()
        {

            List<EventosPeriodicosDTO> listResultado = new List<EventosPeriodicosDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<EventosPeriodicosDTO>(@"EXEC ART_MUSICA_EVENTOS_PERIODICOS_TODOS").ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<HomeEstandarResultado> ConsultarEventosPublicados()
        {

            List<HomeEstandarResultado> listResultado = new List<HomeEstandarResultado>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = (from a in context.ART_MUSICA_EVENTOS_PERIODICOS
                                     join c in context.ART_MUSICA_PARAMETROS_SERVICIOS on a.ClasificacionId equals c.Id
                                     where a.EstadoId == 2
                                     where a.EsActivo == true
                                     where c.CategoriaId == 13

                                     select new HomeEstandarResultado
                                     {
                                         Id = a.Id,
                                         Clasificacion = c.Nombre,
                                         ClasificacionId = a.ClasificacionId,
                                         CodDepto = a.CodDepto,
                                         CodMunicipio = a.CodMunicipio,
                                         Departamento = a.Departamento,
                                         Municipio = a.Municipio,
                                         Nombre = a.Nombre,
                                         Version = a.Version
                                     }).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<HomeEstandarResultado> ConsultarEventosPublicadosPorDepartamento(string CodDepto)
        {

            List<HomeEstandarResultado> listResultado = new List<HomeEstandarResultado>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = (from a in context.ART_MUSICA_EVENTOS_PERIODICOS
                                     join c in context.ART_MUSICA_PARAMETROS_SERVICIOS on a.ClasificacionId equals c.Id
                                     where a.EstadoId == 2
                                     where a.EsActivo == true
                                     where c.CategoriaId == 13
                                     where a.CodDepto == CodDepto
                                     select new HomeEstandarResultado
                                 {
                                     Id = a.Id,
                                     Clasificacion = c.Nombre,
                                     ClasificacionId = a.ClasificacionId,
                                     CodDepto = a.CodDepto,
                                     CodMunicipio = a.CodMunicipio,
                                     Departamento = a.Departamento,
                                     Municipio = a.Municipio,
                                     Nombre = a.Nombre,
                                     Version = a.Version
                                 }).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<HomeEstandarResultado> ConsultarEventosPublicadosPorMunicipio(string CodMunicipio)
        {

            List<HomeEstandarResultado> listResultado = new List<HomeEstandarResultado>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = (from a in context.ART_MUSICA_EVENTOS_PERIODICOS
                                     join c in context.ART_MUSICA_PARAMETROS_SERVICIOS on a.ClasificacionId equals c.Id
                                     where a.EstadoId == 2
                                     where a.EsActivo == true
                                     where c.CategoriaId == 13
                                     where a.CodMunicipio == CodMunicipio
                                     select new HomeEstandarResultado
                                     {
                                         Id = a.Id,
                                         Clasificacion = c.Nombre,
                                         ClasificacionId = a.ClasificacionId,
                                         CodDepto = a.CodDepto,
                                         CodMunicipio = a.CodMunicipio,
                                         Departamento = a.Departamento,
                                         Municipio = a.Municipio,
                                         Nombre = a.Nombre,
                                         Version = a.Version
                                     }).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<HomeEstandarResultado> ConsultarEventosPublicadosPorClasificacionId(int ClasificacionId)
        {

            List<HomeEstandarResultado> listResultado = new List<HomeEstandarResultado>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = (from a in context.ART_MUSICA_EVENTOS_PERIODICOS
                                     join c in context.ART_MUSICA_PARAMETROS_SERVICIOS on a.ClasificacionId equals c.Id
                                     where a.EstadoId == 2
                                     where a.EsActivo == true
                                     where c.CategoriaId == 13
                                     where a.ClasificacionId == ClasificacionId
                                     select new HomeEstandarResultado
                                     {
                                         Id = a.Id,
                                         Clasificacion = c.Nombre,
                                         ClasificacionId = a.ClasificacionId,
                                         CodDepto = a.CodDepto,
                                         CodMunicipio = a.CodMunicipio,
                                         Departamento = a.Departamento,
                                         Municipio = a.Municipio,
                                         Nombre = a.Nombre,
                                         Version = a.Version
                                     }).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static ART_MUSICA_EVENTOS_PERIODICOS ConsultarEventosPeriodicosPorId(int Id)
        {

            ART_MUSICA_EVENTOS_PERIODICOS resultado = new ART_MUSICA_EVENTOS_PERIODICOS();
            try
            {
                using (var context = new SIPAEntities())
                {

                    resultado = context.ART_MUSICA_EVENTOS_PERIODICOS.Where(x => x.Id == Id).SingleOrDefault();


                }
                return resultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static byte[] ObtenerImagenPrincipal(int Id)
        {

            byte[] imagenPrincipal = null;
            try
            {
                using (var context = new SIPAEntities())
                {

                    imagenPrincipal = context.ART_MUSICA_IMAGENES.Where(x => x.EventoPeriodicoId == Id && x.Principal == true).SingleOrDefault().Imagen;


                }
                return imagenPrincipal;

            }
            catch (Exception)
            {
                throw;
            }
        }



        public static List<ART_MUSICA_IMAGENES> ConsultarImagenesEventos(int Id)
        {

            List<ART_MUSICA_IMAGENES> resultado = new List<ART_MUSICA_IMAGENES>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    resultado = context.ART_MUSICA_IMAGENES.Where(x => x.EventoPeriodicoId == Id).ToList();


                }
                return resultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
