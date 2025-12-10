using DevExpress.Web.Mvc;
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
    public class ActividadController : BaseController
    {
        #region contenido

        public ActionResult _AgregarContenido(string id, string ActividadId)
        {
            var model = new ContenidoDTO();

            if (!string.IsNullOrEmpty(id))
            {
                model.Id = Convert.ToInt32(id);
                model = ContenidoNeg.ConsultarPorId(Convert.ToInt32(id));
                List<BasicaDTO> listNombre = new List<BasicaDTO>();
              
                listNombre.Add(new BasicaDTO { text = "Contenido 1", value = "Contenido 1" });
                listNombre.Add(new BasicaDTO { text = "Contenido 2", value = "Contenido 2" });
                listNombre.Add(new BasicaDTO { text = "Contenido 3", value = "Contenido 3" });
                listNombre.Add(new BasicaDTO { text = "Contenido 4", value = "Contenido 4" });
                listNombre.Add(new BasicaDTO { text = "Contenido 5", value = "Contenido 5" });
                ViewBag.listNombre = new SelectList(listNombre, "value", "text");
            }

            if (!string.IsNullOrEmpty(ActividadId))
            {
                model.ActividadId = ActividadId;
            }
          
            return PartialView("_AgregarContenido", model);
        }
        [HttpPost]
        public JsonResult AgregarContenido(string Id, string ActividadId, ContenidoDTO model)
        {
            bool isSuccess = true;

            ContenidoDTO registro = new ContenidoDTO
            {
                ActividadId = model.ActividadId,
                DescripcionContenido = model.DescripcionContenido,
                NombreContenido = model.NombreContenido,
                UsuarioId = Convert.ToInt32(UsuaroId)
            };
            if (String.IsNullOrEmpty(Id) || (Id == "0"))
                ContenidoNeg.Crear(registro, Convert.ToInt32(UsuaroId));
            else
                ContenidoNeg.Actualizar(Convert.ToInt32(Id), registro, Convert.ToInt32(UsuaroId));

            return Json(isSuccess);
        }
        public ActionResult TablaContenido(string ActividadId, int EliminarId)
        {
            var listado = new List<ContenidoDTO>();
            if (EliminarId > 0)
            {
                ContenidoNeg.Eliminar(EliminarId);
            }

            listado = ContenidoNeg.ConsultarPorActividadId(Convert.ToInt32(ActividadId));

            return PartialView("_TablaContenido", listado);
        }
        #endregion
        public ActionResult DatosConvenio(int Id)
        {
            var model = ConvenioNeg.ConsultarPorId(Id);

            return PartialView("_DatosConvenio", model);
        }
        // GET: Actividad
        public ActionResult Index(int Id)
        {
            var model = new ActividadDTO();
            model.ConvenioId = Id;
            ViewData["ConvenioId"] = Id;
            return View(model);
        }


        // GET: Convenio/Create
        public ActionResult Crear(int Id)
        {
            var model = new ActividadDTO();
            model.ConvenioId = Id;
            var datos = ConvenioNeg.ConsultarPorId(Id);
            model.NombreEntidad = datos.NombreEntidad;
            model.NumeroConvenio = datos.Nombre; 
            CargarDatosBasicos();
            return View(model);
        }

        // POST: Convenio/Create
        [HttpPost]
        public ActionResult Crear(ActividadDTO datos)
        {

            if (ModelState.IsValid)
            {
               int Id = ActividadNeg.Crear(datos, Convert.ToInt32(UsuaroId));

                if (datos.DocumentoEPK != null)
                {
                    int DocumentoId = CrearDocumento(Convert.ToInt32(UsuaroId), NombreCompletoUsuario, datos.DocumentoEPK);

                    if (DocumentoId > 0)
                    {
                        ActividadNeg.ActualizarDocumento(Id, DocumentoId);
                    }


                }
            }
            else
            {
                var datosconvenio = ConvenioNeg.ConsultarPorId(datos.ConvenioId);
                datos.NombreEntidad = datosconvenio.NombreEntidad;
                datos.NumeroConvenio = datosconvenio.Nombre; 
                CargarDatosBasicos();
                return View("Crear", datos);
            }

            return RedirectToAction("Index", "Actividad", new { Id = datos.ConvenioId });
          
        }

        // GET: Convenio/Edit/5
        public ActionResult Editar(int id)
        {
            var model = new ActividadDTO();
            CargarDatosBasicos();
            model = ActividadNeg.ConsultarPorId(id);
            var datos = ConvenioNeg.ConsultarPorId(model.ConvenioId);
            model.NombreEntidad = datos.NombreEntidad;
            model.NumeroConvenio = datos.Nombre; 
            
            return View(model);
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

        // POST: Convenio/Edit/5
        [HttpPost]
        public ActionResult Editar(int id, ActividadDTO datos)
        {
            if (ModelState.IsValid)
            {
                ActividadNeg.Actualizar(id, datos, Convert.ToInt32(UsuaroId));
                if (datos.DocumentoEPK != null)
                {
                    int DocumentoId = CrearDocumento(Convert.ToInt32(UsuaroId), NombreCompletoUsuario, datos.DocumentoEPK);

                    if (DocumentoId > 0)
                    {
                        ActividadNeg.ActualizarDocumento(id, DocumentoId);
                    }


                }
            }
            else
            {
                CargarDatosBasicos();
                var datosconvenio = ConvenioNeg.ConsultarPorId(datos.ConvenioId);
                datos.NombreEntidad = datosconvenio.NombreEntidad;
                datos.NumeroConvenio = datosconvenio.Nombre; 
                Warning(string.Format("<b></b> Inconsitencia en los datos  "), true);
                return View("Editar", datos);
            }

            return RedirectToAction("Index", "Actividad", new { Id = datos.ConvenioId });
          
        }

        private GridViewSettings GetGridSettings()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridActividad";
            settings.CallbackRouteValues = new { Controller = "Actividad", Action = "GridViewPartial" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "Actividades" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "Id";
            settings.Columns.Add("Nombre");
            settings.Columns.Add("NombreTipoActividad");
            settings.Columns.Add("ValorEjecutado");
            settings.Columns.Add("ValorProgramado");
            settings.Columns.Add("NumeroDias");


            return settings;
        }


        [ValidateInput(false)]
        public ActionResult GridViewPartial(int Id)
        {
            ViewBag.GridSettings = GetGridSettings();
            var model = ObtenerDatos(Id);
            ViewData["ConvenioId"] = Id; 
            return PartialView("_GridViewPartial", model);
        }

        public ActionResult ExportTo(int Id, string OutputFormat)
        {
            var model = ObtenerDatos(Id);
            ViewData["ConvenioId"] = Id;
            return GridViewExtension.ExportToXls(GetGridSettings(), model.ToList());
        }

        #region privada
        private void CargarDatosBasicos()
        {
            List<BasicaDTO> listEstado = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_CATEGORIA_ESTADOS);
            ViewBag.listEstado = new SelectList(listEstado, "value", "text");

            List<BasicaDTO> listTipoActividad = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_TIPO_ACTIVIDAD);
            ViewBag.listTipoActividad = new SelectList(listTipoActividad, "value", "text");
        }

        private List<ActividadDTO> ObtenerDatos(int ConvenioId)
        {
            var model = new List<ActividadDTO>();
            model = ActividadNeg.ConsultarPorConvenioId(ConvenioId);

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


            var model = new HandleErrorInfo(filterContext.Exception, "Actividad", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }
        #endregion

    }
}