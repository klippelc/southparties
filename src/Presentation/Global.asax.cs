using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Presentation
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //builder.Services.AddSingleton<IMyService, MyService>();
            // MediatR
            //For<ServiceFactory>().Use<ServiceFactory>(ctx => ctx.GetInstance);
            //For<IMediator>().Use<Mediator>();

            //For<IDbService>().Use(ctx => DbContextFactory()).LifecycleIs<TransientLifecycle>();

        }
    }
}
