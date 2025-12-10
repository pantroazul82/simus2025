using SM.Aplicacion.Basicas;
using SM.LibreriaComun.DTO;
using SM.Utilidades.Log;
using System;
using System.Collections.Generic;
using SM.LibreriaComun.DTO.GEO;
using System.Web.Mvc;
using PagedList;
using System.Linq;
using System.Web;
using WebSImus.Models;
using SM.Aplicacion.Servicios;
using System.Text;
using SM.Aplicacion.Geo;

namespace WebSImus.Controllers
{
    [HandleError()]
    public class ReporteMapasController : Controller
    {
      
        // GET: Mapas
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Eje(int Id)
        {
            var model = SM.Aplicacion.Geo.MapaMusicalNeg.ConsultarEJeResena(Id, WebSImus.Areas.Mapas.Helps.Utilidades.GetBaseUrl());
            IHtmlString str = new HtmlString(model.Resena);
            ViewBag.resena = str;
            return View(model);
        }

        public ActionResult _DatosEscuelas(string CodDepto, string porcentaje, string nombre, int? page)
        {
            List<EscuelaMunicipioDTO> listResultado = new List<EscuelaMunicipioDTO>();
            ViewBag.CodDepto = CodDepto;
            ViewBag.NombreDepto = nombre;
            ViewBag.porcentaje = porcentaje;

            if (!string.IsNullOrEmpty(CodDepto))
            {
                listResultado = SM.Aplicacion.Geo.GeoNeg.ConsultarEscuelasPorMunicipio(CodDepto);
                ViewBag.CantidadEscuelas = listResultado.Select(t => t.Cantidad).Sum();
                ViewBag.CantidadMunEscuelas = listResultado.Select(t => t.Cantidad).Count();
                ViewBag.CantidadPublicas = listResultado.Select(t => t.Cantidad_Publica).Sum();
                ViewBag.CantidadPrivada = listResultado.Select(t => t.Cantidad_Privada).Sum();
                ViewBag.CantidadMixta = listResultado.Select(t => t.Cantidad_Mixta).Sum();
                ViewBag.CantidadMun = SM.Aplicacion.Geo.CelebraGeoNeg.CantidadMunicipiosPorDepto(CodDepto);
            }


            var model = from l in listResultado select l;
            int pageSize = 8;
            int pageNumber = (page ?? 1);

            return PartialView("_DatosEscuelas", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult _DatosConciertos(string CodDepto, string porcentaje, string nombre, int? page, string filtroAno)
        {
            List<ConciertosPorMunicipioDTO> listResultado = new List<ConciertosPorMunicipioDTO>();
            ViewBag.CodDepto = CodDepto;
                
            ViewBag.porcentaje = porcentaje;
            ViewBag.FiltroAno = filtroAno;

            if (!string.IsNullOrEmpty(CodDepto))
            {
                if (!string.IsNullOrEmpty(filtroAno))
                {
                    listResultado = SM.Aplicacion.Geo.CelebraGeoNeg.ConsultarCantidadConciertosPorMun(WebSImus.Areas.Mapas.Helps.Utilidades.GetBaseUrl(), CodDepto, Convert.ToInt32(filtroAno));
                    ViewBag.NombreDepto = ZonaGeograficasLogica.obtenerNombreDepartamento(CodDepto);
                    ViewBag.CantidadConciertos = listResultado.Select(t => t.cantidad).Sum();
                    ViewBag.CantidadMunConciertos = listResultado.Select(t => t.cantidad).Count();
                    ViewBag.CantidadMun = SM.Aplicacion.Geo.CelebraGeoNeg.CantidadMunicipiosPorDepto(CodDepto);
                }
            }


            var model = from l in listResultado select l;
            int pageSize = 8;
            int pageNumber = (page ?? 1);

            return PartialView("_DatosConciertos", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult _DatosConciertosMunicipio(string Id, string intAno)
        {
            var model = new List<ConciertosDTO>();

            if ((!string.IsNullOrEmpty(Id)) && (!string.IsNullOrEmpty(intAno)))
            {
                model = SM.Aplicacion.Geo.CelebraGeoNeg.ConsultarConciertosPorMunicipio(WebSImus.Areas.Mapas.Helps.Utilidades.GetBaseUrl(), Convert.ToInt32(intAno), Id);
                ViewBag.NombreDepto = model[0].Departamento;
                ViewBag.NombreMunicipio = model[0].Municipio;
                ViewBag.ver_Mas = model[0].Ver_Mas;

            }

            return PartialView("_DatosConciertosMunicipio", model);
        }

        public ActionResult _DatosAgentes(string CodDepto, string porcentaje, string nombre, int? page)
        {
            List<AgenteMunicipioDTO> listResultado = new List<AgenteMunicipioDTO>();
            ViewBag.CodDepto = CodDepto;
            ViewBag.NombreDepto = nombre;
            ViewBag.porcentaje = porcentaje;

            if (!string.IsNullOrEmpty(CodDepto))
            {
                listResultado = SM.Aplicacion.Geo.GeoNeg.ConsultarAgentesPorMunicipio(CodDepto);
                ViewBag.CantidadAgentes = listResultado.Select(t => t.cantidad).Sum();

            }

            var model = from l in listResultado select l;
            int pageSize = 8;
            int pageNumber = (page ?? 1);

            return PartialView("_DatosAgentes", model.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult ExportarExcel()
        {

            var listaescuelas = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerReporteGeneral();
            System.Data.DataTable dataTable = new System.Data.DataTable();

            string nombreArchivo;
            var stream = WebSImus.Comunes.Excel.CrearReporteGeneral("Estadisticas departamento", "", dataTable, out nombreArchivo);
            const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            stream.Position = 0;
            return File(stream, contentType, nombreArchivo);
        }

        public ActionResult ExportarExcelDepartamento(string selectorAno = "2019")
        {

            var listadosDepartamentos = SM.Aplicacion.Eventos.EventosNeg.GenerarReportePorcentajePorDepartamento(Convert.ToInt32(selectorAno));
            System.Data.DataTable dataTable = new System.Data.DataTable();
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cod Departamento" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Departamento" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cant. Municipios" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cant. Municipios con Conciertos" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Porcentaje %" });
             StringBuilder stringBuilder = new StringBuilder();
             foreach (ReporteDepartamentoDTO item in listadosDepartamentos)
             {
                 stringBuilder.Clear();
                 System.Data.DataRow dataRow = dataTable.NewRow();
                 dataRow["Cod Departamento"] = item.Codigo;
                 dataRow["Departamento"] = item.Departamento;
                 dataRow["Cant. Municipios"] = item.CantidadMunicipios.ToString();
                 dataRow["Cant. Municipios con Conciertos"] = item.CantidadMunConEventos.ToString();
                 dataRow["Porcentaje %"] = item.Porcentaje.ToString("0.##") + ",00";
                 dataTable.Rows.Add(dataRow);
             }
            string nombreArchivo;
            var stream = WebSImus.Comunes.Excel.CrearReportePorcentajeDepartamentos("Porcentaje Departamento " + selectorAno, "", dataTable, out nombreArchivo);
            const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            stream.Position = 0;
            return File(stream, contentType, nombreArchivo);
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

        public ActionResult MapaPulep()
        {


            return View();
        }
        public ActionResult TematicoEscuelas()
        {


            return View();
        }

        public ActionResult TematicoAgentes()
        {

            return View();
        }


        public ActionResult MapaEscuelas()
        {
            ViewBag.departamentos = new SelectList(ZonaGeograficasLogica.ConsultarDepartamentos(), "value", "text");
            List<BasicaDTO> objMunicipios = new List<BasicaDTO>();
            ViewBag.municipios = new SelectList(objMunicipios, "value", "text");

            return View();
        }

        public ActionResult MapaEventos()
        {
            ViewBag.departamentos = new SelectList(ZonaGeograficasLogica.ConsultarDepartamentos(), "value", "text");
            List<BasicaDTO> objMunicipios = new List<BasicaDTO>();
            ViewBag.municipios = new SelectList(objMunicipios, "value", "text");
            ViewBag.listadoClasificados = new SelectList(ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_TIPO_EVENTO), "value", "text");

            return View();
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

        public ActionResult MapaMusical()
        {
            ViewBag.departamentos = new SelectList(ZonaGeograficasLogica.ConsultarDepartamentos(), "value", "text");
            List<BasicaDTO> objMunicipios = new List<BasicaDTO>();
            ViewBag.municipios = new SelectList(objMunicipios, "value", "text");

            return View();
        }

        public ActionResult _DatosMapaMusical(string codigo)
        {
            var model = new MapaMusicalModelo();

            if (!String.IsNullOrEmpty(codigo))
            {
                MunicipiosGeoDTO resultado = MapaMusicalNeg.ConsultarTradicionalMunicipiosModal("http://simus.mincultura.gov.co/", codigo); 

                if (resultado != null)
                {
                    model.Cantidad = resultado.Cantidad;
                    model.CodigoMunicipio = resultado.Cod_Municipio;
                    model.Eje = resultado.Eje;
                    model.EjeId = resultado.EjeId;
                    model.Estilo = resultado.Estilo;
                    model.Foto = resultado.Foto;
                    model.ListGeneros = resultado.ListGeneros;
                    model.Ubicacion = resultado.Ubicacion;
                    model.Ver_Mas = resultado.Ver_Mas;
                }
            }

            return PartialView("_DatosMapaMusical", model);
        }

        public ActionResult MapaAgentes()
        {


            return View();
        }
        public ActionResult MapaEntidades()
        {
            ViewBag.departamentos = new SelectList(ZonaGeograficasLogica.ConsultarDepartamentos(), "value", "text");
            List<BasicaDTO> objMunicipios = new List<BasicaDTO>();
            ViewBag.municipios = new SelectList(objMunicipios, "value", "text");
            return View();
        }

        public ActionResult MapaAgrupaciones()
        {
            ViewBag.departamentos = new SelectList(ZonaGeograficasLogica.ConsultarDepartamentos(), "value", "text");
            List<BasicaDTO> objMunicipios = new List<BasicaDTO>();
            ViewBag.municipios = new SelectList(objMunicipios, "value", "text");
            return View();
        }

        public ActionResult MapaGeneral()
        {
            ViewBag.departamentos = new SelectList(ZonaGeograficasLogica.ConsultarDepartamentos(), "value", "text");
            List<BasicaDTO> objMunicipios = new List<BasicaDTO>();
            ViewBag.municipios = new SelectList(objMunicipios, "value", "text");
            return View();
        }

        public ActionResult Mapa()
        {
            ViewBag.departamentos = new SelectList(ZonaGeograficasLogica.ConsultarDepartamentos(), "value", "text");
            List<BasicaDTO> objMunicipios = new List<BasicaDTO>();
            ViewBag.municipios = new SelectList(objMunicipios, "value", "text");

            return View();
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
        protected override void OnException(ExceptionContext filterContext)
        {
            string ruta = "";
            ruta = Server.MapPath("/Log");
            Log.WriteLog(ruta, filterContext.Exception.ToString());

            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;


            var model = new HandleErrorInfo(filterContext.Exception, "Mapas", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }
    }
}