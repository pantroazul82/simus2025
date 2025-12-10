using SM.Datos.AuditoriaData;
using SM.Datos.DTO.Servicios;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.Servicios
{
    public class HerramientaServicio
    {
        #region Actualizacion
        public static int Agregar(ART_MUSICA_HERRAMIENTAS registro, string NombreUsuario, int ArtMusicaUsuarioId, string strIP)
        {
            int ServicioId = 0;
            try
            {

                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_HERRAMIENTAS.Add(registro);
                    context.SaveChanges();
                    ServicioId = registro.Id;

                    string temp;
                    temp = string.Format("El usuario {0} ({1}) creó el {2} la  utilidad.\nDatos actuales:\n{3}. Actor nombre: :\n{4} ", NombreUsuario, ArtMusicaUsuarioId, DateTime.Now, registro, registro.Nombre);
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine(temp);
                    ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.Herramientas.ToString(), IpUsuario = strIP, RegistroId = ServicioId, UsuarioId = ArtMusicaUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Creación" };

                    var auditoria = new RegistroOperacionServicio();
                    auditoria.Crear(registroOperacion);

                }

                return ServicioId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ActualizarDocumento(int herramientaID,
                                            int documentoId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_HERRAMIENTAS.Where(x => x.Id == herramientaID).FirstOrDefault();

                    if (entidad != null)
                    {
                        entidad.DocumentoId = documentoId;

                    }
                    context.SaveChanges();
                }
            }
            catch (Exception)
            { throw; }
        }

        public static void Actualizar(int HerramientaId,
                                    string Nombre,
                                    string descripcion,
                                    string autores,
                                    int EstadoId,
                                    int TipoId,
                                    string link,
                                    string urlyoutube,                      
                                    int UsuarioAprobadorId,
                                     string NombreUsuario,
                                    string strIP)
        {
            try
            {
               
                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_HERRAMIENTAS.Where(x => x.Id == HerramientaId).FirstOrDefault();
                   
                  
                    if (entidad != null)
                    {
                        entidad.Nombre = Nombre;
                        entidad.Descripcion = descripcion;
                        entidad.EstadoId = EstadoId;
                        entidad.TipoId = TipoId;
                        entidad.autores = autores;
                        entidad.UrlArchivo = link;
                        entidad.UrlVideo = urlyoutube;
                        entidad.UsuarioAprobadorId = UsuarioAprobadorId;
                        entidad.FechaActualizacion = DateTime.Today;
                        
                    }
                    context.SaveChanges();

                    //auditoria

                    string temp;
                    temp = string.Format("El usuario {0} ({1}) creó el {2} la  utilidad.\nDatos actuales:\n{3}. Actor responsable: \n{4} ", NombreUsuario, UsuarioAprobadorId, DateTime.Now, "ART_MUSICA_HERRAMIENTAS", Nombre);
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine(temp);
                    ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.Herramientas.ToString(), IpUsuario = strIP, RegistroId = HerramientaId, UsuarioId = UsuarioAprobadorId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Actualización" };

                    var auditoria = new RegistroOperacionServicio();
                    auditoria.Crear(registroOperacion);

                }
            }
            catch (Exception)
            { throw; }
        }
        #endregion

        #region Consultas
        public static List<HerramientaConsultaDTO> ConsultarHerramientas()
        {
            var listBasica = new List<HerramientaConsultaDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listBasica = (from h in context.ART_MUSICA_HERRAMIENTAS
                                  join e in context.ART_MUSICA_ESTADOS on h.EstadoId equals e.Id
                                  join p in context.ART_MUSICA_PARAMETROS_SERVICIOS on h.TipoId  equals p.Id 
                                  orderby h.Id descending
                                  select new HerramientaConsultaDTO
                                  {
                                     Estado = e.Nombre,
                                     Id = h.Id,
                                     Nombre = h.Nombre,
                                     TipoHerramienta = p.Nombre,
                                     TipoId = h.TipoId,
                                     FechaActualizacion = h.FechaActualizacion ?? DateTime.Today
                                  }).ToList();


                }
                return listBasica;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ART_MUSICA_HERRAMIENTAS ObtenerHerramienta(int Id)
        {
            var listBasica = new ART_MUSICA_HERRAMIENTAS();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listBasica = context.ART_MUSICA_HERRAMIENTAS.Where(x=> x.Id == Id).SingleOrDefault(); 

                }
                return listBasica;

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
