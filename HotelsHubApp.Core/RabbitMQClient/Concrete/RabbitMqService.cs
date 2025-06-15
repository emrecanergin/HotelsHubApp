using HotelsHubApp.Core.RabbitMQClient.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;

namespace HotelsHubApp.Core.RabbitMQClient.Concrete
{
    public class RabbitMqService : IRabbitMqService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<RabbitMqService> _logger;
        private IConnection _connection;
        private readonly object _lock = new object();

        public RabbitMqService(IConfiguration configuration, ILogger<RabbitMqService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public IConnection GetConnection()
        {
            if (_connection == null || !_connection.IsOpen)
            {
                lock (_lock)
                {
                    if (_connection == null || !_connection.IsOpen)
                    {
                        _connection = CreateConnectionWithRetry();
                    }
                }
            }
            return _connection;
        }

        private IConnection CreateConnectionWithRetry()
        {
            var maxRetries = 15;
            var retryDelay = TimeSpan.FromSeconds(10);
            
            for (int i = 0; i < maxRetries; i++)
            {
                try
                {
                    var factory = new ConnectionFactory()
                    {
                        HostName = _configuration["RabbitMqConnection:HostName"] ?? "localhost",
                        Port = int.Parse(_configuration["RabbitMqConnection:Port"] ?? "5672"),
                        UserName = _configuration["RabbitMqConnection:UserName"] ?? "guest",
                        Password = _configuration["RabbitMqConnection:Password"] ?? "guest",
                        AutomaticRecoveryEnabled = true,
                        NetworkRecoveryInterval = TimeSpan.FromSeconds(10),
                        RequestedHeartbeat = TimeSpan.FromSeconds(60),
                        RequestedConnectionTimeout = TimeSpan.FromSeconds(30),
                        SocketReadTimeout = TimeSpan.FromSeconds(30),
                        SocketWriteTimeout = TimeSpan.FromSeconds(30)
                    };

                    _logger?.LogInformation($"Attempting to connect to RabbitMQ at {factory.HostName}:{factory.Port} (attempt {i + 1}/{maxRetries})...");
                    var connection = factory.CreateConnection();
                    _logger?.LogInformation("Successfully connected to RabbitMQ");
                    return connection;
                }
                catch (Exception ex)
                {
                    _logger?.LogWarning($"Failed to connect to RabbitMQ (attempt {i + 1}/{maxRetries}): {ex.Message}");
                    
                    if (i == maxRetries - 1)
                    {
                        _logger?.LogError($"Failed to connect to RabbitMQ after {maxRetries} attempts");
                        throw;
                    }
                    
                    Thread.Sleep(retryDelay);
                }
            }
            
            throw new Exception("Could not connect to RabbitMQ after multiple attempts");
        }

        public IModel GetModel(IConnection connection)
        {
            return connection.CreateModel();
        }
    }
}