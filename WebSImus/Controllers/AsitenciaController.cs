using SM.Aplicacion.EntidadesOpeadoras;
using SM.LibreriaComun.DTO;
using SM.LibreriaComun.DTO.EntidadesOperadoras;
using SM.Utilidades.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace WebSImus.Controllers
{
    [HandleError()]
    [SessionExpire]
    public class AsitenciaController : BaseController
    {
        // GET: Asitencia

        [Route("Cronograma/{id? : int}")]
        //[Authorize]
        public ActionResult Exportar(int Id)
        {
            decimal escuelaId = Id;
            string strNombre = "";

            byte[] bytes = Helpers.GenerarArchivo.ObtenerParticipantePorCronograma(Id, out strNombre);
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

        #region Evaluacion

        public ActionResult _AgregarAutoEva(string id, string cronogramaId)
        {
            var model = new AutoEvaluacionDTO();
            int agenteid = 0;

            if (!string.IsNullOrEmpty(id))
            {
                agenteid = Convert.ToInt32(id);
                if (agenteid > 0)
                {
                    model = AsistenciaNeg.ConsultarPreguntasAutoEvaluacion(Convert.ToInt32(cronogramaId), Convert.ToInt32(id));
                    model.ParticipanteId = Convert.ToInt32(id);
                }
            }


            return PartialView("_AgregarAutoEva", model);
        }

        public ActionResult _AgregarEvaluacion(string id, string cronogramaId)
        {
            var model = new EvaluacionDTO();
            int agenteid = 0;

            if (!string.IsNullOrEmpty(id))
            {
                agenteid = Convert.ToInt32(id);
                if (agenteid > 0)
                {
                    model = AsistenciaNeg.ConsultarEvaluacionPorAgenteId(Convert.ToInt32(cronogramaId), Convert.ToInt32(id));
                    model.ParticipanteId = Convert.ToInt32(id);
                }
            }


            return PartialView("_AgregarEvaluacion", model);
        }

        [HttpPost]
        public JsonResult AgregarEvaluacion(string Id, string agenteId, EvaluacionDTO model)
        {
            bool isSuccess = true;

            EvaluacionDTO registro = new EvaluacionDTO
            {
                CronogramaId = Convert.ToInt32(Id),
                ParticipanteId = Convert.ToInt32(agenteId),
                Evaluacion = model.Evaluacion,
                Descripcion = model.Descripcion,
                UsuarioId = Convert.ToInt32(UsuaroId)
            };


            if (!String.IsNullOrEmpty(Id))
                AsistenciaNeg.CrearEvaluacion(registro);


            return Json(isSuccess);
        }

        [HttpPost]
        public JsonResult AgregarAuto(string Id, string agenteId, RespuestaDTO model)
        {
            bool isSuccess = true;

            RespuestaDTO registro = new RespuestaDTO
            {
                CronogramaId = Convert.ToInt32(Id),
                ParticipanteId = Convert.ToInt32(agenteId),
                PreguntaId = model.PreguntaId,
                respuesta = model.respuesta,
                UsuarioId = Convert.ToInt32(UsuaroId)
            };


            if (!String.IsNullOrEmpty(Id))
                AsistenciaNeg.CrearAutoEvaluacion(registro);


            return Json(isSuccess);
        }

        public ActionResult TablaEvaluacion(string CronogramaId)
        {
            var listado = new List<AsistenciaDTO>();


            listado = SM.Aplicacion.EntidadesOpeadoras.AsistenciaNeg.ConsultarParticipantesEvaluacion(Convert.ToInt32(CronogramaId));

            return PartialView("_TablaEvaluacion", listado);
        }
        #endregion

        #region Asistencia
        public ActionResult _AgregarAsistencia(string id, string cronogramaId)
        {
            var model = new AgregarAsistenciaDTO();
            int agenteid = 0;

            if (!string.IsNullOrEmpty(id))
            {
                agenteid = Convert.ToInt32(id);
                if (agenteid > 0)
                {
                    model = AsistenciaNeg.ConsultarAsistenciaPorAgente(Convert.ToInt32(cronogramaId), Convert.ToInt32(id));
                    model.ParticipanteId = agenteid;
                    model.CronogramaId = Convert.ToInt32(cronogramaId);
                }
            }


            return PartialView("_AgregarAsistencia", model);
        }
        [HttpPost]
        public JsonResult AgregarAsistencia(string Id, string agenteId, string fecha)
        {
            bool isSuccess = true;

            AsistenciaDTO registro = new AsistenciaDTO
            {
                CronogramaId = Convert.ToInt32(Id),
                ParticipanteId = Convert.ToInt32(agenteId),
                FechaAsistencia = fecha,
                Asistio = true
            };


            if (!String.IsNullOrEmpty(Id))
                AsistenciaNeg.Crear(registro, Convert.ToInt32(UsuaroId));


            return Json(isSuccess);
        }
        public ActionResult TablaAsistencia(string CronogramaId)
        {
            var listado = new List<AsistenciaDTO>();


            listado = SM.Aplicacion.EntidadesOpeadoras.AsistenciaNeg.ConsultarPorCronograma(Convert.ToInt32(CronogramaId));

            return PartialView("_TablaAsistencia", listado);
        }
        #endregion


        public ActionResult Asistencia(int Id, string fecha = "")
        {
            var model = new CronogramaDTO();
            model.Id = Id;

            return View(model);
        }
        public ActionResult Evaluacion(int Id, string fecha = "")
        {
            var model = new CronogramaDTO();
            model.Id = Id;

            return View(model);
        }
        public ActionResult CargarAsistencia(int cronogramaId, string fecha = "")
        {
            var listado = new List<EstandarDTO>();

            listado = CronogramaNeg.ConsultarAgentesCronograma(cronogramaId, 2);

            return PartialView("_TablaAsistencia", listado);
        }
        #region LogErrores
        protected override void OnException(ExceptionContext filterContext)
        {
            string ruta = "";
            ruta = Server.MapPath("/Log");
            Log.WriteLog(ruta, filterContext.Exception.ToString());

            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;


            var model = new HandleErrorInfo(filterContext.Exception, "Asistencia", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }
        #endregion
    }
}