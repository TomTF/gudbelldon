using System.Web;
using System.Web.Optimization;

namespace Gudbelldon
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/sitebundle").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.validate.messages_de.js",
                        "~/Scripts/materialize.min.js",
                        "~/Scripts/jquery.fullPage.min.js",
                        "~/Scripts/Site/contactMe.js",
                        "~/Scripts/bricklayer.min.js",
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Site.css",
                      "~/Content/materialize.min.css",
                      "~/Content/bricklayer.min.css",
                      "~/Content/jquery.fullPage.css",
                      "~/Content/animate.css"));

            bundles.Add(new ScriptBundle("~/bundles/admin-vendor-scripts").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.messages_de.js",
                "~/Scripts/materialize.min.js",
                "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/bundles/admin-vendor-styles").Include(
                "~/Content/materialize.min.css"));

        }
    }
}
