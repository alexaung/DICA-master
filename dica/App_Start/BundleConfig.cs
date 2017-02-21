using System.Web.Optimization;

namespace dica
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
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
                      "~/Scripts/moment.js",
                      "~/Scripts/respond.js", 
                      "~/Scripts/bootstrap-datetimepicker.js",
                      "~/Scripts/bootstrap-formhelpers.js",
                      "~/Scripts/bootstrap-select.js"));

            bundles.Add(new ScriptBundle("~/bundles/formvalidation").Include(
                        "~/Scripts/FormValidation/formValidation.js",
                        "~/Scripts/FormValidation/framework/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",                      
                      "~/Content/site.css",
                      "~/Content/bootstrap-datetimepicker.css",
                      "~/Content/bootstrap-formhelpers.css",
                      "~/Content/bootstrap-select.css",
                      "~/Content/flag-icon.css"
                      ));
        }
    }
}
