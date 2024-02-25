using Autofac;
using Autofac.Extensions.DependencyInjection;
using Core.DataAccess.Context;
using HotelsHubApp.Business.DependencyResolvers.Autofac;
using HotelsHubApp.Core.DependencyResolvers.Autofac;
using HotelsHubApp.Core.DependencyResolvers.Microsoft;
using HotelsHubApp.Core.Extensions;
using HotelsHubApp.Core.RedisClient.Options;
using HotelsHubApp.Core.Utilities.IoC;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;

namespace HotelsHubApp.WebAPI.Extensions
{
    public static class BuilderExtensionClass
    {
        public static WebApplicationBuilder BuilderExtension(this WebApplicationBuilder builder)
        {

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHealthChecks();
            builder.Services.Configure<RedisOptions>(builder.Configuration.GetSection("RedisOptions"));
            builder.Services.AddDependencyResolvers(new IBaseModule[] { new CoreModule() });
            builder.Services.AddDbContext<HotelbedsDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration["ConnectionStrings:ConnectionString"]);
            });

            builder.Services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            var conf = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("serilogConfiguration.json")
                .Build();

            builder.Host
            .UseSerilog((ctx, lc) =>
            {
                lc.ReadFrom.Configuration(conf);   
            })
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(cbuilder =>
            {
                cbuilder.RegisterModule(new AutofacCoreModule());
                cbuilder.RegisterModule(new AutofacBusinessModule());
            });            

            return builder;
        }
    }
}
