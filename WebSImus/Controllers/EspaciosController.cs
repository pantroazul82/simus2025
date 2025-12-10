using DevExpress.Web.Mvc;
using SM.Aplicacion.Basicas;
using SM.Aplicacion.Documentos;
using SM.Aplicacion.Entidades;
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
using WebSImus.Models;

namespace WebSImus.Controllers
{
    [HandleError()]
    [SessionExpire]
    public class EspaciosController : BaseController
    {

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


                    int EscenarioId = Convert.ToInt32(id);
                    var modeltabla = EsnecariosNeg.ConsultarImagenes(EscenarioId);
                    bool Esprincipal = true;
                    if (modeltabla != null && modeltabla.Count > 0)
                        Esprincipal = false;

                    EsnecariosNeg.CrearImagen(EscenarioId, data, Esprincipal);
                }
            }


            //}


            return Json(isSuccess);

        }
        public ActionResult TablaImagenes(int Id, int EliminarId)
        {
            var modeltabla = new List<ImagenDataDTO>();

            if (EliminarId > 0)
            {
                EsnecariosNeg.EliminarImagen(EliminarId);
            }

            modeltabla = EsnecariosNeg.ConsultarImagenes(Id);

            return PartialView("_TablaImagenes", modeltabla);
        }
        #region Crear


        public ActionResult Crear()
        {

            var model = new EscenarioDTO();

            CargaInicial(model.CodDepartamento, model.codMunicipio);
            List<BasicaDTO> listAsociado = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_CATEGORIAS_ACTORES);
            List<BasicaDTO> listActor = new List<BasicaDTO>();
            ViewBag.listCategoria = new SelectList(listAsociado, "value", "text");
            ViewBag.listActores = new SelectList(listActor, "value", "text");
            List<EstandarDTO> listDirigido = ConvocatoriaNeg.ConsultarParametrosOrdenarPorId(Comunes.ConstantesRecursosBD.CODIGO_DIAS_SEMANA);
            model.DirigidoAData = listDirigido;
            return View(model);
        }
        [HttpPost]
        public ActionResult Crear(EscenarioDTO model)
        {
            if (ModelState.IsValid)
            {
                int EscenarioId = EsnecariosNeg.Crear(model, Convert.ToInt32(UsuaroId));
                if (model.Documento != null)
                {
                    int DocumentoId = CrearDocumento(Convert.ToInt32(UsuaroId), NombreCompletoUsuario, model.Documento);

                    if (DocumentoId > 0)
                    {
                        EsnecariosNeg.ActualizarDocumento(EscenarioId, DocumentoId);
                    }


                }
                return RedirectToAction("Editar", "Espacios", new { Id = EscenarioId });
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

            var model = new EscenarioDTO();
            model = EsnecariosNeg.ConsultarPorId(Id);


            List<EstandarDTO> listDirigido = ConvocatoriaNeg.ConsultarParametrosOrdenarPorId(Comunes.ConstantesRecursosBD.CODIGO_DIAS_SEMANA);
            model.DirigidoAData = listDirigido;
            model.DirigidoASeleccionada = EsnecariosNeg.ConsultarDiasSemana(Id);
            return View(model);
        }
        public ActionResult Editar(int Id)
        {

            var model = new EscenarioDTO();
            model = EsnecariosNeg.ConsultarPorId(Id);
            if (model.UsuarioId != Convert.ToInt32(UsuaroId))
                return RedirectToAction("Detalle", "Espacios", new { Id = Id });

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
            List<EstandarDTO> listDirigido = ConvocatoriaNeg.ConsultarParametrosOrdenarPorId(Comunes.ConstantesRecursosBD.CODIGO_DIAS_SEMANA);
            model.DirigidoAData = listDirigido;
            model.DirigidoASeleccionada = EsnecariosNeg.ConsultarDiasSemana(Id);
            var modelImagen = new SM.LibreriaComun.DTO.Circulacion.ImagenesModels();
            modelImagen.EscenarioId = Id;
            model.Imagenes = modelImagen;
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(int Id, EscenarioDTO model)
        {
            if (ModelState.IsValid)
            {
                // para quede en estado 3;
                model.EstadoId = "3";
                EsnecariosNeg.Actualizar(Id, model, Convert.ToInt32(UsuaroId));
                if (model.Documento != null)
                {
                    int DocumentoId = CrearDocumento(Convert.ToInt32(UsuaroId), NombreCompletoUsuario, model.Documento);

                    if (DocumentoId > 0)
                    {
                        EsnecariosNeg.ActualizarDocumento(Id, DocumentoId);
                        model.documentoArchivo = EsnecariosNeg.ConsultaDocumento(DocumentoId);
                    }


                }

            }

            CargaInicialActualizar(model.CodDepartamento, model.codMunicipio, model.Tipo, model.EsAdmin);

            List<EstandarDTO> listDirigido = ConvocatoriaNeg.ConsultarParametrosOrdenarPorId(Comunes.ConstantesRecursosBD.CODIGO_DIAS_SEMANA);
            model.DirigidoAData = listDirigido;
            model.DirigidoASeleccionada = EsnecariosNeg.ConsultarDiasSemana(Id);

            var modelImagen = new SM.LibreriaComun.DTO.Circulacion.ImagenesModels();
            modelImagen.EscenarioId = Id;
            model.Imagenes = modelImagen;
            return View(model);
        }

        public ActionResult CambiarEstado(int Id)
        {

            var model = new EscenarioDTO();
            model = EsnecariosNeg.ConsultarPorId(Id);

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
            List<EstandarDTO> listDirigido = ConvocatoriaNeg.ConsultarParametrosOrdenarPorId(Comunes.ConstantesRecursosBD.CODIGO_DIAS_SEMANA);
            model.DirigidoAData = listDirigido;
            model.DirigidoASeleccionada = EsnecariosNeg.ConsultarDiasSemana(Id);
            var modelImagen = new SM.LibreriaComun.DTO.Circulacion.ImagenesModels();
            modelImagen.EscenarioId = Id;
            model.Imagenes = modelImagen;
            return View(model);
        }

        [HttpPost]
        public ActionResult CambiarEstado(int Id, EscenarioDTO model)
        {
            if (ModelState.IsValid)
            {
                EsnecariosNeg.Actualizar(Id, model, Convert.ToInt32(UsuaroId));
                if (model.Documento != null)
                {
                    int DocumentoId = CrearDocumento(Convert.ToInt32(UsuaroId), NombreCompletoUsuario, model.Documento);

                    if (DocumentoId > 0)
                    {
                        EsnecariosNeg.ActualizarDocumento(Id, DocumentoId);
                        model.documentoArchivo = EsnecariosNeg.ConsultaDocumento(DocumentoId);
                    }


                }

            }

            CargaInicialActualizar(model.CodDepartamento, model.codMunicipio, model.Tipo, model.EsAdmin);
            List<BasicaDTO> objTipo = CaracterizacionMusicalNeg.ConsultarEstados();
            ViewBag.listEstado = new SelectList(objTipo, "value", "text");
            List<EstandarDTO> listDirigido = ConvocatoriaNeg.ConsultarParametrosOrdenarPorId(Comunes.ConstantesRecursosBD.CODIGO_DIAS_SEMANA);
            model.DirigidoAData = listDirigido;
            model.DirigidoASeleccionada = EsnecariosNeg.ConsultarDiasSemana(Id);
            var modelImagen = new SM.LibreriaComun.DTO.Circulacion.ImagenesModels();
            modelImagen.EscenarioId = Id;
            model.Imagenes = modelImagen;
            return View(model);
        }
        #endregion

        #region MetodoPrivados
        private void CargaInicial(string codigoDepartamento, string codigoMunicipio)
        {

            var objMunicipios = new List<BasicaDTO>();
            var objDepartamentos = new List<BasicaDTO>();

            objDepartamentos = ZonaGeograficasLogica.ConsultarDepartamentos();
            if (!string.IsNullOrEmpty(codigoDepartamento))
            {
                objMunicipios = ZonaGeograficasLogica.ConsultarMunicipios(codigoDepartamento);
            }

            List<BasicaDTO> listClasificacion = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_TIPO_ESCENARIOS);
            ViewBag.listClasificacion = new SelectList(listClasificacion, "value", "text");
            ViewBag.listDepartamentos = new SelectList(objDepartamentos, "value", "text");
            ViewBag.listMunicipio = new SelectList(objMunicipios, "value", "text");

        }

        private void CargaInicialActualizar(string codigoDepartamento, string codigoMunicipio, string TipoActorId, bool admin)
        {

            var objMunicipios = new List<BasicaDTO>();
            var objDepartamentos = new List<BasicaDTO>();

            objDepartamentos = ZonaGeograficasLogica.ConsultarDepartamentos();
            if (!string.IsNullOrEmpty(codigoDepartamento))
            {
                objMunicipios = ZonaGeograficasLogica.ConsultarMunicipios(codigoDepartamento);
            }

            List<BasicaDTO> listClasificacion = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_TIPO_ESCENARIOS);
            ViewBag.listClasificacion = new SelectList(listClasificacion, "value", "text");
            ViewBag.listDepartamentos = new SelectList(objDepartamentos, "value", "text");
            ViewBag.listMunicipio = new SelectList(objMunicipios, "value", "text");

            List<BasicaDTO> listAsociado = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_CATEGORIAS_ACTORES);
            ViewBag.listCategoria = new SelectList(listAsociado, "value", "text");
            List<BasicaDTO> listActor;
            if (admin)
                listActor = ObtenerActorAdministrador(TipoActorId);
            else
                listActor = ObtenerActor(TipoActorId);

            ViewBag.listActores = new SelectList(listActor, "value", "text");

        }
        private List<BasicaDTO> ObtenerActor(string tipo)
        {

            var listActor = new List<BasicaDTO>();

            if (!String.IsNullOrEmpty(tipo))
            {
                if (Convert.ToInt32(tipo) == Comunes.ConstantesRecursosBD.CODIGO_ACTORES_AGENTES)
                    listActor = CaracterizacionMusicalNeg.ConsultarAgentes(Convert.ToInt32(UsuaroId));
                else if (Convert.ToInt32(tipo) == Comunes.ConstantesRecursosBD.CODIGO_ACTORES_ENTIDADES)
                    listActor = CaracterizacionMusicalNeg.ConsultarEntidadPorUsuarioId(Convert.ToInt32(UsuaroId));
                else if (Convert.ToInt32(tipo) == Comunes.ConstantesRecursosBD.CODIGO_ACTORES_AGRUPACIONES)
                    listActor = CaracterizacionMusicalNeg.ConsultarAgrupacionPorUsuarioId(Convert.ToInt32(UsuaroId));
                else if (Convert.ToInt32(tipo) == Comunes.ConstantesRecursosBD.CODIGO_ACTORES_ESCUELAS)
                {
                    decimal UsuarioSipaId = SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.ObtenerUsuarioSipaId(Usuario);
                    listActor = CaracterizacionMusicalNeg.ConsultarEscuelasPorUsuarioId(UsuarioSipaId);
                }

            }

            return listActor;
        }

        private List<BasicaDTO> ObtenerActorAdministrador(string tipo)
        {

            var listActor = new List<BasicaDTO>();

            if (!String.IsNullOrEmpty(tipo))
            {
                if (Convert.ToInt32(tipo) == Comunes.ConstantesRecursosBD.CODIGO_ACTORES_AGENTES)
                    listActor = CaracterizacionMusicalNeg.ConsultarAgentesAdmin();
                else if (Convert.ToInt32(tipo) == Comunes.ConstantesRecursosBD.CODIGO_ACTORES_ENTIDADES)
                    listActor = CaracterizacionMusicalNeg.ConsultarEntidadAdmin();
                else if (Convert.ToInt32(tipo) == Comunes.ConstantesRecursosBD.CODIGO_ACTORES_AGRUPACIONES)
                    listActor = CaracterizacionMusicalNeg.ConsultarAgrupacionAdmin();
                else if (Convert.ToInt32(tipo) == Comunes.ConstantesRecursosBD.CODIGO_ACTORES_ESCUELAS)
                {

                    listActor = CaracterizacionMusicalNeg.ConsultarEscuelasAdmin();
                }

            }

            return listActor;
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
            var model = new List<EspacioDataDTO>();
            string Busqueda = "";
            model = ObtenerMisregistros(Busqueda);
            return GridViewExtension.ExportToXls(GetGridSettings(), model.ToList());

        }

        public ActionResult ExportToPermisos(string OutputFormat)
        {
            var model = new List<EspacioDataDTO>();
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
            settings.SettingsExport.FileName = "Espacios" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "Id";
            settings.Columns.Add("Departamento");
            settings.Columns.Add("Municipio");
            settings.Columns.Add("Nombre");
            settings.Columns.Add("NombreActor");
            settings.Columns.Add("RelacionadoA");
            settings.Columns.Add("Estado");
            settings.Columns.Add("FechaCreacion");
            settings.Columns.Add("FechaActualizacion");
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
            settings.SettingsExport.FileName = "Espacios" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "Id";
            settings.Columns.Add("Departamento");
            settings.Columns.Add("Municipio");
            settings.Columns.Add("Nombre");
            settings.Columns.Add("NombreActor");
            settings.Columns.Add("RelacionadoA");
            settings.Columns.Add("Estado");
            return settings;
        }
        public ActionResult GridViewPartial(string Busqueda = null, string filtro = null)
        {
            ViewBag.GridSettings = GetGridSettings();
            var model = new List<EspacioDataDTO>();
            model = ObtenerMisregistros(Busqueda);

            return PartialView("_GridViewPartial", model);
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartialPermisos()
        {
            ViewBag.GridSettings = GetGridSettingsPermisos();
            var model = new List<EspacioDataDTO>();

            model = ObtenerResultadoGestion();

            return PartialView("_GridViewPartialPermisos", model);
        }
        private List<EspacioDataDTO> ObtenerMisregistros(string Busqueda = null)
        {
            var model = new List<EspacioDataDTO>();

            if (string.IsNullOrEmpty(Busqueda))
            {
                if (TempData["TipoRegistroA"] != null)
                    Busqueda = TempData["TipoRegistroA"].ToString();
                else
                    Busqueda = "1";
            }

            if (Busqueda == "1")
            {
                model = EsnecariosNeg.ConsultarEspaciosPorUsuarioId(Convert.ToInt32(UsuaroId));
                TempData["TipoRegistroA"] = 1;
            }
            else if (Busqueda == "2")
            {
                TempData["TipoRegistroA"] = 2;
                model = EsnecariosNeg.ConsultarEspaciosPorEstadoId(Comunes.ConstantesRecursosBD.CODIGO_ESTADO_PUBLICADO);
            }

            return model;
        }

        private List<EspacioDataDTO> ObtenerResultadoGestion()
        {
            bool EsAdmin = false;
            var model = new List<EspacioDataDTO>();
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
                model = EsnecariosNeg.ConsultarEspaciosTodos();
            else
                model = EsnecariosNeg.ConsultarEspaciosPorMunicipio(Convert.ToInt32(UsuaroId));
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


            var model = new HandleErrorInfo(filterContext.Exception, "Espacios", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }
        #endregion
    }
}