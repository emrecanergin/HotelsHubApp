using HotelsHubApp.Core.RabbitMQClient.Abstract;
using HotelsHubApp.Core.RabbitMQClient.Concrete;
using HotelsHubApp.Core.RedisClient.Abstract;
using HotelsHubApp.Core.RedisClient.Concrete;
using HotelsHubApp.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
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
            serviceCollection.AddHttpClient("HotelbedsRequest", c =>
            {
                c.BaseAddress = new Uri("https://api.test.hotelbeds.com/");
                c.DefaultRequestHeaders.Add("Accept", "application/json");
                c.DefaultRequestHeaders.Add("Accept-Encoding", "*");
                c.DefaultRequestHeaders.Add("Api-key", "b4036e737662995f3452af42bc59e114");
                c.DefaultRequestHeaders.Add("X-Signature", Signature.CreateSignature());
            });
        }
    }
}
