using SM.Utilidades.Log;
using SM.Aplicacion.Basicas;
using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSImus.Models;
using System.IO;
using SM.Aplicacion.Entidades;
using DevExpress.Web.Mvc;
using DevExpress.Data;
using WebSImus.Helpers;
using WebSImus.Translator;
using SM.Aplicacion.Modulo_Usuarios;
using WebSImus.Comunes;

namespace WebSImus.Controllers
{
    [HandleError()]
    [SessionExpire]
    public class EntidadController : BaseController
    {
        private static string codColombia = "52";

        

        public ActionResult CambiarEstado(int Id)
        {
            TempData["imagen"] = "~/img/entidad_generica.jpg";
            ViewBag.ImageData = "~/img/entidad_generica.jpg";
           
            var model = new EntidadModels();
            model = TranslatorEntidades.ConsultaEntidadPorId(Id);
            List<EstandarDTO> listTipoEntidad = CaracterizacionMusicalNeg.ConsultarTipoEntidad();
            List<EstandarDTO> listSeleccionada = CaracterizacionMusicalNeg.ConsultarTipoEntidadSeleccionada(Id);
            model.TipoEntidadData = listTipoEntidad;
            model.TipoEntidadSeleccionada = listSeleccionada;
           
            CargaInicial("52", model.CodigoDepartamento, model.CodigoMunicipio);
            List<BasicaDTO> objTipo = CaracterizacionMusicalNeg.ConsultarEstados();
            ViewBag.listEstado = new SelectList(objTipo, "value", "text");
            if (model.Imagen != null)
            {
                string imageBase64Data = Convert.ToBase64String(model.Imagen);
                string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                TempData["imagen"] = imageDataURL;
                ViewBag.ImageData = imageDataURL;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult CambiarEstado(int Id, HttpPostedFileBase imagenPerfil, string guardar, EntidadModels model)
        {
            string imageDataURL = "";
            ViewBag.ImageData = "~/img/entidad_generica.jpg";
            if (ModelState.IsValid)
            {
                byte[] fileData = null;
                if (imagenPerfil != null && imagenPerfil.ContentLength > 0)
                {

                    using (var binaryReader = new BinaryReader(imagenPerfil.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(imagenPerfil.ContentLength);
                    }
                    string imageBase64Data = Convert.ToBase64String(fileData);
                    imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                    ViewBag.ImageData = imageDataURL;
                }
                else
                {
                    if (model.Imagen != null)
                    {
                        string imageBase64Data = Convert.ToBase64String(model.Imagen);
                        imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                    }
                    else
                    {
                        if (TempData["imagen"] != null)
                            imageDataURL = (string)TempData["imagen"];
                        else
                            imageDataURL = "~/img/entidad_generica.jpg";
                    }

                    TempData["imagen"] = imageDataURL;
                    ViewBag.ImageData = imageDataURL;
                }
                ActualizarEntidad(Id, model, fileData, true);

                if (Convert.ToInt32(model.EstadoId) != Convert.ToInt32(model.EstadoOldId))
                {
                    bool validacionEmail = NotificacionCorreo.IsValidEmail(model.CorreoElectronico);
                    if (validacionEmail)
                        NotificacionCorreo.MensajeNotificaionPorEstado(model.CorreoElectronico,
                                                                       model.Nombre,
                                                                       Convert.ToInt32(model.EstadoId),
                                                                       "Entidades",
                                                                       Id,
                                                                       Convert.ToInt32(UsuaroId),
                                                                       NombreCompletoUsuario,
                                                                       model.Motivo);
                }
                return RedirectToAction("Consulta", "Entidad");
            }

            TempData["imagen"] = "~/img/entidad_generica.jpg";
            ViewBag.ImageData = "~/img/entidad_generica.jpg";
            List<EstandarDTO> listTipoEntidad = CaracterizacionMusicalNeg.ConsultarTipoEntidad();
            List<EstandarDTO> listSeleccionada = CaracterizacionMusicalNeg.ConsultarTipoEntidadSeleccionada(Id);
            model.TipoEntidadData = listTipoEntidad;
            model.TipoEntidadSeleccionada = listSeleccionada;
            CargaInicial(model.CodigoPais, model.CodigoDepartamento, model.CodigoMunicipio);
            List<BasicaDTO> objTipo = CaracterizacionMusicalNeg.ConsultarEstados();
            ViewBag.listEstado = new SelectList(objTipo, "value", "text");
            return View(model);
        }

        public ActionResult Editar(int Id)
        {
            TempData["imagen"] = "~/img/entidad_generica.jpg";
            ViewBag.ImageData = "~/img/entidad_generica.jpg";
          
            var model = new EntidadModels();
            model = TranslatorEntidades.ConsultaEntidadPorId(Id);
            if (model.ArtMusicaUsuarioId != Convert.ToInt32(UsuaroId))
               return RedirectToAction("Detalle", "Entidad", new { Id = Id });

            List<EstandarDTO> listTipoEntidad = CaracterizacionMusicalNeg.ConsultarTipoEntidad();
            List<EstandarDTO> listSeleccionada = CaracterizacionMusicalNeg.ConsultarTipoEntidadSeleccionada(Id);
            model.TipoEntidadData = listTipoEntidad;
            model.TipoEntidadSeleccionada = listSeleccionada;
            model.CodigoPais = "52";
            CargaInicial(model.CodigoPais, model.CodigoDepartamento, model.CodigoMunicipio);
            if (model.Imagen != null)
            {
                string imageBase64Data = Convert.ToBase64String(model.Imagen);
                string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                TempData["imagen"] = imageDataURL;
                ViewBag.ImageData = imageDataURL;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(int Id, HttpPostedFileBase imagenPerfil, string guardar, EntidadModels model)
        {
            string imageDataURL = "";
            ViewBag.ImageData = "~/img/entidad_generica.jpg";
            if (ModelState.IsValid)
            {
                byte[] fileData = null;
                if (imagenPerfil != null && imagenPerfil.ContentLength > 0)
                {

                    using (var binaryReader = new BinaryReader(imagenPerfil.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(imagenPerfil.ContentLength);
                    }
                    string imageBase64Data = Convert.ToBase64String(fileData);
                    imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                    ViewBag.ImageData = imageDataURL;
                }
                else
                {
                    if (model.Imagen != null)
                    {
                        string imageBase64Data = Convert.ToBase64String(model.Imagen);
                        imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                    }
                    else
                    {
                        if (TempData["imagen"] != null)
                            imageDataURL = (string)TempData["imagen"];
                        else
                            imageDataURL = "~/img/entidad_generica.jpg";
                    }

                    TempData["imagen"] = imageDataURL;
                    ViewBag.ImageData = imageDataURL;
                }
              
                ActualizarEntidad(Id, model, fileData, false);
                return RedirectToAction("Index", "Entidad");
            }

            TempData["imagen"] = "~/img/entidad_generica.jpg";
            ViewBag.ImageData = "~/img/entidad_generica.jpg";
            List<EstandarDTO> listTipoEntidad = CaracterizacionMusicalNeg.ConsultarTipoEntidad();
            List<EstandarDTO> listSeleccionada = CaracterizacionMusicalNeg.ConsultarTipoEntidadSeleccionada(Id);
            model.TipoEntidadData = listTipoEntidad;
            model.TipoEntidadSeleccionada = listSeleccionada;
            CargaInicial(model.CodigoPais, model.CodigoDepartamento, model.CodigoMunicipio);
            return View(model);
        }

        public ActionResult Detalle(int Id)
        {
            TempData["imagen"] = "~/img/entidad_generica.jpg";
            ViewBag.ImageData = "~/img/entidad_generica.jpg";
            var model = new EntidadDatosModels();
            model = TranslatorEntidades.ConsultarDatosEntidadPorId(Id);
          
            if (model.Imagen != null)
            {
                string imageBase64Data = Convert.ToBase64String(model.Imagen);
                string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                TempData["imagen"] = imageDataURL;
                ViewBag.ImageData = imageDataURL;
            }
            return View(model);

        }
        public ActionResult Entidad()
        {
            TempData["imagen"] = "~/img/entidad_generica.jpg";
            ViewBag.ImageData = "~/img/entidad_generica.jpg";
            var model = new EntidadModels();
            List<EstandarDTO> listTipoEntidad = CaracterizacionMusicalNeg.ConsultarTipoEntidad();
            List<EstandarDTO> listSeleccionada = new List<EstandarDTO>();
            model.TipoEntidadData = listTipoEntidad;
            model.TipoEntidadSeleccionada = listSeleccionada;
            model.CodigoPais = "52";
            CargaInicial("", "", "");
            return View(model);
        }

        [HttpPost]
        public ActionResult Entidad(HttpPostedFileBase imagenPerfil, string guardar, EntidadModels model)
        {
            TempData["imagen"] = "~/img/entidad_generica.jpg";
            ViewBag.ImageData = "~/img/entidad_generica.jpg";
            List<EstandarDTO> listTipoEntidad = CaracterizacionMusicalNeg.ConsultarTipoEntidad();
            List<EstandarDTO> listSeleccionada = new List<EstandarDTO>();

            if (ModelState.IsValid)
            {
                byte[] fileData = null;

                if (EntidadNeg.ExisteNit(model.Nit))
                {
                    ModelState.AddModelError("", "El Nit ya se encuentra registrado, por favor, comuníquese con el administrador");
                    
                    model.TipoEntidadData = listTipoEntidad;
                    model.TipoEntidadSeleccionada = listSeleccionada;
                    CargaInicial(model.CodigoPais, model.CodigoDepartamento, model.CodigoMunicipio);
                    return View("Entidad", model);
                }

                if (imagenPerfil != null && imagenPerfil.ContentLength > 0)
                {

                    using (var binaryReader = new BinaryReader(imagenPerfil.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(imagenPerfil.ContentLength);
                    }

                }
                GuardarEntidad(model, fileData);
                return RedirectToAction("Index", "Entidad");
            }

            model.TipoEntidadData = listTipoEntidad;
            model.TipoEntidadSeleccionada = listSeleccionada;
            CargaInicial(model.CodigoPais, model.CodigoDepartamento, model.CodigoMunicipio);
            return View(model);
        }

        public ActionResult Consulta()
        {
          
            return View();
        }
        //
        // GET: /Entidad/
        public ActionResult Index()
        {
            
            var model = new ConsultaModel();
            model.TipoRegistro = 1;

            return View(model);
        }

        #region Grilla


        // [Authorize]
        public ActionResult ExportTo(string OutputFormat)
        {
            var model = new List<EntidadDatosModels>();
            string Busqueda = "";
            model = ObtenerMisregistros(Busqueda);

            return GridViewExtension.ExportToXls(GetGridSettings(), model.ToList());
        }

        public ActionResult ExportToPermisos(string OutputFormat)
        {
            var model = new List<EntidadDatosNuevoDTO>();
           model = ObtenerResultadoGestion();

            return GridViewExtension.ExportToXls(GetGridSettingsPermisos(), model.ToList());
        }
        // Returns the settings of the exported GridView. 
        private GridViewSettings GetGridSettings()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridEntidad";
            settings.CallbackRouteValues = new { Controller = "Entidad", Action = "GridViewPartial" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "Entidades" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "Id";
            settings.Columns.Add("Nombre");
            settings.Columns.Add("Nit");
            settings.Columns.Add("Naturaleza");
             settings.Columns.Add("Departamento");
            settings.Columns.Add("Municipio");
            settings.Columns.Add("Estado");
            return settings;
        }

        private GridViewSettings GetGridSettingsPermisos()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridEntidadPermisos";
            settings.CallbackRouteValues = new { Controller = "Entidad", Action = "GridViewPartialPermisos" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "Entidades" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "Id";
            settings.Columns.Add("Nombre");
            settings.Columns.Add("Nit");
            settings.Columns.Add("Naturaleza");
            settings.Columns.Add("Departamento");
            settings.Columns.Add("Municipio");
            settings.Columns.Add("Estado");
            settings.Columns.Add("FechaActualizacion");
            settings.Columns.Add("FechaCreacion");
            return settings;
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial(string Busqueda = null)
        {
            ViewBag.GridSettings = GetGridSettings();
           var model = ObtenerMisregistros(Busqueda);
            
            return PartialView("_GridViewPartial", model);
        }

        private List<EntidadDatosModels> ObtenerMisregistros(string Busqueda = null)
        {
            var model = new List<EntidadDatosModels>();
           
            if (string.IsNullOrEmpty(Busqueda))
            {
                if (TempData["TipoRegistroE"] != null)
                    Busqueda = TempData["TipoRegistroE"].ToString();
                else
                    Busqueda = "1";
            }

            if (Busqueda == "1")
            {
                model = TranslatorEntidades.ConsultarEntidadPorUsuarioId(Convert.ToInt32(UsuaroId));
                TempData["TipoRegistroE"] = 1;
            }
            else if (Busqueda == "2")
            {
                TempData["TipoRegistroE"] = 2;
                model = TranslatorEntidades.ConsultarEntidadPorEstado(Comunes.ConstantesRecursosBD.CODIGO_ESTADO_PUBLICADO);
            }

            return model;
        }
          [ValidateInput(false)]
        public ActionResult GridViewPartialPermisos()
        {
            ViewBag.GridSettings = GetGridSettingsPermisos();
            var model = new List<EntidadDatosNuevoDTO>();

            model = ObtenerResultadoGestion();

            return PartialView("_GridViewPermisos", model);
        }

          private List<EntidadDatosNuevoDTO> ObtenerResultadoGestion()
          {
              bool EsAdmin = false;

              var model = new List<EntidadDatosNuevoDTO>();
              if (TempData["EsAdmin"] == null)
              {
                  EsAdmin = UsuarioLogica.UsuarioEsAdmin(Convert.ToInt32(UsuaroId), Comunes.ConstantesRecursosBD.CODIGO_ADMIN);
                  TempData["EsAdmin"] = EsAdmin;
              }
              else
              {
                  EsAdmin = (bool)TempData["EsAdmin"];
                  TempData["EsAdmin"] = EsAdmin;
              }

              if (EsAdmin)
                  model = EntidadNeg.ConsultarEntidadTodos();
              else
                  model = EntidadNeg.ConsultarEntidadPorMunicipio(Convert.ToInt32(UsuaroId));
              return model;
          }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] WebSImus.Models.AgentePublicoModels item)
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
            return PartialView("_GridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] WebSImus.Models.AgentePublicoModels item)
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
            return PartialView("_GridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialDelete(int Id)
        {
            var model = new List<EntidadDatosModels>();

            try
            {
                EntidadNeg.EliminarEntidad(Id);
                model = TranslatorEntidades.ConsultarEntidadTodos();
                Session["#Ag3nt3s"] = model;
            }
            catch (Exception e)
            {
                ViewData["EditError"] = e.Message;
            }

            return PartialView("_GridViewPartial", model);
        }
        #endregion

        #region MetodosPrivados

        private void GuardarEntidad(EntidadModels model, byte[] imagen)
        {
            var entidad = new EntidadDTO();

            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];

            if (model != null)
            {
                entidad.Id = 0;
                entidad.ArtMusicaUsuarioId = usuario.Id;
                if (!string.IsNullOrEmpty(model.CodigoDepartamento))
                {
                    if (model.CodigoDepartamento.Trim() == "Seleccione un departamento")
                        entidad.CodigoDepartamento = "";
                    else
                        entidad.CodigoDepartamento = model.CodigoDepartamento;
                }
                else
                    entidad.CodigoDepartamento = "";
                if (!string.IsNullOrEmpty(model.CodigoMunicipio))
                {
                    if (model.CodigoMunicipio.Trim() == "Seleccione un municipio")
                        entidad.CodigoMunicipio = "";
                    else
                        entidad.CodigoMunicipio = model.CodigoMunicipio;
                }
                else
                    entidad.CodigoMunicipio = "";
                if (!string.IsNullOrEmpty(model.CodigoPais))
                    entidad.CodigoPais = Convert.ToInt32(model.CodigoPais);
                else
                    entidad.CodigoPais = 0;
                if (!string.IsNullOrEmpty(model.CorreoElectronico))
                    entidad.CorreoElectronico = model.CorreoElectronico;
                if (!string.IsNullOrEmpty(model.Direccion))
                    entidad.Direccion = model.Direccion;

                if (!string.IsNullOrEmpty(model.Naturaleza))
                    entidad.Naturaleza = model.Naturaleza;

                if (imagen != null)
                    entidad.Imagen = imagen;
                else
                    entidad.Imagen = null;
                if (!string.IsNullOrEmpty(model.LinkPortafolio))
                    entidad.LinkPortafolio = model.LinkPortafolio;

                if (!string.IsNullOrEmpty(model.Nombre))
                    entidad.Nombre = model.Nombre;
                if (!string.IsNullOrEmpty(model.Nit))
                    entidad.Nit = Convert.ToInt32(model.Nit);
                if (!string.IsNullOrEmpty(model.DigitoVerificacion))
                    entidad.DigitoVerificacion = Convert.ToInt32(model.DigitoVerificacion);

                if (!string.IsNullOrEmpty(model.Telefono))
                    entidad.Telefono = model.Telefono;
                if (!string.IsNullOrEmpty(model.Descripcion))
                    entidad.Descripcion = model.Descripcion;
                EntidadNeg.CrearEntidad(entidad, model.TipoEntidadPublicado, usuario.PrimerNombre + " " + usuario.PrimerApellido, Request.UserHostAddress);

            }

        }

        private void ActualizarEntidad(int Id, EntidadModels model, byte[] imagen, bool cambiar)
        {
            var entidad = new EntidadDTO();
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];

            if (model != null)
            {
                entidad.Id = Id;
                entidad.ArtMusicaUsuarioId = usuario.Id;
                if (!string.IsNullOrEmpty(model.CodigoDepartamento))
                {
                    if (model.CodigoDepartamento.Trim() == "Seleccione un departamento")
                        entidad.CodigoDepartamento = "";
                    else
                        entidad.CodigoDepartamento = model.CodigoDepartamento;
                }
                else
                    entidad.CodigoDepartamento = "";
                if (!string.IsNullOrEmpty(model.CodigoMunicipio))
                {
                    if (model.CodigoMunicipio.Trim() == "Seleccione un departamento")
                        entidad.CodigoMunicipio = "";
                    else
                        entidad.CodigoMunicipio = model.CodigoMunicipio;
                }
                else
                    entidad.CodigoMunicipio = "";
                if (!string.IsNullOrEmpty(model.CodigoPais))
                    entidad.CodigoPais = Convert.ToInt32(model.CodigoPais);
                else
                    entidad.CodigoPais = 0;
                if (!string.IsNullOrEmpty(model.CorreoElectronico))
                    entidad.CorreoElectronico = model.CorreoElectronico;
                if (!string.IsNullOrEmpty(model.Direccion))
                    entidad.Direccion = model.Direccion;


                if (imagen != null)
                    entidad.Imagen = imagen;
                else
                    entidad.Imagen = null;

                if (!string.IsNullOrEmpty(model.LinkPortafolio))
                    entidad.LinkPortafolio = model.LinkPortafolio;

                if (!string.IsNullOrEmpty(model.Nombre))
                    entidad.Nombre = model.Nombre;
                if (!string.IsNullOrEmpty(model.Nit))
                    entidad.Nit = Convert.ToInt32(model.Nit);
                if (!string.IsNullOrEmpty(model.DigitoVerificacion))
                    entidad.DigitoVerificacion = Convert.ToInt32(model.DigitoVerificacion);

                if (!string.IsNullOrEmpty(model.Telefono))
                    entidad.Telefono = model.Telefono;
                if (!string.IsNullOrEmpty(model.Descripcion))
                    entidad.Descripcion = model.Descripcion;

                if (!string.IsNullOrEmpty(model.Naturaleza))
                    entidad.Naturaleza = model.Naturaleza;

                if (cambiar)
                {
                    if (!string.IsNullOrEmpty(model.EstadoId))
                        entidad.EstadoId = Convert.ToInt32(model.EstadoId);
                    else
                        entidad.EstadoId = 0;
                }
                EntidadNeg.ActualizarEntidad(entidad, cambiar, model.TipoEntidadPublicado, usuario.PrimerNombre + " " + usuario.PrimerApellido, Request.UserHostAddress);

            }

        }
        private void CargaInicial(string codigoPais, string codigoDepartamento, string codigoMunicipio)
        {
            List<BasicaDTO> lsttipoDoc = BasicaLogica.ConsultarTiposDocumentos();
            ViewBag.listTipoDocumento = new SelectList(lsttipoDoc, "value", "text");

         
            var objMunicipios = new List<BasicaDTO>();
            var objDepartamentos = new List<BasicaDTO>();

         
                objDepartamentos = ZonaGeograficasLogica.ConsultarDepartamentos();
                if (!string.IsNullOrEmpty(codigoDepartamento))
                {
                    objMunicipios = ZonaGeograficasLogica.ConsultarMunicipios(codigoDepartamento);
                }
            
            ViewBag.listDepartamentos = new SelectList(objDepartamentos, "value", "text");
            ViewBag.listMunicipio = new SelectList(objMunicipios, "value", "text");
            List<BasicaDTO> ObjNaturaleza = BasicaLogica.ConsultarNaturaleza();
            ViewBag.listNaturaleza = new SelectList(ObjNaturaleza, "value", "text");

        }

        public JsonResult ObtenerDepartamento(string codigopais = null)
        {

            List<BasicaDTO> listDpto = new List<BasicaDTO>();
            ViewBag.esColombia = true;
            if (!String.IsNullOrEmpty(codigopais) && codColombia == codigopais)
            {
                ViewBag.esColombia = false;
                listDpto = ZonaGeograficasLogica.ConsultarDepartamentos();
            }

            var data = listDpto;
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerMunicipio(string departamento = null)
        {

            List<BasicaDTO> listMunicipios = new List<BasicaDTO>();

            if (!String.IsNullOrEmpty(departamento))
            {
                listMunicipios = ZonaGeograficasLogica.ConsultarMunicipios(departamento);
            }

            var data = listMunicipios;
            return Json(data, JsonRequestBehavior.AllowGet);
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


            var model = new HandleErrorInfo(filterContext.Exception, "EntidadController", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }
        #endregion
    }
}