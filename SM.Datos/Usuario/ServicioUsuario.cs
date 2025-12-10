using System;
using SM.Datos.DTO;
using SM.SIPA;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.Datos.AuditoriaData;

namespace SM.Datos.Usuario
{
    public class ServicioUsuario
    {
        private const string SIMUS_MINCULTURA = "MINCULTURA";
        private const string SIMUS_USER = "SIMUS";
        private const string SIMUS_USER_G = "GOOGLE";
        private const string SIMUS_USER_F = "FACEBOOK";
        public static ART_MUSICA_USUARIO ObtenerUsuarioporIdRSS(string IdRSS)
        {
            var model = new ART_MUSICA_USUARIO();


            try
            {
                using (var context = new SIPAEntities())
                {
                    model = context.ART_MUSICA_USUARIO.Where(x => x.IdUserRSS == IdRSS).FirstOrDefault();

                }


            }
            catch (Exception)
            {
                throw;
            }

            return model;
        }

        public static ART_MUSICA_USUARIO ObtenerUsuarioporId(decimal IdUser)
        {
            var model = new ART_MUSICA_USUARIO();


            try
            {
                using (var context = new SIPAEntities())
                {
                    model = context.ART_MUSICA_USUARIO.Where(x => x.Id == IdUser).FirstOrDefault();

                }


            }
            catch (Exception)
            {
                throw;
            }

            return model;
        }

        public static List<SM.Datos.DTO.Parametro> ObtenerUsuarioSipaPorCorreo(string correo)
        {
            var listBasica = new List<SM.Datos.DTO.Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listBasica = (from u in context.ART_MUSICA_USUARIO
                                  join a in context.ADM_USUARIOS on u.Email equals a.USU_CORREO_ELECTRONICO
                                  where a.USU_CORREO_ELECTRONICO.Contains(correo.ToLower())
                                  select new Parametro
                               {
                                   Id = u.Id,
                                   PadreId = a.USU_ID,
                                   Nombre = a.USU_CORREO_ELECTRONICO
                               }).ToList();

                  
                }
                return listBasica;

            }
            catch (Exception)
            {
                throw;
            }
        }

      


        public static ART_MUSICA_USUARIO ObtenerUsuarioSimus(string email, string contraseña)
        {
            var model = new ART_MUSICA_USUARIO();


            try
            {
                using (var context = new SIPAEntities())
                {
                    model = context.ART_MUSICA_USUARIO.Where(x => x.Email.Equals(email)).FirstOrDefault();

                }

                if (model != null && model.Contraseña.Equals(contraseña))
                {
                    return model;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                throw;
            }


        }



        public static ART_MUSICA_USUARIO ObtenerUsuarioMinenSIMUS(string email)
        {
            var model = new ART_MUSICA_USUARIO();


            try
            {
                using (var context = new SIPAEntities())
                {
                    model = context.ART_MUSICA_USUARIO.Where(x => x.Email.Equals(email) && x.TipoRSS.Equals(SIMUS_MINCULTURA)).FirstOrDefault();

                }





            }
            catch (Exception)
            {
                throw;
            }

            return model;
        }

        public static ART_MUSICA_USUARIO ObtenerUsuarioSIMUS(string email, string tipoUser)
        {
            ART_MUSICA_USUARIO model = null;


            try
            {
                using (var context = new SIPAEntities())
                {
                    model = context.ART_MUSICA_USUARIO.Where(x => x.Email.Equals(email)).FirstOrDefault();



                }


            }
            catch (Exception)
            {
                model = null;
            }

            return model;
        }

        public static ART_MUSICA_USUARIO ObtenerUsuarioSIMUSPorUsuarioID(int UsuarioId)
        {
            ART_MUSICA_USUARIO model = null;


            try
            {
                using (var context = new SIPAEntities())
                {
                    model = context.ART_MUSICA_USUARIO.Where(x => x.Id.Equals(UsuarioId)).FirstOrDefault();



                }


            }
            catch (Exception)
            {
                model = null;
            }

            return model;
        }

        public static ART_MUSICA_USUARIO ObtenerUsuarioCelebra(string email)
        {
            ART_MUSICA_USUARIO model = null;


            try
            {
                using (var context = new SIPAEntities())
                {
                    model = context.ART_MUSICA_USUARIO.Where(x => x.Email.Equals(email)).FirstOrDefault();

                }


            }
            catch (Exception)
            {
                model = null;
            }

            return model;
        }

        public static List<UsuarioResultadoDTO> ObtenerUsuarioSIMUSNuevo()
        {
            List<UsuarioResultadoDTO> listResultado = null;


            try
            {
                using (var context = new SIPAEntities())
                {
                    listResultado = context.Database.SqlQuery<UsuarioResultadoDTO>(@"EXEC ART_MUSICA_OBTENER_USUARIOS").ToList();


                }


            }
            catch (Exception)
            {
                listResultado = null;
            }

            return listResultado;
        }

        public static List<ART_MUSICA_USUARIO> ObtenerUsuarioSIMUS()
        {
            List<ART_MUSICA_USUARIO> lstmodel = null;


            try
            {
                using (var context = new SIPAEntities())
                {
                    lstmodel = context.ART_MUSICA_USUARIO.ToList();

                }


            }
            catch (Exception)
            {
                lstmodel = null;
            }

            return lstmodel;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdRSS"></param>
        /// <returns></returns>
        public static bool existeUsuarioporIdRSS(string IdRSS)
        {
            var model = new ART_MUSICA_USUARIO();
            bool respuesta = false;

            try
            {
                using (var context = new SIPAEntities())
                {
                    model = context.ART_MUSICA_USUARIO.Where(x => x.IdUserRSS == IdRSS).FirstOrDefault();

                }
                if (model != null)
                {
                    respuesta = true;
                }

            }
            catch (Exception)
            {
                respuesta = true;
            }

            return respuesta;
        }


        public static bool existeUsuarioporCorreo(string correoElectronico)
        {
            var model = new ART_MUSICA_USUARIO();
            bool respuesta = false;

            try
            {
                using (var context = new SIPAEntities())
                {
                    model = context.ART_MUSICA_USUARIO.Where(x => x.Email.Equals(correoElectronico)).FirstOrDefault();

                }
                if (model != null && model.Id > 0)
                {
                    respuesta = true;
                }

            }
            catch (Exception)
            {
                respuesta = true;
            }

            return respuesta;
        }



        public static bool existenumeroTipoDoc(string numero, string codtipo)
        {
            var model = new ART_MUSICA_USUARIO();
            bool respuesta = false;

            try
            {
                using (var context = new SIPAEntities())
                {
                    model = context.ART_MUSICA_USUARIO.Where(x => x.Identificacion == numero && x.CodTipoDocumento == codtipo).FirstOrDefault();

                }
                if (model != null)
                {
                    respuesta = true;
                }

            }
            catch (Exception)
            {
                respuesta = true;
            }

            return respuesta;
        }




        /// <summary>
        /// Validamos si es usuario simus
        /// </summary>
        /// <param name="correoElectronico"></param>
        /// <returns></returns>
        public static bool existeUsuarioporCorreoSIMUS(string correoElectronico)
        {
            var model = new ART_MUSICA_USUARIO();
            bool respuesta = false;

            try
            {
                using (var context = new SIPAEntities())
                {
                    model = context.ART_MUSICA_USUARIO.Where(x => x.Email.Equals(correoElectronico) & x.TipoRSS.Equals(SIMUS_USER)).FirstOrDefault();

                }
                if (model != null)
                {
                    respuesta = true;
                }

            }
            catch (Exception)
            {
                respuesta = true;
            }

            return respuesta;
        }


        public static bool existeUsuarioporCorreoCelebra(string correoElectronico)
        {
            var model = new ART_MUSICA_USUARIO();
            bool respuesta = false;

            try
            {
                using (var context = new SIPAEntities())
                {
                    model = context.ART_MUSICA_USUARIO.Where(x => x.Email.Equals(correoElectronico)).FirstOrDefault();

                }
                if (model != null)
                {
                    respuesta = true;
                }

            }
            catch (Exception)
            {
                respuesta = true;
            }

            return respuesta;
        }
        public static bool existeUsuarioporCorreo(string correoElectronico, int Iduser)
        {
            var model = new ART_MUSICA_USUARIO();
            bool respuesta = false;

            try
            {
                using (var context = new SIPAEntities())
                {
                    model = context.ART_MUSICA_USUARIO.Where(x => x.Email.Equals(correoElectronico)).FirstOrDefault();

                }
                if (model != null && model.Id != Iduser)
                {
                    respuesta = true;
                }

            }
            catch (Exception)
            {
                respuesta = true;
            }

            return respuesta;
        }


      


        /// <summary>
        /// Crear Usuario
        /// </summary>
        /// <param name="objNewUser"></param>
        /// <returns></returns>
        public static bool crearUsuario(ART_MUSICA_USUARIO objNewUser, string strIP)
        {
            bool respuesta = false;

            try
            {
                string NombreUsuario = objNewUser.PrimerNombre + " " + objNewUser.PrimerApellido; 
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_USUARIO.Add(objNewUser);

                    context.SaveChanges();

                    //Auditoria
                    string temp;
                    temp = string.Format("El usuario {0} ({1}) actualizó el {2} al usuario.\nDatos actuales:\n{3} ", NombreUsuario, objNewUser.Id, DateTime.Now, objNewUser);
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine(temp);
                    ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.Usuario.ToString(), IpUsuario = strIP, RegistroId = objNewUser.Id, UsuarioId = objNewUser.Id, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Creación" };

                    RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                    auditoria.Crear(registroOperacion);

                }
                respuesta = true;

            }
            catch (Exception)
            {
                respuesta = true;
            }
            return respuesta;

        }
        /// <summary>
        /// Creamos el usuario sipa
        /// </summary>
        /// <param name="objSipa"></param>
        /// <returns></returns>
        public static decimal crearUsuarioSipa(ADM_USUARIOS objSipa)
        {
            decimal respuesta = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ADM_USUARIOS.Add(objSipa);

                    context.SaveChanges();

                }
                respuesta = objSipa.USU_ID;

            }
            catch (Exception)
            {
                respuesta = 0;
            }
            return respuesta;
        }

        public static decimal ModificarUsuarioSipa(ADM_USUARIOS objSipa)
        {
            decimal respuesta = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ADM_USUARIOS.Add(objSipa);

                    context.SaveChanges();

                }
                respuesta = objSipa.USU_ID;

            }
            catch (Exception)
            {
                respuesta = 0;
            }
            return respuesta;
        }


        public static ADM_USUARIOS obtnerUserSipa(decimal IduserSipa)
        {
            ADM_USUARIOS objUser = null;
            try
            {
                using (var context = new SIPAEntities())
                {
                    objUser = (from i in context.ADM_USUARIOS.Where(x => x.USU_ID == IduserSipa) select i).SingleOrDefault();



                }




            }
            catch (Exception)
            {
                objUser = null;
            }

            return objUser;
        }


        public static decimal obtenerUsuarioSipaxCorreo(string correoElectronico)
        {
            decimal IdUserSipa = 0;
            ADM_USUARIOS objUser = null;
            try
            {
                using (var context = new SIPAEntities())
                {
                    objUser = (from i in context.ADM_USUARIOS.Where(x => x.USU_CORREO_ELECTRONICO.Equals(correoElectronico)) select i).SingleOrDefault();



                }

                if (objUser != null && objUser.USU_ID != null)
                {
                    IdUserSipa = objUser.USU_ID;
                }


            }
            catch (Exception)
            {
                IdUserSipa = 0;
            }
            return IdUserSipa;
        }

        public static bool modificarUsuario(ART_MUSICA_USUARIO objNewUser, string strIP)
        {
            bool respuesta = false;
          

            try
            {
                string NombreUsuario = objNewUser.PrimerNombre + " " + objNewUser.PrimerApellido; 
                using (var context = new SIPAEntities())
                {

                    var usuario = context.ART_MUSICA_USUARIO.Where(b => b.Id == objNewUser.Id).FirstOrDefault();
                    context.Entry(usuario).CurrentValues.SetValues(objNewUser);
                    context.SaveChanges();

                    //Auditoria
                    string temp;
                    temp = string.Format("El usuario {0} ({1}) actualizó el {2} al rol.\nDatos actuales:\n{3} ", NombreUsuario, objNewUser.Id, DateTime.Now, objNewUser);
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine(temp);
                    ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.Usuario.ToString(), IpUsuario = strIP, RegistroId = objNewUser.Id, UsuarioId = objNewUser.Id, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Actualización" };

                    RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                    auditoria.Crear(registroOperacion);
                }
                respuesta = true;

            }
            catch (Exception)
            {
                respuesta = true;
            }
            return respuesta;

        }

    }
}
