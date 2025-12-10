using SM.LibreriaComun.DTO;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Aplicacion.Perfil
{
    public class ServicioPerfil
    {
        public const string RECURSO_PAGINA = "PAGINA";
        public const string RECURSO_MENU = "MENU";



        public static RolDTO obtnerRolporId(int IdRol)
        {

            ART_MUSICA_ROL objroldb = SM.Datos.Perfiles.ServicioPerfil.obtenerRolporId(IdRol);
            RolDTO objRolDTO = null;
            if (objroldb != null)
            {
                objRolDTO = new RolDTO();
                objRolDTO.codigo = objroldb.Codigo;
                objRolDTO.nombre = objroldb.Nombre;
                objRolDTO.id = objroldb.Id;
            }

            return objRolDTO;

        }

        /// <summary>
        /// Crear nuevo rol
        /// </summary>
        /// <param name="objRol"></param>
        /// <returns></returns>
        public static bool crearRol(RolDTO objRol, List<int> lstRec, int UsuarioId, string NombreUsuario, string strIP)
        {
            ART_MUSICA_ROL objNewRol = new ART_MUSICA_ROL();
            objNewRol.Nombre = objRol.nombre;
            objNewRol.Codigo = objRol.codigo;
            objNewRol.FechaCreacion = DateTime.Now;
            bool respuesta = SM.Datos.Perfiles.ServicioPerfil.crearRol(objNewRol, UsuarioId, NombreUsuario, strIP);
            ART_MUSICA_RECURSO objrec = null;


            foreach (var inew in lstRec)
            {
                objrec = SM.Datos.Usuario.ServicioRecurso.obtenerRecporId(inew);

                SM.Datos.Usuario.ServicioRecurso.resgistrarRecuersoRol(objNewRol, objrec);
            }

            return respuesta;
        }

        public static bool ModificarRol(RolDTO objRol, List<int> lstRec, int UsuarioId, string NombreUsuario, string strIP)
        {
            ART_MUSICA_ROL objNewRol = new ART_MUSICA_ROL();
            objNewRol.Nombre = objRol.nombre;
            objNewRol.Codigo = objRol.codigo;
            objNewRol.Id = objRol.id;
            //permite  realizar la modificacion

            bool respuesta = SM.Datos.Perfiles.ServicioPerfil.ModificarRol(objNewRol, UsuarioId, NombreUsuario, strIP);
            ART_MUSICA_RECURSO objrec = null;

            SM.Datos.Usuario.ServicioRecurso.EliminarOpcionesRol(objRol.id);
            foreach (var inew in lstRec)
            {
                objrec = SM.Datos.Usuario.ServicioRecurso.obtenerRecporId(inew);

                SM.Datos.Usuario.ServicioRecurso.resgistrarRecuersoRol(objNewRol, objrec);
            }

            return respuesta;
        }

        /// <summary>
        /// existe el codigo del rol
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public static bool existeCodRol(string codigo)
        {

            return SM.Datos.Perfiles.ServicioPerfil.existeCodigoRol(codigo);
        }


        public static List<RecursoDTO> ObtenerOpciones()
        {
            try
            {
                List<ART_MUSICA_RECURSO> lstOpcionesentity = SM.Datos.Perfiles.ServicioPerfil.ObtenerOpciones();
                List<RecursoDTO> opciones = new List<RecursoDTO>();
                foreach (ART_MUSICA_RECURSO recurso in lstOpcionesentity)
                {
                    RecursoDTO opcion = new RecursoDTO();
                    opcion.rec_id_padre = Convert.ToInt32(recurso.IdPadre);
                    opcion.id = recurso.Id;
                    opcion.rec_nombre = recurso.Nombre;
                    opcion.rec_tipo = recurso.Tipo;
                    opciones.Add(opcion);
                }
                return opciones;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdMenu"></param>
        /// <returns></returns>
        public static List<RecursoDTO> consultarOpcionesMenu(int IdMenu)
        {
            List<RecursoDTO> lstOpciones = null;
            var tab = SM.Datos.Perfiles.ServicioPerfil.ObtenerMenuOpcionesporIdpadre(IdMenu);
            if (tab != null)
            {
                lstOpciones = new List<RecursoDTO>();
                foreach (ART_MUSICA_RECURSO recurso in tab)
                {
                    RecursoDTO recursoDto = new RecursoDTO();
                    recursoDto.codigo = recurso.Codigo;
                    recursoDto.rec_descripcion = recurso.Descripcion;
                    recursoDto.rec_estado = recurso.Estado ?? false;
                    recursoDto.rec_nombre = recurso.Nombre;
                    recursoDto.id = recurso.Id;
                    recursoDto.rec_id_padre = recurso.IdPadre ?? 0;
                    recursoDto.rec_ruta = recurso.Ruta;
                    recursoDto.rec_tipo = recurso.Tipo;
                    recursoDto.rec_titulo = recurso.Titulo;
                    recursoDto.rec_estilo = recurso.estilo;
                    recursoDto.opciones = null;

                    lstOpciones.Add(recursoDto);
                }
            }
            return lstOpciones;
        }

        public static List<RecursoDTO> consultarOpcionesMenuTodos(int IdMenu)
        {
            List<RecursoDTO> lstOpciones = null;
            var tab = SM.Datos.Perfiles.ServicioPerfil.ObtenerMenuOpcionesporTodosIdpadre(IdMenu);
            if (tab != null)
            {
                lstOpciones = new List<RecursoDTO>();
                foreach (ART_MUSICA_RECURSO recurso in tab)
                {
                    RecursoDTO recursoDto = new RecursoDTO();
                    recursoDto.codigo = recurso.Codigo;
                    recursoDto.rec_descripcion = recurso.Descripcion;
                    recursoDto.rec_estado = recurso.Estado ?? false;
                    recursoDto.rec_nombre = recurso.Nombre;
                    recursoDto.id = recurso.Id;
                    recursoDto.rec_id_padre = recurso.IdPadre ?? 0;
                    recursoDto.rec_ruta = recurso.Ruta;
                    recursoDto.rec_tipo = recurso.Tipo;
                    recursoDto.rec_titulo = recurso.Titulo;
                    recursoDto.rec_estilo = recurso.estilo;
                    recursoDto.opciones = null;

                    lstOpciones.Add(recursoDto);
                }
            }
            return lstOpciones;
        }


        public static List<RecursoDTO> consultarOpcionesMenuporRol(int IdMenu, int idrol)
        {
            List<RecursoDTO> lstOpciones = null;
            var tab = SM.Datos.Perfiles.ServicioPerfil.ObtenerMenuOpcionesporIdpadreporRol(IdMenu, idrol);
            if (tab != null)
            {
                lstOpciones = new List<RecursoDTO>();
                foreach (ART_MUSICA_RECURSO recurso in tab)
                {
                    RecursoDTO recursoDto = new RecursoDTO();
                    recursoDto.codigo = recurso.Codigo;
                    recursoDto.rec_descripcion = recurso.Descripcion;
                    recursoDto.rec_estado = recurso.Estado ?? false;
                    recursoDto.rec_nombre = recurso.Nombre;
                    recursoDto.id = recurso.Id;
                    recursoDto.rec_id_padre = recurso.IdPadre ?? 0;
                    recursoDto.rec_ruta = recurso.Ruta;
                    recursoDto.rec_tipo = recurso.Tipo;
                    recursoDto.rec_titulo = recurso.Titulo;
                    recursoDto.rec_estilo = recurso.estilo;
                    recursoDto.opciones = null;

                    lstOpciones.Add(recursoDto);
                }
            }
            return lstOpciones;
        }



        public static List<RecursoDTO> consultarOpcionesporRol(int IdRol)
        {
            List<RecursoDTO> lstOpciones = new List<RecursoDTO>();
            var tab = SM.Datos.Usuario.ServicioRecurso.ObtenerMenu(IdRol);

            foreach (ART_MUSICA_RECURSO recurso in tab)
            {
                RecursoDTO recursoDto = new RecursoDTO();
                recursoDto.codigo = recurso.Codigo;
                recursoDto.rec_descripcion = recurso.Descripcion;
                recursoDto.rec_estado = Convert.ToBoolean(recurso.Estado);
                recursoDto.rec_nombre = recurso.Nombre;
                recursoDto.id = recurso.Id;
                recursoDto.rec_id_padre = recurso.IdPadre ?? 0;
                recursoDto.rec_ruta = recurso.Ruta;
                recursoDto.rec_tipo = recurso.Tipo;
                recursoDto.rec_titulo = recurso.Titulo;
                recursoDto.rec_estilo = recurso.estilo;
                if (recursoDto.rec_id_padre != null)
                {
                    int idpadre = int.Parse(recursoDto.rec_id_padre.ToString());
                    recursoDto.opciones = consultarOpcionesMenu(idpadre);
                }

                lstOpciones.Add(recursoDto);
            }
            return lstOpciones;
        }


        public static List<RecursoDTO> consultarOpcionesporRolModificar(int IdRol)
        {
            List<RecursoDTO> lstOpciones = new List<RecursoDTO>();
            var tabaplicados = SM.Datos.Usuario.ServicioRecurso.ObtenerMenu(IdRol);
            var tabtotales = SM.Datos.Perfiles.ServicioPerfil.ObtenertodosMenuTodosPadre();

            foreach (ART_MUSICA_RECURSO recurso in tabtotales)
            {
                RecursoDTO recursoDto = new RecursoDTO();
                if (tabaplicados.Exists(x => x.Id == recurso.Id))
                {
                    recursoDto.aplica = true;
                }

                recursoDto.codigo = recurso.Codigo;
                recursoDto.rec_descripcion = recurso.Descripcion;
                recursoDto.rec_estado = Convert.ToBoolean(recurso.Estado);
                recursoDto.rec_nombre = recurso.Nombre;
                recursoDto.id = recurso.Id;
                recursoDto.rec_id_padre = recurso.IdPadre ?? 0;
                recursoDto.rec_ruta = recurso.Ruta;
                recursoDto.rec_tipo = recurso.Tipo;
                recursoDto.rec_titulo = recurso.Titulo;
                recursoDto.rec_estilo = recurso.estilo;
                var pagRol = consultarOpcionesMenuporRol(recursoDto.id, IdRol);
                recursoDto.opciones = consultarOpcionesMenuTodos(recursoDto.id);// traemos aus hijos
                foreach (var pag in recursoDto.opciones)
                {
                    if (pagRol.Exists(x => x.id == pag.id))
                    {
                        pag.aplica = true;
                    }
                }

                lstOpciones.Add(recursoDto);
            }
            return lstOpciones;
        }
        /// <summary>
        /// Recuerso menu y paginas existentes
        /// </summary>
        /// <returns></returns>
        public static List<RecursoDTO> consultarOpcionesTodosMenu()
        {
            List<RecursoDTO> lstMenu = new List<RecursoDTO>();
            List<ART_MUSICA_RECURSO> tab = new List<ART_MUSICA_RECURSO>();

            tab = SM.Datos.Perfiles.ServicioPerfil.ObtenertodosMenuPadre();


            if (tab != null)
            {
                foreach (ART_MUSICA_RECURSO recurso in tab)
                {
                    RecursoDTO recursoDto = new RecursoDTO();
                    recursoDto.codigo = recurso.Codigo;
                    recursoDto.rec_descripcion = recurso.Descripcion;
                    recursoDto.rec_estado = recurso.Estado ?? false;
                    recursoDto.rec_nombre = recurso.Nombre;
                    recursoDto.id = recurso.Id;
                    recursoDto.rec_id_padre = recurso.IdPadre ?? 0;
                    recursoDto.rec_ruta = recurso.Ruta;
                    recursoDto.rec_tipo = recurso.Tipo;
                    recursoDto.rec_tipo_nombre = RECURSO_PAGINA;

                    recursoDto.rec_titulo = recurso.Titulo;
                    recursoDto.rec_estilo = recurso.estilo;
                    recursoDto.opciones = new List<RecursoDTO>();
                    recursoDto.opciones = consultarOpcionesMenu(recurso.Id);
                    lstMenu.Add(recursoDto);
                }

            }



            return lstMenu;
        }







        /// <summary>
        /// Obetnermo los roles existentes
        /// </summary>
        /// <returns></returns>
        public static List<RolDTO> obtenerRoles()
        {
            List<SM.SIPA.ART_MUSICA_ROL> lstRoles = SM.Datos.Perfiles.ServicioPerfil.obtenerRoles();
            List<RolDTO> lstRolDTO = new List<RolDTO>();
            RolDTO objRol = null;
            foreach (var i in lstRoles)
            {
                objRol = new RolDTO();
                objRol.id = i.Id;
                objRol.nombre = i.Nombre;
                objRol.codigo = i.Codigo;

                objRol.fecha = (DateTime)i.FechaCreacion;
                lstRolDTO.Add(objRol);
                objRol = null;
            }
            return lstRolDTO;
        }
        /// <summary>
        /// buscamos todos los roles e indicamos cual existe
        /// </summary>
        /// <param name="idSeleccionados"></param>
        /// <returns></returns>
        public static List<RolDTO> obtenerRoles(List<int> idSeleccionados)
        {
            List<SM.SIPA.ART_MUSICA_ROL> lstRoles = SM.Datos.Perfiles.ServicioPerfil.obtenerRoles();
            List<RolDTO> lstRolDTO = new List<RolDTO>();
            RolDTO objRol = null;
            foreach (var i in lstRoles)
            {
                objRol = new RolDTO();


                objRol.id = i.Id;
                objRol.nombre = i.Nombre;
                objRol.codigo = i.Codigo;

                if (idSeleccionados.Exists(x => x.Equals(objRol.id)))
                {
                    objRol.esescogido = true;
                }

                objRol.fecha = (DateTime)i.FechaCreacion;
                lstRolDTO.Add(objRol);
                objRol = null;
            }
            return lstRolDTO;
        }





        public static List<RolDTO> obtenerRolporIdUser(int idUser)
        {
            List<SM.SIPA.ART_MUSICA_ROL> objRol = SM.Datos.Perfiles.ServicioPerfil.obtenerRolporIdUser(idUser);
            List<RolDTO> objRolDTO = null;

            if (objRol != null)
            {
                objRolDTO = new List<RolDTO>();

                foreach (SM.SIPA.ART_MUSICA_ROL i in objRol)
                {
                    RolDTO ojDTO = new RolDTO();
                    ojDTO.codigo = i.Codigo;
                    ojDTO.id = i.Id;
                    ojDTO.nombre = i.Nombre;
                    ojDTO.fecha = (DateTime)i.FechaCreacion;
                    //add
                    objRolDTO.Add(ojDTO);

                }





            }
            return objRolDTO;
        }

        /// <summary>
        /// actualizamos el rol que pertenece el usuario
        /// </summary>
        /// <param name="IdUser"></param>
        /// <param name="IdRol"></param>
        /// <returns></returns>
        public static bool actualizarUsuarioRol(int IdUser, List<int> IdRol,  string NombreUsuario, int UsuarioId, string strIP)
        {

            SM.Datos.Perfiles.ServicioPerfil.LimpiarUsuarioRol(IdUser);
            foreach (var i in IdRol)
            {
                SM.Datos.Perfiles.ServicioPerfil.actualizarUsuarioRol(IdUser, i, NombreUsuario, UsuarioId, strIP);
            }
            return true;
        }






    }
}
