using System.Collections.Generic;
using System.Linq;
using SM.Datos.DTO;
using SM.SIPA;
using SM.Datos.Agentes;
using System.Data.SqlClient;
using System;
using SM.Datos.Basicas;

namespace SM.Datos.Eventos
{
    public class ArtistasServicio
    {
        #region Actualizacion
        public static int CrearArtistas(int ArtMusicaUsuarioId,
                                         int EventoId,
                                          string Nombre,
                                          string Contacto,
                                          string Enlace,
                                          string Telefono,
                                          string Email,
                                          int Orden,
                                          int cantidadMiembros,
                                          int ProcesoId,
                                          int CategoriaId,
                                          byte[] imagen,
                                          string resena,
                                          bool ? EsGrupo)
                                       
                                         
                                         
        {
            int ArtistaId = 0;
            try
            {
                     
                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {

                            var nuevo = new ART_MUSICA_ARTISTAS_CELEBRA 
                            {
                                Nombre = Nombre,
                                CantidadMiembros = cantidadMiembros,
                                Contacto = Contacto,
                                CategoriaId = CategoriaId,
                                Email = Email,
                                Enlace = Enlace,
                                EsGrupo = EsGrupo,
                                EventoId = EventoId,
                                FechaCreacion = DateTime.Now,
                                FechaPresentacion = DateTime.Now,
                                Orden = Orden,
                                ProcesoId = ProcesoId,
                                Resena = resena,
                                Telefono = Telefono, 
                                Imagen = imagen,
                                UsuarioId = ArtMusicaUsuarioId,
                            };
                            context.ART_MUSICA_ARTISTAS_CELEBRA.Add(nuevo);
                           
                            context.SaveChanges();
                            dbContextTransaction.Commit();
                            ArtistaId = nuevo.Id;

                        }
                        catch
                        {
                            dbContextTransaction.Rollback();
                            throw;
                        }
                    }


                }
           
            }
            catch (Exception)
            {
                throw;
            }

            return ArtistaId;
        }

        public static void ActualizarArtistas(int ArtistaId,
                                             string Nombre,
                                          string Contacto,
                                          string Enlace,
                                          string Telefono,
                                          string Email,
                                          int Orden,
                                          int cantidadMiembros,
                                          int ProcesoId,
                                          int CategoriaId,
                                          byte[] imagen,
                                          string resena,
                                          bool? EsGrupo)
        {

            try
            {

              
                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var entidad = context.ART_MUSICA_ARTISTAS_CELEBRA.Where(x => x.Id == ArtistaId).FirstOrDefault();

                            if (entidad != null)
                            {
                                entidad.CantidadMiembros = cantidadMiembros;
                                entidad.CategoriaId = CategoriaId;
                                entidad.Contacto = Contacto;
                                entidad.Email = Email;
                                entidad.Enlace = Enlace;
                                entidad.EsGrupo = EsGrupo;
                                entidad.Nombre = Nombre;
                                entidad.Orden = Orden;
                                entidad.ProcesoId = ProcesoId;
                                entidad.Resena = resena;
                                entidad.Telefono = Telefono;
                                entidad.FechaModificacion = DateTime.Now;
                        
                                if (imagen != null)
                                    entidad.Imagen = imagen;


                            }
                            context.SaveChanges();
                            dbContextTransaction.Commit();
                        }
                        catch
                        {
                            dbContextTransaction.Rollback();
                            throw;
                        }
                    }

                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void EliminarArtista(int ArtistaId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    //Ojo preguntar sobre la eliminación
                    context.ART_MUSICA_ARTISTAS_CELEBRA.Remove(context.ART_MUSICA_ARTISTAS_CELEBRA.Where(x => x.Id == ArtistaId).FirstOrDefault());
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Consulta
        public static ART_MUSICA_ARTISTAS_CELEBRA ConsultarArtistaPorId(int artistaId)
        {
            var evento = new ART_MUSICA_ARTISTAS_CELEBRA();
            try
            {
                using (var context = new SIPAEntities())
                {

                    evento = context.ART_MUSICA_ARTISTAS_CELEBRA.Where(x => x.Id == artistaId).FirstOrDefault();

                }
                return evento;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ART_MUSICA_ARTISTAS_CELEBRA ConsultarArtistaPorEventoId(int EventoID)
        {
            var evento = new ART_MUSICA_ARTISTAS_CELEBRA();
            try
            {
                using (var context = new SIPAEntities())
                {

                    evento = context.ART_MUSICA_ARTISTAS_CELEBRA.Where(x => x.EventoId == EventoID).FirstOrDefault();

                }
                return evento;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string ConsultarMunicipio(int EventoId)
        {
            string codigoMunicipio = "";
            try
            {
                using (var context = new SIPAEntities())
                {

                    codigoMunicipio = context.ART_MUSICA_EVENTOS.Where(x => x.Id == EventoId).FirstOrDefault().CodMunicipio; 

                }
                return codigoMunicipio;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ArtistaConsultaDTO> ConsultaArtistasPorEventoId(int EventoId)
        {
            List<ArtistaConsultaDTO> listResultado;
           
            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = (from a in context.ART_MUSICA_ARTISTAS_CELEBRA
                                     join c in context.ART_MUSICA_CELEBRA_CATEGORIA on a.CategoriaId equals c.Id
                                     join p in context.ART_MUSICA_PROCESO_FORMACION on a.ProcesoId equals p.Id
                                     where a.EventoId == EventoId
                                     where c.EsActivo == true
                                     orderby  a.Orden 
                                     select new ArtistaConsultaDTO
                                         {
                                             CantidadMiembros = a.CantidadMiembros,
                                             Categoria = c.Nombre,
                                             Contacto = a.Contacto,
                                             Email = a.Email,
                                             Enlace = a.Enlace,
                                             EsGrupo = a.EsGrupo ?? false,
                                             EventoId = a.EventoId,
                                             Id = a.Id,
                                             Nombre = a.Nombre,
                                             Orden = a.Orden,
                                             Proceso = p.Nombre,
                                             Telefono= a.Telefono,
                                             Resena = a.Resena 
                                         }).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<MunicipiosParticipantesDTO> ConsultarMunicipiosParticipantes()
        {

            List<MunicipiosParticipantesDTO> listResultado = new List<MunicipiosParticipantesDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<MunicipiosParticipantesDTO>(@"EXEC ART_MUSICA_CANTIDAD_MUNICIPIOS").ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ConsultarCantidadConciertos()
        {
            int intResultado = 0;
         
            try
            {
                using (var context = new SIPAEntities())
                {


                    var cantidad = context.Database.SqlQuery<int>(@"EXEC ART_MUSICA_CANTIDAD_CONCIERTOS").FirstOrDefault();
                    if (cantidad != null)
                        intResultado = Convert.ToInt32(cantidad);


                }
                return intResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ConsultarCantidadArtistas()
        {
            int intResultado = 0;

            try
            {
                using (var context = new SIPAEntities())
                {


                    var cantidad = context.Database.SqlQuery<int>(@"EXEC ART_MUSICA_CANTIDAD_ARTISTAS").FirstOrDefault();
                    if (cantidad != null)
                        intResultado = Convert.ToInt32(cantidad);


                }
                return intResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ConsultarCantidadGrupos()
        {
            int intResultado = 0;

            try
            {
                using (var context = new SIPAEntities())
                {


                    var cantidad = context.Database.SqlQuery<int>(@"EXEC ART_MUSICA_CANTIDAD_AGRUPACIONES").FirstOrDefault();
                    if (cantidad != null)
                        intResultado = Convert.ToInt32(cantidad);


                }
                return intResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
