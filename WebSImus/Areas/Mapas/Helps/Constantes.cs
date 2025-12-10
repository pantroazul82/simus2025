using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSImus.Areas.Mapas.Helps
{
    public enum enumEstado
    {
        Correcto = 200,
        Error = 500,
        Vacio = 304

    }
    public static class Constantes
    {
        public static class Respuestas
        {
            public const string Correcta = "Respuesta Correcta";
            public const string Vacio = "Respuesta Vacía";
            public const string Error = "Error en el servidor";
        }

    }

    public static class Utilidades
    {
        public static string GetBaseUrl()
        {
            var request = HttpContext.Current.Request;
            var appUrl = HttpRuntime.AppDomainAppVirtualPath;

            if (appUrl != "/")
                appUrl = "/" + appUrl;

            var baseUrl = string.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Authority, appUrl);

            return baseUrl;
        }
    }
}