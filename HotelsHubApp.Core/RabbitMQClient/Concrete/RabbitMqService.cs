using HotelsHubApp.Core.RabbitMQClient.Abstract;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;


namespace HotelsHubApp.Core.RabbitMQClient.Concrete
{
    public class RabbitMqService : IRabbitMqService
    {
        private readonly IConfiguration _configuration;

        public RabbitMqService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConnection GetConnection()
        {
            var factory = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMqConnection:HostName"] ?? "localhost",
                Port = int.Parse(_configuration["RabbitMqConnection:Port"] ?? "5672"),
                UserName = _configuration["RabbitMqConnection:UserName"] ?? "guest",
                Password = _configuration["RabbitMqConnection:Password"] ?? "guest"
            };

            return factory.CreateConnection();          
        }

        public IModel GetModel(IConnection connection)
        {
            return GetConnection().CreateModel();
        }
    }
}