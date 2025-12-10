using DevExpress.Web.Mvc;
using SM.Aplicacion.Basicas;
using SM.Aplicacion.Escuelas;
using SM.Aplicacion.Eventos;
using SM.Aplicacion.Modulo_Usuarios;
using SM.Aplicacion.Usuarios;
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
    public class EventoController : BaseController
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
            Session["$EventoPermisos"] = null;
            Session["$Evento"] = null;
            string strTipo = "Música";
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


        public ActionResult Eliminar(int Id)
        {
            EventosNeg.EliminarEvento(Id, Convert.ToInt32(UsuaroId), NombreCompletoUsuario, Request.UserHostAddress);

            return RedirectToAction("Consulta");


        }

        public ActionResult Duplicar(int Id)
        {
            fabricaMensajes = new SM.LibreriaRecursos.Recursos.FabricaManejador();
            manejadoMensajes = fabricaMensajes.getInstance();
            string FechaEvento = manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.Celebra_Fecha_Evento);
            DateTime datFechaEvento = Convert.ToDateTime(FechaEvento);
            int EventoId = EventosNeg.DuplicarEvento(Id, Convert.ToInt32(UsuaroId), datFechaEvento, NombreCompletoUsuario, Request.UserHostAddress);

            return RedirectToAction("CambiarEstado", "Evento", new { Id = EventoId, mensaje = "D" });
        }

        private void AlertasMensajes()
        {

            Success(string.Format("<b>{0}</b> El registro se duplico con éxito", " "), true);

        }
        public ActionResult Consulta()
        {
            var objAnos = new List<BasicaDTO>();
            objAnos = BasicaLogica.ConsultarListadoAnosMusica();
            ViewBag.listAnos = new SelectList(objAnos, "value", "text");
            var model = new ConsultaModel();
            model.selectorAno = DateTime.Today.Year.ToString();

            return View(model);
        }

        public ActionResult MunicipiosFaltantes()
        {

            return View();
        }

        public ActionResult Detalle(int Id)
        {
            TempData["imagen"] = "~/img/defaultUser.jpg";
            ViewBag.ImageData = "~/img/defaultUser.jpg";
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


            if (string.IsNullOrEmpty(nombre))
                return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(contacto))
                return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(telefono))
                return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(orden))
                return Json(new { Response = "Error" });


            if (string.IsNullOrEmpty(cantidad))
                return Json(new { Response = "Error" });


            if (orden == "0")
                return Json(new { Response = "Error" });

            if (cantidad == "0")
                return Json(new { Response = "Error" });

            var datos = new GrupoDTO();
            datos.EventoId = Convert.ToInt32(eventoId);
            datos.Orden = Convert.ToInt32(orden);
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

        public ActionResult ArtistaEditar(int Id)
        {
            if (Session["$usuario"] == null)
                return RedirectToAction("Login", "Cuenta");

            TempData["imagen"] = "~/img/defaultUser.jpg";
            ViewBag.ImageData = "~/img/defaultUser.jpg";
            CargaInicialArtista();
            var model = new ArtistaModels();

            model = TranslatorEventos.ConsultaArtistaPorId(Id);
            if (model.imagen != null)
            {
                string imageBase64Data = Convert.ToBase64String(model.imagen);
                string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                TempData["imagen"] = imageDataURL;
                ViewBag.ImageData = imageDataURL;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult ArtistaEditar(int Id, HttpPostedFileBase imagenPerfil, ArtistaModels model)
        {
            if (Session["$usuario"] == null)
                return RedirectToAction("Login", "Cuenta");


            fabricaMensajes = new SM.LibreriaRecursos.Recursos.FabricaManejador();
            manejadoMensajes = fabricaMensajes.getInstance();
            CargaInicialArtista();
            string imageDataURL = "";
            ViewBag.ImageData = "~/img/defaultUser.jpg";
            if (ModelState.IsValid)
            {
                // Escuela municipal de música 2
                if (model.ProcesoId == "2")
                {
                    string codMunicipio = ArtistasNeg.ConsultarMunicipio(model.EventoId);
                    bool validate = EscuelasLogica.ExisteEscuela(codMunicipio);
                    if (!validate)
                    {
                        String mensaje = manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.SIMUS_Mensaje_Escuela);
                        ModelState.AddModelError("", mensaje);
                        return View(model);
                    }
                }

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
                    if (model.imagen != null)
                    {
                        string imageBase64Data = Convert.ToBase64String(model.imagen);
                        imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
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

                ActualizarArtista(Id, model, fileData);
                return RedirectToAction("CambiarEstado", "Evento", new { Id = model.EventoId });
            }


            return View(model);
        }
        public ActionResult Artista(int Id)
        {
            if (Session["$usuario"] == null)
                return RedirectToAction("Login", "Cuenta");

            TempData["imagen"] = "~/img/defaultUser.jpg";
            ViewBag.ImageData = "~/img/defaultUser.jpg";
            var model = new ArtistaModels();
            model = TranslatorEventos.ConsultarArtistaPorEventoId(Id);
            model.EventoId = Id;
            CargaInicialArtista();
            return View(model);
        }

        [HttpPost]
        public ActionResult Artista(int Id, HttpPostedFileBase imagenPerfil, ArtistaModels model)
        {
            if (Session["$usuario"] == null)
                return RedirectToAction("Login", "Cuenta");


            fabricaMensajes = new SM.LibreriaRecursos.Recursos.FabricaManejador();
            manejadoMensajes = fabricaMensajes.getInstance();

            TempData["imagen"] = "~/img/defaultUser.jpg";
            ViewBag.ImageData = "~/img/defaultUser.jpg";
            CargaInicialArtista();
            if (ModelState.IsValid)
            {
                // Escuela municipal de música 2
                if (model.ProcesoId == "2")
                {
                    string codMunicipio = ArtistasNeg.ConsultarMunicipio(model.EventoId);
                    bool validate = EscuelasLogica.ExisteEscuela(codMunicipio);
                    if (!validate)
                    {
                        String mensaje = manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.SIMUS_Mensaje_Escuela);
                        ModelState.AddModelError("", mensaje);
                        return View(model);
                    }
                }

                byte[] fileData = null;
                if (imagenPerfil != null && imagenPerfil.ContentLength > 0)
                {

                    using (var binaryReader = new BinaryReader(imagenPerfil.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(imagenPerfil.ContentLength);
                    }

                }

                int ArtistaId = GuardarArtista(model, fileData);
                return RedirectToAction("CambiarEstado", "Evento", new { Id = model.EventoId });
            }


            return View(model);
        }

        public ActionResult _TablaGrupo(int Id, int Eliminar)
        {
            if (Session["$usuario"] == null)
                return RedirectToAction("LoginMusica", "Cuenta");

            var modeltabla = new List<ArtistaPublicoModels>();

            if (Eliminar > 0)
            {
                ArtistasNeg.EliminarArtista(Eliminar);

            }

            modeltabla = Translator.TranslatorEventos.ConsultaArtistasPorEventoId(Id);
            return PartialView("_TablaGrupos", modeltabla);
        }

        public ActionResult CambiarEstado(int Id, string mensaje = "")
        {
           
            TempData["imagen"] = "~/img/defaultUser.jpg";
            ViewBag.ImageData = "~/img/defaultUser.jpg";

            if (mensaje == "D")
                AlertasMensajes();

            var modelPadre = new EventoPadreModels();

            var model = new EventoModels();
            model = TranslatorEventos.ConsultaEventoPorId(Id);

         
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
            var modeltabla = new List<ArtistaPublicoModels>();
            modeltabla = Translator.TranslatorEventos.ConsultaArtistasPorEventoId(Id);
            modelPadre.listArtista = modeltabla;
            return View(modelPadre);
        }

        [HttpPost]
        public ActionResult CambiarEstado(int Id, HttpPostedFileBase imagenPerfil, string guardar, EventoModels model)
        {
            if (Session["$usuario"] == null)
                return RedirectToAction("Login", "Cuenta");

            string imageDataURL = "";
            var modelPadre = new EventoPadreModels();
            modelPadre.DatosBasicos = model;
            ViewBag.ImageData = "~/img/defaultUser.jpg";
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
                            imageDataURL = "~/img/defaultUser.jpg";
                    }

                    TempData["imagen"] = imageDataURL;
                    ViewBag.ImageData = imageDataURL;
                }

                ActualizarEvento(Id, model, fileData, true);
                var modeltabla = new List<ArtistaPublicoModels>();
                modeltabla = Translator.TranslatorEventos.ConsultaArtistasPorEventoId(Id);
                modelPadre.listArtista = modeltabla;
                Session["$EventoId"] = Id;
                CargaInicial(model.CodigoDepartamento, model.CodigoMunicipio);
                List<BasicaDTO> objTipo = CaracterizacionMusicalNeg.ConsultarEstados();
                ViewBag.listEstado = new SelectList(objTipo, "value", "text");
                Success(string.Format("<b></b> Se actualizo con éxito el evento: {0}  ", model.Nombre), true);
                return View("CambiarEstado", modelPadre);
            }


            CargaInicial(model.CodigoDepartamento, model.CodigoMunicipio);
            return View(model);
        }
        public ActionResult Editar(int Id, string mensaje = "")
        {
            TempData["imagen"] = "~/img/defaultUser.jpg";
            ViewBag.ImageData = "~/img/defaultUser.jpg";
            var modelPadre = new EventoPadreModels();

            var model = new EventoModels();
            model = TranslatorEventos.ConsultaEventoPorId(Id);
            if (model.ArtMusicaUsuarioId != Convert.ToInt32(UsuaroId))
                return RedirectToAction("Detalle", "Evento", new { Id = Id });

            if (mensaje == "D")
                AlertasMensajes();

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
        public ActionResult Editar(int Id, HttpPostedFileBase imagenPerfil, string guardar, EventoModels model)
        {
            string imageDataURL = "";
            var modelPadre = new EventoPadreModels();
            modelPadre.DatosBasicos = model;
            ViewBag.ImageData = "~/img/defaultUser.jpg";
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
                            imageDataURL = "~/img/defaultUser.jpg";
                    }

                    TempData["imagen"] = imageDataURL;
                    ViewBag.ImageData = imageDataURL;
                }

                ActualizarEvento(Id, model, fileData, false);
                var modeltabla = new List<GrupoPublicoModels>();
                modeltabla = Translator.TranslatorEventos.ConsultarGruposPorEventoId(Id);
                modelPadre.listGrupos = modeltabla;
                Session["$EventoId"] = Id;
                CargaInicial(model.CodigoDepartamento, model.CodigoMunicipio);
                Success(string.Format("<b></b> Se actualizo con éxito el evento: {0}  ", model.Nombre), true);
                return View("Editar", modelPadre);
            }


            CargaInicial(model.CodigoDepartamento, model.CodigoMunicipio);
            return View(model);
        }
        public ActionResult Evento()
        {
            fabricaMensajes = new SM.LibreriaRecursos.Recursos.FabricaManejador();
            manejadoMensajes = fabricaMensajes.getInstance();
            TempData["imagen"] = "~/img/defaultUser.jpg";
            ViewBag.ImageData = "~/img/defaultUser.jpg";
            var model = new EventoModels();
            model.Nombre = "Celebra la Música";

            model.FechaEvento = manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.Celebra_Fecha_Evento);
            model.HoraEvento = "";
            model.Tipo = "Música";
            CargaInicial("", "");
            return View(model);
        }

        [HttpPost]
        public ActionResult Evento(HttpPostedFileBase imagenPerfil, string CodigoDepartamento, EventoModels model)
        {
            if (Session["$usuario"] == null)
                return RedirectToAction("Login", "Cuenta");

            TempData["imagen"] = "~/img/defaultUser.jpg";
            ViewBag.ImageData = "~/img/defaultUser.jpg";
            model.Tipo = "Música";

            if (ModelState.IsValid)
            {
                byte[] fileData = null;
                if (imagenPerfil != null && imagenPerfil.ContentLength > 0)
                {

                    using (var binaryReader = new BinaryReader(imagenPerfil.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(imagenPerfil.ContentLength);
                    }

                }
                int EventoId = GuardarEvento(model, fileData);
                return RedirectToAction("CambiarEstado", "Evento", new { Id = EventoId });
            }

            CargaInicial(model.CodigoDepartamento, model.CodigoMunicipio);
            return View(model);
        }

        #region MetodosPrivados

        private int GuardarArtista(ArtistaModels model, byte[] imagen)
        {
            var nuevoRegistro = new ArtistaDTO();
            fabricaMensajes = new SM.LibreriaRecursos.Recursos.FabricaManejador();
            manejadoMensajes = fabricaMensajes.getInstance();
            int artistaId = 0;
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];

            if (model != null)
            {
                nuevoRegistro.Id = 0;
                nuevoRegistro.UsuarioId = usuario.Id;

                if (!string.IsNullOrEmpty(model.Nombre))
                    nuevoRegistro.Nombre = model.Nombre;
                if (!string.IsNullOrEmpty(model.Contacto))
                    nuevoRegistro.Contacto = model.Contacto;

                if (!string.IsNullOrEmpty(model.Enlace))
                    nuevoRegistro.Enlace = model.Enlace;

                if (!string.IsNullOrEmpty(model.Resena))
                    nuevoRegistro.Resena = model.Resena;

                if (!string.IsNullOrEmpty(model.Telefono))
                    nuevoRegistro.Telefono = model.Telefono;

                if (!string.IsNullOrEmpty(model.Email))
                    nuevoRegistro.Email = model.Email;

                if (!string.IsNullOrEmpty(model.Orden))
                    nuevoRegistro.Orden = Convert.ToInt32(model.Orden);
                if (!string.IsNullOrEmpty(model.CantidadMiembros))
                    nuevoRegistro.CantidadMiembros = Convert.ToInt32(model.CantidadMiembros);

                if (model.EsGrupo == 1)
                    nuevoRegistro.EsGrupo = true;
                else
                {
                    nuevoRegistro.EsGrupo = false;
                    nuevoRegistro.CantidadMiembros = 1;
                }

                nuevoRegistro.EventoId = model.EventoId;
                if (!string.IsNullOrEmpty(model.CategoriaId))
                    nuevoRegistro.CategoriaId = Convert.ToInt32(model.CategoriaId);
                if (!string.IsNullOrEmpty(model.ProcesoId))
                    nuevoRegistro.ProcesoId = Convert.ToInt32(model.ProcesoId);
                if (imagen != null)
                    nuevoRegistro.Imagen = imagen;
                else
                    nuevoRegistro.Imagen = null;

                artistaId = ArtistasNeg.CrearArtista(nuevoRegistro);

            }

            return artistaId;

        }

        private void ActualizarArtista(int Id, ArtistaModels model, byte[] imagen)
        {
            var registro = new ArtistaDTO();
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];

            if (model != null)
            {
                registro.Id = Id;
                registro.UsuarioId = usuario.Id;

                if (!string.IsNullOrEmpty(model.Nombre))
                    registro.Nombre = model.Nombre;
                if (!string.IsNullOrEmpty(model.CantidadMiembros))
                    registro.CantidadMiembros = Convert.ToInt32(model.CantidadMiembros);

                if (!string.IsNullOrEmpty(model.Orden))
                    registro.Orden = Convert.ToInt32(model.Orden);

                if (!string.IsNullOrEmpty(model.ProcesoId))
                    registro.ProcesoId = Convert.ToInt32(model.ProcesoId);

                if (!string.IsNullOrEmpty(model.CategoriaId))
                    registro.CategoriaId = Convert.ToInt32(model.CategoriaId);

                if (!string.IsNullOrEmpty(model.Contacto))
                    registro.Contacto = model.Contacto;

                if (!string.IsNullOrEmpty(model.Email))
                    registro.Email = model.Email;

                if (!string.IsNullOrEmpty(model.Telefono))
                    registro.Telefono = model.Telefono;

                if (!string.IsNullOrEmpty(model.Enlace))
                    registro.Enlace = model.Enlace;

                if (!string.IsNullOrEmpty(model.Resena))
                    registro.Resena = model.Resena;

                if (imagen != null)
                    registro.Imagen = imagen;
                else
                    registro.Imagen = null;

                if (model.EsGrupo == 1)
                    registro.EsGrupo = true;
                else
                {
                    registro.EsGrupo = false;
                    registro.CantidadMiembros = 1;

                }

                ArtistasNeg.ActualizarArtista(registro);
            }

        }
        private void CargaInicialArtista()
        {
            List<BasicaDTO> objTipo = CaracterizacionMusicalNeg.ConsultarCategoriaCelebra();
            ViewBag.listCategoria = new SelectList(objTipo, "value", "text");
            List<BasicaDTO> objProceso = CaracterizacionMusicalNeg.ConsultarProcesoFormacionCelebra();
            ViewBag.listProceso = new SelectList(objProceso, "value", "text");
        }
        private void ActualizarEvento(int Id, EventoModels model, byte[] imagen, bool cambiar)
        {
            var evento = new EventoDTO();
            fabricaMensajes = new SM.LibreriaRecursos.Recursos.FabricaManejador();
            manejadoMensajes = fabricaMensajes.getInstance();
            string codigoAreaArtistica = "";
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];

            if (model != null)
            {
                evento.Id = Id;
                evento.UsuarioId = usuario.Id;
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

                if (!string.IsNullOrEmpty(model.LugarEvento))
                    evento.LugarEvento = model.LugarEvento;

                if (!string.IsNullOrEmpty(model.Descripcion))
                    evento.Descripción = model.Descripcion;

                if (!string.IsNullOrEmpty(model.Telefono))
                    evento.Telefono = model.Telefono;

                if (!string.IsNullOrEmpty(model.Email))
                    evento.Email = model.Email;

                if (!string.IsNullOrEmpty(model.FechaEvento))
                    try
                    {

                        string[] hora = model.HoraEvento.Split(' ');
                        CultureInfo provider = CultureInfo.InvariantCulture;
                        string dateString = model.FechaEvento + " " + hora[0] + ":01 " + hora[1];
                        DateTime dt = Convert.ToDateTime(dateString);
                        evento.FechaEvento = dt;

                    }
                    catch (FormatException f)
                    {
                        string mensaje = f.ToString();
                    }


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

                EventosNeg.ActualizarEvento(evento, cambiar);
            }

        }
        private int GuardarEvento(EventoModels model, byte[] imagen)
        {
            var nuevoRegistro = new EventoDTO();
            fabricaMensajes = new SM.LibreriaRecursos.Recursos.FabricaManejador();
            manejadoMensajes = fabricaMensajes.getInstance();
            int EventoId = 0;
            string codigoAreaArtistica = "";
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];

            if (model != null)
            {
                nuevoRegistro.Id = 0;
                nuevoRegistro.UsuarioId = usuario.Id;
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

                //Exclusixamente para música
                string strArea = manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.SIMUS_Musica);
                nuevoRegistro.Tipo = strArea;
                codigoAreaArtistica = manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.SIMUS_Codigo_Musica);
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

                if (!string.IsNullOrEmpty(model.FechaEvento))
                    try
                    {

                        string[] hora = model.HoraEvento.Split(' ');
                        CultureInfo provider = CultureInfo.InvariantCulture;
                        string dateString = model.FechaEvento + " " + hora[0] + ":01 " + hora[1];
                        DateTime dt = Convert.ToDateTime(dateString);
                        nuevoRegistro.FechaEvento = dt;

                    }
                    catch (FormatException f)
                    {
                        string mensaje = f.ToString();
                    }


                if (imagen != null)
                    nuevoRegistro.Imagen = imagen;
                else
                    nuevoRegistro.Imagen = null;


                EventoId = EventosNeg.CrearEvento(nuevoRegistro);

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

        public ActionResult Solicitudes()
        {
            var model = new ConsultaModel();
            model.TipoRegistro = 1;

            return View(model);
        }
        #endregion
        #region Grilla


        // [Authorize]
        public ActionResult ExportTo(string OutputFormat)
        {
            var model = new List<EventoDataModels>();
            model = (List<EventoDataModels>)Session["$Evento"];

            return GridViewExtension.ExportToXls(GetGridSettings(), model.ToList());
        }

        public ActionResult ExportToMunicipios(string OutputFormat)
        {
            fabricaMensajes = new SM.LibreriaRecursos.Recursos.FabricaManejador();
            manejadoMensajes = fabricaMensajes.getInstance();
            string strAnoEvento = manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.Celebra_Ano_Evento);
            var model = new List<SM.LibreriaComun.DTO.MunicipiosParticipantesDataDTO>();

            model = EventosNeg.ConsultarMunicipiosFaltantes(Convert.ToInt32(strAnoEvento));

            return GridViewExtension.ExportToXls(GetGridSettingsMunicipios(), model.ToList());
        }

        public ActionResult ExportToPermisos(string OutputFormat, string Busqueda = null)
        {
            if (string.IsNullOrEmpty(Busqueda))
            {
                if (TempData["#AnoEvento"] != null)
                {
                    Busqueda = (string)TempData["#AnoEvento"];
                }
                else
                    Busqueda = "2017";

                TempData["#AnoEvento"] = Busqueda;
            }
            else
                TempData["#AnoEvento"] = Busqueda;

            var model = new List<EventoDataModels>();
            model = TranslatorEventos.ConsultarEventosTodosPorTipo("Música", Convert.ToInt32(Busqueda));

            return GridViewExtension.ExportToXls(GetGridSettingsPermisos(), model.ToList());
        }
        // Returns the settings of the exported GridView. 
        private GridViewSettings GetGridSettings()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridEvento";
            settings.CallbackRouteValues = new { Controller = "Evento", Action = "GridViewPartial" };
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
            settings.CallbackRouteValues = new { Controller = "Evento", Action = "GridViewPartialPermisos" };
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
            settings.Columns.Add("FechaCreacion");
            settings.Columns.Add("FechaActualizacion");
            settings.Columns.Add("NombreDepartamento");
            settings.Columns.Add("NombreMunicipio");
            settings.Columns.Add("Estado");
            settings.Columns.Add("Email");
            settings.Columns.Add("TieneImagen");
            settings.Columns.Add("TieneArtistas");
            settings.Columns.Add("Usuario");
            return settings;
        }

        private GridViewSettings GetGridSettingsMunicipios()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridMunicipios";
            settings.CallbackRouteValues = new { Controller = "Evento", Action = "GridViewPartialMunicipios" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "MunicipiosFaltantes" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.Columns.Add("CodDepartamento");
            settings.Columns.Add("NombreDepartamento");
            settings.Columns.Add("CodMunicipio");
            settings.Columns.Add("NombreMunicipio");

            return settings;
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial(string Busqueda = null, string filtro = null)
        {
            string strTipo = "Música";
            ViewBag.GridSettings = GetGridSettings();
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];
            var model = new List<EventoDataModels>();
            if ((Busqueda == "1") && (filtro == "0"))
                Session["$Evento"] = TranslatorEventos.ConsultarEventosPorUsuarioId(usuario.Id, strTipo);
            else if (string.IsNullOrEmpty(Busqueda) && (filtro == "0"))
                Session["$Evento"] = TranslatorEventos.ConsultarEventosPorUsuarioId(usuario.Id, strTipo);
            else if ((Busqueda == "2") && (filtro == "0"))
                Session["$Evento"] = TranslatorEventos.ConsultarEventoPorEstadoId(Comunes.ConstantesRecursosBD.CODIGO_ESTADO_PUBLICADO, strTipo);
            else if ((Busqueda == "3") && (filtro == "0"))
                Session["$Evento"] = TranslatorEventos.ConsultarEventosTodos();

            model = (List<EventoDataModels>)Session["$Evento"];

            return PartialView("_GridViewPartial", model);
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartialPermisos(string Busqueda)
        {

            if (string.IsNullOrEmpty(Busqueda))
            {
                if (TempData["#AnoEvento"] != null)
                {
                    Busqueda = (string)TempData["#AnoEvento"];
                }
                else
                    Busqueda = "2018";

                TempData["#AnoEvento"] = Busqueda;
            }
            else
                TempData["#AnoEvento"] = Busqueda;

            ViewBag.GridSettings = GetGridSettingsPermisos();
            var model = new List<EventoDataModels>();

            model = TranslatorEventos.ConsultarEventosTodosPorTipo("Música", Convert.ToInt32(Busqueda));

            return PartialView("_GridViewPartialPermisos", model);
        }


        public ActionResult GridViewPartialMunicipios()
        {
            fabricaMensajes = new SM.LibreriaRecursos.Recursos.FabricaManejador();
            manejadoMensajes = fabricaMensajes.getInstance();
            ViewBag.GridSettings = GetGridSettingsMunicipios();
            string strAnoEvento = manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.Celebra_Ano_Evento);
            var model = new List<SM.LibreriaComun.DTO.MunicipiosParticipantesDataDTO>();

            model = EventosNeg.ConsultarMunicipiosFaltantes(Convert.ToInt32(strAnoEvento));

            return PartialView("_GridViewPartialMunicipios", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewSolicitudAprobar(int Id)
        {
            List<SolicitudUsuarioDTO> model = null;

            try
            {
                AsignacionUsuariosNeg.ActualizarSolicitudUsuarioEvento(Id, Convert.ToInt32(UsuaroId));
                model = AsignacionUsuariosNeg.ConsultarEventosUsuariosPorEstado(Comunes.ConstantesRecursosBD.CODIGO_ESTADO_PENDIENTE);
            }
            catch (Exception e)
            {
                ViewData["EditError"] = e.Message;
            }
            return PartialView("_GridViewSolicitud", model);
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
                model = AsignacionUsuariosNeg.ConsultarEventosUsuariosPorEstado(Comunes.ConstantesRecursosBD.CODIGO_ESTADO_PENDIENTE);
                TempData["TipoRegistroE"] = 1;
            }
            else if (Busqueda == "2")
            {
                TempData["TipoRegistroE"] = 2;
                model = AsignacionUsuariosNeg.ConsultarEventosUsuariosPorEstado(Comunes.ConstantesRecursosBD.CODIGO_ESTADO_PUBLICADO);
            }


            return model;
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