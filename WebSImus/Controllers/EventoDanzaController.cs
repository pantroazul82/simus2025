using DevExpress.Web.Mvc;
using SM.Aplicacion.Basicas;
using SM.Aplicacion.Documentos;
using SM.Aplicacion.Eventos;
using SM.Aplicacion.Modulo_Usuarios;
using SM.LibreriaComun.DTO;
using SM.Utilidades.Log;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSImus.Models;
using WebSImus.Translator;

namespace WebSImus.Controllers
{
    [HandleError()]
    [SessionExpire]
    public class EventoDanzaController : BaseController
    {
        private readonly List<BasicaDTO> listAreasArtisticas = new List<BasicaDTO>{
            new BasicaDTO { value = "Música", text  = "Música" },
            new BasicaDTO { value = "Danza", text  = "Danza" },
           
            };

        SM.LibreriaRecursos.Recursos.FabricaManejador fabricaMensajes;
        SM.LibreriaRecursos.Recursos.ManejadorRecursos manejadoMensajes;
        //
        // GET: /Evento/
        public ActionResult Index(string Busqueda)
        {

            bool EsAdmin = false;

            string strTipo = "Danza";
            List<BasicaDTO> listado = new List<BasicaDTO>();
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];
            if (Session["$EsAdmin"] == null)
            {
                string codigoAdmin = Comunes.ConstantesRecursosBD.CODIGO_ADMIN;
                EsAdmin = UsuarioLogica.UsuarioEsAdmin(usuario.Id, codigoAdmin);
                Session["$EsAdmin"] = EsAdmin;
            }
            else
            {
                EsAdmin = (bool)Session["$EsAdmin"];
            }

            if (EsAdmin)
                listado = BasicaLogica.ListadoConsultasAdmin();
            else
                listado = BasicaLogica.ListadoConsultas();

            ViewBag.listadoBusqueda = new SelectList(listado, "value", "text", "1");

            if (string.IsNullOrEmpty(Busqueda))
                Session["$Evento"] = TranslatorEventos.ConsultarEventosPorUsuarioId(usuario.Id, strTipo);
            else if (Busqueda == "1")
                Session["$Evento"] = TranslatorEventos.ConsultarEventosPorUsuarioId(usuario.Id, strTipo);
            else if (Busqueda == "2")
                Session["$Evento"] = TranslatorEventos.ConsultarEventoPorEstadoId(Comunes.ConstantesRecursosBD.CODIGO_ESTADO_PUBLICADO, strTipo);
            else if (Busqueda == "3")
                Session["$Evento"] = TranslatorEventos.ConsultarEventosTodos();

            return View();
        }


        public ActionResult Consulta()
        {
           

            return View();
        }

        public ActionResult Detalle(int Id)
        {
            TempData["imagen"] = "~/img/img_defaultDanza.png";
            ViewBag.ImageData = "~/img/img_defaultDanza.png";
            var modelpadre = new EventoPadreModels();
            var model = new EventoModels();
            model = TranslatorEventos.ConsultaEventoPorId(Id);

            var modeltabla = new List<GrupoPublicoModels>();

            modeltabla = Translator.TranslatorEventos.ConsultarGruposPorEventoId(Id);

            modelpadre.listGrupos = modeltabla;
            if (model.Imagen != null)
            {
                string imageBase64Data = Convert.ToBase64String(model.Imagen);
                string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                TempData["imagen"] = imageDataURL;
                ViewBag.ImageData = imageDataURL;
            }
            modelpadre.DatosBasicos = model;
            return View(modelpadre);

        }
        public ActionResult _AgregarGrupo()
        {
            if (Session["$usuario"] == null)
                return RedirectToAction("Login", "Cuenta");
            return PartialView("_AgregarGrupo");
        }

        public JsonResult AgregarGrupo(int Id,
                                   string nombre,
                                   string contacto,
                                   string enlace,
                                   string telefono,
                                   string orden,
                                   string cantidad,
                                   string resena,
                                   string eventoId)
        {
            bool isSuccess = true;
            int intOrden = 0;


            if (string.IsNullOrEmpty(nombre))
                return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(contacto))
                return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(telefono))
                return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(orden))
                intOrden = 0;
            else
                intOrden = Convert.ToInt32(orden);


            if (string.IsNullOrEmpty(cantidad))
                return Json(new { Response = "Error" });



            if (cantidad == "0")
                return Json(new { Response = "Error" });

            var datos = new GrupoDTO();
            datos.EventoId = Convert.ToInt32(eventoId);
            datos.Orden = intOrden;
            datos.CantidadMiembros = Convert.ToInt32(cantidad);
            datos.EsGrupo = true;
            datos.Contacto = contacto;
            datos.Enlace = enlace;
            datos.Telefono = telefono;
            datos.Nombre = nombre;
            datos.Reseña = resena;
            EventosNeg.CrearGrupo(datos);

            return Json(isSuccess);


        }


        public ActionResult _TablaGrupo(int Id, int Eliminar)
        {
            if (Session["$usuario"] == null)
                return RedirectToAction("LoginCelebra", "Cuenta");

            var modeltabla = new List<GrupoPublicoModels>();

            if (Eliminar > 0)
            {
                EventosNeg.EliminarGrupo(Eliminar);

            }

            modeltabla = Translator.TranslatorEventos.ConsultarGruposPorEventoId(Id);
            return PartialView("_TablaGrupos", modeltabla);
        }

        public ActionResult CambiarEstado(int Id)
        {
            if (Session["$usuario"] == null)
                return RedirectToAction("login", "Cuenta");

            TempData["imagen"] = "~/img/img_defaultDanza.png";
            ViewBag.ImageData = "~/img/img_defaultDanza.png";
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];
            var modelPadre = new EventoDanzaPadreModels();
            var model = new EventoDanzaModels();
            model = TranslatorEventos.ConsultaDanzaEventoPorId(Id);


            if (model.DocumentoId > 0)
                model.documentoArchivo = TranslatorDocumento.ConsultaDocumento(model.DocumentoId);

            Session["$EventoId"] = Id;
            CargaInicial(model.CodigoDepartamento, model.CodigoMunicipio);
            List<BasicaDTO> objTipo = CaracterizacionMusicalNeg.ConsultarEstados();
            ViewBag.listEstado = new SelectList(objTipo, "value", "text");
            if (model.Imagen != null)
            {
                string imageBase64Data = Convert.ToBase64String(model.Imagen);
                string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                TempData["imagen"] = imageDataURL;
                ViewBag.ImageData = imageDataURL;
            }

            modelPadre.DatosBasicos = model;
            var modeltabla = new List<GrupoPublicoModels>();
            modeltabla = Translator.TranslatorEventos.ConsultarGruposPorEventoId(Id);
            modelPadre.listGrupos = modeltabla;
            return View(modelPadre);
        }

        [HttpPost]
        public ActionResult CambiarEstado(int Id, HttpPostedFileBase imagenPerfil, EventoDanzaModels model)
        {
            if (Session["$usuario"] == null)
                return RedirectToAction("Login", "Cuenta");

            string imageDataURL = "";
            var modelPadre = new EventoDanzaPadreModels();

            ViewBag.ImageData = "~/img/img_defaultDanza.png";
            DateTime FechaInicio = DateTime.Today;
            DateTime Fechafinal = DateTime.Today;

            CargaInicial(model.CodigoDepartamento, model.CodigoMunicipio);
            List<BasicaDTO> objTipo = CaracterizacionMusicalNeg.ConsultarEstados();
            ViewBag.listEstado = new SelectList(objTipo, "value", "text");
            modelPadre.DatosBasicos = model;
            var modeltabla = new List<GrupoPublicoModels>();
            modeltabla = Translator.TranslatorEventos.ConsultarGruposPorEventoId(Id);
            modelPadre.listGrupos = modeltabla;

            if (ModelState.IsValid)
            {
                byte[] fileData = null;

                if (imagenPerfil != null && imagenPerfil.ContentLength > 0)
                {

                    using (var binaryReader = new BinaryReader(imagenPerfil.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(imagenPerfil.ContentLength);
                    }

                    string imageBase64Data = Convert.ToBase64String(fileData);
                    imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                    ViewBag.ImageData = imageDataURL;
                }
                else
                {
                    if (model.Imagen != null)
                    {
                        string imageBase64Data = Convert.ToBase64String(model.Imagen);
                        imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                    }
                    else
                    {
                        if (TempData["imagen"] != null)
                            imageDataURL = (string)TempData["imagen"];
                        else
                            imageDataURL = "~/img/img_defaultDanza.png";
                    }

                    TempData["imagen"] = imageDataURL;
                    ViewBag.ImageData = imageDataURL;
                }

                if (model.Nacional == 2)
                {
                    bool validate = false;
                    if (string.IsNullOrEmpty(model.CodigoDepartamento))
                        validate = true;
                    else
                    {
                        if (model.CodigoDepartamento.Trim() == "Seleccione un departamento")
                            validate = true;
                    }

                    if (string.IsNullOrEmpty(model.CodigoMunicipio))
                        validate = true;
                    else
                    {
                        if (model.CodigoMunicipio.Trim() == "Seleccione un municipio")
                            validate = true;
                    }

                    if (validate)
                    {
                        ModelState.AddModelError("", "El departamento y municipio es obligatorio sí el evento no es Nacional");
                        return View(modelPadre);
                    }
                }
                if (!string.IsNullOrEmpty(model.FechaEvento))
                    try
                    {
                        string[] hora = model.HoraEvento.Split(' ');
                        CultureInfo provider = CultureInfo.InvariantCulture;
                        string dateString = model.FechaEvento + " " + hora[0] + ":01 " + hora[1];
                        FechaInicio = Convert.ToDateTime(dateString);

                    }
                    catch (FormatException f)
                    { string mensaje = f.ToString(); }

                if (!string.IsNullOrEmpty(model.FechaEventoFinal))
                    try
                    {
                        string[] hora = model.HoraEventoFinal.Split(' ');
                        CultureInfo provider = CultureInfo.InvariantCulture;
                        string dateString = model.FechaEventoFinal + " " + hora[0] + ":01 " + hora[1];
                        Fechafinal = Convert.ToDateTime(dateString);
                    }
                    catch (FormatException f)
                    { string mensaje = f.ToString(); }

                if (Fechafinal < FechaInicio)
                {
                    ModelState.AddModelError("", "La fecha final no puede ser menor a la fecha inicial");
                    return View(modelPadre);
                }


                ActualizarEvento(Id, model, fileData, true, FechaInicio, Fechafinal);

                Session["$EventoId"] = Id;
                Success(string.Format("<b></b> Se actualizo con éxito el evento: {0}  ", model.Nombre), true);
                return View("CambiarEstado", modelPadre);
            }


            return View(modelPadre);
        }
        public ActionResult Editar(int Id)
        {
            if (Session["$usuario"] == null)
                return RedirectToAction("login", "Cuenta");

            TempData["imagen"] = "~/img/img_defaultDanza.png";
            ViewBag.ImageData = "~/img/img_defaultDanza.png";
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];
            var modelPadre = new EventoDanzaPadreModels();
            var model = new EventoDanzaModels();
            model = TranslatorEventos.ConsultaDanzaEventoPorId(Id);

            if (model.ArtMusicaUsuarioId != usuario.Id)
                return RedirectToAction("Detalle", "EventoDanza", new { Id = Id });

            if (model.DocumentoId > 0)
                model.documentoArchivo = TranslatorDocumento.ConsultaDocumento(model.DocumentoId);

            Session["$EventoId"] = Id;
            CargaInicial(model.CodigoDepartamento, model.CodigoMunicipio);
            if (model.Imagen != null)
            {
                string imageBase64Data = Convert.ToBase64String(model.Imagen);
                string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                TempData["imagen"] = imageDataURL;
                ViewBag.ImageData = imageDataURL;
            }

            modelPadre.DatosBasicos = model;
            var modeltabla = new List<GrupoPublicoModels>();
            modeltabla = Translator.TranslatorEventos.ConsultarGruposPorEventoId(Id);
            modelPadre.listGrupos = modeltabla;
            return View(modelPadre);
        }

        [HttpPost]
        public ActionResult Editar(int Id, HttpPostedFileBase imagenPerfil, EventoDanzaModels model)
        {
            if (Session["$usuario"] == null)
                return RedirectToAction("Login", "Cuenta");

            string imageDataURL = "";
            var modelPadre = new EventoDanzaPadreModels();

            ViewBag.ImageData = "~/img/img_defaultDanza.png";
            DateTime FechaInicio = DateTime.Today;
            DateTime Fechafinal = DateTime.Today;

            CargaInicial(model.CodigoDepartamento, model.CodigoMunicipio);
            modelPadre.DatosBasicos = model;
            var modeltabla = new List<GrupoPublicoModels>();
            modeltabla = Translator.TranslatorEventos.ConsultarGruposPorEventoId(Id);
            modelPadre.listGrupos = modeltabla;

            if (ModelState.IsValid)
            {
                byte[] fileData = null;

                if (imagenPerfil != null && imagenPerfil.ContentLength > 0)
                {

                    using (var binaryReader = new BinaryReader(imagenPerfil.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(imagenPerfil.ContentLength);
                    }

                    string imageBase64Data = Convert.ToBase64String(fileData);
                    imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                    ViewBag.ImageData = imageDataURL;
                }
                else
                {
                    if (model.Imagen != null)
                    {
                        string imageBase64Data = Convert.ToBase64String(model.Imagen);
                        imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                    }
                    else
                    {
                        if (TempData["imagen"] != null)
                            imageDataURL = (string)TempData["imagen"];
                        else
                            imageDataURL = "~/img/img_defaultDanza.png";
                    }

                    TempData["imagen"] = imageDataURL;
                    ViewBag.ImageData = imageDataURL;
                }

                if (model.Nacional == 2)
                {
                    bool validate = false;
                    if (string.IsNullOrEmpty(model.CodigoDepartamento))
                        validate = true;
                    else
                    {
                        if (model.CodigoDepartamento.Trim() == "Seleccione un departamento")
                            validate = true;
                    }

                    if (string.IsNullOrEmpty(model.CodigoMunicipio))
                        validate = true;
                    else
                    {
                        if (model.CodigoMunicipio.Trim() == "Seleccione un municipio")
                            validate = true;
                    }

                    if (validate)
                    {
                        ModelState.AddModelError("", "El departamento y municipio es obligatorio sí el evento no es Nacional");
                        return View(modelPadre);
                    }
                }
                if (!string.IsNullOrEmpty(model.FechaEvento))
                    try
                    {
                        string[] hora = model.HoraEvento.Split(' ');
                        CultureInfo provider = CultureInfo.InvariantCulture;
                        string dateString = model.FechaEvento + " " + hora[0] + ":01 " + hora[1];
                        FechaInicio = Convert.ToDateTime(dateString);

                    }
                    catch (FormatException f)
                    { string mensaje = f.ToString(); }

                if (!string.IsNullOrEmpty(model.FechaEventoFinal))
                    try
                    {
                        string[] hora = model.HoraEventoFinal.Split(' ');
                        CultureInfo provider = CultureInfo.InvariantCulture;
                        string dateString = model.FechaEventoFinal + " " + hora[0] + ":01 " + hora[1];
                        Fechafinal = Convert.ToDateTime(dateString);
                    }
                    catch (FormatException f)
                    { string mensaje = f.ToString(); }

                if (Fechafinal < FechaInicio)
                {
                    ModelState.AddModelError("", "La fecha final no puede ser menor a la fecha inicial");
                    return View(modelPadre);
                }


                ActualizarEvento(Id, model, fileData, false, FechaInicio, Fechafinal);

                Session["$EventoId"] = Id;
                Success(string.Format("<b></b> Se actualizo con éxito el evento: {0}  ", model.Nombre), true);
                return View("Editar", modelPadre);
            }


            return View(modelPadre);
        }
        public ActionResult Evento()
        {
            if (Session["$usuario"] == null)
                return RedirectToAction("Login", "Cuenta");

            TempData["imagen"] = "~/img/img_defaultDanza.png";
            ViewBag.ImageData = "~/img/img_defaultDanza.png";
            var model = new EventoDanzaModels();
            model.Tipo = "Danza";
            CargaInicial("", "");
            return View(model);
        }

        [HttpPost]
        public ActionResult Evento(HttpPostedFileBase imagenPerfil, string CodigoDepartamento, EventoDanzaModels model)
        {
            if (Session["$usuario"] == null)
                return RedirectToAction("Login", "Cuenta");

            TempData["imagen"] = "~/img/img_defaultDanza.png";
            ViewBag.ImageData = "~/img/img_defaultDanza.png";
            model.Tipo = "Danza";
            DateTime FechaInicio = DateTime.Today;
            DateTime Fechafinal = DateTime.Today;
            if (model.Nacional == 2)
            {
                bool validate = false;
                if (string.IsNullOrEmpty(model.CodigoDepartamento))
                    validate = true;
                else
                {
                    if (model.CodigoDepartamento.Trim() == "Seleccione un departamento")
                        validate = true;
                }

                if (string.IsNullOrEmpty(model.CodigoMunicipio))
                    validate = true;
                else
                {
                    if (model.CodigoMunicipio.Trim() == "Seleccione un municipio")
                        validate = true;
                }

                if (validate)
                {
                    CargaInicial(model.CodigoDepartamento, model.CodigoMunicipio);
                    ModelState.AddModelError("", "El departamento y municipio es obligatorio sí el evento no es Nacional");
                    return View(model);
                }
            }

            if (ModelState.IsValid)
            {
                byte[] fileData = null;
                if (!string.IsNullOrEmpty(model.FechaEvento))
                    try
                    {
                        string[] hora = model.HoraEvento.Split(' ');
                        CultureInfo provider = CultureInfo.InvariantCulture;
                        string dateString = model.FechaEvento + " " + hora[0] + ":01 " + hora[1];
                        FechaInicio = Convert.ToDateTime(dateString);

                    }
                    catch (FormatException f)
                    { string mensaje = f.ToString(); }

                if (!string.IsNullOrEmpty(model.FechaEventoFinal))
                    try
                    {
                        string[] hora = model.HoraEventoFinal.Split(' ');
                        CultureInfo provider = CultureInfo.InvariantCulture;
                        string dateString = model.FechaEventoFinal + " " + hora[0] + ":01 " + hora[1];
                        Fechafinal = Convert.ToDateTime(dateString);
                    }
                    catch (FormatException f)
                    { string mensaje = f.ToString(); }

                if (Fechafinal < FechaInicio)
                {
                    CargaInicial(model.CodigoDepartamento, model.CodigoMunicipio);
                    ModelState.AddModelError("", "La fecha final no puede ser menor a la fecha inicial");
                    return View(model);
                }
                if (imagenPerfil != null && imagenPerfil.ContentLength > 0)
                {

                    using (var binaryReader = new BinaryReader(imagenPerfil.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(imagenPerfil.ContentLength);
                    }

                }
                int EventoId = GuardarEvento(model, fileData, FechaInicio, Fechafinal);
                return RedirectToAction("Editar", "EventoDanza", new { Id = EventoId });
            }

            CargaInicial(model.CodigoDepartamento, model.CodigoMunicipio);
            return View(model);
        }

        #region MetodosPrivados

        private void ActualizarEvento(int Id, EventoDanzaModels model, byte[] imagen, bool cambiar, DateTime FechaInicio, DateTime FechaFinal)
        {
            var evento = new EventoDTO();
            int DocumentoId = 0;
            fabricaMensajes = new SM.LibreriaRecursos.Recursos.FabricaManejador();
            manejadoMensajes = fabricaMensajes.getInstance();
            string codigoAreaArtistica = "";
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];

            if (model != null)
            {
                evento.Id = Id;
                evento.UsuarioId = usuario.Id;

                ///Creamos el documento 
                DocumentoId = CrearDocumento(usuario.Id, usuario.PrimerNombre + " " + usuario.PrimerApellido, model.ArchivoAgenda);

                if (!string.IsNullOrEmpty(model.CodigoDepartamento))
                {
                    if (model.CodigoDepartamento.Trim() == "Seleccione un departamento")
                        evento.CodDepartamento = "";
                    else
                        evento.CodDepartamento = model.CodigoDepartamento;
                }
                else
                    evento.CodDepartamento = "";
                if (!string.IsNullOrEmpty(model.CodigoMunicipio))
                {
                    if (model.CodigoMunicipio.Trim() == "Seleccione un municipio")
                        evento.CodMunicipio = "";
                    else
                        evento.CodMunicipio = model.CodigoMunicipio;
                }
                else
                    evento.CodMunicipio = "";

                if (!string.IsNullOrEmpty(model.Tipo))
                {
                    evento.Tipo = model.Tipo;
                    string strArea = manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.SIMUS_Musica);
                    if (model.Tipo == strArea)
                    {
                        codigoAreaArtistica = manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.SIMUS_Codigo_Musica);
                        evento.AreaArtisticaId = Convert.ToDecimal(codigoAreaArtistica);
                    }
                    else if (model.Tipo == manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.SIMUS_Danza))
                    {
                        codigoAreaArtistica = manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.SIMUS_Codigo_Danza);
                        evento.AreaArtisticaId = Convert.ToDecimal(codigoAreaArtistica);
                    }
                }

                if (!string.IsNullOrEmpty(model.Nombre))
                    evento.Nombre = model.Nombre;
                if (!string.IsNullOrEmpty(model.EntidadOrganizadora))
                    evento.EntidadOrganizadora = model.EntidadOrganizadora;

                if (!string.IsNullOrEmpty(model.Telefono))
                    evento.Telefono = model.Telefono;

                if (!string.IsNullOrEmpty(model.Email))
                    evento.Email = model.Email;

                if (!string.IsNullOrEmpty(model.LugarEvento))
                    evento.LugarEvento = model.LugarEvento;

                if (!string.IsNullOrEmpty(model.Descripcion))
                    evento.Descripción = model.Descripcion;

                evento.FechaEvento = FechaInicio;
                evento.FechaEventoFinal = FechaFinal;

                evento.DocumentoId = DocumentoId;
                if (model.Nacional == 1)
                    evento.EsNacional = true;
                else
                    evento.EsNacional = false;

                if (imagen != null)
                    evento.Imagen = imagen;
                else
                    evento.Imagen = null;


                if (cambiar)
                {
                    if (!string.IsNullOrEmpty(model.EstadoId))
                        evento.EstadoId = Convert.ToInt32(model.EstadoId);
                    else
                        evento.EstadoId = 0;

                    evento.Destacado = model.EsDestacado;
                }


                EventosNeg.ActualizarEventoDanza(evento, cambiar);
            }

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
        private int GuardarEvento(EventoDanzaModels model, byte[] imagen, DateTime FechaInicio, DateTime FechaFinal)
        {
            var nuevoRegistro = new EventoDTO();
            fabricaMensajes = new SM.LibreriaRecursos.Recursos.FabricaManejador();
            manejadoMensajes = fabricaMensajes.getInstance();
            int EventoId = 0;
            int DocumentoId = 0;
            string codigoAreaArtistica = "";
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];

            if (model != null)
            {
                nuevoRegistro.Id = 0;
                nuevoRegistro.UsuarioId = usuario.Id;
                ///Creamos el documento 
                DocumentoId = CrearDocumento(usuario.Id, usuario.PrimerNombre + " " + usuario.PrimerApellido, model.ArchivoAgenda);

                if (!string.IsNullOrEmpty(model.CodigoDepartamento))
                {
                    if (model.CodigoDepartamento.Trim() == "Seleccione un departamento")
                        nuevoRegistro.CodDepartamento = "";
                    else
                        nuevoRegistro.CodDepartamento = model.CodigoDepartamento;
                }
                else
                    nuevoRegistro.CodDepartamento = "";
                if (!string.IsNullOrEmpty(model.CodigoMunicipio))
                {
                    if (model.CodigoMunicipio.Trim() == "Seleccione un municipio")
                        nuevoRegistro.CodMunicipio = "";
                    else
                        nuevoRegistro.CodMunicipio = model.CodigoMunicipio;
                }
                else
                    nuevoRegistro.CodMunicipio = "";

                //Exclusixamente paraDanza
                string strArea = manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.SIMUS_Danza);
                nuevoRegistro.Tipo = strArea;
                codigoAreaArtistica = manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.SIMUS_Codigo_Danza);
                nuevoRegistro.AreaArtisticaId = Convert.ToDecimal(codigoAreaArtistica);


                if (!string.IsNullOrEmpty(model.Nombre))
                    nuevoRegistro.Nombre = model.Nombre;
                if (!string.IsNullOrEmpty(model.EntidadOrganizadora))
                    nuevoRegistro.EntidadOrganizadora = model.EntidadOrganizadora;

                if (!string.IsNullOrEmpty(model.LugarEvento))
                    nuevoRegistro.LugarEvento = model.LugarEvento;

                if (!string.IsNullOrEmpty(model.Descripcion))
                    nuevoRegistro.Descripción = model.Descripcion;

                if (!string.IsNullOrEmpty(model.Telefono))
                    nuevoRegistro.Telefono = model.Telefono;

                if (!string.IsNullOrEmpty(model.Email))
                    nuevoRegistro.Email = model.Email;

                nuevoRegistro.FechaEvento = FechaInicio;
                nuevoRegistro.FechaEventoFinal = FechaFinal;

                if (imagen != null)
                    nuevoRegistro.Imagen = imagen;
                else
                    nuevoRegistro.Imagen = null;

                nuevoRegistro.DocumentoId = DocumentoId;
                if (model.Nacional == 1)
                    nuevoRegistro.EsNacional = true;
                else
                    nuevoRegistro.EsNacional = false;

                EventoId = EventosNeg.CrearEventoDanza(nuevoRegistro);

            }

            return EventoId;

        }
        private void CargaInicial(string codigoDepartamento, string codigoMunicipio)
        {
            var objMunicipios = new List<BasicaDTO>();
            var objDepartamentos = new List<BasicaDTO>();

            objDepartamentos = ZonaGeograficasLogica.ConsultarDepartamentos();
            if (!string.IsNullOrEmpty(codigoDepartamento))
            {
                objMunicipios = ZonaGeograficasLogica.ConsultarMunicipios(codigoDepartamento);
            }
            ViewBag.listDepartamentos = new SelectList(objDepartamentos, "value", "text");
            ViewBag.listMunicipio = new SelectList(objMunicipios, "value", "text");
            ViewBag.listTipo = new SelectList(listAreasArtisticas, "value", "text");

        }
        #endregion
        #region Grilla


        // [Authorize]
        public ActionResult ExportTo(string OutputFormat)
        {
            var model = new List<EventoDataModels>();
            model = ObtenerMisregistros("", "0");


            return GridViewExtension.ExportToXls(GetGridSettings(), model.ToList());
        }

        public ActionResult ExportToPermisos(string OutputFormat)
        {
            var model = new List<EventoDataModels>();
            string strTipo = "Danza";
            ViewBag.GridSettings = GetGridSettingsPermisos();
            bool EsAdmin = false;
 
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
                model = TranslatorEventos.ConsultarEventosTodosPorTipo(strTipo, DateTime.Today.Year);
            else
            {

                model = TranslatorEventos.ConsultarEventoPorMunicipio(Convert.ToInt32(UsuaroId), strTipo);
            }


            return GridViewExtension.ExportToXls(GetGridSettingsPermisos(), model.ToList());
        }
        // Returns the settings of the exported GridView. 
        private GridViewSettings GetGridSettings()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridEvento";
            settings.CallbackRouteValues = new { Controller = "EventoDanza", Action = "GridViewPartial" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "Evento" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "EventoId";
            settings.Columns.Add("Nombre");
            settings.Columns.Add("EntidadOrganizadora");
            settings.Columns.Add("LugarEvento");
            settings.Columns.Add("FechaEvento");
            settings.Columns.Add("NombreDepartamento");
            settings.Columns.Add("NombreMunicipio");
            settings.Columns.Add("Estado");
            settings.Columns.Add("Tipo");
            return settings;
        }

        private GridViewSettings GetGridSettingsPermisos()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridEventoPermisos";
            settings.CallbackRouteValues = new { Controller = "EventoDanza", Action = "GridViewPartialPermisos" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "Evento" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "EventoId";
            settings.Columns.Add("Nombre");
            settings.Columns.Add("EntidadOrganizadora");
            settings.Columns.Add("LugarEvento");
            settings.Columns.Add("FechaEvento");
            settings.Columns.Add("NombreDepartamento");
            settings.Columns.Add("NombreMunicipio");
            settings.Columns.Add("Estado");
            settings.Columns.Add("Tipo");
            return settings;
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial(string Busqueda = null, string filtro = null)
        {
    
            ViewBag.GridSettings = GetGridSettings();
           var model = new List<EventoDataModels>();
           model = ObtenerMisregistros(Busqueda, filtro);


            return PartialView("_GridViewPartial", model);
        }

        private List<EventoDataModels> ObtenerMisregistros(string Busqueda = null, string filtro = null)
        {
            var model = new List<EventoDataModels>();
            string strTipo = "Danza";
            if (string.IsNullOrEmpty(Busqueda))
            {
                if (TempData["TipoRegistroE"] != null)
                    Busqueda = TempData["TipoRegistroE"].ToString();
                else
                    Busqueda = "1";
            }

            if ((Busqueda == "1") && (filtro == "0"))
                model = TranslatorEventos.ConsultarEventosPorUsuarioId(Convert.ToInt32(UsuaroId), strTipo);
            else if (string.IsNullOrEmpty(Busqueda) && (filtro == "0"))
                model = TranslatorEventos.ConsultarEventosPorUsuarioId(Convert.ToInt32(UsuaroId), strTipo);
            else if ((Busqueda == "2") && (filtro == "0"))
                model = TranslatorEventos.ConsultarEventoPorEstadoId(Comunes.ConstantesRecursosBD.CODIGO_ESTADO_PUBLICADO, strTipo);
            else if ((Busqueda == "3") && (filtro == "0"))
                model = TranslatorEventos.ConsultarEventosTodos();

            return model;
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartialPermisos()
        {
            string strTipo = "Danza";
            ViewBag.GridSettings = GetGridSettingsPermisos();
             var model = new List<EventoDataModels>();

                model = TranslatorEventos.ConsultarEventosTodosPorTipo(strTipo, DateTime.Today.Year );
          



            return PartialView("_GridViewPartialPermisos", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] WebSImus.Models.AgentePublicoModels item)
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
        public ActionResult GridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] WebSImus.Models.AgentePublicoModels item)
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
        public ActionResult GridViewPartialDelete(int Id)
        {
            var model = new List<EntidadDatosModels>();

            try
            {
                //EntidadNeg.EliminarEntidad(Id);
                //model = TranslatorEntidades.ConsultarEntidadTodos();
                //Session["#Ag3nt3s"] = model;
            }
            catch (Exception e)
            {
                ViewData["EditError"] = e.Message;
            }

            return PartialView("_GridViewPartial", model);
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


            var model = new HandleErrorInfo(filterContext.Exception, "EventoController", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }
        #endregion
    }
}