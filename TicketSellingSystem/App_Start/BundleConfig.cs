using System.Web.Optimization;
using TicketSellingSystem.Bundles;

namespace TicketSellingSystem
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            JsBundles.RegisterJs(bundles);
            StyleBundles.RegisterStyles(bundles);
        }
    }
}