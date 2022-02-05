using HotelsHubApp.Core.RabbitMQClient.Abstract;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;


namespace HotelsHubApp.Core.RabbitMQClient.Concrete
{
    public class RabbitMqService : IRabbitMqService
    {
        public IConnection GetConnection()
        {
            try
            {
                var factory = new ConnectionFactory()
                {
                    Uri = new Uri("amqps://kmisbyko:N-7sc2g8imP7VK1RaEHUaS7nS-5GABjI@eagle.rmq.cloudamqp.com/kmisbyko"),
                };

                return factory.CreateConnection();
            }
            catch (BrokerUnreachableException)
            {
               // return GetConnection();
                throw new Exception("rabbitmq");
            }
        }

        public IModel GetModel(IConnection connection)
        {
            return GetConnection().CreateModel();
        }
    }
}
