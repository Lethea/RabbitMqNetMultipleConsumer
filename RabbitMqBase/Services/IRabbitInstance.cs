using RabbitMqBase.Services.Core.RabbitMqBase;

namespace RabbitMqBase.Services
{
    public interface IRabbitInstance
    {
        public RabbitMqBaseProducer GetProducer();
    }
}
