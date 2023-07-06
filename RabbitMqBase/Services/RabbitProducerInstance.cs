using Microsoft.Extensions.Options;
using RabbitMqBase.Model;
using RabbitMqBase.Services.Core.RabbitMqBase;

namespace RabbitMqBase.Services
{
    public class RabbitProducerInstance: IRabbitInstance
    {
        private readonly RabbitMqConnectionInfo _connectionInfo;
        RabbitMqBaseProducer _producer;

        public RabbitProducerInstance(IOptionsMonitor<RabbitMqConnectionInfo> connectionInfo)
        {
            _connectionInfo = connectionInfo.CurrentValue;
            _producer = new RabbitMqBaseProducer(_connectionInfo);
        }

        public RabbitMqBaseProducer GetProducer()
        {
            return _producer;
        }
    }
}
