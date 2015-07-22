using System.Web.Optimization;

namespace TicketSellingSystem.Bundles
{
    public class StyleBundles
    {
        public static void RegisterStyles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                "~/Content/Bootstrap/bootstrap.css",
                "~/Content/Bootstrap/bootstrap-theme.css"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/AppStyles/Site.css",
                "~/Content/AppStyles/Register.css",
                "~/Content/AppStyles/Login.css",
                "~/Content/AppStyles/Main.css",
                "~/Content/AppStyles/Admin.css"
                ));
        }
    }
}