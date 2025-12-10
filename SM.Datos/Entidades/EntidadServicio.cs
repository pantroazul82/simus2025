using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.Datos.DTO;
using SM.SIPA;
using SM.Datos.Agentes;
using System.Data.SqlClient;
using SM.Datos.AuditoriaData;
using SM.LibreriaComun.DTO;

namespace SM.Datos.Entidades
{
    public class EntidadServicio
    {
        #region Actualizacion
        public static void CrearEntidad(int ArtMusicaUsuarioId,
                                     string Nombre,
                                     int Nit,
                                     int DigitoVerificacion,
                                     int codigoPais,
                                     string codigoMunicipio,
                                     string codigoDepartamento,
                                     string Direccion,
                                     string CorreoElectronico,
                                     string Telefono,
                                     string linkPortafolio,
                                     byte[] imagen,
                                     string descripcion,
                                     string naturaleza,
                                     string[] TipoEntidad,
                                     string NombreUsuario,
                                     string strIP)
        {
                int intEntidadId  =0;

            try
            {
                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            int? digito = null;

                            if (DigitoVerificacion > 0)
                                digito = DigitoVerificacion;
                            var entidad = new ART_MUSICA_ENTIDADES
                            {
                                ArdId = AgenteConstantes.Musica,
                                Nombre = Nombre,
                                Nit = Nit,
                                DigitoVerificacion = digito,
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
                                Naturaleza = naturaleza,
                                Imagen = imagen,
                            };
                            context.ART_MUSICA_ENTIDADES.Add(entidad);
                            context.SaveChanges();
                            intEntidadId = entidad.Id;
                            if (intEntidadId > 0)
                            {
                                if (TipoEntidad != null)
                                {
                                    foreach (var item in TipoEntidad)
                                    {
                                        int Valor = Convert.ToInt32(item);
                                        var vartipoentidad = new ART_MUSICA_ENTIDAD_TIPOENTIDAD
                                          {
                                              EntidadId = intEntidadId,
                                              TipoEntidadId = Valor,
                                          };
                                        context.ART_MUSICA_ENTIDAD_TIPOENTIDAD.Add(vartipoentidad);
                                       
                                    }
                                }
                            }
                            context.SaveChanges();
                            dbContextTransaction.Commit();

                            //Auditoria
                            string temp;
                            temp = string.Format("El usuario {0} ({1}) creó el {2} la  entidad.\nDatos actuales:\n{3} ", NombreUsuario, ArtMusicaUsuarioId, DateTime.Now, "ART_MUSICA_ENTIDAD_PRODUCCION");
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.AppendLine(temp);
                            ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.Entidades.ToString(), IpUsuario = strIP, RegistroId = intEntidadId, UsuarioId = ArtMusicaUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Creación" };

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

        public static void ActualizarEntidad(int EntidadId,
                                            int ArtMusicaUsuarioId,
                                            string Nombre,
                                            int Nit,
                                            int DigitoVerificacion,
                                            int codigoPais,
                                            string codigoMunicipio,
                                            string codigoDepartamento,
                                            string Direccion,
                                            string CorreoElectronico,
                                            string Telefono,
                                            string linkPortafolio,
                                            byte[] imagen,
                                            string descripcion,
                                            string Naturaleza,
                                            string[] TipoEntidad,
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
                            var entidad = context.ART_MUSICA_ENTIDADES.Where(x => x.Id == EntidadId).FirstOrDefault();

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
                                if (DigitoVerificacion > 0)
                                    entidad.DigitoVerificacion = DigitoVerificacion;

                                entidad.Direccion = entidad.Direccion;
                                entidad.FechaActualizacion = DateTime.Now;
                                entidad.LinkPortafolio = linkPortafolio;
                                entidad.Nit = Nit;
                                entidad.Nombre = Nombre;
                                entidad.Telefono = Telefono;
                                entidad.Naturaleza = Naturaleza;

                                if (imagen != null)
                                    entidad.Imagen = imagen;

                            }

                        

                            if (TipoEntidad != null)
                            {
                                EliminarTipoEntidadPorEntidadId(EntidadId);
                                foreach (var item in TipoEntidad)
                                {
                                    int Valor = Convert.ToInt32(item);
                                    var vartipoentidad = new ART_MUSICA_ENTIDAD_TIPOENTIDAD
                                    {
                                        EntidadId = EntidadId,
                                        TipoEntidadId = Valor,
                                    };
                                    context.ART_MUSICA_ENTIDAD_TIPOENTIDAD.Add(vartipoentidad);

                                }
                            }
                            context.SaveChanges();
                            dbContextTransaction.Commit();

                            //Auditoria
                            string temp;
                            temp = string.Format("El usuario {0} ({1}) actualizó el {2} la  entidad.\nDatos actuales:\n{3} ", NombreUsuario, ArtMusicaUsuarioId, DateTime.Now, entidad);
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.AppendLine(temp);
                            ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.Entidades.ToString(), IpUsuario = strIP, RegistroId = EntidadId, UsuarioId = ArtMusicaUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Actualización" };

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

        public static void ActualizarEntidadEstado(int EntidadId,
                                           int ArtMusicaUsuarioId,
                                           string Nombre,
                                           int Nit,
                                           int DigitoVerificacion,
                                           int codigoPais,
                                           string codigoMunicipio,
                                           string codigoDepartamento,
                                           string Direccion,
                                           string CorreoElectronico,
                                           string Telefono,
                                           string linkPortafolio,
                                           byte[] imagen,
                                           string descripcion,
                                           string Naturaleza,
                                           int EstadoId,
                                            string[] TipoEntidad,
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
                            var entidad = context.ART_MUSICA_ENTIDADES.Where(x => x.Id == EntidadId).FirstOrDefault();

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
                                if (DigitoVerificacion > 0)
                                    entidad.DigitoVerificacion = DigitoVerificacion;

                                entidad.Naturaleza = Naturaleza;
                                entidad.Direccion = Direccion;
                                entidad.FechaActualizacion = DateTime.Now;
                                entidad.LinkPortafolio = linkPortafolio;
                                entidad.Nit = Nit;
                                entidad.Nombre = Nombre;
                                entidad.Telefono = Telefono;

                                if (imagen != null)
                                    entidad.Imagen = imagen;

                            }

                            if (TipoEntidad != null)
                            {
                                EliminarTipoEntidadPorEntidadId(EntidadId);
                                foreach (var item in TipoEntidad)
                                {
                                    int Valor = Convert.ToInt32(item);
                                    var vartipoentidad = new ART_MUSICA_ENTIDAD_TIPOENTIDAD
                                    {
                                        EntidadId = EntidadId,
                                        TipoEntidadId = Valor,
                                    };
                                    context.ART_MUSICA_ENTIDAD_TIPOENTIDAD.Add(vartipoentidad);

                                }
                            }
                            context.SaveChanges();
                            dbContextTransaction.Commit();

                            //Auditoria
                            string temp;
                            temp = string.Format("El usuario {0} ({1}) actualizó el {2} la  entidad.\nDatos actuales:\n{3} ", NombreUsuario, ArtMusicaUsuarioId, DateTime.Now, entidad);
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.AppendLine(temp);
                            ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.Entidades.ToString(), IpUsuario = strIP, RegistroId = EntidadId, UsuarioId = ArtMusicaUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Actualización aprobación" };

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

        public static bool ExisteNit(int numero)
        {
            var model = new ART_MUSICA_ENTIDADES();
            bool respuesta = false;

            try
            {
                using (var context = new SIPAEntities())
                {
                    model = context.ART_MUSICA_ENTIDADES.Where(x => x.Nit == numero ).FirstOrDefault();

                }
                if (model != null && model.Id > 1)
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
        public static void EliminarTipoEntidadPorEntidadId(int EntidadId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_ENTIDAD_TIPOENTIDAD.RemoveRange(context.ART_MUSICA_ENTIDAD_TIPOENTIDAD.Where(x => x.EntidadId == EntidadId));
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
      


        public static void EliminarEntidad(int EntidadId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_ENTIDADES.Remove(context.ART_MUSICA_ENTIDADES.Where(x => x.Id == EntidadId).FirstOrDefault());
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Consultas

        public static ART_MUSICA_ENTIDADES ConsultarEntidadPorId(int EntidadId)
        {
            var entidad = new ART_MUSICA_ENTIDADES();
            try
            {
                using (var context = new SIPAEntities())
                {

                    entidad = context.ART_MUSICA_ENTIDADES.Where(x => x.Id == EntidadId).FirstOrDefault();

                }
                return entidad;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static EntidadResultadoDTO ConsultarDatosEntidadPorId(int Id)
        {

            EntidadResultadoDTO listEntidad = new EntidadResultadoDTO();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listEntidad = context.Database.SqlQuery<EntidadResultadoDTO>(@"EXEC ART_MUSICA_ENTIDADES_Id @EntidadId", new SqlParameter("EntidadId", Id)).FirstOrDefault();

                }
                return listEntidad;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public static List<EntidadDatosNuevoDTO> ConsultarEntidadTodos()
        {

            List<EntidadDatosNuevoDTO> listEntidad = new List<EntidadDatosNuevoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listEntidad = context.Database.SqlQuery<EntidadDatosNuevoDTO>(@"EXEC ART_MUSICA_ENTIDADES_Todos_NUEVO").ToList();


                }
                return listEntidad;

            }
            catch (Exception)
            {
                throw;
            }
        }

        
        public static List<EntidadResultadoDTO> ConsultarEntidadPorUsuarioId(int UsuarioId)
        {

            List<EntidadResultadoDTO> listEntidad = new List<EntidadResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    var paramUsuarioID = new SqlParameter
                    {
                        ParameterName = "UsuarioId",
                        Value = UsuarioId,
                        SqlDbType = System.Data.SqlDbType.Int
                    };

                    listEntidad = context.Database.SqlQuery<EntidadResultadoDTO>(@"EXEC ART_MUSICA_ENTIDADES_POR_USUARIOID @UsuarioId", paramUsuarioID).ToList();




                }
                return listEntidad;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public static List<EntidadDatosNuevoDTO> ConsultarEntidadPorMunicipio(int UsuarioId)
        {

            List<EntidadDatosNuevoDTO> listEntidad = new List<EntidadDatosNuevoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listEntidad = context.Database.SqlQuery<EntidadDatosNuevoDTO>(@"EXEC ART_MUSICA_ENTIDADES_POR_DEPARTAMENTO_NUEVO @UsuarioId", new SqlParameter("UsuarioId", UsuarioId)).ToList();




                }
                return listEntidad;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<EntidadResultadoDTO> ConsultarEntidadPorEstado(int EstadoId)
        {

            List<EntidadResultadoDTO> listEntidad = new List<EntidadResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listEntidad = context.Database.SqlQuery<EntidadResultadoDTO>(@"EXEC ART_MUSICA_ENTIDADES_POR_ESTADOID @estadoId", new SqlParameter("estadoId", EstadoId)).ToList();




                }
                return listEntidad;

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
