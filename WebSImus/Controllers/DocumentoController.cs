using SM.Aplicacion.Documentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebSImus.Models;
using WebSImus.Translator;

namespace WebSImus.Controllers
{
    public class DocumentoController : BaseController
    {
        //
        // GET: /Documento/
        public ActionResult Index()
        {
            return View();
        }

     
        public ActionResult Descargar(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DocumentoModels documento = TranslatorDocumento.ConsultaDocumentoPorId(Convert.ToInt32(id));

            if (documento == null)
            {
                return HttpNotFound();
            }

            return File(documento.BytesArchivo, documento.TipoContenido, documento.NombreArchivo);
        }
	}
}