using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace challenge
{
    public class Dependencies
    {
        public static void registerDependencies()
        {
            var builder = new ContainerBuilder();

            // register common 
            var assembly = typeof(common.ModuleDependencies).Assembly;
            builder.RegisterAssemblyModules(assembly);

            // Register mv controllers
            builder.RegisterControllers(typeof(Global).Assembly);

            // inject into dependency resolver
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}