using Autofac;

namespace common
{
    /// <summary>
    /// Autofac module for the common assembly
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
            builder.Register(c => new NLogLogProvider()).As<ILogProvider>();
        }
    }
}
