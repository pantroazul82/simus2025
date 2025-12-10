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
    public class RolController : BaseController
    {
        //
        // GET: /Rol/
        public ActionResult Index()
        {
            bool EsAdmin = false;
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];
            string codigoAdmin = Comunes.ConstantesRecursosBD.CODIGO_ADMIN;
            EsAdmin = UsuarioLogica.UsuarioEsAdmin(usuario.Id, codigoAdmin);
            if (!EsAdmin)
            {
                return RedirectToAction("Index", "Inicio");
            }
            return View();
        }

        public ActionResult CrearRol()
        {
            bool EsAdmin = false;
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];
            string codigoAdmin = Comunes.ConstantesRecursosBD.CODIGO_ADMIN;
            EsAdmin = UsuarioLogica.UsuarioEsAdmin(usuario.Id, codigoAdmin);
            if (!EsAdmin)
            {
                return RedirectToAction("Index", "Inicio");
            }
            RolModel obRol = new RolModel();
            obRol.recusos = SM.Aplicacion.Perfil.ServicioPerfil.consultarOpcionesTodosMenu();
            Session["$model"] = obRol.recusos;
            return View(obRol);
        }

     


        public ActionResult ConsultarRol()
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
            List<RolModel> lisRol = new List<RolModel>();


            return View(lisRol);
        }


 
        
        public ActionResult ModificarRol(int id)
        {
            bool EsAdmin = false;
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];
            string codigoAdmin = Comunes.ConstantesRecursosBD.CODIGO_ADMIN;
            EsAdmin = UsuarioLogica.UsuarioEsAdmin(usuario.Id, codigoAdmin);
            if (!EsAdmin)
            {
                return RedirectToAction("Index", "Inicio");
            }

            RolModel obRol = new RolModel();

            obRol = Translator.TranslatorRolToRolDTO.translatorRolDTOToRol(SM.Aplicacion.Perfil.ServicioPerfil.obtnerRolporId(id));
            obRol.recusos = SM.Aplicacion.Perfil.ServicioPerfil.consultarOpcionesporRolModificar(id);


            return View(obRol);
        }

        /// <summary>
        /// Guardar Nuevo Rol
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Guardar(RolModel model)
        {
            bool EsAdmin = false;
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];
            string codigoAdmin = Comunes.ConstantesRecursosBD.CODIGO_ADMIN;
            EsAdmin = UsuarioLogica.UsuarioEsAdmin(usuario.Id, codigoAdmin);
            if (!EsAdmin)
            {
                return RedirectToAction("Index", "Inicio");
            }

            if (!ModelState.IsValid)
            {

                model.recusos = SM.Aplicacion.Perfil.ServicioPerfil.consultarOpcionesTodosMenu();
                return View("CrearRol", model);
            }
            //validamos que exista el correo elctreonico
            if (model.codigo == null || model.codigo==string.Empty)
            {
                ModelState.AddModelError("", "El codigo del rol es obligatorio.");
                model.recusos = SM.Aplicacion.Perfil.ServicioPerfil.consultarOpcionesTodosMenu();
                return View("CrearRol", model);
            }

            if (model.nombre == null || model.nombre == string.Empty)
            {
                ModelState.AddModelError("", "El nombre del rol es obligatorio.");
                model.recusos = SM.Aplicacion.Perfil.ServicioPerfil.consultarOpcionesTodosMenu();
                return View("CrearRol", model);
            }
            //validamos que exista el correo electrónico
            if (SM.Aplicacion.Perfil.ServicioPerfil.existeCodRol(model.codigo))
            {
                ModelState.AddModelError("", "El codigo del rol ya xiste por favor verifique.");
                model.recusos = SM.Aplicacion.Perfil.ServicioPerfil.consultarOpcionesTodosMenu();
                return View("CrearRol", model);
            }
           
            
            
            RolDTO objNewRol = Translator.TranslatorRolToRolDTO.translatorRolToRolDTO(model);
            List<int> lstRecuersos = obtenerIdRecuersos(model.recusos);

            if (lstRecuersos==null || lstRecuersos.Count == 0)
            {
                ModelState.AddModelError("", "Los Privilegios son obligatorios");
                model.recusos = SM.Aplicacion.Perfil.ServicioPerfil.consultarOpcionesTodosMenu();
                return View("CrearRol", model);
            }


            //guardamos el rol y los recursos
            SM.Aplicacion.Perfil.ServicioPerfil.crearRol(objNewRol, lstRecuersos, usuario.Id, usuario.PrimerNombre + " " + usuario.PrimerApellido, Request.UserHostAddress);
            UsuarioDTOSIM objDTOSIM = (UsuarioDTOSIM)Session["$usuario"];
            objDTOSIM.escreateeditexistoso = true;
            Session["$usuario"] = objDTOSIM;
            return RedirectToAction("ConsultarRol", "Rol");
        }



        /// <summary>
        /// Guardar Nuevo Rol
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult editar(RolModel model)
        {
            bool EsAdmin = false;
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];
            string codigoAdmin = Comunes.ConstantesRecursosBD.CODIGO_ADMIN;
            EsAdmin = UsuarioLogica.UsuarioEsAdmin(usuario.Id, codigoAdmin);
            if (!EsAdmin)
            {
                return RedirectToAction("Index", "Inicio");
            }

            if (!ModelState.IsValid)
            {

                model.recusos = SM.Aplicacion.Perfil.ServicioPerfil.consultarOpcionesporRolModificar(model.id);
                return View("ModificarRol", model);
            }
            //validamos que exista el correo elctreonico
            if (model.codigo == null || model.codigo == string.Empty)
            {
                model.recusos = SM.Aplicacion.Perfil.ServicioPerfil.consultarOpcionesporRolModificar(model.id);
                ModelState.AddModelError("", "El codigo del rol es obligatorio.");
                return View("ModificarRol", model);
            }

            if (model.nombre == null || model.nombre == string.Empty)
            {
                model.recusos = SM.Aplicacion.Perfil.ServicioPerfil.consultarOpcionesporRolModificar(model.id);
                ModelState.AddModelError("", "El nombre del rol es obligatorio.");
                return View("ModificarRol", model);
            }
           

            RolDTO objNewRol = Translator.TranslatorRolToRolDTO.translatorRolToRolDTO(model);
            List<int> lstRecuersos = obtenerIdRecuersos(model.recusos);


            if (lstRecuersos == null || lstRecuersos.Count == 0)
            {
                ModelState.AddModelError("", "Los Privilegios son obligatorios");
                model.recusos = SM.Aplicacion.Perfil.ServicioPerfil.consultarOpcionesporRolModificar(model.id);
                return View("CrearRol", model);
            }

     
            SM.Aplicacion.Perfil.ServicioPerfil.ModificarRol(objNewRol, lstRecuersos, usuario.Id, usuario.PrimerNombre + " " + usuario.PrimerApellido, Request.UserHostAddress);
            UsuarioDTOSIM objDTOSIM = (UsuarioDTOSIM)Session["$usuario"];
            objDTOSIM.escreateeditexistoso = true;
            Session["$usuario"] = objDTOSIM;
            return RedirectToAction("ConsultarRol", "Rol");
        }


        public List<int> obtenerIdRecuersos( IList<RecursoDTO> recusos)
        {            

            List<int> IdRecuersos = new List<int>();


            foreach (var i in recusos)
            {
                if(i.aplica)
                {
                    IdRecuersos.Add(i.id);
                    //hijos
                    if (i.opciones != null)
                    {
                        foreach(var it in i.opciones)
                        {
                            if (it.aplica)
                            {
                                IdRecuersos.Add(it.id);
                            }
                        }
                    }

                }
                


                
            }

            return IdRecuersos;

        }



        #region GridView
        [ValidateInput(false)]
        public ActionResult GridViewConsultaRol()
        {
            bool EsAdmin = false;
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];
            string codigoAdmin = Comunes.ConstantesRecursosBD.CODIGO_ADMIN;
            EsAdmin = UsuarioLogica.UsuarioEsAdmin(usuario.Id, codigoAdmin);
            if (!EsAdmin)
            {
                return RedirectToAction("Index", "Inicio");
            }

            ViewBag.GridSettings = GetGridSettings();
            var model = new List<RolDTO>();
            model = SM.Aplicacion.Perfil.ServicioPerfil.obtenerRoles();
            Session["$Escuelas"] = model;
            return PartialView("_GridViewConsultaRol", model);
        }

        private GridViewSettings GetGridSettings()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridRolConsulta";
            settings.CallbackRouteValues = new { Controller = "Rol", Action = "GridViewConsultaRol" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "EscuelasMusica" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "EscuelaId";
            settings.Columns.Add("NombreEscuela");
            settings.Columns.Add("Departamento");
            settings.Columns.Add("Municipio");
            settings.Columns.Add("Categoria");
            settings.Columns.Add("Estado");
            return settings;
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewConsultaRolAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] WebSImus.Models.EscuelaConsultaModel item)
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
            return PartialView("_GridViewConsultaRol", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewConsultaRolUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] WebSImus.Models.EscuelaConsultaModel item)
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
            return PartialView("_GridViewConsultaRol", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewConsultaRolDelete(decimal EscuelaId)
        {
            var model = new List<EscuelaConsultaModel>();
            try
            {
                //EscuelasLogica.EliminarEscuelas(EscuelaId);
                //model = ConsultarEscuelas();
            }
            catch (Exception e)
            {
                ViewData["EditError"] = e.Message;
            }
            return PartialView("_GridViewConsultaRol", model);
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


            var model = new HandleErrorInfo(filterContext.Exception, "RolController", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }
        #endregion
    }
}