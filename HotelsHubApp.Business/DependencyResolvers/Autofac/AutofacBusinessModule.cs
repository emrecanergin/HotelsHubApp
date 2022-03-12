using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using Castle.DynamicProxy;
using HotelsHubApp.Business.Abstract.Hotelbeds.Services;
using HotelsHubApp.Business.AutoMapper;
using HotelsHubApp.Business.Concrete.Hotelbeds.Management;
using HotelsHubApp.Business.Helper.ResponseMappping;
using HotelsHubApp.Core.Utilities.Interceptors;

namespace HotelsHubApp.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ResponseMap>().As<IResponseMap>();
            builder.RegisterType<SearchManager>().As<ISearchService>();
            builder.RegisterType<CheckRateManager>().As<ICheckRateService>();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            })).AsSelf().SingleInstance();
            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                })
                .SingleInstance();
        }
    }
}
