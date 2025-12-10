using SM.Aplicacion.Servicios;
using SM.LibreriaComun.DTO.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using WebSImus.Translator;
using WebSImus.Models;
using System.Text.RegularExpressions;

namespace WebSImus.Controllers
{
    public class UtilidadHomeController : Controller
    {
        // GET: UtilidadHome
        public ActionResult Clasificados(int? page)
        {
            List<UtilidadHomeDataDTO> listResultado;
            int TipoUtilidadId = ConvocatoriaNeg.ObtenerId(Comunes.ConstantesRecursosBD.NOMBRE_UTILIDAD_CLASIFICADOS);
            listResultado = UtilidadNeg.ConsultarDatosPorTipoUtilidad(TipoUtilidadId);

            var model = from l in listResultado select l;
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Noticias(int? page)
        {
            List<UtilidadHomeDataDTO> listResultado;
            int TipoUtilidadId = ConvocatoriaNeg.ObtenerId(Comunes.ConstantesRecursosBD.NOMBRE_UTILIDAD_NOTICIAS);
            listResultado = UtilidadNeg.ConsultarDatosPorTipoUtilidad(TipoUtilidadId);

            var model = from l in listResultado select l;
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Documentos(int? page)
        {
            List<UtilidadHomeDataDTO> listResultado;

            int TipoUtilidadId = ConvocatoriaNeg.ObtenerId(Comunes.ConstantesRecursosBD.NOMBRE_UTILIDAD_DOCUMENTOS);
            listResultado = UtilidadNeg.ConsultarDatosDocumentos(TipoUtilidadId);

            List<UtilidadHomeModels> Resultado = TranslatorUtilidad.TranslatorUtilidadHomeModel(listResultado);
            var model = from l in Resultado select l;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Detalle(int Id)
        {
            int TipoUtilidadId = ConvocatoriaNeg.ObtenerId(Comunes.ConstantesRecursosBD.NOMBRE_UTILIDAD_NOTICIAS);
            UtilidadDataDetalleDTO resultado = UtilidadNeg.ConsultarDetallePorId(Id);
            List<NoticiasDataDTO> listNoticias = UtilidadNeg.ConsultarNoticiasRecientes(TipoUtilidadId);
            string host = Request.Url.Scheme + "://" + Request.Url.Authority;
            var model = TranslatorUtilidad.TranslatorNoticiasDetalle(resultado, listNoticias, host);
            return View(model);
        }

        public ActionResult Agenda()
        {

            return View();
        }

        public ActionResult AgendaCelebra()
        {

            return View();
        }

        public ActionResult HomeCaja()
        {
            var model = new List<HerramientaDTO>();
            model = UtilidadNeg.ConsultarHerramienta();
            return View(model);
        }

        public ActionResult DetalleCaja(int Id)
        {
            var model = UtilidadNeg.ConsultarHerramientaDetalleID(Id);
            if (model.EsVideo)
            {
                string codigo = ObtenerCodigoVideoYoutube(model.UrlVideo.Trim());
                model.UrlVideoEmbebido = "https://www.youtube.com/embed/" + codigo;
            }
            return View(model);
        }

        private static string ObtenerCodigoVideoYoutube(string youTubeUrl)
        {
            //Setup the RegEx Match and give it 
            Match regexMatch = Regex.Match(youTubeUrl, "^[^v]+v=(.{11}).*",
                               RegexOptions.IgnoreCase);
            if (regexMatch.Success)
            {
                return regexMatch.Groups[1].Value;
            }
            return youTubeUrl;
        }
        public ActionResult _DatosAgenda(string id)
        {
            var model = new UtilidadHomeModels();
            if (!string.IsNullOrEmpty(id))
            {
                if (id != "0")
                {
                    UtilidadDataDetalleDTO resultado = UtilidadNeg.ConsultarDetallePorId(Convert.ToInt32(id));
                    string host = Request.Url.Scheme + "://" + Request.Url.Authority;
                    model = TranslatorUtilidad.TranslatorAgendaDetalle(resultado, host);
                    ViewBag.tituloevento = model.Titulo;
                }
            }

            return PartialView("_DatosAgenda", model);
        }

        public ActionResult _DatosHerramienta(string id)
        {
            var model = new HerramientaDetalleDTO();
            if (!string.IsNullOrEmpty(id))
            {
                model = UtilidadNeg.ConsultarHerramientaDetalleID(Convert.ToInt32(id));
                if (model.EsVideo)
                {
                    string codigo = ObtenerCodigoVideoYoutube(model.UrlVideo.Trim());
                    model.UrlVideoEmbebido = "https://www.youtube.com/embed/" + codigo;
                }
            }

            return PartialView("_DatosHerramienta", model);
        }
        public ActionResult _DatosListadoCaja(string id)
        {

            var model = new List<HerramientaDTO>();
            if (!string.IsNullOrEmpty(id))
            {
                if (id != "0")
                {
                    model = UtilidadNeg.ConsultarHerramientaPorTipoID(Convert.ToInt32(id));
                }
                else
                {
                    model = UtilidadNeg.ConsultarHerramienta();

                }
            }

            return PartialView("_DatosListadoCaja", model);
        }

        public ActionResult _DatosRecientes(string id)
        {
            int TipoUtilidadId = ConvocatoriaNeg.ObtenerId(Comunes.ConstantesRecursosBD.NOMBRE_UTILIDAD_EVENTO);
            List<NoticiasDataDTO> model = UtilidadNeg.ConsultarNoticiasRecientes(TipoUtilidadId);

            return PartialView("_DatosRecientes", model);
        }
    }
}