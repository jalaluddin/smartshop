using System.Web;
using System.Web.Optimization;

namespace SmartShop.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/theme").Include(
                      "~/Scripts/jquery-2.1.4.min.js",
                      "~/Scripts/simpleCart.min.js",
                      "~/Scripts/bootstrap-3.1.1.min.js", 
                      "~/Scripts/jquery.easing.min.js",
                      "~/Scripts/easyResponsiveTabs.js",
                      "~/Scripts/pignose.layerslider.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/jquery-ui.css",
                      "~/Content/style.css",
                      "~/Content/pignose.layerslider.css"));

            bundles.Add(new StyleBundle("~/Content/admin_css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/ionicons.min.css",
                      "~/Content/jquery-jvectormap.css",
                      "~/Content/AdminLTE.min.css",
                      "~/Content/_all-skins.min.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/admin_js").Include(
                      "~/Scripts/jquery-2.1.4.min.js",
                      "~/Scripts/Admin/bootstrap.min.js",
                      "~/Scripts/fastclick.js",
                      "~/Scripts/adminlte.min.js",
                      "~/Scripts/dataTables.bootstrap.min.js",
                      "~/Scripts/jquery.dataTables.min.js",
                      "~/Scripts/jquery.sparkline.min.js",
                      "~/Scripts/jquery-jvectormap-1.2.2.min.js",
                      "~/Scripts/jquery-jvectormap-world-mill-en.js",
                      "~/Scripts/jquery.slimscroll.min.js",
                      "~/Scripts/Chart.min.js",
                      "~/Scripts/dashboard2.js",
                      "~/Scripts/demo.js"
                      ));
        }
    }
}
