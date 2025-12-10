using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SM.Datos.Administrar
{
    /// <summary>
    /// Clase de datos para crear, consultar, editar usuarios.
    /// </summary>
    public class UsuarioManager
    {
        public List<ADM_USUARIOS> GetUsuario()
        {
            List<ADM_USUARIOS> listUsuario = new List<ADM_USUARIOS>();
            try
            {
                
                using (var db = new SIPAEntities())
                {
                    listUsuario = db.ADM_USUARIOS.ToList();
                }
            }
            catch (Exception)
            { throw; }
            return listUsuario;
        }

        public static ADM_USUARIOS ValidarUsuario(string usuario, string contrasena)
        {
            try
            {
                ADM_USUARIOS admUsuario = new ADM_USUARIOS();
                using (var db = new SIPAEntities())
                {
                    admUsuario = (from u in db.ADM_USUARIOS
                                  where (u.USU_USUARIO == usuario)
                                  where (u.USU_CLAVE == contrasena)
                                  select u).FirstOrDefault();
                }
                return admUsuario;
            }
            catch(Exception)
            { throw; }
        }
    }
}
