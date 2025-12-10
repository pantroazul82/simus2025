using System.Web.Mvc;
using Rotativa.MVC;
using SM.LibreriaComun.DTO.Certificacion;
using System;
using DevExpress.Web.Mvc;
using SM.LibreriaComun.DTO.Notificacion;
using SM.Aplicacion.Notificacion;
using System.Collections.Generic;
using WebSImus.Models;

namespace WebSImus.Controllers
{
    public class CertificacionController : BaseController
    {
        // GET: Certificacion
        public ActionResult CertificadoPdf(int Id, string Modulo)
        {
            var model = new CertificacionDTO();
            string nombreArchivo = "Certificacion" + Modulo + DateTime.Today.ToString("dd/MM/yyyy") + ".pdf";

            model = Translator.TranslatorCertificacion.ObtenerModeloactor(Id, Modulo);
            if (model != null)
                Translator.TranslatorCertificacion.AgregarHistoricoCertificacion(Id, Modulo, model.estadoId, model.Estado, NombreCompletoUsuario, Convert.ToInt32(UsuaroId));

            return new ViewAsPdf("CertificadoPdf", model)
            {
                FileName = nombreArchivo


            };
        }

        public ActionResult Index(int Id, string Modulo)
        {
            var model = new CertificacionModel();
            model.Id = Id;
            model.modulo = Modulo;

            return View(model);
        }

        private GridViewSettings GetGridSettings()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridCertificacion";
            settings.CallbackRouteValues = new { Controller = "Certifcacion", Action = "GridViewPartial" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "Certificacion" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "Id";
            settings.Columns.Add("Tipo");
            settings.Columns.Add("NombreUsuario");
            settings.Columns.Add("NombreEstado");
            settings.Columns.Add("FechaRegistro");
            settings.Columns.Add("Motivo");
        
            return settings;
        }

        public ActionResult GridViewPartial(string Id = null, string Modulo = null)
        {
            ViewBag.GridSettings = GetGridSettings();
            var model = new List<NotificacionDTO>();
            model = ObtenerMisregistros(Id, Modulo);

            return PartialView("_GridViewPartial", model);
        }

        private List<NotificacionDTO> ObtenerMisregistros(string Id = null, string Modulo = null)
        {
            var model = new List<NotificacionDTO>();

            if (string.IsNullOrEmpty(Modulo))
            {
                if (TempData["TipoRegistroA"] != null)
                    Modulo = TempData["TipoRegistroA"].ToString();
                else
                    Modulo = "Escuelas";
            }

            if (Modulo == Comunes.ConstantesRecursosBD.ACTORES_AGENTES)
                model = NotificacionNeg.ConsultarPorAgenteId(Convert.ToInt32(Id));
            else if (Modulo == Comunes.ConstantesRecursosBD.ACTORES_AGRUPACIONES)
                model = NotificacionNeg.ConsultarPorAgrupacionId(Convert.ToInt32(Id));
            else if (Modulo == Comunes.ConstantesRecursosBD.ACTORES_ENTIDADES)
                model = NotificacionNeg.ConsultarPorEntidadId(Convert.ToInt32(Id));
            else if (Modulo == Comunes.ConstantesRecursosBD.ACTORES_ESCUELAS)
                model = NotificacionNeg.ConsultarPorEscuelaId(Convert.ToInt32(Id));

            return model;
        }
    }
}