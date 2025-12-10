using System.Collections.Generic;
using System.Linq;
using SM.Datos.DTO;
using SM.SIPA;
using SM.Datos.Agentes;
using System.Data.SqlClient;
using System;
using SM.Datos.Basicas;
using System.Text;
using SM.Datos.AuditoriaData;

namespace SM.Datos.Eventos
{
    public class EventoServicios
    {
        #region Consultas
        public static List<EventoResultadoDTO> ConsultarConciertorPorMunicipio(string codigoMunicipio, int periodo)
        {
            var listBasica = new List<EventoResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listBasica = (from e in context.ART_MUSICA_EVENTOS
                                  where e.AreaArtisticaId == 15
                                  where e.AnoEvento == periodo 
                                  where e.CodMunicipio == codigoMunicipio
                                  select new EventoResultadoDTO
                                  {
                                    EventoId = e.Id,
                                    EntidadOrganizadora = e.EntidadOrganizadora,
                                    LugarEvento = e.LugarEvento,
                                    NombreDepartamento = e.NombreDepartamento,
                                    NombreMunicipio = e.NombreMunicipio,
                                    FechaEvento = e.FechaEvento,
                                    FechaCreacion = e.FechaCreacion,
                                    UsuarioId = e.UsuarioId,
                                    Tipo = e.Tipo,
                                    AnoEvento = e.AnoEvento 
                                  }).ToList();

                }
                return listBasica;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<ART_MUSICA_GRUPOS> ConsultarGrupos(int EventoId)
        {
            var grupos = new List<ART_MUSICA_GRUPOS>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    grupos = (from g in context.ART_MUSICA_GRUPOS
                              join e in context.ART_MUSICA_GRUPOEVENTOS on g.Id equals e.GrupoId
                              where e.EventoId == EventoId
                              select g).ToList();

                }
                return grupos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ART_MUSICA_EVENTOS> ConsultarProgramacionConciertos(int anoEvento, string codigoMunicipio)
        {
            var listResultado = new List<ART_MUSICA_EVENTOS>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = context.ART_MUSICA_EVENTOS.Where(x => x.AnoEvento == anoEvento && x.AreaArtisticaId == 15
                                    && x.Tipo == "Música" && x.CodMunicipio == codigoMunicipio).ToList();

                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static ART_MUSICA_EVENTOS ConsultarEventoPorId(int EventoId)
        {
            var evento = new ART_MUSICA_EVENTOS();
            try
            {
                using (var context = new SIPAEntities())
                {

                    evento = context.ART_MUSICA_EVENTOS.Where(x => x.Id == EventoId).FirstOrDefault();

                }
                return evento;

            }
            catch (Exception)
            {
                throw;
            }
        }

     
        public static List<DepartamentoDTO> ConsultarDepartamentoXMunicipio()
        {

            List<DepartamentoDTO> listResultado = new List<DepartamentoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<DepartamentoDTO>(@"EXEC ART_MUSICA_DEPARTAMENTOS_POR_MUNICIPIOS").ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<DepartamentoDTO> ConsultarDepartamentoXMunicipioPeriodo(int periodo)
        {

            List<DepartamentoDTO> listResultado = new List<DepartamentoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<DepartamentoDTO>(@"EXEC ART_MUSICA_DEPARTAMENTO_PERIODO @Periodo", new SqlParameter("Periodo", periodo)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<EventoResultadoDTO> ConsultarUltimosConciertosCreados(int periodo)
        {

            List<EventoResultadoDTO> listResultado = new List<EventoResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<EventoResultadoDTO>(@"EXEC ART_MUSICA_ULTIMOS_CONCIERTOS_CELEBRA @Periodo", new SqlParameter("Periodo", periodo)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<EventoResultadoDTO> ConsultarEventosTodos()
        {

            List<EventoResultadoDTO> listResultado = new List<EventoResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<EventoResultadoDTO>(@"EXEC ART_MUSICA_EVENTOS_TODOS").ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<EventoResultadoDTO> ConsultarEventosPorUsuarioId(int UsuarioId, string Tipo)
        {

            List<EventoResultadoDTO> listResultado = new List<EventoResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<EventoResultadoDTO>(@"EXEC ART_MUSICA_EVENTOS_UsuarioId @UsuarioId, @Tipo", new SqlParameter("UsuarioId", UsuarioId), new SqlParameter("Tipo", Tipo)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<EventoResultadoDTO> ConsultarEventosTodosPorTipo(string Tipo, int filtroano)
        {

            List<EventoResultadoDTO> listResultado = new List<EventoResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<EventoResultadoDTO>(@"EXEC ART_MUSICA_EVENTOS_TODOS_TIPO_ANO @Tipo, @filtroano", new SqlParameter("Tipo", Tipo), new SqlParameter("filtroano", filtroano)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<EventoResultadoDTO> ConsultarEventosCapitales(int filtroano)
        {

            List<EventoResultadoDTO> listResultado = new List<EventoResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<EventoResultadoDTO>(@"EXEC ART_MUSICA_EVENTOS_PROGRAMACION_ANO_CAPITALES @filtroano", new SqlParameter("filtroano", filtroano)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<EventoResultadoDTO> ConsultarEventosPorCodigoMunicipio(int filtroano, string CodMunicipio)
        {

            List<EventoResultadoDTO> listResultado = new List<EventoResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<EventoResultadoDTO>(@"EXEC ART_MUSICA_EVENTOS_PROGRAMACION_ANO_POR_MUNICIPIO @filtroano, @CodMunicipio", new SqlParameter("filtroano", filtroano), new SqlParameter("CodMunicipio", CodMunicipio)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<EventoResultadoDTO> ConsultarEventosPorCodigoDepto(int filtroano, string CodDepto)
        {

            List<EventoResultadoDTO> listResultado = new List<EventoResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<EventoResultadoDTO>(@"EXEC ART_MUSICA_EVENTOS_PROGRAMACION_ANO_POR_DEPARTAMENTO @filtroano, @CodDepto", new SqlParameter("filtroano", filtroano), new SqlParameter("CodDepto", CodDepto)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public static List<string> ConsultarArtistas(int EventoId)
        {

            var listResultado = new List<string>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    listResultado = (from a in context.ART_MUSICA_ARTISTAS_CELEBRA
                                     where a.EventoId == EventoId
                                     select a.Nombre).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Parametro> ConsultarArtistasPorEventoId(int eventoId)
        {

            var listResultado = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    listResultado = (from a in context.ART_MUSICA_ARTISTAS_CELEBRA
                                     join e in context.ART_MUSICA_EVENTOS on a.EventoId equals e.Id
                                     where a.EventoId == eventoId
                                     orderby a.Nombre 
                                     select new Parametro { Nombre = a.Nombre, Id = a.EventoId }).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Parametro> ConsultarArtistasPorCodigoDepto(int anoEvento, string codDepto)
        {

            var listResultado = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    listResultado = (from a in context.ART_MUSICA_ARTISTAS_CELEBRA
                                     join e in context.ART_MUSICA_EVENTOS on a.EventoId equals e.Id
                                     where e.AnoEvento == anoEvento
                                     where e.CodDepartamento == codDepto
                                     select new Parametro { Nombre = a.Nombre, Id = a.EventoId }).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Parametro> ConsultarArtistasPorCodigoMunicipio(int anoEvento, string codMunicipio)
        {

            var listResultado = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    listResultado = (from a in context.ART_MUSICA_ARTISTAS_CELEBRA
                                     join e in context.ART_MUSICA_EVENTOS on a.EventoId equals e.Id
                                     where e.AnoEvento == anoEvento
                                     where e.CodMunicipio == codMunicipio
                                     select new Parametro { Nombre = a.Nombre, Id = a.EventoId }).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<EventoResultadoDTO> ConsultarEventoPorEstadoId(int EstadoId, string Tipo)
        {

            List<EventoResultadoDTO> listResultado = new List<EventoResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<EventoResultadoDTO>(@"EXEC ART_MUSICA_EVENTOS_EstadoId @EstadoId, @Tipo", new SqlParameter("EstadoId", EstadoId), new SqlParameter("Tipo", Tipo)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<EventoResultadoDTO> ConsultarEventoPorMunicipio(int UsuarioId, string Tipo)
        {

            List<EventoResultadoDTO> listResultado = new List<EventoResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<EventoResultadoDTO>(@"EXEC ART_MUSICA_EVENTOS_Municipio @UsuarioId, @Tipo", new SqlParameter("UsuarioId", UsuarioId), new SqlParameter("Tipo", Tipo)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<EventoResultadoDTO> ConsultarEventoPorDepartamento(string codDepartamento, string Tipo)
        {
            List<EventoResultadoDTO> listResultado = new List<EventoResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = context.Database.SqlQuery<EventoResultadoDTO>(@"EXEC ART_MUSICA_EVENTOS_CodigoDepartamento @CodigoDepartamento, @Tipo", new SqlParameter("CodigoDepartamento", codDepartamento), new SqlParameter("Tipo", Tipo)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<EventoResultadoDTO> ConsultarEventoPorArea(int UsuarioId, string Tipo)
        {
            List<EventoResultadoDTO> listResultado = new List<EventoResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = context.Database.SqlQuery<EventoResultadoDTO>(@"EXEC ART_MUSICA_EVENTOS_USUARIOYAREA @UsuarioId, @Tipo", new SqlParameter("UsuarioId", UsuarioId), new SqlParameter("Tipo", Tipo)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ListadoAnosDTO> ConsultarListadoAno(string CodigoMunicipio)
        {

            List<ListadoAnosDTO> listResultado = new List<ListadoAnosDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<ListadoAnosDTO>(@"EXEC ART_MUSICA_LISTADO_ANOS @CodMunicipio", new SqlParameter("CodMunicipio", CodigoMunicipio)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<DepartamentosParticipantesDTO> ConsultarCantidadDepartamentosDanza()
        {
            List<DepartamentosParticipantesDTO> listResultado = new List<DepartamentosParticipantesDTO>();

            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = context.Database.SqlQuery<DepartamentosParticipantesDTO>(@"EXEC ART_MUSICA_CANTIDAD_Departamento_Danza").ToList();

                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<MunicipiosParticipantesDTO> ConsultarCantidadMunicipiosDanza()
        {
            List<MunicipiosParticipantesDTO> listResultado = new List<MunicipiosParticipantesDTO>();

            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<MunicipiosParticipantesDTO>(@"EXEC ART_MUSICA_CANTIDAD_MUNICIPIOSDanza").ToList();

                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ConsultarCantidadEventosDanza()
        {
            int intResultado = 0;

            try
            {
                using (var context = new SIPAEntities())
                {


                    var cantidad = context.Database.SqlQuery<int>(@"EXEC ART_MUSICA_CANTIDAD_CONCIERTOS_DANZA").FirstOrDefault();
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

        public static List<ConciertoResultadoDTO> ConsultarDetalleEventos(decimal AreaArtisticaId, int anoEvento, string Tipo)
        {

            List<ConciertoResultadoDTO> listResultado = new List<ConciertoResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<ConciertoResultadoDTO>(@"EXEC ART_MUSICA_CONCIERTOS_DETALLE @AreaArtisticaId, @Tipo, @AnoEvento", new SqlParameter("AreaArtisticaId", AreaArtisticaId), new SqlParameter("Tipo", Tipo), new SqlParameter("AnoEvento", anoEvento)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ArtistaPublicoDTO> ConsultarDetalleArtistas(int anoEvento)
        {

            List<ArtistaPublicoDTO> listResultado = new List<ArtistaPublicoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<ArtistaPublicoDTO>(@"EXEC ART_MUSICA_ARTISTAS_DETALLE @AnoEvento", new SqlParameter("AnoEvento", anoEvento)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ArtistaPublicoDTO> ConsultarDetalleGrupos(int anoEvento)
        {

            List<ArtistaPublicoDTO> listResultado = new List<ArtistaPublicoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<ArtistaPublicoDTO>(@"EXEC ART_MUSICA_CELEBRA_GRUPOS @AnoEvento", new SqlParameter("AnoEvento", anoEvento)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<MunicipiosParticipantesDTO> ConsultarMunicipiosFaltantes(int anoEvento)
        {

            List<MunicipiosParticipantesDTO> listResultado = new List<MunicipiosParticipantesDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<MunicipiosParticipantesDTO>(@"EXEC ART_MUSICA_MUNICIPIOS_FALTANTES @Anoevento", new SqlParameter("AnoEvento", anoEvento)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Actualizacion
        public static int CrearEvento(int ArtMusicaUsuarioId,
                                   decimal AreaArtisticaId,
                                 string Nombre,
                                 string EntidadOrganizadora,
                                 string codigoMunicipio,
                                 string codigoDepartamento,
                                 string LugarEvento,
                                 DateTime FechaEvento,
                                 string Tipo,
                                 byte[] imagen,
                                 string descripcion,
                                 string telefono,
                                 string Email)
        {

            try
            {
                int EventoId = 0;
                string Departamento = ServicioBasicas.obtenerNombreDepartamento(codigoDepartamento);
                string Municipio = ServicioBasicas.obtenerNombreMunicipio(codigoMunicipio);
                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {

                            var evento = new ART_MUSICA_EVENTOS
                            {
                                Nombre = Nombre,
                                AreaArtisticaId = AreaArtisticaId,
                                AnoEvento = FechaEvento.Year,
                                CodDepartamento = codigoDepartamento,
                                CodMunicipio = codigoMunicipio,
                                Descripción = descripcion,
                                EntidadOrganizadora = EntidadOrganizadora,
                                FechaEvento = FechaEvento,
                                LugarEvento = LugarEvento,
                                EstadoId = 2,
                                FechaCreacion = DateTime.Now,
                                NombreDepartamento = Departamento,
                                NombreMunicipio = Municipio,
                                Tipo = Tipo,
                                Imagen = imagen,
                                UsuarioId = ArtMusicaUsuarioId,
                                Telefono = telefono,
                                Email = Email,
                                Destacado = false,

                            };
                            context.ART_MUSICA_EVENTOS.Add(evento);
                            context.SaveChanges();
                            EventoId = evento.Id;


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
                return EventoId;

            }
            catch (Exception)
            {
                throw;
            }

        }


        public static int DuplicarEvento(int intEventoId,int ArtMusicaUsuarioId,  DateTime FechaEvento, string NombreUsuario, string strIP)
        {

            try
            {
                int EventoId = 0;
            
                using (var context = new SIPAEntities())
                {
                  
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var entidad = context.ART_MUSICA_EVENTOS.Where(x => x.Id == intEventoId).FirstOrDefault();
                            if (entidad != null)
                            {
                                var evento = new ART_MUSICA_EVENTOS
                                {
                                    Nombre = entidad.Nombre ,
                                    AreaArtisticaId = entidad.AreaArtisticaId,
                                    AnoEvento = FechaEvento.Year,
                                    CodDepartamento = entidad.CodDepartamento,
                                    CodMunicipio = entidad.CodMunicipio,
                                    Descripción = entidad.Descripción,
                                    EntidadOrganizadora = entidad.EntidadOrganizadora,
                                    FechaEvento = FechaEvento,
                                    LugarEvento = entidad.LugarEvento,
                                    EstadoId = 2,
                                    FechaCreacion = DateTime.Now,
                                    NombreDepartamento = entidad.NombreDepartamento,
                                    NombreMunicipio = entidad.NombreMunicipio,
                                    Tipo = entidad.Tipo,
                                    Imagen = entidad.Imagen,
                                    UsuarioId = ArtMusicaUsuarioId,
                                    Telefono = entidad.Telefono,
                                    Email = entidad.Email,
                                    Destacado = false,

                                };
                                context.ART_MUSICA_EVENTOS.Add(evento);
                                context.SaveChanges();
                                EventoId = evento.Id;
                                var listadoArtistas = new List<ART_MUSICA_ARTISTAS_CELEBRA>();
                                listadoArtistas = context.ART_MUSICA_ARTISTAS_CELEBRA.Where(x => x.EventoId == intEventoId).ToList();
                                if (listadoArtistas != null && listadoArtistas.Count > 0)
                                {
                                    foreach (var item in listadoArtistas)
                                    {
                                        var nuevo = new ART_MUSICA_ARTISTAS_CELEBRA
                                        {
                                            Nombre = item.Nombre,
                                            CantidadMiembros = item.CantidadMiembros,
                                            Contacto = item.Contacto,
                                            CategoriaId = item.CategoriaId,
                                            Email = item.Email,
                                            Enlace = item.Enlace,
                                            EsGrupo = item.EsGrupo,
                                            EventoId = EventoId,
                                            FechaCreacion = DateTime.Now,
                                            FechaPresentacion = DateTime.Now,
                                            Orden = item.Orden,
                                            ProcesoId = item.ProcesoId,
                                            Resena = item.Resena,
                                            Telefono = item.Telefono,
                                            Imagen = item.Imagen,
                                            UsuarioId = ArtMusicaUsuarioId,
                                        };
                                        context.ART_MUSICA_ARTISTAS_CELEBRA.Add(nuevo);
                                        context.SaveChanges();
                                    }
                                }

                                // Auditoria
                                string temp;
                                temp = string.Format("El usuario {0} ({1}) duplico el {2} el evento de celebra.\nDatos actuales:\n{3}. Actor nombre: :\n{4} ", NombreUsuario, ArtMusicaUsuarioId, DateTime.Now, entidad, entidad.EntidadId);
                                StringBuilder stringBuilder = new StringBuilder();
                                stringBuilder.AppendLine(temp);
                                ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.EventosCelebraMusica.ToString(), IpUsuario = strIP, RegistroId = EventoId, UsuarioId = ArtMusicaUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Duplicar" };

                                var auditoria = new RegistroOperacionServicio();
                                auditoria.Crear(registroOperacion);
                                context.SaveChanges();
                                dbContextTransaction.Commit();
                            }

                          

                        }
                        catch
                        {
                            dbContextTransaction.Rollback();
                            throw;
                        }
                    }


                }
                return EventoId;

            }
            catch (Exception)
            {
                throw;
            }

        }
        public static int CrearEventoDanza(int ArtMusicaUsuarioId,
                                           decimal AreaArtisticaId,
                                           string Nombre,
                                           string EntidadOrganizadora,
                                           string codigoMunicipio,
                                           string codigoDepartamento,
                                           string LugarEvento,
                                           DateTime FechaEvento,
                                           string Tipo,
                                           byte[] imagen,
                                           string descripcion,
                                           bool EsNacional,
                                           DateTime FechaFinal,
                                           string telefono,
                                           string Email)
        {

            try
            {
                int EventoId = 0;
                string Departamento = "";
                string Municipio = "";

                if (!EsNacional)
                {
                    Departamento = ServicioBasicas.obtenerNombreDepartamento(codigoDepartamento);
                    Municipio = ServicioBasicas.obtenerNombreMunicipio(codigoMunicipio);
                }
                else
                {
                    codigoMunicipio = "";
                    codigoDepartamento = "";
                }
                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {

                            var evento = new ART_MUSICA_EVENTOS
                            {
                                Nombre = Nombre,
                                AreaArtisticaId = AreaArtisticaId,
                                AnoEvento = FechaEvento.Year,
                                CodDepartamento = codigoDepartamento,
                                CodMunicipio = codigoMunicipio,
                                Descripción = descripcion,
                                EntidadOrganizadora = EntidadOrganizadora,
                                FechaEvento = FechaEvento,
                                FechaEventoFinal = FechaFinal,
                                EsNacional = EsNacional,
                                LugarEvento = LugarEvento,
                                EstadoId = 1,
                                FechaCreacion = DateTime.Now,
                                NombreDepartamento = Departamento,
                                NombreMunicipio = Municipio,
                                Tipo = Tipo,
                                Imagen = imagen,
                                UsuarioId = ArtMusicaUsuarioId,
                                Telefono = telefono,
                                Email = Email,
                                Destacado = false,
                            };
                            context.ART_MUSICA_EVENTOS.Add(evento);
                            context.SaveChanges();
                            EventoId = evento.Id;


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
                return EventoId;

            }
            catch (Exception)
            {
                throw;
            }

        }

        public static int CrearEventoDanzaDocumento(int ArtMusicaUsuarioId,
                                         decimal AreaArtisticaId,
                                         string Nombre,
                                         string EntidadOrganizadora,
                                         string codigoMunicipio,
                                         string codigoDepartamento,
                                         string LugarEvento,
                                         DateTime FechaEvento,
                                         string Tipo,
                                         byte[] imagen,
                                         string descripcion,
                                         bool EsNacional,
                                         DateTime FechaFinal,
                                         int DocumentoId,
                                         string telefono,
                                         string Email)
        {

            try
            {
                int EventoId = 0;
                string Departamento = "";
                string Municipio = "";

                if (!EsNacional)
                {
                    Departamento = ServicioBasicas.obtenerNombreDepartamento(codigoDepartamento);
                    Municipio = ServicioBasicas.obtenerNombreMunicipio(codigoMunicipio);
                }
                else
                {
                    codigoMunicipio = "";
                    codigoDepartamento = "";
                }
                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {

                            var evento = new ART_MUSICA_EVENTOS
                            {
                                Nombre = Nombre,
                                AreaArtisticaId = AreaArtisticaId,
                                AnoEvento = FechaEvento.Year,
                                CodDepartamento = codigoDepartamento,
                                CodMunicipio = codigoMunicipio,
                                Descripción = descripcion,
                                EntidadOrganizadora = EntidadOrganizadora,
                                FechaEvento = FechaEvento,
                                FechaEventoFinal = FechaFinal,
                                EsNacional = EsNacional,
                                LugarEvento = LugarEvento,
                                EstadoId = 1,
                                FechaCreacion = DateTime.Now,
                                NombreDepartamento = Departamento,
                                NombreMunicipio = Municipio,
                                Tipo = Tipo,
                                Imagen = imagen,
                                UsuarioId = ArtMusicaUsuarioId,
                                DocumentoId = DocumentoId,
                                Telefono = telefono,
                                Email = Email,
                                Destacado = false,
                            };
                            context.ART_MUSICA_EVENTOS.Add(evento);
                            context.SaveChanges();
                            EventoId = evento.Id;


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
                return EventoId;

            }
            catch (Exception)
            {
                throw;
            }

        }

        public static void ActualizarEvento(int EventoId,
                                            int ArtMusicaUsuarioId,
                                            decimal AreaArtisticaId,
                                            string Nombre,
                                            string EntidadOrganizadora,
                                            string codigoMunicipio,
                                            string codigoDepartamento,
                                            string LugarEvento,
                                            DateTime FechaEvento,
                                            string Tipo,
                                            byte[] imagen,
                                            string descripcion,
                                            string telefono,
                                            string Email)
        {

            try
            {
                string Departamento = ServicioBasicas.obtenerNombreDepartamento(codigoDepartamento);
                string Municipio = ServicioBasicas.obtenerNombreMunicipio(codigoMunicipio);
                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var entidad = context.ART_MUSICA_EVENTOS.Where(x => x.Id == EventoId).FirstOrDefault();

                            if (entidad != null)
                            {
                                entidad.UsuarioId = ArtMusicaUsuarioId;
                                if (string.IsNullOrEmpty(codigoDepartamento))
                                {
                                    entidad.CodDepartamento = "";
                                    entidad.CodMunicipio = "";
                                }
                                else
                                {
                                    entidad.CodDepartamento = codigoDepartamento;
                                    entidad.CodMunicipio = codigoMunicipio;
                                    entidad.NombreDepartamento = Departamento;
                                    entidad.NombreMunicipio = Municipio;
                                }
                                //if (entidad.EstadoId == AgenteConstantes.Aprobado)
                                //    entidad.EstadoId = AgenteConstantes.Actualizado;

                                entidad.Descripción = descripcion;
                                entidad.Nombre = Nombre;
                                entidad.AreaArtisticaId = AreaArtisticaId;
                                entidad.AnoEvento = FechaEvento.Year;
                                entidad.EntidadOrganizadora = EntidadOrganizadora;
                                entidad.FechaEvento = FechaEvento;
                                entidad.LugarEvento = LugarEvento;
                                entidad.FechaModificacion = DateTime.Now;
                                entidad.Telefono = telefono;
                                entidad.Email = Email;
                                entidad.Tipo = Tipo;
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

        public static void ActualizarEventoDanza(int EventoId,
                                   int ArtMusicaUsuarioId,
                                   decimal AreaArtisticaId,
                                  string Nombre,
                                  string EntidadOrganizadora,
                                  string codigoMunicipio,
                                  string codigoDepartamento,
                                  string LugarEvento,
                                  DateTime FechaEvento,
                                  string Tipo,
                                  byte[] imagen,
                                  string descripcion,
                                  bool EsNacional,
                                  DateTime Fechafinal,
                                  int DocumentoId,
                                  string telefono,
                                  string Email)
        {

            try
            {

                string Departamento = "";
                string Municipio = "";
                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var entidad = context.ART_MUSICA_EVENTOS.Where(x => x.Id == EventoId).FirstOrDefault();

                            if (entidad != null)
                            {
                                entidad.UsuarioId = ArtMusicaUsuarioId;
                                if (!EsNacional)
                                {
                                    Departamento = ServicioBasicas.obtenerNombreDepartamento(codigoDepartamento);
                                    Municipio = ServicioBasicas.obtenerNombreMunicipio(codigoMunicipio);
                                    entidad.CodDepartamento = codigoDepartamento;
                                    entidad.CodMunicipio = codigoMunicipio;
                                    entidad.NombreDepartamento = Departamento;
                                    entidad.NombreMunicipio = Municipio;
                                }
                                else
                                {
                                    entidad.CodDepartamento = "";
                                    entidad.CodMunicipio = "";
                                    entidad.NombreDepartamento = "";
                                    entidad.NombreMunicipio = "";
                                }

                                if (entidad.EstadoId == AgenteConstantes.Aprobado)
                                    entidad.EstadoId = AgenteConstantes.Actualizado;

                                entidad.Descripción = descripcion;
                                entidad.Nombre = Nombre;
                                entidad.AreaArtisticaId = AreaArtisticaId;
                                entidad.AnoEvento = FechaEvento.Year;
                                entidad.EntidadOrganizadora = EntidadOrganizadora;
                                entidad.FechaEvento = FechaEvento;
                                entidad.FechaEventoFinal = Fechafinal;
                                entidad.EsNacional = EsNacional;
                                entidad.LugarEvento = LugarEvento;
                                entidad.FechaModificacion = DateTime.Now;
                                entidad.Telefono = telefono;
                                entidad.Email = Email;
                                entidad.Tipo = Tipo;
                                if (imagen != null)
                                    entidad.Imagen = imagen;

                                if (DocumentoId > 0)
                                    entidad.DocumentoId = DocumentoId;

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


        public static void ActualizarEventoDanzaEstado(int EventoId,
                                  int ArtMusicaUsuarioId,
                                  decimal AreaArtisticaId,
                                 string Nombre,
                                 string EntidadOrganizadora,
                                 string codigoMunicipio,
                                 string codigoDepartamento,
                                 string LugarEvento,
                                 DateTime FechaEvento,
                                 string Tipo,
                                 byte[] imagen,
                                 string descripcion,
                                 bool EsNacional,
                                 DateTime Fechafinal,
                                 int DocumentoId,
                                 int EstadoId,
                                 string telefono,
                                 string Email,
                                 bool destacado)
        {

            try
            {
                string Departamento = "";
                string Municipio = "";
                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var entidad = context.ART_MUSICA_EVENTOS.Where(x => x.Id == EventoId).FirstOrDefault();


                            if (entidad != null)
                            {

                                if (!EsNacional)
                                {
                                    Departamento = ServicioBasicas.obtenerNombreDepartamento(codigoDepartamento);
                                    Municipio = ServicioBasicas.obtenerNombreMunicipio(codigoMunicipio);
                                    entidad.CodDepartamento = codigoDepartamento;
                                    entidad.CodMunicipio = codigoMunicipio;
                                    entidad.NombreDepartamento = Departamento;
                                    entidad.NombreMunicipio = Municipio;
                                }
                                else
                                {
                                    entidad.CodDepartamento = "";
                                    entidad.CodMunicipio = "";
                                    entidad.NombreDepartamento = "";
                                    entidad.NombreMunicipio = "";
                                }



                                if (EstadoId > 0)
                                    entidad.EstadoId = EstadoId;
                                entidad.Descripción = descripcion;
                                entidad.Nombre = Nombre;
                                entidad.AreaArtisticaId = AreaArtisticaId;
                                entidad.AnoEvento = FechaEvento.Year;
                                entidad.EntidadOrganizadora = EntidadOrganizadora;
                                entidad.FechaEvento = FechaEvento;
                                entidad.FechaEventoFinal = Fechafinal;
                                entidad.EsNacional = EsNacional;
                                entidad.LugarEvento = LugarEvento;
                                entidad.FechaModificacion = DateTime.Now;
                                entidad.Telefono = telefono;
                                entidad.Email = Email;
                                entidad.Destacado = destacado;
                                entidad.Tipo = Tipo;
                                if (imagen != null)
                                    entidad.Imagen = imagen;

                                if (DocumentoId > 0)
                                    entidad.DocumentoId = DocumentoId;

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
        public static void ActualizarEventoCambiarEstado(int EventoId,
                                   int ArtMusicaUsuarioId,
                                   decimal AreaArtisticaId,
                                  string Nombre,
                                  string EntidadOrganizadora,
                                  string codigoMunicipio,
                                  string codigoDepartamento,
                                  string LugarEvento,
                                  DateTime FechaEvento,
                                  string Tipo,
                                  byte[] imagen,
                                  string descripcion,
                                  int EstadoId,
                                 string telefono,
                                 string Email,
                                 bool destacado)
        {

            try
            {
                string Departamento = ServicioBasicas.obtenerNombreDepartamento(codigoDepartamento);
                string Municipio = ServicioBasicas.obtenerNombreMunicipio(codigoMunicipio);
                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var entidad = context.ART_MUSICA_EVENTOS.Where(x => x.Id == EventoId).FirstOrDefault();

                            if (entidad != null)
                            {
                                if (string.IsNullOrEmpty(codigoDepartamento))
                                {
                                    entidad.CodDepartamento = "";
                                    entidad.CodMunicipio = "";
                                }
                                else
                                {
                                    entidad.CodDepartamento = codigoDepartamento;
                                    entidad.CodMunicipio = codigoMunicipio;
                                    entidad.NombreDepartamento = Departamento;
                                    entidad.NombreMunicipio = Municipio;
                                }

                                entidad.EstadoId = EstadoId;
                                entidad.Descripción = descripcion;
                                entidad.Nombre = Nombre;
                                entidad.AreaArtisticaId = AreaArtisticaId;
                                entidad.AnoEvento = FechaEvento.Year;
                                entidad.EntidadOrganizadora = EntidadOrganizadora;
                                entidad.FechaEvento = FechaEvento;
                                entidad.LugarEvento = LugarEvento;
                                entidad.FechaModificacion = DateTime.Now;
                                entidad.Tipo = Tipo;
                                entidad.Telefono = telefono;
                                entidad.Email = Email;
                                entidad.Destacado = destacado;
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

        public static void CrearGrupo(int EventoId,
                                     string Nombre,
                                string Enlace,
                                string contacto,
                                string telefono,
                                int Orden,
                                int Cantidad,
                                bool Esgrupo,
                                byte[] imagen,
                                string resena)
        {

            try
            {

                short sgrupo = 0;
                int GrupoId = 0;

                using (var context = new SIPAEntities())
                {
                    if (Esgrupo)
                        sgrupo = 1;

                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var grupo = new ART_MUSICA_GRUPOS
                            {
                                CantidadMiembros = Cantidad,
                                Contacto = contacto,
                                Enlace = Enlace,
                                EsGrupo = sgrupo,
                                Imagen = imagen,
                                Nombre = Nombre,
                                Orden = Orden,
                                Reseña = resena,
                                Telefono = telefono,
                            };
                            context.ART_MUSICA_GRUPOS.Add(grupo);
                            context.SaveChanges();
                            GrupoId = grupo.Id;
                            if (GrupoId > 0)
                            {
                                var grupoevento = new ART_MUSICA_GRUPOEVENTOS
                             {
                                 EventoId = EventoId,
                                 GrupoId = GrupoId,
                             };
                                context.ART_MUSICA_GRUPOEVENTOS.Add(grupoevento);
                                context.SaveChanges();
                            }


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

        public static void EliminarGrupo(int GrupoId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    //Ojo preguntar sobre la eliminación
                    context.ART_MUSICA_GRUPOEVENTOS.Remove(context.ART_MUSICA_GRUPOEVENTOS.Where(x => x.GrupoId == GrupoId).FirstOrDefault());
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Eliminar(int eventoId,
                            int UsuarioId,
                            string NombreUsuario,
                            string strIP)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_ARTISTAS_CELEBRA.RemoveRange(context.ART_MUSICA_ARTISTAS_CELEBRA.Where(x => x.EventoId == eventoId));
                    context.ART_MUSICA_EVENTOS.Remove(context.ART_MUSICA_EVENTOS.Where(x => x.Id == eventoId).SingleOrDefault());

                    context.SaveChanges();


                    //Auditoria
                    string temp;
                    temp = string.Format("El usuario {0} ({1}) eliminó el {2} el evento de celebra la música.\nDatos actuales:\n{3} ", NombreUsuario, UsuarioId, DateTime.Now, "ART_MUSICA_EVENTOS");
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine(temp);
                    ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.Eventos.ToString(), IpUsuario = strIP, RegistroId = Convert.ToInt32(eventoId), UsuarioId = UsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Eliminar Evento" };

                    RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                    auditoria.Crear(registroOperacion);

                }

            }
            catch (Exception)
            { throw; }

        }
        #endregion
    }
}
