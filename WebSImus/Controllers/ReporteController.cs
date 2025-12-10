using DevExpress.Web.Mvc;
using SM.Aplicacion.EntidadesOpeadoras;
using SM.LibreriaComun.DTO.Servicios;
using SM.Utilidades.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSImus.Controllers
{
    [HandleError()]
    [SessionExpire]
    public class ReporteController : BaseController
    {
        //
        // GET: /Reporte/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Reporte/Details/5
        public ActionResult Municipio()
        {
            return View();
        }

        public ActionResult Actividad()
        {
            return View();
        }
        public ActionResult Dotacion()
        {
            return View();
        }

        public ActionResult Escuela()
        {
            return View();
        }
        public ActionResult Participante()
        {
            return View();
        }

        public ActionResult Periodo()
        {
            return View();
        }

        #region GridView

        [ValidateInput(false)]
        public ActionResult GridViewPartialActividad()
        {
            ViewBag.GridSettings = GetGridSettingsActividad();
            var model = ObtenerReporteActividad();

            return PartialView("_GridViewPartialActividad", model);
        }

        private GridViewSettings GetGridSettingsActividad()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridActividad";
            settings.CallbackRouteValues = new { Controller = "Reporte", Action = "GridViewPartialActividad" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "Actividad" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            //settings.KeyFieldName = "Id";
            settings.Columns.Add("Entidad");
            settings.Columns.Add("Actividad");
            settings.Columns.Add("Cantidad");


            return settings;
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartialDotacion()
        {
            ViewBag.GridSettings = GetGridSettingsDotacion();
            var model = ObtenerReporteDotacion();

            return PartialView("_GridViewPartialDotacion", model);
        }

        private GridViewSettings GetGridSettingsDotacion()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridDotacion";
            settings.CallbackRouteValues = new { Controller = "Reporte", Action = "GridViewPartialDotacion" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "Dotacion" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "Id";
            settings.Columns.Add("CodigoDane");
            settings.Columns.Add("Departamento");
            settings.Columns.Add("Municipio");
            settings.Columns.Add("Periodo");
            settings.Columns.Add("Fuente");
            settings.Columns.Add("Tipo");
            settings.Columns.Add("Elemento");
            settings.Columns.Add("Formato");
            settings.Columns.Add("Valor");
            settings.Columns.Add("Cantidad");

            return settings;
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartialEscuela()
        {
            ViewBag.GridSettings = GetGridSettingsEscuela();
            var model = ObtenerReporteEntidadEscuela();

            return PartialView("_GridViewPartialEscuela", model);
        }

        private GridViewSettings GetGridSettingsEscuela()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridEscuela";
            settings.CallbackRouteValues = new { Controller = "Reporte", Action = "GridViewPartialEscuela" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "OperatividadEscuela" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            //settings.KeyFieldName = "Id";
            settings.Columns.Add("CodigoDane");
            settings.Columns.Add("Departamento");
            settings.Columns.Add("Municipio");
            settings.Columns.Add("FechaInicio");
            settings.Columns.Add("FechaFin");
            settings.Columns.Add("Operatividad");
            settings.Columns.Add("Entidad");
            settings.Columns.Add("Actividad");
            settings.Columns.Add("Convenio");
            settings.Columns.Add("Cronograma");
            settings.Columns.Add("Escuela");

            return settings;
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartialMunicipio()
        {
            ViewBag.GridSettings = GetGridSettingsMunicipio();
            var model = ObtenerParticipantesXMunicipio();

            return PartialView("_GridViewPartialMunicipio", model);
        }

        private GridViewSettings GetGridSettingsMunicipio()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridMunicipio";
            settings.CallbackRouteValues = new { Controller = "Reporte", Action = "GridViewPartialMunicipio" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "ParticipantesPorMunicipio" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            //settings.KeyFieldName = "Id";
            settings.Columns.Add("CodigoDane");
            settings.Columns.Add("Departamento");
            settings.Columns.Add("Municipio");
            settings.Columns.Add("Cantidad");

            return settings;
        }

        public ActionResult GridViewPartialParticipantes()
        {
            ViewBag.GridSettings = GetGridSettingsParticipantes();
            var model = ObtenerReporteParticipantesXActividad();

            return PartialView("_GridViewPartialParticipante", model);
        }

        private GridViewSettings GetGridSettingsParticipantes()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridParticipantes";
            settings.CallbackRouteValues = new { Controller = "Reporte", Action = "GridViewPartialParticipantes" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "ParticipantesPorActividad" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "Identificacion";
            settings.Columns.Add("Identificacion");
            settings.Columns.Add("Participante");
            settings.Columns.Add("CodigoDane");
            settings.Columns.Add("DepartamentoResidencia");
            settings.Columns.Add("MunicipioResidencia");
            settings.Columns.Add("Telefono");
            settings.Columns.Add("CorreoElectronico");
            settings.Columns.Add("Actividad");
            settings.Columns.Add("TipoActividad");
            settings.Columns.Add("Entidad");
         

            return settings;
        }

        public ActionResult GridViewPartialParticipantesPeriodo()
        {
            ViewBag.GridSettings = GetGridSettingsParticipantes();
            var model = ObtenerReporteParticipantesXActividad();

            return PartialView("_GridViewPartialParticipantePeriodo", model);
        }
        private GridViewSettings GetGridSettingsParticipantesXperiodo()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridParticipantesPeriodo";
            settings.CallbackRouteValues = new { Controller = "Reporte", Action = "GridViewPartialParticipantesPeriodo" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "ParticipantesPorPeriodo" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "Identificacion";
            settings.Columns.Add("Periodo");
            settings.Columns.Add("Entidad");
            settings.Columns.Add("Actividad");
            settings.Columns.Add("Departamento");
            settings.Columns.Add("Municipio");
            settings.Columns.Add("FechaInicio");
            settings.Columns.Add("FechaFin");
            settings.Columns.Add("Identificacion");
            settings.Columns.Add("Participante");
            settings.Columns.Add("DepartamentoResidencia");
            settings.Columns.Add("MunicipioResidencia");
            settings.Columns.Add("Telefono");
            settings.Columns.Add("CorreoElectronico");
         

            return settings;
        }
        #endregion

        #region Exportar
        public ActionResult ExportToParticipanteXPeriodo(string OutputFormat)
        {

            var model = ObtenerReporteParticipantesXActividad();

            return GridViewExtension.ExportToXls(GetGridSettingsParticipantesXperiodo(), model.ToList());
        }

        public ActionResult ExportToParticipanteXActividad(string OutputFormat)
        {

            var model = ObtenerReporteParticipantesXActividad();

            return GridViewExtension.ExportToXls(GetGridSettingsParticipantes(), model.ToList());
        }
        public ActionResult ExportToParticipanteXMunicipio(string OutputFormat)
        {

            var model = ObtenerParticipantesXMunicipio();

            return GridViewExtension.ExportToXls(GetGridSettingsMunicipio(), model.ToList());
        }
        public ActionResult ExportToEntidadXEscuela(string OutputFormat)
        {

            var model = ObtenerReporteEntidadEscuela();

            return GridViewExtension.ExportToXls(GetGridSettingsEscuela(), model.ToList());
        }
        
        public ActionResult ExportToActividad(string OutputFormat)
        {

            var model = ObtenerReporteActividad();

            return GridViewExtension.ExportToXls(GetGridSettingsActividad(), model.ToList());
        }
        public ActionResult ExportToDotacion(string OutputFormat)
        {

            var model = ObtenerReporteDotacion();

            return GridViewExtension.ExportToXls(GetGridSettingsDotacion(), model.ToList());
        }
        #endregion
        #region privada
        private List<ParticipanteXMunicipioListadoDTO> ObtenerParticipantesXMunicipio()
        {
            var model = new List<ParticipanteXMunicipioListadoDTO>();
            model = ContenidoNeg.ReporteParticipanteXMunicipio();

            return model;
        }

        private List<DotacionEscuelaListadoDTO> ObtenerReporteEntidadEscuela()
        {
            var model = new List<DotacionEscuelaListadoDTO>();
            model = ContenidoNeg.ReporteEntidadEscuela();

            return model;
        }

        private List<ParticipanteListadoDTO> ObtenerReporteParticipantesXActividad()
        {
            var model = new List<ParticipanteListadoDTO>();
            model = ContenidoNeg.ReporteParticipantesxActividad();

            return model;
        }

        private List<ActividadListadoDTO> ObtenerReporteActividad()
        {
            var model = new List<ActividadListadoDTO>();
            model = ContenidoNeg.ReporteActividad();

            return model;
        }

        private List<DotacionListadoDTO> ObtenerReporteDotacion()
        {
            var model = new List<DotacionListadoDTO>();
            model = ContenidoNeg.ReporteDotacion();

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


            var model = new HandleErrorInfo(filterContext.Exception, "Reporte", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }
        #endregion

    }
}
