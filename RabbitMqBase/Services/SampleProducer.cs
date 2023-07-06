using Microsoft.Extensions.Options;
using RabbitMqBase.Model;
using RabbitMqBase.Services.Core.RabbitMqBase;

namespace RabbitMqBase.Services
{
    public class SampleProducer: ISampleProducer
    {
        private readonly IRabbitInstance _producerInstance;

        public SampleProducer(IRabbitInstance producerInstance)
        {
            _producerInstance = producerInstance;
        }

        public void SendMessage<T>(string queueName, T message)
        {
            _producerInstance.GetProducer().SendMessage(queueName, message);
        }
    }
}
