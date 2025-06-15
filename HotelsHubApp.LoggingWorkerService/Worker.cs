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

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker service is starting...");
            
            // RabbitMQ'nun tamamen hazır olmasını bekle - daha uzun süre
            await Task.Delay(TimeSpan.FromSeconds(45), stoppingToken);
            
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("Attempting to start RabbitMQ message consumers...");
                    
                    _messageConsumer.Consume("responseLog", LogLevel.Information);
                    _messageConsumer.Consume("errorLog", LogLevel.Error);
                    
                    _logger.LogInformation("Worker service started successfully and listening for messages");
                    
                    // Sonsuz döngüde bekle
                    while (!stoppingToken.IsCancellationRequested)
                    {
                        await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to start message consumers. Retrying in 60 seconds...");
                    await Task.Delay(TimeSpan.FromSeconds(60), stoppingToken);
                }
            }
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker service is stopping...");
            await base.StopAsync(cancellationToken);
        }
    }
}
