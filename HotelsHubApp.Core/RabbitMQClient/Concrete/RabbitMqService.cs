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
                Uri = new Uri("amqps://owrlcjfq:58iV5Fwb0v0nUb8ec2Q52N_ob7EkwYhf@cow.rmq2.cloudamqp.com/owrlcjfq"),
            };

            return factory.CreateConnection();          
        }

        public IModel GetModel(IConnection connection)
        {
            return GetConnection().CreateModel();
        }
    }
}