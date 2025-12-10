using DevExpress.Web.Mvc;
using SM.Aplicacion.Basicas;
using SM.Aplicacion.Estimulos;
using SM.LibreriaComun.DTO;
using SM.LibreriaComun.DTO.Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSImus.Models;

namespace WebSImus.Controllers
{
    [HandleError()]
    [SessionExpire]
    public class EstimuloController : BaseController
    {
        public ActionResult Editar(int Id)
        {
            var model = new EstimuloModel();
            var resultado = ServicioEstimuloNeg.ConsultarConvocatoriaPorId(Id);
            model = Translator.TranslatorConvocatoria.TranslatorConvocatoriaEstimuloModel(resultado);
            CargaInicial();
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(int Id, EstimuloModel model)
        {

            if (ModelState.IsValid)
            {
                Actualizar(Id, model);

            }

            var resultado = ServicioEstimuloNeg.ConsultarConvocatoriaPorId(Id);
            model = Translator.TranslatorConvocatoria.TranslatorConvocatoriaEstimuloModel(resultado);
            CargaInicial();
            Success(string.Format("<b></b> Se actualizo con éxito: {0}  ", model.Titulo), true);
            return View("Editar", model);
        }
        public ActionResult Crear()
        {
            var model = new EstimuloModel();
            CargaInicial();
            return View(model);
        }



        [HttpPost]
        public ActionResult Crear(EstimuloModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Documento == null)
                {
                    CargaInicial();
                    ModelState.AddModelError("", "El documento es obligatorio");
                    return View(model);
                }
                Guardar(model);
                return RedirectToAction("Index", "Estimulo");
            }
            else
            { CargaInicial(); }
            return View(model);

        }

        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            ViewBag.GridSettings = GetGridSettings();
            var model = ServicioEstimuloNeg.ConsultarTodasLasConvocatoriasEstimulos();

            return PartialView("_GridViewPartial", model);
        }
        public ActionResult ExportTo(string OutputFormat)
        {

            var model = ServicioEstimuloNeg.ConsultarTodasLasConvocatoriasEstimulos();

            return GridViewExtension.ExportToXls(GetGridSettings(), model.ToList());
        }
        private GridViewSettings GetGridSettings()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridEstimulo";
            settings.CallbackRouteValues = new { Controller = "Estimulo", Action = "GridViewPartial" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "Estimulo" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "Id";
            settings.Columns.Add("Titulo");
            settings.Columns.Add("FechaApertura");
            settings.Columns.Add("FechaCierre");
            settings.Columns.Add("FechaPublicacion");
            settings.Columns.Add("Estado");
            settings.Columns.Add("Periodo");
       
            return settings;
        }
        private void CargaInicial()
        {
            var objAnos = new List<BasicaDTO>();
            objAnos = BasicaLogica.ConsultarListadoAnosMusica();
            ViewBag.listAnos = new SelectList(objAnos, "value", "text");
            List<BasicaDTO> listEstado = CaracterizacionMusicalNeg.ConsultarEstados();
            ViewBag.listEstado = new SelectList(listEstado, "value", "text");

        }

        private void Actualizar(int Id, EstimuloModel model)
        {
            byte[] data;
            var documento = new DocumentoDTO();
            if (model != null)
            {
                var datos = new ConvocatoriaEstimuloDTO
                {
                    EstadoId = Convert.ToInt32(model.EstadoId),
                    FechaApertura = Convert.ToDateTime(model.FechaApertura),
                    FechaCierre = Convert.ToDateTime(model.FechaCierre),
                    FechaPublicacion = Convert.ToDateTime(model.FechaPublicacion),
                    Periodo = Convert.ToInt32(model.Periodo),
                    Titulo = model.Titulo,
                    Id = Id,
                    UsuarioId = Convert.ToInt32(UsuaroId)
                };
                if (model.Documento != null && model.Documento.ContentLength > 0)
                {

                    using (Stream inputStream = model.Documento.InputStream)
                    {
                        MemoryStream memoryStream = inputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            inputStream.CopyTo(memoryStream);
                        }

                        data = memoryStream.ToArray();
                    }

                    documento = new DocumentoDTO
                   {
                       NombreArchivo = model.Documento.FileName,
                       ExtensionArchivo = Path.GetExtension(model.Documento.FileName),
                       BytesArchivo = data,
                       TamanoArchivo = data.Length,
                       TipoContenido = model.Documento.ContentType,
                       FechaRegistro = DateTime.Now,
                       UsuarioId = Convert.ToInt32(UsuaroId)
                   };

                }
                ServicioEstimuloNeg.Actualizar(datos, documento, NombreCompletoUsuario, Request.UserHostAddress, Convert.ToInt32(UsuaroId));
            }

        }

        private void Guardar(EstimuloModel model)
        {
            byte[] data;
            if (model != null)
            {
                if (model.Documento != null && model.Documento.ContentLength > 0)
                {
                    var datos = new ConvocatoriaEstimuloDTO
                    {
                        EstadoId = Convert.ToInt32(model.EstadoId),
                        FechaApertura = Convert.ToDateTime(model.FechaApertura),
                        FechaCierre = Convert.ToDateTime(model.FechaCierre),
                        FechaPublicacion = Convert.ToDateTime(model.FechaPublicacion),
                        Periodo = Convert.ToInt32(model.Periodo),
                        Titulo = model.Titulo,
                        UsuarioId = Convert.ToInt32(UsuaroId)
                    };
                    using (Stream inputStream = model.Documento.InputStream)
                    {
                        MemoryStream memoryStream = inputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            inputStream.CopyTo(memoryStream);
                        }

                        data = memoryStream.ToArray();
                    }

                    var documento = new DocumentoDTO
                    {
                        NombreArchivo = model.Documento.FileName,
                        ExtensionArchivo = Path.GetExtension(model.Documento.FileName),
                        BytesArchivo = data,
                        TamanoArchivo = data.Length,
                        TipoContenido = model.Documento.ContentType,
                        FechaRegistro = DateTime.Now,
                        UsuarioId = Convert.ToInt32(UsuaroId)
                    };

                    ServicioEstimuloNeg.Agregar(datos, documento, NombreCompletoUsuario, Request.UserHostAddress, Convert.ToInt32(UsuaroId));
                }
            }

        }
        // GET: Estimulo

    }
}