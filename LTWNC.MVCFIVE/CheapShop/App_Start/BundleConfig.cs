using System.Web;
using System.Web.Optimization;

namespace CheapShop
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Danh cho trang Admin
            bundles.Add(new ScriptBundle("~/bundles/admmainjs").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js",
                "~/Scripts/plugins/metismenu/jquery.metisMenu.js",
                "~/Scripts/plugins/slimscroll/jquery.slimscroll.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/admjqueryval").Include(
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/jquery.validate.bootstrap.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/admcustomjs").Include(
               "~/Scripts/cheapdeal.js",
               "~/Scripts/plugins/pace/pace.min.js"
               ));

            bundles.Add(new StyleBundle("~/Content/admbootstrap").Include(
                "~/Content/bootstrap-3.3.0.min.css",
                "~/Content/font-awesome.css"
                ));

            bundles.Add(new StyleBundle("~/Content/admstyle").Include(
                "~/Content/animate.css",
                "~/Content/AdmSite.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/style.css"));

            //gianh cho trang chu
            bundles.Add(new ScriptBundle("~/bundles/mainjs").Include(
                        "~/Scripts/classie.js",
                        "~/Scripts/cbpAnimatedHeader.js",
                        "~/Scripts/inspinia.js",
                        "~/Scripts/wow.min.js"));
        }
    }
}
