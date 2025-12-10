using DevExpress.Web.Mvc;
using SM.Aplicacion.Basicas;
using SM.Aplicacion.Entidades;
using SM.Aplicacion.Eventos;
using SM.Aplicacion.Modulo_Usuarios;
using SM.Aplicacion.Servicios;
using SM.LibreriaComun.DTO;
using SM.LibreriaComun.DTO.Circulacion;
using SM.Utilidades.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSImus.Comunes;
using WebSImus.Models;

namespace WebSImus.Controllers
{
    [HandleError()]
    [SessionExpire]
    public class EventosPeriodicosController : BaseController
    {
        public ActionResult TablaImagenes(int Id, int EliminarId)
        {
            var modeltabla = new List<ImagenDataDTO>();

            if (EliminarId > 0)
            {
                EsnecariosNeg.EliminarImagen(EliminarId);
            }

            modeltabla = EsnecariosNeg.ConsultarImagenesEventosperiodicos(Id);

            return PartialView("_TablaImagenes", modeltabla);
        }

        [HttpPost]
        public JsonResult AgregarImagen(int id)
        {
            bool isSuccess = true;


            byte[] data;
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                if (file != null && file.ContentLength > 0)
                {
                    using (Stream inputStream = file.InputStream)
                    {
                        MemoryStream memoryStream = inputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            inputStream.CopyTo(memoryStream);
                        }

                        data = memoryStream.ToArray();
                    }


                    int EventoId = Convert.ToInt32(id);
                    var modeltabla = EsnecariosNeg.ConsultarImagenesEventosperiodicos(EventoId);
                    bool Esprincipal = true;
                    if (modeltabla != null && modeltabla.Count > 0)
                        Esprincipal = false;

                    EsnecariosNeg.CrearImagenEventos(EventoId, data, Esprincipal);
                }
            }


            //}


            return Json(isSuccess);

        }
        #region Crear


        public ActionResult Crear()
        {

            var model = new EventoPeriodicoNuevoDTO();

            CargaInicial(model.CodDepartamento, model.codMunicipio);
            List<BasicaDTO> listAsociado = new List<BasicaDTO>();
            List<BasicaDTO> listActor = new List<BasicaDTO>();
            listAsociado.Add(new BasicaDTO() { text = "Entidades", value = "7" });
            ViewBag.listCategoria = new SelectList(listAsociado, "value", "text");
            ViewBag.listActores = new SelectList(listActor, "value", "text");
            
            return View(model);
        }
        [HttpPost]
        public ActionResult Crear(EventoPeriodicoNuevoDTO model)
        {
            if (ModelState.IsValid)
            {
                int Id = EventosPeriodicosNeg.Crear(model, Convert.ToInt32(UsuaroId));
               
                return RedirectToAction("Editar", "EventosPeriodicos", new { Id = Id });
            }
            else
            {
                CargaInicial(model.CodDepartamento, model.codMunicipio);
                List<BasicaDTO> listAsociado = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_CATEGORIAS_ACTORES);
                List<BasicaDTO> listActor = new List<BasicaDTO>();
                ViewBag.listCategoria = new SelectList(listAsociado, "value", "text");
                ViewBag.listActores = new SelectList(listActor, "value", "text");
            }
            return View(model);
        }

        public ActionResult Detalle(int Id)
        {

            var model = new EventoPeriodicoNuevoDTO();
            model = EventosPeriodicosNeg.ConsultarPorId(Id);

            bool EsAdmin = false;
        
            CargaInicialActualizar(model.CodDepartamento, model.codMunicipio, model.Tipo, EsAdmin);
            model.EsAdmin = EsAdmin;

            var modelImagen = new SM.LibreriaComun.DTO.Circulacion.ImagenesModels();
            modelImagen.EscenarioId = Id;
            model.Imagenes = modelImagen;
            return View(model);
        }
        public ActionResult Editar(int Id)
        {

            var model = new EventoPeriodicoNuevoDTO();
            model = EventosPeriodicosNeg.ConsultarPorId(Id);
            if (model.UsuarioId != Convert.ToInt32(UsuaroId))
                return RedirectToAction("Detalle", "EventosPeriodicos", new { Id = Id });

            bool EsAdmin = false;
            if (TempData["EsAdmin"] == null)
            {
                EsAdmin = SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.UsuarioEsAdmin(Convert.ToInt32(UsuaroId), Comunes.ConstantesRecursosBD.CODIGO_ADMIN);
                TempData["EsAdmin"] = EsAdmin;
            }
            else
            {
                EsAdmin = (bool)TempData["EsAdmin"];
                TempData["EsAdmin"] = EsAdmin;
            }
            CargaInicialActualizar(model.CodDepartamento, model.codMunicipio, model.Tipo, EsAdmin);
            model.EsAdmin = EsAdmin;
                
            var modelImagen = new SM.LibreriaComun.DTO.Circulacion.ImagenesModels();
            modelImagen.EventoId = Id;
            model.Imagenes = modelImagen;
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(int Id, EventoPeriodicoNuevoDTO model)
        {
            if (ModelState.IsValid)
            {
                // para quede en estado 3;
                model.EstadoId = "3";
                EventosPeriodicosNeg.Actualizar(Id, model, Convert.ToInt32(UsuaroId));
               
            }

            CargaInicialActualizar(model.CodDepartamento, model.codMunicipio, model.Tipo, model.EsAdmin);

           
            var modelImagen = new SM.LibreriaComun.DTO.Circulacion.ImagenesModels();
            modelImagen.EventoId = Id;
            model.Imagenes = modelImagen;
            return View(model);
        }

        public ActionResult CambiarEstado(int Id)
        {

            var model = new EventoPeriodicoNuevoDTO();
            model = EventosPeriodicosNeg.ConsultarPorId(Id);
           

            bool EsAdmin = false;
            if (TempData["EsAdmin"] == null)
            {
                EsAdmin = SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.UsuarioEsAdmin(Convert.ToInt32(UsuaroId), Comunes.ConstantesRecursosBD.CODIGO_ADMIN);
                TempData["EsAdmin"] = EsAdmin;
            }
            else
            {
                EsAdmin = (bool)TempData["EsAdmin"];
                TempData["EsAdmin"] = EsAdmin;
            }
            CargaInicialActualizar(model.CodDepartamento, model.codMunicipio, model.Tipo, EsAdmin);
            List<BasicaDTO> objTipo = CaracterizacionMusicalNeg.ConsultarEstados();
            ViewBag.listEstado = new SelectList(objTipo, "value", "text");
            model.EsAdmin = EsAdmin;

            var modelImagen = new SM.LibreriaComun.DTO.Circulacion.ImagenesModels();
            modelImagen.EventoId = Id;
            model.Imagenes = modelImagen;
            return View(model);
        }

        [HttpPost]
        public ActionResult CambiarEstado(int Id, EventoPeriodicoNuevoDTO model)
        {
            if (ModelState.IsValid)
            {
           
                EventosPeriodicosNeg.Actualizar(Id, model, Convert.ToInt32(UsuaroId));

            }

            CargaInicialActualizar(model.CodDepartamento, model.codMunicipio, model.Tipo, model.EsAdmin);

            List<BasicaDTO> objTipo = CaracterizacionMusicalNeg.ConsultarEstados();
            ViewBag.listEstado = new SelectList(objTipo, "value", "text");
            var modelImagen = new SM.LibreriaComun.DTO.Circulacion.ImagenesModels();
            modelImagen.EventoId = Id;
            model.Imagenes = modelImagen;
            return View(model);
        }
        #endregion

        #region MetodoPrivados
        private void CargaInicialActualizar(string codigoDepartamento, string codigoMunicipio, string TipoActorId, bool admin)
        {

            var objMunicipios = new List<BasicaDTO>();
            var objDepartamentos = new List<BasicaDTO>();

            objDepartamentos = ZonaGeograficasLogica.ConsultarDepartamentos();
            if (!string.IsNullOrEmpty(codigoDepartamento))
            {
                objMunicipios = ZonaGeograficasLogica.ConsultarMunicipios(codigoDepartamento);
            }

            List<BasicaDTO> listClasificacion = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_TIPO_EVENTOS_PERIODICOS);
            ViewBag.listClasificacion = new SelectList(listClasificacion, "value", "text");
            ViewBag.listDepartamentos = new SelectList(objDepartamentos, "value", "text");
            ViewBag.listMunicipio = new SelectList(objMunicipios, "value", "text");

            List<BasicaDTO> listAsociado = new List<BasicaDTO>();
            
            listAsociado.Add(new BasicaDTO() { text = "Entidades", value = "7" });
            ViewBag.listCategoria = new SelectList(listAsociado, "value", "text");
            List<BasicaDTO> listActor;
            if (admin)
                listActor = Administrador.ObtenerActorAdministrador(TipoActorId);
            else
                listActor = Administrador.ObtenerActor(TipoActorId, UsuaroId, Usuario);

            ViewBag.listActores = new SelectList(listActor, "value", "text");

        }
        private void CargaInicial(string codigoDepartamento, string codigoMunicipio)
        {

            var objMunicipios = new List<BasicaDTO>();
            var objDepartamentos = new List<BasicaDTO>();

            objDepartamentos = ZonaGeograficasLogica.ConsultarDepartamentos();
            if (!string.IsNullOrEmpty(codigoDepartamento))
            {
                objMunicipios = ZonaGeograficasLogica.ConsultarMunicipios(codigoDepartamento);
            }

            List<BasicaDTO> listClasificacion = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_TIPO_EVENTOS_PERIODICOS);
            ViewBag.listClasificacion = new SelectList(listClasificacion, "value", "text");
            ViewBag.listDepartamentos = new SelectList(objDepartamentos, "value", "text");
            ViewBag.listMunicipio = new SelectList(objMunicipios, "value", "text");

        }
        #endregion

        #region grillas

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
        public ActionResult ExportTo(string OutputFormat)
        {
            var model = new List<EventosPeriodicosDTO>();
            string Busqueda = "";
            model = ObtenerMisregistros(Busqueda);
            return GridViewExtension.ExportToXls(GetGridSettings(), model.ToList());

        }

        public ActionResult ExportToPermisos(string OutputFormat)
        {
            var model = new List<EventosPeriodicosDTO>();
            model = ObtenerResultadoGestion();

            return GridViewExtension.ExportToXls(GetGridSettingsPermisos(), model.ToList());
        }

        private GridViewSettings GetGridSettingsPermisos()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridGeneral";
            settings.CallbackRouteValues = new { Controller = "Espacios", Action = "GridViewPartialPermisos" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "EventosPeriodicos" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "Id";
            settings.Columns.Add("Departamento");
            settings.Columns.Add("Municipio");
            settings.Columns.Add("Nombre");
            settings.Columns.Add("Clasificacion");
            settings.Columns.Add("NombreEntidad");
            settings.Columns.Add("Estado");
            return settings;
        }
        private GridViewSettings GetGridSettings()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridGeneral";
            settings.CallbackRouteValues = new { Controller = "Espacios", Action = "GridViewPartial" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "EventosPeriodicos" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "Id";
            settings.Columns.Add("Departamento");
            settings.Columns.Add("Municipio");
            settings.Columns.Add("Nombre");
            settings.Columns.Add("Clasificacion");
            settings.Columns.Add("NombreEntidad");
            settings.Columns.Add("Estado");
            return settings;
        }
        public ActionResult GridViewPartial(string Busqueda = null, string filtro = null)
        {
            ViewBag.GridSettings = GetGridSettings();
            var model = new List<EventosPeriodicosDTO>();
            model = ObtenerMisregistros(Busqueda);

            return PartialView("_GridViewPartial", model);
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartialPermisos()
        {
            ViewBag.GridSettings = GetGridSettingsPermisos();
            var model = new List<EventosPeriodicosDTO>();

            model = ObtenerResultadoGestion();

            return PartialView("_GridViewPartialPermisos", model);
        }
        private List<EventosPeriodicosDTO> ObtenerMisregistros(string Busqueda = null)
        {
            var model = new List<EventosPeriodicosDTO>();

            if (string.IsNullOrEmpty(Busqueda))
            {
                if (TempData["TipoRegistroA"] != null)
                    Busqueda = TempData["TipoRegistroA"].ToString();
                else
                    Busqueda = "1";
            }

            if (Busqueda == "1")
            {
                model = EventosPeriodicosNeg.ConsultarPorUsuarioId(Convert.ToInt32(UsuaroId));
                TempData["TipoRegistroA"] = 1;
            }
            else if (Busqueda == "2")
            {
                TempData["TipoRegistroA"] = 2;
                model = EventosPeriodicosNeg.ConsultarPorEstadoId(Comunes.ConstantesRecursosBD.CODIGO_ESTADO_PUBLICADO);
            }

            return model;
        }

        private List<EventosPeriodicosDTO> ObtenerResultadoGestion()
        {
            bool EsAdmin = false;
            var model = new List<EventosPeriodicosDTO>();
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
                model = EventosPeriodicosNeg.ConsultarTodos();
            else
                model = EventosPeriodicosNeg.ConsultarPorMunicipio(Convert.ToInt32(UsuaroId));
            return model;
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


            var model = new HandleErrorInfo(filterContext.Exception, "EventosPeriodicos", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }
        #endregion
    }
}