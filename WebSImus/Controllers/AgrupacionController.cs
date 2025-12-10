using SM.Utilidades.Log;
using SM.Aplicacion.Agrupacion;
using SM.Aplicacion.Basicas;
using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSImus.Models;
using System.IO;
using WebSImus.Translator;
using SM.Aplicacion.Modulo_Usuarios;
using DevExpress.Web.Mvc;
using WebSImus.Comunes;

namespace WebSImus.Controllers
{
    [HandleError()]
    [SessionExpire]
    public class AgrupacionController : BaseController
    {
        private static string codColombia = "52";
      

        [HttpPost]
        public JsonResult CargarListaGenero(string Prefix)
        {

            List<EstandarDTO> listOficios = CaracterizacionMusicalNeg.ConsultarGenerosMusicalesNuevo();

            var result3 = listOficios.Where(s => s.Nombre.ToLower().Contains
                     (Prefix.ToLower())).Select(w => w).ToList();


            return Json(result3, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CargarListaPersona(string Prefix)
        {

            List<EstandarDTO> listOficios = CaracterizacionMusicalNeg.ConsultarAgentes();

            var result3 = listOficios.Where(s => s.Nombre.ToLower().Contains
                     (Prefix.ToLower())).Select(w => w).ToList();


            return Json(result3, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Cargargeneros(int agrupacionId, int EliminarId)
        {
            var listado = new List<EstandarDTO>();
            if (EliminarId > 0)
            {
                SM.Aplicacion.Agrupacion.AgrupacionNeg.EliminarAgrupaciongenero(EliminarId);
            }

            listado = SM.Aplicacion.Agrupacion.AgrupacionNeg.ConsultarGenerosPorAgrupacionId(agrupacionId);

            return PartialView("_TablaGenero", listado);
        }
        public ActionResult CargarAgentes(int agrupacionId, int EliminarId)
        {
            var listado = new List<EstandarDTO>();
            if (EliminarId > 0)
            {
                SM.Aplicacion.Agentes.AgentesNeg.EliminarAgenteAgrupacion(EliminarId);
            }

            listado = SM.Aplicacion.Agentes.AgentesNeg.ConsultarAgentesAsociadosPorAgrupacionId(agrupacionId);

            return PartialView("_TablaAgente", listado);
        }

        [HttpPost]
        public JsonResult AgregarPersona(string atributo,
                                         string agrupacionId)
        {
            bool isSuccess = true;

            if (string.IsNullOrEmpty(atributo))
                return Json(new { Response = "Error" });

            SM.Aplicacion.Agentes.AgentesNeg.AgregarAgente(Convert.ToInt32(agrupacionId), atributo);

            return Json(isSuccess);

        }

        [HttpPost]
        public JsonResult AgregarGeneros(string atributo,
                                         string agrupacionId)
        {
            bool isSuccess = true;

            if (string.IsNullOrEmpty(atributo))
                return Json(new { Response = "Error" });

            SM.Aplicacion.Agrupacion.AgrupacionNeg.AgregarGenero(Convert.ToInt32(agrupacionId), atributo);

            return Json(isSuccess);

        }
        public ActionResult BuscarAgente(string Busqueda = null)
        {
            var model = new List<AgentePublicoModels>();
            if (string.IsNullOrEmpty(Busqueda))
                model = TranslatorAgentes.ConsultarAgentesRecientes();
            else
                model = TranslatorAgentes.ConsultarAgentesRecientePorBusqueda(Busqueda);

            return PartialView("_BuscarAgente", model);
        }

        public ActionResult AgregarAgente(string arreglo)
        {
            if (Session["$AgrupacionId"] != null)
            {
                int AgrupacionId = (int)Session["$AgrupacionId"];
                if (!string.IsNullOrEmpty(arreglo))
                {
                    string recursosId = arreglo.Substring(0, arreglo.Length - 1);
                    string[] listadoRecursos = recursosId.Split(',');

                    foreach (string s in listadoRecursos)
                    {
                        AgrupacionNeg.AgregarAgente(AgrupacionId, Convert.ToInt32(s));
                    }

                }
                return RedirectToAction("Editar", new { id = AgrupacionId });
            }
            else
                return RedirectToAction("Login", "Cuenta");


        }
        public ActionResult _TablaAgentes(int Id, int Eliminar)
        {
            var modeltabla = new List<AgentePublicoModels>();

            if (Eliminar > 0)
            {
                AgrupacionNeg.EliminarAgenteAgrupacion(Eliminar);

            }

            modeltabla = Translator.TranslatorAgentes.ConsultarAgentePorAgrupacionId(Id);
            return PartialView("_TablaAgentes", modeltabla);
        }
        public ActionResult Detalle(int Id)
        {
            TempData["imagen"] = "~/img/agrupa_generica.jpg";
            ViewBag.ImageData = "~/img/agrupa_generica.jpg";
            var model = new AgrupacionDataModels();
            model = TranslatorAgrupacion.ConsultarDatosAgrupacionPorId(Id);

            var modeltabla = new List<AgentePublicoModels>();

            modeltabla = Translator.TranslatorAgentes.ConsultarAgentePorAgrupacionId(Id);

            model.listAgentes = modeltabla;
            if (model.Imagen != null)
            {
                string imageBase64Data = Convert.ToBase64String(model.Imagen);
                string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                TempData["imagen"] = imageDataURL;
                ViewBag.ImageData = imageDataURL;
            }
            return View(model);

        }

        public ActionResult Crear()
        {

            TempData["imagen"] = "~/img/agrupa_generica.jpg";
            ViewBag.ImageData = "~/img/agrupa_generica.jpg";
            var model = new AgrupacionNuevoModels();
            model.CodigoPais = "52";
            model.AreaId = "4";
            CargaInicial(model.CodigoPais, model.CodigoDepartamento, model.CodigoMunicipio);

            return View(model);
        }

        [HttpPost]
        public ActionResult Crear(HttpPostedFileBase imagenPerfil, string guardar, AgrupacionNuevoModels model)
        {

            TempData["imagen"] = "~/img/agrupa_generica.jpg";
            ViewBag.ImageData = "~/img/agrupa_generica.jpg";
            if (ModelState.IsValid)
            {
                byte[] fileData = null;
                if (imagenPerfil != null && imagenPerfil.ContentLength > 0)
                {

                    using (var binaryReader = new BinaryReader(imagenPerfil.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(imagenPerfil.ContentLength);
                    }

                }
                int AgrupacionId = GuardarAgrupacion(model, fileData);
                return RedirectToAction("Editar", "Agrupacion", new { Id = AgrupacionId });

            }
            model.CodigoPais = "52";
            CargaInicial(model.CodigoPais, model.CodigoDepartamento, model.CodigoMunicipio);

            return View(model);
        }
        public ActionResult Agrupacion()
        {

            TempData["imagen"] = "~/img/agrupa_generica.jpg";
            ViewBag.ImageData = "~/img/agrupa_generica.jpg";
            var model = new AgrupacionModels();

            CargaInicial(model.CodigoPais, model.CodigoDepartamento, model.CodigoMunicipio);
            List<EstandarDTO> listGeneros = CaracterizacionMusicalNeg.ConsultarGenerosMusicales();
            model.GeneroData = listGeneros;

            return View(model);
        }

        [HttpPost]
        public ActionResult Agrupacion(HttpPostedFileBase imagenPerfil, string guardar, AgrupacionModels model)
        {
            TempData["imagen"] = "~/img/agrupa_generica.jpg";
            ViewBag.ImageData = "~/img/agrupa_generica.jpg";

            if (ModelState.IsValid)
            {
                int AgenteId = AgrupacionNeg.ObteneragenteId(Convert.ToInt32(model.TipoDocumento), model.NumeroDocumento);
                if (AgenteId == 0)
                {
                    CargaInicial(model.CodigoPais, model.CodigoDepartamento, model.CodigoMunicipio);
                    ModelState.AddModelError("", "El director no existe como agente");
                    return View(model);
                }
                else
                {
                    byte[] fileData = null;
                    if (imagenPerfil != null && imagenPerfil.ContentLength > 0)
                    {

                        using (var binaryReader = new BinaryReader(imagenPerfil.InputStream))
                        {
                            fileData = binaryReader.ReadBytes(imagenPerfil.ContentLength);
                        }

                    }
                    model.AgenteId = AgenteId;
                    //int AgrupacionId = GuardarAgrupacion(model, fileData);
                    //return RedirectToAction("Editar", "Agrupacion", new { Id = AgrupacionId });
                }
            }

            CargaInicial(model.CodigoPais, model.CodigoDepartamento, model.CodigoMunicipio);

            return View(model);
        }

        public ActionResult CambiarEstado(int Id)
        {
            TempData["imagen"] = "~/img/agrupa_generica.jpg";
            ViewBag.ImageData = "~/img/agrupa_generica.jpg";
            var modelPadre = new AgrupacionPadreModels();
            var model = new AgrupacionNuevoModels();
            model.AreaId = "4";
            model = TranslatorAgrupacion.ConsultarAgrupacionPorId(Id);

            CargaInicial(model.CodigoPais, model.CodigoDepartamento, model.CodigoMunicipio);
            List<BasicaDTO> objTipo = CaracterizacionMusicalNeg.ConsultarEstados();
            ViewBag.listEstado = new SelectList(objTipo, "value", "text");
            if (model.imagen != null)
            {
                string imageBase64Data = Convert.ToBase64String(model.imagen);
                string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                TempData["imagen"] = imageDataURL;
                ViewBag.ImageData = imageDataURL;
            }


            return View(model);
        }

        [HttpPost]
        public ActionResult CambiarEstado(int Id, HttpPostedFileBase imagenPerfil, string guardar, AgrupacionNuevoModels model)
        {
            string imageDataURL = "";
            ViewBag.ImageData = "~/img/agrupa_generica.jpg";
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
                    if (model.imagen != null)
                    {
                        string imageBase64Data = Convert.ToBase64String(model.imagen);
                        imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                    }
                    else
                    {
                        if (TempData["imagen"] != null)
                            imageDataURL = (string)TempData["imagen"];
                        else
                            imageDataURL = "~/img/agrupa_generica.jpg";
                    }
                }

                TempData["imagen"] = imageDataURL;
                ViewBag.ImageData = imageDataURL;
                ActualizarAgrupacion(Id, model, fileData, true);

               
                // envio de mensaje por correo electronico
                if (Convert.ToInt32(model.EstadoId) != Convert.ToInt32(model.EstadoOldId))
                {
                    bool validacionEmail = NotificacionCorreo.IsValidEmail(model.CorreoElectronico);
                    if (validacionEmail)
                        NotificacionCorreo.MensajeNotificaionPorEstado(model.CorreoElectronico,
                                                                       model.Nombre,
                                                                       Convert.ToInt32(model.EstadoId),
                                                                       "Agrupaciones",
                                                                      Id,
                                                                       Convert.ToInt32(UsuaroId),
                                                                       NombreCompletoUsuario,
                                                                       model.Motivo);
                }

                model = TranslatorAgrupacion.ConsultarAgrupacionPorId(Id);

                CargaInicial(model.CodigoPais, model.CodigoDepartamento, model.CodigoMunicipio);
                List<BasicaDTO> objTipo = CaracterizacionMusicalNeg.ConsultarEstados();
                ViewBag.listEstado = new SelectList(objTipo, "value", "text");


                Success(string.Format("<b></b> Se actualizo con éxito la agrupación: {0}  ", model.Nombre), true);
                return View("CambiarEstado", model);
            }


            CargaInicial(model.CodigoPais, model.CodigoDepartamento, model.CodigoMunicipio);
            return View(model);
        }
        public ActionResult Editar(int Id)
        {
            TempData["imagen"] = "~/img/agrupa_generica.jpg";
            ViewBag.ImageData = "~/img/agrupa_generica.jpg";
            var modelPadre = new AgrupacionPadreModels();
            var model = new AgrupacionNuevoModels();
            model.AreaId = "4";
            model = TranslatorAgrupacion.ConsultarAgrupacionPorId(Id);
            if (model.ArtMusicaUsuarioId != Convert.ToInt32(UsuaroId))
                return RedirectToAction("DetalleAgrupacion", "Home", new { Id = Id });

            CargaInicial(model.CodigoPais, model.CodigoDepartamento, model.CodigoMunicipio);
            if (model.imagen != null)
            {
                string imageBase64Data = Convert.ToBase64String(model.imagen);
                string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                TempData["imagen"] = imageDataURL;
                ViewBag.ImageData = imageDataURL;
            }


            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(int Id, HttpPostedFileBase imagenPerfil, string guardar, AgrupacionNuevoModels model)
        {
            string imageDataURL = "";
            ViewBag.ImageData = "~/img/agrupa_generica.jpg";
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
                    if (model.imagen != null)
                    {
                        string imageBase64Data = Convert.ToBase64String(model.imagen);
                        imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                    }
                    else
                    {
                        if (TempData["imagen"] != null)
                            imageDataURL = (string)TempData["imagen"];
                        else
                            imageDataURL = "~/img/agrupa_generica.jpg";
                    }
                }
                TempData["imagen"] = imageDataURL;
                ViewBag.ImageData = imageDataURL;
                ActualizarAgrupacion(Id, model, fileData, false);

                model = TranslatorAgrupacion.ConsultarAgrupacionPorId(Id);

                bool validacionEmail = NotificacionCorreo.IsValidEmail(model.CorreoElectronico);
                if (validacionEmail)
                    NotificacionCorreo.MensajeNotificaionPorEstado(model.CorreoElectronico, model.Nombre,
                                                                    3,
                                                                    "Agrupaciones",
                                                                   Id,
                                                                    Convert.ToInt32(UsuaroId),
                                                                    NombreCompletoUsuario,
                                                                   "");

                CargaInicial(model.CodigoPais, model.CodigoDepartamento, model.CodigoMunicipio);
                Success(string.Format("<b></b> Se actualizo con éxito la agrupación: {0}  ", model.Nombre), true);
                return View("Editar", model);
            }


            CargaInicial(model.CodigoPais, model.CodigoDepartamento, model.CodigoMunicipio);
            return View(model);
        }
        //
        // GET: /Agrupacion/
        public ActionResult Index(string Busqueda)
        {
            var model = new ConsultaModel();
            model.TipoRegistro = 1;

            return View(model);
        }

        public ActionResult Consulta()
        {
            return View();
        }

        #region Grilla


        // [Authorize]
        public ActionResult ExportTo(string OutputFormat)
        {
            var model = new List<AgrupacionDataModels>();
            string Busqueda = "";
            model = ObtenerMisregistros(Busqueda);
            return GridViewExtension.ExportToXls(GetGridSettings(), model.ToList());

        }

        public ActionResult ExportToPermisos(string OutputFormat)
        {
            var model = new List<AgrupacionDataModels>();
            model = ObtenerResultadoGestion();

            return GridViewExtension.ExportToXls(GetGridSettingsPermisos(), model.ToList());
        }
        // Returns the settings of the exported GridView. 
        private GridViewSettings GetGridSettings()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridAgrupacion";
            settings.CallbackRouteValues = new { Controller = "Agrupacion", Action = "GridViewPartial" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "Agrupaciones" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "AgrupacionId";
            settings.Columns.Add("Nombre");
            settings.Columns.Add("TipoAgrupacion");
            settings.Columns.Add("Pais");
            settings.Columns.Add("Departamento");
            settings.Columns.Add("Municipio");
            settings.Columns.Add("Estado");
            return settings;
        }

        private GridViewSettings GetGridSettingsPermisos()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridAgrupacionPermisos";
            settings.CallbackRouteValues = new { Controller = "Agrupacion", Action = "GridViewPartialPermisos" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "Agrupaciones" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "AgrupacionId";
            settings.Columns.Add("Nombre");
            settings.Columns.Add("TipoAgrupacion");
            settings.Columns.Add("Departamento");
            settings.Columns.Add("Municipio");
            settings.Columns.Add("Estado");
            settings.Columns.Add("FechaActualizacion");
            settings.Columns.Add("FechaCreacion");
            return settings;
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial(string Busqueda = null, string filtro = null)
        {
            ViewBag.GridSettings = GetGridSettings();
            var model = new List<AgrupacionDataModels>();
            model = ObtenerMisregistros(Busqueda);

            return PartialView("_GridViewPartial", model);
        }

        private List<AgrupacionDataModels> ObtenerMisregistros(string Busqueda = null)
        {
            var model = new List<AgrupacionDataModels>();

            if (string.IsNullOrEmpty(Busqueda))
            {
                if (TempData["TipoRegistroA"] != null)
                    Busqueda = TempData["TipoRegistroA"].ToString();
                else
                    Busqueda = "1";
            }

            if (Busqueda == "1")
            {
                model = TranslatorAgrupacion.ConsultarAgrupacionUsuarioId(Convert.ToInt32(UsuaroId));
                TempData["TipoRegistroA"] = 1;
            }
            else if (Busqueda == "2")
            {
                TempData["TipoRegistroA"] = 2;
                model = TranslatorAgrupacion.ConsultarAgrupacionPorEstadoId(Comunes.ConstantesRecursosBD.CODIGO_ESTADO_PUBLICADO);
            }

            return model;
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartialPermisos()
        {
            ViewBag.GridSettings = GetGridSettingsPermisos();
            var model = new List<AgrupacionDataModels>();

            model = ObtenerResultadoGestion();

            return PartialView("_GridViewPartialPermisos", model);
        }

        private List<AgrupacionDataModels> ObtenerResultadoGestion()
        {
            bool EsAdmin = false;
            var model = new List<AgrupacionDataModels>();
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
                model = TranslatorAgrupacion.ConsultarAgrupacionTodos();
            else
                model = TranslatorAgrupacion.ConsultarAgrupacionPorMunicipio(Convert.ToInt32(UsuaroId));
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
                //EntidadNeg.EliminarEntidad(Id);
                //model = TranslatorEntidades.ConsultarEntidadTodos();
                //Session["#Ag3nt3s"] = model;
            }
            catch (Exception e)
            {
                ViewData["EditError"] = e.Message;
            }

            return PartialView("_GridViewPartial", model);
        }
        #endregion
        #region MetodosPrivados
        private int GuardarAgrupacion(AgrupacionNuevoModels model, byte[] imagen)
        {
            var agrupacion = new AgrupacionDTO();
            int AgrupacionId = 0;

            if (model != null)
            {
                agrupacion.AgrupacionId = 0;
                agrupacion.ArtMusicaUsuarioId = Convert.ToInt32(UsuaroId);
                if (!string.IsNullOrEmpty(model.CodigoDepartamento))
                {
                    if (model.CodigoDepartamento.Trim() == "Seleccione un departamento")
                        agrupacion.CodigoDepartamento = "";
                    else
                        agrupacion.CodigoDepartamento = model.CodigoDepartamento;
                }
                else
                    agrupacion.CodigoDepartamento = "";
                if (!string.IsNullOrEmpty(model.CodigoMunicipio))
                {
                    if (model.CodigoMunicipio.Trim() == "Seleccione un municipio")
                        agrupacion.CodigoMunicipio = "";
                    else
                        agrupacion.CodigoMunicipio = model.CodigoMunicipio;
                }
                else
                    agrupacion.CodigoMunicipio = "";

                agrupacion.CodigoPais = "52";
                if (!string.IsNullOrEmpty(model.CorreoElectronico))
                    agrupacion.CorreoElectronico = model.CorreoElectronico;
                if (!string.IsNullOrEmpty(model.Direccion))
                    agrupacion.Direccion = model.Direccion;

                agrupacion.Nombre = model.Nombre;
                if (imagen != null)
                    agrupacion.imagen = imagen;
                else
                    agrupacion.imagen = null;
                if (!string.IsNullOrEmpty(model.linkPortafolio))
                    agrupacion.linkPortafolio = model.linkPortafolio;



                if (!string.IsNullOrEmpty(model.Descripcion))
                    agrupacion.Descripcion = model.Descripcion;

                if (!string.IsNullOrEmpty(model.Telefono))
                    agrupacion.Telefono = model.Telefono;

                if (!string.IsNullOrEmpty(model.TipoAgrupacionId))
                    agrupacion.TipoAgrupacionId = Convert.ToInt32(model.TipoAgrupacionId);
                if (!string.IsNullOrEmpty(model.NaturalezaId))
                    agrupacion.NaturalezaId = Convert.ToInt32(model.NaturalezaId);
                if (!string.IsNullOrEmpty(model.AreaId))
                    agrupacion.AreaId = Convert.ToInt32(model.AreaId);
                else
                    agrupacion.AreaId = 4;



                AgrupacionId = AgrupacionNeg.CrearAgrupacion(agrupacion, NombreCompletoUsuario, Request.UserHostAddress);
                if (model.DocumentoEPK != null)
                {
                    int DocumentoId = CrearDocumento(Convert.ToInt32(UsuaroId), NombreCompletoUsuario, model.DocumentoEPK);

                    if (DocumentoId > 0)
                    {
                        AgrupacionNeg.ActualizarAgrupacionDocumento(AgrupacionId, DocumentoId);
                    }


                }

            }
            return AgrupacionId;
        }

        private int CrearDocumento(int UsuarioId, string NombreUsuario, HttpPostedFileBase ArchivoAgenda)
        {
            int DocumentoId = 0;

            byte[] data;
            if (ArchivoAgenda != null && ArchivoAgenda.ContentLength > 0)
            {
                using (Stream inputStream = ArchivoAgenda.InputStream)
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }

                    data = memoryStream.ToArray();
                }

                // Mapea los datos del documento

                var documento = new DocumentoDTO
                {
                    NombreArchivo = ArchivoAgenda.FileName,
                    ExtensionArchivo = Path.GetExtension(ArchivoAgenda.FileName),
                    BytesArchivo = data,
                    TamanoArchivo = data.Length,
                    TipoContenido = ArchivoAgenda.ContentType,
                    FechaRegistro = DateTime.Now,
                    UsuarioId = UsuarioId,
                };

                DocumentoId = SM.Aplicacion.Documentos.DocumentosNeg.Crear(documento, NombreUsuario, Request.UserHostAddress, UsuarioId);

            }
            return DocumentoId;

        }
        private void ActualizarAgrupacion(int Id, AgrupacionNuevoModels model, byte[] imagen, bool cambiar)
        {
            var agrupacion = new AgrupacionDTO();

            if (model != null)
            {
                agrupacion.AgrupacionId = 0;
                agrupacion.ArtMusicaUsuarioId = Convert.ToInt32(UsuaroId);
                if (!string.IsNullOrEmpty(model.CodigoDepartamento))
                {
                    if (model.CodigoDepartamento.Trim() == "Seleccione un departamento")
                        agrupacion.CodigoDepartamento = "";
                    else
                        agrupacion.CodigoDepartamento = model.CodigoDepartamento;
                }
                else
                    agrupacion.CodigoDepartamento = "";
                if (!string.IsNullOrEmpty(model.CodigoMunicipio))
                {
                    if (model.CodigoMunicipio.Trim() == "Seleccione un municipio")
                        agrupacion.CodigoMunicipio = "";
                    else
                        agrupacion.CodigoMunicipio = model.CodigoMunicipio;
                }
                else
                    agrupacion.CodigoMunicipio = "";
                if (!string.IsNullOrEmpty(model.CodigoPais))
                    agrupacion.CodigoPais = model.CodigoPais;
                else
                    agrupacion.CodigoPais = "0";
                if (!string.IsNullOrEmpty(model.CorreoElectronico))
                    agrupacion.CorreoElectronico = model.CorreoElectronico;
                if (!string.IsNullOrEmpty(model.Direccion))
                    agrupacion.Direccion = model.Direccion;


                if (imagen != null)
                    agrupacion.imagen = imagen;
                else
                    agrupacion.imagen = null;
                if (!string.IsNullOrEmpty(model.linkPortafolio))
                    agrupacion.linkPortafolio = model.linkPortafolio;

                if (!string.IsNullOrEmpty(model.Nombre))
                    agrupacion.Nombre = model.Nombre;


                if (!string.IsNullOrEmpty(model.Descripcion))
                    agrupacion.Descripcion = model.Descripcion;

                if (!string.IsNullOrEmpty(model.Telefono))
                    agrupacion.Telefono = model.Telefono;

                if (!string.IsNullOrEmpty(model.AreaId))
                    agrupacion.AreaId = Convert.ToInt32(model.AreaId);
                else
                    agrupacion.AreaId = 4;

                agrupacion.TipoAgrupacionId = Convert.ToInt32(model.TipoAgrupacionId);
                agrupacion.NaturalezaId = Convert.ToInt32(model.NaturalezaId);
                if (cambiar)
                {
                    if (!string.IsNullOrEmpty(model.EstadoId))
                        agrupacion.EstadoId = Convert.ToInt32(model.EstadoId);
                    else
                        agrupacion.EstadoId = 0;
                }


                AgrupacionNeg.ActualizarAgrupacion(agrupacion, Id, cambiar, NombreCompletoUsuario, Request.UserHostAddress);

                if (model.DocumentoEPK != null)
                {
                    int DocumentoId = CrearDocumento(Convert.ToInt32(UsuaroId), NombreCompletoUsuario, model.DocumentoEPK);

                    if (DocumentoId > 0)
                    {
                        AgrupacionNeg.ActualizarAgrupacionDocumento(Id, DocumentoId);
                    }


                }
            }


        }

        private void CargaInicial(string codigoPais, string codigoDepartamento, string codigoMunicipio)
        {

            List<BasicaDTO> objTipo = CaracterizacionMusicalNeg.ConsultarTipoAgrupacion();
            ViewBag.listTipos = new SelectList(objTipo, "value", "text");

            List<BasicaDTO> lstArea = ZonaGeograficasLogica.ConsultarAreas();
            ViewBag.listArea = new SelectList(lstArea, "value", "text");

            List<BasicaDTO> objNaturaleza = CaracterizacionMusicalNeg.ConsultarNaturaleza();
            ViewBag.listNaturaleza = new SelectList(objNaturaleza, "value", "text");


            var objMunicipios = new List<BasicaDTO>();
            var objDepartamentos = new List<BasicaDTO>();

            if (codigoPais == "52")
            {
                objDepartamentos = ZonaGeograficasLogica.ConsultarDepartamentos();
                if (!string.IsNullOrEmpty(codigoDepartamento))
                {
                    objMunicipios = ZonaGeograficasLogica.ConsultarMunicipios(codigoDepartamento);
                }
            }

            ViewBag.listDepartamentos = new SelectList(objDepartamentos, "value", "text");
            ViewBag.listMunicipio = new SelectList(objMunicipios, "value", "text");

        }
        #endregion

        #region ConsultasJson
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

        public JsonResult ObtenerAgente(string tipodocumento, string numero)
        {
            var agente = new AgenteDTO();

            agente = AgrupacionNeg.ObteneragentePorDocumento(Convert.ToInt32(tipodocumento), numero);

            var data = agente;
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


            var model = new HandleErrorInfo(filterContext.Exception, "Agrupacion", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }
        #endregion
    }
}