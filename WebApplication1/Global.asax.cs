using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using DbContext.Models;
using ProjectsRepositorie;
using ProjectsRepositorie.Interfaces;
using ProjectsRepositorie.Repositories;
using ProjectsService;
using ProjectsService.Interfaces;
using ProjectsService.Services;
using WebApplication1.Common;
using WebApplication1.Controllers;

namespace WebApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            var builder = new ContainerBuilder();

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            builder.RegisterType<ContextEntities>();

            RegisterControllers(builder);
            RegisterServices(builder);
            RegisterRepositories(builder);

            builder.RegisterType<HelloWorld>().As<IHelloWorld>();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<ProjectReadOnlyRepositorie>().As<IProjectReadOnlyRepositorie>();
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<ProjectListService>().As<IProjectListService>();
        }

        private static void RegisterControllers(ContainerBuilder builder)
        {
            builder.RegisterType<HomeController>().InstancePerRequest();
            builder.RegisterType<ProjectListsController>().InstancePerRequest();
            builder.RegisterType<ProjectController>().InstancePerRequest();
        }


        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

        }
    }
}
