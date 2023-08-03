using HotelsHubApp.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;


namespace HotelsHubApp.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(
            this IServiceCollection serviceCollection,IBaseModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }

            return ServiceCreator.Create(serviceCollection);
        }
    }
}
