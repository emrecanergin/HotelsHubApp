using HotelsHubApp.Core.RabbitMQClient.Abstract;
using HotelsHubApp.Core.RabbitMQClient.Concrete;
using HotelsHubApp.Core.RedisClient.Abstract;
using HotelsHubApp.Core.RedisClient.Concrete;
using HotelsHubApp.Core.Utilities.HttpRequest.HotelbedsAPI;
using HotelsHubApp.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;


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
        }
    }
}
