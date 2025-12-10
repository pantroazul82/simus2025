using DevExpress.Web.Mvc;
using SM.Aplicacion.Basicas;
using SM.Aplicacion.Modulo_Usuarios;
using SM.Aplicacion.Usuarios;
using SM.LibreriaComun.DTO;
using SM.Utilidades.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSImus.Comunes;
using WebSImus.Models;

namespace WebSImus.Controllers
{

    [HandleError()]
    [SessionExpire]
    public class UsuarioRolController : BaseController
    {


        //
        // GET: /UsuarioRol/
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

        [HttpPost]
        public JsonResult CargarLista(string Prefix)
        {
            var listOficios = new List<EstandarDTO>();

            if (Prefix.Length > 3)
            {
                listOficios = UsuarioLogica.ObtenerUsuarioSipaPorCorreo(Prefix);
            }
            var result = listOficios;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Asignar()
        {
            bool EsAdmin = false;
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];
            string codigoAdmin = Comunes.ConstantesRecursosBD.CODIGO_ADMIN;
            EsAdmin = UsuarioLogica.UsuarioEsAdmin(usuario.Id, codigoAdmin);
            if (!EsAdmin)
            {
                return RedirectToAction("Index", "Inicio");
            }
            ViewBag.departamentos = new SelectList(ZonaGeograficasLogica.ConsultarDepartamentos(), "value", "text");
            List<BasicaDTO> objMunicipios = new List<BasicaDTO>();
            ViewBag.municipios = new SelectList(objMunicipios, "value", "text");
            return View();
        }

        [HttpPost]
        public JsonResult AsignarUsuario(string EscuelaId, string correo)
        {
            bool isSuccess = true;

            if (string.IsNullOrEmpty(EscuelaId))
                return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(correo))
                return Json(new { Response = "Error" });

         
            AsignacionUsuariosNeg.AsignarUsuario(Convert.ToDecimal(EscuelaId), correo);

            return Json(isSuccess);

        }

        private void cargardefault(Usuarios objModel = null)
        {
            List<BasicaDTO> lsttipoDoc = BasicaLogica.ConsultarTiposDocumentos();
            ViewBag.listTipoDocumento = new SelectList(lsttipoDoc, "value", "text");

            if (objModel != null)
            {
                if (objModel.IdRol == null)
                {
                    objModel.AvailableRols = SM.Aplicacion.Perfil.ServicioPerfil.obtenerRoles();
                }
                else
                {
                    objModel.AvailableRols = SM.Aplicacion.Perfil.ServicioPerfil.obtenerRoles(objModel.IdRol);
                }
            }

            List<BasicaDTO> lstDpto = ZonaGeograficasLogica.ConsultarDepartamentos();
            ViewBag.listDpto = new SelectList(lstDpto, "value", "text");

            List<BasicaDTO> listMun = new List<BasicaDTO>();
            if (objModel != null && !string.IsNullOrEmpty(objModel.departamento))
            {
                listMun = ZonaGeograficasLogica.ConsultarMunicipios(objModel.departamento);
            }

            ViewBag.listMun = new SelectList(listMun, "value", "text");
        }



        //private void cargardefault(Usuarios objModel = null)
        //{

        //    List<BasicaDTO> lsttipoDoc = BasicaLogica.ConsultarTiposDocumentos();
        //    ViewBag.listTipoDocumento = new SelectList(lsttipoDoc, "value", "text");
        //    //   ViewBag.listRoles = new SelectList(lstRoles, "id", "nombre");
        //    if (objModel != null)
        //    {//validamos si escoje o no un rol
        //        if (objModel.IdRol == null)
        //        {
        //            objModel.AvailableRols = SM.Aplicacion.Perfil.ServicioPerfil.obtenerRoles();
        //        }
        //        else
        //        {
        //            objModel.AvailableRols = SM.Aplicacion.Perfil.ServicioPerfil.obtenerRoles(objModel.IdRol);
        //        }


        //    }

        //    List<BasicaDTO> lstDpto = new List<BasicaDTO>();
        //    lstDpto = ZonaGeograficasLogica.ConsultarDepartamentos();
        //    ViewBag.listDpto = new SelectList(lstDpto, "value", "text");

        //    List<BasicaDTO> listMun = new List<BasicaDTO>();


        //    listMun = ZonaGeograficasLogica.ConsultarMunicipios();

        //    ViewBag.listMun = new SelectList(listMun, "value", "text");
        //}

        #region modificacion
        /// <summary>
        /// cragamo la informacion de usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ModificarUsuarioRol(int id)
        {
            bool EsAdmin = false;
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];
            string codigoAdmin = Comunes.ConstantesRecursosBD.CODIGO_ADMIN;
            EsAdmin = UsuarioLogica.UsuarioEsAdmin(usuario.Id, codigoAdmin);
            if (!EsAdmin)
            {
                return RedirectToAction("Index", "Inicio");
            }

            UsuarioDTOSIM objUser = SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.obtenerUsuarioporId(id);


            Usuarios objModel = Translator.TranslatorUsuarioToUsuariodtosim.UsuarioDTOSIMtoUsuario(objUser);
            cargardefault(objModel);
            //carga todo por primera vez
            objModel.PostedRoles = new PostedRoles();
            objModel.PostedRoles.RolIDs = new string[0];

            if (Session["$UsuarioCiudad"] == null)
            {
                var lstciudades = SM.Aplicacion.Recurso.ServicioRecurso.obtenerCiudadUsuario(id);

                objModel.lstAuxDpto = lstciudades;
                Session["$UsuarioCiudad"] = objModel;
            }



            return View(objModel);
        }



        public ActionResult ModificarCiudadUsuarioRol(int id = 0)
        {
            bool EsAdmin = false;
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];
            string codigoAdmin = Comunes.ConstantesRecursosBD.CODIGO_ADMIN;
            EsAdmin = UsuarioLogica.UsuarioEsAdmin(usuario.Id, codigoAdmin);
            if (!EsAdmin)
            {
                return RedirectToAction("Index", "Inicio");
            }

            UsuarioDTOSIM objUser = SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.obtenerUsuarioporId(id);

            Usuarios objModel = Translator.TranslatorUsuarioToUsuariodtosim.UsuarioDTOSIMtoUsuario(objUser);
            cargardefault(objModel);
            return View(objModel);
        }


        public ActionResult EliminarCiudadUsuarioRol(int id = 0)
        {
            bool EsAdmin = false;
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];
            string codigoAdmin = Comunes.ConstantesRecursosBD.CODIGO_ADMIN;
            EsAdmin = UsuarioLogica.UsuarioEsAdmin(usuario.Id, codigoAdmin);
            if (!EsAdmin)
            {
                return RedirectToAction("Index", "Inicio");
            }

            List<UserDptoMunDTO> lstCiudad = null;

            if (Session["$UsuarioCiudad"] != null)
            {


                lstCiudad = ((Usuarios)Session["$UsuarioCiudad"]).lstAuxDpto;
                try
                {
                    lstCiudad = (from i in lstCiudad.Where(i => i.id != id) select i).ToList();
                }
                catch (Exception)
                {
                    lstCiudad = null;
                }

            }

            ((Usuarios)Session["$UsuarioCiudad"]).lstAuxDpto = lstCiudad;
            PartialView("_GridViewUsuarioCiudad", lstCiudad);
            cargardefault();
            return View("ModificarUsuarioRol", ((Usuarios)Session["$UsuarioCiudad"]));
        }


        public ActionResult ConsultaUsuarioRol()
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
            List<UsuarioRolModel> lisRol = new List<UsuarioRolModel>();


            return View(lisRol);
        }
        #endregion

        #region GridView
        [ValidateInput(false)]
        public ActionResult GridViewConsultaUsuarioRol()
        {
            ViewBag.GridSettings = GetGridSettings();
            var model = new List<UsuarioDTOSIM>();
            model = SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.ConsultarUsuarios();

            return PartialView("_GridViewConsultaUsuario", model);
        }

        private GridViewSettings GetGridSettings()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridUsuarioUsuarioConsulta";
            settings.CallbackRouteValues = new { Controller = "UsuarioRol", Action = "GridViewConsultaUsuarioRol" };
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
        public ActionResult GridViewConsultaUsuarioRolAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] WebSImus.Models.EscuelaConsultaModel item)
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
        public ActionResult GridViewConsultaUsuarioRolUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] WebSImus.Models.EscuelaConsultaModel item)
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
        public ActionResult GridViewConsultaUsuarioRolDelete(decimal EscuelaId)
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

        #region municipio
        public JsonResult obtenerMunicipio(string coddpto = null)
        {
            ViewBag.esDpto = true;
            List<BasicaDTO> listMunicipios = new List<BasicaDTO>();

            if (!String.IsNullOrEmpty(coddpto))
            {
                ViewBag.esDpto = false;
                listMunicipios = ZonaGeograficasLogica.ConsultarMunicipios(coddpto);
            }

            var data = listMunicipios;
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region grid Depto y municipios



        [ValidateInput(false)]
        public ActionResult GridViewUsuarioCiudad(List<UserDptoMunDTO> model = null)
        {
            ViewBag.GridSettings = GetGridSettingsCiudad();
            //tomamos la db
            if (Session["$UsuarioCiudad"] == null)
            {

                if (RouteData.Values["id"] != null)
                {
                    int id = int.Parse(RouteData.Values["id"].ToString());

                    UsuarioDTOSIM objUser = SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.obtenerUsuarioporId(id);
                    cargardefault();
                    Usuarios objModel = Translator.TranslatorUsuarioToUsuariodtosim.UsuarioDTOSIMtoUsuario(objUser);

                    var lstciudades = SM.Aplicacion.Recurso.ServicioRecurso.obtenerCiudadUsuario(id);

                    objModel.lstAuxDpto = lstciudades;
                    Session["$UsuarioCiudad"] = objModel;
                }

            }
            else
            {
                model = ((Usuarios)Session["$UsuarioCiudad"]).lstAuxDpto;
            }

            return PartialView("_GridViewUsuarioCiudad", model);
        }




        private GridViewSettings GetGridSettingsCiudad()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridUsuarioUsuarioCiudad";
            settings.CallbackRouteValues = new { Controller = "UsuarioRol", Action = "GridViewUsuarioCiudad" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;

            return settings;
        }

        #region adiciones

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewUsuarioCiudadRolAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] WebSImus.Models.EscuelaConsultaModel item)
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
        public ActionResult GridViewUsuarioCiudadRolUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] WebSImus.Models.EscuelaConsultaModel item)
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
        public ActionResult GridViewUsuarioCiudadRolDelete(decimal EscuelaId)
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
        #endregion


        [HttpPost]
        public ActionResult Accion(Usuarios userProfile, string command)
        {
            #region validaciones
            bool bexisteError = false;

            if (string.IsNullOrEmpty(userProfile.departamento))
            {
                ModelState.AddModelError("", "El departamento es obligatorio");
                bexisteError = true;
            }

            if (string.IsNullOrEmpty(userProfile.municipio))
            {
                ModelState.AddModelError("", "El municipio es obligatorio");
                bexisteError = true;
            }
            #endregion

            if (command == "Agregar")
            {
                #region agregar

                if (userProfile.departamento != null && (userProfile.municipio == null || userProfile.municipio == "0"))
                {
                    var listAll = ZonaGeograficasLogica.ConsultarMunicipios(userProfile.departamento);
                    if (Session["$UsuarioCiudad"] != null)
                    {
                        BasicaDTO objBasico = ZonaGeograficasLogica.obtenerDptoporCod(userProfile.departamento);
                        List<UserDptoMunDTO> lstCiudad = (from i in listAll
                                                          select new UserDptoMunDTO
                                                          {
                                                              codMun = i.value,
                                                              nomMun = i.text,
                                                              codDpto = userProfile.departamento,
                                                              nomDpto = objBasico.text
                                                          }).ToList();

                        List<UserDptoMunDTO> lstTotal = null;
                        if (((Usuarios)Session["$UsuarioCiudad"]).lstAuxDpto != null && ((Usuarios)Session["$UsuarioCiudad"]).lstAuxDpto.Count > 0)
                        {
                            lstTotal = ((Usuarios)Session["$UsuarioCiudad"]).lstAuxDpto;
                            lstTotal.AddRange(lstCiudad);
                        }
                        else
                        {
                            lstTotal = lstCiudad;
                        }

                        int index = 0;
                        foreach (var i in lstTotal)
                        {
                            i.id = ++index;
                        }

                        ((Usuarios)Session["$UsuarioCiudad"]).lstAuxDpto = lstTotal;
                    }
                }
                else
                {
                    #region proceso normal de adicion

                    if (existeDptoandMunicipio(userProfile.departamento, userProfile.municipio))
                    {
                        ModelState.AddModelError("", "El departamento y municipio ya existen, por favor verifique");
                        bexisteError = true;
                    }

                    if (!bexisteError)
                    {
                        List<UserDptoMunDTO> lstCiudad = null;
                        int count = 1;

                        if (Session["$UsuarioCiudad"] != null && ((Usuarios)Session["$UsuarioCiudad"]).lstAuxDpto != null)
                        {
                            lstCiudad = ((Usuarios)Session["$UsuarioCiudad"]).lstAuxDpto;
                            count = lstCiudad.Count() + 1;
                        }
                        else
                        {
                            Session["$UsuarioCiudad"] = userProfile;
                        }

                        UserDptoMunDTO obDpto = new UserDptoMunDTO();
                        obDpto.codDpto = userProfile.departamento;
                        obDpto.codMun = userProfile.municipio;
                        obDpto.id = count;

                        BasicaDTO objBasico = ZonaGeograficasLogica.obtenerDptoporCod(obDpto.codDpto);
                        obDpto.nomDpto = objBasico.text;
                        objBasico = ZonaGeograficasLogica.obtenerMuniporCod(obDpto.codDpto, obDpto.codMun);
                        obDpto.nomMun = objBasico.text;

                        if (lstCiudad != null)
                        {
                            lstCiudad.Add(obDpto);
                        }
                        else
                        {
                            lstCiudad = new List<UserDptoMunDTO> { obDpto };
                        }

                        ((Usuarios)Session["$UsuarioCiudad"]).lstAuxDpto = lstCiudad;
                    }

                    #endregion
                }

                cargardefault(userProfile);
                return View("ModificarUsuarioRol", userProfile);
            }
            else if (command == "Guardar")
            {
                UsuarioDTOSIM objRegistro = (UsuarioDTOSIM)Session["$usuario"];

                if (userProfile.IdRol == null || userProfile.IdRol.Count == 0)
                {
                    cargardefault(userProfile);
                    ModelState.AddModelError("", "El rol es obligatorio");
                    return View("ModificarUsuarioRol", userProfile);
                }

                SM.Aplicacion.Perfil.ServicioPerfil.actualizarUsuarioRol(userProfile.Id, userProfile.IdRol, objRegistro.PrimerNombre + " " + objRegistro.PrimerApellido, objRegistro.Id, Request.UserHostAddress);


                SM.Aplicacion.Recurso.ServicioRecurso.eliminarCiudadUsuario(userProfile.Id);

                List<UserDptoMunDTO> lstModif = ((Usuarios)Session["$UsuarioCiudad"]).lstAuxDpto;

                foreach (var i in lstModif)
                {
                    i.idUser = userProfile.Id;
                    SM.Aplicacion.Recurso.ServicioRecurso.adicionardeptoUsuario(i);
                }

                objRegistro.escreateeditexistoso = true;
                Session["$usuario"] = objRegistro;
                Session["$UsuarioCiudad"] = null;
                return RedirectToAction("ConsultaUsuarioRol", "UsuarioRol");
            }

            return RedirectToAction("ModificarUsuarioRol", "UsuarioRol", new { id = RouteData.Values["id"] });
        }


        [HttpGet]
        public JsonResult ConsultarMunicipiosPorDepartamento(string codDepartamento)
        {
            var municipios = ZonaGeograficasLogica.ConsultarMunicipios(codDepartamento);
            return Json(municipios.Select(m => new { value = m.value, text = m.text }), JsonRequestBehavior.AllowGet);
        }




        #region validaciones dpto& ciudad
        /// <summary>
        /// validamo si existe el dpto y municipio asociado
        /// </summary>
        /// <param name="codDpto"></param>
        /// <param name="codMun"></param>
        /// <returns></returns>
        private bool existeDptoandMunicipio(string codDpto, string codMun)
        {
            bool existe = false;


            if (Session["$UsuarioCiudad"] != null)
            {

                if ((((Usuarios)Session["$UsuarioCiudad"]).lstAuxDpto).Count > 0)
                {
                    List<UserDptoMunDTO> lstCiudad = ((Usuarios)Session["$UsuarioCiudad"]).lstAuxDpto;

                    if (lstCiudad.Exists(e => e.codDpto == codDpto && e.codMun == codMun))
                    {
                        existe = true;
                    }
                }





            }



            return existe;

        }
        #endregion

        protected override void OnException(ExceptionContext filterContext)
        {
            string ruta = "";
            ruta = Server.MapPath("/Log");
            Log.WriteLog(ruta, filterContext.Exception.ToString());

            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;


            var model = new HandleErrorInfo(filterContext.Exception, "Cuenta", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }

        #endregion
    }
}