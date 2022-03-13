using HotelsHubApp.DataAccess.Concrete.MongoDB;

namespace HotelsHubApp.WebAPI.Extensions
{
    public static class MongoDbExtension
    {
        public static IServiceCollection AddMongoDbSettings(this IServiceCollection services,
           IConfiguration configuration)
        {
            return services.Configure<MongoDbSettings>(options =>
            {
                options.ConnectionString = configuration
                    .GetSection(nameof(MongoDbSettings) + ":" + MongoDbSettings.ConnectionStringValue).Value;
                options.Database = configuration
                    .GetSection(nameof(MongoDbSettings) + ":" + MongoDbSettings.DatabaseValue).Value;
            });
        }
    }
}
