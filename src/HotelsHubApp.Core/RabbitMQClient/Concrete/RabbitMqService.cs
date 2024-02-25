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
                Uri = new Uri("amqps://bjqbnuye:n9x2pOag6o02NNWVu0evb3krFnrqGnFx@cow.rmq2.cloudamqp.com/bjqbnuye"),
            };

            return factory.CreateConnection();          
        }

        public IModel GetModel(IConnection connection)
        {
            return GetConnection().CreateModel();
        }
    }
}