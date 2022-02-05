using Microsoft.Extensions.DependencyInjection;

namespace HotelsHubApp.Core.Utilities.IoC
{
    public static class ServiceCreator
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
