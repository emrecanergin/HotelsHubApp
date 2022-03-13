using HotelsHubApp.Core.RabbitMQClient.Abstract;
using HotelsHubApp.Core.RabbitMQClient.Concrete;
using HotelsHubApp.Core.RedisClient.Abstract;
using HotelsHubApp.Core.RedisClient.Concrete;
using HotelsHubApp.Core.Utilities.HttpRequest.HotelbedsAPI;
using HotelsHubApp.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
using Newtonsoft.Json;


namespace HotelsHubApp.Core.DependencyResolvers.Microsoft
{
    public class CoreModule : IBaseModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IHttpRequestService<>), typeof(HttpRequestService<>));
            //rabbitmq
            serviceCollection.AddScoped<IPublisherService,PublisherService>();
            serviceCollection.AddScoped<IRabbitMqService, RabbitMqService>();
            //redis
            serviceCollection.AddScoped<RedisServer>();
            serviceCollection.AddScoped<IRedisService,RedisManager>();
            serviceCollection.AddEndpointsApiExplorer();
            serviceCollection.AddSwaggerGen();
            serviceCollection.AddHealthChecks();
            serviceCollection.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //request is coming null when its include
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });
            serviceCollection.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.AllowReadingFromString |
                                                               JsonNumberHandling.WriteAsString;
            });

        }
    }
}
