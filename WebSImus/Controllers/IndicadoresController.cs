using ClosedXML.Excel;
using SM.Aplicacion.Reporte;
using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebSImus.Comunes;

namespace WebSImus.Controllers
{
    public class IndicadoresController : Controller
    {

        public ActionResult _DetalleMapa(string CodDepto, string periodo)
        {
            var model = new DepartamentoEstadisticasDTO();

            if (!string.IsNullOrEmpty(CodDepto))
                model = IndicadoresNeg.ObtenerEscuelasPorDepartamento(CodDepto, Convert.ToInt32(periodo)); 
              
           return PartialView("_DetalleMapa", model);
        }
        // GET: Indicadores
        public ActionResult Escuelas(int id = 0, string modal = "")
        {
            int periodo = 1;
            var model = new EscuelasEstadisticasDTO();
            var objAnos = new List<BasicaDTO>();
            objAnos = SM.Aplicacion.Basicas.BasicaLogica.ConsultarListadoAnosMusicaIndicadores();
            ViewBag.listAnos = new SelectList(objAnos, "value", "text");

            if (id != 0)
                periodo = Convert.ToInt32(id);

            model = IndicadoresNeg.ObtenerDatosFijosEscuelas(periodo);
            model.selectorAno = periodo.ToString();
            model.periodo = periodo.ToString();
     
            if (String.IsNullOrEmpty(modal))
                return View(model);
            else
                return PartialView("_DatosEscuelas", model);
        }

        public ActionResult Estudiantes(int id = 0, string modal = "")
        {
            int periodo = 1;
            var model = new EstudiantesEstadisticasDTO();
            var objAnos = new List<BasicaDTO>();
            objAnos = SM.Aplicacion.Basicas.BasicaLogica.ConsultarListadoAnosMusicaIndicadores();
            ViewBag.listAnos = new SelectList(objAnos, "value", "text");
            if (id != 0)
                periodo = Convert.ToInt32(id);
            model = IndicadoresNeg.ObtenerDatosFijosEstudiantes(periodo);
            model.selectorAno = periodo.ToString();

            if (String.IsNullOrEmpty(modal))
                return View(model);
            else
                return PartialView("_DatosEstudiantes", model);
        }

        public ActionResult Docentes(int id = 0, string modal = "")
        {
            int periodo = 1;
            var model = new DocentesEstadisticasDTO();
            var objAnos = new List<BasicaDTO>();
            objAnos = SM.Aplicacion.Basicas.BasicaLogica.ConsultarListadoAnosMusicaIndicadores();
            ViewBag.listAnos = new SelectList(objAnos, "value", "text");
            if (id != 0)
                periodo = Convert.ToInt32(id);
            model = IndicadoresNeg.ObtenerDatosFijosDocentes(periodo);
            model.selectorAno = periodo.ToString();

            if (String.IsNullOrEmpty(modal))
                return View(model);
            else
                return PartialView("_DatosDocentes", model);
        }

        public ActionResult Mapa(int id = 0, string modal = "")
        {
            int periodo = 1;
            var model = new EscuelasEstadisticasDTO();
            var objAnos = new List<BasicaDTO>();
            objAnos = SM.Aplicacion.Basicas.BasicaLogica.ConsultarListadoAnosMusicaIndicadores();
            ViewBag.listAnos = new SelectList(objAnos, "value", "text");

            if (id != 0)
                periodo = Convert.ToInt32(id);

            model.selectorAno = periodo.ToString();
            model.periodo = periodo.ToString();
            return View(model);
        }

        public ActionResult EscuelasData()
        {
            return View();
        }

        public ActionResult DatosBasicos()
        {

            return PartialView("_DatosEscuelas");
        }

        public ActionResult descargar(int numReporte, int periodo)
        {
            if (numReporte == 1)
            {
                DataSet reporte = Export.ToDataSetComplexNaturaleza(SM.Aplicacion.Reporte.IndicadoresNeg.ConsultarDetalleGraficaNaturaleza(periodo));
                DumpExcel(reporte, "Naturaleza");
            }
            if (numReporte == 2)
            {
                DataSet reporte = Export.ToDataSetComplexLegalmente(SM.Aplicacion.Reporte.IndicadoresNeg.ConsultarDetalleGraficaLegalmenteConstituida(periodo));
                DumpExcel(reporte, "LegalmenteConstituida");
            }

            if (numReporte == 3)
            {
                DataSet reporte = Export.ToDataSetComplexTipoEscuela(SM.Aplicacion.Reporte.IndicadoresNeg.ConsultarDetalleGraficaTipoEscuela(periodo));
                DumpExcel(reporte, "TipoEscuela");
            }

            if (numReporte == 4)
            {

                DataSet reporte = Export.ToDataSetComplexFamiliaInstrumental(SM.Aplicacion.Reporte.IndicadoresNeg.ConsultarDetalleGraficaFamiliaInstrumental(periodo));
                DumpExcel(reporte, "FamiliaInstrumental");
            }
            if (numReporte == 5)
            {
                DataSet reporte = Export.ToDataSetComplexPracticaMusical(SM.Aplicacion.Reporte.IndicadoresNeg.ConsultarDetalleGraficaPracticaMusical(periodo));
                DumpExcel(reporte, "PracticaMusical");
            }
            if (numReporte == 6)
            {
                DataSet reporte = Export.ToDataSetComplexRangoEtarios(SM.Aplicacion.Reporte.IndicadoresNeg.ConsultarDetalleGraficaRangosEtarios(periodo));
                DumpExcel(reporte, "RangoEtarios");
            }
            if (numReporte == 7)
            {
                DataSet reporte = Export.ToDataSetComplexUbicacion(SM.Aplicacion.Reporte.IndicadoresNeg.ConsultarDetalleGraficaUbicacion(periodo));
                DumpExcel(reporte, "Ubicacion");
            }
            if (numReporte == 8)
            {
                DataSet reporte = Export.ToDataSetComplexGrupoEtnico(SM.Aplicacion.Reporte.IndicadoresNeg.ConsultarDetalleGraficaGrupoEtnico(periodo));
                DumpExcel(reporte, "GrupoEtnico");
            }

            if (numReporte == 9)
            {
                DataSet reporte = Export.ToDataSetComplexSexo(SM.Aplicacion.Reporte.IndicadoresNeg.ConsultarDetalleGraficaSexo(periodo));
                DumpExcel(reporte, "PorSexo");
            }

            if (numReporte == 10)
            {
                DataSet reporte = Export.ToDataSetComplexDocentes(SM.Aplicacion.Reporte.IndicadoresNeg.ConsultarDetalleNivelEducativoDocentes(periodo));
                DumpExcel(reporte, "NivelEducativoDocentes");
            }

            if (numReporte == 11)
            {
                DataSet reporte = Export.ToDataSetComplexCirculacion(SM.Aplicacion.Reporte.IndicadoresNeg.ConsultarDetalleCirculacion(periodo));
                DumpExcel(reporte, "Circulacion");
            }

           
            return RedirectToAction("Escuelas", "Indicadores");
        }

        private void crearReporte(DataSet dsValue)
        {

            DumpExcel(dsValue, "Prueba");

        }



        private void DumpExcel(DataSet dt, string NombreReporte)
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
                Response.AddHeader("content-disposition", "attachment;filename=" +NombreReporte +".xlsx");

                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }
        #region Json
        public JsonResult ObtenerEscuelasRangoEdad(string Id = "0")
        {

            var reporte = SM.Aplicacion.Reporte.IndicadoresNeg.ObtenerEscuelasPorNaturalezaActual(Convert.ToInt32(Id));

            //oper = null which means its first load.
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }
        public JsonResult ObtenerEscuelasNaturaleza(string Id ="0")
        {

            var reporte = SM.Aplicacion.Reporte.IndicadoresNeg.ObtenerEscuelasPorNaturalezaActual(Convert.ToInt32(Id));

            //oper = null which means its first load.
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }

        public JsonResult ObtenerEscuelasLegalmenteConstituidas(string Id = "2017", string si = "0")
        {
            bool boolSI = false;

            if (si == "1")
                boolSI = true;

            var reporte = SM.Aplicacion.Reporte.IndicadoresNeg.ObtenerEscuelasLegalmenteConstituidas(Convert.ToInt32(Id), boolSI);

            //oper = null which means its first load.
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }

        public JsonResult ObtenerEscuelasPorTipo(string Id = "0")
        {

            var reporte = SM.Aplicacion.Reporte.IndicadoresNeg.ObtenerEscuelasPorTipo(Convert.ToInt32(Id));

            //oper = null which means its first load.
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }

        public JsonResult ObtenerEstudiantesPorUbicacionUrbana(string Id = "0")
        {

            var reporte = SM.Aplicacion.Reporte.IndicadoresNeg.ObtenerEstudiantesPorUbicacionUrbana(Convert.ToInt32(Id));

            //oper = null which means its first load.
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }

        public JsonResult ObtenerEstudiantesPorUbicacionRural(string Id = "0")
        {

            var reporte = SM.Aplicacion.Reporte.IndicadoresNeg.ObtenerEstudiantesPorUbicacionRural(Convert.ToInt32(Id));

            //oper = null which means its first load.
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }

        public JsonResult ObtenerEstudiantesPorSexoMasculino(string Id = "0")
        {

            var reporte = SM.Aplicacion.Reporte.IndicadoresNeg.ObtenerEstudiantesPorSexoMasculino(Convert.ToInt32(Id));

            //oper = null which means its first load.
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }

        public JsonResult ObtenerEstudiantesPorSexoFemenino(string Id = "0")
        {

            var reporte = SM.Aplicacion.Reporte.IndicadoresNeg.ObtenerEstudiantesPorSexoFemenino(Convert.ToInt32(Id));

            //oper = null which means its first load.
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }
        public JsonResult ObtenerEscuelasPorTipoYNaturaleza(string Id = "0", string si = "PUBLICA")
        {


            var reporte = SM.Aplicacion.Reporte.IndicadoresNeg.ObtenerEscuelasPorTipoYNaturaleza(si, Convert.ToInt32(Id));

            //oper = null which means its first load.
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }

        public JsonResult ObtenerEscuelasPorPracticaMusical(string Id = "0", string si = "PUBLICA")
        {

            var reporte = SM.Aplicacion.Reporte.IndicadoresNeg.ObtenerEscuelasPorPracticaMusical(Convert.ToInt32(Id), si);

            //oper = null which means its first load.
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }

        public JsonResult ObtenerEscuelasPorFamiliaInstrumental(string Id = "0", string si = "PUBLICA")
        {


            var reporte = SM.Aplicacion.Reporte.IndicadoresNeg.ObtenerEscuelasPorFamiliaInstrumental(Convert.ToInt32(Id), si);

            //oper = null which means its first load.
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }

        public JsonResult ObtenerEstudiantesPorRangosEtarios(string Id = "0", string si = "PUBLICA")
        {

            var reporte = SM.Aplicacion.Reporte.IndicadoresNeg.ObtenerEstudiantesPorRangosEtarios(Convert.ToInt32(Id), si);

            //oper = null which means its first load.
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }

        public JsonResult ObtenerEstudiantesPorUbicacion(string Id = "0", string si = "PUBLICA")
        {

            var reporte = SM.Aplicacion.Reporte.IndicadoresNeg.ObtenerEstudiantesPorUbicacion(si);

            //oper = null which means its first load.
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }
        public JsonResult ObtenerEstudiantesPorSexo(string Id = "0", string si = "PUBLICA")
        {

            var reporte = SM.Aplicacion.Reporte.IndicadoresNeg.ObtenerEstudiantesPorSexo(si);

            //oper = null which means its first load.
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }
        public JsonResult ObtenerEstudiantesPorGrupoEtnico(string Id = "0", string si = "PUBLICA")
        {

            var reporte = SM.Aplicacion.Reporte.IndicadoresNeg.ObtenerEstudiantesPorGrupoEtnico(Convert.ToInt32(Id), si);

            //oper = null which means its first load.
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }

        public JsonResult ObtenerEscuelasPorNivelEducativoDocentes(string Id = "0", string si = "PUBLICA")
        {

            var reporte = SM.Aplicacion.Reporte.IndicadoresNeg.ObtenerEscuelasPorNivelEducativoDocentes(Convert.ToInt32(Id), si);

            //oper = null which means its first load.
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }

        public JsonResult ObtenerEscuelasPorProduccion(string Id = "0", string si = "PUBLICA")
        {

            var reporte = SM.Aplicacion.Reporte.IndicadoresNeg.ObtenerEscuelasPorProduccion(Convert.ToInt32(Id), si);

            //oper = null which means its first load.
            var jsonSerializer = new JavaScriptSerializer();
            string data = jsonSerializer.Serialize(reporte);
            return Json(data, JsonRequestBehavior.AllowGet); ;

        }
        #endregion
    }
}