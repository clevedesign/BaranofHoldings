using System.Web;
using System.Web.Optimization;

namespace BaranofHoldings
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/jasny-bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/bootstrap.css",
                 "~/Content/styles.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular")
                   .IncludeDirectory("~/Scripts/controllers", "*.js")
                   .IncludeDirectory("~/Scripts/directives", "*.js")
                   .Include("~/Scripts/angular-sanitize.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
