using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace Core.Infrastructure.DependencyManagement
{
    public interface IDependencyRegistrar
    {
        void Register(ContainerBuilder builder, ITypeFinder typeFinder);

        int Order { get; }
    }
}
