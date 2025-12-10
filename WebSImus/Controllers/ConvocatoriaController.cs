using DevExpress.Web.Mvc;
using SM.Aplicacion.Basicas;
using SM.Aplicacion.Documentos;
using SM.Aplicacion.Modulo_Usuarios;
using SM.Aplicacion.Servicios;
using SM.LibreriaComun.DTO;
using SM.LibreriaComun.DTO.Servicios;
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
    public class ConvocatoriaController : BaseController
    {
        [HttpPost]
        public JsonResult AgregarParticipacion(string Id, string tipoActor, string actor, string descripcion)
        {
            bool isSuccess = true;

            if (string.IsNullOrEmpty(Id))
                return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(tipoActor))
                return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(actor))
                return Json(new { Response = "Error" });

            var registro = new ParticipacionDetalleDTO
            {
                ActorId = Convert.ToInt32(actor),
                EstadoId = Comunes.ConstantesRecursosBD.CODIGO_ESTADO_DOTACION_INSCRITO,
                ConvocatoriaId = Convert.ToInt32(Id),
                Descipcion = descripcion,
                TipoActorId = Convert.ToInt32(tipoActor),
                UsuarioId = Convert.ToInt32(UsuaroId)
            };

            ParticipacionNeg.AgregarParticipacion(registro);
            return Json(isSuccess);

        }

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

                    EscuelaDocumentosNeg.CrearDocumentoDotacion(registro, id, cat);
                }
            }

            return Json(isSuccess);

        }

        [HttpPost]
        public JsonResult AgregarInstrumento(int id, string instrumento, string prioridad, string cantidad)
        {
            bool isSuccess = true;

            if (string.IsNullOrEmpty(instrumento))
                return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(prioridad))
                return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(cantidad))
                return Json(new { Response = "Error" });

            DotacionNeg.CrearDotacionInstrumento(id, Convert.ToInt32(instrumento), Convert.ToInt32(prioridad), Convert.ToInt32(cantidad));

            return Json(isSuccess);

        }

        public ActionResult TablaDocumentos(int Id, int EliminarId)
        {
            var modeltabla = new List<EscuelaDocumentoDTO>();

            if (EliminarId > 0)
            {
                EscuelaDocumentosNeg.EliminarDocumentoDotacion(EliminarId);
            }

            modeltabla = EscuelaDocumentosNeg.ConsultarDocumentosDotacion(Id);

            return PartialView("_TablaDocumentos", modeltabla);
        }

        public ActionResult TablaInstrumento(int Id, int EliminarId)
        {
            var modeltabla = new List<DotacionInstrumentoDTO>();

            if (EliminarId > 0)
            {
                DotacionNeg.EliminarDotacionInstrumento(EliminarId);
            }

            modeltabla = DotacionNeg.ConsultarInstrumentoDotacion(Id);

            return PartialView("_TablaInstrumentos", modeltabla);
        }

        public ActionResult Participar(int Id)
        {
            var model = new ParicipacionModels();
            model.ConvocatoriaId = Id;
            List<BasicaDTO> listActor= new List<BasicaDTO>();
            List<BasicaDTO> listAsociado = ConvocatoriaNeg.ConsultarCategoriaPorConvocatoria(Id);
            if (listAsociado.Count > 0)
                listActor = ObtenerActor(listAsociado[0].value);
            ViewBag.listCategoria = new SelectList(listAsociado, "value", "text");
            ViewBag.listActores = new SelectList(listActor, "value", "text");
            return PartialView("_Participar", model);
        }
        public JsonResult GetActor(string tipo = null)
        {

            var listActor = new List<BasicaDTO>();

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

            if (!String.IsNullOrEmpty(tipo))
            {
                if (EsAdmin)
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
                else
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
            }

            var data = listActor;
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        // GET: Convocatoria
        public ActionResult Index()
        {
            var model = new ConsultaModel();
            model.TipoRegistro = 2;

            return View(model);
        }

        public ActionResult _ValidacionEscuelas(int Id)
        {
            ViewBag.ConvocatoriaId = ConvocatoriaNeg.ObtenerIdConvocatoriaDotacion();
            string NombreMunicipio = "";
            NombreMunicipio = ConvocatoriaNeg.ObtenerMunicipioPorEntidad(Convert.ToInt32(Id));

            ViewBag.NombreMunicipio = NombreMunicipio;
            return PartialView("_ValidacionEscuelas");
        }

        public ActionResult DetalleDotacion(int Id)
        {
            var modelPadre = new DotacionPadreModel();
            var model = new DotacionModel();
            var documentos = new DotacionDocumentoModels();
            var instrumentos = new InstrumentoModels();
            documentos.DotacionId = Id;
            instrumentos.DotacionId = Id;
            modelPadre.Documentos = documentos;
            modelPadre.Instrumentos = instrumentos;
            var resultado = DotacionNeg.ConsultarDotacionId(Id);
            model = Translator.TranslatorConvocatoria.TranslatorDotacion(resultado);
            string NombreEntidad = ConvocatoriaNeg.ObtenerNombreEntidad(model.EntidadId);
            modelPadre.NombreEntidad = NombreEntidad;
            string NombreEscuela = ConvocatoriaNeg.ObtenerNombreEscuela(Convert.ToInt32(model.EscuelaId));
            ViewBag.NuevoTitulo = NombreEntidad;
            modelPadre.NombreEscuela = NombreEscuela;
            ViewBag.Escuela = NombreEscuela;
            modelPadre.DatosBasicos = model;


            return View(modelPadre);

        }
        public ActionResult Actualizar(int Id)
        {
            var modelPadre = new DotacionPadreModel();
            var model = new DotacionModel();
            var documentos = new DotacionDocumentoModels();
            var instrumentos = new InstrumentoModels();
            documentos.DotacionId = Id;
            instrumentos.DotacionId = Id;
            modelPadre.Documentos = documentos;
            modelPadre.Instrumentos = instrumentos;
            var resultado = DotacionNeg.ConsultarDotacionId(Id);
            model = Translator.TranslatorConvocatoria.TranslatorDotacion(resultado);
            string NombreEntidad = ConvocatoriaNeg.ObtenerNombreEntidad(model.EntidadId);
            modelPadre.NombreEntidad = NombreEntidad;
            string NombreEscuela = ConvocatoriaNeg.ObtenerNombreEscuela(Convert.ToInt32(model.EscuelaId));
            ViewBag.NuevoTitulo = NombreEntidad;
            modelPadre.NombreEscuela = NombreEscuela;
            ViewBag.Escuela = NombreEscuela;
            modelPadre.DatosBasicos = model;
            List<BasicaDTO> listAsociado = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_CATEGORIAS_DOCUMENTOS);
            ViewBag.listCategoria = new SelectList(listAsociado, "value", "text");
            List<BasicaDTO> listInstrumentos = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_CATEGORIAS_INSTRUMENTOS);
            ViewBag.listInstrumento = new SelectList(listInstrumentos, "value", "text");

            List<BasicaDTO> listPrioridad = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_CATEGORIAS_PRIORIDAD);
            ViewBag.listPrioridad = new SelectList(listPrioridad, "value", "text");

            return View(modelPadre);

        }

        [HttpPost]
        public ActionResult Actualizar(int Id, DotacionModel model)
        {
            var modelPadre = new DotacionPadreModel();
            if (ModelState.IsValid)
            {
                ActualizarDotacion(Id, model);

            }
            var documentos = new DotacionDocumentoModels();
            var instrumentos = new InstrumentoModels();
            documentos.DotacionId = Id;
            instrumentos.DotacionId = Id;
            modelPadre.Documentos = documentos;
            modelPadre.Instrumentos = instrumentos;
            List<BasicaDTO> listAsociado = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_CATEGORIAS_DOCUMENTOS);
            ViewBag.listCategoria = new SelectList(listAsociado, "value", "text");
            List<BasicaDTO> listInstrumentos = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_CATEGORIAS_INSTRUMENTOS);
            ViewBag.listInstrumento = new SelectList(listInstrumentos, "value", "text");

            List<BasicaDTO> listPrioridad = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_CATEGORIAS_PRIORIDAD);
            ViewBag.listPrioridad = new SelectList(listPrioridad, "value", "text");
            string NombreEntidad = ConvocatoriaNeg.ObtenerNombreEntidad(model.EntidadId);
            modelPadre.NombreEntidad = NombreEntidad;
            string NombreEscuela = ConvocatoriaNeg.ObtenerNombreEscuela(Convert.ToInt32(model.EscuelaId));
            ViewBag.NuevoTitulo = NombreEntidad;
            modelPadre.NombreEscuela = NombreEscuela;
            ViewBag.Escuela = NombreEscuela;
            modelPadre.DatosBasicos = model;
            Success(string.Format("<b></b> Se actualizo con éxito la convocatoria de dotación  "), true);
            return View("Actualizar", modelPadre);
        }
        public ActionResult Dotacion(int Id)
        {
            var escuela = new EstandarDTO();
            escuela = ConvocatoriaNeg.ObtenerEscuelaPorEntidadId(Id);
            string NombreEntidad = ConvocatoriaNeg.ObtenerNombreEntidad(Id);
            var model = new DotacionPadreModel();
            var modeldatosBasicos = new DotacionModel();
            model.NombreEntidad = NombreEntidad;
            model.NombreEscuela = "";
            if (escuela != null)
            {
                ViewBag.Escuela = escuela.Nombre;
                model.NombreEscuela = escuela.Nombre;
                modeldatosBasicos.EscuelaId = escuela.Id;
            }
            ViewBag.NuevoTitulo = NombreEntidad;

            model.DatosBasicos = modeldatosBasicos;
            model.DatosBasicos.EntidadId = Id;
            string codigoConvocatoria = ConvocatoriaNeg.ObtenerIdConvocatoriaDotacion();
            model.DatosBasicos.ConvocatoriaId = Convert.ToInt32(codigoConvocatoria);

            return View(model);

        }

        [HttpPost]
        public ActionResult Dotacion(int Id, DotacionModel model)
        {
            if (ModelState.IsValid)
            {
                int dotacionId = GuardarDotacion(model);
                return RedirectToAction("Actualizar", "Convocatoria", new { Id = dotacionId });

            }
            var escuela = new EstandarDTO();
            escuela = ConvocatoriaNeg.ObtenerEscuelaPorEntidadId(Id);
            string NombreEntidad = ConvocatoriaNeg.ObtenerNombreEntidad(Id);
            var modelpadre = new DotacionPadreModel();
            var modeldatosBasicos = model;
            modelpadre.NombreEntidad = NombreEntidad;
            ViewBag.NuevoTitulo = NombreEntidad;
            if (escuela != null)
            {
                ViewBag.Escuela = escuela.Nombre;
                modelpadre.NombreEscuela = escuela.Nombre;
                modeldatosBasicos.EscuelaId = escuela.Id;
            }
            modelpadre.DatosBasicos = modeldatosBasicos;
            modelpadre.DatosBasicos.EntidadId = Id;
            string codigoConvocatoria = ConvocatoriaNeg.ObtenerIdConvocatoriaDotacion();
            modelpadre.DatosBasicos.ConvocatoriaId = Convert.ToInt32(codigoConvocatoria);

            return View(model);

        }

        public ActionResult Participacion(int Id, string reg= "")
        {
            var model = new ConsultaModel();
            model.Id = Id;
            ViewData["convocatoriaId"] = Id;
            ViewBag.NombreConvocatoria = ConvocatoriaNeg.ObtenerNombreConvocatoria(Id);
            ViewBag.Regresar ="Editar";
               if (reg == "C")
                   ViewBag.Regresar = "CambiarEstado";
            return View(model);
        }

        public ActionResult MisParticipaciones()
        {
            var model = new ConsultaModel();
                    
            return View(model);
        }
        public ActionResult Detalle(int Id)
        {
            var model = new ConvocatoriaDetalleModels();
            var resultado = ConvocatoriaNeg.ConsultarConvocatoriaPorId(Id);
            model = Translator.TranslatorConvocatoria.TranslatorConvocatoriaDetalle(resultado);

            model.DirigidoASeleccionada = ConvocatoriaNeg.ConsultarDirigidoA(Id);

            string codigoConvocatoria = ConvocatoriaNeg.ObtenerIdConvocatoriaDotacion();
            if (Id == Convert.ToInt32(codigoConvocatoria))
            {
                bool EsAdmin = UsuarioLogica.UsuarioEsAdmin(Convert.ToInt32(UsuaroId), Comunes.ConstantesRecursosBD.CODIGO_ADMIN);
                model.ListadoMunicipiosDotacion = ConvocatoriaNeg.ConsultarEntidadesHabilitadasDotacion(EsAdmin, Convert.ToInt32(UsuaroId));
                model.listadoEntidadesActualizado = ConvocatoriaNeg.ConsultarEntidadesRegistradas(Id, EsAdmin, Convert.ToInt32(UsuaroId));
                model.EsDotacion = true;
            }
            return View(model);
        }

        public ActionResult Editar(int Id)
        {
            var model = new ConvocatoriaModels();
            var resultado = ConvocatoriaNeg.ConsultarConvocatoriaPorId(Id);
            model = Translator.TranslatorConvocatoria.TranslatorConvocatoriaModel(resultado);
            if (model.ArtMusicaUsuarioId != Convert.ToInt32(UsuaroId))
                return RedirectToAction("Detalle", "Convocatoria", new { Id = Id });

            List<EstandarDTO> listDirigido = ConvocatoriaNeg.ConsultarParametros(Comunes.ConstantesRecursosBD.CODIGO_CATEGORIAS_ACTORES);
            model.DirigidoAData = listDirigido;
            model.DirigidoASeleccionada = ConvocatoriaNeg.ConsultarDirigidoA(Id);
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
            CargarDatosBasicos(model.Tipo, EsAdmin);
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(int Id, ConvocatoriaModels model)
        {

            if (ModelState.IsValid)
            {
                ActualizarConvocatoria(Id, model);

            }
            var resultado = ConvocatoriaNeg.ConsultarConvocatoriaPorId(Id);
            model = Translator.TranslatorConvocatoria.TranslatorConvocatoriaModel(resultado);
            List<EstandarDTO> listDirigido = ConvocatoriaNeg.ConsultarParametros(Comunes.ConstantesRecursosBD.CODIGO_CATEGORIAS_ACTORES);
            model.DirigidoASeleccionada = ConvocatoriaNeg.ConsultarDirigidoA(Id);
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
            CargarDatosBasicos(model.Tipo, EsAdmin);
            model.DirigidoAData = listDirigido;

            Success(string.Format("<b></b> Se actualizo con éxito la convocatoria: {0}  ", model.Titulo), true);
            return View("Editar", model);
        }

        public List<BasicaDTO> ObtenerActor(string tipo)
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

        public List<BasicaDTO> ObtenerActorAdministrador(string tipo)
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
        private void CargarDatosBasicos(string tipo, bool admin)
        {

            List<BasicaDTO> listAsociado = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_CATEGORIAS_ACTORES);
            List<BasicaDTO> listActor;
            if (admin)
                listActor = ObtenerActorAdministrador(tipo);
            else
                listActor = ObtenerActor(tipo);
            ViewBag.listCategoria = new SelectList(listAsociado, "value", "text");
            ViewBag.listActores = new SelectList(listActor, "value", "text");

        }

        public ActionResult CambiarEstado(int Id)
        {
            var model = new ConvocatoriaModels();
            var resultado = ConvocatoriaNeg.ConsultarConvocatoriaPorId(Id);
            model = Translator.TranslatorConvocatoria.TranslatorConvocatoriaModel(resultado);
            List<EstandarDTO> listDirigido = ConvocatoriaNeg.ConsultarParametros(Comunes.ConstantesRecursosBD.CODIGO_CATEGORIAS_ACTORES);
            model.DirigidoAData = listDirigido;
            model.DirigidoASeleccionada = ConvocatoriaNeg.ConsultarDirigidoA(Id);
            List<BasicaDTO> listEstado = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_CATEGORIA_ESTADOS);
            ViewBag.listEstado = new SelectList(listEstado, "value", "text");
            CargarDatosBasicos(model.Tipo, true);
            return View(model);
        }
        [HttpPost]
        public ActionResult CambiarEstado(int Id, ConvocatoriaModels model)
        {
            if (ModelState.IsValid)
            {
                ActualizarConvocatoria(Id, model);

            }
            var resultado = ConvocatoriaNeg.ConsultarConvocatoriaPorId(Id);
            model = Translator.TranslatorConvocatoria.TranslatorConvocatoriaModel(resultado);
            List<EstandarDTO> listDirigido = ConvocatoriaNeg.ConsultarParametros(Comunes.ConstantesRecursosBD.CODIGO_CATEGORIAS_ACTORES);
            model.DirigidoASeleccionada = ConvocatoriaNeg.ConsultarDirigidoA(Id);
            CargarDatosBasicos(model.Tipo, true);
            List<BasicaDTO> listEstado = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_CATEGORIA_ESTADOS);
            ViewBag.listEstado = new SelectList(listEstado, "value", "text");
            model.DirigidoAData = listDirigido;

            Success(string.Format("<b></b> Se actualizo con éxito la convocatoria: {0}  ", model.Titulo), true);
            return View("CambiarEstado", model);
        }
        public ActionResult Nuevo()
        {
            var model = new ConvocatoriaModels();
            List<EstandarDTO> listDirigido = ConvocatoriaNeg.ConsultarParametros(Comunes.ConstantesRecursosBD.CODIGO_CATEGORIAS_ACTORES);
            List<BasicaDTO> listAsociado = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_CATEGORIAS_ACTORES);
            List<BasicaDTO> listActor = new List<BasicaDTO>();
            ViewBag.listCategoria = new SelectList(listAsociado, "value", "text");
            ViewBag.listActores = new SelectList(listActor, "value", "text");
            model.DirigidoAData = listDirigido;

            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(ConvocatoriaModels model)
        {
            if (ModelState.IsValid)
            {
                Guardar(model);
                return RedirectToAction("Index", "Convocatoria");
            }
            else
            {
                List<EstandarDTO> listDirigido = ConvocatoriaNeg.ConsultarParametros(Comunes.ConstantesRecursosBD.CODIGO_CATEGORIAS_ACTORES);
                List<BasicaDTO> listAsociado = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_CATEGORIAS_ACTORES);
                List<BasicaDTO> listActor = new List<BasicaDTO>();
                ViewBag.listCategoria = new SelectList(listAsociado, "value", "text");
                ViewBag.listActores = new SelectList(listActor, "value", "text");
                model.DirigidoAData = listDirigido;
            }
            return View(model);
        }

        private void ActualizarConvocatoria(int Id, ConvocatoriaModels model)
        {
            var datos = new ConvocatoriaNuevoDTO();

            if (model != null)
            {
                datos.ActorId = Convert.ToInt32(model.TipoActor);
                datos.Descripcion = model.Descripcion;
                datos.FechaInicio = Convert.ToDateTime(model.FechaInicio);
                datos.FechaFin = Convert.ToDateTime(model.FechaFin);
                datos.TipoActorId = Convert.ToInt32(model.Tipo);
                datos.Titulo = model.Titulo;
                datos.UsuarioId = Convert.ToInt32(UsuaroId);
                datos.Id = model.ConvocatoriaId;
                datos.EstadoId = Convert.ToInt32(model.EstadoId);
                ConvocatoriaNeg.ActualizarConvocatoria(datos, model.DirigidoAPublicado);

                if (model.Documento != null)
                {
                    int DocumentoId = CrearDocumento(Convert.ToInt32(UsuaroId), NombreCompletoUsuario, model.Documento);

                    if (DocumentoId > 0)
                    {
                        ConvocatoriaNeg.ActualizarDocumento(model.ConvocatoriaId, DocumentoId);
                    }


                }
            }

        }

        private void ActualizarDotacion(int Id, DotacionModel model)
        {
            var datos = new DotacionDTO();

            if (model != null)
            {
                datos.Apellido = model.Apellido;
                datos.Cargo = model.Cargo;
                datos.Celular = model.Celular;
                datos.Email = model.Email;
                datos.Identificacion = model.Identificacion;
                datos.Id = Id;
                datos.Identificacion = model.Identificacion;
                datos.Nombre = model.Nombre;
                datos.Telefono = model.Telefono;
                DotacionNeg.Actualizar(datos);


            }

        }

        private void Guardar(ConvocatoriaModels model)
        {
            var datos = new ConvocatoriaNuevoDTO();
            int ConvocatoriaId = 0;

            if (model != null)
            {
                datos.ActorId = Convert.ToInt32(model.TipoActor);
                datos.Descripcion = model.Descripcion;
                datos.FechaInicio = Convert.ToDateTime(model.FechaInicio);
                datos.FechaFin = Convert.ToDateTime(model.FechaFin);
                datos.TipoActorId = Convert.ToInt32(model.Tipo);
                datos.Titulo = model.Titulo;
                datos.UsuarioId = Convert.ToInt32(UsuaroId);
                ConvocatoriaId = ConvocatoriaNeg.CrearConvocatoria(datos, model.DirigidoAPublicado);

                if (model.Documento != null)
                {
                    int DocumentoId = CrearDocumento(Convert.ToInt32(UsuaroId), NombreCompletoUsuario, model.Documento);

                    if (DocumentoId > 0)
                    {
                        ConvocatoriaNeg.ActualizarDocumento(ConvocatoriaId, DocumentoId);
                    }


                }
            }

        }

        private int GuardarDotacion(DotacionModel model)
        {
            var datos = new DotacionDTO();
            int DotacionId = 0;

            if (model != null)
            {
                datos.Apellido = model.Apellido;
                datos.Cargo = model.Cargo;
                datos.ConvocatoriaId = model.ConvocatoriaId;
                if (!String.IsNullOrEmpty(model.Celular))
                    datos.Celular = model.Celular;
                else
                    datos.Celular = "";
                datos.Email = model.Email;
                datos.EntidadId = model.EntidadId;
                datos.EscuelaId = Convert.ToInt32(model.EscuelaId);
                datos.Identificacion = model.Identificacion;
                datos.Nombre = model.Nombre;
                datos.Telefono = model.Telefono;
                datos.UsuarioId = Convert.ToInt32(UsuaroId);
                DotacionId = DotacionNeg.CrearDotacion(datos);
            }
            return DotacionId;
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
        public ActionResult Consulta()
        {
            var model = new ConsultaModel();
            model.TipoRegistro = 1;

            return View(model);
        }

        public ActionResult ConsultaDotacion()
        {
            var model = new ConsultaModel();
            model.TipoRegistro = 1;

            return View(model);
        }
        private GridViewSettings GetGridSettings()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridConvocatoria";
            settings.CallbackRouteValues = new { Controller = "Convocatoria", Action = "GridViewPartial" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "Convocatoria" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "Id";
            settings.Columns.Add("Titulo");
            settings.Columns.Add("FechaInicio");
            settings.Columns.Add("FechaFin");
            settings.Columns.Add("Estado");
            settings.Columns.Add("RelacionadoA");
            settings.Columns.Add("Tipo");

            return settings;
        }

        private GridViewSettings GetGridSettingsDotacion()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridDotacion";
            settings.CallbackRouteValues = new { Controller = "Convocatoria", Action = "GridViewPartialDotacion" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "ConvocatoriaDotacion" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "Id";
            settings.Columns.Add("Nombre");
            settings.Columns.Add("Cargo");
            settings.Columns.Add("NombreEntidad");
            settings.Columns.Add("NombreEscuela");
            settings.Columns.Add("Municipio");
            settings.Columns.Add("Departamento");

            return settings;
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial(string Busqueda = null)
        {
            ViewBag.GridSettings = GetGridSettings();
            var model = ObtenerMisConvocatorias(Busqueda);

            return PartialView("_GridViewPartial", model);
        }


        [ValidateInput(false)]
        public ActionResult GridViewPartialDotacion()
        {
            ViewBag.GridSettings = GetGridSettingsDotacion();
            var model = DotacionNeg.ConsultarListadoDotacion();

            return PartialView("_GridViewPartialDotacion", model);
        }

        private GridViewSettings GetGridSettingsParticipacion()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridParticipacion";
            settings.CallbackRouteValues = new { Controller = "Convocatoria", Action = "GridViewPartialParticipacion" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "Participantes" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "Id";
            settings.Columns.Add("RelacionadoA");
            settings.Columns.Add("Nombre");
            settings.Columns.Add("FechaRegistro");
            settings.Columns.Add("Descripcion");
            settings.Columns.Add("Usuario");

            return settings;
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartialMisParticipacion()
        {
            ViewBag.GridSettings = GetGridSettingsParticipacion();
            var model = ParticipacionNeg.ConsultarConvocatoriasPorUsuarioId(Convert.ToInt32(UsuaroId));

            return PartialView("_GridViewPartialMisParticipacion", model);
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartialParticipacion(int Id)
        {
            ViewBag.GridSettings = GetGridSettingsParticipacion();
            var model = ParticipacionNeg.ConsultarParticipacionPorConvocatoriaId(Id);
            ViewData["convocatoriaId"] = Id; 
            return PartialView("_GridViewParticipacion", model);
        }
        private List<ConvocatoriaListDTO> ObtenerMisConvocatorias(string Busqueda = null)
        {
            var model = new List<ConvocatoriaListDTO>();

            if (string.IsNullOrEmpty(Busqueda))
            {
                if (TempData["TipoRegistroA"] != null)
                    Busqueda = TempData["TipoRegistroA"].ToString();
                else
                    Busqueda = "2";
            }

            if (Busqueda == "1")
            {
                model = ConvocatoriaNeg.ConsultarConvocatoriaPorUsuarioId(Convert.ToInt32(UsuaroId));
                TempData["TipoRegistroA"] = 1;
            }
            else if (Busqueda == "2")
            {
                TempData["TipoRegistroA"] = 2;
                model = ConvocatoriaNeg.ConsultarConvocatoriaPorEstadoId(Comunes.ConstantesRecursosBD.CODIGO_ESTADOCONV_ACTIVA);
            }

            return model;
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartialPermisos(string Busqueda = null)
        {
            ViewBag.GridSettings = GetGridSettings();
            var model = ObtenerMisregistros(Busqueda);

            return PartialView("_GridViewPartialPermisos", model);
        }

        private List<ConvocatoriaListDTO> ObtenerMisregistros(string Busqueda = null)
        {
            var model = new List<ConvocatoriaListDTO>();

            if (string.IsNullOrEmpty(Busqueda))
            {
                if (TempData["TipoRegistroE"] != null)
                    Busqueda = TempData["TipoRegistroE"].ToString();
                else
                    Busqueda = "1";
            }

            if (Busqueda == "1")
            {
                model = ConvocatoriaNeg.ConsultarConvocatoriaPorEstadoId(Comunes.ConstantesRecursosBD.CODIGO_ESTADOCONV_PENDIENTE);
                TempData["TipoRegistroE"] = 1;
            }
            else if (Busqueda == "2")
            {
                TempData["TipoRegistroE"] = 2;
                model = ConvocatoriaNeg.ConsultarConvocatoriaPorEstadoId(Comunes.ConstantesRecursosBD.CODIGO_ESTADOCONV_ACTIVA);
            }
            else if (Busqueda == "3")
            {
                TempData["TipoRegistroE"] = 3;
                model = ConvocatoriaNeg.ConsultarConvocatoriaPorEstadoId(Comunes.ConstantesRecursosBD.CODIGO_ESTADOCONV_EVALUACION);
            }
            else if (Busqueda == "4")
            {
                TempData["TipoRegistroE"] = 4;
                model = ConvocatoriaNeg.ConsultarConvocatoriaPorEstadoId(Comunes.ConstantesRecursosBD.CODIGO_ESTADOCONV_RECHAZADA);
            }
            else if (Busqueda == "5")
            {
                TempData["TipoRegistroE"] = 5;
                model = ConvocatoriaNeg.ConsultarConvocatoriaPorEstadoId(Comunes.ConstantesRecursosBD.CODIGO_ESTADOCONV_FINALIZADA);
            }

            return model;
        }

        public ActionResult ExportTo(string OutputFormat)
        {

            var model = ConvocatoriaNeg.ConsultarConvocatoriaPorUsuarioId(Convert.ToInt32(UsuaroId));

            return GridViewExtension.ExportToXls(GetGridSettings(), model.ToList());
        }

        public ActionResult ExportToDotacion(string OutputFormat)
        {

            var model = DotacionNeg.ConsultarListadoDotacion();

            return GridViewExtension.ExportToXls(GetGridSettingsDotacion(), model.ToList());
        }

        public ActionResult ExportToParticipacion(int Id, string OutputFormat)
        {
            var model = ParticipacionNeg.ConsultarParticipacionPorConvocatoriaId(Id);
            ViewData["convocatoriaId"] = Id; 
            return GridViewExtension.ExportToXls(GetGridSettingsParticipacion(), model.ToList());
        }

        public ActionResult ExportToPermisos(string OutputFormat)
        {
            var model = new List<ConvocatoriaListDTO>();
            string Busqueda = "";
            model = ObtenerMisregistros(Busqueda);

            return GridViewExtension.ExportToXls(GetGridSettings(), model.ToList());
        }

        #region LogErrores
        protected override void OnException(ExceptionContext filterContext)
        {
            string ruta = "";
            ruta = Server.MapPath("/Log");
            Log.WriteLog(ruta, filterContext.Exception.ToString());

            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;


            var model = new HandleErrorInfo(filterContext.Exception, "Convocatoria", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }
        #endregion
    }

}