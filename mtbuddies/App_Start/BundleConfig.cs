using System.Web;
using System.Web.Optimization;

namespace mtbuddies
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;
            bundles.Add(new ScriptBundle("~/bundles/apps").Include(
                "~/Scripts/app.js"));                 

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/css/main.css"));

        }
    }
}
