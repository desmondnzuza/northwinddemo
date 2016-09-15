using System.Web;
using System.Web.Optimization;

namespace KMC.Northwind.Demo.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            var prerequisiteBundle = new ScriptBundle("~/bundles/angularprerequisite").Include(
                "~/assets/js/jquery-2.1.1.min.js",
                "~/assets/js/jquery.signalR.min.js",
                "~/Scripts/jquery.validate*"
                ).Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"
                ).Include(
                "~/Scripts/angular.js",
                "~/Scripts/angular-ui-router.js",
                "~/assets/ui.bootstrap.custom/ui-bootstrap-custom-tpls-0.14.3.js",
                "~/assets/js/toastr.js",
                "~/assets/js/moment.js",
                "~/assets/js/angular-moment.js"
                );

            var chartsBundle = new ScriptBundle("~/bundles/charts").Include(
               "~/assets/js/highcharts.min.js",
               "~/assets/js/drilldown.min.js",
               "~/app/common/directives/highcharts-ng.js"
               );

            var appBundle = new ScriptBundle("~/bundles/app").Include(
                "~/app/app.js",
                "~/app/route/routerConfig.js")
                .Include(
                "~/app/category/controllers/*.js",
                "~/app/product/controllers/*.js",
                "~/app/report/controllers/*.js",
                "~/app/supplier/controllers/*.js");

            bundles.Add(prerequisiteBundle);
            bundles.Add(chartsBundle);
            bundles.Add(appBundle);
        }
    }
}
