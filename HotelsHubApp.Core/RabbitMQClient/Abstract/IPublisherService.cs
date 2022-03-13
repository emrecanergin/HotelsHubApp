namespace HotelsHubApp.Core.RabbitMQClient.Abstract
{
    public interface IPublisherService
    {
        bool SendData<T>(string queueName, T data);
    }
}
