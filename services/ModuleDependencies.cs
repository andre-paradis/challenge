using Autofac;
using common;
using persistence;

namespace services
{ 

    /// <summary>
    /// autofac dependencies for services assembly
    /// </summary>
    /// <seealso cref="Autofac.Module" />
    public class ModuleDependencies : Module
    {
        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new SuggestionServiceImpl(c.Resolve<ILogProvider>(), c.Resolve<ICityRepository>())).As<ISuggestionService>();
        }
    }
}
