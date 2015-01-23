using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Core;

namespace Web.FrameWork.Mvc
{
    public class NopDependencyResolver : IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            object obj = EngineContext.Current.ContainerManager.ResolveOptional(serviceType);
            return obj; 
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            var type = typeof(IEnumerable<>).MakeGenericType(serviceType);
            return (IEnumerable<object>)EngineContext.Current.Resolve(type);
        }
    }
}
