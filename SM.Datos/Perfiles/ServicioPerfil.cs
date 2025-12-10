using SM.Datos.AuditoriaData;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.Perfiles
{
    public class ServicioPerfil
    {
        public const string PERRFIL_STANDARD = "STANDARD";
        /// <summary>
        /// Obtenemos lista de perfil asociado a un usuario
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public static List<SM.SIPA.ART_MUSICA_USUARIO_ROL> PerfilUsuario(decimal idUser)
        {
            List<ART_MUSICA_USUARIO_ROL> ListPerfil = new List<ART_MUSICA_USUARIO_ROL>();

            try
            {
                using (var context = new SIPAEntities())
                {
                    ListPerfil = (from p in context.ART_MUSICA_USUARIO_ROL where p.ART_MUSICA_USUARIO.Id == idUser select p).ToList();

                }


            }
            catch (Exception)
            {
                throw;
            }

            return ListPerfil;
        }


        public static List<int> obtenerIdRol(decimal idUser)
        {
            List<ART_MUSICA_USUARIO_ROL> LstPerfil = null;
            List<int> respuesta = null;

            try
            {
                using (var context = new SIPAEntities())
                {
                    LstPerfil = (from p in context.ART_MUSICA_USUARIO_ROL where p.ART_MUSICA_USUARIO.Id == idUser select p).ToList();

                }
                if (LstPerfil != null)
                {
                    respuesta = new List<int>();
                    foreach (var i in LstPerfil)
                    {
                        respuesta.Add(i.RoleId ?? 0);
                    }

                }



            }
            catch (Exception)
            {
                throw;
            }

            return respuesta;
        }



        public static List<SM.SIPA.ART_MUSICA_ROL> obtenerRoles()
        {
            List<ART_MUSICA_ROL> lstRol = new List<ART_MUSICA_ROL>();
            using (var context = new SIPAEntities())
            {
                lstRol = (from p in context.ART_MUSICA_ROL orderby p.Nombre ascending select p).ToList();

            }

            return lstRol;

        }

        /// <summary>
        /// Obtenemos Rol por Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static SM.SIPA.ART_MUSICA_ROL obtenerRolporId(int Id)
        {
            ART_MUSICA_ROL objroldb = new ART_MUSICA_ROL();
            using (var context = new SIPAEntities())
            {
                objroldb = (from p in context.ART_MUSICA_ROL.Where(x => x.Id == Id) select p).SingleOrDefault();

            }

            return objroldb;

        }


        public static List<ART_MUSICA_RECURSO> ObtenerOpcionesRol(string nombreRol)
        {
            List<ART_MUSICA_RECURSO> lstOpciones = new List<ART_MUSICA_RECURSO>();
            using (SIPAEntities db = new SIPAEntities())
            {


                lstOpciones = (from p in db.ART_MUSICA_ROL_RECURSO
                               join r in db.ART_MUSICA_RECURSO on p.RecId equals r.Id
                               join rl in db.ART_MUSICA_ROL on p.RolId equals rl.Id
                               where (rl.Nombre == nombreRol)
                               select p.ART_MUSICA_RECURSO).ToList();

            }
            return lstOpciones;
        }



        public static ART_MUSICA_ROL obtenerRolDefault()
        {
            ART_MUSICA_ROL objRol = null;
            try
            {
                using (var context = new SIPAEntities())
                {
                    objRol = (from p in context.ART_MUSICA_ROL.Where(x => x.Codigo == PERRFIL_STANDARD) select p).SingleOrDefault();

                }
            }
            catch (Exception)
            {

            }
            return objRol;
        }

       
        public static bool adicionarUsuarioaRol(ART_MUSICA_USUARIO_ROL objUserRol, string strIP)
        {
            bool respuesta = false;
            string strNombreUsuario = objUserRol.ART_MUSICA_USUARIO.PrimerNombre + " " + objUserRol.ART_MUSICA_USUARIO.PrimerApellido;
          
            try
            {
                using (var context = new SIPAEntities())
                {
                    var nuevoAcoiacion = new ART_MUSICA_USUARIO_ROL();
                                      
                    nuevoAcoiacion.RoleId = objUserRol.ART_MUSICA_ROL.Id;
                    nuevoAcoiacion.UserId = objUserRol.ART_MUSICA_USUARIO.Id;
                    context.ART_MUSICA_USUARIO_ROL.Add(nuevoAcoiacion);

                    context.SaveChanges();
                    //Auditoria
                    string temp;
                    temp = string.Format("El usuario {0} ({1}) adicionar el {2} rol al usuario.\nDatos actuales:\n{3} ", strNombreUsuario, objUserRol.ART_MUSICA_USUARIO.Id, DateTime.Now, nuevoAcoiacion);
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine(temp);
                    ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.Roles.ToString(), IpUsuario = strIP, RegistroId = nuevoAcoiacion.Id, UsuarioId = objUserRol.ART_MUSICA_USUARIO.Id, NombreUsuario = strNombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Adicionar Rol Usuario" };

                    RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                    auditoria.Crear(registroOperacion);

                }
                respuesta = true;

            }
            catch (Exception)
            {
                respuesta = false;
            }
            return respuesta;

        }

        /// <summary>
        /// Crear rol
        /// </summary>
        /// <param name="ojbNew"></param>
        /// <returns></returns>
        public static bool crearRol(ART_MUSICA_ROL ojbNew, int UsuarioId, string NombreUsuario, string strIP)
        {
            bool respuesta = false;

            try
            {
                using (var context = new SIPAEntities())
                {
                    var objnew = new ART_MUSICA_ROL();
                    objnew.FechaCreacion = DateTime.Now;
                    objnew.Codigo = ojbNew.Codigo;
                    objnew.Nombre = ojbNew.Nombre;

                    context.ART_MUSICA_ROL.Add(objnew);

                    context.SaveChanges();
                    ojbNew.Id = objnew.Id;

                    //Auditoria
                    string temp;
                    temp = string.Format("El usuario {0} ({1}) creó el {2} al rol.\nDatos actuales:\n{3} ", NombreUsuario, UsuarioId, DateTime.Now, objnew);
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine(temp);
                    ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.Roles.ToString(), IpUsuario = strIP, RegistroId = ojbNew.Id, UsuarioId = UsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Creación" };


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


        public static bool ModificarRol(ART_MUSICA_ROL ojbNew, int UsuarioId, string NombreUsuario, string strIP)
        {
            bool respuesta = false;

            try
            {

                using (var context = new SIPAEntities())
                {
                    var rorl = context.ART_MUSICA_ROL.Where(b => b.Id == ojbNew.Id).FirstOrDefault();
                    ojbNew.FechaCreacion = rorl.FechaCreacion;
                    context.Entry(rorl).CurrentValues.SetValues(ojbNew);
                    context.SaveChanges();

                    //Auditoria
                    string temp;
                    temp = string.Format("El usuario {0} ({1}) actualizó el {2} al rol.\nDatos actuales:\n{3} ", NombreUsuario, UsuarioId, DateTime.Now, ojbNew);
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine(temp);
                    ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.Roles.ToString(), IpUsuario = strIP, RegistroId = ojbNew.Id, UsuarioId = UsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Actualización" };

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



        //Fix Actualización de Rol

        public static bool actualizarUsuarioRol(int IdUser, int IdRol, string NombreUsuario, int UsuarioId, string strIP)
        {
            bool respuesta = false;
           
            try
            {
                using (var context = new SIPAEntities())
                {
                    ART_MUSICA_USUARIO_ROL ObjModifi = new ART_MUSICA_USUARIO_ROL();


                    var objRolNuevo = (from p in context.ART_MUSICA_ROL.Where(x => x.Id == IdRol) select p).SingleOrDefault();
                    ObjModifi.ART_MUSICA_ROL = objRolNuevo;
                    var objUserNew = (from p in context.ART_MUSICA_USUARIO.Where(e => e.Id == IdUser) select p).SingleOrDefault();
                    ObjModifi.ART_MUSICA_USUARIO = objUserNew;
                    context.ART_MUSICA_USUARIO_ROL.Add(ObjModifi);
                    context.SaveChanges();

                    //Auditoria
                    string temp;
                    temp = string.Format("El usuario {0} ({1}) actualizó el {2} el usuario rol {4}.\nDatos actuales:\n{3} ", NombreUsuario, UsuarioId, DateTime.Now, ObjModifi, IdRol);
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine(temp);
                    ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.Roles.ToString(), IpUsuario = strIP, RegistroId = IdUser, UsuarioId = UsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Usuario actualizar rol" };

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
        /// limpiamos los permisos del user
        /// </summary>
        /// <param name="IdUser"></param>
        /// <returns></returns>
        public static bool LimpiarUsuarioRol(int IdUser)
        {
            bool respuesta = false;
            //nuevo rol
            //var objRolActual = obtenerRolporId(IdRol);
            try
            {
                using (var context = new SIPAEntities())
                {
                    ART_MUSICA_USUARIO_ROL ObjModifi = new ART_MUSICA_USUARIO_ROL();


                    //removembos el rol del usuario
                    var listuserRol = (from p in context.ART_MUSICA_USUARIO_ROL.Where(e => e.UserId == IdUser) select p).ToList();

                    foreach (var iremoeve in listuserRol)
                    {

                        context.ART_MUSICA_USUARIO_ROL.Remove(iremoeve);
                    }
                    //adicionamos el nuevo rol


                    context.SaveChanges();

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
        /// validamos si existe el codigo del rol
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public static bool existeCodigoRol(string codigo)
        {
            List<ART_MUSICA_ROL> objrol = null;
            bool respuesta = false;

            try
            {
                using (var context = new SIPAEntities())
                {
                    objrol = (from p in context.ART_MUSICA_ROL where p.Codigo == codigo select p).ToList();

                }
                if (objrol != null && objrol.Count > 0)
                {
                    respuesta = true;
                }



            }
            catch (Exception)
            {
                throw;
            }

            return respuesta;
        }


        /// <summary>
        /// Obtenemos las opciones existentes de recursos
        /// </summary>
        /// <returns></returns>
        public static List<ART_MUSICA_RECURSO> ObtenerOpciones()
        {
            List<ART_MUSICA_RECURSO> lstOpciones = new List<ART_MUSICA_RECURSO>();
            using (SIPAEntities db = new SIPAEntities())
            {


                lstOpciones = (from p in db.ART_MUSICA_RECURSO
                               orderby p.Tipo descending, p.IdPadre, p.Nombre
                               select p).ToList();

            }
            return lstOpciones;
        }



        public static List<ART_MUSICA_RECURSO> ObtenertodosMenuPadre()
        {
            List<ART_MUSICA_RECURSO> listMenu = new List<ART_MUSICA_RECURSO>();
            using (SIPAEntities db = new SIPAEntities())
            {

                listMenu = (from p in db.ART_MUSICA_RECURSO.Where(p => p.Tipo == "MENU")
                            orderby p.Nombre ascending
                            select p).ToList();


            }
            return listMenu;
        }

        public static List<ART_MUSICA_RECURSO> ObtenertodosMenuTodosPadre()
        {
            List<ART_MUSICA_RECURSO> listMenu = new List<ART_MUSICA_RECURSO>();
            using (SIPAEntities db = new SIPAEntities())
            {

                listMenu = (from r in db.ART_MUSICA_RECURSO
                            where (r.Tipo == "MENU")
                            orderby r.Nombre ascending
                            select r).ToList();


            }
            return listMenu;
        }





        public static List<ART_MUSICA_RECURSO> ObtenerMenuOpcionesporIdpadre(int idPadre)
        {
            List<ART_MUSICA_RECURSO> listMenu = new List<ART_MUSICA_RECURSO>();
            using (SIPAEntities db = new SIPAEntities())
            {


                listMenu = (from p in db.ART_MUSICA_RECURSO.Where(r => r.IdPadre == idPadre && r.Tipo == "PAG")
                            orderby p.Nombre ascending
                            select p).ToList();

            }
            return listMenu;
        }


        public static List<ART_MUSICA_RECURSO> ObtenerMenuOpcionesporTodosIdpadre(int idPadre)
        {
            List<ART_MUSICA_RECURSO> listMenu = new List<ART_MUSICA_RECURSO>();
            using (SIPAEntities db = new SIPAEntities())
            {


                listMenu = (from r in db.ART_MUSICA_RECURSO
                            where (r.IdPadre == idPadre && r.Tipo == "PAG")
                            orderby r.Nombre descending
                            select r).ToList();

            }
            return listMenu;
        }
        /// <summary>
        /// Obtenermos la opcciones del menu por Rol
        /// </summary>
        /// <param name="idPadre"></param>
        /// <param name="idRol"></param>
        /// <returns></returns>
        public static List<ART_MUSICA_RECURSO> ObtenerMenuOpcionesporIdpadreporRol(int idPadre, int idRol)
        {
            List<ART_MUSICA_RECURSO> listMenu = new List<ART_MUSICA_RECURSO>();
            using (SIPAEntities db = new SIPAEntities())
            {


                listMenu = (from p in db.ART_MUSICA_ROL_RECURSO
                            join r in db.ART_MUSICA_RECURSO on p.RecId equals r.Id
                            where (r.IdPadre == idPadre && r.Tipo == "PAG" && p.RolId == idRol)
                            orderby r.Id
                            select p.ART_MUSICA_RECURSO).ToList();

            }
            return listMenu;
        }


        /// <summary>
        /// obtenemos el rol de un usuario
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>

        public static List<SM.SIPA.ART_MUSICA_ROL> obtenerRolporIdUser(int idUser)
        {
            List<SM.SIPA.ART_MUSICA_ROL> objRol = null;
            try
            {
                using (var context = new SIPAEntities())
                {
                    objRol = (from p in context.ART_MUSICA_USUARIO_ROL.Where(x => x.ART_MUSICA_USUARIO.Id == idUser) select p.ART_MUSICA_ROL).ToList<SM.SIPA.ART_MUSICA_ROL>();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return objRol;
        }

    }
}
