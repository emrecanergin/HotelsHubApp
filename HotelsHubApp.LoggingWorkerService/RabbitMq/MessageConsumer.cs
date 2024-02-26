using HotelsHubApp.Core.RabbitMQClient.Abstract;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;
using System.Text;

namespace HotelsHubApp.LoggingWorkerService.RabbitMq
{
    internal class MessageConsumer : IMessageConsumer
    {
        private readonly IRabbitMqService _rabbitMqService;
        private readonly ILogger<MessageConsumer> _logger;
        public MessageConsumer(IRabbitMqService rabbitMqService,
                               ILogger<MessageConsumer> logger)
        {
            _rabbitMqService = rabbitMqService;       
            _logger = logger;
        }
        
        public void Consume(string queueName,LogLevel logLevel)
        {
            var consumer = GetRabbitMQConsumer(out IModel channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body.ToArray());
                _logger.Log(logLevel, message,$"{}");
            };

            channel.BasicConsume(queueName, true, consumer);
        }
        public EventingBasicConsumer GetRabbitMQConsumer(out IModel channel)
        {
            //consider using block
            var connection = _rabbitMqService.GetConnection();
            var rabbitChannel = _rabbitMqService.GetModel(connection);
            channel = rabbitChannel;
            return new EventingBasicConsumer(rabbitChannel);
        }
    }
}
