using System.Web;
using System.Web.Optimization;

namespace mtbuddies
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {            
            bundles.Add(new ScriptBundle("~/bundles/apps").Include(
                "~/Scripts/app.js"));
        }
    }
}
