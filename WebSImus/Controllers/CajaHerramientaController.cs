using DevExpress.Web.Mvc;
using SM.Aplicacion.Basicas;
using SM.Aplicacion.Servicios;
using SM.LibreriaComun.DTO;
using SM.LibreriaComun.DTO.Servicios;
using SM.Utilidades.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSImus.Helpers;
using WebSImus.Models;

namespace WebSImus.Controllers
{
    [HandleError()]
    [SessionExpire]
    public class CajaHerramientaController : BaseController
    {
        // GET: CajaHerramienta
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Editar(int id)
        {
            var model = new HerramientaModel();
            var resultado = HerramientaNeg.ObtenerHerramienta(id);
            model = Translator.TranslatorUtilidad.TranslatorHerramientaModel(resultado);
            CargaInicial();
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(int Id, HerramientaModel model)
        {
            if (ModelState.IsValid)
            {
                Actualizar(Id, model);
              
            }
            var resultado = HerramientaNeg.ObtenerHerramienta(Id);
            model = Translator.TranslatorUtilidad.TranslatorHerramientaModel(resultado);
            CargaInicial();
            Success(string.Format("<b></b> Se actualizo con éxito la herramienta: {0}  ", model.Nombre), true);
            return View("Editar", model);
        }
        public ActionResult Crear()
        {
            var model = new HerramientaModel();
          
            CargaInicial();
            return View(model);
        }

        [HttpPost]
        public ActionResult Crear(HerramientaModel model)
        {
           
            if (ModelState.IsValid)
            {
               
                int HerramientaId = Guardar(model);
                return RedirectToAction("Index", "CajaHerramienta");

            }
            CargaInicial();

            return View(model);
        }

        private void Actualizar(int Id, HerramientaModel model)
        {
            if (model != null)
            {
                HerramientaNeg.Actualizar(Id, model.Nombre,
                                            model.Descripcion,
                                          model.Autores,
                                          Convert.ToInt32(model.EstadoId),
                                          Convert.ToInt32(model.TipoId),
                                          model.UrlArchivo,
                                          model.UrlVideo,
                                          Convert.ToInt32(UsuaroId), NombreCompletoUsuario, Request.UserHostAddress);

                if (model.Documento != null)
                {
                    int DocumentoId = documentoCreacion.CrearDocumento(Convert.ToInt32(UsuaroId), NombreCompletoUsuario, Request.UserHostAddress, model.Documento);

                    if (DocumentoId > 0)
                    {
                        HerramientaNeg.ActualizarDOcumento(Id, DocumentoId);
                    }


                }

            }
        }

        private int Guardar(HerramientaModel model)
        {
            int herramientaId = 0;

            if (model !=null)
            {
                var datos = new HerramientaDetalleDTO();
                datos.Autores = model.Autores;
                datos.Descripcion = model.Descripcion;
                datos.Nombre = model.Nombre;
                datos.TipoId = Convert.ToInt32(model.TipoId);
                datos.UrlArchivo = model.UrlArchivo;
                datos.UrlVideo = model.UrlVideo;
                datos.UsuarioId = Convert.ToInt32(UsuaroId);
                datos.EstadoId = Convert.ToInt32(model.EstadoId);
                herramientaId = HerramientaNeg.Crear(datos, NombreCompletoUsuario, Request.UserHostAddress);

                if (model.Documento != null)
                {
                    int DocumentoId = documentoCreacion.CrearDocumento(Convert.ToInt32(UsuaroId), NombreCompletoUsuario, Request.UserHostAddress, model.Documento);

                    if (DocumentoId > 0)
                    {
                        HerramientaNeg.ActualizarDOcumento(herramientaId, DocumentoId);
                    }


                }

            }
            return herramientaId;

        }
        private void CargaInicial()
        {
            List<BasicaDTO> listTipoHerramienta = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_TIPO_HERRAMIENTAS);
            ViewBag.listTipoHerramienta = new SelectList(listTipoHerramienta, "value", "text");
            List<BasicaDTO> listEstado = CaracterizacionMusicalNeg.ConsultarEstados();
            ViewBag.listEstado = new SelectList(listEstado, "value", "text");
       
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartialPermisos()
        {
            ViewBag.GridSettings = GetGridSettingsPermisos();
            var model =  ObtenerResultadoGestion();

            return PartialView("GridViewPartialPermisos", model);
        }

        public ActionResult ExportToPermisos(string OutputFormat)
        {
            var model = new List<HerramientaDataDTO>();
            model = ObtenerResultadoGestion();

            return GridViewExtension.ExportToXls(GetGridSettingsPermisos(), model.ToList());
        }

        private GridViewSettings GetGridSettingsPermisos()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridHerramienta";
            settings.CallbackRouteValues = new { Controller = "CajaHerramienta", Action = "GridViewPartialPermisos" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "Herramientas" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "Id";
            settings.Columns.Add("Nombre");
            settings.Columns.Add("TipoHerramienta");
            settings.Columns.Add("Estado");
         
            return settings;
        }
        private List<HerramientaDataDTO> ObtenerResultadoGestion()
        {
            var model = new List<HerramientaDataDTO>();

            model = HerramientaNeg.ConsultarHerramientas();
            return model;
        }

        #region LogErrores
        protected override void OnException(ExceptionContext filterContext)
        {
            string ruta = "";
            ruta = Server.MapPath("/Log");
            Log.WriteLog(ruta, filterContext.Exception.ToString());

            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;


            var model = new HandleErrorInfo(filterContext.Exception, "CajaHerramientaController", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }
        #endregion
    }
}