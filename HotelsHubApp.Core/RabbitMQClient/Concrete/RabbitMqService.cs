using HotelsHubApp.Core.RabbitMQClient.Abstract;
using RabbitMQ.Client;


namespace HotelsHubApp.Core.RabbitMQClient.Concrete
{
    public class RabbitMqService : IRabbitMqService
    {
        public IConnection GetConnection()
        {
            var factory = new ConnectionFactory()
            {
                Uri = new Uri("amqps://yylkrnyv:6RTO_isewkbQbFHaYtMCQZz-dV_gbkq5@sparrow.rmq.cloudamqp.com/yylkrnyv"),
            };

            return factory.CreateConnection();          
        }

        public IModel GetModel(IConnection connection)
        {
            return GetConnection().CreateModel();
        }
    }
}