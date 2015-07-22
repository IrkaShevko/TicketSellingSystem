using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Autofac.Integration.WebApi;
using TicketSellingSystemInfrastructure.Services;

namespace TicketSellingSystem.Filters
{
    public class BlockedUserFilter : IAutofacActionFilter
    {
        private readonly IUserService _service;

        public BlockedUserFilter(IUserService service)
        {
            _service = service;
        }

        public void OnActionExecuting(HttpActionContext actionContext)
        {
            var name = actionContext.RequestContext.Principal.Identity.Name;
            var user = _service.GetUserByEmail(name);
            if (user.Blocked)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
            }
        }

        public void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {}
    }
}