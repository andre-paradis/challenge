using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System.Web.Http;
using System.Web.Mvc;

namespace challenge
{
    public class Dependencies
    {
        public static void registerDependencies()
        {
            var builder = new ContainerBuilder();

            // register common 
            var common = typeof(common.ModuleDependencies).Assembly;
            builder.RegisterAssemblyModules(common);

            var persistence = typeof(persistence.ModuleDependencies).Assembly;
            builder.RegisterAssemblyModules(persistence);

            var services = typeof(services.ModuleDependencies).Assembly;
            builder.RegisterAssemblyModules(services);

            // Register mvc controllers
            builder.RegisterControllers(typeof(Global).Assembly);

            // Register webapi controllers
            // You can register controllers all at once using assembly scanning...
            builder.RegisterApiControllers(typeof(Global).Assembly);

            // inject into dependency resolver for MVC
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // ... and also WebAPI
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}