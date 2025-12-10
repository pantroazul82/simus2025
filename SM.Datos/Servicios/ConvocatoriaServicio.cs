using SM.Datos.DTO;
using SM.Datos.DTO.Servicios;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SM.Datos.Servicios
{
    public class ConvocatoriaServicio
    {

        public static ART_MUSICA_CONVOCATORIAS ConsultarConvocatoriaPorId(int Id)
        {

            var registro = new ART_MUSICA_CONVOCATORIAS();

            try
            {
                using (var context = new SIPAEntities())
                {

                    registro = context.ART_MUSICA_CONVOCATORIAS.Where(x => x.Id == Id).FirstOrDefault();


                }
                return registro;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Basica> ConsultarParametros(int CategoriaId)
        {
            List<Basica> listPaises;
            try
            {
                using (var context = new SIPAEntities())
                {

                    listPaises = (from P in context.ART_MUSICA_PARAMETROS_SERVICIOS
                                  where P.CategoriaId == CategoriaId
                                  select new Basica
                                  {
                                      Value = P.Id.ToString(),
                                      Nombre = P.Nombre
                                  }).ToList();


                }
                return listPaises;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ObtenerCategoriaId(int intId)
        {
            int intCategoriaId = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    intCategoriaId = context.ART_MUSICA_PARAMETROS_SERVICIOS.Where(x => x.Id == intId).SingleOrDefault().CategoriaId;


                }
                return intCategoriaId;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ObtenerId(string nombre)
        {
            int intCategoriaId = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    intCategoriaId = context.ART_MUSICA_PARAMETROS_SERVICIOS.Where(x => x.Nombre == nombre && x.Categoria == "Tipo Servicio").SingleOrDefault().Id;


                }
                return intCategoriaId;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string ObtenerNombreParametro(int intId)
        {
            string nombre = "";
            try
            {
                using (var context = new SIPAEntities())
                {
                    nombre = context.ART_MUSICA_PARAMETROS_SERVICIOS.Where(x => x.Id == intId).SingleOrDefault().Nombre;

                }
                return nombre;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<ConvocatoriaResultadoDTO> ConsultarConvocatoriasPorEstadoId(int estadoId)
        {

            var listResultado = new List<ConvocatoriaResultadoDTO>();

            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = context.Database.SqlQuery<ConvocatoriaResultadoDTO>(@"EXEC ART_MUSICA_LISTADO_CONVOCATORIAS @EstadoId", new SqlParameter("EstadoId", estadoId)).ToList();

                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ConvocatoriaResultadoDTO> ConsultarConvocatoriasPorUsuarioId(int usuarioId)
        {

            var listResultado = new List<ConvocatoriaResultadoDTO>();

            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<ConvocatoriaResultadoDTO>(@"EXEC ART_MUSICA_LISTADO_CONVOCATORIAS_POR_USUARIOID @UsuarioId", new SqlParameter("UsuarioId", usuarioId)).ToList();

                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

       
        public static string ObtenerIdConvocatoriaDotacion()
        {
            string codigo = "";
            try
            {
                using (var context = new SIPAEntities())
                {

                    codigo = context.ART_MUSICA_VARIABLES.Where(x => x.Codigo == "DOTACION").FirstOrDefault().Valor;

                }
                return codigo;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string ObtenerNombreAgente(int Id)
        {
            string Nombre = "";
            try
            {
                using (var context = new SIPAEntities())
                {

                    var registro = context.ART_MUSICA_AGENTE.Where(x => x.ID == Id).FirstOrDefault();

                    if (registro != null)
                    {
                        Nombre = registro.PrimerNombre + " " + registro.SegundoNombre + " " + registro.PrimerApellido + " " + registro.SedundoApellido;
                    }


                }
                return Nombre;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string ObtenerNombreEntidad(int Id)
        {
            string Nombre = "";
            try
            {
                using (var context = new SIPAEntities())
                {

                    Nombre = context.ART_MUSICA_ENTIDADES.Where(x => x.Id == Id).FirstOrDefault().Nombre;

                }
                return Nombre;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string ObtenerNombreAgrupacion(int Id)
        {
            string Nombre = "";
            try
            {
                using (var context = new SIPAEntities())
                {

                    Nombre = context.ART_MUSICA_AGRUPACION.Where(x => x.Id == Id).FirstOrDefault().Nombre;

                }
                return Nombre;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string ObtenerNombreEscuela(int Id)
        {
            string Nombre = "";
            try
            {
                using (var context = new SIPAEntities())
                {

                    Nombre = context.ART_ENTIDADES_ARTES.Where(x => x.ENT_ID == Id).FirstOrDefault().ENT_NOMBRE;

                }
                return Nombre;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string ObtenerNombreConvocatoria(int Id)
        {
            string Nombre = "";
            try
            {
                using (var context = new SIPAEntities())
                {

                    Nombre = context.ART_MUSICA_CONVOCATORIAS.Where(x => x.Id == Id).FirstOrDefault().Titulo;

                }
                return Nombre;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Parametro ObtenerEscuelaPorEntidadId(int Id)
        {

            string codMunicipio = "";
            var parametro = new Parametro();
            try
            {
                using (var context = new SIPAEntities())
                {
                    codMunicipio = context.ART_MUSICA_ENTIDADES.Where(x => x.Id == Id).FirstOrDefault().CodigoMunicipio;

                    if (!String.IsNullOrEmpty(codMunicipio))
                    {
                        var ENTIDAD = (from E in context.ART_ENTIDADES_ARTES
                                       join U in context.ART_ENTIDAD_UBICACION on E.ENT_ID equals U.ENT_ID
                                       join I in context.ART_MUSICA_ENTIDAD_IDENTIFICACION on E.ENT_ID equals I.ENT_ID
                                       where U.ZON_ID == codMunicipio
                                       where I.ENT_TIPO_ESCUELA == "1"
                                       select E).FirstOrDefault();

                        if (ENTIDAD != null)
                        {
                            parametro.Id = ENTIDAD.ENT_ID;
                            parametro.Nombre = ENTIDAD.ENT_NOMBRE;
                        }
                    }


                }
                return parametro;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string ObtenerMunicipioPorEntidad(int Id)
        {
            string Nombre = "";

            try
            {
                using (var context = new SIPAEntities())
                {

                    var ENTIDAD = (from E in context.ART_MUSICA_ENTIDADES
                                   join U in context.BAS_ZONAS_GEOGRAFICAS on E.CodigoMunicipio equals U.ZON_ID
                                   where E.Id == Id
                                   select U).FirstOrDefault();

                    if (ENTIDAD != null)
                        Nombre = ENTIDAD.ZON_NOMBRE;



                }
                return Nombre;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public static string ObtenerNombreentidad(int Id)
        {
            string Nombre = "";

            try
            {
                using (var context = new SIPAEntities())
                {
                    
                    Nombre = context.ART_MUSICA_ENTIDADES.Where(x => x.Id == Id).FirstOrDefault().Nombre;

                }
                return Nombre;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string ObtenerNombreEstado(int EstadoId)
        {
            string Nombre = "";
            try
            {
                using (var context = new SIPAEntities())
                {

                    Nombre = context.ART_MUSICA_PARAMETROS_SERVICIOS.Where(x => x.Id == EstadoId).FirstOrDefault().Nombre;

                }
                return Nombre;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public static string ObtenerNombreEstadoSIMUS(int EstadoId)
        {
            string Nombre = "";
            try
            {
                using (var context = new SIPAEntities())
                {

                    Nombre = context.ART_MUSICA_ESTADOS.Where(x => x.Id == EstadoId).FirstOrDefault().Nombre;

                }
                return Nombre;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int AgregarConvocatoria(ART_MUSICA_CONVOCATORIAS registro, string[] listactores)
        {
            int ConvocatoriaId = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_CONVOCATORIAS.Add(registro);
                    context.SaveChanges();
                    ConvocatoriaId = registro.Id;
                    ActualizarActoresDirigido(ConvocatoriaId, listactores);

                }

                return ConvocatoriaId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Actualizar(int ConvocatoriaId,
                                      string titulo,
                                      string descripcion,
                                      DateTime FechaInicio,
                                      DateTime FechaFin,
                                      int EstadoId,
                                      int TipoId,
                                      int ActorId,
                                      string[] listactores)
        {
            try
            {
                string NombreActor = "";
                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_CONVOCATORIAS.Where(x => x.Id == ConvocatoriaId).FirstOrDefault();

                    if (entidad != null)
                    {
                        entidad.Titulo = titulo;
                        entidad.Descripcion = descripcion;
                        entidad.EstadoId = EstadoId;
                        entidad.TipoActorId = TipoId;
                        entidad.NombreActor = NombreActor;
                        entidad.FechaInicio = FechaInicio;
                        entidad.FechaFin = FechaFin;
                        if (TipoId == 6)
                        {
                            entidad.AgenteId = ActorId;
                            entidad.EntidadId = null;
                            entidad.AgrupacionId = null;
                            entidad.EscuelaId = null;
                            NombreActor = ConvocatoriaServicio.ObtenerNombreAgente(ActorId);
                        }
                        else if (TipoId == 7)
                        {
                            entidad.AgenteId = null;
                            entidad.EntidadId = ActorId;
                            entidad.AgrupacionId = null;
                            entidad.EscuelaId = null;
                            NombreActor = ConvocatoriaServicio.ObtenerNombreEntidad(ActorId);
                        }
                        else if (TipoId == 8)
                        {
                            entidad.AgenteId = null;
                            entidad.EntidadId = null;
                            entidad.AgrupacionId = ActorId;
                            entidad.EscuelaId = null;
                            NombreActor = ConvocatoriaServicio.ObtenerNombreAgrupacion(ActorId);
                        }
                        else if (TipoId == 9)
                        {
                            entidad.AgenteId = null;
                            entidad.EntidadId = null;
                            entidad.AgrupacionId = null;
                            entidad.EscuelaId = ActorId;
                            NombreActor = ConvocatoriaServicio.ObtenerNombreEscuela(ActorId);
                        }

                        entidad.NombreActor = NombreActor;
                    }
                    context.SaveChanges();
                    EliminatActores(ConvocatoriaId);
                    ActualizarActoresDirigido(ConvocatoriaId, listactores);
                }
            }
            catch (Exception)
            { throw; }
        }

        public static void ActualizarActoresDirigido(int convocatoriaId, string[] listDirigidoActores)
        {
            try
            {
                using (var context = new SIPAEntities())
                {

                    foreach (string item in listDirigidoActores)
                    {
                        ART_MUSICA_CONVOCATORIA_ACTORES actores = new ART_MUSICA_CONVOCATORIA_ACTORES() { ConvocatoriaId = convocatoriaId, ActorId = Convert.ToInt32(item) };
                        context.ART_MUSICA_CONVOCATORIA_ACTORES.Add(actores);
                    }
                    context.SaveChanges();
                }

            }
            catch (Exception)
            { throw; }
        }

        public static void EliminatActores(int ConvocatoriaId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {

                    context.ART_MUSICA_CONVOCATORIA_ACTORES.RemoveRange(context.ART_MUSICA_CONVOCATORIA_ACTORES.Where(x => x.ConvocatoriaId == ConvocatoriaId));
                    context.SaveChanges();


                }

            }
            catch (Exception)
            { throw; }
        }

        public static void EliminatParticipacionAgente(int ConvocatoriaId, int agenteId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {

                    context.ART_MUSICA_PARTICIPACION.RemoveRange(context.ART_MUSICA_PARTICIPACION.Where(x => x.ConvocatoriaId == ConvocatoriaId && x.AgenteId == agenteId));
                    context.SaveChanges();


                }

            }
            catch (Exception)
            { throw; }
        }

        public static void EliminatParticipacionAgrupacion(int ConvocatoriaId, int actorId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {

                    context.ART_MUSICA_PARTICIPACION.RemoveRange(context.ART_MUSICA_PARTICIPACION.Where(x => x.ConvocatoriaId == ConvocatoriaId && x.AgrupacionId == actorId));
                    context.SaveChanges();


                }

            }
            catch (Exception)
            { throw; }
        }

        public static void EliminatParticipacionEntidad(int ConvocatoriaId, int actorId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {

                    context.ART_MUSICA_PARTICIPACION.RemoveRange(context.ART_MUSICA_PARTICIPACION.Where(x => x.ConvocatoriaId == ConvocatoriaId && x.EntidadId == actorId));
                    context.SaveChanges();


                }

            }
            catch (Exception)
            { throw; }
        }

        public static void EliminatParticipacionEscuelas(int ConvocatoriaId, int actorId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {

                    context.ART_MUSICA_PARTICIPACION.RemoveRange(context.ART_MUSICA_PARTICIPACION.Where(x => x.ConvocatoriaId == ConvocatoriaId && x.EscuelaId == actorId));
                    context.SaveChanges();


                }

            }
            catch (Exception)
            { throw; }
        }

        public static void ActualizarDocumento(int ConvocatoriaId,
                                               int documentoId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_CONVOCATORIAS.Where(x => x.Id == ConvocatoriaId).FirstOrDefault();

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

        public static List<Parametro> ConsultarDirigidoA(int Id)
        {
            List<Parametro> listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    listBasica = (from I in context.ART_MUSICA_CONVOCATORIA_ACTORES
                                  join a in context.ART_MUSICA_PARAMETROS_SERVICIOS on I.ActorId equals a.Id
                                  where I.ConvocatoriaId == Id
                                  select new Parametro
                                  {
                                      Id = I.ActorId,
                                      Nombre = a.Nombre
                                  }).ToList();

                }
                return listBasica;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Parametro> ConsultarEntidadesHabilitadasDotacion()
        {
            List<Parametro> listBasica = new List<Parametro>();
            var listdatos = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listBasica = (from d in context.ART_MUSICA_ENTIDAD_DOTACION
                                  join e in context.ART_MUSICA_ENTIDADES on d.EntidadId equals e.Id
                                  where d.EsActivo == true
                                  select new Parametro
                                  {
                                      Id = e.Id,
                                      Nombre = e.Nombre
                                  }).ToList();

                    var VarParametros = listBasica
                 .Where(t1 => !context.ART_MUSICA_DOTACION
.Any(t2 => t2.EntidadId == t1.Id)
 );


                    foreach (var item in VarParametros)
                    {
                        var objParametro = new Parametro();
                        objParametro.Id = item.Id;
                        objParametro.Nombre = item.Nombre;
                        listdatos.Add(objParametro);
                    }
                }
                return listdatos;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Parametro> ConsultarEntidadesHabilitadasDotacionPorUsuarioId(int UsuarioId)
        {
            List<Parametro> listBasica = new List<Parametro>();
            var listdatos = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listBasica = (from d in context.ART_MUSICA_ENTIDAD_DOTACION
                                  join e in context.ART_MUSICA_ENTIDADES on d.EntidadId equals e.Id
                                  join u in context.ART_MUSICA_USUARIO on e.CodigoMunicipio equals u.CodMunicipio
                                  where d.EsActivo == true
                                  where u.Id == UsuarioId
                                  select new Parametro
                                  {
                                      Id = e.Id,
                                      Nombre = e.Nombre
                                  }).ToList();


                    var VarParametros = listBasica
                 .Where(t1 => !context.ART_MUSICA_DOTACION
.Any(t2 => t2.EntidadId == t1.Id)
 );


                    foreach (var item in VarParametros)
                    {
                        var objParametro = new Parametro();
                        objParametro.Id = item.Id;
                        objParametro.Nombre = item.Nombre;
                        listdatos.Add(objParametro);
                    }

                }
                return listdatos;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public static List<Parametro> ConsultarEntidadesRegistradas(int ConvocatoriaId)
        {

            var listdatos = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listdatos = (from d in context.ART_MUSICA_DOTACION
                                 join e in context.ART_MUSICA_ENTIDADES on d.EntidadId equals e.Id
                                 where d.ConvocatoriaId == ConvocatoriaId
                                 select new Parametro
                                 {
                                     Id = d.Id,
                                     Nombre = e.Nombre
                                 }).ToList();



                }
                return listdatos;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Parametro> ConsultarEntidadesRegistradasPorUsuario(int ConvocatoriaId, int UsuarioId)
        {

            var listdatos = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listdatos = (from d in context.ART_MUSICA_DOTACION
                                 join e in context.ART_MUSICA_ENTIDADES on d.EntidadId equals e.Id
                                 where d.ConvocatoriaId == ConvocatoriaId
                                 where d.UsuarioId == UsuarioId
                                 select new Parametro
                                 {
                                     Id = d.Id,
                                     Nombre = e.Nombre
                                 }).ToList();



                }
                return listdatos;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
