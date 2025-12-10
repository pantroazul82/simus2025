using DevExpress.Web.Mvc;
using SM.Aplicacion.Modulo_Usuarios;
using SM.LibreriaComun.DTO;
using SM.Utilidades.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSImus.Models;

namespace WebSImus.Controllers
{
    [HandleError()]
    [SessionExpire]
    public class RecursoController : BaseController
    {
        public const string PAGE_CREAR = "CrearMenu";
        public const string PAGE_MODIFICAR = "ModificarMenu";
        //
        // GET: /Recurso/
        public ActionResult Index()
        {
            return View();
        }


        #region edicion y crecaion del recurso


        /// <summary>
        /// vaidamp y redirrecionamos si es una pagina o menu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ModificarRecurso(int id)
        {
            bool EsAdmin = false;   
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];
            string codigoAdmin = Comunes.ConstantesRecursosBD.CODIGO_ADMIN;
            EsAdmin = UsuarioLogica.UsuarioEsAdmin(usuario.Id, codigoAdmin);
            if (!EsAdmin)
            {
                return RedirectToAction("Index", "Inicio", new { id = id });
            }
               
        
            RecursoDTO objMenuOpagina = SM.Aplicacion.Recurso.ServicioRecurso.ObtenerRecurso(id);
            if (objMenuOpagina.rec_tipo == Comunes.ConstantesRecursosBD.RECURSO_MENU)
            {

                return RedirectToAction("ModificarMenu", "Recurso", new { id = id });
            }

            if (objMenuOpagina.rec_tipo == Comunes.ConstantesRecursosBD.RECURSO_PAGINA)
            {

                return RedirectToAction("ModificarPagina", "Recurso", new { id = id });
            }
            return View();
        }

        public ActionResult CrearMenu()
        {
            bool EsAdmin = false;
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];
            string codigoAdmin = Comunes.ConstantesRecursosBD.CODIGO_ADMIN;
            EsAdmin = UsuarioLogica.UsuarioEsAdmin(usuario.Id, codigoAdmin);
            if (!EsAdmin)
            {
                return RedirectToAction("Index", "Inicio");
            }

            RecursoModel objModel = new RecursoModel();
            Session["$RecursoModel"] = null;
            IEnumerable<RecursoDTO> lstpagina = SM.Aplicacion.Recurso.ServicioRecurso.consultarTodosPagina();
            ViewBag.lstpagina = null;
            if (lstpagina != null && lstpagina.Count() > 0)
            {
                ViewBag.lstpagina = new SelectList(lstpagina, "id", "rec_nombre", objModel.idPagina);
            }


            return View(objModel);
        }

        #region pagina
        public ActionResult CrearPagina()
        {
            bool EsAdmin = false;
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];
            string codigoAdmin = Comunes.ConstantesRecursosBD.CODIGO_ADMIN;
            EsAdmin = UsuarioLogica.UsuarioEsAdmin(usuario.Id, codigoAdmin);
            if (!EsAdmin)
            {
                return RedirectToAction("Index", "Inicio");
            }
            RecursoModel objModel = new RecursoModel();

            return View(objModel);
        }

        public ActionResult ModificarPagina(int id)
        {
            bool EsAdmin = false;
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];
            string codigoAdmin = Comunes.ConstantesRecursosBD.CODIGO_ADMIN;
            EsAdmin = UsuarioLogica.UsuarioEsAdmin(usuario.Id, codigoAdmin);
            if (!EsAdmin)
            {
                return RedirectToAction("Index", "Inicio");
            }

            RecursoModel objModel = new RecursoModel();
            RecursoDTO obRec = SM.Aplicacion.Recurso.ServicioRecurso.ObtenerRecurso(id);
            objModel = Translator.TranslatorRecursoToRecursoDTO.TranslatorRecursoDTOToRecurso(obRec);

            return View(objModel);
        }



        public ActionResult GuardarPagina(RecursoModel mdl)
        {
            bool EsAdmin = false;
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];
            string codigoAdmin = Comunes.ConstantesRecursosBD.CODIGO_ADMIN;
            EsAdmin = UsuarioLogica.UsuarioEsAdmin(usuario.Id, codigoAdmin);
            if (!EsAdmin)
            {
                return RedirectToAction("Index", "Inicio");
            }

            bool bexisteError = false;
            //validaciones
            if (mdl.codigo == string.Empty)
            {
                ModelState.AddModelError("", "El codigo es obligatorio");
                bexisteError = true;
            }

            if (mdl.nombre == string.Empty)
            {
                ModelState.AddModelError("", "El nombre es obligatorio");
                bexisteError = true;
            }
            if (mdl.titulo == string.Empty)
            {
                ModelState.AddModelError("", "El titulo es obligatorio");
                bexisteError = true;
            }
            if (mdl.estilo == string.Empty)
            {
                ModelState.AddModelError("", "El estilo es obligatorio");
                bexisteError = true;
            }
            if (mdl.url == string.Empty)
            {
                ModelState.AddModelError("", "La url es obligatoria");
                bexisteError = true;
            }

            if (!bexisteError)
            {

                RecursoDTO objPagina = Translator.TranslatorRecursoToRecursoDTO.TranslatorRecursoModelToRecursoDTO(mdl);
               
                objPagina.fechacreacion = DateTime.Now;
                objPagina.rec_id_padre = 0;

                RecursoDTO objMenu = Translator.TranslatorRecursoToRecursoDTO.TranslatorRecursoModelToRecursoDTO(mdl);

                if (SM.Aplicacion.Recurso.ServicioRecurso.ExisteCodRecuerso(objMenu))
                {
                    ModelState.AddModelError("", "El codigo ingresado ya existe,por favor valide");
                    return View("Crearpagina", mdl);
                }

                SM.Aplicacion.Recurso.ServicioRecurso.crearPaginas(objPagina, usuario.Id, usuario.PrimerNombre + " " + usuario.PrimerApellido, Request.UserHostAddress);

                UsuarioDTOSIM objAcess = (UsuarioDTOSIM)Session["$usuario"];
                objAcess.esactualizadoMenu = true;
                Session["$usuario"] = objAcess;
                return RedirectToAction("ConsultaRecurso", "Recurso");

            }


            return View("Crearpagina", mdl);

        }

        public ActionResult ActualizarPagina(RecursoModel mdl)
        {
            bool EsAdmin = false;
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];
            string codigoAdmin = Comunes.ConstantesRecursosBD.CODIGO_ADMIN;
            EsAdmin = UsuarioLogica.UsuarioEsAdmin(usuario.Id, codigoAdmin);
            if (!EsAdmin)
            {
                return RedirectToAction("Index", "Inicio");
            }

            bool bexisteError = false;
            //validaciones
            if (mdl.codigo == string.Empty)
            {
                ModelState.AddModelError("", "El codigo es obligatorio");
                bexisteError = true;
            }

            if (mdl.nombre == string.Empty)
            {
                ModelState.AddModelError("", "El nombre es obligatorio");
                bexisteError = true;
            }
            if (mdl.titulo == string.Empty)
            {
                ModelState.AddModelError("", "El titulo es obligatorio");
                bexisteError = true;
            }
            if (mdl.estilo == string.Empty)
            {
                ModelState.AddModelError("", "El estilo es obligatorio");
                bexisteError = true;
            }
            if (mdl.url == string.Empty)
            {
                ModelState.AddModelError("", "La url es obligatoria");
                bexisteError = true;
            }

            if (!bexisteError)
            {

                RecursoDTO objPagina = Translator.TranslatorRecursoToRecursoDTO.TranslatorRecursoModelToRecursoDTO(mdl);

                SM.Aplicacion.Recurso.ServicioRecurso.modificarPagina(objPagina, usuario.Id, usuario.PrimerNombre + " " + usuario.PrimerApellido, Request.UserHostAddress);

                UsuarioDTOSIM objAcess = (UsuarioDTOSIM)Session["$usuario"];
                objAcess.esactualizadoMenu = true;
                Session["$usuario"] = objAcess;
                return RedirectToAction("ConsultaRecurso", "Recurso");

            }


            return View("Crearpagina", mdl);

        }

        #endregion

        #region edicion del menu




        public ActionResult ModificarMenu(int id)
        {
            bool EsAdmin = false;
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];
            string codigoAdmin = Comunes.ConstantesRecursosBD.CODIGO_ADMIN;
            EsAdmin = UsuarioLogica.UsuarioEsAdmin(usuario.Id, codigoAdmin);
            if (!EsAdmin)
            {
                return RedirectToAction("Index", "Inicio", new { id = id });
            }

            RecursoModel objModel = new RecursoModel();
            RecursoDTO obRec = SM.Aplicacion.Recurso.ServicioRecurso.ObtenerRecurso(id);
            objModel = Translator.TranslatorRecursoToRecursoDTO.TranslatorRecursoDTOToRecurso(obRec);
            //cargamos las 
            IEnumerable<RecursoDTO> lstpagina = SM.Aplicacion.Recurso.ServicioRecurso.consultarTodosPagina();
            ViewBag.lstpagina = null;
            if (lstpagina != null && lstpagina.Count() > 0)
            {
                ViewBag.lstpagina = new SelectList(lstpagina, "id", "rec_nombre", objModel.idPagina);

            }


            objModel.lstPagina = SM.Aplicacion.Recurso.ServicioRecurso.consultarTodosPaginaporPadre(objModel.id);
            objModel.urlaction = PAGE_MODIFICAR;

            Session["$RecursoModel"] = objModel;

            //cargamos las paginas asociadas al menu en este momento





            return View(objModel);
        }

        [HttpPost]
        public ActionResult AccionModificar(RecursoModel mdl, string command)
        {
            bool EsAdmin = false;
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];
            string codigoAdmin = Comunes.ConstantesRecursosBD.CODIGO_ADMIN;
            EsAdmin = UsuarioLogica.UsuarioEsAdmin(usuario.Id, codigoAdmin);
            if (!EsAdmin)
            {
                return RedirectToAction("Index", "Inicio");
            }
            //ViewBag.GridSettings = GetGridSettingsCiudad();


            #region validaciones
            bool bexisteError = false;
            //validaciones


            if (mdl.nombre == string.Empty)
            {
                ModelState.AddModelError("", "El nombre es obligatorio");
                bexisteError = true;
            }
            if (mdl.titulo == string.Empty)
            {
                ModelState.AddModelError("", "El titulo es obligatorio");
                bexisteError = true;
            }
            if (mdl.estilo == string.Empty)
            {
                ModelState.AddModelError("", "El estilo es obligatorio");
                bexisteError = true;
            }



            #endregion

            if (command == "Agregar")
            {
                #region agregar



                if (mdl.idPagina != 0)
                {
                    if (this.existePaginaenMenu(mdl.idPagina))
                    {
                        ModelState.AddModelError("", "Esta pagina ya ha sido adicionada.");
                        bexisteError = true;
                    }
                }

                if (!bexisteError)
                {

                    List<RecursoDTO> lstPagina = null; ;
                    RecursoDTO objRecurso = SM.Aplicacion.Recurso.ServicioRecurso.ObtenerRecurso(mdl.idPagina);

                    if (Session["$RecursoModel"] != null)
                    {
                        //que tenga objetos
                        if ((((RecursoModel)Session["$RecursoModel"])).lstPagina.Count > 0)
                        {

                            lstPagina = (((RecursoModel)Session["$RecursoModel"])).lstPagina;
                        }

                    }

                    if (lstPagina != null)
                    {

                        lstPagina.Add(objRecurso);

                    }
                    else
                    {
                        lstPagina = new List<RecursoDTO>();
                        lstPagina.Add(objRecurso);

                    }
                    mdl.lstPagina = lstPagina;
                    mdl.urlaction = PAGE_MODIFICAR;
                    Session["$RecursoModel"] = mdl;
                    PartialView("_GridViewRecursoPagina", mdl.lstPagina);
                }

                #endregion
            }
            if (command == "Guardar")
            {

                if (!bexisteError)
                {
                    #region guardar
                    RecursoDTO objMenu = Translator.TranslatorRecursoToRecursoDTO.TranslatorRecursoModelToRecursoDTO(mdl);

                    SM.Aplicacion.Recurso.ServicioRecurso.modificarMenu(objMenu, usuario.Id, usuario.PrimerNombre + " " + usuario.PrimerApellido, Request.UserHostAddress);
                    //todo de nuevo
                    SM.Aplicacion.Recurso.ServicioRecurso.reiniciarTodosPaginaporPadre(objMenu.id, usuario.Id, usuario.PrimerNombre + " " + usuario.PrimerApellido, Request.UserHostAddress);
                    //obtenemos el Id y creamos ahora las paginas

                    foreach (var i in (((RecursoModel)Session["$RecursoModel"])).lstPagina)
                    {
                        i.rec_id_padre = objMenu.id;
                        //la idea es asociar todos los menu
                        SM.Aplicacion.Recurso.ServicioRecurso.modificarPagina(i, usuario.Id, usuario.PrimerNombre + " " + usuario.PrimerApellido, Request.UserHostAddress);
                    }


                    UsuarioDTOSIM objAcess = (UsuarioDTOSIM)Session["$usuario"];
                    objAcess.esactualizadoMenu = true;
                    Session["$usuario"] = objAcess;
                    return RedirectToAction("ConsultaRecurso", "Recurso");
                }

                    #endregion

            }
            IEnumerable<RecursoDTO> lstpagina = SM.Aplicacion.Recurso.ServicioRecurso.consultarTodosPagina();
            ViewBag.lstpagina = new SelectList(lstpagina, "id", "rec_nombre", mdl.idPagina);

            return View("ModificarMenu", mdl);

        }

        #endregion


        #endregion

        #region adicionar paginas al menu

        private bool existePaginaenMenu(int idPagina)
        {
            bool existe = false;


            if (Session["$RecursoModel"] != null)
            {

                if ((((RecursoModel)Session["$RecursoModel"])).lstPagina.Count > 0)
                {
                    List<RecursoDTO> lstCiudad = ((RecursoModel)Session["$RecursoModel"]).lstPagina;

                    if (lstCiudad.Exists(e => e.id == idPagina))
                    {
                        existe = true;
                    }
                }





            }



            return existe;

        }

        /// <summary>
        /// removemos una pagina del nuevo menu
        /// </summary>
        /// <param name="idPagina"></param>
        private void removePaginaMenu(int idPagina)
        {

            if (Session["$RecursoModel"] != null)
            {
                if ((((RecursoModel)Session["$RecursoModel"])).lstPagina.Count > 0)
                {
                    RecursoModel objnew = (RecursoModel)Session["$RecursoModel"];
                    List<RecursoDTO> lstCiudad = (objnew).lstPagina;
                    if (lstCiudad.Exists(e => e.id == idPagina))
                    {
                        objnew.lstPagina = lstCiudad.FindAll(x => x.id != idPagina);
                        Session["$RecursoModel"] = objnew;
                    }
                }






            }
        }


        /// <summary>
        /// Metodo o accion que no perimte 
        /// adicionar paginas o crear el menu
        /// </summary>
        /// <param name="mdl">modelo</param>
        /// <param name="command">accion</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Accion(RecursoModel mdl, string command)
        {
            bool EsAdmin = false;
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];
            string codigoAdmin = Comunes.ConstantesRecursosBD.CODIGO_ADMIN;
            EsAdmin = UsuarioLogica.UsuarioEsAdmin(usuario.Id, codigoAdmin);
            if (!EsAdmin)
            {
                return RedirectToAction("Index", "Inicio");
            }


            #region validaciones
            bool bexisteError = false;
            //validaciones
            if (mdl.codigo == string.Empty)
            {
                ModelState.AddModelError("", "El codigo es obligatorio");
                bexisteError = true;
            }

            if (mdl.nombre == string.Empty)
            {
                ModelState.AddModelError("", "El nombre es obligatorio");
                bexisteError = true;
            }
            if (mdl.titulo == string.Empty)
            {
                ModelState.AddModelError("", "El titulo es obligatorio");
                bexisteError = true;
            }
            if (mdl.estilo == string.Empty)
            {
                ModelState.AddModelError("", "El estilo es obligatorio");
                bexisteError = true;
            }



            #endregion

            if (command == "Agregar")
            {
                #region agregar



                if (mdl.idPagina != 0)
                {
                    if (this.existePaginaenMenu(mdl.idPagina))
                    {
                        ModelState.AddModelError("", "Esta pagina ya ha sidoa adicionada.");
                        bexisteError = true;
                    }
                }
                if (!bexisteError)
                {

                    List<RecursoDTO> lstPagina = null; ;
                    RecursoDTO objRecurso = SM.Aplicacion.Recurso.ServicioRecurso.ObtenerRecurso(mdl.idPagina);

                    if (Session["$RecursoModel"] != null)
                    {
                        //que tenga objetos
                        if ((((RecursoModel)Session["$RecursoModel"])).lstPagina.Count > 0)
                        {

                            lstPagina = (((RecursoModel)Session["$RecursoModel"])).lstPagina;
                        }

                    }

                    if (lstPagina != null)
                    {

                        lstPagina.Add(objRecurso);

                    }
                    else
                    {
                        lstPagina = new List<RecursoDTO>();
                        lstPagina.Add(objRecurso);

                    }

                    mdl.lstPagina = lstPagina;
                    mdl.urlaction = PAGE_CREAR;
                    Session["$RecursoModel"] = mdl;
                    PartialView("_GridViewRecursoPagina", mdl.lstPagina);
                }

                #endregion
            }
            if (command == "Guardar")
            {

                if (!bexisteError)
                {
                    #region guardar

                    //validamos el codigo del menu si esta ya existe
                    RecursoDTO objMenu = Translator.TranslatorRecursoToRecursoDTO.TranslatorRecursoModelToRecursoDTO(mdl);

                    if (SM.Aplicacion.Recurso.ServicioRecurso.ExisteCodRecuerso(objMenu))
                    {
                        ModelState.AddModelError("", "El codigo ingresado ya existe,por favor valide");

                    }
                    else
                    {

                        //Creamos el menu
                        SM.Aplicacion.Recurso.ServicioRecurso.crearMenu(objMenu,usuario.Id, usuario.PrimerNombre + " " + usuario.PrimerApellido, Request.UserHostAddress);

                        //obtenemos el Id y creamos ahora las paginas

                        foreach (var i in (((RecursoModel)Session["$RecursoModel"])).lstPagina)
                        {
                            i.rec_id_padre = objMenu.id;
                            //la idea es asociar todos los menu
                            SM.Aplicacion.Recurso.ServicioRecurso.modificarPagina(i, usuario.Id, usuario.PrimerNombre + " " + usuario.PrimerApellido, Request.UserHostAddress);
                        }


                        UsuarioDTOSIM objAcess = (UsuarioDTOSIM)Session["$usuario"];
                        objAcess.esactualizadoMenu = true;
                        Session["$usuario"] = objAcess;
                        return RedirectToAction("ConsultaRecurso", "Recurso");
                    }
                }

                    #endregion

            }
            IEnumerable<RecursoDTO> lstpagina = SM.Aplicacion.Recurso.ServicioRecurso.consultarTodosPagina();
            ViewBag.lstpagina = new SelectList(lstpagina, "id", "rec_nombre", mdl.idPagina);

            return View("CrearMenu", mdl);

        }



        #endregion

        public ActionResult ModificardeletePagina(int id)
        {
            bool EsAdmin = false;
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];
            string codigoAdmin = Comunes.ConstantesRecursosBD.CODIGO_ADMIN;
            EsAdmin = UsuarioLogica.UsuarioEsAdmin(usuario.Id, codigoAdmin);
            if (!EsAdmin)
            {
                return RedirectToAction("Index", "Inicio", new { id = id });
            }
            removePaginaMenu(id);
            IEnumerable<RecursoDTO> lstpagina = SM.Aplicacion.Recurso.ServicioRecurso.consultarTodosPagina();

            if (Session["$RecursoModel"] == null) RedirectToAction("ConsultaRecurso", "Recurso");
            //cargamos de la session
            RecursoModel objModel = (RecursoModel)Session["$RecursoModel"];
            ViewBag.lstpagina = new SelectList(lstpagina, "id", "rec_nombre", objModel.idPagina);

            //conocemos si es para crear o modificar
            return View(objModel.urlaction, objModel);
        }


        public ActionResult ConsultaRecurso()
        {
            bool EsAdmin = false;
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];
            string codigoAdmin = Comunes.ConstantesRecursosBD.CODIGO_ADMIN;
            EsAdmin = UsuarioLogica.UsuarioEsAdmin(usuario.Id, codigoAdmin);
            if (!EsAdmin)
            {
                return RedirectToAction("Index", "Inicio");
            }

            MensajesAccesoSimus();
            List<RecursoModel> lisRol = new List<RecursoModel>();


            return View(lisRol);
        }



        #region gridpaginas
        [ValidateInput(false)]
        public ActionResult GridViewRecursoPagina(List<RecursoDTO> model = null)
        {
            bool EsAdmin = false;
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];
            string codigoAdmin = Comunes.ConstantesRecursosBD.CODIGO_ADMIN;
            EsAdmin = UsuarioLogica.UsuarioEsAdmin(usuario.Id, codigoAdmin);
            if (!EsAdmin)
            {
                return RedirectToAction("Index", "Inicio");
            }

            ViewBag.GridSettings = GetGridRecursoSettings();
            //tomamos la db
            if (Session["$RecursoModel"] == null)
            {
                //SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.GetUsuariosSIMUS();
            }
            else
            {
                RecursoModel objModel = (RecursoModel)Session["$RecursoModel"];
                model = objModel.lstPagina;
            }

            return PartialView("_GridViewRecursoPagina", model);
        }


        private GridViewSettings GetGridRecursoSettings()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridUsuarioRecursoConsulta";
            settings.CallbackRouteValues = new { Controller = "Recurso", Action = "GridViewConsultaRecurso" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            //// Export-specific settings  
            //settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            //settings.SettingsExport.FileName = "EscuelasMusica" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            //settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            //settings.KeyFieldName = "EscuelaId";
            //settings.Columns.Add("NombreEscuela");
            //settings.Columns.Add("Departamento");
            //settings.Columns.Add("Municipio");
            //settings.Columns.Add("Categoria");
            //settings.Columns.Add("Estado");
            return settings;
        }

        public ActionResult GridViewRecursoPaginaAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] WebSImus.Models.EscuelaConsultaModel item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewConsultaUsuario", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewRecursoPaginaUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] WebSImus.Models.EscuelaConsultaModel item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewConsultaUsuario", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewRecursoPaginaDelete(decimal EscuelaId)
        {

            if (EscuelaId != 0)
            {
                try
                {
                    //EscuelasLogica.EliminarEscuelas(EscuelaId);
                    //model = ConsultarEscuelas();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridViewConsultaUsuario", null);
        }
        #endregion



        #region GridView
        [ValidateInput(false)]
        public ActionResult GridViewConsultaRecurso()
        {
            ViewBag.GridSettings = GetGridSettings();
            var model = new List<RecursoDTO>();
            model = SM.Aplicacion.Recurso.ServicioRecurso.consultarTodosRecurso();

            var modeP = Translator.TranslatorRecursoToRecursoDTO.TranslatorRecursoDTOToRecurso(model);
            Session["$Recurso"] = model;
            return PartialView("_GridViewConsultaRecurso", modeP);
        }

        private GridViewSettings GetGridSettings()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridUsuarioRecursoConsulta";
            settings.CallbackRouteValues = new { Controller = "Recurso", Action = "GridViewConsultaRecurso" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            //// Export-specific settings  
            //settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            //settings.SettingsExport.FileName = "EscuelasMusica" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            //settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            //settings.KeyFieldName = "EscuelaId";
            //settings.Columns.Add("NombreEscuela");
            //settings.Columns.Add("Departamento");
            //settings.Columns.Add("Municipio");
            //settings.Columns.Add("Categoria");
            //settings.Columns.Add("Estado");
            return settings;
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewConsultaRecursoAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] WebSImus.Models.EscuelaConsultaModel item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewConsultaUsuario", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewConsultaRecursoUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] WebSImus.Models.EscuelaConsultaModel item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewConsultaUsuario", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewConsultaRecursoRolDelete(decimal EscuelaId)
        {

            if (EscuelaId != 0)
            {
                try
                {
                    //EscuelasLogica.EliminarEscuelas(EscuelaId);
                    //model = ConsultarEscuelas();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridViewConsultaUsuario", null);
        }
        #endregion

        #region LogErrores
        protected override void OnException(ExceptionContext filterContext)
        {
            string ruta = "";
            ruta = Server.MapPath("/Log");
            Log.WriteLog(ruta, filterContext.Exception.ToString());

            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;


            var model = new HandleErrorInfo(filterContext.Exception, "RecursoController", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }
        #endregion
    }
}