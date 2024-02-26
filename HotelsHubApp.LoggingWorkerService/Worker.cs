using HotelsHubApp.Core.RabbitMQClient.Abstract;
using HotelsHubApp.Core.RabbitMQClient.Concrete;
using HotelsHubApp.LoggingWorkerService.RabbitMq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;

namespace HotelsHubApp.LoggingWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IMessageConsumer _messageConsumer;
        private readonly IRabbitMqService _rabbitMqService;
        public Worker(IMessageConsumer messageConsumer,
                      ILogger<Worker> logger,
                      IRabbitMqService rabbitMqService)
        {
            _messageConsumer = messageConsumer;
            _logger = logger;
            _rabbitMqService = rabbitMqService;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _messageConsumer.Consume("responseLog",LogLevel.Information);
            _messageConsumer.Consume("errorLog", LogLevel.Error);

            return base.StartAsync(cancellationToken);

        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
            }
        }
    }
}
