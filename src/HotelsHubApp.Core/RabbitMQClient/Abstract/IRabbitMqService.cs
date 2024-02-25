using RabbitMQ.Client;

namespace HotelsHubApp.Core.RabbitMQClient.Abstract
{
    public interface IRabbitMqService
    {
        IConnection GetConnection();
        IModel GetModel(IConnection connection);
    }
}
