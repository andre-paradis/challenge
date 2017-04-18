﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
