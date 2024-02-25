using Microsoft.Extensions.DependencyInjection;

namespace HotelsHubApp.Core.Utilities.IoC
{
    public interface IBaseModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}
