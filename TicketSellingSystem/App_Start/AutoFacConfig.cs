using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using TicketSellingSystem.Controllers;
using TicketSellingSystem.Filters;
using TicketSellingSystemInfrastructure.Context;
using TicketSellingSystemInfrastructure.Repository;
using TicketSellingSystemInfrastructure.Services;

namespace TicketSellingSystem
{
    public class AutoFacConfig
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof (HomeController).Assembly);
            builder.RegisterApiControllers(typeof (AccountController).Assembly);

            builder.RegisterGeneric(typeof (EfRepository<>))
                .As(typeof (IRepository<>))
                .InstancePerRequest();

            builder.RegisterType(typeof (TicketSellingSystemContext))
                .As(typeof (DbContext))
                .InstancePerRequest();

            var assembly = Assembly.GetAssembly(typeof (IUserService));

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.Register(c => new BlockedUserFilter(c.Resolve<IUserService>()))
                .AsWebApiActionFilterFor<ApiController>()
                .InstancePerRequest();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            var config = GlobalConfiguration.Configuration;
            builder.RegisterWebApiFilterProvider(config);
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}