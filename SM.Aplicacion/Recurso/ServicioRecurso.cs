using SM.LibreriaComun.DTO;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Aplicacion.Recurso
{
    public class ServicioRecurso
    {
        public const string RECURSO_PAGINA = "PAG";
        public const string RECURSO_MENU = "MENU";




        public static RecursoDTO ObtenerRecurso(int id)
        {
            ART_MUSICA_RECURSO obRecurso = SM.Datos.Recurso.ServicioRecurso.ObtenerRecurso(id);
            RecursoDTO recursoDto = null;
            if (obRecurso != null)
            {
                recursoDto = new RecursoDTO();
                recursoDto.codigo = obRecurso.Codigo;
                recursoDto.rec_descripcion = obRecurso.Descripcion;
                recursoDto.rec_estado = obRecurso.Estado ?? false;
                recursoDto.rec_nombre = obRecurso.Nombre;
                recursoDto.id = obRecurso.Id;
                recursoDto.rec_id_padre = obRecurso.IdPadre ?? 0;
                recursoDto.rec_ruta = obRecurso.Ruta;
                recursoDto.rec_tipo = obRecurso.Tipo;
                // recursoDto.fechacreacion = recurso.;

                recursoDto.rec_tipo_nombre = RECURSO_PAGINA;
                if (obRecurso.Tipo == RECURSO_MENU) recursoDto.rec_tipo_nombre = RECURSO_MENU;

                if (recursoDto.rec_id_padre > 0)
                {
                    ART_MUSICA_RECURSO objpadre = SM.Datos.Recurso.ServicioRecurso.ObtenerRecurso(recursoDto.rec_id_padre);
                    recursoDto.nombrepadre = objpadre.Nombre;

                }

                recursoDto.rec_titulo = obRecurso.Titulo;
                recursoDto.rec_estilo = obRecurso.estilo;
                recursoDto.opciones = new List<RecursoDTO>();

            }
            return recursoDto;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<RecursoDTO> consultarTodosRecurso()
        {
            List<RecursoDTO> lstMenu = new List<RecursoDTO>();
            List<ART_MUSICA_RECURSO> tab = new List<ART_MUSICA_RECURSO>();

            tab = SM.Datos.Recurso.ServicioRecurso.ObtenerTodoRecurso();


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
                    // recursoDto.fechacreacion = recurso.;

                    recursoDto.rec_tipo_nombre = RECURSO_PAGINA;
                    if (recurso.Tipo == RECURSO_MENU) recursoDto.rec_tipo_nombre = RECURSO_MENU;

                    if (recursoDto.rec_id_padre > 0)
                    {
                        ART_MUSICA_RECURSO objpadre = SM.Datos.Recurso.ServicioRecurso.ObtenerRecurso(recursoDto.rec_id_padre);
                        recursoDto.nombrepadre = objpadre.Nombre;

                    }

                    recursoDto.rec_titulo = recurso.Titulo;
                    recursoDto.rec_estilo = recurso.estilo;
                    recursoDto.opciones = new List<RecursoDTO>();

                    lstMenu.Add(recursoDto);
                }

            }



            return lstMenu;
        }
        public static List<RecursoDTO> consultarTodosPagina()
        {
            List<RecursoDTO> lstMenu = new List<RecursoDTO>();
            List<ART_MUSICA_RECURSO> tab = new List<ART_MUSICA_RECURSO>();

            tab = SM.Datos.Recurso.ServicioRecurso.ObtenerTodoPagina();


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
                    // recursoDto.fechacreacion = recurso.;

                    recursoDto.rec_tipo_nombre = RECURSO_PAGINA;


                    recursoDto.rec_titulo = recurso.Titulo;
                    recursoDto.rec_estilo = recurso.estilo;
                    recursoDto.opciones = new List<RecursoDTO>();

                    lstMenu.Add(recursoDto);
                }

            }



            return lstMenu;
        }


        public static List<RecursoDTO> consultarTodosPaginaporPadre(int idPadre)
        {
            List<RecursoDTO> lstMenu = new List<RecursoDTO>();
            List<ART_MUSICA_RECURSO> tab = new List<ART_MUSICA_RECURSO>();

            tab = SM.Datos.Recurso.ServicioRecurso.ObtenerTodoPaginaporPadre(idPadre);


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
                    // recursoDto.fechacreacion = recurso.;

                    recursoDto.rec_tipo_nombre = RECURSO_PAGINA;


                    recursoDto.rec_titulo = recurso.Titulo;
                    recursoDto.rec_estilo = recurso.estilo;
                    recursoDto.opciones = new List<RecursoDTO>();

                    lstMenu.Add(recursoDto);
                }

            }



            return lstMenu;
        }
        /// <summary>
        /// Reiniciamos las opciones de un idpadre para qu queden libres idpadre=0;
        /// </summary>
        /// <param name="idPadre"></param>
        /// <returns></returns>
        public static bool reiniciarTodosPaginaporPadre(int idPadre, int UsuarioId, string NombreUsuario, string strIP)
        {
            bool respuesta = false;
            List<ART_MUSICA_RECURSO> tab = new List<ART_MUSICA_RECURSO>();

            tab = SM.Datos.Recurso.ServicioRecurso.ObtenerTodoPaginaporPadre(idPadre);


            if (tab != null)
            {
                foreach (ART_MUSICA_RECURSO recurso in tab)
                {
                    recurso.IdPadre = 0;
                    SM.Datos.Recurso.ServicioRecurso.ModificarPagina(recurso, UsuarioId, NombreUsuario, strIP);
                }

                respuesta = false;


            }



            return respuesta;
        }







        /// <summary>
        /// Creamos el menu y por referenia obtenmos el id
        /// </summary>
        /// <param name="objMenu"></param>
        /// <returns></returns>
        public static bool crearMenu(RecursoDTO objMenu, int UsuarioId, string NombreUsuario, string strIP)
        {
            ART_MUSICA_RECURSO bzrecurso = null;
            if (objMenu != null)
            {
                bzrecurso = new ART_MUSICA_RECURSO();
                bzrecurso.Tipo = RECURSO_MENU;
                bzrecurso.Titulo = objMenu.rec_titulo;
                bzrecurso.Nombre = objMenu.rec_nombre;
                bzrecurso.Codigo = objMenu.codigo;
                bzrecurso.estilo = objMenu.rec_estilo;
                bzrecurso.IdPadre = 0;
            }

            bool respuesta = SM.Datos.Recurso.ServicioRecurso.crearMenu(bzrecurso, UsuarioId, NombreUsuario, strIP);
            objMenu.id = bzrecurso.Id;
            return respuesta;
        }
        public static bool ExisteCodRecuerso(RecursoDTO objMenu)
        {
             ART_MUSICA_RECURSO bzrecurso = null;
             if (objMenu != null)
             {
                 bzrecurso = new ART_MUSICA_RECURSO();
                 bzrecurso.Codigo = objMenu.codigo;
                 bzrecurso.Nombre = objMenu.rec_nombre;
             }
            bool respuesta = SM.Datos.Recurso.ServicioRecurso.existecodigoMenu(bzrecurso);

            return respuesta;
        }


        public static bool modificarMenu(RecursoDTO objMenu, int UsuarioId, string NombreUsuario, string strIP)
        {
            ART_MUSICA_RECURSO bzrecurso = null;
            if (objMenu != null)
            {
                bzrecurso = new ART_MUSICA_RECURSO();
                bzrecurso.Tipo = RECURSO_MENU;
                bzrecurso.Titulo = objMenu.rec_titulo;
                bzrecurso.estilo = objMenu.rec_estilo;
                bzrecurso.Nombre = objMenu.rec_nombre;
                bzrecurso.Codigo = objMenu.codigo;
                bzrecurso.estilo = objMenu.rec_estilo;
                bzrecurso.IdPadre = objMenu.rec_id_padre;
                bzrecurso.Id = objMenu.id;
            }

            bool respuesta = SM.Datos.Recurso.ServicioRecurso.modificarMenu(bzrecurso, UsuarioId, NombreUsuario, strIP);

            return respuesta;
        }



        /// <summary>
        /// Creamos la spaginas
        /// </summary>
        /// <param name="objMenu"></param>
        /// <returns></returns>
        public static bool crearPaginas(RecursoDTO objMenu, int UsuarioId, string NombreUsuario, string strIP)
        {
            ART_MUSICA_RECURSO bzrecurso = null;
            if (objMenu != null)
            {
                bzrecurso = new ART_MUSICA_RECURSO();
                bzrecurso.Tipo = RECURSO_PAGINA;
                bzrecurso.Titulo = objMenu.rec_titulo;
                bzrecurso.Nombre = objMenu.rec_nombre;
                bzrecurso.Codigo = objMenu.codigo;
                bzrecurso.estilo = objMenu.rec_estilo;
                bzrecurso.IdPadre = objMenu.rec_id_padre;
                bzrecurso.Ruta = objMenu.rec_ruta;
            }

            bool respuesta = SM.Datos.Recurso.ServicioRecurso.crearPagina(bzrecurso, UsuarioId, NombreUsuario, strIP);
            objMenu.id = bzrecurso.Id;
            return respuesta;
        }
        public static bool modificarPagina(RecursoDTO objMenu, int UsuarioId, string NombreUsuario, string strIP)
        {
            ART_MUSICA_RECURSO bzrecurso = null;
            if (objMenu != null)
            {
                bzrecurso = new ART_MUSICA_RECURSO();
                bzrecurso.Tipo = RECURSO_PAGINA;
                bzrecurso.Titulo = objMenu.rec_titulo;
                bzrecurso.Nombre = objMenu.rec_nombre;
                bzrecurso.Codigo = objMenu.codigo;
                bzrecurso.estilo = objMenu.rec_estilo;
                bzrecurso.IdPadre = objMenu.rec_id_padre;
                bzrecurso.Ruta = objMenu.rec_ruta;
                bzrecurso.Id = objMenu.id;
            }

            bool respuesta = SM.Datos.Recurso.ServicioRecurso.ModificarPagina(bzrecurso, UsuarioId, NombreUsuario, strIP);
            objMenu.id = bzrecurso.Id;
            return respuesta;
        }



        public static bool adicionardeptoUsuario(UserDptoMunDTO objfrom)
        {
            ART_MUSICA_USER_CIUDAD objTo = new ART_MUSICA_USER_CIUDAD();

            objTo.CodDpto = objfrom.codDpto;
            objTo.CodMun = objfrom.codMun;
            objTo.IdUser = objfrom.idUser;

            SM.Datos.Recurso.ServicioRecurso.adicionardeptoUsuario(objTo);
            objTo.Id = objTo.Id;
            return true;
        }
        #region servicios logicos para el usuario rol
        /// <summary>
        /// adicionamos un dpto y ciudad a un usuario
        /// </summary>
        /// <param name="objfrom"></param>
        /// <returns></returns>
        public static bool crearCiudadUsuario(UserDptoMunDTO objfrom)
        {


            ART_MUSICA_USER_CIUDAD objTo = new ART_MUSICA_USER_CIUDAD();
            objTo.CodDpto = objfrom.codDpto;
            objTo.CodMun = objfrom.codMun;
            objTo.IdUser = objfrom.idUser;
            return SM.Datos.Recurso.ServicioRecurso.adicionardeptoUsuario(objTo);
        }

        public static bool eliminarCiudadUsuario(int idUser)
        {
            bool respuesta = false;

            var lstCiudadUsuario = SM.Datos.Recurso.ServicioRecurso.obtenerCiudadUsuarioPorId(idUser);

            if (lstCiudadUsuario != null)
            {


                foreach (var item in lstCiudadUsuario)
                {

                    SM.Datos.Recurso.ServicioRecurso.eliminardeptoUsuario(item);

                }
                respuesta = true;
            }
            return respuesta;
        }


        public static List<UserDptoMunDTO> obtenerCiudadUsuario(int IdUser)
        {
            List<UserDptoMunDTO> respuesta = null;

            var lstCiudadUsuario = SM.Datos.Recurso.ServicioRecurso.obtenerCiudadUsuarioPorId(IdUser);



            if (lstCiudadUsuario != null)
            {
                UserDptoMunDTO objItem = null;
                respuesta = new List<UserDptoMunDTO>();
                foreach (var item in lstCiudadUsuario)
                {
                    objItem = new UserDptoMunDTO();

                    objItem.idUser = IdUser;
                    objItem.codDpto = item.CodDpto;
                    objItem.codMun = item.CodMun; 

                    BasicaDTO objBasico = SM.Aplicacion.Basicas.ZonaGeograficasLogica.obtenerDptoporCod(objItem.codDpto);
                    if (objBasico != null)
                    {
                        objItem.nomDpto = objBasico.text;

                        objBasico = SM.Aplicacion.Basicas.ZonaGeograficasLogica.obtenerMuniporCod(objItem.codDpto, objItem.codMun);
                        objItem.nomMun = objBasico.text;
                    }
                    objItem.id = item.Id;
                    respuesta.Add(objItem);

                }
            }


            return respuesta;
        }

        #endregion




    }
}
