namespace HotelsHubApp.Core.RabbitMQClient.Abstract
{
    public interface IPublisherService
    {
        bool SendData(string queueName, string data);
    }
}
