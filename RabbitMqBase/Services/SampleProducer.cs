using Microsoft.Extensions.Options;
using RabbitMqBase.Model;
using RabbitMqBase.Services.Core.RabbitMqBase;

namespace RabbitMqBase.Services
{
    public class SampleProducer: ISampleProducer
    {
        private readonly RabbitMqConnectionInfo _connectionInfo;

        public SampleProducer(IOptionsMonitor<RabbitMqConnectionInfo> connectionInfo)
        {
            _connectionInfo = connectionInfo.CurrentValue;
        }

        public void SendMessage<T>(string queueName, T message)
        {
            var producer = new RabbitMqBaseProducer(_connectionInfo);
            producer.SendMessage(queueName, message);
        }
    }
}
