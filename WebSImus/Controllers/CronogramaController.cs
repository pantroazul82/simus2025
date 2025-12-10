using DevExpress.Web.Mvc;
using SM.Aplicacion.Basicas;
using SM.Aplicacion.EntidadesOpeadoras;
using SM.Aplicacion.Escuelas;
using SM.Aplicacion.Servicios;
using SM.LibreriaComun.DTO;
using SM.LibreriaComun.DTO.EntidadesOperadoras;
using SM.Utilidades.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DevExpress.Export;
using DevExpress.Web;
using DevExpress.XtraPrinting;
using System.Text.RegularExpressions;
using SM.Aplicacion.Documentos;
using System.Web;
using System.IO;


namespace WebSImus.Controllers
{
    [HandleError()]
    [SessionExpire]
    public class CronogramaController : BaseController
    {
        // GET: Cronograma

        #region Documentos
        [HttpPost]
        public JsonResult AgregarDocumento(int id, string cat)
        {
            bool isSuccess = true;

            if (string.IsNullOrEmpty(cat))
                return Json(new { Response = "Error" });

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

                    int UsuarioId = Convert.ToInt32(UsuaroId);

                    var registro = new DocumentoDTO
                    {
                        NombreArchivo = file.FileName,
                        ExtensionArchivo = Path.GetExtension(file.FileName),
                        BytesArchivo = data,
                        TamanoArchivo = data.Length,
                        TipoContenido = file.ContentType,
                        FechaRegistro = DateTime.Now,
                        UsuarioId = UsuarioId,
                    };

                    EscuelaDocumentosNeg.CrearDocumentoCronograma(registro, id, cat, Convert.ToInt32(UsuaroId));
                }
            }

            return Json(isSuccess);

        }
        public ActionResult TablaDocumentos(int Id, int EliminarId)
        {
            var modeltabla = new List<EscuelaDocumentoDTO>();

            if (EliminarId > 0)
            {
                EscuelaDocumentosNeg.EliminarDocumentoCronograma(EliminarId);
            }

            modeltabla = EscuelaDocumentosNeg.ConsultarDocumentosCronograma(Id);

            return PartialView("_TablaDocumentos", modeltabla);
        }
        #endregion

        #region Dotacion

        public JsonResult obtenerElemento(string tipo = null)
        {

            List<BasicaDTO> listInstrumentos = new List<BasicaDTO>();

          

            if (!String.IsNullOrEmpty(tipo))
            {
               // int categoriaId = ConvocatoriaNeg.ObtenerCategoriaId(Convert.ToInt32(tipo));

                int categoriaId = Convert.ToInt32(tipo);
                if (categoriaId == 218)
                {
                    listInstrumentos = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_CATEGORIAS_INSTRUMENTOS);
                    ViewBag.listElemento = new SelectList(listInstrumentos, "value", "text");
                }
                else if (categoriaId == 219)
                {
                    listInstrumentos = new List<BasicaDTO>();
                    listInstrumentos = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_ACCESORIO);
                    ViewBag.listElemento = new SelectList(listInstrumentos, "value", "text");
                }
                else if (categoriaId == 220)
                {
                    listInstrumentos = new List<BasicaDTO>();
                    listInstrumentos = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_OTROS_ELEMETOS);
                    ViewBag.listElemento = new SelectList(listInstrumentos, "value", "text");
                }

            }

            var data = listInstrumentos;
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult _AgregarDotacion(string id, string CronogramaId)
        {
            var model = new DotacionDTO();
            List<BasicaDTO> listInstrumentos = new List<BasicaDTO>();
            List<BasicaDTO> listFormato = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_FORMATO);
            ViewBag.listFormato = new SelectList(listFormato, "value", "text");

            List<BasicaDTO> listTipoDotacion = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_TIPO_DOTACION);
            ViewBag.listTipoDotacion = new SelectList(listTipoDotacion, "value", "text");
            ViewBag.listElemento = new SelectList(listInstrumentos, "value", "text");
         
            if (!string.IsNullOrEmpty(id))
            {
                model.Id = Convert.ToInt32(id);
                model = SM.Aplicacion.EntidadesOpeadoras.DotacionConvenioNeg.ConsultarPorId(Convert.ToInt32(id));
                int categoriaId = Convert.ToInt32(model.TipoId);
                if (categoriaId == 218)
                {
                    listInstrumentos = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_CATEGORIAS_INSTRUMENTOS);
                    ViewBag.listElemento = new SelectList(listInstrumentos, "value", "text");
                }
                else if (categoriaId == 219)
                {
                    listInstrumentos = new List<BasicaDTO>();
                    listInstrumentos = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_ACCESORIO);
                    ViewBag.listElemento = new SelectList(listInstrumentos, "value", "text");
                }
                else if (categoriaId == 220)
                {
                    listInstrumentos = new List<BasicaDTO>();
                    listInstrumentos = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_OTROS_ELEMETOS);
                    ViewBag.listElemento = new SelectList(listInstrumentos, "value", "text");
                }

            }

            if (!string.IsNullOrEmpty(CronogramaId))
            {
                model.CronogramaId = CronogramaId;
            }

            return PartialView("_AgregarDotacion", model);
        }

        [HttpPost]
        public JsonResult AgregarDotacion(string Id, string CronogramaId, DotacionDTO model)
        {
            bool isSuccess = true;

            DotacionDTO registro = new DotacionDTO
            {
                CronogramaId = CronogramaId,
               TipoId = model.TipoId,
               ElementoId = model.ElementoId,
               FormatoId = model.FormatoId,
               Marca = model.Marca,
               Aprobado = model.Aprobado,
               Diagnostico = model.Diagnostico,
               Garantia = model.Garantia,
               Precio = model.Precio,
               Referencia = model.Referencia,
               Serial = model.Serial,
               Proveedor = model.Proveedor,
               Descripcion = model.Descripcion,
                UsuarioId = Convert.ToInt32(UsuaroId)
            };
            if (String.IsNullOrEmpty(Id) || (Id == "0"))
                DotacionConvenioNeg.Crear(registro, Convert.ToInt32(UsuaroId));
            else
                DotacionConvenioNeg.Actualizar(Convert.ToInt32(Id), registro, Convert.ToInt32(UsuaroId));

            return Json(isSuccess);
        }
        public ActionResult TablaDotacion(string CronogramaId, int EliminarId)
        {
            var listado = new List<DotacionDTO>();
            if (EliminarId > 0)
            {
                DotacionConvenioNeg.Eliminar(EliminarId);
            }

            listado = SM.Aplicacion.EntidadesOpeadoras.DotacionConvenioNeg.ConsultarPorCronogramaId(Convert.ToInt32(CronogramaId));

            return PartialView("_TablaDotacion", listado);
        }

        [Route("Cronograma/{id? : int}")]
        //[Authorize]
        public ActionResult Exportar(int Id)
        {
            decimal escuelaId = Id;
            string strNombre = "";

            byte[] bytes = Helpers.GenerarArchivo.ObtenerActaDotacion(Id, out strNombre);
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = "application/vnd.ms-excel";
            string file = MakeValidFileName(strNombre);
            Response.AddHeader("content-disposition", "attachment;filename=\"" + file + "\"");
            Response.BinaryWrite(bytes);
            Response.Flush();

            return null;

        }

        public static string MakeValidFileName(string name)
        {
            string invalidChars = Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()));
            string invalidReStr = string.Format(@"[{0}]+", invalidChars);
            string replace = Regex.Replace(name, invalidReStr, "_").Replace(";", "").Replace(",", "");
            return replace;
        }
        #endregion
        public ActionResult Index(int Id)
        {
            var model = new CronogramaDTO();
            model.ActividadId = Id;
            var actividad = ActividadNeg.ConsultarPorId(model.ActividadId);
            if (actividad != null)
            {
                model.Nombreactividad = actividad.Nombre;
                model.TipoActividadID = actividad.TipoActividadId;
            }
                    
            ViewData["ActividadId"] = Id;
            return View(model);
        }
        public ActionResult Crear(int Id)
        {
            var model = new CronogramaDTO();
            model.ActividadId = Id;
            var actividad = ActividadNeg.ConsultarPorId(model.ActividadId);
            if (actividad != null)
            {
                model.Nombreactividad = actividad.Nombre;
                model.TipoActividadID = actividad.TipoActividadId;
            }
                    
            CargarDatosBasicos("", "");
            return View(model);
        }

        // POST: Convenio/Create
        [HttpPost]
        public ActionResult Crear(CronogramaDTO datos)
        {
            int registroId = 0;
            if (ModelState.IsValid)
            {
                registroId = CronogramaNeg.Crear(datos, Convert.ToInt32(UsuaroId));
            }
            else
            {
                CargarDatosBasicos(datos.Cod_departamento, datos.Municipio);
                datos.Nombreactividad = CronogramaNeg.ObtenerNombreActividad(datos.ActividadId);
                var actividad = ActividadNeg.ConsultarPorId(datos.ActividadId);
                if (actividad != null)
                {
                    datos.Nombreactividad = actividad.Nombre;
                    datos.TipoActividadID = actividad.TipoActividadId;
                }
                return View("Crear", datos);
            }

            return RedirectToAction("Editar", "Cronograma", new { Id = registroId });

        }

        public ActionResult CargarAgentesResponsable(int cronogramaId, int EliminarId)
        {
            var listado = new List<EstandarDTO>();
            if (EliminarId > 0)
            {
                CronogramaNeg.EliminarAgente(EliminarId);
            }

            listado = CronogramaNeg.ConsultarAgentesCronograma(cronogramaId, 1);

            return PartialView("_TablaResponsable", listado);
        }

        public ActionResult CargarAgentesParticipantes(int cronogramaId, int EliminarId)
        {
            var listado = new List<EstandarDTO>();
            if (EliminarId > 0)
            {
                CronogramaNeg.EliminarAgente(EliminarId);
            }

            listado = CronogramaNeg.ConsultarAgentesCronograma(cronogramaId, 2);

            return PartialView("_TablaParticipantes", listado);
        }

        [HttpPost]
        public JsonResult agregaragente(string atributo,
                                         string cronogramaId, string tipoid)
        {
            bool isSuccess = true;

            if (string.IsNullOrEmpty(atributo))
                return Json(new { Response = "Error" });

            CronogramaNeg.AgregarAgente(Convert.ToInt32(cronogramaId), atributo, Convert.ToInt32(tipoid), Convert.ToInt32(UsuaroId));

            return Json(isSuccess);

        }


       

        // GET: Convenio/Edit/5
        public ActionResult Editar(int id)
        {
            var model = new CronogramaDTO();
            model = CronogramaNeg.ConsultarPorId(id);
            CargarDatosBasicos(model.Cod_departamento, model.Cod_municipio);
            var actividad = ActividadNeg.ConsultarPorId(model.ActividadId);
            if (actividad != null)
            {
                model.Nombreactividad = actividad.Nombre;
                model.TipoActividadID = actividad.TipoActividadId;
            }
            var documentos = new CronogramaDocumentoModels();
            documentos.CronogramaId = id;
            model.Documentos = documentos;
            List<BasicaDTO> listAsociado = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_CRONOGRAMA_DOCUMENTO);
            ViewBag.listCategoria = new SelectList(listAsociado, "value", "text");
            return View(model);
        }

        // POST: Convenio/Edit/5
        [HttpPost]
        public ActionResult Editar(int id, CronogramaDTO datos)
        {
            if (ModelState.IsValid)
            {
                CronogramaNeg.Actualizar(id, datos, Convert.ToInt32(UsuaroId));
            }
            else
            {
                CargarDatosBasicos(datos.Cod_departamento, datos.Cod_municipio);
                var actividad = ActividadNeg.ConsultarPorId(datos.ActividadId);
                if (actividad != null)
                {
                    datos.Nombreactividad = actividad.Nombre;
                    datos.TipoActividadID = actividad.TipoActividadId;
                }
                Warning(string.Format("<b></b> Inconsitencia en los datos  "), true);
                return View("Editar", datos);
            }

            return RedirectToAction("Index", "Cronograma", new { Id = datos.ActividadId });

        }
        private GridViewSettings GetGridSettings()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridCronograma";
            settings.CallbackRouteValues = new { Controller = "Cronograma", Action = "GridViewPartial" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "Cronograma" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "Id";
            settings.Columns.Add("Nombre");
            settings.Columns.Add("Departamento");
            settings.Columns.Add("Municipio");
            settings.Columns.Add("FechaInicio");
            settings.Columns.Add("FechaFin");
            settings.Columns.Add("Cupo");


            return settings;
        }


        [ValidateInput(false)]
        public ActionResult GridViewPartial(int Id)
        {
            ViewBag.GridSettings = GetGridSettings();
            var model = ObtenerDatos(Id);
            ViewData["ActividadId"] = Id;
            return PartialView("_GridViewPartial", model);
        }

        public ActionResult ExportTo(int Id, string OutputFormat)
        {
            var model = ObtenerDatos(Id);
            ViewData["ActividadId"] = Id;
            return GridViewExtension.ExportToXls(GetGridSettings(), model.ToList());
        }
        #region privada
        private void CargarDatosBasicos(string codigoDepartamento, string codMunicipio)
        {
            var objMunicipios = new List<BasicaDTO>();
            var objDepartamentos = new List<BasicaDTO>();
            var objEscuelas = new List<BasicaDTO>();

            objDepartamentos = ZonaGeograficasLogica.ConsultarDepartamentos();
            if (!string.IsNullOrEmpty(codigoDepartamento))
            {
                objMunicipios = ZonaGeograficasLogica.ConsultarMunicipios(codigoDepartamento);
                if (!string.IsNullOrEmpty(codMunicipio))
                {
                    objEscuelas = EscuelasLogica.ConsultarEscuelaMunicipios(codMunicipio);
                }
            }


            ViewBag.listDepartamentos = new SelectList(objDepartamentos, "value", "text");
            ViewBag.listMunicipio = new SelectList(objMunicipios, "value", "text");
            ViewBag.listEscuelas = new SelectList(objEscuelas, "value", "text");
        }

        public JsonResult ObtenerEscuela(string municipio = null)
        {

            var listado = new List<BasicaDTO>();

            if (!String.IsNullOrEmpty(municipio))
            {
                listado = EscuelasLogica.ConsultarEscuelaMunicipios(municipio);
            }

            var data = listado;
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        private List<CronogramaDTO> ObtenerDatos(int Id)
        {
            var model = new List<CronogramaDTO>();
            model = CronogramaNeg.ConsultarPorActividadId(Id);

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


            var model = new HandleErrorInfo(filterContext.Exception, "Cronograma", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }
        #endregion
    }
}