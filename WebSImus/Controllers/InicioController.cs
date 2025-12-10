using ClosedXML.Excel;
using SM.LibreriaComun.DTO;
using SM.LibreriaRecursos.Recursos;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Services;
using WebSImus.Comunes;

namespace WebSImus.Controllers
{

    public class InicioController : BaseController
    {
        private List<RecursoDTO> ltsMenu = null;

        // GET: /Inicio/
        public ActionResult Index()
        {
            MensajesAccesoSimus();

            ViewBag.nombreusuario = NombreCompletoUsuario;
            reportesdeValor();
            return View();
        }

        /// <summary>
        /// Cargamos todos los valores indicados por valor 
        /// </summary>
        private void reportesdeValor()
        {   //total estudiantes
            var Edades = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerReporteEscEdadesMiembros();
            ViewBag.totalEstudiantes = Edades.Sum(x => decimal.Parse(x.value));

            var OrgComunitaria = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerReporteOrgComunitaria();
            ViewBag.totalComunitaria = OrgComunitaria.Sum(x => decimal.Parse(x.value));

            var Profesores = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerReporteProfesores();
            ViewBag.totalProfesores = 0;

            var EstdEscenarios = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerCantidadEstudiantesESC();
            ViewBag.EstdEscenarios = 0;


            var Entdependeotra = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerCantidadEscuelasDependeOtra();
            ViewBag.Entdependeotra = 0;
            //rotadores
            ViewBag.cantAgente = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerCantidadAgente();
            ViewBag.cantEntidad = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerCantidadEntidades();






            try
            {
                ViewBag.totalProfesores = (int)(Edades.Sum(x => decimal.Parse(x.value)) / Profesores.Sum(x => decimal.Parse(x.value)));
                ViewBag.EstdEscenarios = (int)(EstdEscenarios.Sum(x => decimal.Parse(x.criterio6) + decimal.Parse(x.criterio7) + decimal.Parse(x.criterio12) + decimal.Parse(x.criterio26)));
                ViewBag.Entdependeotra = (int)(Entdependeotra.Sum(x => decimal.Parse(x.value)));
            }
            catch (Exception)
            {

            }

        }
        #region ultilidad excel

        [HttpGet]
        public JsonResult GetWidgetData()
        {
            var Edades = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerReporteEscEdadesMiembros();
            var OrgComunitaria = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerReporteOrgComunitaria();
            var Profesores = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerReporteProfesores();
            var EstdEscenarios = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerCantidadEstudiantesESC();
            var Entdependeotra = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerCantidadEscuelasDependeOtra();

            var cantAgente = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerCantidadAgente();
            var cantEntidad = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerCantidadEntidades();

            int totalProfesores = 0;
            int totalEstudiantes = 0;
            int estdEscenarios = 0;
            int entDependen = 0;

            try
            {
                totalEstudiantes = (int)(Edades.Sum(x => decimal.Parse(x.value)));
                totalProfesores = (int)(Edades.Sum(x => decimal.Parse(x.value)) / Profesores.Sum(x => decimal.Parse(x.value)));
                estdEscenarios = (int)(EstdEscenarios.Sum(x => decimal.Parse(x.criterio6) + decimal.Parse(x.criterio7) + decimal.Parse(x.criterio12) + decimal.Parse(x.criterio26)));
                entDependen = (int)(Entdependeotra.Sum(x => decimal.Parse(x.value)));
            }
            catch (Exception)
            {
                // Evitar crash si datos vienen mal formateados
            }

            return Json(new
            {
                totalEstudiantes,
                totalComunitaria = OrgComunitaria.Sum(x => decimal.Parse(x.value)),
                totalProfesores,
                EstdEscenarios = estdEscenarios,
                Entdependeotra = entDependen,
                cantAgente,
                cantEntidad
            }, JsonRequestBehavior.AllowGet);
        }



        private void crearReporte(DataSet dsValue)
        {

            DumpExcel(dsValue);

        }



        private void DumpExcel(DataSet dt)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                wb.Style.Font.Bold = true;

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= EmployeeReport.xlsx");

                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }



        public ActionResult descargar(int numReporte)
        {
            if (numReporte == 1)//Reporte d escuelas por dpto
            {
                DataSet reporte = Export.ToDataSet(SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerReporteDptoEscuela());
                DumpExcel(reporte);
            }
            if (numReporte == 2)//reporte de  edades por departamentos
            {
                DataSet reporte = Export.ToDataSetComplex(SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerReporteEdadesDpto());
                DumpExcel(reporte);
            }

            if (numReporte == 3)//reporte de  Profesores por dpto
            {
                var Edades = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerReporteEdadesDpto();
                int Total = (int)Edades.Sum(x => decimal.Parse(x.criterio6) + decimal.Parse(x.criterio7) + decimal.Parse(x.criterio12) + decimal.Parse(x.criterio19) + decimal.Parse(x.criterio26));

                DataSet reporte = Export.ToDataSet(SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerReporteProfesores(), Total);
                DumpExcel(reporte);
            }

            if (numReporte == 4)//reporte de  Cantidad de escuelas por estado de consolidación por dpto
            {
                DataSet reporte = Export.ToDataSetComplexConslDpto(SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerCantidadEscuelasConsolidacionDPTO());
                DumpExcel(reporte);
            }
            if (numReporte == 5)//reporte de  Cantidad de participaciones de los estudiantes en escenarios
            {
                DataSet reporte = Export.ToDataSetComplexEstudiantesESC(SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerCantidadEstudiantesESC());
                DumpExcel(reporte);
            }
            if (numReporte == 6)//reporte de  Cantidad de escuelas de música con organización comunitaria por dpto
            {
                DataSet reporte = Export.ToDataSet(SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerReporteOrgComunitaria());
                DumpExcel(reporte);
            }
            if (numReporte == 7)//reporte de  CCantidad de escuelas que dependen de otra entidad
            {
                DataSet reporte = Export.ToDataSet(SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerCantidadEscuelasDependeOtra());
                DumpExcel(reporte);
            }
            if (numReporte == 8)//reporte de  Cantidad de docentes por nivel educativo
            {
                DataSet reporte = Export.ToDataSetProfesorDpto(SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerReportePorfesorNvlDepartamento());
                DumpExcel(reporte);
            }

            if (numReporte == 9)//Dotación instrumental existente en las escuelas de música DPTO
            {
                DataSet reporte = Export.ToDataSetInstrumentoDpto(SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerReporteInstrumentoDepartamento());
                DumpExcel(reporte);
            }

            if (numReporte == 10)//Dotación Practicas musicales en las escuelas DPTO
            {
                DataSet reporte = Export.ToDataSetComplexConslDpto(SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerPracticaMusicaDpto());
                DumpExcel(reporte);
            }

            if (numReporte == 11)//Dotación Practicas musicales en las escuelas DPTO
            {
                DataSet reporte = Export.ToDataSetComplexConslDpto(SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerAreaMusicaDPTO());
                DumpExcel(reporte);
            }

            if (numReporte == 12)//Población en condiciones especiales atendida DPTO
            {
                DataSet reporte = Export.ToDataSetComplexConslDpto(SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerPoblaCodEsDPTO());
                DumpExcel(reporte);
            }
            return RedirectToAction("Index", "Inicio");
        }


        #endregion


        public ActionResult _Menu()
        {

            ltsMenu = WebSImus.Controlador.Cache.ManejadorRecursos.generateTabs(Convert.ToInt32(UsuaroId));

            return PartialView("_Menu", ltsMenu);
        }

        public ActionResult _Perfil()
        {
            return PartialView("_Perfil");
        }

        public ActionResult _Salir()
        {
            return PartialView("_Salir");
        }


        public ActionResult _MensajeConfirmacion()
        {
            return PartialView("_MensajeConfirmacion");
        }

        public ActionResult _Tareas()
        {
            return PartialView("_Tareas");
        }

        public ActionResult _Mensajes()
        {
            return PartialView("_Mensajes");
        }




        private void GenerarOpciones(int IdMenu)
        {


        }



        #region Dashboard
        /// <summary>
        /// Teporte por departamentos
        /// </summary>
        /// <returns></returns>

        public JsonResult GetPiechartData()
        {

            var reporte = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerReporteDptoEscuela();

            //oper = null which means its first load.
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }
        /// <summary>
        /// escuelas por tipo
        /// </summary>
        /// <returns></returns>
        //public JsonResult GetEscueltasTipo()
        //{

        //    var reporte = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerReporteEscuelasTipo();

        //    //oper = null which means its first load.
        //    var jsonSerializer = new JavaScriptSerializer();
        //    string data = jsonSerializer.Serialize(reporte);
        //    return Json(data, JsonRequestBehavior.AllowGet); ;

        //}

        public JsonResult GetEscueltasTipo()
        {
            var reporte = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerReporteEscuelasTipo();
            return Json(reporte, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetEscPracticaMusical()
        {

            var reporte = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerReporteEscuelasPracticaMcal();

            //oper = null which means its first load.
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }


        public JsonResult GetEscEdades()
        {

            var reporte = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerReporteEscEdadesMiembros();
            //ViewBag.totalEstudiantes = reporte.Sum(x => decimal.Parse(x.value));
            //oper = null which means its first load.
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }
        public JsonResult GetEscEtnia()
        {

            var reporte = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerReporteEsceEtnia();

            //oper = null which means its first load.
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }
        public JsonResult GetEscEtniSEXO()
        {

            var reporte = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerReportesexo();

            //oper = null which means its first load.
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }
        public JsonResult GetEscArea()
        {

            var reporte = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerReporteArea();

            //oper = null which means its first load.
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }

        public JsonResult GetEscCondiesp()
        {

            var reporte = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerReporteCondiesp();

            //oper = null which means its first load.
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult GetEscOrgComunitaria()
        {

            var reporte = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerReporteDptoEscuela();

            //oper = null which means its first load.
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }
        /// <summary>
        /// Cantidad de escuelas por estado de consolidación
        /// </summary>
        /// <returns></returns>
        public JsonResult GetEscConsolidacion()
        {

            var reporte = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerCantidadEscuelasConsolidacion();

            //oper = null which means its first load.
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }


        /// <summary>
        /// Cantidad de docentes por nivel educativo
        /// </summary>
        /// <returns></returns>
        public JsonResult GetProfesoresDpto()
        {

            var reporte = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerGraphCantidadNivelProfesorDPTO();

            //oper = null which means its first load.
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }

        /// <summary>
        /// Dotación instrumental existente en las escuelas de música
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDotacionInsDpto()
        {

            var reporte = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerGraphInstrumentoDepartamentoV2();

            //oper = null which means its first load.
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }
        #endregion

    }
}