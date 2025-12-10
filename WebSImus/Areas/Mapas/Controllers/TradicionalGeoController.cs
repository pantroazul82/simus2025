using Newtonsoft.Json.Linq;
using SM.Aplicacion.Geo;
using SM.LibreriaComun.DTO.GEO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using WebSImus.Areas.Mapas.Models;
using WebSImus.Areas.Mapas.Helps;

namespace WebSImus.Areas.Mapas.Controllers
{
    public class TradicionalGeoController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var modelmunicipios = new List<MunicipiosGeoDTO>();
            var resultado = new MunicipioModels();
            var datos = new EstructuraTradicionalModels();
            string respuestadetalle = "";
            int Estado = 0;
            try
            {
                modelmunicipios = MapaMusicalNeg.ConsultarTradicionalMunicipios(Utilidades.GetBaseUrl());
                resultado.Municipios = modelmunicipios;

                if (modelmunicipios.Count > 0)
                {
                    respuestadetalle = Constantes.Respuestas.Correcta;
                    Estado = (int)enumEstado.Correcto;
                }
                else if (modelmunicipios.Count == 0)
                {
                    respuestadetalle = Constantes.Respuestas.Vacio;
                    Estado = (int)enumEstado.Vacio;
                }
                datos = new EstructuraTradicionalModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }
            catch
            {
                respuestadetalle = Constantes.Respuestas.Error;
                Estado = (int)enumEstado.Error;
                resultado = new MunicipioModels();
                datos = new EstructuraTradicionalModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }

            return Request.CreateResponse<EstructuraTradicionalModels>(HttpStatusCode.OK, datos);
        }

        // GET: api/PatGeo/5
        public HttpResponseMessage Get(string Id)
        {
            var modelmunicipios = new List<MunicipiosGeoDTO>();
            var resultado = new MunicipioModels();
            var datos = new EstructuraTradicionalModels();
            string respuestadetalle = "";
            int Estado = 0;
            try
            {
                modelmunicipios = MapaMusicalNeg.ConsultarTradicionalMunicipios(Utilidades.GetBaseUrl(), Id);
                resultado.Municipios = modelmunicipios;

                if (modelmunicipios.Count > 0)
                {
                    respuestadetalle = Constantes.Respuestas.Correcta;
                    Estado = (int)enumEstado.Correcto;
                }
                else if (modelmunicipios.Count == 0)
                {
                    respuestadetalle = Constantes.Respuestas.Vacio;
                    Estado = (int)enumEstado.Vacio;
                }
                datos = new EstructuraTradicionalModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }
            catch
            {
                respuestadetalle = Constantes.Respuestas.Error;
                Estado = (int)enumEstado.Error;
                resultado = new MunicipioModels();
                datos = new EstructuraTradicionalModels() { responseData = resultado, responseDetails = respuestadetalle, responseStatus = Estado };
            }

            return Request.CreateResponse<EstructuraTradicionalModels>(HttpStatusCode.OK, datos);
        }
    }
}
