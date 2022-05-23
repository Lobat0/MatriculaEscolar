using System.Web;
using System.Web.Optimization;

namespace MatriculaAcademica
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/jquery-3.4.1.js",
                      "~/Scripts/DataTables/jquery.dataTables.min.js",
                      "~/Content/DataTables/css/jquery.dataTables.min.css"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/home").Include(   
                        "~/Content/assets/img/favicon.ico",
                        "~/Content/assets/css/font-awesome.css",
                        "~/Content/assets/css/slick.css",
                        "~/Content/assets/css/jquery.fancybox.css",
                        "~/Content/assets/css/theme-color/default-theme.css",
                        "~/Content/assets/css/style.css",
                        "~/Content/assets/js/slick.js",
                        "~/Content/assets/js/waypoints.js",
                        "~/Content/assets/js/jquery.counterup.js",
                        "~/Content/assets/js/jquery.mixitup.js",
                        "~/Content/assets/js/jquery.fancybox.pack.js"
                ));

        }
    }
}
