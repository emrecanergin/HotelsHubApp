using Autofac;
using Autofac.Extensions.DependencyInjection;
using HotelsHubApp.Business.DependencyResolvers.Autofac;
using HotelsHubApp.Core.DependencyResolvers.Autofac;
using Serilog;

namespace HotelsHubApp.WebAPI.Extensions
{
    public static class BuilderExtensionClass
    {
        public static WebApplicationBuilder BuilderExtension(this WebApplicationBuilder builder)
        {
            builder.Host
            .UseSerilog((ctx, lc) =>
            {
                lc.WriteTo.MongoDB("mongodb://localhost/logscollection");
            })
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(builder1 =>
            {
                builder1.RegisterModule(new AutofacCoreModule());
                builder1.RegisterModule(new AutofacBusinessModule());
            });
            return builder;
        }
    }
}
