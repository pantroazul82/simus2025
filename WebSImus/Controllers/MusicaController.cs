using DevExpress.Web.Mvc;
using SM.Aplicacion.Basicas;
using SM.Aplicacion.Escuelas;
using SM.Aplicacion.Eventos;
using SM.Aplicacion.Estimulos;
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
using PagedList;
using SM.Aplicacion.Usuarios;

namespace WebSImus.Controllers
{

    [HandleError()]
    //[SessionExpire]
    public class MusicaController : BaseController
    {
        SM.LibreriaRecursos.Recursos.FabricaManejador fabricaMensajes;
        SM.LibreriaRecursos.Recursos.ManejadorRecursos manejadoMensajes;
        const string ImagenProgrmacion = "~/img/imag_programacion.jpg";

        public ActionResult _SolicitudActualizacion(string CodMunicipio)
        {
            var model = new List<EventoDataDTO>();
            BasicaDTO objBasicas = ZonaGeograficasLogica.ObtenerNombres(CodMunicipio);
            fabricaMensajes = new SM.LibreriaRecursos.Recursos.FabricaManejador();
            manejadoMensajes = fabricaMensajes.getInstance();
            string AnoEvento = manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.Celebra_Ano_Evento);
            if (objBasicas != null)
            {
                ViewBag.NombreMunicipio = objBasicas.text + " - " + objBasicas.value;
            }
            if (!String.IsNullOrEmpty(CodMunicipio))
                model = EventosNeg.ConsultarConciertorPorMunicipio(CodMunicipio, Convert.ToInt32(AnoEvento), Convert.ToInt32(UsuaroId));
            return PartialView("_SolicitudActualizacion", model);
        }

        [HttpPost]
        public JsonResult AgregarUsuario(string EventoId, string CodMunicipio)
        {
            bool isSuccess = true;

            if (string.IsNullOrEmpty(EventoId))
                return Json(new { Response = "Error" });


            AsignacionUsuariosNeg.AgregarSolicitudConciertos(Convert.ToInt32(EventoId), Convert.ToInt32(UsuaroId), CodMunicipio);


            return Json(isSuccess);

        }
        public ActionResult _DetalleArtistas(string Id, int? page)
        {
            var listado = new List<BasicaDTO>();

          
            ViewBag.EventoId = Id;

            if (!string.IsNullOrEmpty(Id))
            {
                ViewBag.nombreEntidad = EventosNeg.obtenerNombreEntidad(Convert.ToInt32(Id));
                listado = EventosNeg.ConsultarArtistasPorEventoId(Convert.ToInt32(Id));

            }


            var model = from l in listado select l;
            int pageSize = 15;
            int pageNumber = (page ?? 1);

            return PartialView("_DetalleArtistas", model.ToPagedList(pageNumber, pageSize));
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
        // GET: /Celebra/

        public ActionResult ProgramacionDepartamento(string Id, string periodo, int? page)
        {
            string Nombre = "";
            var listResultado = new List<EventoDataModels>();
            listResultado = TranslatorEventos.ConsultarEventosPorCodigoDepto(Convert.ToInt32(periodo), Id);
            Nombre = ZonaGeograficasLogica.obtenerNombreDepartamento(Id) + " - " + periodo;
            ViewBag.CodDepto = Id;
            ViewBag.periodo = periodo;
            ViewBag.Registros = Nombre;
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialResultado", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ProgramacionPeriodo(string codDepto, string codMun, string periodo, int? page)
        {
            var listResultado = new List<EventoDataModels>();
            string Nombre = "";
            if ((!String.IsNullOrEmpty(codDepto)) && (codMun.Trim() == "Municipio"))
            {
                listResultado = TranslatorEventos.ConsultarEventosPorCodigoDepto(Convert.ToInt32(periodo), codDepto);
                Nombre = ZonaGeograficasLogica.obtenerNombreDepartamento(codDepto) + " - " + periodo;
                ViewBag.CodDepto = codDepto;

            }
            else if (!String.IsNullOrEmpty(codMun))
            {
                listResultado = TranslatorEventos.ConsultarEventosPorCodigoMunicipio(Convert.ToInt32(periodo), codMun);
                Nombre = ZonaGeograficasLogica.ObtenerNombreDepartamentoyMunicipio(codMun) + " - " + periodo;
                ViewBag.codMunicipio = codMun;
            }
            ViewBag.Registros = Nombre;
            ViewBag.periodo = periodo;
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialResultado", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ProgramacionMunicipio(string Id, string periodo, int? page)
        {
            string Nombre = "";
            var listResultado = new List<EventoDataModels>();
            listResultado = TranslatorEventos.ConsultarEventosPorCodigoMunicipio(Convert.ToInt32(periodo), Id);
            Nombre = ZonaGeograficasLogica.ObtenerNombreDepartamentoyMunicipio(Id) + " - " + periodo;
            ViewBag.codMunicipio = Id;
            ViewBag.periodo = periodo;
            ViewBag.Registros = Nombre;
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialResultado", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult TematicoCelebra(string id = "2019")
        {
            var objAnos = new List<BasicaDTO>();
            objAnos = BasicaLogica.ConsultarListadoAnosMusica();
            ViewBag.listAnos = new SelectList(objAnos, "value", "text");
            var model = new ConsultaModel();
            model.selectorAno = id;

            return View(model);
        }
        public ActionResult MapaCelebra(string id = "2019")
        {
            ViewBag.departamentos = new SelectList(ZonaGeograficasLogica.ConsultarDepartamentos(), "value", "text");
            List<BasicaDTO> objMunicipios = new List<BasicaDTO>();
            ViewBag.municipios = new SelectList(objMunicipios, "value", "text");
            var objAnos = new List<BasicaDTO>();
            objAnos = BasicaLogica.ConsultarListadoAnosMusica();
            ViewBag.listAnos = new SelectList(objAnos, "value", "text");
            var model = new ConsultaModel();
            model.selectorAno = id;
            return View(model);
        }

        public ActionResult Programacion(string codDepto, string codMunicipio, int? periodo, int? page)
        {
            int intAno = (periodo ?? 2019);
            string Nombre = "";
            ViewBag.periodo = intAno;
            var listResultado = new List<EventoDataModels>();
            if (String.IsNullOrEmpty(codDepto) && String.IsNullOrEmpty(codMunicipio))
            {
                listResultado = TranslatorEventos.ConsultarEventosCapitales(intAno);
                Nombre = "Capitales";
            }
            else if (!String.IsNullOrEmpty(codDepto))
            {
                listResultado = TranslatorEventos.ConsultarEventosPorCodigoDepto(intAno, codDepto);
                Nombre = ZonaGeograficasLogica.obtenerNombreDepartamento(codDepto) + " - " + intAno.ToString();
                ViewBag.CodDepto = codDepto;

            }
            else if (!String.IsNullOrEmpty(codMunicipio))
            {
                listResultado = TranslatorEventos.ConsultarEventosPorCodigoMunicipio(intAno, codMunicipio);
                Nombre = ZonaGeograficasLogica.ObtenerNombreDepartamentoyMunicipio(codMunicipio) + " - " + intAno.ToString();
                ViewBag.codMunicipio = codMunicipio;
            }

            ViewBag.CantidadRegistros = listResultado.Count;
            ViewBag.Registros = Nombre;
            var model = from l in listResultado select l;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            if (page == null)
            {
                List<BasicaDTO> objMunicipios = new List<BasicaDTO>();
                List<BasicaDTO> objDepartamentos = ZonaGeograficasLogica.ConsultarDepartamentos();
                var objAnos = new List<BasicaDTO>();
                objAnos = BasicaLogica.ConsultarListadoAnosMusica();
                ViewBag.listAnos = new SelectList(objAnos, "value", "text");
                ViewBag.departamentos = new SelectList(objDepartamentos, "value", "text");
                ViewBag.municipios = new SelectList(objMunicipios, "value", "text");
                return View(model.ToPagedList(pageNumber, pageSize));
            }
            else
                return PartialView("_PartialResultado", model.ToPagedList(pageNumber, pageSize));


        }

        [HttpPost]
        public ActionResult Programacion(ProgramacionModels model)
        {

            var objAnos = new List<BasicaDTO>();
            ViewBag.listAnos = new SelectList(objAnos, "value", "text");

            if (ModelState.IsValid)
            {


                return RedirectToAction("DetalleProgramacion", "Musica", new { Ano = model.codigoAno, codigo = model.CodigoMunicipio });
            }
            //CargaInicial("", "");
            return View(model);
        }

        public ActionResult DetalleProgramacion(string Ano, string codigo, int? page)
        {
            ViewBag.AnoEvento = Ano;
            ViewBag.Codigo = codigo;

            List<EventoPadreModels> listResultado;
            listResultado = TranslatorEventos.ConsultarProgramacionConciertosMusica(Ano, codigo);
            if (listResultado.Count > 0)
            {
                ViewBag.Municipio = (from l in listResultado select l).FirstOrDefault().DatosBasicos.Municipio;
                ViewBag.Departamento = (from l in listResultado select l).FirstOrDefault().DatosBasicos.Departamento;
                ViewBag.FechaEvento = (from l in listResultado select l).FirstOrDefault().DatosBasicos.FechaEvento;
            }
            var model = from l in listResultado select l;
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult Resultado()
        {

            return View();
        }
        public ActionResult Index()
        {
            if (String.IsNullOrEmpty(NombreCompletoUsuario))
                return RedirectToAction("LoginMusica", "Cuenta");

            ViewBag.NombreUsuario = NombreCompletoUsuario;


            return View();
        }

        public ActionResult Consulta(string Id)
        {
            return View();
        }


        public ActionResult Municipios()
        {

            return View();
        }

        public ActionResult ConsultaArtistas()
        {

            return View();
        }
        public ActionResult ArtistaEditar(int Id)
        {
            if (Session["$usuario"] == null)
                return RedirectToAction("LoginMusica", "Cuenta");

            TempData["imagen"] = "~/img/logo_crear_concierto.png";
            ViewBag.ImageData = "~/img/logo_crear_concierto.png";
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
                return RedirectToAction("LoginMusica", "Cuenta");


            fabricaMensajes = new SM.LibreriaRecursos.Recursos.FabricaManejador();
            manejadoMensajes = fabricaMensajes.getInstance();
            CargaInicialArtista();
            string imageDataURL = "";
            ViewBag.ImageData = "~/img/logo_crear_concierto.png";
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
                            imageDataURL = "~/img/logo_crear_concierto.png";
                    }

                    TempData["imagen"] = imageDataURL;
                    ViewBag.ImageData = imageDataURL;
                }

                ActualizarArtista(Id, model, fileData);
                return RedirectToAction("Editar", "Musica", new { Id = model.EventoId });
            }


            return View(model);
        }
        public ActionResult Artista(int Id)
        {
            if (Session["$usuario"] == null)
                return RedirectToAction("LoginMusica", "Cuenta");

            TempData["imagen"] = "~/img/logo_crear_concierto.png";
            ViewBag.ImageData = "~/img/logo_crear_concierto.png";
            var model = new ArtistaModels();
            model.EventoId = Id;
            CargaInicialArtista();
            return View(model);
        }

        [HttpPost]
        public ActionResult Artista(int Id, HttpPostedFileBase imagenPerfil, ArtistaModels model)
        {
            if (Session["$usuario"] == null)
                return RedirectToAction("LoginMusica", "Cuenta");


            fabricaMensajes = new SM.LibreriaRecursos.Recursos.FabricaManejador();
            manejadoMensajes = fabricaMensajes.getInstance();

            TempData["imagen"] = "~/img/logo_crear_concierto.png";
            ViewBag.ImageData = "~/img/logo_crear_concierto.png";
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
                return RedirectToAction("Editar", "Musica", new { Id = model.EventoId });
            }


            return View(model);
        }
        public ActionResult Evento()
        {
            fabricaMensajes = new SM.LibreriaRecursos.Recursos.FabricaManejador();
            manejadoMensajes = fabricaMensajes.getInstance();

            TempData["imagen"] = "~/img/logo_crear_concierto.png";
            ViewBag.ImageData = "~/img/logo_crear_concierto.png";
            var model = new EventoModels();
            model.Nombre = "Celebra la Música";
            model.FechaEvento = manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.Celebra_Fecha_Evento);
            model.Tipo = "Música";
            CargaInicial("", "");
            return View(model);
        }

        [HttpPost]
        public ActionResult Evento(HttpPostedFileBase imagenPerfil, string CodigoDepartamento, EventoModels model)
        {

            TempData["imagen"] = "~/img/logo_crear_concierto.png";
            ViewBag.ImageData = "~/img/logo_crear_concierto.png";
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
                return RedirectToAction("Editar", "Musica", new { Id = EventoId });
            }

            CargaInicial(model.CodigoDepartamento, model.CodigoMunicipio);
            return View(model);
        }

        public ActionResult Editar(int Id)
        {

            TempData["imagen"] = "~/img/logo_crear_concierto.png";
            ViewBag.ImageData = "~/img/logo_crear_concierto.png";
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];
            var modelPadre = new EventoPadreModels();

            var model = new EventoModels();
            model = TranslatorEventos.ConsultaEventoPorId(Id);
            if (model.ArtMusicaUsuarioId != usuario.Id)
                return RedirectToAction("Detalle", "Musica", new { Id = Id });

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
            var modeltabla = new List<ArtistaPublicoModels>();
            modeltabla = Translator.TranslatorEventos.ConsultaArtistasPorEventoId(Id);
            modelPadre.listArtista = modeltabla;
            return View(modelPadre);
        }

        [HttpPost]
        public ActionResult Editar(int Id, HttpPostedFileBase imagenPerfil, EventoModels model)
        {
            if (Session["$usuario"] == null)
                return RedirectToAction("LoginMusica", "Cuenta");

            string imageDataURL = "";
            var modelPadre = new EventoPadreModels();
            modelPadre.DatosBasicos = model;
            ViewBag.ImageData = "~/img/logo_crear_concierto.png";
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
                            imageDataURL = "~/img/logo_crear_concierto.png";
                    }

                    TempData["imagen"] = imageDataURL;
                    ViewBag.ImageData = imageDataURL;
                }

                ActualizarEvento(Id, model, fileData, false);
                var modeltabla = new List<ArtistaPublicoModels>();
                modeltabla = Translator.TranslatorEventos.ConsultaArtistasPorEventoId(Id);
                modelPadre.listArtista = modeltabla;
                Session["$EventoId"] = Id;
                CargaInicial(model.CodigoDepartamento, model.CodigoMunicipio);
                Success(string.Format("<b></b> Se actualizo con éxito el concierto: {0}  ", model.Nombre), true);
                return View("Editar", modelPadre);
            }


            CargaInicial(model.CodigoDepartamento, model.CodigoMunicipio);
            return View(model);
        }

        public ActionResult Detalle(int Id)
        {
            TempData["imagen"] = "~/img/logo_crear_concierto.png";
            ViewBag.ImageData = "~/img/logo_crear_concierto.png";
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
        #region MetodosPrivados
        public JsonResult ObtenerMunicipio(string departamento = null)
        {

            List<BasicaDTO> listMunicipios = new List<BasicaDTO>();

            if (!String.IsNullOrEmpty(departamento))
            {
                listMunicipios = ZonaGeograficasLogica.ConsultarMunicipios(departamento);
            }

            var data = listMunicipios;
            return Json(data, JsonRequestBehavior.AllowGet);
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

            if (model != null)
            {
                nuevoRegistro.Id = 0;
                nuevoRegistro.UsuarioId = Convert.ToInt32(UsuaroId);
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

        private int GuardarArtista(ArtistaModels model, byte[] imagen)
        {
            var nuevoRegistro = new ArtistaDTO();
            fabricaMensajes = new SM.LibreriaRecursos.Recursos.FabricaManejador();
            manejadoMensajes = fabricaMensajes.getInstance();
            int artistaId = 0;

            if (model != null)
            {
                nuevoRegistro.Id = 0;
                nuevoRegistro.UsuarioId = Convert.ToInt32(UsuaroId);

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

        }

        public JsonResult ObtenerAnosProgramacion(string codigoMunicipio = null)
        {

            List<BasicaDTO> listDpto = new List<BasicaDTO>();
            ViewBag.esColombia = true;
            if (!String.IsNullOrEmpty(codigoMunicipio))
            {

                listDpto = EventosNeg.ConsultarListadoAno(codigoMunicipio);
            }

            var data = listDpto;
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        private void CargaInicialArtista()
        {
            List<BasicaDTO> objTipo = CaracterizacionMusicalNeg.ConsultarCategoriaCelebra();
            ViewBag.listCategoria = new SelectList(objTipo, "value", "text");
            List<BasicaDTO> objProceso = CaracterizacionMusicalNeg.ConsultarProcesoFormacionCelebra();
            ViewBag.listProceso = new SelectList(objProceso, "value", "text");
        }
        #endregion
        #region Grilla


        // [Authorize]
        public ActionResult ExportTo(string OutputFormat)
        {
            var model = new List<EventoDataModels>();
            model = TranslatorEventos.ConsultarEventoPorArea(Convert.ToInt32(UsuaroId), "Música");

            return GridViewExtension.ExportToXls(GetGridSettings(), model.ToList());
        }

        public ActionResult ExportToMunicipios(string OutputFormat)
        {
            var model = new List<MunicipioCelebraModels>();

            model = TranslatorEventos.MunicipioParticipantesCelebralaMusica();

            return GridViewExtension.ExportToXls(GetGridSettingsMunicipio(), model.ToList());
        }

        public ActionResult ExportToArtistas(string OutputFormat)
        {
            fabricaMensajes = new SM.LibreriaRecursos.Recursos.FabricaManejador();
            manejadoMensajes = fabricaMensajes.getInstance();
            string AnoEvento = manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.Celebra_Ano_Evento);
            var model = new List<ArtistaDetalleDTO>();

            model = EventosNeg.ConsultarDetalleArtistas(Convert.ToInt32(AnoEvento));

            return GridViewExtension.ExportToXls(GetGridSettingsArtista(), model.ToList());
        }

        public ActionResult ExportToPermisos(string OutputFormat)
        {
            fabricaMensajes = new SM.LibreriaRecursos.Recursos.FabricaManejador();
            manejadoMensajes = fabricaMensajes.getInstance();
            string codigoAreaArtistica = manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.SIMUS_Codigo_Musica);
            decimal AreaArtisticaId = Convert.ToDecimal(codigoAreaArtistica);
            string strArea = manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.SIMUS_Musica);
            string AnoEvento = manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.Celebra_Ano_Evento);
            var model = new List<EventoDataDTO>();

            model = EventosNeg.ConsultarDetalleEventos(AreaArtisticaId, Convert.ToInt32(AnoEvento), strArea);

            return GridViewExtension.ExportToXls(GetGridSettingsPermisos(), model.ToList());
        }
        // Returns the settings of the exported GridView. 
        private GridViewSettings GetGridSettings()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridEvento";
            settings.CallbackRouteValues = new { Controller = "Musica", Action = "GridViewPartial" };
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
            return settings;
        }

        private GridViewSettings GetGridSettingsPermisos()
        {
            var settings = new GridViewSettings();
            settings.Name = "DataView";
            settings.CallbackRouteValues = new { Controller = "Musica", Action = "DataViewPartial" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "Conciertos" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.Columns.Add("NombreDepartamento");
            settings.Columns.Add("NombreMunicipio");
            settings.Columns.Add("EntidadOrganizadora");
            settings.Columns.Add("LugarEvento");
            settings.Columns.Add("FechaEvento");

            return settings;
        }

        private GridViewSettings GetGridSettingsMunicipio()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridMunicipio";
            settings.CallbackRouteValues = new { Controller = "Musica", Action = "GridViewMunicipio" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "MunicipiosParticipantes" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "CodMunicipio";
            settings.Columns.Add("NombreDepartamento");
            settings.Columns.Add("NombreMunicipio");
            settings.Columns.Add("cantidad");
            return settings;
        }
        [ValidateInput(false)]
        public ActionResult GridViewMunicipio()
        {

            ViewBag.GridSettings = GetGridSettingsMunicipio();

            var model = new List<MunicipioCelebraModels>();

            model = TranslatorEventos.MunicipioParticipantesCelebralaMusica();

            return PartialView("_GridviewMunicipio", model);
        }

        private GridViewSettings GetGridSettingsArtista()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridArtista";
            settings.CallbackRouteValues = new { Controller = "Musica", Action = "GridViewArtista" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "ArtistasParticipantes" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "Id";
            settings.Columns.Add("NombreDepartamento");
            settings.Columns.Add("NombreMunicipio");
            settings.Columns.Add("EntidadOrganizadora");
            settings.Columns.Add("LugarEvento");
            settings.Columns.Add("Nombre");
            settings.Columns.Add("Contacto");
            settings.Columns.Add("Proceso");
            settings.Columns.Add("Categoria");
            settings.Columns.Add("CantidadMiembros");
            return settings;
        }
        [ValidateInput(false)]
        public ActionResult GridViewArtista()
        {

            ViewBag.GridSettings = GetGridSettingsArtista();

            fabricaMensajes = new SM.LibreriaRecursos.Recursos.FabricaManejador();
            manejadoMensajes = fabricaMensajes.getInstance();
            string AnoEvento = manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.Celebra_Ano_Evento);
            var model = new List<ArtistaDetalleDTO>();

            model = EventosNeg.ConsultarDetalleArtistas(Convert.ToInt32(AnoEvento));

            return PartialView("_GridviewArtista", model);
        }

        public ActionResult GridViewResultado()
        {

            fabricaMensajes = new SM.LibreriaRecursos.Recursos.FabricaManejador();
            manejadoMensajes = fabricaMensajes.getInstance();
            string AnoEvento = manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.Celebra_Ano_Evento);
            var model = new List<ResultadoEstimuloDTO>();

            model = ServicioEstimuloNeg.ObtenerGanadoresConvocatoriaCoro(AnoEvento);

            return PartialView("_GridviewResultado", model);
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial(string Busqueda = null, string filtro = null)
        {

            ViewBag.GridSettings = GetGridSettings();
            ViewBag.NombreUsuario = NombreCompletoUsuario;
            var model = new List<EventoDataModels>();


            model = TranslatorEventos.ConsultarEventoPorArea(Convert.ToInt32(UsuaroId), "Música");

            return PartialView("_GridViewPartial", model);
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartialPermisos(string codigo = null)
        {
            ViewBag.GridSettings = GetGridSettingsPermisos();


            var model = new List<EventoDataModels>();

            //Session["$EventoDanza10"] = TranslatorEventos.ConsultarEventoPorDepartamento(codigo, "Danza");

            model = (List<EventoDataModels>)Session["$EventoDanza10"];

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

        #endregion

        #region LogErrores
        protected override void OnException(ExceptionContext filterContext)
        {
            string ruta = "";
            ruta = Server.MapPath("/Log");
            Log.WriteLog(ruta, filterContext.Exception.ToString());

            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;


            var model = new HandleErrorInfo(filterContext.Exception, "MusicaController", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }
        #endregion

        [ValidateInput(false)]
        public ActionResult DataViewPartial()
        {
            fabricaMensajes = new SM.LibreriaRecursos.Recursos.FabricaManejador();
            manejadoMensajes = fabricaMensajes.getInstance();
            string codigoAreaArtistica = manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.SIMUS_Codigo_Musica);
            decimal AreaArtisticaId = Convert.ToDecimal(codigoAreaArtistica);
            string strArea = manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.SIMUS_Musica);
            string AnoEvento = manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.Celebra_Ano_Evento);
            var model = new List<EventoDataDTO>();

            model = EventosNeg.ConsultarDetalleEventos(AreaArtisticaId, Convert.ToInt32(AnoEvento), strArea);
            return PartialView("_DataViewPartial", model);
        }
    }
}