using DevExpress.Web.Mvc;
using System;
using System.Threading;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebSImus.App_Start;
using System.Web.Http;
using System.Net.Http.Formatting;
using OfficeOpenXml;


namespace WebSImus
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            HtmlHelper.ClientValidationEnabled = true;
            HtmlHelper.UnobtrusiveJavaScriptEnabled = true;
         
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
         
            ModelBinders.Binders.DefaultBinder = new DevExpress.Web.Mvc.DevExpressEditorsBinder();
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(new QueryStringMapping("json", "true", "application/json"));
            // EPPlus: la licencia y compatibilidad se establecen vía Web.config (appSettings)
         
        }

        void Session_OnStart(object sender, EventArgs e)
        {

           
        }

        void Session_OnEnd(object sender, EventArgs e)
        {
            // Liberar Cache
            Console.Write("");
            Session.Clear();
        }
        protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            //DevExpressHelper.Theme = "SimusTheme";
            DevExpressHelper.Theme = "Metropolis";

        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
        
            Thread.CurrentThread.CurrentCulture =
            new System.Globalization.CultureInfo("es-CO");

            System.Threading.Thread.CurrentThread.CurrentUICulture =
            new System.Globalization.CultureInfo("es");
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            //if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            //{
            //    HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache");
            //    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
            //    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
            //    HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
            //    HttpContext.Current.Response.End();
            //}
        }

        //protected void Application_EndRequest()
        //{
        //    if (Context.Response.StatusCode == 404)
        //    {
        //        var exception = Server.GetLastError();
        //        var httpException = exception as HttpException;
        //        Response.Clear();
        //        Server.ClearError();
        //        var routeData = new RouteData();
        //        routeData.Values["controller"] = "Error";
        //        routeData.Values["action"] = "NotFound";
        //        routeData.Values["exception"] = exception;
        //        Response.StatusCode = 500;

        //        if (httpException != null)
        //        {
        //            Response.StatusCode = httpException.GetHttpCode();
        //            switch (Response.StatusCode)
        //            {
        //                case 404:
        //                    routeData.Values["action"] = "NotFound";
        //                    break;
        //            }
        //        }
        //        // Avoid IIS7 getting in the middle
        //        Response.TrySkipIisCustomErrors = true;
        //        IController errormanagerController = new ErrorController();
        //        HttpContextWrapper wrapper = new HttpContextWrapper(Context);
        //        var rc = new RequestContext(wrapper, routeData);
        //        errormanagerController.Execute(rc);
        //    }

            
        //}
    }
}
