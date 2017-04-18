using Autofac;

namespace common
{
    public class ModuleDependencies : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new NLogLogProvider()).As<ILogProvider>();
        }
    }
}
