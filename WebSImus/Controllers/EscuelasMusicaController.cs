using DevExpress.Export;
using DevExpress.Web;
using DevExpress.Web.Mvc;
using DevExpress.XtraPrinting;
using OfficeOpenXml.Drawing.Chart.ChartEx;
using SM.Aplicacion.Basicas;
using SM.Aplicacion.Documentos;
using SM.Aplicacion.EntidadesOpeadoras;
using SM.Aplicacion.Escuelas;
using SM.Aplicacion.Formularios;
using SM.Aplicacion.Modulo_Usuarios;
using SM.Aplicacion.Servicios;
using SM.Aplicacion.Servinformacion;
using SM.Aplicacion.Usuarios;
using SM.LibreriaComun.DTO;
using SM.Utilidades.Log;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebSImus.Comunes;
using WebSImus.Helpers;
using WebSImus.Models;
using WebSImus.Translator;


namespace WebSImus.Controllers
{

    [HandleError()]
    [SessionExpire]
    public class EscuelasMusicaController : BaseController
    {
        public ActionResult _AgregarGenero()
        {

            return PartialView("_AgregarGenero");
        }

        public ActionResult _AgregarNiveles(string id, string escuelaId)
        {
            var model = new NivelesFormacionDTO();
            List<BasicaDTO> objLista = new List<BasicaDTO>();
            objLista.Add(new BasicaDTO() { text = "Inicial", value = "Inicial" });
            objLista.Add(new BasicaDTO() { text = "Básico", value = "Básico" });
            objLista.Add(new BasicaDTO() { text = "Medio", value = "Medio" });
            if (!string.IsNullOrEmpty(id))
            {
                model.FormacionPracticaNuevoId = Convert.ToInt32(id);
                model.EscuelaId = Convert.ToDecimal(escuelaId);

            }
            ViewBag.listaNiveles = new SelectList(objLista, "value", "text");
            return PartialView("_AgregarNiveles", model);
        }

        [HttpPost]
        public JsonResult AgregarNiveles(string EscuelaId,
                              string FormacionId,
                              string Nivel,
                              string Grupo,
                              string Integrantes,
                              string Horas)
        {
            bool isSuccess = true;

            if (String.IsNullOrEmpty(Grupo))
                Grupo = "0";

            if (String.IsNullOrEmpty(Integrantes))
                Integrantes = "0";

            if (String.IsNullOrEmpty(Horas))
                Horas = "0";

            NivelesFormacionDTO registro = new NivelesFormacionDTO
            {
                EscuelaId = Convert.ToDecimal(EscuelaId),
                Cantidadgrupos = Grupo,
                CantidadIntegrantes = Integrantes,
                HoraSemanal = Horas,
                NombreNiveles = Nivel,
                FormacionPracticaNuevoId = Convert.ToInt32(FormacionId)
            };
            FormacionLogica.InsertarNiveles(registro);

            return Json(isSuccess);
        }
        [HttpPost]
        public ActionResult AgregarGeneros(string atributo,
                                         string formacionId)
        {


            if (string.IsNullOrEmpty(atributo))
                return Json(new { Response = "Error" });

            EscuelasLogica.AgregarGenero(Convert.ToInt32(formacionId), atributo);
            var listado = new List<EstandarDTO>();

            listado = EscuelasLogica.ConsultarGenerosPorPracticaID(Convert.ToInt32(formacionId));

            return PartialView("_TablaGenero", listado);

        }

        [HttpPost]
        public JsonResult AgregarPractica(string EscuelaId,
                                         string PracticaId)
        {
            bool isSuccess = true;


            EscuelasLogica.AgregarPracticaMusical(Convert.ToDecimal(EscuelaId), Convert.ToInt16(PracticaId));

            return Json(isSuccess);

        }

        public ActionResult Cargargeneros(int FormacionPracticaId, int EliminarId)
        {
            var listado = new List<EstandarDTO>();
            if (EliminarId > 0)
            {
                EscuelasLogica.EliminarPracticaGenero(EliminarId);
            }

            listado = EscuelasLogica.ConsultarGenerosPorPracticaID(FormacionPracticaId);

            return PartialView("_TablaGenero", listado);
        }

        public ActionResult CargarNivel(int FormacionPracticaId, int EliminarId)
        {
            var listado = new List<NivelesFormacionDTO>();
            if (EliminarId > 0)
            {
                FormacionLogica.EliminarPracticaNivel(EliminarId);
            }

            listado = FormacionLogica.ConsultarNiveles(FormacionPracticaId);

            return PartialView("_TablaNivel", listado);
        }

        public ActionResult CargarPractica(int EscuelaId, int EliminarId)
        {
            var listado = new List<EstandarDTO>();
            if (EliminarId > 0)
            {
                EscuelasLogica.EliminarPracticaGenero(EliminarId);
            }

            listado = EscuelasLogica.ConsultarPracticaPorEscuela(EscuelaId);

            return PartialView("_TablaPractica", listado);
        }
        public ActionResult _ValidacionEscuelas(string CodMunicipio)
        {
            var model = new List<EscuelaSolicitudDTO>();
            decimal UsuarioSipaId = UsuarioLogica.ObtenerUsuarioSipaId(Usuario);
            BasicaDTO objBasicas = ZonaGeograficasLogica.ObtenerNombres(CodMunicipio);
            if (objBasicas != null)
            {
                ViewBag.NombreMunicipio = objBasicas.text + " - " + objBasicas.value;
            }
            if (!String.IsNullOrEmpty(CodMunicipio))
                model = EscuelasLogica.ConsultarEscuelasPorMunicipio(CodMunicipio, UsuarioSipaId);
            return PartialView("_ValidacionEscuelas", model);
        }


        public ActionResult _ValidacionEstado(string IdEstado)
        {


            return PartialView("_ValidacionEstado");
        }

        public ActionResult _TablaEscuelas(string CodMunicipio)
        {
            var model = new List<EscuelaSolicitudDTO>();
            decimal UsuarioSipaId = UsuarioLogica.ObtenerUsuarioSipaId(Usuario);


            if (!String.IsNullOrEmpty(CodMunicipio))
                model = EscuelasLogica.ConsultarEscuelasPorMunicipio(CodMunicipio, UsuarioSipaId);
            return PartialView("_TablaEscuelas", model);
        }
        [HttpPost]
        public JsonResult AgregarUsuario(string EscuelaId, string CodMunicipio)
        {
            bool isSuccess = true;

            if (string.IsNullOrEmpty(EscuelaId))
                return Json(new { Response = "Error" });


            AsignacionUsuariosNeg.AgregarSolicitud(Convert.ToDecimal(EscuelaId), Convert.ToInt32(UsuaroId), CodMunicipio);


            return Json(isSuccess);

        }

        [HttpPost]
        public JsonResult AgregarDocumento(int id, string cat)
        {
            bool isSuccess = true;
            string categoria = "";

            if (string.IsNullOrEmpty(cat))
                return Json(new { Response = "Error" });
            else
            {
                if (cat == "1")
                    categoria = "Matriz proyecto productivo";
                else if (cat == "2")
                    categoria = "Matriz proyecto organizativo";
                else if (cat == "3")
                    categoria = "Altas de almacén";
                else if (cat == "4")
                    categoria = "Contrato director";
                else if (cat == "5")
                    categoria = "Contrato personal administrativo";
                else if (cat == "6")
                    categoria = "Contrato profesor";
                else if (cat == "7")
                    categoria = "Estatutos";
                else if (cat == "8")
                    categoria = "Manual de convivencia";
                else if (cat == "9")
                    categoria = "Manual de funcionamiento";
                else if (cat == "10")
                    categoria = "Manual de uso de servicios y espacios";
                else if (cat == "11")
                    categoria = "Organigrama";
                else if (cat == "12")
                    categoria = "Organización académica";
                else if (cat == "13")
                    categoria = "Plan de acción";
                else if (cat == "14")
                    categoria = "Plan estratégico";
                else if (cat == "15")
                    categoria = "Póliza";
                else if (cat == "16")
                    categoria = "Portafolio";
                else if (cat == "17")
                    categoria = "Proyecto educativo musical";
                else if (cat == "18")
                    categoria = "Acta de reunión de visita";
                else if (cat == "19")
                    categoria = "Seguimiento iniciación";

            }

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

                    decimal EscuelaId = Convert.ToDecimal(id);
                    EscuelaDocumentosNeg.Crear(registro, EscuelaId, categoria, NombreCompletoUsuario, Request.UserHostAddress, Convert.ToInt32(UsuaroId));
                }
            }


            //}


            return Json(isSuccess);

        }

        public ActionResult TablaDocumentos(int Id, int EliminarId)
        {
            var modeltabla = new List<EscuelaDocumentoDTO>();

            if (EliminarId > 0)
            {
                EscuelaDocumentosNeg.EliminarDocumento(EliminarId);
            }

            modeltabla = EscuelaDocumentosNeg.ConsultarEscuelasDocumentos(Id);

            return PartialView("_TablaDocumentos", modeltabla);
        }
        public ActionResult TablaVideo(int Id, int EliminarId)
        {
            var modeltabla = new List<VideoModel>();

            if (EliminarId > 0)
            {
                RedesLogica.EliminarVideo(EliminarId);
            }

            modeltabla = Translator.TranslatorEscuelas.ConsultarVideos(Id);
            if (modeltabla.Count > 0)
                ViewBag.videoUrl = modeltabla[0].url;
            return PartialView("_TablaVideos", modeltabla);
        }

        public ActionResult Cargar(int Id)
        {
            var model = new InfraestructuraModel();
            return PartialView("_Infraestructura", model);
        }
        //
        // GET: /EscuelasMusica/
        //[OutputCache(Duration = 10)]
        public ActionResult Index()
        {
            var model = new RedesSocialesModel();
            ViewBag.Mensajes = "No";
            return View(model);
        }
        [HttpPost]
        //[OutputCache(Duration = 10)]
        public ActionResult Index(FormCollection collection, RedesSocialesModel redes)
        {
            if (ModelState.IsValid)
            {

                ViewBag.TituloAlerta = "Título escuelas de música";
                ViewBag.MensajeAlerta = "Se guardo con éxito";
                ViewBag.municipios = null;
            }
            ViewBag.Mensajes = "OK";
            return View("Index", redes);
        }

        public ActionResult Formulario(int Id)
        {
            if (String.IsNullOrEmpty(UsuaroId))
                return RedirectToAction("Login", "Cuenta");

            ViewBag.EsEditar = true;


            EscuelaEncabezadoDTO escuela = FormulariosLogica.ConsultarEncabezadoEscuela(Id);
            ViewBag.NombreEscuela = escuela.Nombre;
            ViewBag.ResenaEscuela = escuela.Resena;
            ViewBag.EscuelaId = Id;
            var model = CargarFormulariosActivos(Id);
            return View(model);
        }


        public ActionResult Auditoria(int Id)
        {
            if (String.IsNullOrEmpty(UsuaroId))
                return RedirectToAction("Login", "Cuenta");

            ViewBag.EsEditar = true;


            EscuelaEncabezadoDTO escuela = FormulariosLogica.ConsultarEncabezadoEscuela(Id);
            ViewBag.NombreEscuela = escuela.Nombre;
            ViewBag.ResenaEscuela = escuela.Resena;
            ViewBag.EscuelaId = Id;
            var model = CargarFormulariosActivos(Id);
            return View(model);
        }
        public ActionResult CargarDocumentos()
        {
            var model = new CoordenadasDTO();
            if (Session["$Coorde"] != null)
                model = (CoordenadasDTO)Session["$Coorde"];
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> CargarDocumentos(CoordenadasDTO model)
        {
            // CargarDocumentoNeg.UsuariosDesencriptar();
            var coorde = new CoordenadasDTO();
            ResultadoWebServices obj = new ResultadoWebServices();
            string token = System.Configuration.ConfigurationManager.AppSettings["TokenServinformacion"];
            string url = System.Configuration.ConfigurationManager.AppSettings["UrlServinformacion"];
            coorde = await obj.ObtenerCoordenadas(model.Direccion, model.Ciudad, token, url);

            coorde.Direccion = model.Direccion;
            coorde.Ciudad = model.Ciudad;

            Session["$Coorde"] = coorde;
            return RedirectToAction("CargarDocumentos", "EscuelasMusica");

        }

        [HttpPost]
        public ActionResult Formulario(int Id, string Guardar, FormCollection collection, HttpPostedFileBase imagenPerfil)
        {
            if (String.IsNullOrEmpty(UsuaroId))
                return RedirectToAction("Login", "Cuenta");
            decimal FormularioId = 0;

            List<FormularioDTO> listFormulario = FormulariosLogica.ConsultarFormulariosActivos();
            foreach (var item in listFormulario)
            {
                if (item.Perfiles == Guardar)
                {
                    FormularioId = item.ForID;
                    break;
                }
            }

            if (FormularioId != 0)
            {
                List<FormularioCamposDTO> listCamposFormularios = FormulariosLogica.ConsultarCampos(FormularioId);
                List<FormularioResultadoCampoDTO> listFormularioResultado = new List<FormularioResultadoCampoDTO>();
                foreach (var item in listCamposFormularios)
                {
                    FormularioResultadoCampoDTO datos = new FormularioResultadoCampoDTO();
                    datos.FOR_ID = FormularioId;
                    datos.FCO_ID = item.FCO_ID;
                    datos.FCO_NOMBRE = item.FCO_NOMBRE;
                    datos.FCO_TIPO_DATO = item.FCO_TIPODATO;
                    datos.FCO_DESCRIPCION = "";
                    if ((item.FCO_TIPODATO != "M") && (item.FCO_TIPODATO != "A"))
                    {
                        string value = Convert.ToString(collection[item.FCO_NOMBRE]);
                        if (!string.IsNullOrEmpty(value))
                            datos.FCO_DESCRIPCION = value;

                    }
                    else if (item.FCO_TIPODATO == "M")
                    {
                        List<BasicaDTO> listBasicas = FormulariosLogica.ConsularListadoElementosPorId(Convert.ToDecimal(item.FLI_ID));
                        string arreglo = "";

                        foreach (var x in listBasicas)
                        {
                            string valor = Convert.ToString(collection[x.text]);

                            if (!string.IsNullOrEmpty(valor))
                            {
                                if (valor != "false")
                                    arreglo = arreglo + x.text + ",";
                            }
                        }
                        if (!string.IsNullOrEmpty(arreglo))
                        {
                            arreglo = arreglo.Substring(0, arreglo.Length - 1);
                        }
                        datos.FCO_DESCRIPCION = arreglo;
                    }
                    else if (item.FCO_TIPODATO == "A")
                    {
                        datos.archivo = null;
                        if (imagenPerfil != null && imagenPerfil.ContentLength > 0)
                        {
                            byte[] fileData = null;
                            using (var binaryReader = new BinaryReader(imagenPerfil.InputStream))
                            {
                                fileData = binaryReader.ReadBytes(imagenPerfil.ContentLength);
                            }

                            datos.archivo = fileData;
                            datos.FCO_DESCRIPCION = imagenPerfil.FileName;
                            datos.NombreArchivo = imagenPerfil.FileName;
                            datos.TipoArchivo = imagenPerfil.ContentType;

                        }

                    }
                    listFormularioResultado.Add(datos);
                }
                FormulariosLogica.GuardarFormulario(listFormularioResultado, Id);
            }

            EscuelaEncabezadoDTO escuela = FormulariosLogica.ConsultarEncabezadoEscuela(Id);
            ViewBag.NombreEscuela = escuela.Nombre;
            ViewBag.ResenaEscuela = escuela.Resena;
            ViewBag.EscuelaId = Id;
            var model = CargarFormulariosActivos(Id);
            Success(string.Format("<b>{0}</b> Se actualizo con éxito", escuela.Nombre), true);

            return View(model);
        }


        private List<FormularioModels> CargarFormulariosActivos(int Id)
        {
            var model = new List<FormularioModels>();
            List<FormularioDTO> listFormulario = FormulariosLogica.ConsultarFormulariosActivos();
            List<FormularioSeccionesDTO> listSeccionesFormularios = FormulariosLogica.ConsultarSeccionesTodas();
            List<FormularioCamposDTO> listCamposFormularios = FormulariosLogica.ConsultarCamposFormulariodinamicoTodos();
            foreach (var item in listFormulario)
            {
                FormularioModels datos = new FormularioModels();
                datos.Descripcion = item.Descripcion;
                datos.EsActiva = item.EsActiva;
                datos.EsEditable = item.EsEditable;
                datos.EsVisible = item.EsVisible;
                datos.FechaRegistro = item.FechaRegistro;
                datos.ForID = item.ForID;
                datos.Nombre = item.Nombre;
                datos.Perfiles = item.Perfiles;
                datos.listSecciones = listSeccionesFormularios.Where(x => x.FOR_ID == datos.ForID).ToList();
                datos.listCampos = CargarCamposFormularios(listCamposFormularios, datos.ForID, Id);
                model.Add(datos);
            }

            return model;
        }

        private List<FormularioCamposModels> CargarCamposFormularios(List<FormularioCamposDTO> listCamposFormularios, decimal ForId, decimal EscuelaId)
        {
            List<FormularioCamposModels> listCamposModels = new List<FormularioCamposModels>();
            List<FormularioValoresDTO> listValores = FormulariosLogica.ConsultarValores(EscuelaId, ForId);
            if (listCamposFormularios != null)
            {
                List<FormularioCamposDTO> listCampos = listCamposFormularios.Where(x => x.FOR_ID == ForId).ToList();
                foreach (var item in listCampos)
                {
                    FormularioCamposModels datos = new FormularioCamposModels();
                    FormularioValoresDTO datosvalores = new FormularioValoresDTO();
                    string selected = "";
                    datosvalores = listValores.Where(x => x.FCO_ID == item.FCO_ID).FirstOrDefault();
                    if (datosvalores != null)
                    {
                        if (datosvalores.FVA_VALOR != null)
                        {
                            selected = datosvalores.FVA_VALOR;
                            datos.FCO_DESCRIPCION = datosvalores.FVA_VALOR;
                        }
                    }
                    else
                    {
                        datos.FCO_DESCRIPCION = item.FCO_DESCRIPCION;
                    }

                    if (item.FCO_TIPODATO == "L")
                    {
                        if (item.listadoBasico != null)
                        {
                            if (string.IsNullOrEmpty(selected))
                                datos.ColeccionDatos = new SelectList(item.listadoBasico, "value", "text");
                            else
                                datos.ColeccionDatos = new SelectList(item.listadoBasico, "value", "text", selected);

                        }
                        else
                        {
                            List<BasicaDTO> objeto = new List<BasicaDTO>();
                            datos.ColeccionDatos = new SelectList(objeto, "value", "text");
                        }
                    }
                    if (item.FCO_TIPODATO == "M")
                    {
                        List<EstandarDTO> listEstandar = new List<EstandarDTO>();

                        if (item.listadoBasico != null)
                        {
                            string[] arrayDato = selected.Split(',');

                            foreach (var x in item.listadoBasico)
                            {
                                EstandarDTO estandar = new EstandarDTO();
                                estandar.Id = x.value;
                                estandar.Nombre = x.text;
                                if ((arrayDato.Length == 0) || (arrayDato == null))
                                    estandar.EsSeleccionado = false;
                                else
                                {
                                    bool esCheked = false;
                                    foreach (string s in arrayDato)
                                    {
                                        if (s == x.text)
                                        {
                                            esCheked = true;
                                            break;
                                        }
                                    }
                                    estandar.EsSeleccionado = esCheked;
                                }

                                listEstandar.Add(estandar);
                            }


                            datos.listadoData = listEstandar;

                        }
                        else
                            datos.listadoData = listEstandar;

                    }

                    datos.FCO_ESOBLIGATORIA = item.FCO_ESOBLIGATORIA;
                    datos.FCO_ID = item.FCO_ID;
                    datos.FCO_NOMBRE = item.FCO_NOMBRE;
                    datos.FCO_ORDEN = item.FCO_ORDEN;
                    datos.FCO_TIPODATO = item.FCO_TIPODATO;
                    datos.FLI_ID = item.FLI_ID;
                    datos.FOR_ID = item.FOR_ID;
                    datos.FSC_DUPLICACIONES = item.FSC_DUPLICACIONES;
                    datos.FSC_ID = item.FSC_ID;
                    datos.FSC_NOMBRE = item.FSC_NOMBRE;
                    listCamposModels.Add(datos);
                }
            }

            return listCamposModels;
        }

        public ActionResult prueba(int Id)
        {
            return View();
        }


        //  [Authorize]
        public ActionResult Ficha(int Id)
        {
            var model = new EscuelasPadre();
            if (String.IsNullOrEmpty(UsuaroId))
                return RedirectToAction("Login", "Cuenta");
            //Carga los datos básicos
            model.Escuelas = CargarDatosBasicos(Id);

            Session["Estado"] = model.Escuelas.Estado;
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


            modelinstitucionalidad = TranslatorEscuelas.CargarInstitucionalidad(Id);
            modelinfraestructura = TranslatorEscuelas.CargarInfraestructura(Id);
            modelParticipacion = TranslatorEscuelas.CargarParticipacion(Id);
            modelFormacion = TranslatorEscuelas.CargarFormacion(Id);
            modelProduccion = TranslatorEscuelas.CargarProduccion(Id);
            modelRedes = TranslatorEscuelas.CargarDatosRedes(Id);

            modelinfraestructura.FuentesDotacionSeleccionada = ParametrosLogica.ConsultarFuentesDotacionSeleccionada(Convert.ToDecimal(Id));
            modelinfraestructura.MaterialPedagogicoSeleccionada = ParametrosLogica.ConsultarMaterialPedagogicoSeleccionada(Convert.ToDecimal(Id));
            modelinfraestructura.TiposFuentesDotacionSeleccionada = ParametrosLogica.ConsultarTiposFuentesDotacionSeleccionada(Convert.ToDecimal(Id));
            modelinfraestructura.TipoSolucionesAcusticasSeleccionada = ParametrosLogica.ConsultarSolucionesAcusticasSeleccionada(Convert.ToDecimal(Id));
            modelinfraestructura.TiposInternetSeleccionada = ParametrosLogica.ConsultarTiposInternetSeleccionados(Convert.ToDecimal(Id));
            // cargamos en la clase padre
            model.Institucionalidad = modelinstitucionalidad;
            model.Infraestructura = modelinfraestructura;
            model.Participacion = modelParticipacion;
            model.Formacion = modelFormacion;
            model.Produccion = modelProduccion;
            model.RedesSociales = modelRedes;


            return View(model);
        }


        public ActionResult CambiarEstado(int Id, int wizard = 0)
        {
            if (String.IsNullOrEmpty(UsuaroId))
                return RedirectToAction("Login", "Cuenta");

            bool EsAdmin = false;
            bool EsCoordinador = false;
            bool EsPermitido = false;
            var modelnuevo = new EscuelasNuevo();
            var model = new Escuelas();
            var modelRedes = new RedesSocialesModel();
            modelnuevo.EscuelaId = Id;

            ///validacion para cronogramas y visitas

            EsAdmin = UsuarioLogica.UsuarioEsAdmin(Convert.ToInt32(UsuaroId), Comunes.ConstantesRecursosBD.CODIGO_ADMIN);

            if (EsAdmin)
                EsPermitido = true;

            if (!EsPermitido)
            {
                EsCoordinador = UsuarioLogica.UsuarioEsCoordinadorAsesor(Convert.ToInt32(UsuaroId), Comunes.ConstantesRecursosBD.CODIGO_COORDINADOR, Comunes.ConstantesRecursosBD.CODIGO_ASESOR);
            }

            //Carga los datos básicos
            model = CargarDatosBasicos(Id);

            if (model.imagen != null)
            {
                string imageBase64Data = Convert.ToBase64String(model.imagen);
                string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                TempData["imagen"] = imageDataURL;
                ViewBag.ImageData = imageDataURL;
            }
            else
            {
                ///TODO.  Dejar como constante "~/assets/images/users/user2.jpg";
                TempData["imagen"] = "~/img/defaultUser.jpg";
                ViewBag.ImageData = "~/img/defaultUser.jpg";
            }

            ViewBag.NombreEscuela = model.NombreEscuela + " - " + ZonaGeograficasLogica.ObtenerNombreDepartamentoyMunicipio(model.MunicipioSelector);

            

            modelRedes = TranslatorEscuelas.CargarDatosRedes(Id);
            modelnuevo.Escuelas = model;
            var EscuelaDocumentos = new EscuelaDocumentoModels();
            EscuelaDocumentos.EscuelaId = Id;
            modelnuevo.Documentos = EscuelaDocumentos;
            modelnuevo.RedesSociales = modelRedes;

            cargarParametrosNuevo(model.DepartamentoSelector);
            List<BasicaDTO> objTipo = CaracterizacionMusicalNeg.ConsultarEstados();
            ViewBag.listEstado = new SelectList(objTipo, "value", "text");

            //Operatividad de la escuela

            List<BasicaDTO> listTipoOperacion = SM.Aplicacion.Servicios.ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_TIPO_OPERACION);
            ViewBag.listOperacion = new SelectList(listTipoOperacion, "value", "text");

            return View(modelnuevo);
        }


        [HttpPost]
        public ActionResult CambiarEstado(HttpPostedFileBase imagenPerfil, int Id, Escuelas model, RedesSocialesModel RedesData, string Guardar, string Redes)
        {
            string imageDataURL = "";
            string Mensaje = "";
            var modelnuevo = new EscuelasNuevo();

            if (ModelState.IsValid)
            {
                ViewBag.NombreEscuela = model.NombreEscuela + " - " + ZonaGeograficasLogica.ObtenerNombreDepartamentoyMunicipio(model.MunicipioSelector);


                decimal UsuarioSipaId = UsuarioLogica.ObtenerUsuarioSipaId(Usuario);

                byte[] fileData = null;
                if (imagenPerfil != null && imagenPerfil.ContentLength > 0)
                {

                    using (var binaryReader = new BinaryReader(imagenPerfil.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(imagenPerfil.ContentLength);
                    }
                    EscuelasLogica.ActualizarImagen(Convert.ToDecimal(Id), fileData, Convert.ToInt32(UsuaroId), NombreCompletoUsuario, Request.UserHostAddress);

                    string imageBase64Data = Convert.ToBase64String(fileData);
                    imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                    TempData["imagen"] = imageDataURL;
                    ViewBag.ImageData = imageDataURL;

                }
                else
                {

                    if (model.imagen != null)
                    {
                        string imageBase64Data = Convert.ToBase64String(model.imagen);
                        imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                        TempData["imagen"] = imageDataURL;
                    }
                    else
                    {
                        if (TempData["imagen"] != null)
                            imageDataURL = (string)TempData["imagen"];
                        else
                            imageDataURL = "~/img/defaultUser.jpg";
                    }

                    TempData["imagen"] = imageDataURL;
                    ViewBag.ImageData = imageDataURL;

                }
                if (Guardar == "Siguiente")
                {


                    EscuelasLogica.ActualizarEScuelaGeo(Convert.ToDecimal(Id),
                                                    model.NombreEscuela,
                                                    String.Empty,
                                                    model.SitioWeb,
                                                    model.Nit,
                                                    Convert.ToInt32(model.AnoValue),
                                                    model.NombreContacto,
                                                    model.Cargo,
                                                    model.Resena,
                                                    model.Telefono,
                                                    model.CorreoElectronico,
                                                   UsuarioSipaId,
                                                    model.MunicipioSelector,
                                                    model.Area,
                                                    model.Direccion,
                                                    model.TelefonoEscuela,
                                                    model.Fax,
                                                    model.CorreoElectronicoEscuela,
                                                    fileData,
                                                    model.Naturaleza,
                                                    model.TipoEscuelas.ToString(),
                                                    model.Latitud,
                                                    model.Longitud,
                                                    Convert.ToInt32(model.EstadoId),
                                                   model.OperacionEscuela,
                                                    Convert.ToInt32(UsuaroId),
                                                   NombreCompletoUsuario,
                                                    Request.UserHostAddress);


                    string estadoFinal = "N"; // Valor por defecto

                    switch (Convert.ToInt32(model.EstadoId)) // Convert 'EstadoId' to int for comparison
                    {
                        case 1:
                            estadoFinal = "N"; // No Publicado
                            break;
                        case 2:
                            estadoFinal = "E"; // Publicado
                            break;
                        case 3:
                            estadoFinal = "E"; // Publicado
                            break;
                    }

                    EscuelasLogica.ActualizarEscuelaEstado(
                        Id,
                        estadoFinal,
                        Convert.ToInt32(UsuaroId),
                        NombreCompletoUsuario,
                        Request.UserHostAddress
                    );

                    BasicaDTO nombres = ZonaGeograficasLogica.ObtenerNombres(model.MunicipioSelector);

                    string mensaje = "La escuela de música con el Id: " + Id.ToString() + ". Nombre: " + model.NombreEscuela;
                    if (nombres != null)
                    {
                        mensaje += ". Departamento: " + nombres.value + "  Municipio: " + nombres.text;
                    }
                    mensaje += ".  Ha sido actualizada por cambio de estado por el usuario.  " + NombreCompletoUsuario;
                    mensajeCorreo(mensaje, model.NombreEscuela);

                    // envio de mensaje por correo electronico
                    if (Convert.ToInt32(model.EstadoId) != Convert.ToInt32(model.EstadoOldId))
                    {
                        bool validacionEmail = NotificacionCorreo.IsValidEmail(model.CorreoElectronico);
                        if (validacionEmail)
                            NotificacionCorreo.MensajeNotificaionPorEstado(model.CorreoElectronico,
                                                                           model.NombreEscuela,
                                                                           Convert.ToInt32(model.EstadoId),
                                                                           "Escuelas",
                                                                           Convert.ToInt32(model.EscuelaId),
                                                                           Convert.ToInt32(UsuaroId),
                                                                           NombreCompletoUsuario,
                                                                           model.Motivo);
                    }
                    

                    return RedirectToAction("Beneficiarios", "EscuelasMusica", new { Id = Id });
                }
                else if (Redes == "Guardar")
                {
                    GrabarRedes(RedesData, Id);

                }

            }

            List<BasicaDTO> objTipo = CaracterizacionMusicalNeg.ConsultarEstados();
            ViewBag.listEstado = new SelectList(objTipo, "value", "text");

            List<BasicaDTO> listTipoOperacion = SM.Aplicacion.Servicios.ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_TIPO_OPERACION);
            ViewBag.listOperacion = new SelectList(listTipoOperacion, "value", "text");

            // CargarParametros datos básicos
            CargarParametrosPostNuevo(model.DepartamentoSelector);
            modelnuevo.Escuelas = model;
            modelnuevo.EscuelaId = Id;
            modelnuevo.RedesSociales = RedesData;
            var EscuelaDocumentos = new EscuelaDocumentoModels();

            EscuelaDocumentos.EscuelaId = Id;
            modelnuevo.Documentos = EscuelaDocumentos;
            if (string.IsNullOrEmpty(Mensaje))
                Success(string.Format("<b>{0}</b> Se actualizo con éxito", model.NombreEscuela), true);
            else
                Warning(string.Format(Mensaje), true);
            return View("CambiarEstado", modelnuevo);
        }


        void cargarParametros(string codigoDepartamento, string codigoRegimen)
        {
            List<BasicaDTO> objMunicipios = new List<BasicaDTO>();
            List<BasicaDTO> objDepartamentos = ZonaGeograficasLogica.ConsultarDepartamentos();
            TempData["Departamentos"] = objDepartamentos;
            ViewBag.departamentos = new SelectList(objDepartamentos, "value", "text");

            if (!String.IsNullOrEmpty(codigoDepartamento))
                objMunicipios = ZonaGeograficasLogica.ConsultarMunicipios(codigoDepartamento);

            ViewBag.municipios = new SelectList(objMunicipios, "value", "text");
            List<BasicaDTO> objAnos = BasicaLogica.ConsultarListadoAnos();
            TempData["ListAnos"] = objAnos;
            ViewBag.Anos = new SelectList(objAnos, "value", "text");

            //Parametros institucionalidad
            List<BasicaDTO> objParametros = new List<BasicaDTO>();
            List<BasicaDTO> objCategoria = new List<BasicaDTO>();
            List<BasicaDTO> objRegimen = ParametrosLogica.ConsultarRegimenPadre();
            List<BasicaDTO> ObjNaturaleza = BasicaLogica.ConsultarNaturaleza();
            List<BasicaDTO> ObjNiveles = ParametrosLogica.ConsultarNivelesAdministracion();
            List<BasicaDTO> ObjTiposVinculacion = ParametrosLogica.ConsultarTipoVinculacionDirector();
            List<BasicaDTO> ObjEspacios = ParametrosLogica.ConsultarEspacios();
            List<BasicaDTO> ObjOrganizacion = ParametrosLogica.ConsultarOrganizacionComunitaria();
            List<BasicaDTO> objTipoDocumentoCreacion = InstitucionalidadLogica.ObtenerTipoDocumentoCreacion();


            List<BasicaDTO> objTipoEscuela = ParametrosLogica.ConsultarTipoEscuelasMusica();
            objCategoria = Cargartipodocumento();
            TempData["Categoria"] = objCategoria;
            TempData["RegimenPadre"] = objRegimen;
            TempData["Naturaleza"] = ObjNaturaleza;
            TempData["Niveles"] = ObjNiveles;
            TempData["TiposVinculacion"] = ObjTiposVinculacion;
            TempData["Espacios"] = ObjEspacios;
            TempData["Organizacion"] = ObjOrganizacion;
            TempData["TipoDocumentoCreacion"] = objTipoDocumentoCreacion;
            TempData["TipoEscuelas"] = objTipoEscuela;

            if (!String.IsNullOrEmpty(codigoRegimen))
                objParametros = ParametrosLogica.ConsultarRegimenHijos(codigoRegimen);
            ViewBag.listRegimen = new SelectList(objRegimen, "value", "text");
            ViewBag.listSubregimen = new SelectList(objParametros, "value", "text");
            ViewBag.listNaturaleza = new SelectList(ObjNaturaleza, "value", "text");
            ViewBag.listNivel = new SelectList(ObjNiveles, "value", "text");
            ViewBag.listTipovinculacion = new SelectList(ObjTiposVinculacion, "value", "text");
            ViewBag.listTipoDocumentoCreacion = new SelectList(objTipoDocumentoCreacion, "value", "text");
            //Parametros Infraestructura
            ViewBag.listEspacio = new SelectList(ObjEspacios, "value", "text");
            ViewBag.listTipoEscuelasMusica = new SelectList(objTipoEscuela, "value", "text");
            ViewBag.listCategoria = new SelectList(objCategoria, "value", "text");

            //Parametros Participacion
            ViewBag.listTipoOrganizacion = new SelectList(ObjOrganizacion, "value", "text");

        }

        private void cargarParametrosOrganizacion(string codigoRegimen)
        {

            //Parametros institucionalidad
            List<BasicaDTO> objParametros = new List<BasicaDTO>();
            List<BasicaDTO> objRegimen = ParametrosLogica.ConsultarRegimenPadre();
            List<BasicaDTO> ObjNiveles = ParametrosLogica.ConsultarNivelesAdministracion();
            List<BasicaDTO> ObjTiposVinculacion = ParametrosLogica.ConsultarTipoVinculacionDirector();
            List<BasicaDTO> ObjEspacios = ParametrosLogica.ConsultarEspacios();
            List<BasicaDTO> ObjOrganizacion = ParametrosLogica.ConsultarOrganizacionComunitaria();
            List<BasicaDTO> objTipoDocumentoCreacion = InstitucionalidadLogica.ObtenerTipoDocumentoCreacion();

            List<BasicaDTO> listOperaEntidad = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_OPERA_ENTIDAD);
            ViewBag.listOperaEntidad = new SelectList(listOperaEntidad, "value", "text");



            if (!String.IsNullOrEmpty(codigoRegimen))
                objParametros = ParametrosLogica.ConsultarRegimenHijos(codigoRegimen);
            ViewBag.listRegimen = new SelectList(objRegimen, "value", "text");
            ViewBag.listSubregimen = new SelectList(objParametros, "value", "text");
            ViewBag.listNivel = new SelectList(ObjNiveles, "value", "text");
            ViewBag.listTipovinculacion = new SelectList(ObjTiposVinculacion, "value", "text");
            ViewBag.listTipoDocumentoCreacion = new SelectList(objTipoDocumentoCreacion, "value", "text");
            //Parametros Infraestructura
            ViewBag.listEspacio = new SelectList(ObjEspacios, "value", "text");


        }

        private void cargarParametrosInfraestructura()
        {

            List<BasicaDTO> ObjEspacios = ParametrosLogica.ConsultarEspacios();
            List<BasicaDTO> objCategoria = new List<BasicaDTO>();
            objCategoria = Cargartipodocumento();
            TempData["Categoria"] = objCategoria;


            ViewBag.listEspacio = new SelectList(ObjEspacios, "value", "text");

            ViewBag.listCategoria = new SelectList(objCategoria, "value", "text");

        }
        private void cargarParametrosNuevo(string codigoDepartamento)
        {
            List<BasicaDTO> objMunicipios = new List<BasicaDTO>();
            List<BasicaDTO> objDepartamentos = ZonaGeograficasLogica.ConsultarDepartamentos();
            TempData["Departamentos"] = objDepartamentos;
            ViewBag.departamentos = new SelectList(objDepartamentos, "value", "text");

            if (!String.IsNullOrEmpty(codigoDepartamento))
                objMunicipios = ZonaGeograficasLogica.ConsultarMunicipios(codigoDepartamento);

            ViewBag.municipios = new SelectList(objMunicipios, "value", "text");
            List<BasicaDTO> objAnos = BasicaLogica.ConsultarListadoAnos();
            TempData["ListAnos"] = objAnos;
            ViewBag.Anos = new SelectList(objAnos, "value", "text");

            List<BasicaDTO> ObjNaturaleza = BasicaLogica.ConsultarNaturaleza();
            List<BasicaDTO> objTipoEscuela = ParametrosLogica.ConsultarTipoEscuelasMusica();

            TempData["Naturaleza"] = ObjNaturaleza;
            TempData["TipoEscuelas"] = objTipoEscuela;

            ViewBag.listNaturaleza = new SelectList(ObjNaturaleza, "value", "text");

            //Parametros Infraestructura
            ViewBag.listTipoEscuelasMusica = new SelectList(objTipoEscuela, "value", "text");

            List<BasicaDTO> objCategoria = new List<BasicaDTO>();

            if (TempData["Categoria"] != null)
                objCategoria = (List<BasicaDTO>)TempData["Categoria"];
            else
            {
                objCategoria = Cargartipodocumento();
                TempData["Categoria"] = objCategoria;
            }

            ViewBag.listCategoria = new SelectList(objCategoria, "value", "text");
        }
        private void CargarParametrosPost(string codigoDepartamento, string codigoRegimen)
        {
            List<BasicaDTO> objMunicipios = new List<BasicaDTO>();
            List<BasicaDTO> objParametros = new List<BasicaDTO>();
            List<BasicaDTO> objDepartamentos;
            List<BasicaDTO> objAnos;
            List<BasicaDTO> objRegimen;
            List<BasicaDTO> ObjNaturaleza;
            List<BasicaDTO> ObjNiveles;
            List<BasicaDTO> ObjTiposVinculacion;
            List<BasicaDTO> ObjEspacios;
            List<BasicaDTO> ObjOrganizacion;
            List<BasicaDTO> objTipoDocumentoCreacion;
            List<BasicaDTO> objTipoEscuela;
            List<BasicaDTO> objCategoria = new List<BasicaDTO>();

            if (TempData["Categoria"] != null)
                objCategoria = (List<BasicaDTO>)TempData["Categoria"];
            else
            {
                objCategoria = Cargartipodocumento();
                TempData["Categoria"] = objCategoria;
            }

            if (TempData["TipoEscuelas"] != null)
                objTipoEscuela = (List<BasicaDTO>)TempData["TipoEscuelas"];
            else
            {
                objTipoEscuela = ParametrosLogica.ConsultarTipoEscuelasMusica();
                TempData["TipoEscuelas"] = objTipoEscuela;
            }


            if (TempData["Departamentos"] != null)
                objDepartamentos = (List<BasicaDTO>)TempData["Departamentos"];
            else
            {
                objDepartamentos = ZonaGeograficasLogica.ConsultarDepartamentos();
                TempData["Departamentos"] = objDepartamentos;
            }

            ViewBag.departamentos = new SelectList(objDepartamentos, "value", "text");

            if (!String.IsNullOrEmpty(codigoDepartamento))
                objMunicipios = ZonaGeograficasLogica.ConsultarMunicipios(codigoDepartamento);

            ViewBag.municipios = new SelectList(objMunicipios, "value", "text");
            if (TempData["ListAnos"] != null)
                objAnos = (List<BasicaDTO>)TempData["ListAnos"];
            else
            {
                objAnos = BasicaLogica.ConsultarListadoAnos();
                TempData["ListAnos"] = objAnos;
            }
            if (TempData["TipoDocumentoCreacion"] != null)
                objTipoDocumentoCreacion = (List<BasicaDTO>)TempData["TipoDocumentoCreacion"];
            else
            {
                objTipoDocumentoCreacion = InstitucionalidadLogica.ObtenerTipoDocumentoCreacion();
                TempData["TipoDocumentoCreacion"] = objTipoDocumentoCreacion;
            }

            if (TempData["RegimenPadre"] != null)
                objRegimen = (List<BasicaDTO>)TempData["RegimenPadre"];
            else
            {
                objRegimen = ParametrosLogica.ConsultarRegimenPadre();
                TempData["RegimenPadre"] = objRegimen;
            }

            if (TempData["Naturaleza"] != null)
                ObjNaturaleza = (List<BasicaDTO>)TempData["Naturaleza"];
            else
            {
                ObjNaturaleza = BasicaLogica.ConsultarNaturaleza();
                TempData["Naturaleza"] = ObjNaturaleza;
            }

            if (TempData["Niveles"] != null)
                ObjNiveles = (List<BasicaDTO>)TempData["Niveles"];
            else
            {
                ObjNiveles = ParametrosLogica.ConsultarNivelesAdministracion();
                TempData["Niveles"] = ObjNiveles;
            }

            if (TempData["TiposVinculacion"] != null)
                ObjTiposVinculacion = (List<BasicaDTO>)TempData["TiposVinculacion"];
            else
            {
                ObjTiposVinculacion = ParametrosLogica.ConsultarTipoVinculacionDirector();
                TempData["TiposVinculacion"] = ObjTiposVinculacion;
            }

            if (TempData["Espacios"] != null)
                ObjEspacios = (List<BasicaDTO>)TempData["Espacios"];
            else
            {
                ObjEspacios = ParametrosLogica.ConsultarEspacios();
                TempData["Espacios"] = ObjEspacios;
            }

            if (TempData["Organizacion"] != null)
                ObjOrganizacion = (List<BasicaDTO>)TempData["Organizacion"];
            else
            {
                ObjOrganizacion = ParametrosLogica.ConsultarOrganizacionComunitaria();
                TempData["Organizacion"] = ObjOrganizacion;
            }


            if (!String.IsNullOrEmpty(codigoRegimen))
                objParametros = ParametrosLogica.ConsultarRegimenHijos(codigoRegimen);

            ViewBag.Anos = new SelectList(objAnos, "value", "text");
            ViewBag.listRegimen = new SelectList(objRegimen, "value", "text");
            ViewBag.listSubregimen = new SelectList(objParametros, "value", "text");
            ViewBag.listNaturaleza = new SelectList(ObjNaturaleza, "value", "text");
            ViewBag.listNivel = new SelectList(ObjNiveles, "value", "text");
            ViewBag.listTipovinculacion = new SelectList(ObjTiposVinculacion, "value", "text");
            ViewBag.listTipoDocumentoCreacion = new SelectList(objTipoDocumentoCreacion, "value", "text");
            ViewBag.listTipoEscuelasMusica = new SelectList(objTipoEscuela, "value", "text");
            ViewBag.listCategoria = new SelectList(objCategoria, "value", "text");
            //Parametros Infraestructura
            ViewBag.listEspacio = new SelectList(ObjEspacios, "value", "text");

            //Parametros Participacion
            ViewBag.listTipoOrganizacion = new SelectList(ObjOrganizacion, "value", "text");

        }

        private void CargarParametrosPostNuevo(string codigoDepartamento)
        {
            List<BasicaDTO> objMunicipios = new List<BasicaDTO>();
            List<BasicaDTO> objParametros = new List<BasicaDTO>();
            List<BasicaDTO> objDepartamentos;
            List<BasicaDTO> objAnos;
            List<BasicaDTO> ObjNaturaleza;
            List<BasicaDTO> objTipoEscuela;

            if (TempData["TipoEscuelas"] != null)
                objTipoEscuela = (List<BasicaDTO>)TempData["TipoEscuelas"];
            else
            {
                objTipoEscuela = ParametrosLogica.ConsultarTipoEscuelasMusica();
                TempData["TipoEscuelas"] = objTipoEscuela;
            }


            if (TempData["Departamentos"] != null)
                objDepartamentos = (List<BasicaDTO>)TempData["Departamentos"];
            else
            {
                objDepartamentos = ZonaGeograficasLogica.ConsultarDepartamentos();
                TempData["Departamentos"] = objDepartamentos;
            }

            ViewBag.departamentos = new SelectList(objDepartamentos, "value", "text");

            if (!String.IsNullOrEmpty(codigoDepartamento))
                objMunicipios = ZonaGeograficasLogica.ConsultarMunicipios(codigoDepartamento);

            ViewBag.municipios = new SelectList(objMunicipios, "value", "text");
            if (TempData["ListAnos"] != null)
                objAnos = (List<BasicaDTO>)TempData["ListAnos"];
            else
            {
                objAnos = BasicaLogica.ConsultarListadoAnos();
                TempData["ListAnos"] = objAnos;
            }




            if (TempData["Naturaleza"] != null)
                ObjNaturaleza = (List<BasicaDTO>)TempData["Naturaleza"];
            else
            {
                ObjNaturaleza = BasicaLogica.ConsultarNaturaleza();
                TempData["Naturaleza"] = ObjNaturaleza;
            }



            ViewBag.Anos = new SelectList(objAnos, "value", "text");
            ViewBag.listSubregimen = new SelectList(objParametros, "value", "text");
            ViewBag.listNaturaleza = new SelectList(ObjNaturaleza, "value", "text");
            ViewBag.listTipoEscuelasMusica = new SelectList(objTipoEscuela, "value", "text");
            List<BasicaDTO> objCategoria = new List<BasicaDTO>();

            if (TempData["Categoria"] != null)
                objCategoria = (List<BasicaDTO>)TempData["Categoria"];
            else
            {
                objCategoria = Cargartipodocumento();
                TempData["Categoria"] = objCategoria;
            }

            ViewBag.listCategoria = new SelectList(objCategoria, "value", "text");
        }


        private List<BasicaDTO> Cargartipodocumento()
        {

            List<BasicaDTO> objCategoria = new List<BasicaDTO>();
            ///Todo
            ///reemplazar por tabla
            objCategoria.Add(new BasicaDTO { value = "1", text = "Matriz proyecto productivo" });
            objCategoria.Add(new BasicaDTO { value = "2", text = "Matriz proyecto organizativo" });
            objCategoria.Add(new BasicaDTO { value = "3", text = "Altas de almacén" });
            objCategoria.Add(new BasicaDTO { value = "4", text = "Contrato director" });
            objCategoria.Add(new BasicaDTO { value = "5", text = "Contrato personal administrativo" });
            objCategoria.Add(new BasicaDTO { value = "6", text = "Contrato profesor" });
            objCategoria.Add(new BasicaDTO { value = "7", text = "Estatutos" });
            objCategoria.Add(new BasicaDTO { value = "8", text = "Manual de convivencia" });
            objCategoria.Add(new BasicaDTO { value = "9", text = "Manual de funcionamiento" });
            objCategoria.Add(new BasicaDTO { value = "10", text = "Manual de uso de servicios y espacios" });
            objCategoria.Add(new BasicaDTO { value = "11", text = "Organigrama" });
            objCategoria.Add(new BasicaDTO { value = "12", text = "Organización académica" });
            objCategoria.Add(new BasicaDTO { value = "13", text = "Plan de acción" });
            objCategoria.Add(new BasicaDTO { value = "14", text = "Plan estratégico" });
            objCategoria.Add(new BasicaDTO { value = "15", text = "Póliza" });
            objCategoria.Add(new BasicaDTO { value = "16", text = "Portafolio" });
            objCategoria.Add(new BasicaDTO { value = "17", text = "Proyecto educativo musical" });
            objCategoria.Add(new BasicaDTO { value = "18", text = "Acta de reunión de  visita" });
            objCategoria.Add(new BasicaDTO { value = "19", text = "Seguimiento iniciación" });

            TempData["Categoria"] = objCategoria;

            return objCategoria;
        }
        public ActionResult Infraestructura(int Id)
        {
            if (String.IsNullOrEmpty(UsuaroId))
                return RedirectToAction("Login", "Cuenta");

            var model = new InfraestructuraModel();
            bool existe = false;

            existe = InfraestructuraLogica.ValidarInfraestructura(Convert.ToDecimal(Id));

            if (!existe)
            {
                model.EsSedeAsignada = 1;
                model.EsAdecuadaAcusticamente = 1;
                model.TieneAccesoInternet = 1;
                model.TieneMaterialPedagogico = 1;

            }
            else
            {
                model = TranslatorEscuelas.CargarInfraestructura(Id);

            }
            //Cargamos listas Infraestructura
            List<EstandarDTO> FuentesDotacion = ParametrosLogica.ConsultarFuentesDotacion();
            TempData["FuentesDotacion"] = FuentesDotacion;
            List<EstandarDTO> MaterialPedagogico = ParametrosLogica.ConsultarMaterialPedagogico();
            TempData["MaterialPedagogico"] = MaterialPedagogico;
            List<EstandarDTO> TiposFuentesDotcion = ParametrosLogica.ConsultarTiposFuentesDotacion();
            TempData["TiposFuentesDotcion"] = TiposFuentesDotcion;
            List<EstandarDTO> Soluciones = ParametrosLogica.ConsultarSolucionesAcusticas();
            TempData["Soluciones"] = Soluciones;
            List<EstandarDTO> TiposInternet = ParametrosLogica.ConsultarTiposInternet();
            TempData["TiposInternet"] = TiposInternet;
            model.FuentesDotacionData = FuentesDotacion;
            model.MaterialPedagogicoData = MaterialPedagogico;
            model.TiposFuentesDotacionData = TiposFuentesDotcion;
            model.TipoSolucionesAcusticasData = Soluciones;
            model.TiposInternetData = TiposInternet;

            model.FuentesDotacionSeleccionada = ParametrosLogica.ConsultarFuentesDotacionSeleccionada(Convert.ToDecimal(Id));
            model.MaterialPedagogicoSeleccionada = ParametrosLogica.ConsultarMaterialPedagogicoSeleccionada(Convert.ToDecimal(Id));
            model.TiposFuentesDotacionSeleccionada = ParametrosLogica.ConsultarTiposFuentesDotacionSeleccionada(Convert.ToDecimal(Id));
            model.TipoSolucionesAcusticasSeleccionada = ParametrosLogica.ConsultarSolucionesAcusticasSeleccionada(Convert.ToDecimal(Id));
            model.TiposInternetSeleccionada = ParametrosLogica.ConsultarTiposInternetSeleccionados(Convert.ToDecimal(Id));
            model.EscuelaId = Id;

            ViewBag.NombreEscuela = EscuelasLogica.ObtenerNombreEscuela(Id) + " - " + ZonaGeograficasLogica.ObtenerNombresPorEscuelaId(Id);
            model.NombreEscuela = ViewBag.NombreEscuela + " - " + ZonaGeograficasLogica.ObtenerNombresPorEscuelaId(Id);
            cargarParametrosInfraestructura();
            return View(model);
        }

        [HttpPost]
        public ActionResult Infraestructura(int Id, InfraestructuraModel model)
        {
            string Mensaje = "";

            if (ModelState.IsValid)
            {
                ViewBag.NombreEscuela = model.NombreEscuela + " - " + ZonaGeograficasLogica.ObtenerNombresPorEscuelaId(Id);

                if (String.IsNullOrEmpty(model.Espacio) || (model.Espacio == "Seleccione un valor"))
                {
                    Mensaje = "Es obligatorio seleccionar un espacio";
                }
                else
                {
                    if (String.IsNullOrEmpty(model.CantidadCuerdasPulsadas) && String.IsNullOrEmpty(model.CantidadVientosMadera) && String.IsNullOrEmpty(model.CantidadVientosMetales) && String.IsNullOrEmpty(model.CantidadOtros) && String.IsNullOrEmpty(model.CantidadCuerdasSinfonicas) && String.IsNullOrEmpty(model.CantidadPercusionMenor) && String.IsNullOrEmpty(model.CantidadPercusionSinfonica))
                    {
                        Mensaje = "Al menos un campo de cantidad de instrumentos con los que cuenta es obligatorio";
                    }
                }


                if (String.IsNullOrEmpty(Mensaje))
                {
                    GrabarInfraestructura(model, Id);


                    // BasicaDTO nombres = ZonaGeograficasLogica.ObtenerNombres(model.MunicipioSelector);
                    BasicaDTO nombres = new BasicaDTO();
                    string mensaje = "La escuela de música con el Id: " + Id.ToString() + ". Nombre: " + model.NombreEscuela;
                    if (nombres != null)
                    {
                        mensaje += ". Departamento: " + nombres.value + "  Municipio: " + nombres.text;
                    }
                    mensaje += ".  Ha sido actualizada en la sección de infraestructura por el usuario.  " + NombreCompletoUsuario;
                    mensajeCorreo(mensaje, model.NombreEscuela);
                    EscuelasLogica.ActualizarFechaModificacion(Convert.ToDecimal(Id));

                    return RedirectToAction("Produccion", "EscuelasMusica", new { Id = Id });
                }

            }


            //Cargamos listas Infraestructura
            List<EstandarDTO> FuentesDotacion = ParametrosLogica.ConsultarFuentesDotacion();
            TempData["FuentesDotacion"] = FuentesDotacion;
            List<EstandarDTO> MaterialPedagogico = ParametrosLogica.ConsultarMaterialPedagogico();
            TempData["MaterialPedagogico"] = MaterialPedagogico;
            List<EstandarDTO> TiposFuentesDotcion = ParametrosLogica.ConsultarTiposFuentesDotacion();
            TempData["TiposFuentesDotcion"] = TiposFuentesDotcion;
            List<EstandarDTO> Soluciones = ParametrosLogica.ConsultarSolucionesAcusticas();
            TempData["Soluciones"] = Soluciones;
            List<EstandarDTO> TiposInternet = ParametrosLogica.ConsultarTiposInternet();
            TempData["TiposInternet"] = TiposInternet;
            model.FuentesDotacionData = FuentesDotacion;
            model.MaterialPedagogicoData = MaterialPedagogico;
            model.TiposFuentesDotacionData = TiposFuentesDotcion;
            model.TipoSolucionesAcusticasData = Soluciones;
            model.TiposInternetData = TiposInternet;

            model.FuentesDotacionSeleccionada = ParametrosLogica.ConsultarFuentesDotacionSeleccionada(Convert.ToDecimal(Id));
            model.MaterialPedagogicoSeleccionada = ParametrosLogica.ConsultarMaterialPedagogicoSeleccionada(Convert.ToDecimal(Id));
            model.TiposFuentesDotacionSeleccionada = ParametrosLogica.ConsultarTiposFuentesDotacionSeleccionada(Convert.ToDecimal(Id));
            model.TipoSolucionesAcusticasSeleccionada = ParametrosLogica.ConsultarSolucionesAcusticasSeleccionada(Convert.ToDecimal(Id));
            model.TiposInternetSeleccionada = ParametrosLogica.ConsultarTiposInternetSeleccionados(Convert.ToDecimal(Id));
            model.EscuelaId = Id;

            ViewBag.NombreEscuela = model.NombreEscuela;

            cargarParametrosInfraestructura();

            if (string.IsNullOrEmpty(Mensaje))
                Success(string.Format("<b>{0}</b> Se actualizo con éxito", model.NombreEscuela), true);
            else
                Warning(string.Format(Mensaje), true);
            return View("Infraestructura", model);
        }

        public ActionResult Beneficiarios(int Id)
        {
            if (String.IsNullOrEmpty(UsuaroId))
                return RedirectToAction("Login", "Cuenta");

            var model = new ParticipacionModel();
            var practicaMusicalSeleccionada = new List<PracticaMusicales>();
            bool existe = false;

            existe = ParticipacionLogica.ValidarParticipacion(Convert.ToDecimal(Id));

            if (!existe)
            {
                model.TieneOrganizacionComunitaria = 1;
                model.TieneProyectosMusica = 1;

            }
            else
            {
                model = TranslatorEscuelas.CargarParticipacion(Id);

            }
            //cargamos listas participacion
            List<BasicaDTO> ObjOrganizacion = ParametrosLogica.ConsultarOrganizacionComunitaria();
            ViewBag.listTipoOrganizacion = new SelectList(ObjOrganizacion, "value", "text");
            List<EstandarDTO> ProyectoList = ParametrosLogica.ConsultarProyectosParticipacion();

            model.ProyectosData = ProyectoList;
            model.ProyectosSeleccionada = ParametrosLogica.ConsultarProyectosParticipacionSeleccionada(Convert.ToDecimal(Id));
            model.EscuelaId = Id;

            ViewBag.NombreEscuela = EscuelasLogica.ObtenerNombreEscuela(Id) + " - " + ZonaGeograficasLogica.ObtenerNombresPorEscuelaId(Id);
            model.NombreEscuela = ViewBag.NombreEscuela;

            return View(model);
        }

        [HttpPost]
        public ActionResult Beneficiarios(int Id, ParticipacionModel model)
        {
            string Mensaje = "";

            if (ModelState.IsValid)
            {

                if (String.IsNullOrEmpty(model.CantidadPrimeraInfancia) && String.IsNullOrEmpty(model.CantidaEntre6y11) && String.IsNullOrEmpty(model.CantidaEntre12y18)
                    && String.IsNullOrEmpty(model.CantidaEntre19y26) && String.IsNullOrEmpty(model.CantidaEntre27y60) && String.IsNullOrEmpty(model.CantidadMayores60))
                {
                    Mensaje = "Al menos un campo de rango de edades es obligatorio";
                }
                else
                {
                    if (String.IsNullOrEmpty(model.CantidadHombres) && String.IsNullOrEmpty(model.CantidadMujeres))
                    {
                        Mensaje = "Al menos un campo de alumnos por sexo es obligatorio";
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(model.CantidadRural) && String.IsNullOrEmpty(model.CantidadUrbana))
                        {
                            Mensaje = "Al menos un campo de alumnos por  área de ubicación es obligatorio";
                        }
                        else
                        {
                            int intCantidadPrimeraInfancia = 0;
                            int intCantidadCantidaEntre6y11 = 0;
                            int intCantidaEntre12y18 = 0;
                            int intCantidaEntre19y26 = 0;
                            int intCantidaEntre27y60 = 0;
                            int intCantidadMayores60 = 0;
                            int intTotalEdades = 0;
                            int intCantidaHombres = 0;
                            int intCantidadMujeres = 0;
                            int intTotalSexo = 0;
                            int intCantidadRural = 0;
                            int intCantidadUrbana = 0;
                            int intTotalUbicacion = 0;

                            if (!String.IsNullOrEmpty(model.CantidadPrimeraInfancia))
                                intCantidadPrimeraInfancia = Convert.ToInt32(model.CantidadPrimeraInfancia);

                            if (!String.IsNullOrEmpty(model.CantidaEntre6y11))
                                intCantidadCantidaEntre6y11 = Convert.ToInt32(model.CantidaEntre6y11);

                            if (!String.IsNullOrEmpty(model.CantidaEntre12y18))
                                intCantidaEntre12y18 = Convert.ToInt32(model.CantidaEntre12y18);

                            if (!String.IsNullOrEmpty(model.CantidaEntre19y26))
                                intCantidaEntre19y26 = Convert.ToInt32(model.CantidaEntre19y26);

                            if (!String.IsNullOrEmpty(model.CantidaEntre27y60))
                                intCantidaEntre27y60 = Convert.ToInt32(model.CantidaEntre27y60);

                            if (!String.IsNullOrEmpty(model.CantidadMayores60))
                                intCantidadMayores60 = Convert.ToInt32(model.CantidadMayores60);

                            intTotalEdades = intCantidadPrimeraInfancia + intCantidadCantidaEntre6y11 + intCantidaEntre12y18 + intCantidaEntre19y26 + intCantidaEntre27y60 + intCantidadMayores60;

                            if (!String.IsNullOrEmpty(model.CantidadHombres))
                                intCantidaHombres = Convert.ToInt32(model.CantidadHombres);

                            if (!String.IsNullOrEmpty(model.CantidadMujeres))
                                intCantidadMujeres = Convert.ToInt32(model.CantidadMujeres);

                            intTotalSexo = intCantidaHombres + intCantidadMujeres;

                            if (!String.IsNullOrEmpty(model.CantidadRural))
                                intCantidadRural = Convert.ToInt32(model.CantidadRural);

                            if (!String.IsNullOrEmpty(model.CantidadUrbana))
                                intCantidadUrbana = Convert.ToInt32(model.CantidadUrbana);

                            intTotalUbicacion = intCantidadRural + intCantidadUrbana;

                            if (intTotalEdades != intTotalSexo)
                            {
                                Mensaje = "la sumatoria total de alumnos por rangos de edades y la sumatoria total de alumnos por sexo debe ser igual, por favor revisar";
                            }
                            else
                            {
                                if (intTotalEdades != intTotalUbicacion)
                                {
                                    Mensaje = "la sumatoria total de alumnos por rangos de edades y la sumatoria total de alumnos por área de ubicación debe ser igual, por favor revisar";
                                }
                            }
                        }

                    }

                }


                ViewBag.NombreEscuela = model.NombreEscuela + " - " + ZonaGeograficasLogica.ObtenerNombresPorEscuelaId(Id);

                if (String.IsNullOrEmpty(Mensaje))
                {
                    GrabarParticipacion(model, Id);

                    // BasicaDTO nombres = ZonaGeograficasLogica.ObtenerNombres(model.MunicipioSelector);
                    BasicaDTO nombres = new BasicaDTO();
                    string mensaje = "La escuela de música con el Id: " + Id.ToString() + ". Nombre: " + model.NombreEscuela;
                    if (nombres != null)
                    {
                        mensaje += ". Departamento: " + nombres.value + "  Municipio: " + nombres.text;
                    }
                    mensaje += ".  Ha sido actualizada en la sección de beneficiarios por el usuario.  " + NombreCompletoUsuario;
                    mensajeCorreo(mensaje, model.NombreEscuela);
                    EscuelasLogica.ActualizarFechaModificacion(Convert.ToDecimal(Id));

                    return RedirectToAction("Organizacion", "EscuelasMusica", new { Id = Id });
                }
            }
            //cargamos listas participacion
            List<BasicaDTO> ObjOrganizacion = ParametrosLogica.ConsultarOrganizacionComunitaria();
            ViewBag.listTipoOrganizacion = new SelectList(ObjOrganizacion, "value", "text");
            List<EstandarDTO> ProyectoList = ParametrosLogica.ConsultarProyectosParticipacion();

            model.ProyectosData = ProyectoList;
            model.ProyectosSeleccionada = ParametrosLogica.ConsultarProyectosParticipacionSeleccionada(Convert.ToDecimal(Id));
            model.EscuelaId = Id;


            if (string.IsNullOrEmpty(Mensaje))
                Success(string.Format("<b>{0}</b> Se actualizo con éxito", model.NombreEscuela), true);
            else
            {
                Warning(string.Format(Mensaje), true);
                ModelState.AddModelError("", Mensaje);
            }
            return View("Beneficiarios", model);
        }

        public ActionResult Formacion(int Id)
        {
            if (String.IsNullOrEmpty(UsuaroId))
                return RedirectToAction("Login", "Cuenta");
            var modelPadre = new FormacionPadre();
            var model = new FormacionModelNuevo();
            //var modelPracticas = new FormacionPractica();

            FormacionLogica.Insertar(Convert.ToDecimal(Id));
            FormacionDatosDTO datos = FormacionLogica.ObtenerFormacionId(Convert.ToDecimal(Id));

            model = TranslatorEscuelas.TranslatorFormacionDataDTOFormacionModelNuevo(datos);
            modelPadre.EscuelaId = Id;
            model.EscuelaId = Id;
            modelPadre.basico = model;
            ViewBag.NombreEscuela = EscuelasLogica.ObtenerNombreEscuela(Id) + " - " + ZonaGeograficasLogica.ObtenerNombresPorEscuelaId(Id);
            model.NombreEscuela = ViewBag.NombreEscuela;
            List<BasicaDTO> objPtactica = ParametrosLogica.ConsultarPracticasMusicales();
            ViewBag.listPractica = new SelectList(objPtactica, "value", "text");
            //modelPadre.practica = modelPracticas;
            return View(modelPadre);
        }

        [HttpPost]
        public ActionResult Formacion(int Id, FormacionModelNuevo model)
        {
            string Mensaje = "";
            var modelPadre = new FormacionPadre();
            modelPadre.basico = model;
            if (ModelState.IsValid)
            {
                ViewBag.NombreEscuela = model.NombreEscuela;


                if (String.IsNullOrEmpty(Mensaje))
                {
                    GrabarFormacionNuevo(model, Id);

                    // BasicaDTO nombres = ZonaGeograficasLogica.ObtenerNombres(model.MunicipioSelector);
                    BasicaDTO nombres = new BasicaDTO();
                    string mensaje = "La escuela de música con el Id: " + Id.ToString() + ". Nombre: " + model.NombreEscuela;
                    if (nombres != null)
                    {
                        mensaje += ". Departamento: " + nombres.value + "  Municipio: " + nombres.text;
                    }
                    mensaje += ".  Ha sido actualizada en la sección de formación por el usuario.  " + NombreCompletoUsuario;
                    mensajeCorreo(mensaje, model.NombreEscuela);
                    EscuelasLogica.ActualizarFechaModificacion(Convert.ToDecimal(Id));

                    return RedirectToAction("Infraestructura", "EscuelasMusica", new { Id = Id });
                }

            }

            model.EscuelaId = Id;
            modelPadre.EscuelaId = Id;

            if (string.IsNullOrEmpty(Mensaje))
                Success(string.Format("<b>{0}</b> Se actualizo con éxito", model.NombreEscuela), true);
            else
                Warning(string.Format(Mensaje), true);
            return View("Formacion", modelPadre);
        }

        public ActionResult Produccion(int Id)
        {
            if (String.IsNullOrEmpty(UsuaroId))
                return RedirectToAction("Login", "Cuenta");

            var model = new ProduccionModel();
            bool existe = false;

            existe = ProduccionLogica.ValidarProduccion(Convert.ToDecimal(Id));

            model = TranslatorEscuelas.CargarProduccion(Id);
            model.EscuelaId = Id;

            ViewBag.NombreEscuela = EscuelasLogica.ObtenerNombreEscuela(Id) + " - " + ZonaGeograficasLogica.ObtenerNombresPorEscuelaId(Id);
            model.NombreEscuela = ViewBag.NombreEscuela;

            return View(model);
        }

        [HttpPost]
        public ActionResult Produccion(int Id, ProduccionModel model)
        {
            string Mensaje = "";

            if (ModelState.IsValid)
            {
                ViewBag.NombreEscuela = model.NombreEscuela + " - " + ZonaGeograficasLogica.ObtenerNombresPorEscuelaId(Id);

                GrabarProduccion(model, Id);


                // BasicaDTO nombres = ZonaGeograficasLogica.ObtenerNombres(model.MunicipioSelector);
                BasicaDTO nombres = new BasicaDTO();
                string mensaje = "La escuela de música con el Id: " + Id.ToString() + ". Nombre: " + model.NombreEscuela;
                if (nombres != null)
                {
                    mensaje += ". Departamento: " + nombres.value + "  Municipio: " + nombres.text;
                }
                mensaje += ".  Ha sido actualizada en la sección de producción por el usuario.  " + NombreCompletoUsuario;
                mensajeCorreo(mensaje, model.NombreEscuela);
                EscuelasLogica.ActualizarFechaModificacion(Convert.ToDecimal(Id));


            }

            model.EscuelaId = Id;


            if (string.IsNullOrEmpty(Mensaje))
                Success(string.Format("<b>{0}</b> Se actualizo con éxito", model.NombreEscuela), true);
            else
                Warning(string.Format(Mensaje), true);
            return View("Produccion", model);
        }
        public ActionResult Organizacion(int Id)
        {
            if (String.IsNullOrEmpty(UsuaroId))
                return RedirectToAction("Login", "Cuenta");

            var model = new Institucionalidad();
            var practicaMusicalSeleccionada = new List<PracticaMusicales>();
            bool existe = false;

            existe = InstitucionalidadLogica.ValidarInstitucionalidad(Convert.ToDecimal(Id));

            if (!existe)
            {
                model.ActividadMusical = 1;
                model.CreadaLegalmente = 1;
                model.ApoyoAdministrativo = 1;
                model.DependeInstitucion = 1;
                model.FormacionMusical = 1;

            }
            else
                model = TranslatorEscuelas.CargarInstitucionalidad(Id);

            // formación por parte del PNMC
            List<PracticaMusicales> practicaMusical = ConsultarPracticasFormacionDocentes();
            model.PracticaMusicalPNMCData = practicaMusical;
            model.PracticaMusicalPNMCSeleccionada = ConsultarPracticaMusicalPNMCSeleccionada(Convert.ToDecimal(Id));
            model.EscuelaId = Id;

            ViewBag.NombreEscuela = EscuelasLogica.ObtenerNombreEscuela(Id) + " - " + ZonaGeograficasLogica.ObtenerNombresPorEscuelaId(Id);
            model.NombreEscuela = ViewBag.NombreEscuela;
            cargarParametrosOrganizacion(model.Regimen);
            return View(model);
        }

        [HttpPost]
        public ActionResult Organizacion(int Id, Institucionalidad model)
        {
            string Mensaje = "";

            if (ModelState.IsValid)
            {
                ViewBag.NombreEscuela = model.NombreEscuela + " - " + ZonaGeograficasLogica.ObtenerNombresPorEscuelaId(Id);


                bool validacionDocumento = false;
                bool validarEntidad = false;

                if (model.CreadaLegalmente == 1)
                {
                    if (model.DocumentoCreacion == null)
                    {
                        if (model.DocumentoId > 0)
                            validacionDocumento = false;
                        else
                            validacionDocumento = true;
                    }
                    else
                    {

                        if (string.IsNullOrEmpty(model.NumeroDocumentoCreacion))
                            validacionDocumento = true;

                        if (string.IsNullOrEmpty(model.FechaDocumentoCreacion))
                            validacionDocumento = true;

                        if (string.IsNullOrEmpty(model.TipoDocumentoCreacion))
                            validacionDocumento = true;
                    }

                }
                if (validacionDocumento)
                {
                    Mensaje = "Si la escuela fue creada legalmente debe diligenciar obligatoriamente los siguientes campos:  Número documento de creación, Fecha documento, Tipo documento creación y el archivo en pdf";

                }
                else
                {
                    if (model.DependeInstitucion == 1)
                    {
                        if (String.IsNullOrEmpty(model.NombreEntidad))
                            validarEntidad = true;
                        else
                        {

                            if (String.IsNullOrEmpty(model.NivelEntidad) || (model.NivelEntidad == "Seleccione un valor"))
                                validarEntidad = true;
                        }
                    }

                    if (validarEntidad)
                    {
                        Mensaje = "El nombre y nivel de la entidad es obligatorio, cuando la pregunta ¿Depende de alguna entidad? es afirmativo, por favor revisar";
                    }
                    else
                    {
                        //Validaciones docentes
                        if (String.IsNullOrEmpty(model.Voluntarios) && String.IsNullOrEmpty(model.ContratoLaboral) && String.IsNullOrEmpty(model.ContratoHonorario)
                            && String.IsNullOrEmpty(model.OrdenPrestacionServicios))
                        {
                            Mensaje = "Al menos un campo de cantidad de docentes según tipo de vinculación es obligatorio";
                        }
                        else
                        {
                            if (String.IsNullOrEmpty(model.Primaria) && String.IsNullOrEmpty(model.Tecnico) && String.IsNullOrEmpty(model.PregradoMusica)
                                              && String.IsNullOrEmpty(model.PostGrado) && String.IsNullOrEmpty(model.Secundaria) && String.IsNullOrEmpty(model.UniversitariaSinTitulo) && String.IsNullOrEmpty(model.PregradoOtrasAreas))
                            {
                                Mensaje = "Al menos un campo de cantidad de docentes de acuerdo a su nivel educativo es obligatorio";
                            }
                            else
                            {
                                int intVoluntarios = 0;
                                int intContratoLaboral = 0;
                                int intContratoHonorario = 0;
                                int intOrdenPrestacionServicios = 0;
                                int intTotaldocentes = 0;

                                int intPrimaria = 0;
                                int intTecnico = 0;
                                int intPregradoMusica = 0;
                                int intOPostGrado = 0;
                                int intSecundaria = 0;
                                int intUniversitariaSinTitulo = 0;
                                int intPregradoOtrasAreas = 0;
                                int intTotalNivelEducativo = 0;

                                if (!String.IsNullOrEmpty(model.Primaria))
                                    intPrimaria = Convert.ToInt32(model.Primaria);

                                if (!String.IsNullOrEmpty(model.Tecnico))
                                    intTecnico = Convert.ToInt32(model.Tecnico);

                                if (!String.IsNullOrEmpty(model.PregradoMusica))
                                    intPregradoMusica = Convert.ToInt32(model.PregradoMusica);

                                if (!String.IsNullOrEmpty(model.PostGrado))
                                    intOPostGrado = Convert.ToInt32(model.PostGrado);

                                if (!String.IsNullOrEmpty(model.Secundaria))
                                    intSecundaria = Convert.ToInt32(model.Secundaria);

                                if (!String.IsNullOrEmpty(model.UniversitariaSinTitulo))
                                    intUniversitariaSinTitulo = Convert.ToInt32(model.UniversitariaSinTitulo);

                                if (!String.IsNullOrEmpty(model.PregradoOtrasAreas))
                                    intPregradoOtrasAreas = Convert.ToInt32(model.PregradoOtrasAreas);

                                intTotalNivelEducativo = intPregradoOtrasAreas + intUniversitariaSinTitulo + intSecundaria + intOPostGrado + intPregradoMusica + intTecnico + intPrimaria;

                                if (!String.IsNullOrEmpty(model.Voluntarios))
                                    intVoluntarios = Convert.ToInt32(model.Voluntarios);

                                if (!String.IsNullOrEmpty(model.ContratoLaboral))
                                    intContratoLaboral = Convert.ToInt32(model.ContratoLaboral);

                                if (!String.IsNullOrEmpty(model.OrdenPrestacionServicios))
                                    intOrdenPrestacionServicios = Convert.ToInt32(model.OrdenPrestacionServicios);

                                if (!String.IsNullOrEmpty(model.ContratoHonorario))
                                    intContratoHonorario = Convert.ToInt32(model.ContratoHonorario);

                                intTotaldocentes = intVoluntarios + intContratoLaboral + intOrdenPrestacionServicios + intContratoHonorario;
                                if (intTotaldocentes != intTotalNivelEducativo)
                                {
                                    Mensaje = "la sumatoria total de docentes por tipo vinculación y la sumatoria total de docentes por nivel educativo debe ser igual, por favor revisar";
                                }
                            }
                        }
                    }
                }

                if (String.IsNullOrEmpty(Mensaje))
                {
                    bool EsCargadodocumento = GrabarInstitucionalidad(model, Id, validacionDocumento);

                    if (EsCargadodocumento)
                        model = TranslatorEscuelas.CargarInstitucionalidad(Id);



                    // BasicaDTO nombres = ZonaGeograficasLogica.ObtenerNombres(model.MunicipioSelector);
                    BasicaDTO nombres = new BasicaDTO();
                    string mensaje = "La escuela de música con el Id: " + Id.ToString() + ". Nombre: " + model.NombreEscuela;
                    if (nombres != null)
                    {
                        mensaje += ". Departamento: " + nombres.value + "  Municipio: " + nombres.text;
                    }
                    mensaje += ".  Ha sido actualizada en la sección de organización por el usuario.  " + NombreCompletoUsuario;
                    mensajeCorreo(mensaje, model.NombreEscuela);
                    EscuelasLogica.ActualizarFechaModificacion(Convert.ToDecimal(Id));

                    return RedirectToAction("Formacion", "EscuelasMusica", new { Id = Id });
                }
            }


            // CargarParametros datos básicos
            cargarParametrosOrganizacion(model.Regimen);
            // formación por parte del PNMC
            List<PracticaMusicales> practicaMusical = ConsultarPracticasFormacionDocentes();
            model.PracticaMusicalPNMCData = practicaMusical;
            model.PracticaMusicalPNMCSeleccionada = ConsultarPracticaMusicalPNMCSeleccionada(Convert.ToDecimal(Id));

            if (string.IsNullOrEmpty(Mensaje))
                Success(string.Format("<b>{0}</b> Se actualizo con éxito", model.NombreEscuela), true);
            else
                Warning(string.Format(Mensaje), true);
            return View("Organizacion", model);
        }
        public ActionResult EditarNuevo(int Id, int wizard = 0)
        {
            if (String.IsNullOrEmpty(UsuaroId))
                return RedirectToAction("Login", "Cuenta");

            var modelnuevo = new EscuelasNuevo();
            var model = new Escuelas();
            var modelRedes = new RedesSocialesModel();
            bool EsAdmin = false;
            bool EsCoordinador = false;
            modelnuevo.EscuelaId = Id;
            //Carga los datos básicos
            model = CargarDatosBasicos(Id);
            decimal UsuarioSipaId = UsuarioLogica.ObtenerUsuarioSipaId(Usuario);
            //Redirecciona si no es propietario del registro

            EsAdmin = UsuarioLogica.UsuarioEsAdmin(Convert.ToInt32(UsuaroId), Comunes.ConstantesRecursosBD.CODIGO_ADMIN);

            if (EsAdmin)
            {
                return RedirectToAction("CambiarEstado", "EscuelasMusica", new { Id = Id, wizard = wizard });
            }
            else
            {
                EsCoordinador = UsuarioLogica.UsuarioEsCoordinadorAsesor(Convert.ToInt32(UsuaroId), Comunes.ConstantesRecursosBD.CODIGO_COORDINADOR, Comunes.ConstantesRecursosBD.CODIGO_ASESOR);
                if (EsCoordinador)
                {
                    return RedirectToAction("CambiarEstado", "EscuelasMusica", new { Id = Id, wizard = wizard });
                }
                else
                {
                    if (model.UsuarioId != UsuarioSipaId)
                    {

                        return RedirectToAction("Ficha", "EscuelasMusica", new { Id = Id });
                    }

                }

            }
            if (CronogramaNeg.ValidaCronogramaXEscuelaId(Id))
            {
                return RedirectToAction("Consulta", "EscuelasMusica");
            }

            model.NombreEstado = BasicaLogica.ObtenerNombreEstado(Convert.ToInt32(model.EstadoId));
            if (model.imagen != null)
            {
                string imageBase64Data = Convert.ToBase64String(model.imagen);
                string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                TempData["imagen"] = imageDataURL;
                ViewBag.ImageData = imageDataURL;
            }
            else
            {
                ///TODO.  Dejar como constante "~/assets/images/users/user2.jpg";
                TempData["imagen"] = "~/img/defaultUser.jpg";
                ViewBag.ImageData = "~/img/defaultUser.jpg";
            }

            ViewBag.NombreEscuela = model.NombreEscuela + " - " + ZonaGeograficasLogica.ObtenerNombresPorEscuelaId(Id);
            cargarParametrosNuevo(model.DepartamentoSelector);
            modelRedes = TranslatorEscuelas.CargarDatosRedes(Id);
            modelnuevo.Escuelas = model;
            var EscuelaDocumentos = new EscuelaDocumentoModels();
            EscuelaDocumentos.EscuelaId = Id;
            modelnuevo.Documentos = EscuelaDocumentos;
            modelnuevo.RedesSociales = modelRedes;

            return View(modelnuevo);
        }
        [HttpPost]
        public ActionResult EditarNuevo(HttpPostedFileBase imagenPerfil, int Id, Escuelas model, RedesSocialesModel RedesData, string Guardar, string Redes)
        {
            string imageDataURL = "";
            string Mensaje = "";
            var modelnuevo = new EscuelasNuevo();

            if (ModelState.IsValid)
            {
                ViewBag.NombreEscuela = model.NombreEscuela;


                decimal UsuarioSipaId = UsuarioLogica.ObtenerUsuarioSipaId(Usuario);

                byte[] fileData = null;
                if (imagenPerfil != null && imagenPerfil.ContentLength > 0)
                {

                    using (var binaryReader = new BinaryReader(imagenPerfil.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(imagenPerfil.ContentLength);
                    }
                    EscuelasLogica.ActualizarImagen(Convert.ToDecimal(Id), fileData, Convert.ToInt32(UsuaroId), NombreCompletoUsuario, Request.UserHostAddress);

                    string imageBase64Data = Convert.ToBase64String(fileData);
                    imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                    TempData["imagen"] = imageDataURL;
                    ViewBag.ImageData = imageDataURL;

                }
                else
                {

                    if (model.imagen != null)
                    {
                        string imageBase64Data = Convert.ToBase64String(model.imagen);
                        imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                        TempData["imagen"] = imageDataURL;
                    }
                    else
                    {
                        if (TempData["imagen"] != null)
                            imageDataURL = (string)TempData["imagen"];
                        else
                            imageDataURL = "~/img/defaultUser.jpg";
                    }

                    TempData["imagen"] = imageDataURL;
                    ViewBag.ImageData = imageDataURL;

                }
                if (Guardar == "Siguiente")
                {


                    EscuelasLogica.ActualizarEScuelaGeo(Convert.ToDecimal(Id),
                                                    model.NombreEscuela,
                                                    String.Empty,
                                                    model.SitioWeb,
                                                    model.Nit,
                                                    Convert.ToInt32(model.AnoValue),
                                                    model.NombreContacto,
                                                    model.Cargo,
                                                    model.Resena,
                                                    model.Telefono,
                                                    model.CorreoElectronico,
                                                   UsuarioSipaId,
                                                    model.MunicipioSelector,
                                                    model.Area,
                                                    model.Direccion,
                                                    model.TelefonoEscuela,
                                                    model.Fax,
                                                    model.CorreoElectronicoEscuela,
                                                    fileData,
                                                    model.Naturaleza,
                                                    model.TipoEscuelas.ToString(),
                                                    model.Latitud,
                                                    model.Longitud,
                                                    3,
                                                    model.OperacionEscuela,
                                                    Convert.ToInt32(UsuaroId),
                                                   NombreCompletoUsuario,
                                                    Request.UserHostAddress);

                    BasicaDTO nombres = ZonaGeograficasLogica.ObtenerNombres(model.MunicipioSelector);

                    string mensaje = "La escuela de música con el Id: " + Id.ToString() + ". Nombre: " + model.NombreEscuela;
                    if (nombres != null)
                    {
                        mensaje += ". Departamento: " + nombres.value + "  Municipio: " + nombres.text;
                    }
                    mensaje += ".  Ha sido actualizada por el usuario.  " + NombreCompletoUsuario;
                    mensajeCorreo(mensaje, model.NombreEscuela);


                    EscuelasLogica.ActualizarFechaModificacion(Convert.ToDecimal(Id));
                    model.FechaActualizacion = DateTime.Now;

                    // envio de mensaje por correo electronico

                    bool validacionEmail = NotificacionCorreo.IsValidEmail(model.CorreoElectronico);
                    if (validacionEmail)
                        NotificacionCorreo.MensajeNotificaionPorEstado(model.CorreoElectronico, model.NombreEscuela,
                                                                        3,
                                                                        "Escuelas",
                                                                       Convert.ToInt32(model.EscuelaId),
                                                                        Convert.ToInt32(UsuaroId),
                                                                        NombreCompletoUsuario,
                                                                        model.Motivo);

                    // ACTUALIZAR ESTADO A 'E' (activo/publicado)
                    EscuelasLogica.ActualizarEscuelaEstado(
                        Id,
                        model.EstadoId,
                        Convert.ToInt32(UsuaroId),
                        NombreCompletoUsuario,
                        Request.UserHostAddress
                    );


                    return RedirectToAction("Beneficiarios", "EscuelasMusica", new { Id = Id });
                }
                else if (Redes == "Guardar")
                {
                    GrabarRedes(RedesData, Id);
                }

            }

            // CargarParametros datos básicos
            CargarParametrosPostNuevo(model.DepartamentoSelector);
            modelnuevo.Escuelas = model;
            modelnuevo.EscuelaId = Id;
            modelnuevo.RedesSociales = RedesData;
            var EscuelaDocumentos = new EscuelaDocumentoModels();

            EscuelaDocumentos.EscuelaId = Id;
            modelnuevo.Documentos = EscuelaDocumentos;
            if (string.IsNullOrEmpty(Mensaje))
                Success(string.Format("<b>{0}</b> Se actualizo con éxito", model.NombreEscuela), true);
            else
                Warning(string.Format(Mensaje), true);
            if (model == null)
                model = new Escuelas();

            modelnuevo.Escuelas = model;
            return View("EditarNuevo", modelnuevo);
        }




        private void mensajeCorreo(string mensaje, string nombreescuela, bool validate = false)
        {
            string asunto = "";
            if (validate)
                asunto = "Creación de la escuela de música " + nombreescuela;
            else asunto = "Actualización de la escuela de música " + nombreescuela;
            string nombre = "Administrador";
            EnvioCorreo.EnviarCorreoEscuelas(mensaje, asunto, nombre);
        }


        [Route("EscuelasMusica/{id? : int}")]
        //[Authorize]
        public ActionResult Exportar(int Id)
        {
            decimal escuelaId = Id;
            string strNombre = "";

            byte[] bytes = Helpers.GenerarArchivo.ObtenerFichaCompleta(escuelaId, out strNombre);
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

        [Route("EscuelasMusica/{id? : int}")]
        //[Authorize]
        public ActionResult Eliminar(int Id)
        {
            decimal escuelaId = Id;

            EscuelasLogica.EliminarEscuelas(escuelaId, Convert.ToInt32(UsuaroId), NombreCompletoUsuario, Request.UserHostAddress);

            return RedirectToAction("Consulta");


        }

        public ActionResult ConsultarMunicipios()
        {


            return View();
        }
        // [Authorize]
        public ActionResult Consulta(string Busqueda)
        {
            var model = new ConsultaModel();
            model.TipoRegistro = 1;


            return View(model);
        }

        public ActionResult Solicitudes()
        {
            var model = new ConsultaModel();
            model.TipoRegistro = 1;

            return View(model);
        }
        //[Authorize]
        public ActionResult Escuelas()
        {
            var model = new Escuelas();

            CargarEscuelas();
            List<BasicaDTO> objMunicipios = new List<BasicaDTO>();
            ViewBag.municipios = new SelectList(objMunicipios, "value", "text");
            return View(model);
        }

        private void CargarEscuelas()
        {
            ViewBag.departamentos = new SelectList(ZonaGeograficasLogica.ConsultarDepartamentos(), "value", "text");
            ViewBag.Anos = new SelectList(BasicaLogica.ConsultarListadoAnos(), "value", "text");
            List<BasicaDTO> ObjNaturaleza = BasicaLogica.ConsultarNaturaleza();
            ViewBag.listNaturaleza = new SelectList(ObjNaturaleza, "value", "text");
            List<BasicaDTO> objTipoEscuela = ParametrosLogica.ConsultarTipoEscuelasMusica();
            ViewBag.listTipoEscuelasMusica = new SelectList(objTipoEscuela, "value", "text");
        }

        [HttpPost]
        //[Authorize]
        public ActionResult Escuelas(HttpPostedFileBase imagenPerfil, string guardar, Escuelas datos)
        {


            List<BasicaDTO> objMunicipios = new List<BasicaDTO>();

            if (ModelState.IsValid)
            {
                byte[] fileData = null;

                if (datos.MunicipioSelector == "Seleccione un valor")
                {
                    CargarEscuelas();

                    ViewBag.municipios = new SelectList(objMunicipios, "value", "text");
                    if (!String.IsNullOrEmpty(datos.DepartamentoSelector))
                        objMunicipios = ZonaGeograficasLogica.ConsultarMunicipios(datos.DepartamentoSelector);

                    ViewBag.municipios = new SelectList(objMunicipios, "value", "text");
                    Warning(string.Format("<b></b> Es obligatorio seleccionar un municipio "), true);
                    return View("Escuelas", datos);
                }
                if (imagenPerfil != null && imagenPerfil.ContentLength > 0)
                {

                    using (var binaryReader = new BinaryReader(imagenPerfil.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(imagenPerfil.ContentLength);
                    }
                    //EscuelasLogica.ActualizarImagen(EscuelaId, fileData, usuario.Id, usuario.PrimerNombre + " " + usuario.PrimerApellido, Request.UserHostAddress);
                }


                decimal UsuarioSipaId = UsuarioLogica.ObtenerUsuarioSipaId(Usuario);
                var EscuelaId = EscuelasLogica.CrearEscuela(datos.NombreEscuela,
                                                              datos.Nit,
                                                              Convert.ToInt32(datos.AnoValue),
                                                              datos.NombreContacto,
                                                              datos.Cargo,
                                                              datos.Resena,
                                                              datos.Telefono,
                                                              datos.CorreoElectronico,
                                                              UsuarioSipaId,
                                                              datos.MunicipioSelector,
                                                              datos.Area,
                                                              datos.Direccion,
                                                              datos.TelefonoEscuela,
                                                              datos.Fax,
                                                              datos.CorreoElectronicoEscuela,
                                                              datos.SitioWeb,
                                                              datos.Naturaleza,
                                                              datos.TipoEscuelas,
                                                              fileData,
                                                              datos.Latitud,
                                                              datos.Longitud,
                                                             Convert.ToInt32(UsuaroId),
                                                              NombreCompletoUsuario,
                                                              Request.UserHostAddress);



                //Enviar notificación de correo electrónico

                BasicaDTO nombres = ZonaGeograficasLogica.ObtenerNombres(datos.MunicipioSelector);

                string mensaje = "La escuela de música con el Id: " + datos.EscuelaId.ToString() + ". Nombre: " + datos.NombreEscuela;
                if (nombres != null)
                {
                    mensaje += ". Departamento: " + nombres.value + "  Municipio: " + nombres.text;
                }
                mensaje += ".  Ha sido creada por el usuario.  " + NombreCompletoUsuario;
                mensajeCorreo(mensaje, datos.NombreEscuela, true);

                // envio de mensaje por correo electronico

                bool validacionEmail = NotificacionCorreo.IsValidEmail(datos.CorreoElectronico);
                if (validacionEmail)
                    NotificacionCorreo.MensajeNotificaionPorEstado(datos.CorreoElectronico,
                                                                          datos.NombreEscuela,
                                                                          1,
                                                                          "Escuelas",
                                                                          Convert.ToInt32(EscuelaId),
                                                                          Convert.ToInt32(UsuaroId),
                                                                          NombreCompletoUsuario,
                                                                          "");

                return RedirectToAction("EditarNuevo", "EscuelasMusica", new { Id = EscuelaId, wizard = 1 });
            }

            CargarEscuelas();
            ViewBag.municipios = new SelectList(objMunicipios, "value", "text");
            if (!String.IsNullOrEmpty(datos.DepartamentoSelector))
                objMunicipios = ZonaGeograficasLogica.ConsultarMunicipios(datos.DepartamentoSelector);

            ViewBag.municipios = new SelectList(objMunicipios, "value", "text");
            return View("Escuelas", datos);
        }


        //  [Authorize]
        public ActionResult Categoria(int Id)
        {

            var model = new List<CategorizacionResumenDTO>();
            var modelEncabezado = new CategoriaEncabezadoDTO();
            decimal suma = 0;
            model = CategorizacionLogica.ConsultarCategorizacionPorEscuela(Convert.ToDecimal(Id), out suma);
            modelEncabezado = CategorizacionLogica.ConsultarNombreEscuela(Convert.ToDecimal(Id));
            ViewBag.Suma = suma;
            if (modelEncabezado != null)
            {
                ViewBag.Factor = modelEncabezado.Categoria;
                ViewBag.Nombre = modelEncabezado.Nombre;
                ViewBag.Estilo = "widget-sucess";

            }

            return View(model);
        }


        #region MetodosPrivados
        private List<PracticaMusicales> ConsultarPracticaMusical()
        {
            List<PracticaMusicales> objPractica = new List<PracticaMusicales>();
            var BasicaPractica = ParametrosLogica.ConsultarPracticasMusicales();
            foreach (var item in BasicaPractica)
            {
                PracticaMusicales objParametro = new PracticaMusicales();
                objParametro.Id = item.value;
                objParametro.Nombre = item.text;
                objPractica.Add(objParametro);
            }

            return objPractica;
        }

        private List<PracticaMusicales> ConsultarPracticasFormacionDocentes()
        {
            List<PracticaMusicales> objPractica = new List<PracticaMusicales>();
            var BasicaPractica = ParametrosLogica.ConsultarPracticasFormacionDocentes();
            foreach (var item in BasicaPractica)
            {
                PracticaMusicales objParametro = new PracticaMusicales();
                objParametro.Id = item.value;
                objParametro.Nombre = item.text;
                objPractica.Add(objParametro);
            }

            return objPractica;
        }

        private List<PracticaMusicales> ConsultarPracticaMusicalSeleccionada(decimal EntId)
        {
            List<PracticaMusicales> objPractica = new List<PracticaMusicales>();
            var BasicaPractica = ParametrosLogica.ConsultarPracticaMusicalSeleccionada(EntId);
            foreach (var item in BasicaPractica)
            {
                PracticaMusicales objParametro = new PracticaMusicales();
                objParametro.Id = item.value;
                objParametro.Nombre = item.text;
                objPractica.Add(objParametro);
            }

            return objPractica;
        }

        private List<PracticaMusicales> ConsultarPracticaMusicalPNMCSeleccionada(decimal EntId)
        {
            List<PracticaMusicales> objPractica = new List<PracticaMusicales>();
            var BasicaPractica = ParametrosLogica.ConsultarPracticasMusicalesPNMC(EntId);
            foreach (var item in BasicaPractica)
            {
                PracticaMusicales objParametro = new PracticaMusicales();
                objParametro.Id = item.value;
                objParametro.Nombre = item.text;
                objPractica.Add(objParametro);
            }

            return objPractica;
        }

        private Escuelas CargarDatosBasicos(decimal EscuelaId)
        {
            Escuelas model = new Escuelas();
            EscuelaDTO datos = EscuelasLogica.ConsultarDatosBasicosPorId(EscuelaId);

            if (datos != null)
            {
                if ((datos.ENT_ANO_CONSTITUCION != null))
                    model.AnoValue = datos.ENT_ANO_CONSTITUCION.ToString();

                if (!String.IsNullOrEmpty(datos.ENT_CARGO_CONTACTO))
                    model.Cargo = datos.ENT_CARGO_CONTACTO.Trim();

                if (!String.IsNullOrEmpty(datos.ENT_CONTACTO_CORREO))
                    model.CorreoElectronico = datos.ENT_CONTACTO_CORREO.Trim();

                if (!String.IsNullOrEmpty(datos.ENT_CORREO_ELECTRONICO_ENTIDAD))
                    model.CorreoElectronicoEscuela = datos.ENT_CORREO_ELECTRONICO_ENTIDAD.Trim();

                if (!String.IsNullOrEmpty(datos.ZON_PADRE_ID))
                    model.DepartamentoSelector = datos.ZON_PADRE_ID;


                if (!String.IsNullOrEmpty(datos.ENT_DIRECCION))
                    model.Direccion = datos.ENT_DIRECCION;

                if (!String.IsNullOrEmpty(datos.ENT_ESTADO))
                {
                    if (datos.ENT_ESTADO == "N")
                        model.Estado = 2;
                    else if (datos.ENT_ESTADO == "E")
                        model.Estado = 1;
                    else if (datos.ENT_ESTADO == "P")
                        model.Estado = 1;

                }

                model.EstadoId = datos.EstadoId;
                model.EstadoOldId = datos.EstadoId;
                model.OperacionEscuela = datos.OperatividadEscuela;
                if (datos.ENT_FECHA_ACTUALIZACION != null)
                    model.FechaActualizacion = (DateTime)datos.ENT_FECHA_ACTUALIZACION;

                model.EscuelaId = datos.ENT_ID ?? 0;
                if (!String.IsNullOrEmpty(datos.ENT_FAX))
                    model.Fax = datos.ENT_FAX.Trim();

                if (!String.IsNullOrEmpty(datos.Naturaleza))
                    model.Naturaleza = datos.Naturaleza;

                if (!String.IsNullOrEmpty(datos.TipoEscuela))
                    model.TipoEscuelas = datos.TipoEscuela;

                if (!String.IsNullOrEmpty(datos.ZON_ID))
                    model.MunicipioSelector = datos.ZON_ID;

                if (!String.IsNullOrEmpty(datos.ENT_NIT))
                    model.Nit = datos.ENT_NIT;

                if (!String.IsNullOrEmpty(datos.ENT_NOMBRE_CONTACTO))
                    model.NombreContacto = datos.ENT_NOMBRE_CONTACTO.Trim();

                if (!String.IsNullOrEmpty(datos.ENT_NOMBRE))
                    model.NombreEscuela = datos.ENT_NOMBRE.Trim();

                if (!String.IsNullOrEmpty(datos.ENT_RESENA))
                    model.Resena = datos.ENT_RESENA.Trim();

                if (!String.IsNullOrEmpty(datos.ENT_PAGINA_WEB))
                    model.SitioWeb = datos.ENT_PAGINA_WEB.Trim();


                if (!String.IsNullOrEmpty(datos.ENT_TELEFONOS))
                    model.Telefono = datos.ENT_TELEFONOS.Trim();

                if (!String.IsNullOrEmpty(datos.Latitud))
                    model.Latitud = datos.Latitud.Trim();

                if (!String.IsNullOrEmpty(datos.Longitud))
                    model.Longitud = datos.Longitud.Trim();


                if (!String.IsNullOrEmpty(datos.ENT_TELEFONO))
                    model.TelefonoEscuela = datos.ENT_TELEFONO.Trim();

                if (!String.IsNullOrEmpty(datos.ZON_NOMBRE))
                {
                    model.Municipio = datos.ZON_NOMBRE.Trim();
                    if (!String.IsNullOrEmpty(datos.ZON_NOMBRE_PADRE))
                        model.Departamento = datos.ZON_NOMBRE_PADRE.Trim();
                    model.ZonaGeografica = model.Municipio + ", " + model.Departamento;
                }

                model.UsuarioId = datos.USU_ID;

                model.imagen = datos.Imagen;


            }
            model.Area = EscuelasLogica.ConsultarAreaPorId(EscuelaId);

            return model;
        }

        private List<EscuelaConsultaModel> ConsultarEscuelas()
        {
            var model = new List<EscuelaConsultaModel>();
            var result = new List<EscuelaNuevoDatosDTO>();
            result = EscuelasLogica.ConsultarEscuelasTodos();

            foreach (var item in result)
            {
                var datos = new EscuelaConsultaModel();

                datos.Estado = item.Estado;
                datos.Departamento = item.Departamento;
                datos.EscuelaId = item.ENT_ID;
                datos.FechaActualizacion = item.ENT_FECHA_ACTUALIZACION.ToString("dd/MM/yyyy");
                datos.FechaCreacion = item.ENT_FECHA_DILIGENCIAMIENTO.ToString("dd/MM/yyyy");
                datos.Municipio = item.Municipio;
                datos.NombreEscuela = item.ENT_NOMBRE;
                datos.Naturaleza = item.Naturaleza;
                datos.Tipo = item.Tipo;
                model.Add(datos);
            }



            return model;
        }



        private List<EscuelaConsultaModel> ConsultarEscuelasPorMunicipio(int UsuarioId)
        {
            var model = new List<EscuelaConsultaModel>();
            var result = new List<EscuelaNuevoDatosDTO>();
            result = EscuelasLogica.ConsultarEscuelasPorMunicipio(UsuarioId);

            foreach (var item in result)
            {
                var datos = new EscuelaConsultaModel();

                datos.Estado = item.Estado;
                datos.Departamento = item.Departamento;
                datos.EscuelaId = item.ENT_ID;
                datos.FechaActualizacion = item.ENT_FECHA_ACTUALIZACION.ToString("dd/MM/yyyy");
                datos.FechaCreacion = item.ENT_FECHA_DILIGENCIAMIENTO.ToString("dd/MM/yyyy");
                datos.Municipio = item.Municipio;
                datos.NombreEscuela = item.ENT_NOMBRE;
                datos.Naturaleza = item.Naturaleza;
                datos.Tipo = item.Tipo;
                model.Add(datos);
            }



            return model;
        }
        private string GetYouTubeID(string youTubeUrl)
        {
            //Setup the RegEx Match and give it 
            Match regexMatch = Regex.Match(youTubeUrl, "^[^v]+v=(.{11}).*",
                               RegexOptions.IgnoreCase);
            if (regexMatch.Success)
            {
                return regexMatch.Groups[1].Value +
                       "&hl=en&fs=1";
            }
            return youTubeUrl;
        }

        private void GrabarRedes(RedesSocialesModel datos, int Id)
        {
            try
            {
                RedesLogica.AgregarRedes(Id, datos.Facebook, datos.Twitter, datos.CanalYoutube, datos.VideoId, datos.GaleriaId, datos.GaleriaFlicker,
                    datos.DescripcionFlicker);

            }
            catch (Exception ex)
            { throw ex; }
        }

        private async void GrabarEscuelas(Escuelas datos, int Id, byte[] fileData)
        {

            string Latitud = "";
            string Longitud = "";
            try
            {
                Latitud = datos.Latitud;
                Longitud = datos.Longitud;

                if (string.IsNullOrEmpty(datos.Latitud))
                {
                    var coordenadas = new CoordenadasDTO();
                    ResultadoWebServices obj = new ResultadoWebServices();
                    string token = System.Configuration.ConfigurationManager.AppSettings["TokenServinformacion"];
                    string url = System.Configuration.ConfigurationManager.AppSettings["UrlServinformacion"];
                    coordenadas = await obj.ObtenerCoordenadas(datos.Direccion, datos.MunicipioSelector, token, url);

                    Latitud = coordenadas.Latitud;
                    Longitud = coordenadas.Longitud;
                }

                decimal UsuarioSipaId = UsuarioLogica.ObtenerUsuarioSipaId(Usuario);
                EscuelasLogica.ActualizarEScuelaGeo(Convert.ToDecimal(Id),
                                                    datos.NombreEscuela,
                                                    String.Empty,
                                                    datos.SitioWeb,
                                                    datos.Nit,
                                                    Convert.ToInt32(datos.AnoValue),
                                                    datos.NombreContacto,
                                                    datos.Cargo,
                                                    datos.Resena,
                                                    datos.Telefono,
                                                    datos.CorreoElectronico,
                                                    UsuarioSipaId,
                                                    datos.MunicipioSelector,
                                                    datos.Area,
                                                    datos.Direccion,
                                                    datos.TelefonoEscuela,
                                                    datos.Fax,
                                                    datos.CorreoElectronicoEscuela,
                                                    fileData,
                                                    datos.Naturaleza,
                                                    datos.TipoEscuelas.ToString(),
                                                    Latitud,
                                                    Longitud,
                                                    1,
                                                   datos.OperacionEscuela,
                                                     Convert.ToInt32(UsuaroId),
                                                    NombreCompletoUsuario,
                                                    Request.UserHostAddress);

            }
            catch (Exception ex)
            { throw ex; }
        }

        private bool GrabarInstitucionalidad(Institucionalidad datos, int Id, bool ValidateDocumentoCreacion = false)
        {

            bool validateDocumento = false;
            int DocumentoId = 0;
            int UsuarioId = Convert.ToInt32(UsuaroId);
            List<string> practicamusicalPNMCselecionadas = new List<string>();
            try
            {
                if (string.IsNullOrEmpty(datos.Voluntarios))
                    datos.Voluntarios = "0";
                if (string.IsNullOrEmpty(datos.OrdenPrestacionServicios))
                    datos.OrdenPrestacionServicios = "0";
                if (string.IsNullOrEmpty(datos.ContratoLaboral))
                    datos.ContratoLaboral = "0";
                if (string.IsNullOrEmpty(datos.ContratoHonorario))
                    datos.ContratoHonorario = "0";

                if (string.IsNullOrEmpty(datos.Primaria))
                    datos.Primaria = "0";
                if (string.IsNullOrEmpty(datos.Secundaria))
                    datos.Secundaria = "0";
                if (string.IsNullOrEmpty(datos.Tecnico))
                    datos.Tecnico = "0";
                if (string.IsNullOrEmpty(datos.UniversitariaSinTitulo))
                    datos.UniversitariaSinTitulo = "0";

                if (string.IsNullOrEmpty(datos.PregradoMusica))
                    datos.PregradoMusica = "0";

                if (string.IsNullOrEmpty(datos.PregradoOtrasAreas))
                    datos.PregradoOtrasAreas = "0";

                if (string.IsNullOrEmpty(datos.PostGrado))
                    datos.PostGrado = "0";

                //Apoyo
                if (string.IsNullOrEmpty(datos.VoluntariosAdministrativo))
                    datos.VoluntariosAdministrativo = "0";

                if (string.IsNullOrEmpty(datos.OrdenPrestacionServiciosAdministrativo))
                    datos.OrdenPrestacionServiciosAdministrativo = "0";

                if (string.IsNullOrEmpty(datos.ContratoHonorariosAdministrativo))
                    datos.ContratoHonorariosAdministrativo = "0";

                if (string.IsNullOrEmpty(datos.ContratoLaboralAdministrativo))
                    datos.ContratoLaboralAdministrativo = "0";

                bool boolcreadaLegalmente = false;
                bool boolApoyoAdministrativo = false;
                bool boolIncluyeActividadMusical = false;
                int Totaldocentesvinculados = Convert.ToInt32(datos.Voluntarios) + Convert.ToInt32(datos.OrdenPrestacionServicios) + Convert.ToInt32(datos.ContratoLaboral) + Convert.ToInt32(datos.ContratoHonorario);
                int TotaldocentesNivelEducativo = Convert.ToInt32(datos.Primaria) + Convert.ToInt32(datos.Secundaria) + Convert.ToInt32(datos.Tecnico) + Convert.ToInt32(datos.UniversitariaSinTitulo) + Convert.ToInt32(datos.PregradoMusica) + Convert.ToInt32(datos.PregradoOtrasAreas) + Convert.ToInt32(datos.PostGrado);

                if (datos.CreadaLegalmente == 1)
                    boolcreadaLegalmente = true;
                if (datos.ApoyoAdministrativo == 1)
                    boolApoyoAdministrativo = true;
                if (datos.ActividadMusical == 1)
                    boolIncluyeActividadMusical = true;

                DateTime? datFecha = null;
                if (!string.IsNullOrEmpty(datos.FechaNacimiento))
                    datFecha = Convert.ToDateTime(datos.FechaNacimiento);


                if (datos.PublicadoPNMC != null)
                {
                    if (datos.PublicadoPNMC.PracticaMusicalIds != null)
                    {
                        foreach (string s in datos.PublicadoPNMC.PracticaMusicalIds)
                        {
                            practicamusicalPNMCselecionadas.Add(s);
                        }
                    }
                }

                InstitucionalidadLogica.Grabar(Convert.ToDecimal(Id),
                                                boolcreadaLegalmente,
                                                datos.NombreDirector,
                                                datFecha,
                                                datos.TelefonoCelularDirector,
                                                datos.CorreoElectronicoDirector,
                                                Convert.ToInt16(datos.TipoVinculacionDirector),
                                                datos.EntidadContratanteDirector,
                                                Convert.ToInt16(datos.Voluntarios),
                                                Convert.ToInt16(datos.OrdenPrestacionServicios),
                                                Convert.ToInt16(datos.ContratoHonorario),
                                                Convert.ToInt16(datos.ContratoLaboral),
                                                Convert.ToInt16(Totaldocentesvinculados),
                                                Convert.ToInt16(datos.Primaria),
                                                Convert.ToInt16(datos.Secundaria),
                                                Convert.ToInt16(datos.Tecnico),
                                                Convert.ToInt16(datos.UniversitariaSinTitulo),
                                                Convert.ToInt16(datos.PregradoMusica),
                                                Convert.ToInt16(datos.PregradoOtrasAreas),
                                                Convert.ToInt16(datos.PostGrado),
                                                Convert.ToInt16(TotaldocentesNivelEducativo),
                                                boolApoyoAdministrativo,
                                                Convert.ToInt16(datos.VoluntariosAdministrativo),
                                                Convert.ToInt16(datos.OrdenPrestacionServiciosAdministrativo),
                                                Convert.ToInt16(datos.ContratoHonorariosAdministrativo),
                                                Convert.ToInt16(datos.ContratoLaboralAdministrativo),
                                                boolIncluyeActividadMusical,
                                                datos.Naturaleza,
                                                datos.DependeInstitucion,
                                                datos.NombreEntidad,
                                                Convert.ToInt32(datos.NivelEntidad),
                                                datos.Regimen,
                                                datos.SubRegimen,
                                                UsuarioId,
                                               NombreCompletoUsuario,
                                                Request.UserHostAddress,
                                                 datos.OperaEntidad,
                                                practicamusicalPNMCselecionadas);

                if (!ValidateDocumentoCreacion)
                {
                    DocumentoId = CrearDocumento(UsuarioId, NombreCompletoUsuario, datos.DocumentoCreacion);

                    if (DocumentoId > 0)
                    {
                        InstitucionalidadLogica.CrearDocumentoEscuelas(Convert.ToDecimal(Id), DocumentoId, datos.DocumentoCreacion.FileName, datos.FechaDocumentoCreacion, datos.TipoDocumentoCreacion, datos.NumeroDocumentoCreacion);
                    }

                    validateDocumento = true;
                }


                return validateDocumento;
            }
            catch (Exception ex)
            { throw ex; }
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

                DocumentoId = DocumentosNeg.Crear(documento, NombreUsuario, Request.UserHostAddress, UsuarioId);

            }
            return DocumentoId;

        }

        private void GrabarInfraestructura(InfraestructuraModel datos, int Id)
        {

            try
            {

                if (string.IsNullOrEmpty(datos.CantidadCuerdasPulsadas))
                    datos.CantidadCuerdasPulsadas = "0";

                if (string.IsNullOrEmpty(datos.CantidadCuerdasSinfonicas))
                    datos.CantidadCuerdasSinfonicas = "0";

                if (string.IsNullOrEmpty(datos.CantidadVientosMadera))
                    datos.CantidadVientosMadera = "0";

                if (string.IsNullOrEmpty(datos.CantidadVientosMetales))
                    datos.CantidadVientosMetales = "0";


                if (string.IsNullOrEmpty(datos.CantidadPercusionMenor))
                    datos.CantidadPercusionMenor = "0";

                if (string.IsNullOrEmpty(datos.CantidadPercusionSinfonica))
                    datos.CantidadPercusionSinfonica = "0";

                if (string.IsNullOrEmpty(datos.CantidadOtros))
                    datos.CantidadOtros = "0";

                // dotación
                if (string.IsNullOrEmpty(datos.CantidadSillas))
                    datos.CantidadSillas = "0";

                if (string.IsNullOrEmpty(datos.CantidadAtriles))
                    datos.CantidadAtriles = "0";
                if (string.IsNullOrEmpty(datos.CantidadTableros))
                    datos.CantidadTableros = "0";
                if (string.IsNullOrEmpty(datos.CantidadEstanterias))
                    datos.CantidadEstanterias = "0";

                if (string.IsNullOrEmpty(datos.PorcentajeAdecuacion))
                    datos.PorcentajeAdecuacion = "0";

                decimal totalInstrumentos = Convert.ToDecimal(datos.CantidadCuerdasPulsadas) + Convert.ToDecimal(datos.CantidadCuerdasSinfonicas) + Convert.ToDecimal(datos.CantidadVientosMadera) +
                                            Convert.ToDecimal(datos.CantidadVientosMetales) + Convert.ToDecimal(datos.CantidadPercusionMenor) + Convert.ToDecimal(datos.CantidadPercusionSinfonica) + Convert.ToDecimal(datos.CantidadOtros);
                bool EsTieneAccesoInternet = false;
                bool EsTieneMaterialPedagogico = false;
                bool EsSedeAsignada = false;
                bool EsAdecuadaAcusticamente = false;
                if (datos.TieneAccesoInternet == 1)
                    EsTieneAccesoInternet = true;

                if (datos.TieneMaterialPedagogico == 1)
                    EsTieneMaterialPedagogico = true;

                if (datos.EsSedeAsignada == 1)
                    EsSedeAsignada = true;
                if (datos.EsAdecuadaAcusticamente == 1)
                    EsAdecuadaAcusticamente = true;


                InfraestructuraLogica.Grabar(Id, EsSedeAsignada,
                                              EsTieneMaterialPedagogico,
                                              EsAdecuadaAcusticamente,
                                              Convert.ToInt16(datos.CantidadCuerdasPulsadas),
                                               Convert.ToInt16(datos.CantidadCuerdasSinfonicas),
                                               Convert.ToInt16(datos.CantidadVientosMadera),
                                               Convert.ToInt16(datos.CantidadVientosMetales),
                                               Convert.ToInt16(datos.CantidadPercusionMenor),
                                               Convert.ToInt16(datos.CantidadPercusionSinfonica),
                                              Convert.ToInt16(datos.CantidadOtros),
                                               Convert.ToInt16(totalInstrumentos),
                                              EsTieneMaterialPedagogico,
                                               Convert.ToInt16(datos.CantidadTitulosBibliograficos),
                                              datos.Sede,
                                               Convert.ToInt16(datos.CantidadSillas),
                                               Convert.ToInt16(datos.CantidadAtriles),
                                              Convert.ToInt16(datos.CantidadTableros),
                                               Convert.ToInt16(datos.CantidadEstanterias),
                                               Convert.ToInt16(datos.PorcentajeAdecuacion),
                                              "",
                                              EsTieneAccesoInternet,
                                              datos.TipoInternetPublicado,
                                              datos.FuentesDotacionPublicado,
                                              datos.TipoFuentesDotacionPublicado,
                                              datos.MaterialPedagogicoPublicado,
                                              datos.TipoSolucionesAcusticasPublicado,
                                              datos.Espacio,
                                             Convert.ToInt32(UsuaroId),
                                              NombreCompletoUsuario,
                                              Request.UserHostAddress);



            }
            catch (Exception ex)
            { throw ex; }
        }

        private void GrabarParticipacion(ParticipacionModel datos, int Id)
        {

            try
            {
                if (string.IsNullOrEmpty(datos.CantidadPrimeraInfancia))
                    datos.CantidadPrimeraInfancia = "0";
                if (string.IsNullOrEmpty(datos.CantidaEntre6y11))
                    datos.CantidaEntre6y11 = "0";
                if (string.IsNullOrEmpty(datos.CantidaEntre12y18))
                    datos.CantidaEntre12y18 = "0";
                if (string.IsNullOrEmpty(datos.CantidaEntre19y26))
                    datos.CantidaEntre19y26 = "0";
                if (string.IsNullOrEmpty(datos.CantidaEntre27y60))
                    datos.CantidaEntre27y60 = "0";
                if (string.IsNullOrEmpty(datos.CantidadMayores60))
                    datos.CantidadMayores60 = "0";

                if (string.IsNullOrEmpty(datos.CantidadIndigenas))
                    datos.CantidadIndigenas = "0";
                if (string.IsNullOrEmpty(datos.CantidadAfrocolombiana))
                    datos.CantidadAfrocolombiana = "0";
                if (string.IsNullOrEmpty(datos.CantidadRom))
                    datos.CantidadRom = "0";
                if (string.IsNullOrEmpty(datos.CantidadRaizales))
                    datos.CantidadRaizales = "0";
                if (string.IsNullOrEmpty(datos.CantidadEtniaOtros))
                    datos.CantidadEtniaOtros = "0";

                //por sexo
                if (string.IsNullOrEmpty(datos.CantidadHombres))
                    datos.CantidadHombres = "0";
                if (string.IsNullOrEmpty(datos.CantidadMujeres))
                    datos.CantidadMujeres = "0";

                //por Zona
                if (string.IsNullOrEmpty(datos.CantidadRural))
                    datos.CantidadRural = "0";
                if (string.IsNullOrEmpty(datos.CantidadUrbana))
                    datos.CantidadUrbana = "0";

                //por población especial
                if (string.IsNullOrEmpty(datos.CantidadDicapacitados))
                    datos.CantidadDicapacitados = "0";
                if (string.IsNullOrEmpty(datos.CantidadDesplazados))
                    datos.CantidadDesplazados = "0";

                if (string.IsNullOrEmpty(datos.CantidadRedUnidos))
                    datos.CantidadRedUnidos = "0";

                if (string.IsNullOrEmpty(datos.NumeroIntegrantes))
                    datos.NumeroIntegrantes = "0";

                if (string.IsNullOrEmpty(datos.CantidadCupos))
                    datos.CantidadCupos = "0";

                int totalAlumnos = Convert.ToInt32(datos.CantidadPrimeraInfancia) + Convert.ToInt32(datos.CantidaEntre6y11) + Convert.ToInt32(datos.CantidaEntre12y18) + Convert.ToInt32(datos.CantidaEntre19y26) + Convert.ToInt32(datos.CantidaEntre27y60) + Convert.ToInt32(datos.CantidadMayores60);
                int totalAlumnosEtnia = Convert.ToInt32(datos.CantidadIndigenas) + Convert.ToInt32(datos.CantidadAfrocolombiana) + Convert.ToInt32(datos.CantidadRom) + Convert.ToInt32(datos.CantidadRaizales) + Convert.ToInt32(datos.CantidadEtniaOtros);
                bool TieneOrganizacionComunitaria = false;
                bool TieneProyectosMusica = false;

                if (datos.TieneOrganizacionComunitaria == 1)
                    TieneOrganizacionComunitaria = true;

                if (datos.TieneProyectosMusica == 1)
                    TieneProyectosMusica = true;


                ParticipacionLogica.Grabar(Id,
                                            Convert.ToInt32(datos.CantidadPrimeraInfancia),
                                             Convert.ToInt32(datos.CantidaEntre6y11),
                                             Convert.ToInt32(datos.CantidaEntre12y18),
                                             Convert.ToInt32(datos.CantidaEntre19y26),
                                             Convert.ToInt32(datos.CantidaEntre27y60),
                                            totalAlumnos,
                                             Convert.ToInt32(datos.CantidadHombres),
                                             Convert.ToInt32(datos.CantidadMujeres),
                                            (Convert.ToInt32(datos.CantidadHombres) + Convert.ToInt32(datos.CantidadMujeres)),
                                             Convert.ToInt32(datos.CantidadRural),
                                             Convert.ToInt32(datos.CantidadUrbana),
                                            (Convert.ToInt32(datos.CantidadRural) + Convert.ToInt32(datos.CantidadUrbana)),
                                             Convert.ToInt32(datos.CantidadIndigenas),
                                             Convert.ToInt32(datos.CantidadAfrocolombiana),
                                             Convert.ToInt32(datos.CantidadRom),
                                             Convert.ToInt32(datos.CantidadRaizales),
                                             Convert.ToInt32(datos.CantidadEtniaOtros),
                                            totalAlumnosEtnia,
                                             Convert.ToInt32(datos.CantidadDicapacitados),
                                             Convert.ToInt32(datos.CantidadDesplazados),
                                            (Convert.ToInt32(datos.CantidadDicapacitados) + Convert.ToInt32(datos.CantidadDesplazados) + Convert.ToInt32(datos.CantidadRedUnidos)),
                                            TieneOrganizacionComunitaria,
                                            Convert.ToInt16(datos.TipoOrganizacionComunitaria),
                                            "",
                                            TieneProyectosMusica,
                                            "",
                                            datos.OrganizacionComunitaria,
                                             Convert.ToInt32(datos.NumeroIntegrantes),
                                            datos.NombrePresidente,
                                            datos.TelefonoCelular,
                                            datos.TelefonoFijo,
                                            datos.CorreoElectronicoParticipacion,
                                             Convert.ToInt32(datos.CantidadMayores60),
                                             Convert.ToInt32(datos.CantidadCupos),
                                             Convert.ToInt32(datos.CantidadRedUnidos),
                                             datos.ProyectosPublicado,
                                             Convert.ToInt32(UsuaroId),
                                                NombreCompletoUsuario,
                                             Request.UserHostAddress);

            }
            catch (Exception ex)
            { throw ex; }
        }

        private void GrabarFormacion(FormacionModel datos, int Id)
        {
            List<string> practicamusicalselecionadas = new List<string>();

            bool TieneProgramasPorEscrito = false;
            bool TieneTalleresIndependientes = false;
            try
            {
                if (string.IsNullOrEmpty(datos.DuracionInicio))
                    datos.DuracionInicio = "0";
                if (string.IsNullOrEmpty(datos.PoblacionInicio))
                    datos.PoblacionInicio = "0";
                if (string.IsNullOrEmpty(datos.HorasInicio))
                    datos.HorasInicio = "0";

                if (string.IsNullOrEmpty(datos.DuracionBasico))
                    datos.DuracionBasico = "0";
                if (string.IsNullOrEmpty(datos.PoblacionBasico))
                    datos.PoblacionBasico = "0";
                if (string.IsNullOrEmpty(datos.HorasBasico))
                    datos.HorasBasico = "0";


                if (string.IsNullOrEmpty(datos.DuracionMedio))
                    datos.DuracionMedio = "0";
                if (string.IsNullOrEmpty(datos.PoblacionMedio))
                    datos.PoblacionMedio = "0";
                if (string.IsNullOrEmpty(datos.HorasMedio))
                    datos.HorasMedio = "0";

                if (string.IsNullOrEmpty(datos.DuracionCursos))
                    datos.DuracionCursos = "0";
                if (string.IsNullOrEmpty(datos.PoblacionCursos))
                    datos.PoblacionCursos = "0";
                if (string.IsNullOrEmpty(datos.HorasCursos))
                    datos.HorasCursos = "0";

                if (string.IsNullOrEmpty(datos.DuracionPedagogias))
                    datos.DuracionPedagogias = "0";
                if (string.IsNullOrEmpty(datos.PoblacionPedagogias))
                    datos.PoblacionPedagogias = "0";
                if (string.IsNullOrEmpty(datos.HorasPedagogias))
                    datos.HorasPedagogias = "0";



                if (datos.TieneProgramasPorEscrito == 1)
                    TieneProgramasPorEscrito = true;

                if (datos.TieneTalleresIndependientes == 1)
                    TieneTalleresIndependientes = true;

                if (datos.Publicado != null)
                {
                    if (datos.Publicado.PracticaMusicalIds != null)
                    {
                        foreach (string s in datos.Publicado.PracticaMusicalIds)
                        {
                            practicamusicalselecionadas.Add(s);
                        }
                    }
                }




                FormacionLogica.Grabar(Id,
                                       datos.ProcesosFormacion,
                                        true,
                                        TieneTalleresIndependientes,
                                        TieneProgramasPorEscrito,
                                        Convert.ToInt32(datos.DuracionInicio),
                                         Convert.ToInt32(datos.PoblacionInicio),
                                         Convert.ToInt32(datos.HorasInicio),
                                         datos.ObservacionesNiveles,
                                         Convert.ToInt32(datos.DuracionBasico),
                                         Convert.ToInt32(datos.PoblacionBasico),
                                         Convert.ToInt32(datos.HorasBasico),
                                         datos.ObservacionesNiveles,
                                         Convert.ToInt32(datos.DuracionMedio),
                                         Convert.ToInt32(datos.PoblacionMedio),
                                         Convert.ToInt32(datos.HorasMedio),
                                         datos.ObservacionesNiveles,
                                         Convert.ToInt32(datos.DuracionCursos),
                                         Convert.ToInt32(datos.PoblacionCursos),
                                         Convert.ToInt32(datos.HorasCursos),
                                        datos.ObservacionesTalleres,
                                         Convert.ToInt32(datos.DuracionPedagogias),
                                         Convert.ToInt32(datos.PoblacionPedagogias),
                                         Convert.ToInt32(datos.HorasPedagogias),
                                        datos.ObservacionesTalleres,
                                       practicamusicalselecionadas,
                                     Convert.ToInt32(UsuaroId),
                                      NombreCompletoUsuario,
                                       Request.UserHostAddress);


            }
            catch (Exception ex)
            { throw ex; }
        }

        private void GrabarFormacionNuevo(FormacionModelNuevo datos, int Id)
        {
            List<string> practicamusicalselecionadas = new List<string>();

            bool TieneProgramasPorEscrito = false;
            bool TieneTalleresIndependientes = false;
            try
            {


                if (datos.TieneProgramasPorEscrito == 1)
                    TieneProgramasPorEscrito = true;

                if (datos.TieneTalleresIndependientes == 1)
                    TieneTalleresIndependientes = true;


                FormacionLogica.GrabarNuevo(Id,
                                       datos.ProcesosFormacion,
                                       TieneTalleresIndependientes,
                                       TieneProgramasPorEscrito,
                                        Convert.ToInt32(UsuaroId),
                                        NombreCompletoUsuario,
                                       Request.UserHostAddress);


            }
            catch (Exception ex)
            { throw ex; }
        }

        private void GrabarProduccion(ProduccionModel datos, int Id)
        {

            try
            {
                if (string.IsNullOrEmpty(datos.CantidadGirasNacionales))
                    datos.CantidadGirasNacionales = "0";

                if (string.IsNullOrEmpty(datos.CantidadConciertos))
                    datos.CantidadGirasNacionales = "0";

                if (string.IsNullOrEmpty(datos.CantidadDiscos))
                    datos.CantidadGirasNacionales = "0";

                if (string.IsNullOrEmpty(datos.CantidadRepertorios))
                    datos.CantidadGirasNacionales = "0";
                if (string.IsNullOrEmpty(datos.CantidadMaterialDivulgativo))
                    datos.CantidadGirasNacionales = "0";

                if (string.IsNullOrEmpty(datos.CantidadMaterialPedagogico))
                    datos.CantidadGirasNacionales = "0";
                if (string.IsNullOrEmpty(datos.CantidadAgrupaciones))
                    datos.CantidadGirasNacionales = "0";

                if (string.IsNullOrEmpty(datos.CantidadGirasInternacionales))
                    datos.CantidadGirasNacionales = "0";

                ProduccionLogica.Grabar(Id,
                                        Convert.ToInt16(datos.CantidadGirasNacionales),
                                        Convert.ToInt16(datos.CantidadConciertos),
                                        Convert.ToInt16(datos.CantidadDiscos),
                                        Convert.ToInt16(datos.CantidadRepertorios),
                                        Convert.ToInt16(datos.CantidadMaterialDivulgativo),
                                        Convert.ToInt16(datos.CantidadMaterialPedagogico),
                                        Convert.ToInt16(datos.CantidadAgrupaciones),
                                        Convert.ToInt16(datos.CantidadGirasInternacionales),
                                        Convert.ToInt32(UsuaroId),
                                        NombreCompletoUsuario,
                                        Request.UserHostAddress);


            }
            catch (Exception ex)
            { throw ex; }
        }
        [HttpPost]
        public JsonResult PasoActual(decimal Id)
        {
            int paso = 1;
            bool ValidarBeneficiario = false;
            bool ValidarOrganizacion = false;
            bool validarFormacion = false;
            bool validarInfraestructura = false;
            bool validarProduccion = false;
            ValidarBeneficiario = ParticipacionLogica.ValidarParticipacion(Convert.ToDecimal(Id));

            if (!ValidarBeneficiario)
            {
                paso = 2;
            }
            else
            {
                ValidarOrganizacion = InstitucionalidadLogica.ValidarInstitucionalidad(Convert.ToDecimal(Id));
                if (!ValidarOrganizacion)
                {
                    paso = 3;
                }
                else
                {
                    validarFormacion = FormacionLogica.ValidarFormacion(Convert.ToDecimal(Id));
                    if (!validarFormacion)
                    {
                        paso = 4;
                    }
                    else
                    {
                        validarInfraestructura = InfraestructuraLogica.ValidarInfraestructura(Convert.ToDecimal(Id));
                        if (!validarInfraestructura)
                        {
                            paso = 5;
                        }
                        else
                        {
                            validarProduccion = ProduccionLogica.ValidarProduccion(Convert.ToDecimal(Id));
                            paso = 6;
                            if (!validarProduccion)
                            {
                                paso = 61;
                            }
                            else
                            {
                                paso = 6;
                            }

                        }

                    }
                }
            }

            return Json(paso, JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region ConsultasJson

        public JsonResult AgregarVideo(int Id,
                                      string clasificacion,
                                      string urlVideo,
                                      string descripcion)
        {
            bool isSuccess = true;


            if (string.IsNullOrEmpty(clasificacion))
                return Json(new { Response = "Error" });

            //if (string.IsNullOrEmpty(descripcion))
            //    return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(urlVideo))
                return Json(new { Response = "Error" });


            var datos = new EscuelaVideoDTO();

            datos.EscuelaId = Convert.ToDecimal(Id);
            datos.urlvideoYoutube = urlVideo;
            datos.clasificacion = clasificacion;
            datos.Descripcion = descripcion;
            RedesLogica.AgregarVídeo(datos);

            return Json(isSuccess);


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

        public JsonResult ConsultarSubRegimen(string padre = null)
        {

            List<BasicaDTO> listParametros = new List<BasicaDTO>();

            if (!String.IsNullOrEmpty(padre))
            {
                listParametros = ParametrosLogica.ConsultarRegimenHijos(padre);

            }

            var data = listParametros;
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Grilla

        public static void ApplyCurrentCulture()
        {

            CultureInfo ci = CultureInfo.GetCultureInfo("es");
            Thread.CurrentThread.CurrentUICulture = ci;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);

        }
        // [Authorize]
        public ActionResult ExportTo(GridViewSettings settings, object dataObject, XlsExportOptionsEx exportOptions)
        {
            var obj = settings;
            string Busqueda = "";
            var model = new List<EscuelaConsultaModel>();
            model = ObtenerMisEscuelas(Busqueda);
            return GridViewExtension.ExportToXlsx(GetGridSettings(), model.ToList(), new XlsxExportOptionsEx() { AllowSortingAndFiltering = DevExpress.Utils.DefaultBoolean.True, ExportType = ExportType.WYSIWYG });

        }


        private GridViewSettings GetGridSettings()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridEscuelas";
            settings.CallbackRouteValues = new { Controller = "EscuelasMusica", Action = "GridViewPartial" };
            settings.Theme = "BlackGlass";
            settings.KeyFieldName = "Id";
            settings.SettingsPager.Visible = true;
            settings.Settings.ShowGroupPanel = true;
            settings.Settings.ShowFilterRow = true;
            settings.SettingsBehavior.AllowSelectByRowClick = true;
            settings.SettingsBehavior.ColumnResizeMode = ColumnResizeMode.Control;
            settings.Settings.ShowHeaderFilterButton = true;
            settings.SettingsPopup.HeaderFilter.Height = 200;
            //settings.Settings.ShowFilterRow = true;
            //settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            //settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.Selected; 
            settings.SettingsExport.FileName = "EscuelasMusica" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.RenderBrick = (sender, e) =>
            {
                if (e.RowType == GridViewRowType.Data && e.VisibleIndex % 2 == 0)
                    e.BrickStyle.BackColor = System.Drawing.Color.FromArgb(0xEE, 0xEE, 0xEE);
            };

            settings.KeyFieldName = "EscuelaId";
            settings.Columns.Add("NombreEscuela");
            settings.Columns.Add(column =>
            {
                column.FieldName = "Departamento";
                column.Settings.AutoFilterCondition = AutoFilterCondition.Like;
            });
            settings.Columns.Add("Municipio");
            settings.Columns.Add("Naturaleza");
            settings.Columns.Add("Estado");
            settings.Columns.Add("Tipo");

            return settings;
        }

        private GridViewSettings GetGridSettingsAuditoria()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridEscuelasAuditoria";
            settings.CallbackRouteValues = new { Controller = "EscuelasMusica", Action = "GridViewPartialAuditoria" };
            settings.Theme = "BlackGlass";
            settings.KeyFieldName = "Id";
            settings.SettingsPager.Visible = true;
            settings.Settings.ShowGroupPanel = true;
            settings.Settings.ShowFilterRow = true;
            settings.SettingsBehavior.AllowSelectByRowClick = true;
            settings.SettingsBehavior.ColumnResizeMode = ColumnResizeMode.Control;
            settings.Settings.ShowHeaderFilterButton = true;
            settings.SettingsPopup.HeaderFilter.Height = 200;

            settings.SettingsExport.FileName = "AuditoriaEscuelas" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.RenderBrick = (sender, e) =>
            {
                if (e.RowType == GridViewRowType.Data && e.VisibleIndex % 2 == 0)
                    e.BrickStyle.BackColor = System.Drawing.Color.FromArgb(0xEE, 0xEE, 0xEE);
            };

            settings.KeyFieldName = "Id";
            settings.Columns.Add("Escuelas");

            settings.Columns.Add("Categoria");
            settings.Columns.Add("NombreUsuario");
            settings.Columns.Add("FechaRegistro");
            settings.Columns.Add("Operacion");
            settings.Columns.Add("Descripcion");
            return settings;
        }

        public ActionResult ExportToAuditoria(string Id)
        {
            var model = new List<EscuelaAuditoriaModelDTO>();
            model = EscuelasLogica.ConsultarAuditoriaEscuelas(Convert.ToInt32(Id));


            return GridViewExtension.ExportToXls(GetGridSettingsAuditoria(), model.ToList());
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartialAuditoria(string Id = null)
        {
            ViewBag.GridSettings = GetGridSettingsAuditoria();
            var model = new List<EscuelaAuditoriaModelDTO>();
            model = EscuelasLogica.ConsultarAuditoriaEscuelas(Convert.ToInt32(Id));
            return PartialView("_GridViewPartialAuditoria", model);
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial(string Busqueda = null)
        {
            ViewBag.GridSettings = GetGridSettings();
            var model = new List<EscuelaConsultaModel>();
            model = ObtenerMisEscuelas(Busqueda);
            return PartialView("_GridViewPartial", model);
        }

        private List<EscuelaConsultaModel> ObtenerMisEscuelas(string Busqueda = null)
        {
            var model = new List<EscuelaConsultaModel>();
            decimal UsuarioSipaId = UsuarioLogica.ObtenerUsuarioSipaId(Usuario);

            if (string.IsNullOrEmpty(Busqueda))
            {
                if (TempData["TipoRegistro"] != null)
                    Busqueda = TempData["TipoRegistro"].ToString();
                else
                    Busqueda = "1";
            }

            if (Busqueda == "1")
            {
                model = TranslatorEscuelas.ConsultarEscuelasPorAdmUsuarios(UsuarioSipaId);
                TempData["TipoRegistro"] = 1;
            }
            else if (Busqueda == "2")
            {
                TempData["TipoRegistro"] = 2;
                model = TranslatorEscuelas.ConsultarEscuelasPorEstado(Comunes.ConstantesRecursosBD.CODIGO_ESTADO_PUBLICADO);
            }

            return model;
        }

        public ActionResult GridViewSolicitud(string Busqueda = null)
        {
            List<SolicitudUsuarioDTO> model = null;
            model = ObtenerMisregistros(Busqueda);
            return PartialView("_GridViewSolicitud", model);
        }

        private List<SolicitudUsuarioDTO> ObtenerMisregistros(string Busqueda = null)
        {
            var model = new List<SolicitudUsuarioDTO>();

            if (string.IsNullOrEmpty(Busqueda))
            {
                if (TempData["TipoRegistroE"] != null)
                    Busqueda = TempData["TipoRegistroE"].ToString();
                else
                    Busqueda = "1";
            }

            if (Busqueda == "1")
            {
                model = AsignacionUsuariosNeg.ConsultarUsuariosPorEstado(Comunes.ConstantesRecursosBD.CODIGO_ESTADO_PENDIENTE);
                TempData["TipoRegistroE"] = 1;
            }
            else if (Busqueda == "2")
            {
                TempData["TipoRegistroE"] = 2;
                model = AsignacionUsuariosNeg.ConsultarUsuariosPorEstado(Comunes.ConstantesRecursosBD.CODIGO_ESTADO_PUBLICADO);
            }


            return model;
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewSolicitudAprobar(int Id)
        {
            List<SolicitudUsuarioDTO> model = null;

            try
            {
                AsignacionUsuariosNeg.ActualizarSolicitudUsuario(Id, Convert.ToInt32(UsuaroId));
                model = AsignacionUsuariosNeg.ConsultarUsuariosPorEstado(Comunes.ConstantesRecursosBD.CODIGO_ESTADO_PENDIENTE);
            }
            catch (Exception e)
            {
                ViewData["EditError"] = e.Message;
            }
            return PartialView("_GridViewSolicitud", model);
        }
        public ActionResult GridViewPartialPermisos()
        {
            ViewBag.GridSettings = GetGridSettingsPermisos();
            var model = new List<EscuelaConsultaModel>();
            model = ObtenerEscuelasGestion();


            return PartialView("_GridViewPartialPermisos", model);
        }


        private List<EscuelaConsultaModel> ObtenerEscuelasGestion()
        {
            bool EsAdmin = false;
            var model = new List<EscuelaConsultaModel>();
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
                model = ConsultarEscuelas();
            else
                model = ConsultarEscuelasPorMunicipio(Convert.ToInt32(UsuaroId));
            return model;
        }
        public ActionResult ExportToPermisos(string OutputFormat)
        {
            var model = new List<EscuelaConsultaModel>();
            model = ObtenerEscuelasGestion();


            return GridViewExtension.ExportToXls(GetGridSettingsPermisos(), model.ToList());
        }
        private GridViewSettings GetGridSettingsPermisos()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridEscuelasPermisos";
            settings.CallbackRouteValues = new { Controller = "EscuelasMusica", Action = "GridViewPartialPermisos" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "EscuelasMusicaPermisos" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "EscuelaId";
            settings.Columns.Add("NombreEscuela");
            settings.Columns.Add("Departamento");
            settings.Columns.Add("Municipio");
            settings.Columns.Add("Naturaleza");
            settings.Columns.Add("Tipo");
            settings.Columns.Add("Estado");
            settings.Columns.Add("FechaActualizacion");
            settings.Columns.Add("FechaCreacion");
            return settings;
        }
        [HttpPost, ValidateInput(false)]
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
            return PartialView("_GridViewPartial", model);
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
            return PartialView("_GridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialDelete(decimal EscuelaId)
        {
            var model = new List<EscuelaConsultaModel>();

            try
            {
                EscuelasLogica.EliminarEscuelas(EscuelaId, Convert.ToInt32(UsuaroId), NombreCompletoUsuario, Request.UserHostAddress);
                model = ConsultarEscuelas();
            }
            catch (Exception e)
            {
                ViewData["EditError"] = e.Message;
            }
            return PartialView("_GridViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialPermisosDelete(decimal EscuelaId)
        {
            var model = new List<EscuelaConsultaModel>();

            try
            {
                EscuelasLogica.EliminarEscuelas(EscuelaId, Convert.ToInt32(UsuaroId), NombreCompletoUsuario, Request.UserHostAddress);

            }
            catch (Exception e)
            {
                ViewData["EditError"] = e.Message;
            }
            return PartialView("_GridViewPartial", model);
        }
        #endregion
        protected override void OnException(ExceptionContext filterContext)
        {
            string ruta = "";
            ruta = Server.MapPath("/Log");
            Log.WriteLog(ruta, filterContext.Exception.ToString());

            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;


            var model = new HandleErrorInfo(filterContext.Exception, "EscuelasMusica", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }



    }
}