using System.Web;
using System.Web.Optimization;

namespace mtbuddies
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/apps").Include(
                "~/Scripts/app.js"));                 

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/css/main.css",
                "~/Content/_reset.scss",
                "~/Content/_layout.scss"));
        }
    }
}
