using System.Web.Optimization;

namespace TicketSellingSystem.Bundles
{
    public class JsBundles
    {
        public static void RegisterJs(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/Bootstrap/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/JQuery/jquery-*"));

            bundles.Add(new ScriptBundle("~/bundles/otherLibraries").Include(
                "~/Scripts/OtherLibraries/Modernizr/modernizr-*",
                "~/Scripts/OtherLibraries/XEditable/xeditable.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/Angular/angular.js",
                "~/Scripts/Angular/angular-route.js",
                "~/Scripts/Angular/angular-cookies.js",
                "~/Scripts/Angular-ui/ui-bootstrap.js",
                "~/Scripts/Angular-ui/ui-bootstrap-tpls.js"));

            bundles.Add(new ScriptBundle("~/bundles/controllers").Include(
                "~/Scripts/Application/Controllers/registerController.js",
                "~/Scripts/Application/Controllers/loginController.js",
                "~/Scripts/Application/Controllers/mainController.js",
                "~/Scripts/Application/Controllers/filmController.js",
                "~/Scripts/Application/Controllers/adminUserController.js",
                "~/Scripts/Application/Controllers/adminCinemaController.js",
                "~/Scripts/Application/Controllers/authController.js"));

            bundles.Add(new ScriptBundle("~/bundles/services").Include(
                "~/Scripts/Application/Services/authService.js",
                "~/Scripts/Application/Services/adminUserService.js",
                "~/Scripts/Application/Services/adminCinemaService.js",
                "~/Scripts/Application/Services/mainLoadingService.js",
                "~/Scripts/Application/Services/filmLoadingService.js",
                "~/Scripts/Application/Services/userLoadingService.js",
                "~/Scripts/Application/Services/cinemaLoadingService.js",
                "~/Scripts/Application/Services/sessionService.js",
                "~/Scripts/Application/Services/authResolveService.js"));

            bundles.Add(new ScriptBundle("~/bundles/events").Include(
                "~/Scripts/Application/Events/appRun.js",
                "~/Scripts/Application/Events/routeChangeStart.js",
                "~/Scripts/Application/Events/goToMainPage.js",
                "~/Scripts/Application/Events/authNotAuthenticated.js",
                "~/Scripts/Application/Events/authNotAuthorized.js"));

            bundles.Add(new ScriptBundle("~/bundles/constants").Include(
                "~/Scripts/Application/Constants/routes.js",
                "~/Scripts/Application/Constants/authEvents.js",
                "~/Scripts/Application/Constants/roles.js",
                "~/Scripts/Application/Constants/constants.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/application").Include(
                "~/Scripts/Application/modules.js",
                "~/Scripts/Application/Config/routeConfig.js",
                "~/Scripts/Application/Config/authInterceptor.js"
                ));
        }
    }
}