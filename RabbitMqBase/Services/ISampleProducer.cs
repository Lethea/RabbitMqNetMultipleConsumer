namespace RabbitMqBase.Services
{
    public interface ISampleProducer
    {
        public void SendMessage<T>(string queueName, T message);
    }
}
