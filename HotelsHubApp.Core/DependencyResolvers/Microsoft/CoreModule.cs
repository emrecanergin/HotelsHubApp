using HotelsHubApp.Core.RabbitMQClient.Abstract;
using HotelsHubApp.Core.RabbitMQClient.Concrete;
using HotelsHubApp.Core.RedisClient.Abstract;
using HotelsHubApp.Core.RedisClient.Concrete;
using HotelsHubApp.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using HotelsHubApp.Core.Utilities.HttpRequest;
using HotelsHubApp.Business.HttpRequests.Helper;

namespace HotelsHubApp.Core.DependencyResolvers.Microsoft
{
    public class CoreModule : IBaseModule
    {
        public void Load(IServiceCollection serviceCollection)
        { 
            //rabbitmq
            serviceCollection.AddScoped<IPublisherService,PublisherService>();
            serviceCollection.AddScoped<IRabbitMqService, RabbitMqService>();
            //redis
            serviceCollection.AddScoped<RedisServer>();
            serviceCollection.AddScoped<IRedisService,RedisManager>();


            //httprequest
            serviceCollection.AddScoped(typeof(IHttpRequestService<>), typeof(HttpRequestService<>));
            serviceCollection.AddHttpClient("HotelbedsRequest", (serviceProvider, c) =>
            {
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                c.BaseAddress = new Uri("https://api.test.hotelbeds.com/");
                c.Timeout = TimeSpan.FromSeconds(60); // 60 saniye timeout
                c.DefaultRequestHeaders.Add("Accept", "application/json");
                c.DefaultRequestHeaders.Add("Accept-Encoding", "*");
                var apiKey = configuration["Hotelbeds:ApiKey"] ?? "apikey";
                c.DefaultRequestHeaders.Add("Api-key", apiKey);
                // X-Signature her request'te dinamik hesaplanacak
            });
        }
    }
}
