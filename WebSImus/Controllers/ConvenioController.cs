using DevExpress.Web.Mvc;
using SM.Aplicacion.Basicas;
using SM.Aplicacion.EntidadesOpeadoras;
using SM.Aplicacion.Servicios;
using SM.LibreriaComun.DTO;
using SM.LibreriaComun.DTO.EntidadesOperadoras;
using SM.Utilidades.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSImus.Controllers
{
    [HandleError()]
    [SessionExpire]
    public class ConvenioController : BaseController
    {
        // GET: Convenio
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Coordinador()
        {
            return View();
        }


        public ActionResult Asesor()
        {
            return View();
        }
        // GET: Convenio/Create
        public ActionResult Crear()
        {
            var model = new ConvenioDTO();
            CargarDatosBasicos();
            return View(model);
        }

        // POST: Convenio/Create
        [HttpPost]
        public ActionResult Crear(ConvenioDTO datos)
        {

            if (ModelState.IsValid)
            {
               int convenioId =  ConvenioNeg.Crear(datos, Convert.ToInt32(UsuaroId));

                if (datos.DocumentoEPK != null)
                {
                    int DocumentoId = CrearDocumento(Convert.ToInt32(UsuaroId), NombreCompletoUsuario, datos.DocumentoEPK);

                    if (DocumentoId > 0)
                    {
                        ConvenioNeg.ActualizarDocumento(convenioId, DocumentoId);
                    }


                }
            }
            else
            {
                CargarDatosBasicos();
                return View("Crear", datos);
            }


            return RedirectToAction("Index");

        }

        // GET: Convenio/Edit/5
        public ActionResult Editar(int id)
        {
            var model = new ConvenioDTO();
            CargarDatosBasicos();
            model = ConvenioNeg.ConsultarPorId(id);
            return View(model);
        }

        // POST: Convenio/Edit/5
        [HttpPost]
        public ActionResult Editar(int id, ConvenioDTO datos)
        {
            if (ModelState.IsValid)
            {
                ConvenioNeg.Actualizar(id, datos, Convert.ToInt32(UsuaroId));

                if (datos.DocumentoEPK != null)
                {
                    int DocumentoId = CrearDocumento(Convert.ToInt32(UsuaroId), NombreCompletoUsuario, datos.DocumentoEPK);

                    if (DocumentoId > 0)
                    {
                        ConvenioNeg.ActualizarDocumento(id, DocumentoId);
                    }


                }
            }
            else
            {
                CargarDatosBasicos();
                Warning(string.Format("<b></b> Inconsitencia en los datos  "), true);
                return View("Editar", datos);
            }


            return RedirectToAction("Index");
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
        private GridViewSettings GetGridSettings()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridConvenio";
            settings.CallbackRouteValues = new { Controller = "Convenio", Action = "GridViewPartial" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "Convenios" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "Id";
            settings.Columns.Add("Nombre");
            settings.Columns.Add("Periodo");
            settings.Columns.Add("Nombreentidad");
            settings.Columns.Add("FechaInicio");
            settings.Columns.Add("FechaFin");
            settings.Columns.Add("Nombreestado");

            return settings;
        }

        private GridViewSettings GetGridSettingsCoordinador()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridCoordinador";
            settings.CallbackRouteValues = new { Controller = "Convenio", Action = "GridViewPartialCoordinador" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "CronogramaCoordinador" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "Id";
            settings.Columns.Add("Cronograma");
            settings.Columns.Add("FechaInicio");
            settings.Columns.Add("FechaFin");
            settings.Columns.Add("Departamento");
            settings.Columns.Add("Municipio");
            settings.Columns.Add("Escuela");
            settings.Columns.Add("Agente");
            settings.Columns.Add("Convenio");
            settings.Columns.Add("Actividad");

            return settings;
        }

        private GridViewSettings GetGridSettingsResponsable()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridResponsable";
            settings.CallbackRouteValues = new { Controller = "Convenio", Action = "GridViewPartialResponsable" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "CronogramaResponsable" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "ID";
            settings.Columns.Add("Cronograma");
            settings.Columns.Add("FechaInicio");
            settings.Columns.Add("FechaFin");
            settings.Columns.Add("Departamento");
            settings.Columns.Add("Municipio");
            settings.Columns.Add("Escuela");
            settings.Columns.Add("Agente");
            settings.Columns.Add("Convenio");
            settings.Columns.Add("Actividad");

            return settings;
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial(string Busqueda = null)
        {
            ViewBag.GridSettings = GetGridSettings();
            var model = ObtenerDatos();

            return PartialView("_GridViewPartial", model);
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartialResponsable(string Busqueda = null)
        {
            ViewBag.GridSettingsResp = GetGridSettingsResponsable();
            var model = ObtenerResponsableCronograma(Convert.ToInt32(UsuaroId));

            return PartialView("_GridViewPartialResponsable", model);
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartialCoordinador(string Busqueda = null)
        {
            ViewBag.GridSettingsCoord = GetGridSettingsCoordinador();
            var model = ObtenerConsultaCoordinadorCronograma();

            return PartialView("_GridViewPartialCoordinador", model);
        }

        public ActionResult ExportTo(string OutputFormat)
        {

            var model = ObtenerDatos();

            return GridViewExtension.ExportToXls(GetGridSettings(), model.ToList());
        }

        public ActionResult ExportToResponsable(string OutputFormat)
        {
            var model = ObtenerResponsableCronograma(Convert.ToInt32(UsuaroId));

            return GridViewExtension.ExportToXls(GetGridSettingsResponsable(), model.ToList());
        }

        public ActionResult ExportToCoordinadorCronograma(string OutputFormat)
        {
            var model = ObtenerConsultaCoordinadorCronograma();

            return GridViewExtension.ExportToXls(GetGridSettingsCoordinador(), model.ToList());
        }

        #region privada
        private void CargarDatosBasicos()
        {
            List<BasicaDTO> listEstado = CaracterizacionMusicalNeg.ConsultarEstados();
            ViewBag.listEstado = new SelectList(listEstado, "value", "text");
            List<BasicaDTO> listEntidades = ConvenioNeg.ObtenerEntidadesOperadoras();
            ViewBag.listEntidades = new SelectList(listEntidades, "value", "text");

            List<BasicaDTO> listAgente = ConvenioNeg.ObtenerCoordinador();
            ViewBag.listAgente = new SelectList(listAgente, "value", "text");

            //cargar combo de periodo

            List<BasicaDTO> objAnos = BasicaLogica.ConsultarListadoAnosMusica();
            ViewBag.listAnos = new SelectList(objAnos, "value", "text");
        }

        private List<ConvenioConsultaDTO> ObtenerDatos()
        {
            var model = new List<ConvenioConsultaDTO>();
            model = ConvenioNeg.ConsultarTodos();

            return model;
        }

        private List<CronogramaListadoDTO> ObtenerResponsableCronograma(int UsuarioId)
        {
            var model = new List<CronogramaListadoDTO>();
            model = CronogramaNeg.ConsultarResponsableCronogramas(UsuarioId);

            return model;
        }

        private List<CronogramaListadoDTO> ObtenerConsultaCoordinadorCronograma()
        {
            var model = new List<CronogramaListadoDTO>();
            model = CronogramaNeg.ConsultaCoordinadorCronograma();

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


            var model = new HandleErrorInfo(filterContext.Exception, "Convenio", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }
        #endregion
    }
}
