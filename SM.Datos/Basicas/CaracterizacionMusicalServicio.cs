using SM.Datos.DTO;
using SM.LibreriaComun.DTO.General;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.Basicas
{
    /// <summary>
    /// Clase de datos  para consultar las tablas basicas de la caracterización musical
    /// </summary>
    public class CaracterizacionMusicalServicio
    {
        public static List<Parametro> ConsultarOficiosMusical()
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    //var VarParametros = context.ART_MUSICA_OFICIOS.Where(x => x.Estado == true).ToList();

                    var VarParametros = context.ART_MUSICA_OFICIOS
                    .Where(t1 => !context.ART_MUSICA_AGENTEXOCUPACION
  .Any(t2 => t2.OficioId == t1.Id)
    );

                    foreach (var item in VarParametros)
                    {
                        var objParametro = new Parametro();
                        objParametro.Id = item.Id;
                        objParametro.Nombre = item.Nombre;
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

        public static List<Parametro> ConsultarAgentePorUsuarioId(int UsuarioId)
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var VarParametros = context.ART_MUSICA_AGENTE.Where(x => x.IdADM_ART_USUARIO == UsuarioId && x.EstadoId == 2);


                    foreach (var item in VarParametros)
                    {
                        var objParametro = new Parametro();
                        objParametro.Id = item.ID;
                        objParametro.Nombre = item.PrimerNombre + " " + item.SegundoNombre + " " + item.PrimerApellido + " " + item.SedundoApellido ?? " ";
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

        public static List<Parametro> ConsultarAgenteAdmin()
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var VarParametros = context.ART_MUSICA_AGENTE.Where(x => x.EstadoId == 2);


                    foreach (var item in VarParametros)
                    {
                        var objParametro = new Parametro();
                        objParametro.Id = item.ID;
                        objParametro.Nombre = item.PrimerNombre + " " + item.SegundoNombre + " " + item.PrimerApellido + " " + item.SedundoApellido ?? " ";
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

        public static List<Parametro> ConsultarEntidadPorUsuarioId(int UsuarioId)
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var VarParametros = context.ART_MUSICA_ENTIDADES.Where(x => x.ArtMusicaUsuarioId == UsuarioId && x.EstadoId == 2);


                    foreach (var item in VarParametros)
                    {
                        var objParametro = new Parametro();
                        objParametro.Id = item.Id;
                        objParametro.Nombre = item.Nombre;
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

        public static List<Parametro> ConsultarEntidadAdmin()
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var VarParametros = context.ART_MUSICA_ENTIDADES.Where(x => x.EstadoId == 2);


                    foreach (var item in VarParametros)
                    {
                        var objParametro = new Parametro();
                        objParametro.Id = item.Id;
                        objParametro.Nombre = item.Nombre;
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

        public static List<Parametro> ConsultarAgrupacionPorUsuarioId(int UsuarioId)
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var VarParametros = context.ART_MUSICA_AGRUPACION.Where(x => x.ArtMusicaUsuarioId == UsuarioId && x.EstadoId == 2);


                    foreach (var item in VarParametros)
                    {
                        var objParametro = new Parametro();
                        objParametro.Id = item.Id;
                        objParametro.Nombre = item.Nombre;
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

        public static List<Parametro> ConsultarAgrupacionAdmin()
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var VarParametros = context.ART_MUSICA_AGRUPACION.Where(x => x.EstadoId == 2);


                    foreach (var item in VarParametros)
                    {
                        var objParametro = new Parametro();
                        objParametro.Id = item.Id;
                        objParametro.Nombre = item.Nombre;
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

        public static List<Parametro> ConsultarEscuelasPorUsuarioId(decimal UsuarioId)
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listBasica = (from e in context.ART_ENTIDADES_ARTES
                                  join i in context.ART_MUSICA_ENTIDAD_IDENTIFICACION on e.ENT_ID equals i.ENT_ID
                                  where e.ENT_TIPO == "E"
                                  where i.EstadoId == 2
                                  where i.USU_ID == UsuarioId
                                  select new Parametro
                                  {
                                      Id = e.ENT_ID,
                                      Nombre = e.ENT_NOMBRE
                                  }).ToList();


                }
                return listBasica;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Parametro> ConsultarEscuelasAdmin()
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listBasica = (from e in context.ART_ENTIDADES_ARTES
                                  where e.ENT_TIPO == "E"
                                  where e.ENT_ESTADO == "E"
                                  select new Parametro
                                  {
                                      Id = e.ENT_ID,
                                      Nombre = e.ENT_NOMBRE
                                  }).ToList();


                }
                return listBasica;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Parametro> ConsultarServicios()
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    var VarParametros = context.ART_MUSICA_SERVICIOS.Where(x => x.Estado == true).ToList();

                    foreach (var item in VarParametros)
                    {
                        var objParametro = new Parametro();
                        objParametro.Id = item.Id;
                        objParametro.Nombre = item.Nombre;
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

        public static List<Parametro> ConsultarGenerosMusicalesNuevo()
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    var VarParametros = context.ART_MUSICA_GENEROS_MUSICALES.Where(x => x.Estado == true).ToList();

                    foreach (var item in VarParametros)
                    {
                        var objParametro = new Parametro();
                        objParametro.Id = item.Id;
                        objParametro.Nombre = item.Nombre;
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


        public static List<Parametro> ConsultarAgentes()
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    var VarParametros = context.ART_MUSICA_AGENTE.Where(x => x.EstadoId == 2).ToList();

                    foreach (var item in VarParametros)
                    {
                        var objParametro = new Parametro();
                        objParametro.Id = item.ID;
                        objParametro.Nombre = item.PrimerNombre + " " + item.SegundoNombre + " " + item.PrimerApellido + " " + item.SedundoApellido ?? " ";
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
        public static List<Parametro> ConsultarIntereses()
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    var VarParametros = context.ART_MUSICA_INTERESES.Where(x => x.Estado == true).ToList();

                    foreach (var item in VarParametros)
                    {
                        var objParametro = new Parametro();
                        objParametro.Id = item.Id;
                        objParametro.Nombre = item.Nombre;
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

        public static List<Parametro> ConsultarInstrumentos()
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    var VarParametros = context.ART_MUSICA_INSTRUMENTOS.Where(x => x.IsEstado == true).ToList();

                    foreach (var item in VarParametros)
                    {
                        var objParametro = new Parametro();
                        objParametro.Id = item.Id;
                        objParametro.Nombre = item.Nombre;
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

        public static List<Parametro> ConsultarListadoInstrumentos()
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    var VarParametros = context.ART_MUSICA_INSTRUMENTOS.Where(x => x.IsEstado == true && x.PadreId != null).OrderBy(x => x.Nombre).ToList();

                    foreach (var item in VarParametros)
                    {
                        var objParametro = new Parametro();
                        objParametro.Id = item.Id;
                        objParametro.Nombre = item.Nombre;
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

        public static string ObenerNombreInstrumento(int Id)
        {
            string Nombre = "";
            try
            {
                using (var context = new SIPAEntities())
                {
                    Nombre = context.ART_MUSICA_INSTRUMENTOS.Where(x => x.Id == Id).FirstOrDefault().Nombre;

                }
                return Nombre;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int ObtenerOficioId(string atributo)
        {
            int OficioId = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    var VarParametros = context.ART_MUSICA_OFICIOS.Where(x => x.Nombre == atributo).FirstOrDefault();
                    if (VarParametros != null)
                    {
                        OficioId = VarParametros.Id;
                    }
                }

                return OficioId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ObtenerGeneroId(string atributo)
        {
            int OficioId = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    var VarParametros = context.ART_MUSICA_GENEROS_MUSICALES.Where(x => x.Nombre == atributo).FirstOrDefault();
                    if (VarParametros != null)
                    {
                        OficioId = VarParametros.Id;
                    }
                }

                return OficioId;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int ObtenerInstrumentoId(string atributo)
        {
            int InstrumentoId = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    var VarParametros = context.ART_MUSICA_INSTRUMENTOS.Where(x => x.Nombre == atributo).FirstOrDefault();
                    if (VarParametros != null)
                    {
                        InstrumentoId = VarParametros.Id;
                    }
                }

                return InstrumentoId;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int ObtenerServicioId(string atributo)
        {
            int ServicioId = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    var VarParametros = context.ART_MUSICA_SERVICIOS.Where(x => x.Nombre == atributo).FirstOrDefault();
                    if (VarParametros != null)
                    {
                        ServicioId = VarParametros.Id;
                    }
                }

                return ServicioId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ObtenerAgenteId(string atributo)
        {
            int AgenteId = 0;
         
            try
            {


                using (var context = new SIPAEntities())
                {
                    var VarParametros = new ART_MUSICA_AGENTE();
                    /// Nombre completo


                    VarParametros = context.ART_MUSICA_AGENTE.Where(x => x.Identificacion == atributo).FirstOrDefault();



                    if (VarParametros != null)
                    {
                        AgenteId = VarParametros.ID;
                    }
                }

                return AgenteId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ObtenerInteresId(string atributo)
        {
            int ServicioId = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    var VarParametros = context.ART_MUSICA_INTERESES.Where(x => x.Nombre == atributo).FirstOrDefault();
                    if (VarParametros != null)
                    {
                        ServicioId = VarParametros.Id;
                    }
                }

                return ServicioId;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Parametro> ConsultarTipoEntidad()
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    var VarParametros = context.ART_MUSICA_TIPO_ENTIDAD.ToList();

                    foreach (var item in VarParametros)
                    {
                        var objParametro = new Parametro();
                        objParametro.Id = item.Id;
                        objParametro.Nombre = item.Nombre;
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

        public static List<Parametro> ConsultarEstados()
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    var VarParametros = context.ART_MUSICA_ESTADOS.ToList();

                    foreach (var item in VarParametros)
                    {
                        var objParametro = new Parametro();
                        objParametro.Id = item.Id;
                        objParametro.Nombre = item.Nombre;
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

        public static List<Parametro> ConsultarTipoAgrupacion()
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    var VarParametros = context.ART_MUSICA_TIPO_AGRUPACION.ToList();

                    foreach (var item in VarParametros)
                    {
                        var objParametro = new Parametro();
                        objParametro.Id = item.Id;
                        objParametro.Nombre = item.Nombre;
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

        public static List<Parametro> ConsultarNaturaleza()
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    var VarParametros = context.ART_MUSICA_NATURALEZA_AGRUPACION.ToList();

                    foreach (var item in VarParametros)
                    {
                        var objParametro = new Parametro();
                        objParametro.Id = item.Id;
                        objParametro.Nombre = item.Nombre;
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

        public static List<Parametro> ConsultarAgenteOficiosSeleccionada(int AgenteId)
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listBasica = (from ge in context.ART_MUSICA_AGENTE_OFICIOS
                                  join g in context.ART_MUSICA_OFICIOS on ge.OficioId equals g.Id
                                  where ge.AgenteId == AgenteId
                                  select new Parametro
                                  {
                                      Id = ge.OficioId,
                                      Nombre = g.Nombre
                                  }).ToList();

                }
                return listBasica;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Parametro> ConsultarTipoEntidadSeleccionada(int EntidadId)
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listBasica = (from ge in context.ART_MUSICA_ENTIDAD_TIPOENTIDAD
                                  join g in context.ART_MUSICA_TIPO_ENTIDAD on ge.TipoEntidadId equals g.Id
                                  where ge.EntidadId == EntidadId
                                  select new Parametro
                                  {
                                      Id = ge.TipoEntidadId,
                                      Nombre = g.Nombre
                                  }).ToList();

                }
                return listBasica;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<GenerosMusicalesResultadoDTO> ConsultarGenerosMusicales()
        {

            List<GenerosMusicalesResultadoDTO> listResultado = new List<GenerosMusicalesResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<GenerosMusicalesResultadoDTO>(@"EXEC ART_MUSICA_OBTENER_GENEROS_MUSICALES").ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public static List<Parametro> ConsultarGenerosMusicalesPorAgenteId(int AgenteId)
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    var VarParametros = context.ART_MUSICA_OBTENER_GENEROS_MUSICALES_AGENTEID(AgenteId).ToList();

                    foreach (var item in VarParametros)
                    {
                        var objParametro = new Parametro();
                        objParametro.Id = item.Id;
                        objParametro.Nombre = item.Nombre;
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

        public static List<Parametro> ConsultarAgenteGenerosSeleccionados(int AgenteId)
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listBasica = (from ge in context.ART_MUSICA_AGENTE_GENEROS
                                  join g in context.ART_MUSICA_GENEROS_MUSICALES on ge.GeneroId equals g.Id
                                  where ge.AgenteId == AgenteId
                                  select new Parametro
                                        {
                                            Id = ge.GeneroId,
                                            Nombre = g.Nombre
                                        }).ToList();

                }
                return listBasica;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Parametro> ConsultarAgrupacionGenerosSeleccionados(int AgrupacionId)
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listBasica = (from ge in context.ART_MUSICA_AGRUPACION_GENEROS
                                  join g in context.ART_MUSICA_GENEROS_MUSICALES on ge.GeneroId equals g.Id
                                  where ge.AgrupacionId == AgrupacionId
                                  select new Parametro
                                  {
                                      Id = ge.GeneroId ?? 0,
                                      Nombre = g.Nombre
                                  }).ToList();

                }
                return listBasica;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Parametro> ConsultarCategoriaCelebra()
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    var VarParametros = context.ART_MUSICA_CELEBRA_CATEGORIA.Where(x => x.EsActivo == true).ToList();

                    foreach (var item in VarParametros)
                    {
                        var objParametro = new Parametro();
                        objParametro.Id = item.Id;
                        objParametro.Nombre = item.Nombre;
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

        public static List<Parametro> ConsultarProcesoFormacionCelebra()
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    var VarParametros = context.ART_MUSICA_PROCESO_FORMACION.ToList();

                    foreach (var item in VarParametros)
                    {
                        var objParametro = new Parametro();
                        objParametro.Id = item.Id;
                        objParametro.Nombre = item.Nombre;
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

        #region CertificacionSIMUS
        public static CertificacionDTO ObtenerdatosEscuelas(decimal EscuelaId)
        {
            var listBasica = new CertificacionDTO();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listBasica = (from e in context.ART_ENTIDADES_ARTES
                                  join i in context.ART_MUSICA_ENTIDAD_IDENTIFICACION on e.ENT_ID equals i.ENT_ID
                                  join s in context.ART_MUSICA_ESTADOS on i.EstadoId equals s.Id
                                  where e.ENT_TIPO == "E"
                                  where e.ENT_ID == EscuelaId
                                  select new CertificacionDTO
                                  {
                                      Id = Convert.ToInt64(e.ENT_ID),
                                      Nombre = e.ENT_NOMBRE,
                                      Estado = s.Nombre,
                                      FechaCreacion = e.ENT_FECHA_DILIGENCIAMIENTO,
                                      FechaActualizacion = e.ENT_FECHA_ACTUALIZACION
                                  }).FirstOrDefault();


                }
                return listBasica;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static CertificacionDTO ObtenerdatosAgentes(Int32 AgenteId)
        {
            var listBasica = new CertificacionDTO();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listBasica = (from e in context.ART_MUSICA_AGENTE
                                  join s in context.ART_MUSICA_ESTADOS on e.EstadoId equals s.Id
                                  where e.ID == AgenteId
                                  select new CertificacionDTO
                                  {
                                      Id = e.ID,
                                      Nombre = e.PrimerNombre + " " + e.SegundoNombre + " " + e.PrimerApellido + " " + e.SedundoApellido,
                                      Estado = s.Nombre,
                                      FechaCreacion = e.FechaCreacion,
                                      FechaActualizacion = e.FechaActualizacion
                                  }).FirstOrDefault();


                }
                return listBasica;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static CertificacionDTO ObtenerdatosEntidades(Int32 entidadid)
        {
            var listBasica = new CertificacionDTO();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listBasica = (from e in context.ART_MUSICA_ENTIDADES
                                  join s in context.ART_MUSICA_ESTADOS on e.EstadoId equals s.Id
                                  where e.Id == entidadid
                                  select new CertificacionDTO
                                  {
                                      Id = e.Id,
                                      Nombre = e.Nombre,
                                      Estado = s.Nombre,
                                      FechaCreacion = e.FechaCreacion,
                                      FechaActualizacion = e.FechaActualizacion
                                  }).FirstOrDefault();


                }
                return listBasica;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static CertificacionDTO ObtenerdatosAgrupacion(Int32 agrupacionID)
        {
            var listBasica = new CertificacionDTO();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listBasica = (from e in context.ART_MUSICA_AGRUPACION
                                  join s in context.ART_MUSICA_ESTADOS on e.EstadoId equals s.Id
                                  where e.Id == agrupacionID
                                  select new CertificacionDTO
                                  {
                                      Id = e.Id,
                                      Nombre = e.Nombre,
                                      Estado = s.Nombre,
                                      FechaCreacion = e.FechaCreacion,
                                      FechaActualizacion = e.FechaActualizacion
                                  }).FirstOrDefault();


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
