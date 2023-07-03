using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace AnotherConsumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost", 
                Port = 5672, 
                UserName = "admin", 
                Password = "qwe123FF" 
            };

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "TestQueue", durable: true, exclusive: false, autoDelete: false,
                arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                Console.WriteLine("Message received by console app : {0}", message);
            };
            channel.BasicConsume(queue: "TestQueue", autoAck: true, consumer: consumer);

            Console.ReadLine();
        }
    }
}