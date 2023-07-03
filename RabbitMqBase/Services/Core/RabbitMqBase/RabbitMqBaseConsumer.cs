using RabbitMQ.Client.Events;
using RabbitMqBase.Model;
using System.Text;
using Newtonsoft.Json;

namespace RabbitMqBase.Services.Core.RabbitMqBase
{
    public class RabbitMqBaseConsumer : RabbitMqBaseClient
    {
        protected RabbitMqBaseConsumer(RabbitMqConnectionInfo connectionInfo) : base(connectionInfo)
        {

        }
        protected void OnEventReceived<T>(object? sender, BasicDeliverEventArgs eventArgs, string threadIndex)
        {
            try
            {
                Console.WriteLine(threadIndex + " --- ");
                var body = Encoding.UTF8.GetString(eventArgs.Body.ToArray());
                var message = JsonConvert.DeserializeObject<T>(body);
                Console.WriteLine(message.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cant retrieve message from queue {ex.Message}");
            }
            finally
            {
                Channel.BasicAck(eventArgs.DeliveryTag, false);
            }
        }
    }
}
