using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebSImus.Models;
using SM.LibreriaComun.DTO;
using SM.Aplicacion.Escuelas;
using WebSImus.Translator;
using SM.Aplicacion.Basicas;
using DevExpress.Web.Mvc;
using SM.Utilidades.Log;
using System.Web.Script.Serialization;
using System.Linq;
using PagedList;
using SM.Aplicacion.Agrupacion;
using SM.Aplicacion.Servicios;
using System.Web.Http.Cors;

namespace WebSImus.Controllers
{
    [HandleError()]
    public class HomeController : Controller
    {

        public ActionResult Cargargeneros(int FormacionPracticaId)
        {
            var listado = new List<EstandarDTO>();
          
            listado = EscuelasLogica.ConsultarGenerosPorPracticaID(FormacionPracticaId);

            return PartialView("_CargarGeneros", listado);
        }
        public ActionResult _DatosAgenda()
        {
            int TipoUtilidadId = ConvocatoriaNeg.ObtenerId(Comunes.ConstantesRecursosBD.NOMBRE_UTILIDAD_EVENTO);
            List<SM.LibreriaComun.DTO.Servicios.NoticiasDataDTO> model = SM.Aplicacion.Servicios.UtilidadNeg.ConsultarEventosdelMes(TipoUtilidadId);

            return PartialView("_DatosAgenda", model);
        }

        public ActionResult Index()
        {
            ViewBag.cantAgente = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerCantidadAgente();
            ViewBag.cantAgrupacion = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerCantidadAgrupaciones();
            ViewBag.cantEntidad = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerCantidadEntidades();
            ViewBag.cantEscuelas = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerCantidadEscuelas();
             
            return View();
        }

        public ActionResult Index2()
        {
            ViewBag.cantAgente = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerCantidadAgente();
            ViewBag.cantAgrupacion = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerCantidadAgrupaciones();
            ViewBag.cantEntidad = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerCantidadEntidades();
            ViewBag.cantEscuelas = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerCantidadEscuelas();

            return View();
        }

        public ActionResult _BusquedaEscuelas(string param,  int? page)
        {
            ViewBag.Palabra = param;
            var resultado = BusquedaLogica.ConsultarEscuelas(param);
            var listResultado = TranslatorBusqueda.TranslatorBusquedaDTOTOResuladoModels(resultado);

            var model = from l in listResultado select l;
            int pageSize = 8;
            int pageNumber = (page ?? 1);

            return PartialView("_BusquedaEscuelas", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult _BusquedaEventos(string param, int? page)
        {
            ViewBag.Palabra = param;
            var resultado = BusquedaLogica.ConsultarEventos(param);
            var listResultado = TranslatorBusqueda.TranslatorBusquedaDTOTOResuladoModels(resultado);

            var model = from l in listResultado select l;
            int pageSize = 8;
            int pageNumber = (page ?? 1);

            return PartialView("_BusquedaEventos", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult _BusquedaEntidades(string param, int? page)
        {
            ViewBag.Palabra = param;
            var resultado = BusquedaLogica.ConsultarEntidades(param);
            var listResultado = TranslatorBusqueda.TranslatorBusquedaDTOTOResuladoModels(resultado);

            var model = from l in listResultado select l;
            int pageSize = 8;
            int pageNumber = (page ?? 1);

            return PartialView("_BusquedaEntidades", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult _BusquedaAgrupaciones(string param, int? page)
        {
            ViewBag.Palabra = param;
            var resultado = BusquedaLogica.ConsultarAgrupacion(param);
            var listResultado = TranslatorBusqueda.TranslatorBusquedaDTOTOResuladoModels(resultado);

            var model = from l in listResultado select l;
            int pageSize = 8;
            int pageNumber = (page ?? 1);

            return PartialView("_BusquedaAgrupaciones", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult _BusquedaAgentes(string param, int? page)
        {
            ViewBag.Palabra = param;
            var resultado = BusquedaLogica.ConsultarAgentes(param);
            var listResultado = TranslatorBusqueda.TranslatorBusquedaDTOTOResuladoModels(resultado);

            var model = from l in listResultado select l;
            int pageSize = 8;
            int pageNumber = (page ?? 1);

            return PartialView("_BusquedaAgentes", model.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Resultado(string param, int? page)
        {

            var padre = new BusquedaPadreModels();
            ViewBag.Palabra = param;
            return View();
        }

        public ActionResult CargarGrafica()
        {


            return PartialView("Grafica");
        }


        public ActionResult ConsultaAgentes()
        {


            return View();
        }

        public ActionResult ConsultaAgrupaciones()
        {


            return View();
        }

        public ActionResult AgrupacionDepartamento(string Id, string Tipo, int? page)
        {
            var listResultado = new List<AgrupacionHomeModels>();
            var listado = new List<AgrupacionHomeDataDTO>();
            listado = AgrupacionNeg.ConsultarAgrupacionHomePorDepartamento(Id);
            if (!String.IsNullOrEmpty(Tipo))
            {
                int tipoAgrupacionId = Convert.ToInt32(Tipo);
                listado = (from l in listado where l.TipoAgrupacionId == tipoAgrupacionId select l).ToList();
                ViewBag.tipoAgrupacionId = Tipo;
            }
            listResultado = TranslatorHomeActores.AgrupacionesHome(listado);
            ViewBag.CodDepto = Id;
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialResultado", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult AgrupacionMunicipio(string Id, string Tipo, int? page)
        {
            var listResultado = new List<AgrupacionHomeModels>();
            var listado = new List<AgrupacionHomeDataDTO>();
            listado = AgrupacionNeg.ConsultarAgrupacionHomePorMunicipio(Id);
            if (!String.IsNullOrEmpty(Tipo))
            {
                int tipoAgrupacionId = Convert.ToInt32(Tipo);
                listado = (from l in listado where l.TipoAgrupacionId == tipoAgrupacionId select l).ToList();
                ViewBag.tipoAgrupacionId = Tipo;
            }
            listResultado = TranslatorHomeActores.AgrupacionesHome(listado);
            ViewBag.codMunicipio = Id;
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialResultado", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult AgrupacionTipo(string Id, string codDepto, string codMunicipio, int? page)
        {
            var listResultado = new List<AgrupacionHomeModels>();
            var listado = new List<AgrupacionHomeDataDTO>();
            if (String.IsNullOrEmpty(codDepto) && String.IsNullOrEmpty(codMunicipio) && !String.IsNullOrEmpty(Id))
                listado = AgrupacionNeg.ConsultarAgrupacionHomeTodos();
            else if (!String.IsNullOrEmpty(codMunicipio))
            {
                if (codMunicipio.Length == 5)
                {
                    listado = AgrupacionNeg.ConsultarAgrupacionHomePorMunicipio(codMunicipio);
                    ViewBag.codMunicipio = codMunicipio;
                }
                else if (!String.IsNullOrEmpty(codDepto))
                {
                    listado = AgrupacionNeg.ConsultarAgrupacionHomePorDepartamento(codDepto);
                    ViewBag.CodDepto = codDepto;
                }
                else if (!String.IsNullOrEmpty(Id))
                {
                    listado = AgrupacionNeg.ConsultarAgrupacionHomeTodos();
                    ViewBag.tipoAgrupacionId = Id;
                }
            }
            else if (!String.IsNullOrEmpty(codDepto))
            {
                listado = AgrupacionNeg.ConsultarAgrupacionHomePorDepartamento(codDepto);
                ViewBag.CodDepto = codDepto;
            }

            if (!String.IsNullOrEmpty(Id))
            {
                int tipoAgrupacionId = Convert.ToInt32(Id);
                listado = (from l in listado where l.TipoAgrupacionId == tipoAgrupacionId select l).ToList();
                ViewBag.tipoAgrupacionId = Id;
            }
            listResultado = TranslatorHomeActores.AgrupacionesHome(listado);
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialResultado", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult CargarTodoAgrupacion(int? page)
        {
            var listResultado = new List<AgrupacionHomeModels>();
            var listado = new List<AgrupacionHomeDataDTO>();

            listado = AgrupacionNeg.ConsultarAgrupacionHomeTodos();

            listResultado = TranslatorHomeActores.AgrupacionesHome(listado);
            ViewBag.codMunicipio = "";
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialResultado", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult HomeAgrupaciones(string codDepto, string codMunicipio, string tipo, int? page)
        {

            var listResultado = new List<AgrupacionHomeModels>();
            var listado = new List<AgrupacionHomeDataDTO>();
            if (String.IsNullOrEmpty(codDepto) && String.IsNullOrEmpty(codMunicipio) && String.IsNullOrEmpty(tipo))
                listado = AgrupacionNeg.ConsultarAgrupacionHomeTodos();
            else if (!String.IsNullOrEmpty(codMunicipio))
            {
                if (codMunicipio.Length == 5)
                {
                    listado = AgrupacionNeg.ConsultarAgrupacionHomePorMunicipio(codMunicipio);
                    ViewBag.codMunicipio = codMunicipio;
                }
                else if (!String.IsNullOrEmpty(codDepto))
                {
                    listado = AgrupacionNeg.ConsultarAgrupacionHomePorDepartamento(codDepto);
                    ViewBag.CodDepto = codDepto;
                }
                else if (!String.IsNullOrEmpty(tipo))
                {
                    listado = AgrupacionNeg.ConsultarAgrupacionHomeTodos();
                    ViewBag.tipoAgrupacionId = tipo;
                }
            }
            else if (!String.IsNullOrEmpty(codDepto))
            {
                listado = AgrupacionNeg.ConsultarAgrupacionHomePorDepartamento(codDepto);
                ViewBag.CodDepto = codDepto;
            }


            if (!String.IsNullOrEmpty(tipo))
            {
                int tipoAgrupacionId = Convert.ToInt32(tipo);
                listado = (from l in listado where l.TipoAgrupacionId == tipoAgrupacionId select l).ToList();
                ViewBag.tipoAgrupacionId = tipo;
            }

            listResultado = TranslatorHomeActores.AgrupacionesHome(listado);
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            if (page == null)
            {
                List<BasicaDTO> objMunicipios = new List<BasicaDTO>();
                List<BasicaDTO> objDepartamentos = ZonaGeograficasLogica.ConsultarDepartamentos();
                List<BasicaDTO> objTipo = CaracterizacionMusicalNeg.ConsultarTipoAgrupacion();
                ViewBag.departamentos = new SelectList(objDepartamentos, "value", "text");
                ViewBag.municipios = new SelectList(objMunicipios, "value", "text");
                ViewBag.tipo = new SelectList(objTipo, "value", "text");
                return View(model.ToPagedList(pageNumber, pageSize));
            }
            else
                return PartialView("_PartialResultado", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult DetalleAgrupacion(int Id)
        {
            TempData["imagen"] = "~/img/agrupa_generica.jpg";
            ViewBag.ImageData = "~/img/agrupa_generica.jpg";
            var model = new AgrupacionDataModels();
            model = TranslatorAgrupacion.ConsultarDatosAgrupacionPorId(Id);
            var redsocial = new List<RedSocialDTO>();
            redsocial = SM.Aplicacion.RedSocial.RedSocialNeg.ObtenerRedSocialporActor(Id, "Agrupacion");

            if (redsocial != null)
            {
                foreach (var item in redsocial)
                {
                    if (item.Nombre == "Facebook")
                        model.facebook = item.valor;
                    if (item.Nombre == "Twitter")
                        model.twitter = item.valor;
                    if (item.Nombre == "Youtube")
                        model.youtube = item.valor;
                    if (item.Nombre == "Sound")
                        model.soundcloud = item.valor;
                }
            }

            var modeltabla = new List<AgentePublicoModels>();

            modeltabla = Translator.TranslatorAgentes.ConsultarAgentePorAgrupacionId(Id);
            var listado = new List<EstandarDTO>();
            listado = SM.Aplicacion.Agrupacion.AgrupacionNeg.ConsultarGenerosPorAgrupacionId(Id);
            model.listAgentes = modeltabla;
            model.listgeneros = listado;
            if (model.Imagen != null)
            {
                string imageBase64Data = Convert.ToBase64String(model.Imagen);
                string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                TempData["imagen"] = imageDataURL;
                ViewBag.ImageData = imageDataURL;
            }
            return View(model);

        }

        public ActionResult GridViewPartialAgentes()
        {
            var model = new List<AgentePublicoModels>();

            model = TranslatorAgentes.ConsultarAgentesPorEstadoId(Comunes.ConstantesRecursosBD.CODIGO_ESTADO_PUBLICADO);

            return PartialView("_GridViewPartialAgentes", model);
        }

        public ActionResult GridViewPartialAgrupacion()
        {
            var model = new List<AgrupacionDataModels>();

            model = TranslatorAgrupacion.ConsultarAgrupacionPorEstadoId(Comunes.ConstantesRecursosBD.CODIGO_ESTADO_PUBLICADO);

            return PartialView("_GridViewPartialAgrupacion", model);
        }

        public ActionResult ConsultaEntidades()
        {


            return View();
        }

        public ActionResult GridViewPartialEntidades()
        {
            var model = new List<EntidadDatosModels>();

            model = TranslatorEntidades.ConsultarEntidadPorEstado(Comunes.ConstantesRecursosBD.CODIGO_ESTADO_PUBLICADO);

            return PartialView("_GridViewPartialEntidades", model);
        }
        public ActionResult ConsultaEscuelas()
        {


            return View();
        }

        public ActionResult GridViewPartialEscuelas()
        {
            var model = new List<EscuelaPublicoDTO>();

            model = EscuelasLogica.ConsultaEscuelasDatosPublicos("E");

            return PartialView("_GridViewPartialEscuelas", model);
        }
        public ActionResult GridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] WebSImus.Models.EscuelaConsultaModel item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartialEscuelas", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] WebSImus.Models.EscuelaConsultaModel item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartialEscuelas", model);
        }


        public ActionResult Ficha(int Id)
        {
            var model = new EscuelasPadre();

            //Carga los datos básicos
            model.Escuelas = TranslatorEscuelas.CargarDatosBasicos(Id);
            if (model.Escuelas.imagen != null)
            {
                string imageBase64Data = Convert.ToBase64String(model.Escuelas.imagen);
                string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                TempData["imagen"] = imageDataURL;
                ViewBag.ImageData = imageDataURL;
            }
            else
            {
                TempData["imagen"] = "~/img/generica_escuelas.jpg";
                ViewBag.ImageData = "~/img/generica_escuelas.jpg";
            }

            ViewBag.NombreEscuela = model.Escuelas.NombreEscuela;
            //Cargar datos de institucionalidad
            var modelinstitucionalidad = new Institucionalidad();
            var practicaMusicalSeleccionada = new List<PracticaMusicales>();
            //CargaInfraestructura
            var modelinfraestructura = new InfraestructuraModel();
            //CargaParticipacion
            var modelParticipacion = new ParticipacionModel();
            var modelFormacion = new FormacionModel();
            var modelProduccion = new ProduccionModel();
            var modelRedes = new RedesSocialesModel();
            var modeltabla = new List<VideoModel>();

            modelinstitucionalidad = TranslatorEscuelas.CargarInstitucionalidadFicha(Id);
            modelinfraestructura = TranslatorEscuelas.CargarInfraestructuraFicha(Id);
            //modelParticipacion = TranslatorEscuelas.CargarParticipacion(Id);
            //modelFormacion = TranslatorEscuelas.CargarFormacionFicha(Id);
            modelProduccion = TranslatorEscuelas.CargarProduccionFicha(Id);
            modelRedes = TranslatorEscuelas.CargarDatosRedes(Id);
            modeltabla = Translator.TranslatorEscuelas.ConsultarVideosFicha(Id);

            //Practicas musiclaes formación
            var listadoPractica = new List<PracticaHomeModelDTO>();
            listadoPractica = EscuelasLogica.ConsultarPracticaPorEscuelaHome(Id);
            model.Practicas = listadoPractica;

            // cargamos en la clase padre
            model.Institucionalidad = modelinstitucionalidad;
            model.Infraestructura = modelinfraestructura;
            model.Participacion = modelParticipacion;
            model.Produccion = modelProduccion;
            model.RedesSociales = modelRedes;
            model.listadoVideo = modeltabla;

            return View(model);
        }

        public ActionResult FichaEscuela(int Id)
        {
            var model = new EscuelasPadre();

            //Carga los datos básicos
            model.Escuelas = TranslatorEscuelas.CargarDatosBasicos(Id);
            if (model.Escuelas.imagen != null)
            {
                string imageBase64Data = Convert.ToBase64String(model.Escuelas.imagen);
                string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                TempData["imagen"] = imageDataURL;
                ViewBag.ImageData = imageDataURL;
            }
            else
            {
                TempData["imagen"] = "~/img/defaultUser.jpg";
                ViewBag.ImageData = "~/img/defaultUser.jpg";
            }

            ViewBag.NombreEscuela = model.Escuelas.NombreEscuela;
            //Cargar datos de institucionalidad
            var modelinstitucionalidad = new Institucionalidad();
            var practicaMusicalSeleccionada = new List<PracticaMusicales>();
            //CargaInfraestructura
            var modelinfraestructura = new InfraestructuraModel();
            //CargaParticipacion
            var modelParticipacion = new ParticipacionModel();
            var modelFormacion = new FormacionModel();
            var modelProduccion = new ProduccionModel();
            var modelRedes = new RedesSocialesModel();
            var modeltabla = new List<VideoModel>();

            modelinstitucionalidad = TranslatorEscuelas.CargarInstitucionalidadFicha(Id);
            modelinfraestructura = TranslatorEscuelas.CargarInfraestructuraFicha(Id);
            //modelParticipacion = TranslatorEscuelas.CargarParticipacion(Id);
            modelFormacion = TranslatorEscuelas.CargarFormacionFicha(Id);
            modelProduccion = TranslatorEscuelas.CargarProduccionFicha(Id);
            modelRedes = TranslatorEscuelas.CargarDatosRedes(Id);
            modeltabla = Translator.TranslatorEscuelas.ConsultarVideosFicha(Id);

            // cargamos en la clase padre
            model.Institucionalidad = modelinstitucionalidad;
            model.Infraestructura = modelinfraestructura;
            model.Participacion = modelParticipacion;
            model.Formacion = modelFormacion;
            model.Produccion = modelProduccion;
            model.RedesSociales = modelRedes;
            model.listadoVideo = modeltabla;

            return View(model);
        }


        public ActionResult DetalleEntidad(int Id)
        {
            TempData["imagen"] = "~/img/entidad_generica.jpg";
            ViewBag.ImageData = "~/img/entidad_generica.jpg";
            var model = new EntidadDatosModels();
            model = TranslatorEntidades.ConsultarDatosEntidadPorId(Id);
            var redsocial = new List<RedSocialDTO>();
            redsocial = SM.Aplicacion.RedSocial.RedSocialNeg.ObtenerRedSocialporActor(Id, "Entidad");

            if (redsocial != null)
            {
                foreach (var item in redsocial)
                {
                    if (item.Nombre == "Facebook")
                        model.facebook = item.valor;
                    if (item.Nombre == "Twitter")
                        model.twitter = item.valor;
                    if (item.Nombre == "Youtube")
                        model.youtube = item.valor;
                    if (item.Nombre == "Sound")
                        model.soundcloud = item.valor;
                }
            }

            if (model.Imagen != null)
            {
                string imageBase64Data = Convert.ToBase64String(model.Imagen);
                string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                TempData["imagen"] = imageDataURL;
                ViewBag.ImageData = imageDataURL;
            }
            return View(model);
        }

        public ActionResult DetalleAgente(int Id)
        {

            TempData["imagen"] = "~/img/agente_generico.png";
            ViewBag.ImageData = "~/img/agente_generico.png";
            var model = new AgentePublicoModels();
            var redsocial = new List<RedSocialDTO>();
            model = Translator.TranslatorAgentes.ConsultarDatosAgentePorId(Id);

            redsocial = SM.Aplicacion.RedSocial.RedSocialNeg.ObtenerRedSocialporActor(Id, "Agente");

            if (redsocial != null)
            {
                foreach (var item in redsocial)
                {
                    if (item.Nombre == "Facebook")
                        model.facebook = item.valor;
                    if (item.Nombre == "Twitter")
                        model.twitter = item.valor;
                    if (item.Nombre == "Youtube")
                        model.youtube = item.valor;
                    if (item.Nombre == "Sound")
                        model.soundcloud = item.valor;
                }
            }

            //Agregar los oficios
            var listadoOficios = new List<OcupacionDTO>();
            var listado = new List<EstandarDTO>();
            listadoOficios = SM.Aplicacion.Agentes.AgentesNeg.ConsultarOcupacionPorAgenteId(Id);
            model.listOficios = listadoOficios;

            listado = SM.Aplicacion.Agentes.AgentesNeg.ConsultarServicioPorInteresId(Id);
            model.listIntereses = listado;
            listado = new List<EstandarDTO>();
            listado = SM.Aplicacion.Agentes.AgentesNeg.ConsultarServicioPorAgenteId(Id);
            model.listServicio = listado;

            model.listExperiencia = Translator.TranslatorAgentes.ConsultarExperiencia(Id, Translator.TranslatorAgentes.Experiencia);
            model.listFormacion = Translator.TranslatorAgentes.ConsultarExperiencia(Id, Translator.TranslatorAgentes.Formacion);
            if (model.imagen != null)
            {
                string imageBase64Data = Convert.ToBase64String(model.imagen);
                string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                TempData["imagen"] = imageDataURL;
                ViewBag.ImageData = imageDataURL;
            }
            return View(model);
        }

        public JsonResult GetMunicipio(string departamento = null)
        {

            List<BasicaDTO> listMunicipios = new List<BasicaDTO>();

            if (!String.IsNullOrEmpty(departamento))
            {
                listMunicipios = ZonaGeograficasLogica.ConsultarMunicipios(departamento);
            }

            var data = listMunicipios;
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAlumnosRangoEdad(string Id)
        {
            decimal EscuelaId = Convert.ToDecimal(Id);
            var reporte = ParticipacionLogica.ConsultarAlumnosPorRangoEdad(EscuelaId);

            //oper = null which means its first load.
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }

        public JsonResult GetAlumnosEtnia(string Id)
        {
            decimal EscuelaId = Convert.ToDecimal(Id);
            var reporte = ParticipacionLogica.ConsultarAlumnosPorEtnia(EscuelaId);
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }

        public JsonResult GetAlumnosSexo(string Id)
        {
            decimal EscuelaId = Convert.ToDecimal(Id);
            var reporte = ParticipacionLogica.ConsultarAlumnosPorSexo(EscuelaId);
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }

        public JsonResult GetAlumnosUbicacion(string Id)
        {
            decimal EscuelaId = Convert.ToDecimal(Id);
            var reporte = ParticipacionLogica.ConsultarAlumnosPorUbicacion(EscuelaId);
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }

        public JsonResult GetAlumnosCondicionesEspeciales(string Id)
        {
            decimal EscuelaId = Convert.ToDecimal(Id);
            var reporte = ParticipacionLogica.ConsultarAlumnosPorCondicionesEspeciales(EscuelaId);
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }
        protected override void OnException(ExceptionContext filterContext)
        {
            string ruta = "";
            ruta = Server.MapPath("/Log");
            Log.WriteLog(ruta, filterContext.Exception.ToString());

            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;


            var model = new HandleErrorInfo(filterContext.Exception, "Home", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }

    }
}