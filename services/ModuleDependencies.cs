using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using common;
using persistence;

namespace services
{
    public class ModuleDependencies : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new SuggestionServiceImpl(c.Resolve<ILogProvider>(), c.Resolve<ICityRepository>())).As<ISuggestionService>();
        }
    }
}
