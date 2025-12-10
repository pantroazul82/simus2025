using System.Web;
using System.Web.Optimization;
using System.Windows.Media;
using static DevExpress.Xpo.DB.DataStoreLongrunnersWatch;

namespace WebSImus.App_Start
{
    public class BundleConfig
    {
		// Para obtener más información sobre las uniones, consulte http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.

            bundles.Clear();
            bundles.ResetAll();

            BundleTable.EnableOptimizations = false;
            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").IncludeDirectory(
                       "~/Scripts/bootstrap", "*.js", true));



            bundles.Add(new ScriptBundle("~/Scripts/jquery").IncludeDirectory(
                        "~/Scripts/jquery", "*.js", true));



            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
             "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/Scripts/jqueryval").Include(
                       "~/Scripts/jquery.validate*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/jquery-ui.css",
                       "~/css/simus_font.css",
                        "~/css/backend_18.css",
                          "~/css/theme-default.css"));

            bundles.Add(new StyleBundle("~/bundles/fontawesome").Include(
                "~/fonts/fontawesome-free-6.7.2-web/css/all.css"
            ));




            bundles.Add(new StyleBundle("~/Content/estatico").Include(
                     "~/Content/bootstrap.css",
                     "~/Content/jquery-ui.css",
                      "~/css/newstyles.css",
                     "~/css/theme-default_oscuro.css",
                     "~/css/simus_font.css"));

            bundles.Add(new StyleBundle("~/Content/publico.css").Include(
                    "~/Content/bootstrap.css",
                    "~/Content/jquery-ui.css",
                    "~/css/newstyles.css",
                    "~/css/simus_font.css"));

            bundles.Add(new StyleBundle("~/Content/celebra").Include(
                      "~/Content/bootstrap.css",
                       "~/css/theme-celebra.css"));

            bundles.Add(new StyleBundle("~/Content/escuelas").Include(
                     "~/css/backend_18.css"));


            bundles.Add(new StyleBundle("~/Content/musica").Include(
                      "~/Content/bootstrap.css",
                       "~/css/theme-default_oscuro.css",
                       "~/css/simus_font.css"));

            bundles.Add(new StyleBundle("~/Content/front_css").Include(
                      "~/Content/bootstrap.css",
                      "~/css/style.css"));
        }
    }
}