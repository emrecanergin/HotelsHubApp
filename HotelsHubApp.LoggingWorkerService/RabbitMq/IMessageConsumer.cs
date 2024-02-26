using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsHubApp.LoggingWorkerService.RabbitMq
{
    public interface IMessageConsumer
    {
        void Consume(string queueName,LogLevel logLevel);
    }
}
