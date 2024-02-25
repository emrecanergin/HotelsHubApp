using HotelsHubApp.Core.RabbitMQClient.Abstract;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace HotelsHubApp.Core.RabbitMQClient.Concrete
{
    //this page must be recoding!!! (exchange flexibility etc.)
    public class PublisherService : IPublisherService
    {
        IRabbitMqService _rabbitMqService;

        public PublisherService(IRabbitMqService rabbitMqService)
        {
            _rabbitMqService = rabbitMqService;
        }

        public void SendData<T>(string queueName, T data)
        {
            var connection = _rabbitMqService.GetConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare(queue: queueName,
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            //string message = JsonConvert.SerializeObject(data);
            string message = JsonSerializer.Serialize(data);
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                                   routingKey: queueName,
                                   basicProperties: null,
                                   body: body);
        }
    }
}