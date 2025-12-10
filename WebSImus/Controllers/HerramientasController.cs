using SM.Aplicacion.Servicios;
using SM.LibreriaComun.DTO.Servicios;
using SM.Utilidades.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using SM.Aplicacion.Estimulos;

namespace WebSImus.Controllers
{
     [HandleError()]
    public class HerramientasController : Controller
    {

       
        // GET: Herramientas
        public ActionResult Index()
        {
            var model = new List<ConvocatoriaListadoEstimuloDTO>();
            model = ServicioEstimuloNeg.ConsultarConvocatoriasEstimulosEstado(Comunes.ConstantesRecursosBD.CODIGO_ESTADO_PUBLICADO);
            return View(model);
        }

        public ActionResult Estimulos()
        {
            return View();
        }

        public ActionResult Convocatorias(int? page)
        {

            List<ConvocatoriaListDTO> listResultado;
            listResultado = ConvocatoriaNeg.ConsultarConvocatoriaHome(Comunes.ConstantesRecursosBD.CODIGO_ESTADOCONV_ACTIVA);
            
            var model = from l in listResultado select l;
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            string ruta = "";
            ruta = Server.MapPath("/Log");
            Log.WriteLog(ruta, filterContext.Exception.ToString());

            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;


            var model = new HandleErrorInfo(filterContext.Exception, "Herramientas", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }
    }
}