using SM.Utilidades.Log;
using SM.Aplicacion.Basicas;
using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSImus.Models;
using System.IO;
using SM.Aplicacion.Agentes;
using DevExpress.Web.Mvc;
using DevExpress.Data;
using WebSImus.Helpers;
using WebSImus.Translator;
using SM.Aplicacion.Modulo_Usuarios;
using System.Threading.Tasks;
using WebSImus.Comunes;

namespace WebSImus.Controllers
{
    [HandleError()]
    [SessionExpire]
    public class AgenteController : BaseController
    {
        private static readonly string codColombia = "52";


        public JsonResult AgregarFormacion(int Id,
                                      string empresa,
                                      string titulo,
                                      string mesinicio,
                                      string anoinicio,
                                      string mesfin,
                                      string anofin,
                                      string trabajoactual,
                                      string descripcion,
                                      string agenteId)
        {
            bool isSuccess = true;


            if (string.IsNullOrEmpty(empresa))
                return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(titulo))
                return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(anoinicio))
                return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(mesinicio))
                return Json(new { Response = "Error" });


            if (string.IsNullOrEmpty(anofin))
                return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(mesfin))
                return Json(new { Response = "Error" });

            if (anoinicio == "0")
                return Json(new { Response = "Error" });

            if (mesinicio == "0")
                return Json(new { Response = "Error" });

            var datos = new ExperienciaDTO();
            datos.AgenteId = Convert.ToInt32(agenteId);
            if (string.IsNullOrEmpty(anofin))
                datos.AnoFin = 0;
            else
                datos.AnoFin = Convert.ToInt32(anofin);
            datos.AnoInicio = Convert.ToInt32(anoinicio);
            datos.Descripcion = descripcion;
            datos.Empresa = empresa;
            if (string.IsNullOrEmpty(mesfin))
                datos.MesFin = 0;
            else
                datos.MesFin = Convert.ToInt32(mesfin);
            datos.MesInicio = Convert.ToInt32(mesinicio);
            datos.Tipo = Translator.TranslatorAgentes.Formacion;
            datos.Titulo = titulo;
            datos.TrabajoActual = false;
            ExperienciaNeg.CrearExperiencia(Id, datos);



            return Json(isSuccess);


        }

        public JsonResult AgregarExperiencia(int Id,
                                    string empresa,
                                    string titulo,
                                    string mesinicio,
                                    string anoinicio,
                                    string mesfin,
                                    string anofin,
                                    string trabajoactual,
                                    string descripcion,
                                    string agenteId)
        {
            bool isSuccess = true;


            if (string.IsNullOrEmpty(empresa))
                return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(titulo))
                return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(anoinicio))
                return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(mesinicio))
                return Json(new { Response = "Error" });


            if (string.IsNullOrEmpty(anofin))
                return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(mesfin))
                return Json(new { Response = "Error" });

            if (anoinicio == "0")
                return Json(new { Response = "Error" });

            if (mesinicio == "0")
                return Json(new { Response = "Error" });

            var datos = new ExperienciaDTO();
            datos.AgenteId = Convert.ToInt32(agenteId);
            if (string.IsNullOrEmpty(anofin))
                datos.AnoFin = 0;
            else
                datos.AnoFin = Convert.ToInt32(anofin);
            datos.AnoInicio = Convert.ToInt32(anoinicio);
            datos.Descripcion = descripcion;
            datos.Empresa = empresa;
            if (string.IsNullOrEmpty(mesfin))
                datos.MesFin = 0;
            else
                datos.MesFin = Convert.ToInt32(mesfin);
            datos.MesInicio = Convert.ToInt32(mesinicio);
            datos.Tipo = Translator.TranslatorAgentes.Experiencia;
            datos.Titulo = titulo;
            datos.TrabajoActual = false;
            ExperienciaNeg.CrearExperiencia(Id, datos);



            return Json(isSuccess);


        }

        [HttpPost]
        public JsonResult AgregarOcupacion(string atributo,
                                           string agenteId)
        {
            bool isSuccess = true;

            if (string.IsNullOrEmpty(atributo))
                return Json(new { Response = "Error" });

            AgentesNeg.AgregarOcupacion(Convert.ToInt32(agenteId), atributo);

            return Json(isSuccess);

        }

        [HttpPost]
        public JsonResult AgregarServicio(string atributo,
                                         string agenteId)
        {
            bool isSuccess = true;

            if (string.IsNullOrEmpty(atributo))
                return Json(new { Response = "Error" });

            AgentesNeg.AgregarServicio(Convert.ToInt32(agenteId), atributo);

            return Json(isSuccess);

        }

        [HttpPost]
        public JsonResult AgregarInstrumento(string atributo,
                                            string OficioId,
                                            string agenteId)
        {
            bool isSuccess = true;

            if (string.IsNullOrEmpty(atributo))
                return Json(new { Response = "Error" });

            AgentesNeg.AgregarInstrumentos(Convert.ToInt32(agenteId), Convert.ToInt32(OficioId), atributo);

            return Json(isSuccess);

        }
        [HttpPost]
        public JsonResult AgregarInteres(string atributo,
                                         string agenteId)
        {
            bool isSuccess = true;

            if (string.IsNullOrEmpty(atributo))
                return Json(new { Response = "Error" });

            AgentesNeg.AgregarInteres(Convert.ToInt32(agenteId), atributo);

            return Json(isSuccess);

        }

        public ActionResult CargarOcupacion(int AgenteId, int EliminarId)
        {
            ViewBag.NumeroPasos = 1;
            var listado = new List<OcupacionDTO>();
            if (EliminarId > 0)
            {
                AgentesNeg.EliminarAgenteOcupacion(EliminarId);
            }

            listado = AgentesNeg.ConsultarOcupacionPorAgenteId(AgenteId);

            return PartialView("_TablaOcupacion", listado);
        }

        public ActionResult CargarInstrumentos(int AgenteId, int OficioId, int EliminarId)
        {
            ViewBag.NumeroPasos = 1;
            var listado = new List<OcupacionDTO>();
            if (EliminarId > 0)
            {
                AgentesNeg.EliminarAgenteOcupacion(EliminarId);
            }

            listado = AgentesNeg.ConsultarOcupacionPorAgenteId(AgenteId);

            return PartialView("_TablaOcupacion", listado);
        }

        public ActionResult CargarServicio(int AgenteId, int EliminarId)
        {
            var listado = new List<EstandarDTO>();
            if (EliminarId > 0)
            {
                AgentesNeg.EliminarAgenteServicio(EliminarId);
            }

            listado = AgentesNeg.ConsultarServicioPorAgenteId(AgenteId);

            return PartialView("_TablaServicio", listado);
        }

        public ActionResult CargarInteres(int AgenteId, int EliminarId)
        {
            var listado = new List<EstandarDTO>();
            if (EliminarId > 0)
            {
                AgentesNeg.EliminarAgenteInteres(EliminarId);
            }

            listado = AgentesNeg.ConsultarServicioPorInteresId(AgenteId);

            return PartialView("_TablaInteres", listado);
        }

        [HttpPost]
        public JsonResult CargarLista(string Prefix)
        {
            List<EstandarDTO> listOficios = new List<EstandarDTO>();
            if (TempData["$listOficio"] == null)
            {
                listOficios = CaracterizacionMusicalNeg.ConsultarOficios();
                TempData["$listOficio"] = listOficios;
            }
            else
                listOficios = (List<EstandarDTO>)TempData["$listOficio"];
            //Searching records from list using LINQ query  


            var result3 = listOficios.Where(s => s.Nombre.ToLower().Contains
                     (Prefix.ToLower())).Select(w => w).ToList();


            return Json(result3, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CargarListaInstrumentos(string Prefix)
        {
            List<EstandarDTO> listInstrumentos = new List<EstandarDTO>();
            if (TempData["$listInstrumentos"] == null)
            {
                listInstrumentos = CaracterizacionMusicalNeg.ConsultarInstrumentos();
                TempData["$listInstrumentos"] = listInstrumentos;
            }
            else
                listInstrumentos = (List<EstandarDTO>)TempData["$listInstrumentos"];
            //Searching records from list using LINQ query  


            var result3 = listInstrumentos.Where(s => s.Nombre.ToLower().Contains
                     (Prefix.ToLower())).Select(w => w).ToList();


            return Json(result3, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CargarListaServicio(string Prefix)
        {

            List<EstandarDTO> listOficios = CaracterizacionMusicalNeg.ConsultarServicios();

            var result3 = listOficios.Where(s => s.Nombre.ToLower().Contains
                     (Prefix.ToLower())).Select(w => w).ToList();


            return Json(result3, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CargarListaInteres(string Prefix)
        {

            List<EstandarDTO> listOficios = CaracterizacionMusicalNeg.ConsultarIntereses();

            var result3 = listOficios.Where(s => s.Nombre.ToLower().Contains
                     (Prefix.ToLower())).Select(w => w).ToList();


            return Json(result3, JsonRequestBehavior.AllowGet);
        }
        // GET: /Agente/
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
        public ActionResult Detalle(int Id)
        {
            TempData["imagen"] = "~/img/defaultUser.jpg";
            ViewBag.ImageData = "~/img/defaultUser.jpg";
            var model = new AgentePublicoModels();
            model = Translator.TranslatorAgentes.ConsultarDatosAgentePorId(Id);
        
          
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

        public ActionResult Agregar()
        {

            TempData["imagen"] = "~/img/agente_generico.png";
            ViewBag.ImageData = "~/img/agente_generico.png";
            var model = new AgentePadreModel();
            var modelAgente = new AgenteModel();
            modelAgente.CodigoPais = "52";
            modelAgente.Area = "4";
            model.DatosBasicos = modelAgente;
            CargaInicialAgentes("52", "", "");
            return View(model);

        }

        public ActionResult Crear()
        {
            if (Session["$usuario"] == null)
                return RedirectToAction("Login", "Cuenta");

            TempData["imagen"] = "~/img/defaultUser.jpg";
            ViewBag.ImageData = "~/img/defaultUser.jpg";
            var model = new AgentePadreModel();
            var modelAgente = new AgenteModel();

            model.DatosBasicos = modelAgente;
            CargaInicialAgentes(modelAgente.CodigoPais, modelAgente.CodigoDepartamento, modelAgente.CodigoMunicipio);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Crear(HttpPostedFileBase imagenPerfil, string guardar, AgenteModel modelAgente)
        {
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
               
                int AgenteId = await GuardarNuevoAgente(modelAgente, fileData); 
               
                return RedirectToAction("Editar", "Agente", new { Id = AgenteId });
            }

            TempData["imagen"] = "~/img/defaultUser.jpg";
            ViewBag.ImageData = "~/img/defaultUser.jpg";
            var model = new AgentePadreModel();
            model.DatosBasicos = modelAgente;
            CargaInicialAgentes(modelAgente.CodigoPais, modelAgente.CodigoDepartamento, modelAgente.CodigoMunicipio);
            return View("Agente", model);
        }

        [HttpPost]
        public async Task<ActionResult> Agregar(HttpPostedFileBase imagenPerfil, string guardar, AgenteModel modelAgente)
        {
            var model = new AgentePadreModel();
            TempData["imagen"] = "~/img/agente_generico.png";
            ViewBag.ImageData = "~/img/agente_generico.png";
 
            if (ModelState.IsValid)
            {
                byte[] fileData = null;

                if (AgentesNeg.existenumeroTipoDocumento(modelAgente.NumeroDocumento, Convert.ToInt32(modelAgente.TipoDocumento)))
                {
                    ModelState.AddModelError("", "El tipo de documento y número documento ya se encuentra registrado, por favor, comuníquese con el administrador");
                
                    model.DatosBasicos = modelAgente;
                    CargaInicialAgentes(modelAgente.CodigoPais, modelAgente.CodigoDepartamento, modelAgente.CodigoMunicipio);
                    return View("Agregar", model);
                }

                if (imagenPerfil != null && imagenPerfil.ContentLength > 0)
                {

                    using (var binaryReader = new BinaryReader(imagenPerfil.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(imagenPerfil.ContentLength);
                    }

                }

                int AgenteId = await GuardarAgente(modelAgente, fileData); 

                //int AgenteId = GuardarAgente(modelAgente, fileData);
                return RedirectToAction("Actualizar", "Agente", new { Id = AgenteId });
            }

         
            //List<EstandarDTO> listOficios = CaracterizacionMusicalNeg.ConsultarOficios();
            //List<EstandarDTO> listGeneros = CaracterizacionMusicalNeg.ConsultarGenerosMusicales();
            //List<EstandarDTO> listSeleccionada = new List<EstandarDTO>();
            //TempData["Oficios"] = listOficios;
            //TempData["Generos"] = listGeneros;
            //modelAgente.OficiosData = listOficios;
            //modelAgente.GeneroData = listGeneros;
            //modelAgente.OficiosSeleccionada = listSeleccionada;
            //modelAgente.GenerosSeleccionada = listSeleccionada;
            model.DatosBasicos = modelAgente;
            CargaInicialAgentes(modelAgente.CodigoPais, modelAgente.CodigoDepartamento, modelAgente.CodigoMunicipio);
            return View("Agente", model);
        }


        public ActionResult Agente()
        {
            TempData["imagen"] = "~/img/agente_generico.png";
            ViewBag.ImageData = "~/img/agente_generico.png";
            var model = new AgentePadreModel();
            var modelAgente = new AgenteModel();
            modelAgente = Translator.TranslatorAgentes.ConsultarUsuarioPorId(Convert.ToInt32(UsuaroId));

            modelAgente.CodigoPais = "52";
            modelAgente.Area = "4";
            model.DatosBasicos = modelAgente;
            CargaInicialAgentes("52", modelAgente.CodigoDepartamento, modelAgente.CodigoMunicipio);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Agente(HttpPostedFileBase imagenPerfil, string guardar, AgenteModel modelAgente)
        {
            TempData["imagen"] = "~/img/defaultUser.jpg";
            ViewBag.ImageData = "~/img/defaultUser.jpg";
            var model = new AgentePadreModel();
            if (ModelState.IsValid)
            {
                byte[] fileData = null;
                if (AgentesNeg.existenumeroTipoDocumento(modelAgente.NumeroDocumento, Convert.ToInt32(modelAgente.TipoDocumento)))
                {
                    ModelState.AddModelError("", "El tipo de documento y número documento ya se encuentra registrado, por favor, comuníquese con el administrador");

                    model.DatosBasicos = modelAgente;
                    CargaInicialAgentes(modelAgente.CodigoPais, modelAgente.CodigoDepartamento, modelAgente.CodigoMunicipio);
                    return View("Agente", model);
                }
                if (imagenPerfil != null && imagenPerfil.ContentLength > 0)
                {

                    using (var binaryReader = new BinaryReader(imagenPerfil.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(imagenPerfil.ContentLength);
                    }

                }
 
                int AgenteId = await GuardarAgente(modelAgente, fileData); 
                return RedirectToAction("Editar", "Agente", new { Id = AgenteId });
            }

          
            List<EstandarDTO> listOficios = CaracterizacionMusicalNeg.ConsultarOficios();
            List<EstandarDTO> listGeneros = CaracterizacionMusicalNeg.ConsultarGenerosMusicales();
            List<EstandarDTO> listSeleccionada = new List<EstandarDTO>();
            TempData["Oficios"] = listOficios;
            TempData["Generos"] = listGeneros;
            modelAgente.OficiosData = listOficios;
            modelAgente.GeneroData = listGeneros;
            modelAgente.OficiosSeleccionada = listSeleccionada;
            modelAgente.GenerosSeleccionada = listSeleccionada;
            model.DatosBasicos = modelAgente;
            CargaInicialAgentes(modelAgente.CodigoPais, modelAgente.CodigoDepartamento, modelAgente.CodigoMunicipio);
            return View("Agente", model);
        }

        public ActionResult _AgregarFormacion()
        {
            List<BasicaDTO> listBasicasMeses = BasicaLogica.ConsultarMeses();
            List<BasicaDTO> listAno = BasicaLogica.ConsultarListadoAgenteAnos();
            ViewBag.listMeses = new SelectList(listBasicasMeses, "value", "text");
            ViewBag.listAno = new SelectList(listAno, "value", "text");
            return PartialView("_AgregarFormacion");
        }

        public ActionResult _AgregarExperiencia()
        {
            List<BasicaDTO> listBasicasMeses = BasicaLogica.ConsultarMeses();
            List<BasicaDTO> listAno = BasicaLogica.ConsultarListadoAgenteAnos();
            ViewBag.listMeses = new SelectList(listBasicasMeses, "value", "text");
            ViewBag.listAno = new SelectList(listAno, "value", "text");
            return PartialView("_AgregarExperiencia");
        }

        public ActionResult _TablaFormacion(int Id, int Eliminar)
        {
            var modeltabla = new List<AgenteExperienciaModels>();

            if (Eliminar > 0)
            {
                ExperienciaNeg.EliminarExperiencia(Eliminar);

            }

            modeltabla = Translator.TranslatorAgentes.ConsultarExperiencia(Id, Translator.TranslatorAgentes.Formacion);
            return PartialView("_TablaFormacion", modeltabla);
        }

        public ActionResult _TablaExperiencia(int Id, int Eliminar)
        {
            var modeltabla = new List<AgenteExperienciaModels>();

            if (Eliminar > 0)
            {
                ExperienciaNeg.EliminarExperiencia(Eliminar);

            }

            modeltabla = Translator.TranslatorAgentes.ConsultarExperiencia(Id, Translator.TranslatorAgentes.Experiencia);
            return PartialView("_TablaExperiencia", modeltabla);
        }

        public ActionResult CambiarEstado(int Id)
        {

            TempData["imagen"] = "~/img/agente_generico.png";
            ViewBag.ImageData = "~/img/agente_generico.png";
            ViewBag.NumeroPasos = 1;

            var model = new AgentePadreModel();
            var modelAgente = new AgenteModel();
            var modelExperiencia = new List<AgenteExperienciaModels>();
            var modelFormacion = new List<AgenteExperienciaModels>();
            modelAgente = Translator.TranslatorAgentes.ConsultarAgenteporId(Id);

            ViewBag.Nombre = modelAgente.PrimerNombre + " " + modelAgente.SegundoNombre + " " + modelAgente.PrimerApellido;
            modelExperiencia = Translator.TranslatorAgentes.ConsultarExperiencia(Id, Translator.TranslatorAgentes.Experiencia);
            modelFormacion = Translator.TranslatorAgentes.ConsultarExperiencia(Id, Translator.TranslatorAgentes.Formacion);

            if (modelAgente.imagen != null)
            {
                string imageBase64Data = Convert.ToBase64String(modelAgente.imagen);
                string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                TempData["imagen"] = imageDataURL;
                ViewBag.ImageData = imageDataURL;
            }
            modelAgente.CodigoPais = "52";
            modelAgente.Area = "4";
            model.DatosBasicos = modelAgente;
            CargaInicialAgentes(modelAgente.CodigoPais, modelAgente.CodigoDepartamento, modelAgente.CodigoMunicipio);
            List<BasicaDTO> objTipo = CaracterizacionMusicalNeg.ConsultarEstados();
            ViewBag.listEstado = new SelectList(objTipo, "value", "text");
            return View(model);
        }


        [HttpPost]
        public ActionResult CambiarEstado(int Id, HttpPostedFileBase imagenPerfil, AgenteModel modelAgente)
        {
            string imageDataURL = "";
            var model = new AgentePadreModel();
            ViewBag.NumeroPasos = 1;

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
                    if (modelAgente.imagen != null)
                    {
                        string imageBase64Data = Convert.ToBase64String(modelAgente.imagen);
                        imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                    }
                    else
                    {
                        imageDataURL = "~/img/agente_generico.png";
                    }

                    ViewBag.ImageData = imageDataURL;
                }
                ActualizarAgente(Id, modelAgente, fileData, true);

            }
            else
            {
                if (modelAgente.imagen != null)
                {
                    string imageBase64Data = Convert.ToBase64String(modelAgente.imagen);
                    imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                    ViewBag.ImageData = imageDataURL;
                }
                else
                    ViewBag.ImageData = "~/img/agente_generico.png";
            }
            if (Convert.ToInt32(modelAgente.EstadoId) != Convert.ToInt32(modelAgente.EstadoOldId))
            {
                bool validacionEmail = NotificacionCorreo.IsValidEmail(modelAgente.CorreoElectronico);
                if (validacionEmail)
                    NotificacionCorreo.MensajeNotificaionPorEstado(modelAgente.CorreoElectronico,
                                                                   modelAgente.PrimerNombre + " " + modelAgente.SegundoNombre + " " + modelAgente.PrimerApellido,
                                                                   Convert.ToInt32(modelAgente.EstadoId),
                                                                   "Agentes",
                                                                   Id,
                                                                   Convert.ToInt32(UsuaroId),
                                                                   NombreCompletoUsuario,
                                                                   modelAgente.Motivo);
            }
            model.DatosBasicos = modelAgente;
            CargaInicialAgentes(modelAgente.CodigoPais, modelAgente.CodigoDepartamento, modelAgente.CodigoMunicipio);
            List<BasicaDTO> objTipo = CaracterizacionMusicalNeg.ConsultarEstados();

            ViewBag.listEstado = new SelectList(objTipo, "value", "text");
            Success(string.Format("<b>{0}</b> Se actualizo con éxito el agente: ", modelAgente.PrimerNombre + " " + modelAgente.PrimerApellido), true);
            return View("CambiarEstado", model);
        }

        public ActionResult Actualizar(int Id)
        {

            TempData["imagen"] = "~/img/agente_generico.png";
            ViewBag.ImageData = "~/img/agente_generico.png";
            ViewBag.NumeroPasos = 1;

            var model = new AgentePadreModel();
            var modelAgente = new AgenteModel();
            var modelExperiencia = new List<AgenteExperienciaModels>();
            var modelFormacion = new List<AgenteExperienciaModels>();
            modelAgente = Translator.TranslatorAgentes.ConsultarAgenteporId(Id);
            if (modelAgente.ArtMusicaUsuarioId != Convert.ToInt32(UsuaroId))
            {
                return RedirectToAction("Detalle", "Agente", new { Id = modelAgente.AgenteId });
            }


            ViewBag.Nombre = modelAgente.PrimerNombre + " " + modelAgente.SegundoNombre + " " + modelAgente.PrimerApellido;
            modelExperiencia = Translator.TranslatorAgentes.ConsultarExperiencia(Id, Translator.TranslatorAgentes.Experiencia);
            modelFormacion = Translator.TranslatorAgentes.ConsultarExperiencia(Id, Translator.TranslatorAgentes.Formacion);

            if (modelAgente.imagen != null)
            {
                string imageBase64Data = Convert.ToBase64String(modelAgente.imagen);
                string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                TempData["imagen"] = imageDataURL;
                ViewBag.ImageData = imageDataURL;
            }
            modelAgente.CodigoPais = "52";
            model.DatosBasicos = modelAgente;
            CargaInicialAgentes(modelAgente.CodigoPais, modelAgente.CodigoDepartamento, modelAgente.CodigoMunicipio);
            return View(model);
        }

        [HttpPost]
        public ActionResult Actualizar(int Id, HttpPostedFileBase imagenPerfil, AgenteModel modelAgente)
        {

            string imageDataURL = "";
            var model = new AgentePadreModel();
            ViewBag.NumeroPasos = 1;

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
                    if (modelAgente.imagen != null)
                    {
                        string imageBase64Data = Convert.ToBase64String(modelAgente.imagen);
                        imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                    }
                    else
                    {
                        imageDataURL = "~/img/agente_generico.png";
                    }

                    ViewBag.ImageData = imageDataURL;
                }
                ActualizarAgente(Id, modelAgente, fileData, false);

            }
            else
            {
                if (modelAgente.imagen != null)
                {
                    string imageBase64Data = Convert.ToBase64String(modelAgente.imagen);
                    imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                    ViewBag.ImageData = imageDataURL;
                }
                else
                    ViewBag.ImageData = "~/img/agente_generico.png";
            }

            model.DatosBasicos = modelAgente;
            model.DatosBasicos.AgenteId = Id;
            CargaInicialAgentes(modelAgente.CodigoPais, modelAgente.CodigoDepartamento, modelAgente.CodigoMunicipio);
            Success(string.Format("<b>{0}</b> Se actualizo con éxito el agente: ", modelAgente.PrimerNombre + " " + modelAgente.PrimerApellido), true);
            return View("Actualizar", model);
        }
        public ActionResult Editar(int Id)
        {

            TempData["imagen"] = "~/img/agente_generico.png";
            ViewBag.ImageData = "~/img/agente_generico.png";
            ViewBag.NumeroPasos = 1;

            var model = new AgentePadreModel();
            var modelAgente = new AgenteModel();
            var modelExperiencia = new List<AgenteExperienciaModels>();
            var modelFormacion = new List<AgenteExperienciaModels>();
            modelAgente = Translator.TranslatorAgentes.ConsultarAgenteporId(Id);
            bool Validar = false;
            if (modelAgente.ArtMusicaUsuarioId != Convert.ToInt32(UsuaroId))
            {
               var objetoUsuario = UsuarioLogica.ObtenerUsuarioSIMUSPorUsuarioID(Convert.ToInt32(UsuaroId));
               if (modelAgente.NumeroDocumento.Trim() != objetoUsuario.Identificacion.Trim())
                   return RedirectToAction("DetalleAgente", "Home", new { Id = modelAgente.AgenteId });
               else
                   Validar = true;
            }

            if (Validar)
            {
                ViewBag.Nombre = modelAgente.PrimerNombre + " " + modelAgente.SegundoNombre + " " + modelAgente.PrimerApellido;
                modelExperiencia = Translator.TranslatorAgentes.ConsultarExperiencia(Id, Translator.TranslatorAgentes.Experiencia);
                modelFormacion = Translator.TranslatorAgentes.ConsultarExperiencia(Id, Translator.TranslatorAgentes.Formacion);
            }

            if (modelAgente.imagen != null)
            {
                string imageBase64Data = Convert.ToBase64String(modelAgente.imagen);
                string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                TempData["imagen"] = imageDataURL;
                ViewBag.ImageData = imageDataURL;
            }
            modelAgente.CodigoPais = "52";
            modelAgente.Area = "4";
            model.DatosBasicos = modelAgente;
            CargaInicialAgentes(modelAgente.CodigoPais, modelAgente.CodigoDepartamento, modelAgente.CodigoMunicipio);
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(int Id, HttpPostedFileBase imagenPerfil, AgenteModel modelAgente)
        {

            string imageDataURL = "";
            var model = new AgentePadreModel();
            ViewBag.NumeroPasos = 1;

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
                    if (modelAgente.imagen != null)
                    {
                        string imageBase64Data = Convert.ToBase64String(modelAgente.imagen);
                        imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                    }
                    else
                    {
                        imageDataURL = "~/img/agente_generico.png";
                    }

                    ViewBag.ImageData = imageDataURL;
                }
                ActualizarAgente(Id, modelAgente, fileData, false);

            }
            else
            {
                if (modelAgente.imagen != null)
                {
                    string imageBase64Data = Convert.ToBase64String(modelAgente.imagen);
                    imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                    ViewBag.ImageData = imageDataURL;
                }
                else
                    ViewBag.ImageData = "~/img/agente_generico.png";
            }

            model.DatosBasicos = modelAgente;
            model.DatosBasicos.AgenteId = Id;
            CargaInicialAgentes(modelAgente.CodigoPais, modelAgente.CodigoDepartamento, modelAgente.CodigoMunicipio);
            Success(string.Format("<b>{0}</b> Se actualizo con éxito el agente: ", modelAgente.PrimerNombre + " " + modelAgente.PrimerApellido), true);
            return View("Editar", model);
        }

        #region Grilla


        // [Authorize]
        public ActionResult ExportTo(string OutputFormat)
        {
            var model = new List<AgentePublicoModels>();
            string Busqueda = "";
            model = ObtenerMisregistros(Busqueda);
            return GridViewExtension.ExportToXls(GetGridSettings(), model.ToList());
        }

        // Returns the settings of the exported GridView. 
        private GridViewSettings GetGridSettings()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridAgente";
            settings.CallbackRouteValues = new { Controller = "Agente", Action = "GridViewPartial" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "Agentes" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "AgenteId";
            settings.Columns.Add("Nombres");
            settings.Columns.Add("Apellidos");
            settings.Columns.Add("Departamento");
            settings.Columns.Add("Municipio");
            settings.Columns.Add("Pais");
            settings.Columns.Add("Estado");
            return settings;
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial(string Busqueda = null, string filtro = null)
        {
            ViewBag.GridSettings = GetGridSettings();
            var model = new List<AgentePublicoModels>();

            model = ObtenerMisregistros(Busqueda);

            return PartialView("_GridViewPartial", model);
        }

        private List<AgentePublicoModels> ObtenerMisregistros(string Busqueda = null)
        {
            var model = new List<AgentePublicoModels>();
            
            if (string.IsNullOrEmpty(Busqueda))
            {
                if (TempData["TipoRegistroA"] != null)
                    Busqueda = TempData["TipoRegistroA"].ToString();
                else
                    Busqueda = "1";
            }

            if (Busqueda == "1")
            {
                model = TranslatorAgentes.ConsultarAgentesPorUsuarioId(Convert.ToInt32(UsuaroId));
                TempData["TipoRegistroA"] = 1;
            }
            else if (Busqueda == "2")
            {
                TempData["TipoRegistroA"] = 2;
                model = TranslatorAgentes.ConsultarAgentesPorEstadoId(Comunes.ConstantesRecursosBD.CODIGO_ESTADO_PUBLICADO);
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
      
        #endregion

        #region Grilla


        // [Authorize]
        public ActionResult ExportToPermisos(string OutputFormat)
        {
            var model = new List<AgenteListadoDTO>();
            model = ObtenerResultadoGestion();

            return GridViewExtension.ExportToXls(GetGridSettingsPermisos(), model.ToList());
        }

        // Returns the settings of the exported GridView. 
        private GridViewSettings GetGridSettingsPermisos()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridPermisos";
            settings.CallbackRouteValues = new { Controller = "Agente", Action = "GridViewPartialPermisos" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            // Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "AgentesPermisos" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;

            settings.KeyFieldName = "AgenteId";
            settings.Columns.Add("Nombres");
            settings.Columns.Add("Apellidos");
            settings.Columns.Add("Departamento");
            settings.Columns.Add("Municipio");
            settings.Columns.Add("FechaActualizacion");
            settings.Columns.Add("FechaCreacion");
            settings.Columns.Add("Estado");
            return settings;
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartialPermisos()
        {
            ViewBag.GridSettings = GetGridSettingsPermisos();
            var model = new List<AgenteListadoDTO>();

            model = ObtenerResultadoGestion();

            return PartialView("_GridViewPermisos", model);
        }

        private List<AgenteListadoDTO> ObtenerResultadoGestion()
        {
            bool EsAdmin = false;
            var model = new List<AgenteListadoDTO>();
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
                model = AgentesNeg.ConsultarAgentesTodos();
            else
                model = AgentesNeg.ConsultarAgentesPermisosTodos(Convert.ToInt32(UsuaroId));
            return model;
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialPermisosDelete(int AgenteId)
        {
            var model = new List<AgentePublicoModels>();

            try
            {
               
            }
            catch (Exception e)
            {
                ViewData["EditError"] = e.Message;
            }

            return PartialView("_GridViewPermisos", model);
        }
        #endregion
        #region Metodosprivados

        private async Task<int> GuardarNuevoAgente(AgenteModel model, byte[] imagen)
        {
            var agente = new AgenteDTO();
            int AgenteId = 0;
          
            UsuarioDTOSIM usuario = (UsuarioDTOSIM)Session["$usuario"];

            if (model != null)
            {
                agente.AgenteId = AgenteId;
                agente.ArtMusicaUsuarioId = usuario.Id;
                if (!string.IsNullOrEmpty(model.CodigoDepartamento))
                {
                    if (model.CodigoDepartamento.Trim() == "Seleccione un departamento")
                        agente.CodigoDepartamento = "";
                    else
                        agente.CodigoDepartamento = model.CodigoDepartamento;
                }
                else
                    agente.CodigoDepartamento = "";
                if (!string.IsNullOrEmpty(model.CodigoMunicipio))
                {
                    if (model.CodigoMunicipio.Trim() == "Seleccione un municipio")
                        agente.CodigoMunicipio = "";
                    else
                        agente.CodigoMunicipio = model.CodigoMunicipio;
                }
                else
                    agente.CodigoMunicipio = "";
                if (!string.IsNullOrEmpty(model.CodigoPais))
                    agente.CodigoPais = model.CodigoPais;
                else
                    agente.CodigoPais = "";

                if (!string.IsNullOrEmpty(model.Area))
                    agente.CodigoArea = model.Area;
                else
                    agente.CodigoArea = "";

                if (!string.IsNullOrEmpty(model.CorreoElectronico))
                    agente.CorreoElectronico = model.CorreoElectronico;

                if (!string.IsNullOrEmpty(model.Direccion))
                    agente.Direccion = model.Direccion;

                if (!string.IsNullOrEmpty(model.Descripcion))
                    agente.Descripcion = model.Descripcion;

                agente.FechaNacimiento = model.FechaNacimiento;

                if (imagen != null)
                    agente.imagen = imagen;
                else
                    agente.imagen = null;
                if (!string.IsNullOrEmpty(model.linkPortafolio))
                    agente.linkPortafolio = model.linkPortafolio;
                if (!string.IsNullOrEmpty(model.NumeroDocumento))
                    agente.NumeroDocumento = model.NumeroDocumento;
                if (!string.IsNullOrEmpty(model.PrimerApellido))
                    agente.PrimerApellido = model.PrimerApellido;
                if (!string.IsNullOrEmpty(model.PrimerNombre))
                    agente.PrimerNombre = model.PrimerNombre;
                if (!string.IsNullOrEmpty(model.SegundoApellido))
                    agente.SegundoApellido = model.SegundoApellido;
                if (!string.IsNullOrEmpty(model.SegundoNombre))
                    agente.SegundoNombre = model.SegundoNombre;
                if (!string.IsNullOrEmpty(model.NombreArtistico))
                    agente.NombreArtistico = model.NombreArtistico;
                if (!string.IsNullOrEmpty(model.Sexo))
                {
                    if (model.Sexo == "Femenino")
                        agente.Sexo = "F";
                    else if (model.Sexo == "Masculino")
                        agente.Sexo = "M";

                }
                if (!string.IsNullOrEmpty(model.Telefono))
                    agente.Telefono = model.Telefono;
                if (!string.IsNullOrEmpty(model.TipoDocumento))
                    agente.TipoDocumento = model.TipoDocumento;

                string ip = Request.UserHostAddress;
                AgenteId = AgentesNeg.Crear(agente, ip, usuario.PrimerNombre + " " + usuario.PrimerApellido);

                 //AgentesNeg objAgentes = new AgentesNeg();
                string path = System.Web.Configuration.WebConfigurationManager.AppSettings["UrlWebApiSinic"];
                decimal UsuarioSipaId = UsuarioLogica.ObtenerUsuarioSipaId(Usuario);
                try
                {
                    int intResult = await AgentesNeg.CrearAgenteSinic(path, agente, UsuarioSipaId);
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                }

            }
            return AgenteId;
        }
        private async Task<int> GuardarAgente(AgenteModel model, byte[] imagen)
        {
            var agente = new AgenteDTO();
            int AgenteId = 0;



            if (model != null)
            {
                agente.AgenteId = AgenteId;
                agente.ArtMusicaUsuarioId = Convert.ToInt32(UsuaroId);
                if (!string.IsNullOrEmpty(model.CodigoDepartamento))
                {
                    if (model.CodigoDepartamento.Trim() == "Seleccione un departamento")
                        agente.CodigoDepartamento = "";
                    else
                        agente.CodigoDepartamento = model.CodigoDepartamento;
                }
                else
                    agente.CodigoDepartamento = "";
                if (!string.IsNullOrEmpty(model.CodigoMunicipio))
                {
                    if (model.CodigoMunicipio.Trim() == "Seleccione un municipio")
                        agente.CodigoMunicipio = "";
                    else
                        agente.CodigoMunicipio = model.CodigoMunicipio;
                }
                else
                    agente.CodigoMunicipio = "";

                agente.CodigoPais = "52";
                if (!string.IsNullOrEmpty(model.CorreoElectronico))
                    agente.CorreoElectronico = model.CorreoElectronico;
                if (!string.IsNullOrEmpty(model.Direccion))
                    agente.Direccion = model.Direccion;
                agente.FechaNacimiento = model.FechaNacimiento;

                if (imagen != null)
                    agente.imagen = imagen;
                else
                    agente.imagen = null;
                if (!string.IsNullOrEmpty(model.linkPortafolio))
                    agente.linkPortafolio = model.linkPortafolio;
                if (!string.IsNullOrEmpty(model.NumeroDocumento))
                    agente.NumeroDocumento = model.NumeroDocumento;
                if (!string.IsNullOrEmpty(model.PrimerApellido))
                    agente.PrimerApellido = model.PrimerApellido;
                if (!string.IsNullOrEmpty(model.PrimerNombre))
                    agente.PrimerNombre = model.PrimerNombre;
                if (!string.IsNullOrEmpty(model.SegundoApellido))
                    agente.SegundoApellido = model.SegundoApellido;
                if (!string.IsNullOrEmpty(model.SegundoNombre))
                    agente.SegundoNombre = model.SegundoNombre;
                if (!string.IsNullOrEmpty(model.Sexo))
                {
                    if (model.Sexo == "Femenino")
                        agente.Sexo = "F";
                    else if (model.Sexo == "Masculino")
                        agente.Sexo = "M";

                }
                if (!string.IsNullOrEmpty(model.Telefono))
                    agente.Telefono = model.Telefono;
                if (!string.IsNullOrEmpty(model.TipoDocumento))
                    agente.TipoDocumento = model.TipoDocumento;

                agente.NombreArtistico = model.NombreArtistico;
                agente.Descripcion = model.Descripcion;
                agente.CodigoArea = model.Area;
                string ip = Request.UserHostAddress;
                AgenteId = AgentesNeg.CrearAgente(agente, ip, NombreCompletoUsuario);

                string path = System.Web.Configuration.WebConfigurationManager.AppSettings["UrlWebApiSinic"];
                decimal UsuarioSipaId = UsuarioLogica.ObtenerUsuarioSipaId(Usuario);

                try
                {
                    int intResult = await AgentesNeg.CrearAgenteSinic(path, agente, UsuarioSipaId);
                }
                catch(Exception ex)
                {
                    string error = ex.Message;
                }
              
              

            }
            return AgenteId;
        }

        private void ActualizarAgente(int Id, AgenteModel model, byte[] imagen, bool cambiar)
        {
            var agente = new AgenteDTO();

            if (model != null)
            {
                agente.AgenteId = Id;
                agente.Direccion = " ";
                agente.ArtMusicaUsuarioId = Convert.ToInt32(UsuaroId);
                if (!string.IsNullOrEmpty(model.CodigoDepartamento))
                {
                    if (model.CodigoDepartamento.Trim() == "Seleccione un departamento")
                        agente.CodigoDepartamento = "";
                    else
                        agente.CodigoDepartamento = model.CodigoDepartamento;
                }
                else
                    agente.CodigoDepartamento = "";
                if (!string.IsNullOrEmpty(model.CodigoMunicipio))
                {
                    if (model.CodigoMunicipio.Trim() == "Seleccione un municipio")
                        agente.CodigoMunicipio = "";
                    else
                        agente.CodigoMunicipio = model.CodigoMunicipio;
                }
                else
                    agente.CodigoMunicipio = "";

                agente.CodigoPais = "52";

                if (!string.IsNullOrEmpty(model.Area))
                    agente.CodigoArea = model.Area;
                else
                    agente.CodigoArea = "";

                if (!string.IsNullOrEmpty(model.CorreoElectronico))
                    agente.CorreoElectronico = model.CorreoElectronico;
                if (!string.IsNullOrEmpty(model.Direccion))
                    agente.Direccion = model.Direccion;
                if (!string.IsNullOrEmpty(model.Descripcion))
                    agente.Descripcion = model.Descripcion;
                agente.FechaNacimiento = model.FechaNacimiento;


                if (!string.IsNullOrEmpty(model.linkPortafolio))
                    agente.linkPortafolio = model.linkPortafolio;
                if (!string.IsNullOrEmpty(model.NumeroDocumento))
                    agente.NumeroDocumento = model.NumeroDocumento;
                if (!string.IsNullOrEmpty(model.PrimerApellido))
                    agente.PrimerApellido = model.PrimerApellido;
                if (!string.IsNullOrEmpty(model.PrimerNombre))
                    agente.PrimerNombre = model.PrimerNombre;
                if (!string.IsNullOrEmpty(model.SegundoApellido))
                    agente.SegundoApellido = model.SegundoApellido;
                if (!string.IsNullOrEmpty(model.SegundoNombre))
                    agente.SegundoNombre = model.SegundoNombre;
                if (!string.IsNullOrEmpty(model.NombreArtistico))
                    agente.NombreArtistico = model.NombreArtistico;
                if (!string.IsNullOrEmpty(model.Sexo))
                {
                    if (model.Sexo == "Femenino")
                        agente.Sexo = "F";
                    else if (model.Sexo == "Masculino")
                        agente.Sexo = "M";

                }
                if (!string.IsNullOrEmpty(model.Telefono))
                    agente.Telefono = model.Telefono;
                if (!string.IsNullOrEmpty(model.TipoDocumento))
                    agente.TipoDocumento = model.TipoDocumento;

                if (imagen != null)
                    agente.imagen = imagen;

                agente.NombreArtistico = model.NombreArtistico;
                agente.Descripcion = model.Descripcion;
                agente.CodigoArea = model.Area;

                if (cambiar)
                {
                    if (!string.IsNullOrEmpty(model.EstadoId))
                        agente.EstadoId = Convert.ToInt32(model.EstadoId);
                    else
                        agente.EstadoId = 0;
                }

                string ip = Request.UserHostAddress;
                agente.ArtMusicaUsuarioId = Convert.ToInt32(UsuaroId);
                AgentesNeg.ActualizarAgente(agente, cambiar, ip, NombreCompletoUsuario);

            }

        }
        private void CargaInicialAgentes(string codigoPais, string codigoDepartamento, string codigoMunicipio)
        {
            List<BasicaDTO> lsttipoDoc = BasicaLogica.ConsultarTiposDocumentos();
            ViewBag.listTipoDocumento = new SelectList(lsttipoDoc, "value", "text");

            List<BasicaDTO> lstArea = ZonaGeograficasLogica.ConsultarAreas();
            ViewBag.listArea = new SelectList(lstArea, "value", "text");

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

        #region ConsultasJson
        public JsonResult ObtenerMunicipio(string departamento = null)
        {
            List<BasicaDTO> listMunicipios = new List<BasicaDTO>();

            if (!String.IsNullOrEmpty(departamento))
            {
                listMunicipios = ZonaGeograficasLogica.ConsultarMunicipios(departamento);
            }

            return Json(listMunicipios, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerDepartamento(string codigopais = null)
        {
            List<BasicaDTO> listDpto = new List<BasicaDTO>();
            ViewBag.esColombia = true;

            if (!String.IsNullOrEmpty(codigopais) && codColombia == codigopais)
            {
                ViewBag.esColombia = false;
                listDpto = ZonaGeograficasLogica.ConsultarDepartamentos();
            }

            return Json(listDpto, JsonRequestBehavior.AllowGet);
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


            var model = new HandleErrorInfo(filterContext.Exception, "AgenteController", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }
        #endregion
    }
}