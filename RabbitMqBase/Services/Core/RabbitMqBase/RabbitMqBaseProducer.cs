using System.Text;
using System.Text.Json;
using RabbitMqBase.Model;
using RabbitMQ.Client;

namespace RabbitMqBase.Services.Core.RabbitMqBase
{
    public class RabbitMqBaseProducer : RabbitMqBaseClient
    {
        public RabbitMqBaseProducer(RabbitMqConnectionInfo connectionInfo) : base(connectionInfo)
        {
        }

        public void SendMessage<T>(string queueName, T message)
        {
            DeclareQueue(queueName);
            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);
            Channel.BasicPublish(exchange: "", routingKey: queueName, body: body);
        }

    }
}
