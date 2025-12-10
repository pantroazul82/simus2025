using SM.Datos.AuditoriaData;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SM.Datos.Basicas;
using SM.Datos.DTO;
using System.Data.SqlClient;
using SM.Datos.DTO.Servicios;
using SM.Datos.DTO.Geo;

namespace SM.Datos.Servicios
{
    public class UtilidadServicio
    {

        #region Actualizacion
        public static int Agregar(ART_MUSICA_MODULO_SERVICIOS registro, string NombreUsuario, int ArtMusicaUsuarioId, string strIP)
        {
            int ServicioId = 0;
            try
            {


                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_MODULO_SERVICIOS.Add(registro);
                    context.SaveChanges();
                    ServicioId = registro.Id;



                    string temp;
                    temp = string.Format("El usuario {0} ({1}) creó el {2} la  utilidad.\nDatos actuales:\n{3}. Actor nombre: :\n{4} ", NombreUsuario, ArtMusicaUsuarioId, DateTime.Now, registro, registro.NombreActor);
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine(temp);
                    ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.Servicios.ToString(), IpUsuario = strIP, RegistroId = ServicioId, UsuarioId = ArtMusicaUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Creación" };

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


        public static void ActualizarCoordenadas(int utilidadId, string latitud, string longitud)
        {
            try
            {

                double dbLongitud = Convert.ToDouble(longitud);
                double dblatitud = Convert.ToDouble(latitud);

                if (latitud.Contains(","))
                    latitud = latitud.Replace(",", ".");

                if (longitud.Contains(","))
                    longitud = longitud.Replace(",", ".");
                var Location = System.Data.Entity.Spatial.DbGeography.FromText(string.Format("POINT({0} {1})", latitud, longitud));

                            
                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_MODULO_SERVICIOS.Where(x => x.Id == utilidadId).FirstOrDefault();
                    if (entidad != null)
                    {
                        entidad.Coordenadas = Location;
                        context.SaveChanges();
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Actualizar(int UtilidadId,
                                    string titulo,
                                    string descripcion,
                                    DateTime FechaInicio,
                                    DateTime FechaFin,
                                    int EstadoId,
                                    int TipoId,
                                    int ActorId,
                                    int TipoUtilidadId,
                                   int TipoEventoId,
                                    int codPais,
                                    string codDepto,
                                    string codMunicipio,
                                    string OtraCiudad,
                                    string direccion,
                                    string telefono,
                                    string correoelectronico,
                                    bool EsActivo,
                                    byte[] imagen,
                                     int UsuarioAprobadorId,
                                     string NombreUsuario,
                                    string strIP)
        {
            try
            {
                string NombreActor = "";
                string departamento = "";
                string Municipio = "";
                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_MODULO_SERVICIOS.Where(x => x.Id == UtilidadId).FirstOrDefault();
                    if (codDepto.Length == 2)
                        departamento = ServicioBasicas.obtenerNombreDepartamento(codDepto);
                    else
                        codDepto = "";


                    if (codMunicipio.Length == 5)
                        Municipio = ServicioBasicas.obtenerNombreMunicipio(codMunicipio);
                    else
                    {
                        codMunicipio = "";
                        OtraCiudad = "";
                    }

                    if (entidad != null)
                    {
                        entidad.Titulo = titulo;
                        entidad.Descripcion = descripcion;
                        entidad.EstadoId = EstadoId;
                        entidad.TipoActorId = TipoId;
                        entidad.NombreActor = NombreActor;
                        entidad.FechaInicio = FechaInicio;
                        entidad.FechaFin = FechaFin;
                        entidad.TipoServicioId = TipoUtilidadId;
                        entidad.TipoEventoId = TipoEventoId;
                        entidad.CodPais = codPais;
                        entidad.CodDepto = codDepto;
                        entidad.CodMunicipio = codMunicipio;
                        entidad.Departamento = departamento;
                        entidad.Municipio = Municipio;
                        entidad.Telefono = telefono;
                        entidad.Email = correoelectronico;
                        entidad.Direccion = direccion;
                        entidad.OtraCiudad = OtraCiudad;
                        entidad.EsActivo = EsActivo;
                        entidad.UsuarioAprobadorId = UsuarioAprobadorId;
                        entidad.FechaActualizacion = DateTime.Today;
                        if (imagen != null)
                            entidad.Imagen = imagen;
                        if (TipoId == 6)
                        {
                            entidad.AgenteId = ActorId;
                            entidad.EntidadId = null;
                            entidad.AgrupacionId = null;
                            entidad.EscuelaId = null;
                            entidad.TipoActor = "Agentes";
                            NombreActor = ConvocatoriaServicio.ObtenerNombreAgente(ActorId);
                        }
                        else if (TipoId == 7)
                        {
                            entidad.AgenteId = null;
                            entidad.EntidadId = ActorId;
                            entidad.AgrupacionId = null;
                            entidad.EscuelaId = null;
                            entidad.TipoActor = "Entidad";
                            NombreActor = ConvocatoriaServicio.ObtenerNombreEntidad(ActorId);
                        }
                        else if (TipoId == 8)
                        {
                            entidad.AgenteId = null;
                            entidad.EntidadId = null;
                            entidad.AgrupacionId = ActorId;
                            entidad.EscuelaId = null;
                            entidad.TipoActor = "Agrupación";
                            NombreActor = ConvocatoriaServicio.ObtenerNombreAgrupacion(ActorId);
                        }
                        else if (TipoId == 9)
                        {
                            entidad.AgenteId = null;
                            entidad.EntidadId = null;
                            entidad.AgrupacionId = null;
                            entidad.EscuelaId = ActorId;
                            entidad.TipoActor = "Escuelas";
                            NombreActor = ConvocatoriaServicio.ObtenerNombreEscuela(ActorId);
                        }

                        entidad.NombreActor = NombreActor;
                    }
                    context.SaveChanges();

                    //auditoria

                    string temp;
                    temp = string.Format("El usuario {0} ({1}) creó el {2} la  utilidad.\nDatos actuales:\n{3}. Actor responsable: \n{4} ", NombreUsuario, UsuarioAprobadorId, DateTime.Now, "ART_MUSICA_MODULO_SERVICIOS", NombreActor);
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine(temp);
                    ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.Servicios.ToString(), IpUsuario = strIP, RegistroId = UtilidadId, UsuarioId = UsuarioAprobadorId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Actualización" };

                    var auditoria = new RegistroOperacionServicio();
                    auditoria.Crear(registroOperacion);

                }
            }
            catch (Exception)
            { throw; }
        }
        public static void ActualizarDocumentoutilidad(int utilidadId,
                                                int documentoId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_MODULO_SERVICIOS.Where(x => x.Id == utilidadId).FirstOrDefault();

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

        public static void EliminarGenero(int UtilidadGeneroId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_UTILIDAD_GENEROS.Remove(context.ART_MUSICA_UTILIDAD_GENEROS.Where(x => x.Id == UtilidadGeneroId).FirstOrDefault());
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void EliminarServicio(int UtilidadServicioId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_UTILIDAD_SERVICIO.Remove(context.ART_MUSICA_UTILIDAD_SERVICIO.Where(x => x.Id == UtilidadServicioId).FirstOrDefault());
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void AgregarGeneros(ART_MUSICA_UTILIDAD_GENEROS registro)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_UTILIDAD_GENEROS.Add(registro);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void AgregarServicio(ART_MUSICA_UTILIDAD_SERVICIO registro)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_UTILIDAD_SERVICIO.Add(registro);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region consultas
        public static List<Parametro> ConsultarGenerosPorUtilidadId(int utilidadid)
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    var VarParametros = context.ART_MUSICA_UTILIDAD_GENEROS.Where(x => x.UtilidadId == utilidadid).ToList();

                    foreach (var item in VarParametros)
                    {
                        var objParametro = new Parametro();
                        objParametro.Id = item.Id;
                        objParametro.Nombre = item.Atributo;
                        listBasica.Add(objParametro);
                    }

                }
                return listBasica;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Parametro> ConsultarServicioPorUtilidadId(int utilidadid)
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    var VarParametros = context.ART_MUSICA_UTILIDAD_SERVICIO.Where(x => x.UtilidadId == utilidadid).ToList();

                    foreach (var item in VarParametros)
                    {
                        var objParametro = new Parametro();
                        objParametro.Id = item.Id;
                        objParametro.Nombre = item.Atributo;
                        listBasica.Add(objParametro);
                    }

                }
                return listBasica;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ART_MUSICA_MODULO_SERVICIOS ConsultarPorId(int Id)
        {

            var registro = new ART_MUSICA_MODULO_SERVICIOS();

            try
            {
                using (var context = new SIPAEntities())
                {

                    registro = context.ART_MUSICA_MODULO_SERVICIOS.Where(x => x.Id == Id).FirstOrDefault();


                }
                return registro;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<NoticiasDTO> ConsultarNoticiasRecientes(int TipoUtilidadId)
        {
            var listBasica = new List<NoticiasDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listBasica = (from e in context.ART_MUSICA_MODULO_SERVICIOS
                                  where e.TipoServicioId == TipoUtilidadId
                                  where e.EstadoId == 2
                                  where e.EsActivo == true
                                  orderby e.Id descending
                                  select new NoticiasDTO
                                  {
                                      UtilidadId = e.Id,
                                      Descripcion = e.Descripcion,
                                      FechaInicio = e.FechaInicio ?? DateTime.Today,
                                      FechaFinal = e.FechaFin ?? DateTime.Today,
                                      Titulo = e.Titulo,
                                      Imagen = e.Imagen
                                  }).Take(3).ToList();


                }
                return listBasica;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<NoticiasDTO> ConsultarEventosdelMes(int TipoUtilidadId, DateTime datFechaInicio, DateTime datFechaFinal)
        {
            var listBasica = new List<NoticiasDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listBasica = (from e in context.ART_MUSICA_MODULO_SERVICIOS
                                  where e.TipoServicioId == TipoUtilidadId
                                  where e.EstadoId == 2
                                  where e.EsActivo == true
                                  where e.FechaInicio >= datFechaInicio
                                  where e.FechaInicio <= datFechaFinal
                                  orderby e.FechaInicio descending
                                  select new NoticiasDTO
                                  {
                                      UtilidadId = e.Id,
                                      Descripcion = e.Departamento + " - " + e.Municipio,
                                      FechaInicio = e.FechaInicio ?? DateTime.Today,
                                      FechaFinal = e.FechaFin ?? DateTime.Today,
                                      Titulo = e.Titulo,
                                      Imagen = e.Imagen
                                  }).Take(4).ToList();


                }
                return listBasica;

            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion
        #region ProcedimientosAlmacenados
        public static UtilidadDetalleDTO ConsultarDetallePorId(int Id)
        {
            var listResultado = new UtilidadDetalleDTO();
            try
            {
                using (var context = new SIPAEntities())
                {
                    listResultado = context.Database.SqlQuery<UtilidadDetalleDTO>(@"EXEC ART_MUSICA_UTILIDAD_DETALLE @Id", new SqlParameter("Id", Id)).SingleOrDefault();

                }
                return listResultado;

            }
            catch (Exception)
            {  throw;  }
        }

        public static List<UtilidadHomeDTO> ConsultarDatosDocumentos(int utilidadId)
        {
            var listResultado = new List<UtilidadHomeDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    listResultado = context.Database.SqlQuery<UtilidadHomeDTO>(@"EXEC ART_MUSICA_UTILIDAD_HOME_DOCUMENTOS @TipoUtilidadId", new SqlParameter("TipoUtilidadId", utilidadId)).ToList();

                }
                return listResultado;

            }
            catch (Exception)
            { throw; }
        }
        public static List<UtilidadHomeDTO> ConsultarDatosPorTipoUtilidad(int utilidadId)
        {
            var listResultado = new List<UtilidadHomeDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    listResultado = context.Database.SqlQuery<UtilidadHomeDTO>(@"EXEC ART_MUSICA_UTILIDAD_HOME_PUBLICO @TipoUtilidadId", new SqlParameter("TipoUtilidadId", utilidadId)).ToList();

                }
                return listResultado;

            }
            catch (Exception)
            { throw; }
        }
        public static List<UtilidadResultadoDTO> ConsultarPorUsuarioId(int UsuarioId)
        {
            var listResultado = new List<UtilidadResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    listResultado = context.Database.SqlQuery<UtilidadResultadoDTO>(@"EXEC ART_MUSICA_UTILIDAD_POR_USUARIOID @UsuarioId", new SqlParameter("UsuarioId", UsuarioId)).ToList();

                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<UtilidadResultadoDTO> ConsultarPorEstadoId(int EstadoId)
        {

            var listResultado = new List<UtilidadResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<UtilidadResultadoDTO>(@"EXEC ART_MUSICA_UTILIDAD_POR_ESTADO @EstadoId", new SqlParameter("EstadoId", EstadoId)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<UtilidadResultadoDTO> ConsultarPorMunicipio(int UsuarioId)
        {

            var listResultado = new List<UtilidadResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    listResultado = context.Database.SqlQuery<UtilidadResultadoDTO>(@"EXEC ART_MUSICA_UTILIDAD_POR_MUNICIPIO @UsuarioId", new SqlParameter("UsuarioId", UsuarioId)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<UtilidadResultadoDTO> ConsultarTodos()
        {

            var listResultado = new List<UtilidadResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    listResultado = context.Database.SqlQuery<UtilidadResultadoDTO>(@"EXEC ART_MUSICA_UTILIDAD_TODOS").ToList();
                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<EventoGeoResultadoDTO> ConsultarEventosGeo(int TipoUtilidadId)
        {
            var listResultado = new List<EventoGeoResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    listResultado = context.Database.SqlQuery<EventoGeoResultadoDTO>(@"EXEC ART_MUSICA_EVENTOS_GEO @TipoUtilidadId", new SqlParameter("TipoUtilidadId", TipoUtilidadId)).ToList();

                }
                return listResultado;

            }
            catch (Exception)
            { throw; }
        }

        public static List<EventoGeoResultadoDTO> ConsultarEventosAgenda()
        {
            var listResultado = new List<EventoGeoResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    listResultado = context.Database.SqlQuery<EventoGeoResultadoDTO>(@"EXEC ART_MUSICA_EVENTOS_MUSICALES").ToList();

                }
                return listResultado;

            }
            catch (Exception)
            { throw; }
        }

        public static List<EventoGeoResultadoDTO> ConsultarEventosGeoPorMunicipio(int TipoUtilidadId, string CodMunicipio)
        {
            var listResultado = new List<EventoGeoResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    listResultado = context.Database.SqlQuery<EventoGeoResultadoDTO>(@"EXEC ART_MUSICA_EVENTOS_GEO_POR_MUNICIPIO @TipoUtilidadId", new SqlParameter("TipoUtilidadId", TipoUtilidadId), new SqlParameter("CodMunicipio", CodMunicipio)).ToList();

                }
                return listResultado;

            }
            catch (Exception)
            { throw; }
        }

        ///TODO
        ///PROCEDIMIENTOS ALMACENADOS DE CAJA DE HERRAMIENTAS
        ///

        public static List<HerramientaResultadoDTO> ConsultarHerramientaPorTipoID(int TipoId)
        {
            var listResultado = new List<HerramientaResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    listResultado = context.Database.SqlQuery<HerramientaResultadoDTO>(@"EXEC ART_MUSICA_HOME_HERRAMIENTAS_TIPO @TipoId", new SqlParameter("TipoId", TipoId)).ToList();

                }
                return listResultado;

            }
            catch (Exception)
            { throw; }
        }

        public static List<HerramientaResultadoDTO> ConsultarHerramienta()
        {
            var listResultado = new List<HerramientaResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    listResultado = context.Database.SqlQuery<HerramientaResultadoDTO>(@"EXEC ART_MUSICA_HOME_HERRAMIENTAS").ToList();

                }
                return listResultado;

            }
            catch (Exception)
            { throw; }
        }

        public static HerramientaResultadoDetalleDTO ConsultarHerramientaDetalle(int Id)
        {
            var listResultado = new HerramientaResultadoDetalleDTO();
            try
            {
                using (var context = new SIPAEntities())
                {
                    listResultado = context.Database.SqlQuery<HerramientaResultadoDetalleDTO>(@"EXEC ART_MUSICA_HOME_HERRAMIENTAS_DETALLE @Id", new SqlParameter("Id", Id)).SingleOrDefault();

                }
                return listResultado;

            }
            catch (Exception)
            { throw; }
        }

        #endregion
    }
}
