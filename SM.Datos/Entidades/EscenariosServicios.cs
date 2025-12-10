using SM.Datos.Basicas;
using SM.Datos.DTO;
using SM.Datos.Servicios;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.LibreriaComun.DTO.Circulacion;

namespace SM.Datos.Entidades
{
    public class EscenariosServicios
    {

        #region Actualización
        public static int Agregar(ART_MUSICA_ESCENARIOS registro, string[] listado)
        {
            int registroId = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_ESCENARIOS.Add(registro);
                    context.SaveChanges();
                    registroId = registro.Id;
                    ActualizarDiasSemana(registroId, listado);

                }

                return registroId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int AgregarImagenes(ART_MUSICA_IMAGENES registro)
        {
            int registroId = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_IMAGENES.Add(registro);
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

        public static void ActualizarDocumento(int EscenarioId,
                                              int documentoId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_ESCENARIOS.Where(x => x.Id == EscenarioId).FirstOrDefault();

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

        public static void ActualizarDiasSemana(int EscenarioId, string[] listado)
        {
            try
            {
                using (var context = new SIPAEntities())
                {

                    foreach (string item in listado)
                    {
                        ART_MUSICA_ESCENARIO_DIAS actores = new ART_MUSICA_ESCENARIO_DIAS() { EscenarioId = EscenarioId, DiaId = Convert.ToInt32(item) };
                        context.ART_MUSICA_ESCENARIO_DIAS.Add(actores);
                    }
                    context.SaveChanges();
                }

            }
            catch (Exception)
            { throw; }
        }

        public static void EliminarDias(int EscenarioId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {

                    context.ART_MUSICA_ESCENARIO_DIAS.RemoveRange(context.ART_MUSICA_ESCENARIO_DIAS.Where(x => x.EscenarioId == EscenarioId));
                    context.SaveChanges();


                }

            }
            catch (Exception)
            { throw; }
        }
        public static void Actualizar(int registroId, EscenarioDTO datos, int UsuarioId, string[] listado)
        {
            try
            {
                string NombreActor = "";
                string[] hora = datos.HoraApertura.Split(' ');
                string dateString = "01/01/2018" + " " + hora[0] + ":01 " + hora[1];
                DateTime dt = Convert.ToDateTime(dateString);

                string[] horacierre = datos.HoraCierre.Split(' ');
                string dateStringCierre = "01/01/2018" + " " + horacierre[0] + ":01 " + horacierre[1];
                DateTime dtCierre = Convert.ToDateTime(dateStringCierre);

                TimeSpan timeInicio = dt.TimeOfDay;
                TimeSpan timeCierre = dtCierre.TimeOfDay;

                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_ESCENARIOS.Where(x => x.Id == registroId).FirstOrDefault();

                    if (entidad != null)
                    {
                        entidad.Nombre = datos.Nombre;
                        entidad.Descripcion = datos.Descripcion;
                        entidad.EstadoId = Convert.ToInt32(datos.EstadoId);
                        entidad.Aforo = Convert.ToInt32(datos.aforo);
                        entidad.ClasificacionId = Convert.ToInt32(datos.ClasificacionId);
                        entidad.CodDepto = datos.CodDepartamento;
                        entidad.CodMunicipio = datos.codMunicipio;
                        entidad.Contacto = datos.Contacto;
                        entidad.CorreoElectronico = datos.CorreoElectronico;
                        entidad.Departamento = ServicioBasicas.obtenerNombreDepartamento(datos.CodDepartamento);
                        entidad.Municipio = ServicioBasicas.obtenerNombreMunicipio(datos.codMunicipio);
                        entidad.Direccion = datos.direccion;
                        entidad.EsActivo = datos.EsActivo;
                        entidad.PaginaWeb = datos.PaginaWeb;
                        entidad.Telefono = datos.Telefono;
                        entidad.FechaActualizacion = DateTime.Now;
                        entidad.TipoActor = Convert.ToInt32(datos.Tipo);
                        entidad.HoraInicio = timeInicio;
                        entidad.HoraFinal = timeCierre;
                        entidad.UsuarioActualizaId = UsuarioId; 
                        if (Convert.ToInt32(datos.Tipo) == 6)
                        {
                            entidad.AgenteId = Convert.ToInt32(datos.ActorId);
                            entidad.EntidadId = null;
                            entidad.AgrupacionId = null;
                            entidad.EscuelaId = null;
                            NombreActor = ConvocatoriaServicio.ObtenerNombreAgente(Convert.ToInt32(datos.ActorId));
                            entidad.RelacionadoA = "Agentes";
                        }
                        else if (Convert.ToInt32(datos.Tipo) == 7)
                        {
                            entidad.AgenteId = null;
                            entidad.EntidadId = Convert.ToInt32(datos.ActorId);
                            entidad.AgrupacionId = null;
                            entidad.EscuelaId = null;
                            NombreActor = ConvocatoriaServicio.ObtenerNombreEntidad(Convert.ToInt32(datos.ActorId));
                            entidad.RelacionadoA = "Entidad";
                        }

                        else if (Convert.ToInt32(datos.Tipo) == 8)
                        {
                            entidad.AgenteId = null;
                            entidad.EntidadId = null;
                            entidad.AgrupacionId = Convert.ToInt32(datos.ActorId);
                            entidad.EscuelaId = null;
                            NombreActor = ConvocatoriaServicio.ObtenerNombreAgrupacion(Convert.ToInt32(datos.ActorId));
                            entidad.RelacionadoA = "Agrupación";

                        }
                        else if (Convert.ToInt32(datos.Tipo) == 9)
                        {
                            entidad.AgenteId = null;
                            entidad.EntidadId = null;
                            entidad.AgrupacionId = null;
                            entidad.EscuelaId = Convert.ToInt32(datos.ActorId); ;
                            NombreActor = ConvocatoriaServicio.ObtenerNombreEscuela(Convert.ToInt32(datos.ActorId));
                            entidad.RelacionadoA = "Escuelas";

                        }

                        entidad.NombreActor = NombreActor;
                    }
                    context.SaveChanges();
                    EliminarDias(registroId);
                    ActualizarDiasSemana(registroId, listado);

                }
            }
            catch (Exception)
            { throw; }
        }

        public static void EliminarImagen(int imagenid)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var entidad = context.ART_MUSICA_IMAGENES.Where(x => x.Id == imagenid).FirstOrDefault();

                            if (entidad != null)
                            {

                                context.ART_MUSICA_IMAGENES.Remove(entidad);
                                context.SaveChanges();

                           


                                dbContextTransaction.Commit();
                            }

                        }

                        catch
                        { dbContextTransaction.Rollback(); }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region consulta

        public static List<ImagenDataDTO> ConsultarImagenes(int EscenarioId)
        {
            var listDocumentos = new List<ImagenDataDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listDocumentos = (from e in context.ART_MUSICA_IMAGENES
                                      where e.EscenarioId == EscenarioId
                                      select new ImagenDataDTO
                                      {
                                          EscenarioId= e.EscenarioId ?? 0,
                                          EsPrincipal = e.Principal,
                                          imagen = e.Imagen,
                                          ImagenId = e.Id
                                      }).ToList();
                }

                return listDocumentos;
            }
            catch (Exception)
            { throw; }
        }

        public static List<ImagenDataDTO> ConsultarImagenesEventosperiodicos(int EventoId)
        {
            var listDocumentos = new List<ImagenDataDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listDocumentos = (from e in context.ART_MUSICA_IMAGENES
                                      where e.EventoPeriodicoId == EventoId
                                      select new ImagenDataDTO
                                      {
                                          EscenarioId = e.EscenarioId ?? 0,
                                          EsPrincipal = e.Principal,
                                          imagen = e.Imagen,
                                          ImagenId = e.Id
                                      }).ToList();
                }

                return listDocumentos;
            }
            catch (Exception)
            { throw; }
        }

        public static ART_MUSICA_ESCENARIOS ConsultarPorId(int Id)
        {

            var registro = new ART_MUSICA_ESCENARIOS();

            try
            {
                using (var context = new SIPAEntities())
                {

                    registro = context.ART_MUSICA_ESCENARIOS.Where(x => x.Id == Id).FirstOrDefault();


                }
                return registro;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Parametro> ConsultarDiasSemana(int Id)
        {
            List<Parametro> listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    listBasica = (from I in context.ART_MUSICA_ESCENARIO_DIAS
                                  join a in context.ART_MUSICA_PARAMETROS_SERVICIOS on I.DiaId equals a.Id
                                  where I.EscenarioId == Id
                                  select new Parametro
                                  {
                                      Id = I.DiaId,
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
        public static List<EspacioDataDTO> ConsultarEspaciosPorUsuarioId(int UsuarioId)
        {

            List<EspacioDataDTO> listResultado = new List<EspacioDataDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<EspacioDataDTO>(@"EXEC ART_MUSICA_ESPACIOS_UsuarioId @UsuarioId", new SqlParameter("UsuarioId", UsuarioId)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<EspacioDataDTO> ConsultarEspaciosPorEstadoId(int EstadoId)
        {

            List<EspacioDataDTO> listResultado = new List<EspacioDataDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<EspacioDataDTO>(@"EXEC ART_MUSICA_ESPACIOS_EstadoId @EstadoId", new SqlParameter("EstadoId", EstadoId)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<EspacioDataDTO> ConsultarEspaciosPorMunicipio(int UsuarioId)
        {

            List<EspacioDataDTO> listResultado = new List<EspacioDataDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<EspacioDataDTO>(@"EXEC ART_MUSICA_ESPACIOS_POR_COORDINADOR @UsuarioId", new SqlParameter("UsuarioId", UsuarioId)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<EspacioDataDTO> ConsultarEspaciosTodos()
        {

            List<EspacioDataDTO> listResultado = new List<EspacioDataDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<EspacioDataDTO>(@"EXEC ART_MUSICA_ESPACIOS_TODOS").ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<HomeEstandarResultado> ConsultarEscenariosEscenicosPublicados()
        {

            List<HomeEstandarResultado> listResultado = new List<HomeEstandarResultado>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = (from a in context.ART_MUSICA_ESCENARIOS
                                     join c in context.ART_MUSICA_PARAMETROS_SERVICIOS on a.ClasificacionId equals c.Id
                                     where a.EstadoId == 2
                                     where a.EsActivo == true

                                     select new HomeEstandarResultado
                                     {
                                         Id = a.Id,
                                         Clasificacion = c.Nombre,
                                         ClasificacionId = a.ClasificacionId,
                                         CodDepto = a.CodDepto,
                                         CodMunicipio = a.CodMunicipio,
                                         Departamento = a.Departamento,
                                         Municipio = a.Municipio,
                                         Nombre = a.Nombre

                                     }).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<HomeEstandarResultado> ConsultarEscenariosEscenicosPublicadosPorDepartamento(string codDepto)
        {

            List<HomeEstandarResultado> listResultado = new List<HomeEstandarResultado>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = (from a in context.ART_MUSICA_ESCENARIOS
                                     join c in context.ART_MUSICA_PARAMETROS_SERVICIOS on a.ClasificacionId equals c.Id
                                     where a.EstadoId == 2
                                     where a.EsActivo == true
                                     where a.CodDepto == codDepto
                                     select new HomeEstandarResultado
                                     {
                                         Id = a.Id,
                                         Clasificacion = c.Nombre,
                                         ClasificacionId = a.ClasificacionId,
                                         CodDepto = a.CodDepto,
                                         CodMunicipio = a.CodMunicipio,
                                         Departamento = a.Departamento,
                                         Municipio = a.Municipio,
                                         Nombre = a.Nombre

                                     }).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<HomeEstandarResultado> ConsultarEscenariosEscenicosPublicadosPorMunicipio(string codMunicipio)
        {

            List<HomeEstandarResultado> listResultado = new List<HomeEstandarResultado>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = (from a in context.ART_MUSICA_ESCENARIOS
                                     join c in context.ART_MUSICA_PARAMETROS_SERVICIOS on a.ClasificacionId equals c.Id
                                     where a.EstadoId == 2
                                     where a.EsActivo == true
                                     where a.CodMunicipio == codMunicipio
                                     select new HomeEstandarResultado
                                     {
                                         Id = a.Id,
                                         Clasificacion = c.Nombre,
                                         ClasificacionId = a.ClasificacionId,
                                         CodDepto = a.CodDepto,
                                         CodMunicipio = a.CodMunicipio,
                                         Departamento = a.Departamento,
                                         Municipio = a.Municipio,
                                         Nombre = a.Nombre

                                     }).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public static List<HomeEstandarResultado> ConsultarEscenariosEscenicosPublicadosPorClasificacionId(int ClasificacionId)
        {

            List<HomeEstandarResultado> listResultado = new List<HomeEstandarResultado>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = (from a in context.ART_MUSICA_ESCENARIOS
                                     join c in context.ART_MUSICA_PARAMETROS_SERVICIOS on a.ClasificacionId equals c.Id
                                     where a.EstadoId == 2
                                     where a.EsActivo == true
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
                                         Nombre = a.Nombre

                                     }).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static ART_MUSICA_ESCENARIOS ConsultarEscenariosPorId(int Id)
        {

            ART_MUSICA_ESCENARIOS resultado = new ART_MUSICA_ESCENARIOS();
            try
            {
                using (var context = new SIPAEntities())
                {

                    resultado = context.ART_MUSICA_ESCENARIOS.Where(x => x.Id == Id).SingleOrDefault();


                }
                return resultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string ConsultarClasificacionNombre(int ClasificacionId)
        {

            string resultado = "";
            try
            {
                using (var context = new SIPAEntities())
                {

                    resultado = context.ART_MUSICA_PARAMETROS_SERVICIOS.Where(x => x.Id == ClasificacionId).SingleOrDefault().Nombre;


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

                    var registro = context.ART_MUSICA_IMAGENES.Where(x => x.EscenarioId == Id && x.Principal == true).SingleOrDefault();

                    if (registro != null)
                        imagenPrincipal = registro.Imagen;

                }
                return imagenPrincipal;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ART_MUSICA_IMAGENES> ConsultarImagenesEscenarios(int Id)
        {

            List<ART_MUSICA_IMAGENES> resultado = new List<ART_MUSICA_IMAGENES>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    resultado = context.ART_MUSICA_IMAGENES.Where(x => x.EscenarioId == Id).ToList();


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
