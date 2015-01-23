using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Autofac;
using Core;
using Core.Infrastructure.DependencyManagement;
using Autofac.Builder;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Data;
using Core.Data;
using Service.Customers;
using System.Reflection;
using System.Web.Mvc;
using Service.Authentication;
using Web.FrameWork.Mvc.Routes;
using Core.Caching;
namespace Web.FrameWork
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
         

            //HTTP context and other related stuff
            builder.Register(c =>
                //register FakeHttpContext when HttpContext is not available
                new HttpContextWrapper(HttpContext.Current) as HttpContextBase).As<HttpContextBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Request)
                .As<HttpRequestBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Response)
                .As<HttpResponseBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Server)
                .As<HttpServerUtilityBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Session)
                .As<HttpSessionStateBase>()
                .InstancePerHttpRequest();

            //controllers
            builder.RegisterControllers(typeFinder.GetAssemblies().ToArray());

            builder.Register<IDbContext>(c => new RTDbContext());
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerHttpRequest();

            //cache manager
            builder.RegisterType<MemoryCacheManager>().As<ICacheManager>().Named<ICacheManager>("nop_cache_static").SingleInstance();
            builder.RegisterType<PerRequestCacheManager>().As<ICacheManager>().Named<ICacheManager>("nop_cache_per_request").InstancePerHttpRequest();

            //work context
            builder.RegisterType<WebWorkContext>().As<IWorkContext>().InstancePerHttpRequest();

            //service
            builder.RegisterType<FormsAuthenticationService>().As<IAuthenticationService>().InstancePerHttpRequest();
            builder.RegisterType<CustomerService>().As<ICustomerService>().InstancePerHttpRequest();
            builder.RegisterType<CustomerRegistrationService>().As<ICustomerRegistrationService>().InstancePerHttpRequest();

            builder.RegisterType<RoutePublisher>().As<IRoutePublisher>().SingleInstance();
        }
        public int Order
        {
            get { return 0; }
        }
    }
}
