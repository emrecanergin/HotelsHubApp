using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using Castle.DynamicProxy;
using HotelsHubApp.Business.Abstract.Hotelbeds.Requests;
using HotelsHubApp.Business.Abstract.Hotelbeds.Services;
using HotelsHubApp.Business.AutoMapper;
using HotelsHubApp.Business.Concrete.Hotelbeds.Management;
using HotelsHubApp.Business.Concrete.Hotelbeds.Requests;
using HotelsHubApp.Business.Concrete.Hotelbeds.Requests.RequestGenerators;
using HotelsHubApp.Business.Helper.ResponseMappping;
using HotelsHubApp.Business.HttpClients.HotelbedsClient;
using HotelsHubApp.Business.HttpRequests.Hotelbeds;
using HotelsHubApp.Core.Utilities.Interceptors;

namespace HotelsHubApp.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //services
            builder.RegisterType<HotelApiConsumer>().As<IHotelApiConsumer>();
            builder.RegisterType<ResponseMap>().As<IResponseMap>();
            builder.RegisterType<SearchManager>().As<ISearchService>();
            builder.RegisterType<CheckRateManager>().As<ICheckRateService>();
            builder.RegisterType<BookingManager>().As<IBookingService>();
            builder.RegisterType<HotelbedsSearchRequest>().As<ISearchRequest>();
            builder.RegisterType<HotelbedsBookingRequest>().As<IBookingRequest>();
            builder.RegisterType<HotelbedsCheckRequest>().As<ICheckRateRequest>();
            builder.RegisterType<AvailabilityRequestBodyGenerator>().As<IAvailabilityRequestBodyGenerator>();



            //automapper
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

            
            //aspects
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
