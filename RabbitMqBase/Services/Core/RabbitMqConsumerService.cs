using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMqBase.Model;
using RabbitMqBase.Services.Core.RabbitMqBase;

namespace RabbitMqBase.Services.Core
{
    // MULTIPLE RABBIT MQ CONSUMER HANDLED BY THIS CLASS
    public class RabbitMqConsumerService : RabbitMqBaseConsumer
    {
        private readonly RabbitMqConnectionInfo _connectionInfo;
        public RabbitMqConsumerService(RabbitMqConnectionInfo connectionInfo) : base(connectionInfo)
        {
            _connectionInfo = connectionInfo;
        }

        public Task StartListening(int i, string queueName)
        {
            DeclareQueue(queueName);
            var consumer = new EventingBasicConsumer(Channel);
            consumer.Received += (sender, args) => OnEventReceived<SendEvent>(sender, args, i.ToString());
            Channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);

            /* OR YOU CAN LISTEN HERE
             
              consumer.Received += (sender, args) =>
                {
                    var body = args.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine("Received message: {0}", message);

                    // Acknowledge the message
                    channel.BasicAck(args.DeliveryTag, multiple: false);
                };
             */
            Console.WriteLine($" Rabbit Mq Consumer {i} Started");
            return Task.CompletedTask;
        }
    }
}
