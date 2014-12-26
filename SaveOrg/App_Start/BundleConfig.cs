using System.Web;
using System.Web.Optimization;

namespace SaveOrg
{
  public class BundleConfig
  {
    private static readonly string[] Bootstrap = 
    {
      "~/Scripts/bootstrap*",
      "~/Scripts/respond*"
    };

    private static readonly string[] Jquery = 
    {
      "~/Scripts/jquery-{version}.js"
    };

    private static readonly string[] StudentEdit = 
    {
      "~/Scripts/Views/Student/Edit*"
    };

    private static readonly string[] JqueryVal = 
    {
      "~/Scripts/jquery.validate*"
    };

    private static readonly string[] Modernizr = 
    {
      "~/Scripts/modernizr-*"
    };

    private static readonly string[] Css = 
    {
      "~/Content/bootstrap.css",
      "~/Content/site.css"
    };

    // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
    public static void RegisterBundles(BundleCollection bundles)
    {
      // Set EnableOptimizations to false for debugging. For more information,
      // visit http://go.microsoft.com/fwlink/?LinkId=301862
#if DEBUG
      BundleTable.EnableOptimizations = false;
#else
      BundleTable.EnableOptimizations = true;
#endif

      bundles.Add(new StyleBundle("~/Content/Layout").Include(Css));

      bundles.Add(new ScriptBundle("~/Bundles/Layout").Include(Modernizr).Include(Jquery).Include(JqueryVal).Include(Bootstrap));

      bundles.Add(new ScriptBundle("~/Bundles/Student/Edit").Include(StudentEdit));
    }
  }
}
