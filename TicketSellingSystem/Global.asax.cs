using System;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace TicketSellingSystem
{
    public class Global : HttpApplication
    {
        private void Application_Start(object sender, EventArgs e)
        {
            AutoFacConfig.Initialize();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.Initialize();
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            var authCookie =
                Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null || authCookie.Value == "")
                return;
            var authTicket =
                FormsAuthentication.Decrypt(authCookie.Value);
            var formsIdentity = new FormsIdentity(authTicket);
            var roles = authTicket.UserData.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
            HttpContext.Current.User = new GenericPrincipal(formsIdentity, roles);
        }
    }
}