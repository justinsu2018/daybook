using System.Web.Optimization;

namespace Daybook.WebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lab").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/underscore.min.js",
                        "~/Content/metisMenu/metisMenu.min.js",
                        "~/Scripts/morrisjs/morris.js",
                        "~/Scripts/raphael/raphael.js",
                        "~/Scripts/moment.min.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/sb-admin-2.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                    "~/Scripts/app/controllers/payee/controllers/payeeController.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/sb-admin-2.css",
                      "~/Scripts/morrisjs/morris.css",
                      "~/Content/font-awesome/css/font-awesome.css",
                      "~/Content/font-awesome.css",
                      "~/Content/metisMenu/metisMenu.min.css"));
        }
    }
}
