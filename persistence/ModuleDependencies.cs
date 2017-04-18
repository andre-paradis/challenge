using Autofac;

namespace persistence
{
    public class ModuleDependencies : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new NHCityRepository()).As<ICityRepository>();
        }
    }
}
