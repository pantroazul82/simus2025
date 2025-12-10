using DevExpress.Web.Mvc;
using SM.Aplicacion.Basicas;
using SM.Aplicacion.Servicios;
using SM.LibreriaComun.DTO;
using SM.LibreriaComun.DTO.Servicios;
using SM.Utilidades.Log;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSImus.Helpers;
using WebSImus.Models;

namespace WebSImus.Controllers
{
    [HandleError()]
    [SessionExpire]
    public class UtilidadController : BaseController
    {
        public ActionResult Cargargeneros(int utilidadId, int EliminarId)
        {
            var listado = new List<EstandarDTO>();
            if (EliminarId > 0)
            {
                UtilidadNeg.EliminarGenero(EliminarId);
            }

            listado = UtilidadNeg.ConsultarGenerosPorUtilidadId(utilidadId);

            return PartialView("_TablaGenero", listado);
        }

        [HttpPost]
        public JsonResult AgregarGeneros(string atributo,
                                         string utilidadId)
        {
            bool isSuccess = true;

            if (string.IsNullOrEmpty(atributo))
                return Json(new { Response = "Error" });

            UtilidadNeg.AgregarGenero(Convert.ToInt32(utilidadId), atributo);

            return Json(isSuccess);

        }

        public ActionResult CargarServicio(int utilidadId, int EliminarId)
        {
            var listado = new List<EstandarDTO>();
            if (EliminarId > 0)
            {
                UtilidadNeg.EliminarServicio(EliminarId);
            }

            listado = UtilidadNeg.ConsultarServicioPorUtilidadId(utilidadId);

            return PartialView("_TablaServicio", listado);
        }

        [HttpPost]
        public JsonResult AgregarServicio(string atributo,
                                         string utilidadId)
        {
            bool isSuccess = true;

            if (string.IsNullOrEmpty(atributo))
                return Json(new { Response = "Error" });

            UtilidadNeg.AgregarServicio(Convert.ToInt32(utilidadId), atributo);

            return Json(isSuccess);

        }
        public ActionResult _AceptarTerminos()
        {

            return PartialView("_AceptarTerminos");
        }
        // GET: Utilidad
        public ActionResult Index()
        {
            var model = new ConsultaModel();
            model.TipoRegistro = 1;

            return View(model);
        }

        public ActionResult Consulta()
        {
            return View();
        }
        public ActionResult Detalle(int Id)
        {
            TempData["imagen"] = "~/img/agrupa_generica.jpg";
            ViewBag.ImageData = "~/img/agrupa_generica.jpg";
            var model = new UtilidadDataDetalleDTO();
            model = UtilidadNeg.ConsultarDetallePorId(Id);

            if (model.Imagen != null)
            {
                string imageBase64Data = Convert.ToBase64String(model.Imagen);
                string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                TempData["imagen"] = imageDataURL;
                ViewBag.ImageData = imageDataURL;
            }
            return View(model);

        }
        public ActionResult Nuevo()
        {
            var model = new UtilidadPadreModels();
            TempData["imagen"] = "~/img/agrupa_generica.jpg";
            ViewBag.ImageData = "~/img/agrupa_generica.jpg";
            model.EsActivo = true;
            model.HoraInicio = "12:00";
            model.HoraFin = "12:00";
            CargaInicial("", "", "");
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(HttpPostedFileBase imagenPerfil, UtilidadPadreModels model)
        {
            TempData["imagen"] = "~/img/agrupa_generica.jpg";
            ViewBag.ImageData = "~/img/agrupa_generica.jpg";
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
                int AgrupacionId = Guardar(model, fileData);
                return RedirectToAction("Editar", "Utilidad", new { Id = AgrupacionId });

            }
            CargaInicial(model.CodigoPais, model.CodigoDepartamento, model.CodigoMunicipio);

            return View(model);
        }

        public ActionResult Editar(int Id)
        {
            var model = new UtilidadPadreModels();
            TempData["imagen"] = "~/img/agrupa_generica.jpg";
            ViewBag.ImageData = "~/img/agrupa_generica.jpg";
            var resultado = UtilidadNeg.ConsultarUtilidadporId(Id);
            model = Translator.TranslatorUtilidad.TranslatorUtilidadModel(resultado);

            var datosbasicos = new DatosBasicosUtilidad();
            datosbasicos.UtilidadId = Id;
            model.DatosBasicos = datosbasicos;
            ViewBag.Nombre = model.Titulo;
            if (model.ArtMusicaUsuarioId != Convert.ToInt32(UsuaroId))
                return RedirectToAction("Detalle", "Utilidad", new { Id = Id });

            CargarDatosBasicos(model.Tipo, model.Tipoutilidad, model.CodigoPais, model.CodigoDepartamento, model.CodigoMunicipio, false);
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
        public ActionResult Editar(int Id, HttpPostedFileBase imagenPerfil, UtilidadPadreModels model)
        {
            string imageDataURL = "";
            ViewBag.ImageData = "~/img/agrupa_generica.jpg";

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
                            imageDataURL = "~/img/agrupa_generica.jpg";
                    }
                }
                TempData["imagen"] = imageDataURL;
                ViewBag.ImageData = imageDataURL;
                Actualizar(Id, model, fileData);

            }
            var resultado = UtilidadNeg.ConsultarUtilidadporId(Id);
            model = Translator.TranslatorUtilidad.TranslatorUtilidadModel(resultado);
            var datosbasicos = new DatosBasicosUtilidad();
            datosbasicos.UtilidadId = Id;
            model.DatosBasicos = datosbasicos;
            ViewBag.Nombre = model.Titulo;
            CargarDatosBasicos(model.Tipo, model.Tipoutilidad, model.CodigoPais, model.CodigoDepartamento, model.CodigoMunicipio, false);

            Success(string.Format("<b></b> Se actualizo con éxito la utilidad: {0}  ", model.Titulo), true);
            return View("Editar", model);
        }

        public ActionResult CambiarEstado(int Id)
        {
            var model = new UtilidadPadreModels();
            TempData["imagen"] = "~/img/agrupa_generica.jpg";
            ViewBag.ImageData = "~/img/agrupa_generica.jpg";
            var resultado = UtilidadNeg.ConsultarUtilidadporId(Id);
            model = Translator.TranslatorUtilidad.TranslatorUtilidadModel(resultado);
            var datosbasicos = new DatosBasicosUtilidad();
            datosbasicos.UtilidadId = Id;
            model.DatosBasicos = datosbasicos;
           
            CargarDatosBasicos(model.Tipo, model.Tipoutilidad, model.CodigoPais, model.CodigoDepartamento, model.CodigoMunicipio, true);
            List<BasicaDTO> listEstado = CaracterizacionMusicalNeg.ConsultarEstados();
            ViewBag.listEstado = new SelectList(listEstado, "value", "text");
            ViewBag.Nombre = model.Titulo;
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
        public ActionResult CambiarEstado(int Id, HttpPostedFileBase imagenPerfil, UtilidadPadreModels model)
        {
            string imageDataURL = "";
            ViewBag.ImageData = "~/img/agrupa_generica.jpg";

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
                            imageDataURL = "~/img/agrupa_generica.jpg";
                    }
                }
                TempData["imagen"] = imageDataURL;
                ViewBag.ImageData = imageDataURL;
                ViewBag.Nombre = model.Titulo;
                Actualizar(Id, model, fileData);

            }
            var resultado = UtilidadNeg.ConsultarUtilidadporId(Id);
            model = Translator.TranslatorUtilidad.TranslatorUtilidadModel(resultado);
            var datosbasicos = new DatosBasicosUtilidad();
            datosbasicos.UtilidadId = Id;
            model.DatosBasicos = datosbasicos;
            CargarDatosBasicos(model.Tipo, model.Tipoutilidad, model.CodigoPais, model.CodigoDepartamento, model.CodigoMunicipio, true);
            List<BasicaDTO> listEstado = CaracterizacionMusicalNeg.ConsultarEstados();
            ViewBag.listEstado = new SelectList(listEstado, "value", "text");

            Success(string.Format("<b></b> Se actualizo con éxito la convocatoria: {0}  ", model.Titulo), true);
            return View("CambiarEstado", model);
        }
        #region MetodosPrivados
        private void Actualizar(int Id, UtilidadPadreModels model, byte[] imagen)
        {
            var datos = new UtilidadDTO();

            if (model != null)
            {
                datos.ActorId = Convert.ToInt32(model.TipoActor);
                datos.Descripcion = model.Descripcion;
                if (!string.IsNullOrEmpty(model.FechaInicio))
                {
                    try
                    {

                        string[] hora = model.HoraInicio.Split(' ');
                        CultureInfo provider = CultureInfo.InvariantCulture;
                        string dateString = model.FechaInicio + " " + hora[0] + ":01 " + hora[1];
                        DateTime dt = Convert.ToDateTime(dateString);
                        datos.FechaInicio = dt;

                    }
                    catch (FormatException f)
                    {
                        string mensaje = f.ToString();
                    }
                }

                if (!string.IsNullOrEmpty(model.FechaFin))
                {
                    try
                    {

                        string[] hora = model.HoraFin.Split(' ');
                        CultureInfo provider = CultureInfo.InvariantCulture;
                        string dateString = model.FechaFin + " " + hora[0] + ":01 " + hora[1];
                        DateTime dt = Convert.ToDateTime(dateString);
                        datos.FechaFin = dt;

                    }
                    catch (FormatException f)
                    {
                        string mensaje = f.ToString();
                    }
                }
                datos.TipoActorId = Convert.ToInt32(model.Tipo);
                datos.Titulo = model.Titulo;
                datos.UsuarioAprobadorId = Convert.ToInt32(UsuaroId);
                datos.UtilidadId = model.UtilidadId;
                datos.EstadoId = Convert.ToInt32(model.EstadoId);
                datos.TipoUtilidadId = Convert.ToInt32(model.Tipoutilidad);
                datos.TipoEventoId = Convert.ToInt32(model.TipoEvento);
                datos.Telefono = model.Telefono;
                datos.CorreoElectronico = model.CorreoElectronico;
                datos.CodPais = Convert.ToInt32(model.CodigoPais);
                datos.EsActivo = model.EsActivo;
                if (!string.IsNullOrEmpty(model.CodigoDepartamento))
                {
                    if (model.CodigoDepartamento.Trim() == "Seleccione un departamento")
                        datos.codDepto = "";
                    else
                        datos.codDepto = model.CodigoDepartamento;
                }
                else
                    datos.codDepto = "";
                if (!string.IsNullOrEmpty(model.CodigoMunicipio))
                {
                    if (model.CodigoMunicipio.Trim() == "Seleccione un municipio")
                        datos.codMunicipio = "";
                    else
                        datos.codMunicipio = model.CodigoMunicipio;
                }
                else
                    datos.codMunicipio = "";

                datos.Direccion = model.Direccion;
                if (imagen != null)
                    datos.imagen = imagen;
                else
                    datos.imagen = null;

                datos.Latitud = model.Latitud;
                datos.Longitud = model.Longitud;

                UtilidadNeg.Actualizarutilidad(datos, NombreCompletoUsuario, Request.UserHostAddress);

                if (model.Documento != null)
                {
                    int DocumentoId = documentoCreacion.CrearDocumento(Convert.ToInt32(UsuaroId), NombreCompletoUsuario, Request.UserHostAddress, model.Documento);

                    if (DocumentoId > 0)
                    {
                        UtilidadNeg.ActualizarDOcumento(model.UtilidadId, DocumentoId);
                    }


                }
            }

        }

        private void CargarDatosBasicos(string tipo, string tipoUtilidad, string codigoPais, string codigoDepartamento, string codigoMunicipio, bool admin)
        {

            List<BasicaDTO> listAsociado = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_CATEGORIAS_ACTORES);
            List<BasicaDTO> listTipoUtilidad = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_TIPO_UTILIDAD);
            List<BasicaDTO> listActor;
            if (admin)
                listActor = ObtenerActorAdministrador(tipo);
            else
                listActor = ObtenerActor(tipo);

            List<BasicaDTO> listTipoClasificacion = ObtenerTipoClasificacion(tipoUtilidad);
            ViewBag.listCategoria = new SelectList(listAsociado, "value", "text");
            ViewBag.listActores = new SelectList(listActor, "value", "text");
            ViewBag.listTipoUtilidad = new SelectList(listTipoUtilidad, "value", "text");
            ViewBag.listTipoEvento = new SelectList(listTipoClasificacion, "value", "text");

            List<BasicaDTO> lstPais = ZonaGeograficasLogica.ConsultarPaises();
            ViewBag.listPais = new SelectList(lstPais, "value", "text");

            var objMunicipios = new List<BasicaDTO>();
            var objDepartamentos = new List<BasicaDTO>();

            if (codigoPais == "52")
            {
                objDepartamentos = ZonaGeograficasLogica.ConsultarDepartamentos();
                if (!string.IsNullOrEmpty(codigoDepartamento))
                {
                    objMunicipios = ZonaGeograficasLogica.ConsultarMunicipios(codigoDepartamento);
                }
            }

            ViewBag.listDepartamentos = new SelectList(objDepartamentos, "value", "text");
            ViewBag.listMunicipio = new SelectList(objMunicipios, "value", "text");

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

        public List<BasicaDTO> ObtenerTipoClasificacion(string tipo)
        {

            var listTipoUtilidad = new List<BasicaDTO>();
            string NombreCategoria;
            if (!String.IsNullOrEmpty(tipo))
            {
                NombreCategoria = ConvocatoriaNeg.ObtenerNombreParametro(Convert.ToInt32(tipo));

                if (!String.IsNullOrEmpty(NombreCategoria))
                {
                    if (NombreCategoria.TrimEnd() == Comunes.ConstantesRecursosBD.NOMBRE_UTILIDAD_EVENTO)
                        listTipoUtilidad = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_TIPO_EVENTO);
                    else if (NombreCategoria.TrimEnd() == Comunes.ConstantesRecursosBD.NOMBRE_UTILIDAD_NOTICIAS)
                        listTipoUtilidad = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_TIPO_NOTICIAS);
                    else if (NombreCategoria.TrimEnd() == Comunes.ConstantesRecursosBD.NOMBRE_UTILIDAD_CLASIFICADOS)
                        listTipoUtilidad = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_TIPO_CLASIFICADOS);
                    else if (NombreCategoria.TrimEnd() == Comunes.ConstantesRecursosBD.NOMBRE_UTILIDAD_DOCUMENTOS)
                        listTipoUtilidad = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_TIPO_DOCUMENTOS);
                }
            }


            return listTipoUtilidad;
        }
        private int Guardar(UtilidadPadreModels model, byte[] imagen)
        {
            var registro = new UtilidadDTO();
            int utilidadId = 0;

            if (model != null)
            {
                registro.UtilidadId = 0;
                registro.UsuarioId = Convert.ToInt32(UsuaroId);
                if (!string.IsNullOrEmpty(model.CodigoDepartamento))
                {
                    if (model.CodigoDepartamento.Trim() == "Seleccione un departamento")
                        registro.codDepto = "";
                    else
                        registro.codDepto = model.CodigoDepartamento;
                }
                else
                    registro.codDepto = "";
                if (!string.IsNullOrEmpty(model.CodigoMunicipio))
                {
                    if (model.CodigoMunicipio.Trim() == "Seleccione un municipio")
                        registro.codMunicipio = "";
                    else
                        registro.codMunicipio = model.CodigoMunicipio;
                }
                else
                    registro.codMunicipio = "";

                if (!string.IsNullOrEmpty(model.CodigoPais))
                    registro.CodPais = Convert.ToInt32(model.CodigoPais);
                if (!string.IsNullOrEmpty(model.OtraCiudad))
                    registro.OtraCiudad = model.OtraCiudad;

                if (!string.IsNullOrEmpty(model.CorreoElectronico))
                    registro.CorreoElectronico = model.CorreoElectronico;
                if (!string.IsNullOrEmpty(model.Direccion))
                    registro.Direccion = model.Direccion;

                registro.Titulo = model.Titulo;
                if (imagen != null)
                    registro.imagen = imagen;
                else
                    registro.imagen = null;

                if (!string.IsNullOrEmpty(model.Descripcion))
                    registro.Descripcion = model.Descripcion;

                if (!string.IsNullOrEmpty(model.Telefono))
                    registro.Telefono = model.Telefono;

                if (!string.IsNullOrEmpty(model.Tipo))
                    registro.TipoActorId = Convert.ToInt32(model.Tipo);
                if (!string.IsNullOrEmpty(model.TipoActor))
                    registro.ActorId = Convert.ToInt32(model.TipoActor);
                if (!string.IsNullOrEmpty(model.Tipoutilidad))
                    registro.TipoUtilidadId = Convert.ToInt32(model.Tipoutilidad);
                if (!string.IsNullOrEmpty(model.TipoEvento))
                    registro.TipoEventoId = Convert.ToInt32(model.TipoEvento);


                if (!string.IsNullOrEmpty(model.FechaInicio))
                {
                    try
                    {

                        string[] hora = model.HoraInicio.Split(' ');
                        CultureInfo provider = CultureInfo.InvariantCulture;
                        string dateString = model.FechaInicio + " " + hora[0] + ":01 " + hora[1];
                        DateTime dt = Convert.ToDateTime(dateString);
                        registro.FechaInicio = dt;

                    }
                    catch (FormatException f)
                    {
                        string mensaje = f.ToString();
                    }
                }

                if (!string.IsNullOrEmpty(model.FechaFin))
                {
                    try
                    {

                        string[] hora = model.HoraFin.Split(' ');
                        CultureInfo provider = CultureInfo.InvariantCulture;
                        string dateString = model.FechaFin + " " + hora[0] + ":01 " + hora[1];
                        DateTime dt = Convert.ToDateTime(dateString);
                        registro.FechaFin = dt;

                    }
                    catch (FormatException f)
                    {
                        string mensaje = f.ToString();
                    }
                }
             
                registro.Latitud = model.Latitud;
                registro.Longitud = model.Longitud;
                registro.EsActivo = model.EsActivo;
                utilidadId = UtilidadNeg.CrearUtilidad(registro, NombreCompletoUsuario, Request.UserHostAddress);

                if (model.Documento != null)
                {
                    int DocumentoId = documentoCreacion.CrearDocumento(Convert.ToInt32(UsuaroId), NombreCompletoUsuario, Request.UserHostAddress, model.Documento);

                    if (DocumentoId > 0)
                    {
                        UtilidadNeg.ActualizarDOcumento(utilidadId, DocumentoId);
                    }


                }

            }
            return utilidadId;
        }

        private void CargaInicial(string codigoPais, string codigoDepartamento, string codigoMunicipio)
        {
            List<BasicaDTO> listAsociado = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_CATEGORIAS_ACTORES);
            List<BasicaDTO> listTipoUtilidad = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_TIPO_UTILIDAD);
            List<BasicaDTO> listActor = new List<BasicaDTO>();
            ViewBag.listCategoria = new SelectList(listAsociado, "value", "text");
            ViewBag.listActores = new SelectList(listActor, "value", "text");
            ViewBag.listTipoUtilidad = new SelectList(listTipoUtilidad, "value", "text");
            ViewBag.listTipoEvento = new SelectList(listActor, "value", "text");

            List<BasicaDTO> lstArea = ZonaGeograficasLogica.ConsultarAreas();
            ViewBag.listArea = new SelectList(lstArea, "value", "text");

            List<BasicaDTO> lstPais = ZonaGeograficasLogica.ConsultarPaises();
            ViewBag.listPais = new SelectList(lstPais, "value", "text");

            var objMunicipios = new List<BasicaDTO>();
            var objDepartamentos = new List<BasicaDTO>();

            if (codigoPais == "52")
            {
                objDepartamentos = ZonaGeograficasLogica.ConsultarDepartamentos();
                if (!string.IsNullOrEmpty(codigoDepartamento))
                {
                    objMunicipios = ZonaGeograficasLogica.ConsultarMunicipios(codigoDepartamento);
                }
            }

            ViewBag.listDepartamentos = new SelectList(objDepartamentos, "value", "text");
            ViewBag.listMunicipio = new SelectList(objMunicipios, "value", "text");

        }
        #endregion

        #region MetodosJson
        public JsonResult GetEvento(string tipo = null)
        {

            var listTipoUtilidad = new List<BasicaDTO>();
            string NombreCategoria;
            if (!String.IsNullOrEmpty(tipo))
            {
                NombreCategoria = ConvocatoriaNeg.ObtenerNombreParametro(Convert.ToInt32(tipo));

                if (!String.IsNullOrEmpty(NombreCategoria))
                {
                    if (NombreCategoria.TrimEnd() == Comunes.ConstantesRecursosBD.NOMBRE_UTILIDAD_EVENTO)
                        listTipoUtilidad = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_TIPO_EVENTO);
                    else if (NombreCategoria.TrimEnd() == Comunes.ConstantesRecursosBD.NOMBRE_UTILIDAD_NOTICIAS)
                        listTipoUtilidad = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_TIPO_NOTICIAS);
                    else if (NombreCategoria.TrimEnd() == Comunes.ConstantesRecursosBD.NOMBRE_UTILIDAD_CLASIFICADOS)
                        listTipoUtilidad = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_TIPO_CLASIFICADOS);
                    else if (NombreCategoria.TrimEnd() == Comunes.ConstantesRecursosBD.NOMBRE_UTILIDAD_DOCUMENTOS)
                        listTipoUtilidad = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_TIPO_DOCUMENTOS);
                }
            }

            var data = listTipoUtilidad;
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Grillas
        public ActionResult ExportTo(string OutputFormat)
        {
            var model = new List<UtilidadListadoDTO>();
            string Busqueda = "";
            model = ObtenerMisregistros(Busqueda);
            return GridViewExtension.ExportToXls(GetGridSettings(), model.ToList());

        }

        public ActionResult ExportToPermisos(string OutputFormat)
        {
            var model = new List<UtilidadListadoDTO>();
            model = ObtenerResultadoGestion();

            return GridViewExtension.ExportToXls(GetGridSettingsPermisos(), model.ToList());
        }

        private GridViewSettings GetGridSettingsPermisos()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridUtilidadPermisos";
            settings.CallbackRouteValues = new { Controller = "Utilidad", Action = "GridViewPartialPermisos" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "Utilidades" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "UtilidadId";
            settings.Columns.Add("Titulo");
            settings.Columns.Add("TipoActor");
            settings.Columns.Add("NombreActor");
            settings.Columns.Add("TipoUtilidad");
            settings.Columns.Add("Clasificacion");
            settings.Columns.Add("FechaInicio");
            settings.Columns.Add("FechaFin");
            settings.Columns.Add("FechaActualizacion");
            settings.Columns.Add("FechaCreacion");
            return settings;
        }
        private GridViewSettings GetGridSettings()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridUtilidad";
            settings.CallbackRouteValues = new { Controller = "Utilidad", Action = "GridViewPartial" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "Utilidades" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "UtilidadId";
            settings.Columns.Add("Titulo");
            settings.Columns.Add("TipoActor");
            settings.Columns.Add("NombreActor");
            settings.Columns.Add("TipoUtilidad");
            settings.Columns.Add("Clasificacion");
            settings.Columns.Add("FechaInicio");
            settings.Columns.Add("FechaFin");
            return settings;
        }
        public ActionResult GridViewPartial(string Busqueda = null, string filtro = null)
        {
            ViewBag.GridSettings = GetGridSettings();
            var model = new List<UtilidadListadoDTO>();
            model = ObtenerMisregistros(Busqueda);

            return PartialView("_GridViewPartial", model);
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartialPermisos()
        {
            ViewBag.GridSettings = GetGridSettingsPermisos();
            var model = new List<UtilidadListadoDTO>();

            model = ObtenerResultadoGestion();

            return PartialView("_GridViewPartialPermisos", model);
        }
        private List<UtilidadListadoDTO> ObtenerResultadoGestion()
        {
            bool EsAdmin = false;
            var model = new List<UtilidadListadoDTO>();
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

            if (EsAdmin)
                model = UtilidadNeg.ConsultarTodos();
            else
                model = UtilidadNeg.ConsultarPorMunicipio(Convert.ToInt32(UsuaroId));
            return model;
        }
        private List<UtilidadListadoDTO> ObtenerMisregistros(string Busqueda = null)
        {
            var model = new List<UtilidadListadoDTO>();

            if (string.IsNullOrEmpty(Busqueda))
            {
                if (TempData["TipoRegistroA"] != null)
                    Busqueda = TempData["TipoRegistroA"].ToString();
                else
                    Busqueda = "1";
            }

            if (Busqueda == "1")
            {
                model = UtilidadNeg.ConsultarPorUsuarioId(Convert.ToInt32(UsuaroId));
                TempData["TipoRegistroA"] = 1;
            }
            else if (Busqueda == "2")
            {
                TempData["TipoRegistroA"] = 2;
                model = UtilidadNeg.ConsultarPorEstadoId(Comunes.ConstantesRecursosBD.CODIGO_ESTADO_PUBLICADO);
            }

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


            var model = new HandleErrorInfo(filterContext.Exception, "UtilidadController", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }
        #endregion
    }
}