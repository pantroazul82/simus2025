using SM.Aplicacion.Basicas;
using SM.Aplicacion.Escuelas;
using SM.Aplicacion.Modulo_Usuarios;
using SM.Aplicacion.Servicios;
using SM.LibreriaComun.DTO;
using SM.LibreriaComun.DTO.FichaAsesoria;
using SM.Utilidades.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSImus.Controllers
{
    [HandleError()]
    [SessionExpire]
    public class FichaAsesoriaController : BaseController
    {
        // GET: FichaAsesoria

        #region Instrumentos

        public ActionResult _AgregarInstrumento(string id, string escuelaId)
        {
            var model = new InstrumentoNuevoDTO();
            model.Id = 0;

            if (!string.IsNullOrEmpty(id))
            {
                model.Id = Convert.ToInt32(id);

            }

            if (!string.IsNullOrEmpty(escuelaId))
            {
                model.EscuelaId = Convert.ToDecimal(escuelaId);
            }

            ViewBag.listaInstrumento = new SelectList(CaracterizacionMusicalNeg.ConsultarListadoInstrumentos(), "value", "text");
            return PartialView("_AgregarInstrumento", model);
        }

        [HttpPost]
        public JsonResult AgregarInstrumento(string Id, string EscuelaId, InstrumentoNuevoDTO model)
        {
            bool isSuccess = true;
            int Total = 0;

            Total = model.CantidadBuenos + model.CantidadMalos + model.CantidadRegular + model.CantidadPerdidos;


            InstrumentoNuevoDTO registro = new InstrumentoNuevoDTO
            {
                CantidadBuenos = model.CantidadBuenos,
                CantidadMalos = model.CantidadMalos,
                CantidadMincultura = model.CantidadMincultura,
                CantidadRegular = model.CantidadRegular,
                Descripcion = model.Descripcion,
                EscuelaId = Convert.ToDecimal(EscuelaId),
                InstrumentoId = model.InstrumentoId,
                CantidadPerdidos = model.CantidadPerdidos,
                Total = Total
            };
            if (String.IsNullOrEmpty(Id) || (Id == "0"))
                InstrumentoNeg.Crear(registro, Convert.ToInt32(UsuaroId));
            else
                InstrumentoNeg.Actualizar(Convert.ToInt32(Id), registro, Convert.ToInt32(UsuaroId));

            return Json(isSuccess);
        }

        public ActionResult TablaInstrumento(string EscuelaId, int EliminarId)
        {
            var listado = new List<InstrumentoNuevoDTO>();
            if (EliminarId > 0)
            {
                InstrumentoNeg.Eliminar(EliminarId);
            }

            listado = InstrumentoNeg.ConsultarPorEscuelaId(Convert.ToDecimal(EscuelaId));

            return PartialView("_TablaInstrumento", listado);
        }
        #endregion

        #region Repertorios

        public ActionResult _AgregarRepertorio(string id, string escuelaId)
        {
            var model = new RepertorioNuevoDTO();
            model.Id = 0;

            if (!string.IsNullOrEmpty(id))
            {
                model.Id = Convert.ToInt32(id);

            }

            if (!string.IsNullOrEmpty(escuelaId))
            {
                model.EscuelaId = Convert.ToDecimal(escuelaId);
            }

            return PartialView("_AgregarRepertorio", model);
        }

        [HttpPost]
        public JsonResult AgregarRepertorio(string Id, string EscuelaId, RepertorioNuevoDTO model)
        {
            bool isSuccess = true;


            RepertorioNuevoDTO registro = new RepertorioNuevoDTO
            {
                Arreglista = model.Arreglista,
                Compositor = model.Compositor,
                Dificultad = model.Dificultad,
                EscuelaId = Convert.ToDecimal(EscuelaId),
                Nombre = model.Nombre

            };
            if (String.IsNullOrEmpty(Id) || (Id == "0"))
                RepositorioNeg.Crear(registro, Convert.ToInt32(UsuaroId));
            else
                RepositorioNeg.Actualizar(Convert.ToInt32(Id), registro, Convert.ToInt32(UsuaroId));

            return Json(isSuccess);
        }

        public ActionResult TablaRepertorio(string EscuelaId, int EliminarId)
        {
            var listado = new List<RepertorioNuevoDTO>();
            if (EliminarId > 0)
            {
                RepositorioNeg.Eliminar(EliminarId);
            }

            listado = RepositorioNeg.ConsultarPorEscuelaId(Convert.ToDecimal(EscuelaId));

            return PartialView("_TablaRepertorio", listado);
        }
        #endregion

        #region Observaciones

        public ActionResult _AgregarObservacion(string id, string tipo, string escuelaId)
        {
            var model = new ObservacionNuevoDTO();

            if (!string.IsNullOrEmpty(id))
            {
                model.Id = Convert.ToInt32(id);

            }

            if (!string.IsNullOrEmpty(escuelaId))
            {
                model.EscuelaId = Convert.ToDecimal(escuelaId);
            }

            model = ObservacionNeg.ConsultarPorTipo(Convert.ToDecimal(escuelaId), tipo);
            model.Tipo = tipo;

            return PartialView("_AgregarObservacion", model);
        }

        [HttpPost]
        public JsonResult AgregarObservacion(string EscuelaId, ObservacionNuevoDTO model)
        {
            bool isSuccess = true;

            ObservacionNuevoDTO registro = new ObservacionNuevoDTO
            {
                EscuelaId = Convert.ToDecimal(EscuelaId),
                Observaciones = model.Observaciones,
                Recomendaciones = model.Recomendaciones,
                Tipo = model.Tipo

            };

            ObservacionNeg.Crear(registro, Convert.ToInt32(UsuaroId));

            return Json(isSuccess);
        }

        public ActionResult TablaObservacion(string EscuelaId, string tipo, int EliminarId)
        {
            var listado = new ObservacionNuevoDTO();
            if (EliminarId > 0)
            {
                ObservacionNeg.Eliminar(EliminarId);
            }

            listado = ObservacionNeg.ConsultarPorTipo(Convert.ToDecimal(EscuelaId), tipo);

            return PartialView("_TablaObservacion", listado);
        }
        #endregion

        #region Clasificacion

        public ActionResult _AgregarClasificacion(string id, string escuelaId, string tipo)
        {
            var model = new ClasificacionNuevoDTO();

            if (!string.IsNullOrEmpty(id))
            {
                model.Id = Convert.ToInt32(id);
                model = ClasificacionNeg.ConsultarPorId(Convert.ToInt32(id));

            }

            if (!string.IsNullOrEmpty(escuelaId))
            {
                model.EscuelaId = Convert.ToDecimal(escuelaId);
            }

            ViewBag.logica = new SelectList(BasicaLogica.ConsultarSINO(), "value", "text");
            //ViewBag.listaClasificacion = new SelectList(BasicaLogica.ConsultarParametrosPorCategoria(tipo), "value", "text");
            model.Tipo = tipo;
           
            return PartialView("_AgregarClasificacion", model);
        }

        [HttpPost]
        public JsonResult AgregarClasificacion(string Id, string EscuelaId, ClasificacionNuevoDTO model)
        {
            bool isSuccess = true;



            ClasificacionNuevoDTO registro = new ClasificacionNuevoDTO
            {
                EscuelaId = model.EscuelaId,
                Bueno = model.Bueno,
                Clasificacion = model.Clasificacion,
                ClasificacionId = model.ClasificacionId,
                DEFICIENTE = model.DEFICIENTE,
                NOSEREALIZA = model.NOSEREALIZA,
                REGULAR = model.REGULAR,
                Tipo = model.Tipo
            };
            if (String.IsNullOrEmpty(Id) || (Id == "0"))
                ClasificacionNeg.Crear(registro, Convert.ToInt32(UsuaroId));
            else
                ClasificacionNeg.Actualizar(Convert.ToInt32(Id), registro, Convert.ToInt32(UsuaroId));

            return Json(isSuccess);
        }

        public ActionResult TablaClasificacion(string EscuelaId, string tipo, int EliminarId)
        {
            var listado = new List<ClasificacionNuevoDTO>();
            if (EliminarId > 0)
            {
                // ClasificacionNeg.Eliminar(EliminarId);
            }

            listado = ClasificacionNeg.ConsultarPorEscuelaId(Convert.ToDecimal(EscuelaId), tipo);

            return PartialView("_TablaClasificacion", listado);
        }
        #endregion

        #region Matriz

        public ActionResult _AgregarMatriz(string id, string escuelaId, string tipo)
        {
            var model = new MatrizNuevoDTO();

            if (!string.IsNullOrEmpty(id))
            {
                model.Id = Convert.ToInt32(id);
                model = MatrizNeg.ConsultarPorId(Convert.ToInt32(id));
            }

            if (!string.IsNullOrEmpty(escuelaId))
            {
                model.EscuelaId = Convert.ToDecimal(escuelaId);
            }
          ViewBag.listaClasificacion = new SelectList(BasicaLogica.ConsultarParametrosPorCategoria(tipo), "value", "text");
            model.TipoM = tipo;
           return PartialView("_AgregarMatriz", model);
        }

        [HttpPost]
        public JsonResult AgregarMatriz(string Id, string EscuelaId, MatrizNuevoDTO model)
        {
            bool isSuccess = true;



            MatrizNuevoDTO registro = new MatrizNuevoDTO
            {
                EscuelaId = model.EscuelaId,
                Clasificacion = model.Clasificacion,
                ClasificacionId = model.ClasificacionId,
                Dificultades = model.Dificultades,
                Fortaleza = model.Fortaleza,
                TipoM = model.TipoM
            };
            if (String.IsNullOrEmpty(Id) || (Id == "0"))
                MatrizNeg.Crear(registro, Convert.ToInt32(UsuaroId));
            else
                MatrizNeg.Actualizar(Convert.ToInt32(Id), registro, Convert.ToInt32(UsuaroId));

            return Json(isSuccess);
        }

        public ActionResult TablaMatriz(string EscuelaId, string tipo, int EliminarId)
        {
            var listado = new List<MatrizNuevoDTO>();
            if (EliminarId > 0)
            {
                // ClasificacionNeg.Eliminar(EliminarId);
            }

            listado = MatrizNeg.ConsultarPorEscuelaId(Convert.ToDecimal(EscuelaId), tipo);

            return PartialView("_TablaMatriz", listado);
        }
        #endregion

        #region Asesoria

        [HttpPost]
        public JsonResult AgregarAsesoria(string EscuelaId, AsesoriaNuevoDTO model)
        {
            bool isSuccess = true;

            if (!String.IsNullOrEmpty(EscuelaId))
            {
                GrabarAsesoria(model, Convert.ToInt32(EscuelaId));
            }

            return Json(isSuccess);
        }


        [HttpPost]
        public JsonResult AgregarConcepto(string EscuelaId, AsesoriaConceptoDTO model)
        {
            bool isSuccess = true;

            if (!String.IsNullOrEmpty(EscuelaId))
            {
                GrabarConcepto(model, Convert.ToInt32(EscuelaId));
            }

            return Json(isSuccess);
        }
        public ActionResult Asesoria(int Id)
        {
            bool EsAdmin = false;
            bool EsCoordinador = false;
          
            if (String.IsNullOrEmpty(UsuaroId))
                return RedirectToAction("Login", "Cuenta");

            EsAdmin = UsuarioLogica.UsuarioEsAdmin(Convert.ToInt32(UsuaroId), Comunes.ConstantesRecursosBD.CODIGO_ADMIN);

            if (!EsAdmin)
            {
                EsCoordinador = UsuarioLogica.UsuarioEsCoordinadorAsesor(Convert.ToInt32(UsuaroId), Comunes.ConstantesRecursosBD.CODIGO_COORDINADOR, Comunes.ConstantesRecursosBD.CODIGO_ASESOR);
                if (!EsCoordinador)
                {
            
                    return RedirectToAction("EditarNuevo", "EscuelasMusica", new { Id = Id, wizard = 0 });
                }
            }
            ViewBag.Anos = new SelectList(BasicaLogica.ConsultarListadoAnos(), "value", "text");
            ViewBag.logica = new SelectList(BasicaLogica.ConsultarSINO(), "value", "text");
            ViewBag.NombreEscuela = EscuelasLogica.ObtenerNombreEscuela(Id)  +" - " + ZonaGeograficasLogica.ObtenerNombresPorEscuelaId(Id);
            var model = new AsesoriaEscuelaDTO();
          
            model.Asesoria = AsesoriaNeg.ConsultarPorEscuelaId(Id);
            model.Concepto = AsesoriaNeg.ConsultarConceptoPorEscuelaId(Id);
            if ((model.Asesoria == null) || (model.Asesoria.EscuelaId == 0))
            {
                CrearAsesoria(Id);
                ValidarFichaClasificacion(Id);
                ValidarFichaMatriz(Id);     
            }
            model.EscuelaId = Id;
            return View(model);
        }

        [HttpPost]
        public ActionResult Asesoria(int Id, AsesoriaNuevoDTO model)
        {
            string Mensaje = "";
            string NombreEscuela = "";

            if (ModelState.IsValid)
            {
                NombreEscuela = EscuelasLogica.ObtenerNombreEscuela(Id);
                ViewBag.NombreEscuela = NombreEscuela + " - " + ZonaGeograficasLogica.ObtenerNombresPorEscuelaId(Id);


                if (String.IsNullOrEmpty(Mensaje))
                {
                    GrabarAsesoria(model, Id);

                    // BasicaDTO nombres = ZonaGeograficasLogica.ObtenerNombres(model.MunicipioSelector);
                    BasicaDTO nombres = new BasicaDTO();
                    string mensaje = "La escuela de música con el Id: " + Id.ToString() + ". Nombre: " + NombreEscuela;
                    if (nombres != null)
                    {
                        mensaje += ". Departamento: " + nombres.value + "  Municipio: " + nombres.text;
                    }
                    mensaje += ".  Ha sido actualizada en la sección de formación por el usuario.  " + NombreCompletoUsuario;



                }

            }

            model.EscuelaId = Id;
            ViewBag.Anos = new SelectList(BasicaLogica.ConsultarListadoAnos(), "value", "text");
            ViewBag.logica = new SelectList(BasicaLogica.ConsultarSINO(), "value", "text");
            ViewBag.NombreEscuela = EscuelasLogica.ObtenerNombreEscuela(Id);
            if (string.IsNullOrEmpty(Mensaje))
                Success(string.Format("<b>{0}</b> Se actualizo con éxito", NombreEscuela), true);
            else
                Warning(string.Format(Mensaje), true);
            return View("Asesoria", model);
        }
        #endregion

        #region MetodosPrivados
        private void GrabarAsesoria(AsesoriaNuevoDTO datos, int EscuelaId)
        {
            try
            {
                AsesoriaNeg.Actualizar(EscuelaId, datos, Convert.ToInt32(UsuaroId));

            }
            catch (Exception ex)
            { throw ex; }
        }

        private void GrabarConcepto(AsesoriaConceptoDTO datos, int EscuelaId)
        {
            try
            {
                AsesoriaNeg.ActualizarConcepto(EscuelaId, datos, Convert.ToInt32(UsuaroId));

            }
            catch (Exception ex)
            { throw ex; }
        }


        private void ValidarFichaClasificacion(decimal Id)
        {
            List<BasicaDTO> listadoClasificacion = new List<BasicaDTO>();
            List<ClasificacionNuevoDTO> model = ClasificacionNeg.ValidarExisteEscuela(Id);

            if ((model == null) || (model.Count == 0))
            {
                //Técnica
                listadoClasificacion = BasicaLogica.ConsultarParametrosPorCategoria(Comunes.ConstantesRecursosBD.FICHA_CLASIFICACION_TECNICA);
                foreach (var item in listadoClasificacion)
                {
                    CrearClasificación(Id, Comunes.ConstantesRecursosBD.FICHA_CLASIFICACION_TECNICA, Convert.ToInt32(item.value), item.text);
                }
                //Técnica instrumental
                listadoClasificacion = new List<BasicaDTO>();
                listadoClasificacion = BasicaLogica.ConsultarParametrosPorCategoria(Comunes.ConstantesRecursosBD.FICHA_CLASIFICACION_TECNICA_INSTRUMENTAL);
                foreach (var item in listadoClasificacion)
                {
                    CrearClasificación(Id, Comunes.ConstantesRecursosBD.FICHA_CLASIFICACION_TECNICA_INSTRUMENTAL, Convert.ToInt32(item.value), item.text);
                }

                //Comunicación
                listadoClasificacion = new List<BasicaDTO>();
                listadoClasificacion = BasicaLogica.ConsultarParametrosPorCategoria(Comunes.ConstantesRecursosBD.FICHA_CLASIFICACION_TECNICA_COMUNICACION);
                foreach (var item in listadoClasificacion)
                {
                    CrearClasificación(Id, Comunes.ConstantesRecursosBD.FICHA_CLASIFICACION_TECNICA_COMUNICACION, Convert.ToInt32(item.value), item.text);
                }

                //Técnica instrumental
                listadoClasificacion = new List<BasicaDTO>();
                listadoClasificacion = BasicaLogica.ConsultarParametrosPorCategoria(Comunes.ConstantesRecursosBD.FICHA_CLASIFICACION_TECNICA_EVALUACION);
                foreach (var item in listadoClasificacion)
                {
                    CrearClasificación(Id, Comunes.ConstantesRecursosBD.FICHA_CLASIFICACION_TECNICA_EVALUACION, Convert.ToInt32(item.value), item.text);
                }

            }

        }

        private void ValidarFichaMatriz(decimal Id)
        {
            List<BasicaDTO> listadoClasificacion = new List<BasicaDTO>();
            List<MatrizNuevoDTO> model = MatrizNeg.ValidarExisteEscuela(Id);

            if ((model == null) || (model.Count == 0))
            {
                //Observacion
                listadoClasificacion = BasicaLogica.ConsultarParametrosPorCategoria(Comunes.ConstantesRecursosBD.FICHA_MATRIZ_OBSERVACION);
                foreach (var item in listadoClasificacion)
                {
                    CrearMatriz(Id, Comunes.ConstantesRecursosBD.FICHA_MATRIZ_OBSERVACION, Convert.ToInt32(item.value), item.text);
                }
                //Proceso
                listadoClasificacion = new List<BasicaDTO>();
                listadoClasificacion = BasicaLogica.ConsultarParametrosPorCategoria(Comunes.ConstantesRecursosBD.FICHA_MATRIZ_PROCESO);
                foreach (var item in listadoClasificacion)
                {
                    CrearMatriz(Id, Comunes.ConstantesRecursosBD.FICHA_MATRIZ_PROCESO, Convert.ToInt32(item.value), item.text);
                }

              

            }

        }

        private void CrearClasificación(decimal EscuelaId, string tipo, int ClasificacionId, string Clasificacion)
        {

            try
            {
                ClasificacionNuevoDTO registro = new ClasificacionNuevoDTO
                {
                    EscuelaId = EscuelaId,
                    Bueno = " ",
                    Clasificacion = Clasificacion,
                    ClasificacionId = ClasificacionId,
                    DEFICIENTE = " ",
                    NOSEREALIZA = " ",
                    REGULAR = " ",
                    Tipo = tipo
                };

                ClasificacionNeg.Crear(registro, Convert.ToInt32(UsuaroId));


            }
            catch (Exception ex)
            { throw ex; }
        }

        private void CrearMatriz(decimal EscuelaId, string tipo, int ClasificacionId, string Clasificacion)
        {

            try
            {
                MatrizNuevoDTO registro = new MatrizNuevoDTO
                {
                    EscuelaId = EscuelaId,
                    Clasificacion = Clasificacion,
                    ClasificacionId = ClasificacionId,
                    Fortaleza = "",
                    Dificultades = "",
                    TipoM = tipo
                };

                MatrizNeg.Crear(registro, Convert.ToInt32(UsuaroId));


            }
            catch (Exception ex)
            { throw ex; }
        }

        private void CrearAsesoria(decimal Id)
        {

            try
            {
                AsesoriaNuevoDTO registro = new AsesoriaNuevoDTO
                {
                    EscuelaId = Id,

                    NombreAgrupacion = "",
                    PracticaColectiva = "",
                    PromedioAnualPresentaciones = "0",
                    PromedioMesesPresentaciones = "0",
                    AnoValue = "0"
                };

                AsesoriaNeg.Crear(registro, Convert.ToInt32(UsuaroId));


            }
            catch (Exception ex)
            { throw ex; }
        }
        #endregion

        #region Error
        protected override void OnException(ExceptionContext filterContext)
        {
            string ruta = "";
            ruta = Server.MapPath("/Log");
            Log.WriteLog(ruta, filterContext.Exception.ToString());

            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;


            var model = new HandleErrorInfo(filterContext.Exception, "FichaAsesoria", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }
        #endregion
    }
}