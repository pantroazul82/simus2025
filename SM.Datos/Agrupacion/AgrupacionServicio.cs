using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SM.Datos.DTO;
using SM.SIPA;
using SM.Datos.Agentes;
using System.Data.SqlClient;
using SM.Datos.AuditoriaData;
using SM.LibreriaComun.DTO.WSDepartamento;
using SM.Datos.Helper;

namespace SM.Datos.Agrupacion
{
    /// <summary>
    /// Clase de datos para crear, consultar, editar las agrupaciones
    /// </summary>
   public class AgrupacionServicio
    {
       #region consultaWebAPI

       public static List<AgrupacionWSDTO> ConsultarWebApiAgrupaciones(string usuario, string contrasena, out string mensajeError)
       {
           List<AgrupacionWSDTO> ListEntidades = new List<AgrupacionWSDTO>();
           string codigoDepartamento = "";
           try
           {
               codigoDepartamento = UsuarioWsService.ValidaUsuario(usuario, contrasena);

               if (string.IsNullOrEmpty(codigoDepartamento))
               {
                   mensajeError = "Usuario y/o contrasena invalido";

               }
               else
               {
                   mensajeError = "";
                   using (var context = new SIPAEntities())
                   {

                       ListEntidades = (from a in context.ART_MUSICA_AGRUPACION
                                        join z in context.BAS_ZONAS_GEOGRAFICAS on a.CodigoMunicipio equals z.ZON_ID
                                        join d in context.BAS_ZONAS_GEOGRAFICAS on z.ZON_PADRE_ID equals d.ZON_ID
                                        join T in context.ART_MUSICA_TIPO_AGRUPACION on a.TipoAgrupacionId equals T.Id
                                        where a.EstadoId == 2
                                        where a.CodigoDepartamento == codigoDepartamento
                                        select new AgrupacionWSDTO
                                        {
                                            AgrupacionId = a.Id,
                                            CodigoDepartamento = d.ZON_ID,
                                            CodigoMunicipio = z.ZON_ID,
                                            CorreoElectronico = a.CorreoElectronico,
                                            Direccion = a.Direccion,
                                            FechaActualizacion = a.FechaActualizacion,
                                            FechaCreacion = a.FechaCreacion,
                                            Nombre = a.Nombre,
                                            LinkPortafolio = a.LinkPortafolio,
                                            Telefono = a.Telefono,
                                            Descripcion = a.Descripcion,
                                            Departamento = d.ZON_NOMBRE,
                                            Municipio = z.ZON_NOMBRE,
                                            TipoAgrupacion = T.Nombre
                                         
                                        }).ToList();


                   }
               }
               return ListEntidades;

           }
           catch (Exception)
           {
               throw;
           }
       }
       #endregion
       #region Consultas
       public static List<Parametro> ConsultarGenerosPorAgrupacionId(int agrupacionId)
       {
           var listBasica = new List<Parametro>();
           try
           {
               using (var context = new SIPAEntities())
               {
                   var VarParametros = context.ART_MUSICA_AGRUPACION_GENEROS.Where(x => x.AgrupacionId == agrupacionId).ToList();

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
       public static AgrupacionResultadoDTO ConsultarDatosAgrupacionPorId(int Id)
       {

           var resultado = new AgrupacionResultadoDTO();
          
           try
           {
               using (var context = new SIPAEntities())
               {


                   resultado = context.Database.SqlQuery<AgrupacionResultadoDTO>(@"EXEC ART_MUSICA_AGRUPACION_Id @AgrupacionId", new SqlParameter("AgrupacionId", Id)).FirstOrDefault();

               }
               return resultado;

           }
           catch (Exception)
           {
               throw;
           }
       }

       public static List<AgrupacionResultadoDTO> ConsultarAgrupacionTodos()
       {

           List<AgrupacionResultadoDTO> listResultado = new List<AgrupacionResultadoDTO>();
           try
           {
               using (var context = new SIPAEntities())
               {


                   listResultado = context.Database.SqlQuery<AgrupacionResultadoDTO>(@"EXEC ART_MUSICA_AGRUPACION_Todos").ToList();


               }
               return listResultado;

           }
           catch (Exception)
           {
               throw;
           }
       }

       public static List<AgrupacionResultadoDTO> ConsultarAgrupacionObtenerTodos()
       {

           List<AgrupacionResultadoDTO> listResultado = new List<AgrupacionResultadoDTO>();
           try
           {
               using (var context = new SIPAEntities())
               {


                   listResultado = context.Database.SqlQuery<AgrupacionResultadoDTO>(@"EXEC ART_MUSICA_OBTENER_AGRUPACIONES").ToList();


               }
               return listResultado;

           }
           catch (Exception)
           {
               throw;
           }
       }

       public static List<AgrupacionHomeDTO> ConsultarAgrupacionHome()
       {

           var listResultado = new List<AgrupacionHomeDTO>();
           try
           {
               using (var context = new SIPAEntities())
               {


                   listResultado = context.Database.SqlQuery<AgrupacionHomeDTO>(@"EXEC ART_MUSICA_AGRUPACIONES_HOME").ToList();


               }
               return listResultado;

           }
           catch (Exception)
           {
               throw;
           }
       }

       public static List<AgrupacionHomeDTO> ConsultarAgrupacionHomePorDepartamento(string coddepto)
       {

           var listResultado = new List<AgrupacionHomeDTO>();
           try
           {
               using (var context = new SIPAEntities())
               {


                   listResultado = context.Database.SqlQuery<AgrupacionHomeDTO>(@"EXEC ART_MUSICA_AGRUPACIONES_HOME_COD_DEPTO @CODEPTO", new SqlParameter("CODEPTO", coddepto)).ToList();


               }
               return listResultado;

           }
           catch (Exception)
           {
               throw;
           }
       }

       public static List<AgrupacionHomeDTO> ConsultarAgrupacionHomePorMunicipio(string codMunicipio)
       {

           var listResultado = new List<AgrupacionHomeDTO>();
           try
           {
               using (var context = new SIPAEntities())
               {


                   listResultado = context.Database.SqlQuery<AgrupacionHomeDTO>(@"EXEC ART_MUSICA_AGRUPACIONES_HOME_COD_MUNICIPIO @CodMunicipio", new SqlParameter("CodMunicipio", codMunicipio)).ToList();


               }
               return listResultado;

           }
           catch (Exception)
           {
               throw;
           }
       }

       public static List<AgrupacionResultadoDTO> ConsultarAgrupacionPorUsuarioId(int UsuarioId)
       {

           List<AgrupacionResultadoDTO> listResultado = new List<AgrupacionResultadoDTO>();
           try
           {
               using (var context = new SIPAEntities())
               {


                   listResultado = context.Database.SqlQuery<AgrupacionResultadoDTO>(@"EXEC ART_MUSICA_AGRUPACION_UsuarioId @UsuarioId", new SqlParameter("UsuarioId", UsuarioId)).ToList();


               }
               return listResultado;

           }
           catch (Exception)
           {
               throw;
           }
       }


       public static List<AgrupacionResultadoDTO> ConsultarAgrupacionPorEstadoId(int EstadoId)
       {

           List<AgrupacionResultadoDTO> listResultado = new List<AgrupacionResultadoDTO>();
           try
           {
               using (var context = new SIPAEntities())
               {


                   listResultado = context.Database.SqlQuery<AgrupacionResultadoDTO>(@"EXEC ART_MUSICA_AGRUPACION_EstadoId @EstadoId", new SqlParameter("EstadoId", EstadoId)).ToList();


               }
               return listResultado;

           }
           catch (Exception)
           {
               throw;
           }
       }

       public static List<AgrupacionResultadoDTO> ConsultarAgrupacionPorMunicipio(int UsuarioId)
       {

           List<AgrupacionResultadoDTO> listResultado = new List<AgrupacionResultadoDTO>();
           try
           {
               using (var context = new SIPAEntities())
               {


                   listResultado = context.Database.SqlQuery<AgrupacionResultadoDTO>(@"EXEC ART_MUSICA_AGRUPACION_Municipio @UsuarioId", new SqlParameter("UsuarioId", UsuarioId)).ToList();


               }
               return listResultado;

           }
           catch (Exception)
           {
               throw;
           }
       }

       public static List<AgrupacionResultadoDTO> ConsultarAgrupacionPorMunicipioNuevo(int UsuarioId)
       {

           List<AgrupacionResultadoDTO> listResultado = new List<AgrupacionResultadoDTO>();
           try
           {
               using (var context = new SIPAEntities())
               {


                   listResultado = context.Database.SqlQuery<AgrupacionResultadoDTO>(@"EXEC ART_MUSICA_OBTENER_AGRUPACIONES_MUNICIPIO @UsuarioId", new SqlParameter("UsuarioId", UsuarioId)).ToList();


               }
               return listResultado;

           }
           catch (Exception)
           {
               throw;
           }
       }

       public static int ObteneragenteId(int tipodocumentoId, string identificacion)
       {
           int AgenteId = 0;
              try
           {
               using (var context = new SIPAEntities())
               {
                   var agente = context.ART_MUSICA_AGENTE.Where(x => x.CodTipoDocumento == tipodocumentoId && x.Identificacion == identificacion).FirstOrDefault();

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

       public static ART_MUSICA_AGENTE ObteneragentePorDocumento(int tipodocumentoId, string identificacion)
       {
           var agente = new ART_MUSICA_AGENTE();
           try
           {
               using (var context = new SIPAEntities())
               {
                    agente = context.ART_MUSICA_AGENTE.Where(x => x.CodTipoDocumento == tipodocumentoId && x.Identificacion == identificacion).FirstOrDefault();

                  
               }
               return agente;

           }
           catch (Exception)
           {
               throw;
           }
       }
       public static ART_MUSICA_AGRUPACION ConsultarAgrupacionPorId(int AgrupacionId)
       {
           var agrupacion = new ART_MUSICA_AGRUPACION ();
           try
           {
               using (var context = new SIPAEntities())
               {

                   agrupacion = context.ART_MUSICA_AGRUPACION.Where(x => x.Id == AgrupacionId).FirstOrDefault();

               }
               return agrupacion;

           }
           catch (Exception)
           {
               throw;
           }
       }
       #endregion

       #region Actualizacion

       public static void EliminarAgrupaciongenero(int AgrupacionGeneroId)
       {
           try
           {
               using (var context = new SIPAEntities())
               {
                   context.ART_MUSICA_AGRUPACION_GENEROS.Remove(context.ART_MUSICA_AGRUPACION_GENEROS.Where(x => x.Id == AgrupacionGeneroId).FirstOrDefault());
                   context.SaveChanges();
               }
           }
           catch (Exception)
           {
               throw;
           }
       }

       public static void AgregarAgrupacionGenero(ART_MUSICA_AGRUPACION_GENEROS registro)
       {
           try
           {
               using (var context = new SIPAEntities())
               {
                   context.ART_MUSICA_AGRUPACION_GENEROS.Add(registro);
                   context.SaveChanges();
               }
           }
           catch (Exception)
           {
               throw;
           }
       }
       public static void AgregarAgente(int AgrupacionId, int AgenteId)
       {
           try
           {
               using (var context = new SIPAEntities())
               {
                   var agente = context.ART_MUSICA_AGENTE_AGRUPACION.Where(x => x.AgrupacionId == AgrupacionId && x.AgenteId == AgenteId).FirstOrDefault();

                   if (agente == null)
                   {
                       var entidad = new ART_MUSICA_AGENTE_AGRUPACION
                       {
                           AgrupacionId = AgrupacionId,
                           AgenteId = AgenteId,
                       };
                       context.ART_MUSICA_AGENTE_AGRUPACION.Add(entidad);
                       context.SaveChanges();
                   }
               }

           }
           catch (Exception)
           {
               throw;
           }
       }
       public static int CrearAgrupacion(int ArtMusicaUsuarioId,
                                     string Nombre,
                                     int TipoAgrupacionId,
                                     string codigoPais,
                                     string codigoMunicipio,
                                     string codigoDepartamento,
                                     string Direccion,
                                     string CorreoElectronico,
                                     string Telefono,
                                     string linkPortafolio,
                                     byte[] imagen,
                                     string descripcion,
                                     int NaturalezaId,
                                     int AreaId,
                                     string NombreUsuario,
                                      string strIP)
        {

            try
            {
                int AgrupacionId = 0;
                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                         
                            var entidad = new ART_MUSICA_AGRUPACION 
                            {
                                ArdId = AgenteConstantes.Musica,
                                Nombre = Nombre,
                                CodigoMunicipio = codigoMunicipio,
                                CodigoDepartamento = codigoDepartamento,
                                CodigoPais = codigoPais,
                                CorreoElectronico = CorreoElectronico,
                                Direccion = Direccion,
                                EstadoId = 1,
                                FechaCreacion = DateTime.Now,
                                FechaActualizacion = DateTime.Now,
                                ArtMusicaUsuarioId = ArtMusicaUsuarioId,
                                LinkPortafolio = linkPortafolio,
                                Descripcion = descripcion,
                                Telefono = Telefono,
                                Imagen = imagen,
                                TipoAgrupacionId = TipoAgrupacionId,
                                NaturalezaId = NaturalezaId,
                                ARE_ID = AreaId
                            };
                            context.ART_MUSICA_AGRUPACION.Add(entidad);
                            context.SaveChanges();
                            AgrupacionId = entidad.Id;

                        
                            dbContextTransaction.Commit();

                            //Auditoria
                            string temp;
                            temp = string.Format("El usuario {0} ({1}) creó el {2} la  agrupación.\nDatos actuales:\n{3} ", NombreUsuario, ArtMusicaUsuarioId, DateTime.Now, entidad);
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.AppendLine(temp);
                            ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.Agrupación.ToString(), IpUsuario = strIP, RegistroId = AgrupacionId, UsuarioId = ArtMusicaUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Creación" };

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
                return AgrupacionId;

            }
            catch (Exception)
            {
                throw;
            }
           


        }

        public static void ActualizarAgrupacionDocumento(int AgrupacionId,
                                                int documentoId)
       {
            try
            {
                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_AGRUPACION.Where(x => x.Id == AgrupacionId).FirstOrDefault();

                    if (entidad != null)
                    {
                        entidad.DocumentoId = documentoId;
                        entidad.FechaActualizacion = DateTime.Now;
                    }
                    context.SaveChanges();
                }
            }
            catch(Exception)
            { throw; }
       }


        public static void ActualizarAgrupacion(int AgrupacionId,
                                    int ArtMusicaUsuarioId,
                                     string Nombre,
                                     int TipoAgrupacionId,
                                     string codigoPais,
                                     string codigoMunicipio,
                                     string codigoDepartamento,
                                     string Direccion,
                                     string CorreoElectronico,
                                     string Telefono,
                                     string linkPortafolio,
                                     byte[] imagen,
                                     string descripcion,
                                     int NaturalezaId,
                                     int AreaId,
                                     string NombreUsuario,
                                     string strIP)
        {

            try
            {
                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var entidad = context.ART_MUSICA_AGRUPACION.Where(x => x.Id == AgrupacionId).FirstOrDefault();

                            if (entidad != null)
                            {
                                entidad.ArtMusicaUsuarioId = ArtMusicaUsuarioId;
                                if (string.IsNullOrEmpty(codigoDepartamento))
                                {
                                    entidad.CodigoDepartamento = "";
                                    entidad.CodigoMunicipio = "";
                                }
                                else
                                {
                                    entidad.CodigoDepartamento = codigoDepartamento;
                                    entidad.CodigoMunicipio = codigoMunicipio;
                                }
                                if (entidad.EstadoId == AgenteConstantes.Aprobado)
                                    entidad.EstadoId = AgenteConstantes.Actualizado;
                                entidad.CodigoPais = codigoPais;
                                entidad.CorreoElectronico = CorreoElectronico;
                                entidad.Descripcion = descripcion;
                             
                                entidad.Direccion = entidad.Direccion;
                                entidad.FechaActualizacion = DateTime.Now;
                                entidad.LinkPortafolio = linkPortafolio;
                                entidad.TipoAgrupacionId = TipoAgrupacionId;
                                entidad.Nombre = Nombre;
                                entidad.Telefono = Telefono;
                                entidad.NaturalezaId = NaturalezaId;
                                entidad.ARE_ID = AreaId;
     

                                if (imagen != null)
                                    entidad.Imagen = imagen;

                            }


                          
                            context.SaveChanges();
                            dbContextTransaction.Commit();

                            //Auditoria
                            string temp;
                            temp = string.Format("El usuario {0} ({1}) actualizó el {2} la  agrupación.\nDatos actuales:\n{3} ", NombreUsuario, ArtMusicaUsuarioId, DateTime.Now, entidad);
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.AppendLine(temp);
                            ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.Agrupación.ToString(), IpUsuario = strIP, RegistroId = AgrupacionId, UsuarioId = ArtMusicaUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Actualización" };

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

        public static void EliminarGenerosPorAgrupacionId(int AgrupacionId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_AGRUPACION_GENEROS.RemoveRange(context.ART_MUSICA_AGRUPACION_GENEROS.Where(x => x.AgrupacionId == AgrupacionId));
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void ActualizarAgrupacionEstado(int AgrupacionId,
                                                      int ArtMusicaUsuarioId,
                                                      string Nombre,
                                                      int TipoAgrupacionId,
                                                        string codigoPais,
                                                        string codigoMunicipio,
                                                        string codigoDepartamento,
                                                        string Direccion,
                                                        string CorreoElectronico,
                                                        string Telefono,
                                                        string linkPortafolio,
                                                        byte[] imagen,
                                                        string descripcion,
                                                        int EstadoId,
                                                        int NaturalezaId,
                                                       string NombreUsuario,
                                                        string strIP)
                                            
        {

            try
            {
                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var entidad = context.ART_MUSICA_AGRUPACION.Where(x => x.Id == AgrupacionId).FirstOrDefault();

                            if (entidad != null)
                            {
                                if (string.IsNullOrEmpty(codigoDepartamento))
                                {
                                    entidad.CodigoDepartamento = "";
                                    entidad.CodigoMunicipio = "";
                                }
                                else
                                {
                                    entidad.CodigoDepartamento = codigoDepartamento;
                                    entidad.CodigoMunicipio = codigoMunicipio;
                                }
                                if (EstadoId > 0)
                                    entidad.EstadoId = EstadoId;
                                entidad.CodigoPais = codigoPais;

                                entidad.CorreoElectronico = CorreoElectronico;
                                entidad.Descripcion = descripcion;

                                entidad.Direccion = entidad.Direccion;
                                entidad.FechaActualizacion = DateTime.Now;
                                entidad.LinkPortafolio = linkPortafolio;
                                entidad.TipoAgrupacionId = TipoAgrupacionId;
                                entidad.Nombre = Nombre;
                                entidad.Telefono = Telefono;
                                entidad.NaturalezaId = NaturalezaId; 

                                if (imagen != null)
                                    entidad.Imagen = imagen;

                            }

                           
                            context.SaveChanges();
                            dbContextTransaction.Commit();

                            //Auditoria
                            string temp;
                            temp = string.Format("El usuario {0} ({1}) actualizó el {2} la  agrupación.\nDatos actuales:\n{3} ", NombreUsuario, ArtMusicaUsuarioId, DateTime.Now, entidad);
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.AppendLine(temp);
                            ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.Agrupación.ToString(), IpUsuario = strIP, RegistroId = AgrupacionId, UsuarioId = ArtMusicaUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Actualización aprobación" };

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

        public static void EliminarAgenteAgrupacion(int AgenteAgrupacionId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_AGENTE_AGRUPACION.Remove(context.ART_MUSICA_AGENTE_AGRUPACION.Where(x => x.Id == AgenteAgrupacionId).FirstOrDefault());
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
