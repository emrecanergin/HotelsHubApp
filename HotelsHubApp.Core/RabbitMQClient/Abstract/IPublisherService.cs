namespace HotelsHubApp.Core.RabbitMQClient.Abstract
{
    public interface IPublisherService
    {
        void SendData<T>(string queueName, T data);
    }
}
