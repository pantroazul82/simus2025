using SM.Datos.AuditoriaData;
using SM.Datos.DTO;
using SM.LibreriaComun.DTO;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace SM.Datos.Agentes
{
    /// <summary>
    /// Clase de datos para crear, consultar, editar agentes.
    /// </summary>
    public class AgenteServicio
    {


        #region Consultas
        public static List<Parametro> ConsultarServicioPorInteresId(int AgenteId)
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    var VarParametros = context.ART_MUSICA_AGENTE_INTERESES.Where(x =>  x.AgenteId == AgenteId).ToList();

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
        public static List<Parametro> ConsultarServicioPorAgenteId(int AgenteId)
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    var VarParametros = context.ART_MUSICA_AGENTE_SERVICIO.Where(x => x.Estado == true && x.AgenteId == AgenteId).ToList();

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

        public static List<Parametro> ConsultarAgentesAsociadosPorAgrupacionId(int AgrupacionId)
        {
            var listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    listBasica = (from g in context.ART_MUSICA_AGENTE_AGRUPACION
                                  join a in context.ART_MUSICA_AGENTE on g.AgenteId equals a.ID
                                  where g.AgrupacionId == AgrupacionId
                                  select new Parametro
                                  {
                                      Id = g.Id,
                                      Nombre = a.PrimerNombre + " " + a.SegundoNombre  + " " + a.PrimerApellido + " " + a.SedundoApellido?? " "
                                  }).ToList();

                   

                }
                return listBasica;

            }
            catch (Exception)
            {
                throw;
            }

        }
        public static List<OcupacionResultadoDTO> ConsultarOcupacionPorAgenteId(int AgenteId)
        {
            var listBasica = new List<OcupacionResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    listBasica = context.Database.SqlQuery<OcupacionResultadoDTO>(@"EXEC ART_MUSICA_OCUPACION_POR_AGENTEID @AgenteId", new SqlParameter("AgenteId", AgenteId)).ToList();

                }
                return listBasica;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<AgenteResultadoDTO> ConsultarAgentesRecientes()
        {
            List<AgenteResultadoDTO> listRecientes = new List<AgenteResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listRecientes = (from a in context.ART_MUSICA_AGENTE
                                     orderby a.ID descending
                                     select new AgenteResultadoDTO()
                                     {
                                         AgenteId = a.ID,
                                         Nombres = a.PrimerNombre + " " + a.SegundoNombre,
                                         Apellidos = a.PrimerApellido + " " + a.SedundoApellido,
                                         CodigoDepartamento = a.CodigoDepartamento,
                                         CodMunicipio = a.CodMunicipio,
                                         CodPais = a.CodPais,
                                         CodTipoDocumento = a.CodTipoDocumento,
                                         CorreoElectronico = a.CorreoElectronico,
                                         LinkPortafolio = a.LinkPortafolio
                                     }).Take(200).ToList();

                }
                return listRecientes;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<AgenteResultadoDTO> ConsultarAgentesRecientePorBusqueda(string Busqueda)
        {
            List<AgenteResultadoDTO> listRecientes = new List<AgenteResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {



                    listRecientes = (from a in context.ART_MUSICA_AGENTE
                                     where ((a.PrimerApellido.Contains(Busqueda)) || (a.PrimerNombre.Contains(Busqueda)) ||
                                   (a.SedundoApellido.Contains(Busqueda)) || (a.SegundoNombre.Contains(Busqueda)) || (a.Identificacion.Contains(Busqueda)))
                                     orderby a.ID descending
                                     select new AgenteResultadoDTO()
                                     {
                                         AgenteId = a.ID,
                                         Nombres = a.PrimerNombre + " " + a.SegundoNombre,
                                         Apellidos = a.PrimerApellido + " " + a.SedundoApellido,
                                         CodigoDepartamento = a.CodigoDepartamento,
                                         CodMunicipio = a.CodMunicipio,
                                         CodPais = a.CodPais,
                                         CodTipoDocumento = a.CodTipoDocumento,
                                         CorreoElectronico = a.CorreoElectronico,
                                         LinkPortafolio = a.LinkPortafolio

                                     }).ToList();

                }
                return listRecientes;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<AgenteResultadoDTO> ConsultarAgentesPorAgrupacionId(int AgrupacionId)
        {

            List<AgenteResultadoDTO> listResultado = new List<AgenteResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<AgenteResultadoDTO>(@"EXEC ART_MUSICA_AGENTE_Por_AgrupacionId @AgrupacionId", new SqlParameter("AgrupacionId", AgrupacionId)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<ART_MUSICA_AGENTE_datos_UsuarioId_Result> ConsultarAgenteUsuarioId(int usuarioId)
        {
            try
            {
                var model = new List<ART_MUSICA_AGENTE_datos_UsuarioId_Result>();
                using (var context = new SIPAEntities())
                {

                    model = context.ART_MUSICA_AGENTE_datos_UsuarioId(usuarioId).ToList();

                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ART_MUSICA_AGENTE_datos_EstadoId_Result> ConsultarAgenteEstadoId(int EstadoId)
        {
            try
            {
                var model = new List<ART_MUSICA_AGENTE_datos_EstadoId_Result>();
                using (var context = new SIPAEntities())
                {

                    model = context.ART_MUSICA_AGENTE_datos_EstadoId(EstadoId).ToList();

                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ART_MUSICA_USUARIO ConsultarUsuarioPorId(int Id)
        {
            ART_MUSICA_USUARIO usuario;
            try
            {
                using (var context = new SIPAEntities())
                {

                    usuario = context.ART_MUSICA_USUARIO.Where(x => x.Id == Id).FirstOrDefault();

                }
                return usuario;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public static string ObtenerNombreAgente(int Id)
        {
            string nombrecompleto = string.Empty;
            try
            {
                using (var context = new SIPAEntities())
                {

                    var agente = context.ART_MUSICA_AGENTE.Where(x => x.ID == Id).FirstOrDefault();
                    if (agente != null)
                    {
                        nombrecompleto = agente.PrimerNombre + " " + agente.SegundoNombre + " " + agente.PrimerApellido + " " + agente.SedundoApellido; 
                    }

                }
                return nombrecompleto;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int ObtenerAgenteId(int UsuarioId)
        {
            ART_MUSICA_AGENTE agente;
            int AgenteId = 0;
            try
            {
                using (var context = new SIPAEntities())
                {

                    agente = context.ART_MUSICA_AGENTE.Where(x => x.IdADM_ART_USUARIO == UsuarioId).FirstOrDefault();

                    if (agente != null)
                    {
                        AgenteId = agente.ID;
                    }
                }
                return AgenteId;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ObtenerAgenteId(string Codtipodocumento, string Numerodocumento)
        {
            ART_MUSICA_AGENTE agente;
            int AgenteId = 0;
            int tipoDocumentoId = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    tipoDocumentoId = Convert.ToInt32(Codtipodocumento);

                    agente = context.ART_MUSICA_AGENTE.Where(x => x.CodTipoDocumento == tipoDocumentoId && x.Identificacion == Numerodocumento).FirstOrDefault();

                    if (agente != null)
                        AgenteId = agente.ID;


                }
                return AgenteId;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ART_MUSICA_AGENTE ConsultarAgenteporId(int AgenteId)
        {
            var agente = new ART_MUSICA_AGENTE();
            try
            {
                using (var context = new SIPAEntities())
                {

                    agente = context.ART_MUSICA_AGENTE.Where(x => x.ID == AgenteId).FirstOrDefault();

                }
                return agente;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ART_MUSICA_AGENTE_datos_Id_Result ConsultarDatosAgentePorId(int Id)
        {
            try
            {
                var model = new ART_MUSICA_AGENTE_datos_Id_Result();
                using (var context = new SIPAEntities())
                {

                    model = context.ART_MUSICA_AGENTE_datos_Id(Id).FirstOrDefault();

                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ART_MUSICA_AGENTE_Todos_Result> ConsultarAgentesTodos()
        {
            try
            {
                var model = new List<ART_MUSICA_AGENTE_Todos_Result>();
                using (var context = new SIPAEntities())
                {

                    model = context.ART_MUSICA_AGENTE_Todos().ToList();

                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public static List<AgenteListadoDTO> ConsultarAgentesNuevo()
        {

            var listResultado = new List<AgenteListadoDTO>();

            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = context.Database.SqlQuery<AgenteListadoDTO>(@"EXEC ART_MUSICA_OBTENER_AGENTES").ToList();

                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<AgenteListadoDTO> ConsultarAgentesNuevoPorUsuarioId(int UsuarioId)
        {

            var listResultado = new List<AgenteListadoDTO>();

            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = context.Database.SqlQuery<AgenteListadoDTO>(@"EXEC ART_MUSICA_CONSULTAR_CONVOCATORIAS_ESTIMULOS_ESTADOID @UsuarioId", new SqlParameter("UsuarioId", UsuarioId)).ToList();
                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<ART_MUSICA_AGENTE_POR_DEPARTAMENTO_Result> ConsultarAgentesPermisosTodos(int UsuarioId)
        {
            try
            {
                var model = new List<ART_MUSICA_AGENTE_POR_DEPARTAMENTO_Result>();
                using (var context = new SIPAEntities())
                {

                    model = context.ART_MUSICA_AGENTE_POR_DEPARTAMENTO(UsuarioId).ToList();

                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Actualizacion
        public static int CrearAgente(int ArtMusicaUsuarioId,
                                     string TipoDocumento,
                                     string NumeroDocumento,
                                     string PrimerNombre,
                                     string SegundoNombre,
                                     string PrimerApellido,
                                    string SegundoApellido,
                                    DateTime FechaNacimiento,
                                    string Direccion,
                                    string CorreoElectronico,
                                    string Sexo,
                                    string CodigoPais,
                                    string CodigoDepartamento,
                                    string CodigoMunicipio,
                                    string Telefono,
                                    string linkPortafolio,
                                    byte[] imagen,
                                    string NombreArtistico,
                                    int AreaId,
                                    string descripcion,
                                    string strIP,
                                    string NombreUsuario)
        {
            int AgenteId = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            DateTime? datFechanacimiento;
                            if (FechaNacimiento.ToString() == "1900-01-01")
                                datFechanacimiento = null;
                            else
                                datFechanacimiento = FechaNacimiento;

                            if (string.IsNullOrEmpty(Direccion))
                            {
                                Direccion = " ";
                            }

                            var agente = new ART_MUSICA_AGENTE
                               {
                                   ARD_ID = AgenteConstantes.Musica,
                                   CodMunicipio = CodigoMunicipio,
                                   CodPais = CodigoPais,
                                   CodTipoDocumento = Convert.ToInt32(TipoDocumento),
                                   CorreoElectronico = CorreoElectronico,
                                   CodigoDepartamento = CodigoDepartamento,
                                   Direccion = Direccion,
                                   EstadoId = AgenteConstantes.Pendiente,
                                   FechaCreacion = DateTime.Now,
                                   FechaActualizacion = DateTime.Now,
                                   FechaNacimiento = datFechanacimiento,
                                   IdADM_ART_USUARIO = ArtMusicaUsuarioId,
                                   Identificacion = NumeroDocumento,
                                   Imagen = imagen,
                                   LinkPortafolio = linkPortafolio,
                                   PrimerApellido = PrimerApellido,
                                   PrimerNombre = PrimerNombre,
                                   SedundoApellido = SegundoApellido,
                                   SegundoNombre = SegundoNombre,
                                   Sexo = Sexo,
                                   Telefono = Telefono,
                                   NombreArtistico = NombreArtistico,
                                   ARE_ID  = AreaId,
                                   Descripcion = descripcion 
                               };
                            context.ART_MUSICA_AGENTE.Add(agente);
                            context.SaveChanges();
                            AgenteId = agente.ID;
                           
                            dbContextTransaction.Commit();
                            //Auditoria
                            string temp;
                            temp = string.Format("El usuario {0} ({1}) creó el {2} la escuela.\nDatos actuales:\n{3} ", NombreUsuario, ArtMusicaUsuarioId, DateTime.Now, agente);
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.AppendLine(temp);
                            ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.Agente.ToString(), IpUsuario = strIP, RegistroId = AgenteId, UsuarioId = ArtMusicaUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Creación" };

                            RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                            auditoria.Crear(registroOperacion);
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

            return AgenteId;
        }


        private void CrearAgenteSINIC(ART_MUSICA_AGENTE agente)
        {
            try
            {

                 var url = "http://www.sinic.gov.co/eventossinic/api/SIMUS/ConsultaEventosMusica?esTotal=false";

                WebRequest req = WebRequest.Create(url);

                req.Method = "POST";

                HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
                if (resp.StatusCode == HttpStatusCode.OK)
                {
                }
            }
            catch(Exception)
            {
                throw;
            }

        }

   
        public static bool existenumeroTipoDocumento(string numero, int codtipo)
        {
            var model = new ART_MUSICA_AGENTE();
            bool respuesta = false;

            try
            {
                using (var context = new SIPAEntities())
                {
                    model = context.ART_MUSICA_AGENTE.Where(x => x.Identificacion == numero && x.CodTipoDocumento == codtipo).FirstOrDefault();

                }
                if (model != null && model.ID > 1)
                {
                    respuesta = true;
                }

            }
            catch (Exception)
            {
                respuesta = false;
            }

            return respuesta;
        }
        public static int Crear(int ArtMusicaUsuarioId,
                                   string TipoDocumento,
                                   string NumeroDocumento,
                                   string PrimerNombre,
                                   string SegundoNombre,
                                   string PrimerApellido,
                                  string SegundoApellido,
                                  DateTime FechaNacimiento,
                                  string Direccion,
                                  string CorreoElectronico,
                                  string Sexo,
                                  string CodigoPais,
                                  string CodigoDepartamento,
                                  string CodigoMunicipio,
                                  string Telefono,
                                  string linkPortafolio,
                                  string descripcion,
                                  string nombreArtistico,
                                  string codigoarea,
                                  byte[] imagen,
                                  string strIP,
                                  string NombreUsuario)
        {
            int AgenteId = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            DateTime? datFechanacimiento;
                            int intAreId = Convert.ToInt32(codigoarea);
                            if (FechaNacimiento.ToString() == "1900-01-01")
                                datFechanacimiento = null;
                            else
                                datFechanacimiento = FechaNacimiento;

                            var agente = new ART_MUSICA_AGENTE
                            {
                                ARD_ID = AgenteConstantes.Musica,
                                CodMunicipio = CodigoMunicipio,
                                CodPais = CodigoPais,
                                CodTipoDocumento = Convert.ToInt32(TipoDocumento),
                                CorreoElectronico = CorreoElectronico,
                                CodigoDepartamento = CodigoDepartamento,
                                Direccion = Direccion,
                                EstadoId = AgenteConstantes.Pendiente,
                                FechaCreacion = DateTime.Now,
                                FechaActualizacion = DateTime.Now,
                                FechaNacimiento = datFechanacimiento,
                                IdADM_ART_USUARIO = ArtMusicaUsuarioId,
                                Identificacion = NumeroDocumento,
                                Imagen = imagen,
                                LinkPortafolio = linkPortafolio,
                                PrimerApellido = PrimerApellido,
                                PrimerNombre = PrimerNombre,
                                SedundoApellido = SegundoApellido,
                                SegundoNombre = SegundoNombre,
                                Sexo = Sexo,
                                Telefono = Telefono,
                                Descripcion = descripcion,
                                ARE_ID = intAreId,
                                NombreArtistico = nombreArtistico 
                               
                            };
                            context.ART_MUSICA_AGENTE.Add(agente);
                            context.SaveChanges();
                            AgenteId = agente.ID;
                          
                                dbContextTransaction.Commit();
                            //Auditoria
                            string temp;
                            temp = string.Format("El usuario {0} ({1}) creó el {2} la escuela.\nDatos actuales:\n{3} ", NombreUsuario, ArtMusicaUsuarioId, DateTime.Now, agente);
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.AppendLine(temp);
                            ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.Agente.ToString(), IpUsuario = strIP, RegistroId = AgenteId, UsuarioId = ArtMusicaUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Creación" };

                            RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                            auditoria.Crear(registroOperacion);
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

            return AgenteId;
        }
        public static void ActualizarAgente(int AgenteId,
                                          int ArtMusicaUsuarioId,
                                          string TipoDocumento,
                                          string NumeroDocumento,
                                          string PrimerNombre,
                                          string SegundoNombre,
                                          string PrimerApellido,
                                          string SegundoApellido,
                                          DateTime FechaNacimiento,
                                          string Direccion,
                                          string CorreoElectronico,
                                          string Sexo,
                                          string CodigoPais,
                                          string CodigoDepartamento,
                                          string CodigoMunicipio,
                                          string Telefono,
                                          string linkPortafolio,
                                          string descripcion,
                                         string CodigoArea,
                                         string NombreArtistico,
                                          byte[] imagen,
                                          string strIP,
                                          string NombreUsuario)
        {

            try
            {
                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var agente = context.ART_MUSICA_AGENTE.Where(x => x.ID == AgenteId).FirstOrDefault();
                            DateTime? datFechanacimiento;
                            if (FechaNacimiento.ToString() == "1900-01-01")
                                datFechanacimiento = null;
                            else
                                datFechanacimiento = FechaNacimiento;



                            if (agente != null)
                            {
                                if (string.IsNullOrEmpty(CodigoDepartamento))
                                {
                                    agente.CodigoDepartamento = "";
                                    agente.CodMunicipio = "";
                                }
                                else
                                {
                                    agente.CodigoDepartamento = CodigoDepartamento;
                                    agente.CodMunicipio = CodigoMunicipio;
                                }
                                agente.CodPais = CodigoPais;
                                agente.CodTipoDocumento = Convert.ToInt32(TipoDocumento);
                                agente.CorreoElectronico = CorreoElectronico;
                                agente.Direccion = Direccion;
                                if (agente.EstadoId == AgenteConstantes.Aprobado)
                                    agente.EstadoId = AgenteConstantes.Actualizado;
                                agente.FechaActualizacion = DateTime.Now;
                                agente.FechaNacimiento = datFechanacimiento;
                                agente.IdADM_ART_USUARIO = ArtMusicaUsuarioId;
                                agente.Identificacion = NumeroDocumento;
                                agente.LinkPortafolio = linkPortafolio;
                                agente.PrimerApellido = PrimerApellido;
                                agente.PrimerNombre = PrimerNombre;
                                agente.SedundoApellido = SegundoApellido;
                                agente.SegundoNombre = SegundoNombre;
                                agente.Sexo = Sexo;
                                agente.Telefono = Telefono;
                                agente.Descripcion = descripcion;
                                agente.NombreArtistico = NombreArtistico;
                                agente.ARE_ID = Convert.ToInt32(CodigoArea);
                                if (imagen != null)
                                {
                                    agente.Imagen = imagen;
                                }

                            }
                          
                            context.SaveChanges();
                            dbContextTransaction.Commit();

                            //Auditoria
                            string temp;
                            temp = string.Format("El usuario {0} ({1}) actualizó el {2} al agente.\nDatos actuales:\n{3} ", NombreUsuario, ArtMusicaUsuarioId, DateTime.Now, agente);
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.AppendLine(temp);
                            ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.Agente.ToString(), IpUsuario = strIP, RegistroId = AgenteId, UsuarioId = ArtMusicaUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Actualización" };

                            RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                            auditoria.Crear(registroOperacion);

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

        public static void ActualizarAgenteEstado(int AgenteId,
                                         int EstadoId,
                                         string TipoDocumento,
                                         string NumeroDocumento,
                                         string PrimerNombre,
                                         string SegundoNombre,
                                         string PrimerApellido,
                                         string SegundoApellido,
                                         DateTime FechaNacimiento,
                                         string Direccion,
                                         string CorreoElectronico,
                                         string Sexo,
                                         string CodigoPais,
                                         string CodigoDepartamento,
                                         string CodigoMunicipio,
                                         string Telefono,
                                         string linkPortafolio,
                                         string descripcion,
                                         string CodigoArea,
                                         string NombreArtistico,
                                         byte[] imagen,
                                         string strIP,
                                         string NombreUsuario,
                                         int UsuarioId)
                                        
        {

            try
            {
                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var agente = context.ART_MUSICA_AGENTE.Where(x => x.ID == AgenteId).FirstOrDefault();
                            DateTime? datFechanacimiento;
                            if (FechaNacimiento.ToString() == "1900-01-01")
                                datFechanacimiento = null;
                            else
                                datFechanacimiento = FechaNacimiento;



                            if (agente != null)
                            {
                                if (string.IsNullOrEmpty(CodigoDepartamento))
                                {
                                    agente.CodigoDepartamento = "";
                                    agente.CodMunicipio = "";
                                }
                                else
                                {
                                    agente.CodigoDepartamento = CodigoDepartamento;
                                    agente.CodMunicipio = CodigoMunicipio;
                                }

                                if (EstadoId > 0)
                                    agente.EstadoId = EstadoId;
                                agente.CodPais = CodigoPais;
                                agente.CodTipoDocumento = Convert.ToInt32(TipoDocumento);
                                agente.CorreoElectronico = CorreoElectronico;
                                agente.Direccion = Direccion;
                                agente.FechaActualizacion = DateTime.Now;
                                agente.FechaNacimiento = datFechanacimiento;
                                agente.Identificacion = NumeroDocumento;
                                agente.LinkPortafolio = linkPortafolio;
                                agente.PrimerApellido = PrimerApellido;
                                agente.PrimerNombre = PrimerNombre;
                                agente.SedundoApellido = SegundoApellido;
                                agente.SegundoNombre = SegundoNombre;
                                agente.Sexo = Sexo;
                                agente.Telefono = Telefono;
                                agente.Descripcion = descripcion;
                                agente.NombreArtistico = NombreArtistico;
                             
                                agente.ARE_ID = Convert.ToInt32(CodigoArea);
                                if (imagen != null)
                                {
                                    agente.Imagen = imagen;
                                }

                            }
                            context.SaveChanges();
                           
                            context.SaveChanges();
                            dbContextTransaction.Commit();
                            //Auditoria
                            string temp;
                            temp = string.Format("El usuario {0} ({1}) actualizó por editar el {2} al agente.\nDatos actuales:\n{3} ", NombreUsuario, UsuarioId, DateTime.Now, agente);
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.AppendLine(temp);
                            ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.Agente.ToString(), IpUsuario = strIP, RegistroId = AgenteId, UsuarioId = UsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Actualización aprobador" };

                            RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                            auditoria.Crear(registroOperacion);

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

        public static void ActualizarImagen(int AgenteId, byte[] imagen)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    var agente = context.ART_MUSICA_AGENTE.Where(x => x.ID == AgenteId).FirstOrDefault();
                    if (agente != null)
                    {
                        agente.Imagen = imagen;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void EliminarGenerosPorAgenteId(int AgenteId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_AGENTE_GENEROS.RemoveRange(context.ART_MUSICA_AGENTE_GENEROS.Where(x => x.AgenteId == AgenteId));
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void EliminarOficiosPorAgenteId(int AgenteId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_AGENTE_OFICIOS.RemoveRange(context.ART_MUSICA_AGENTE_OFICIOS.Where(x => x.AgenteId == AgenteId));
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void EliminarAgenteOcupacion(int AgenteOcupacionId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_AGENTEXOCUPACION.Remove(context.ART_MUSICA_AGENTEXOCUPACION.Where(x => x.Id == AgenteOcupacionId).FirstOrDefault());
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void EliminarAgenteServicio(int AgenteServicioId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_AGENTE_SERVICIO.Remove(context.ART_MUSICA_AGENTE_SERVICIO.Where(x => x.Id == AgenteServicioId).FirstOrDefault());
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void EliminarAgenteAgrupacion(int AgrupacionAgenteId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_AGENTE_AGRUPACION.Remove(context.ART_MUSICA_AGENTE_AGRUPACION.Where(x => x.Id == AgrupacionAgenteId).FirstOrDefault());
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void EliminarAgenteInteres(int AgenteInteresId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_AGENTE_INTERESES.Remove(context.ART_MUSICA_AGENTE_INTERESES.Where(x => x.Id == AgenteInteresId).FirstOrDefault());
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void EliminarAgente(int AgenteId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_AGENTE_EXPERIENCIA.RemoveRange(context.ART_MUSICA_AGENTE_EXPERIENCIA.Where(x => x.AgenteId == AgenteId));
                    context.ART_MUSICA_AGENTE.Remove(context.ART_MUSICA_AGENTE.Where(x => x.ID == AgenteId).FirstOrDefault());
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool ValidarOcupacion(int AgenteId, string atributo)
        {
            bool Validate = false;
            try
            {
                using (var context = new SIPAEntities())
                {
                    var registro = context.ART_MUSICA_AGENTEXOCUPACION.Where(x => x.AgenteId == AgenteId && x.Atributo == atributo).FirstOrDefault();

                    if (registro != null)
                        Validate = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Validate;
        }

        public static bool ValidarInstrumentos(int AgenteId, int OficioId, string atributo)
        {
            bool Validate = false;
            try
            {
                using (var context = new SIPAEntities())
                {
                    var registro = context.ART_MUSICA_AGENTES_INSTRUMENTOS.Where(x => x.AgenteId == AgenteId && x.OficioId == OficioId && x.Instrumento == atributo).FirstOrDefault();

                    if (registro != null)
                        Validate = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Validate;
        }
        public static void AgregarOcupacion(ART_MUSICA_AGENTEXOCUPACION registro)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                   context.ART_MUSICA_AGENTEXOCUPACION.Add(registro);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void AgregarInstrumento(ART_MUSICA_AGENTES_INSTRUMENTOS registro)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_AGENTES_INSTRUMENTOS.Add(registro);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void AgregarServicio(ART_MUSICA_AGENTE_SERVICIO registro)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_AGENTE_SERVICIO.Add(registro);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void AgregarAgrupacionAgente(ART_MUSICA_AGENTE_AGRUPACION registro)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_AGENTE_AGRUPACION.Add(registro);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void AgregarInteres(ART_MUSICA_AGENTE_INTERESES registro)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_AGENTE_INTERESES.Add(registro);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

     
        #endregion
    }
}
