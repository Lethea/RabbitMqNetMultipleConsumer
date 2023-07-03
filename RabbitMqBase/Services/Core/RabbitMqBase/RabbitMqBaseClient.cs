using RabbitMQ.Client;
using RabbitMqBase.Model;

namespace RabbitMqBase.Services.Core.RabbitMqBase
{
    public class RabbitMqBaseClient
    {
        private IConnection _connection;
        private readonly ConnectionFactory _connectionFactory;
        protected IModel Channel;
        private readonly RabbitMqConnectionInfo _connectionInfo;
        protected RabbitMqBaseClient(RabbitMqConnectionInfo connectionInfo)
        {
            _connectionInfo = connectionInfo;
            _connectionFactory ??= new ConnectionFactory()
            {
                HostName = connectionInfo.Hostname,
                Port = connectionInfo.Port,
                UserName = connectionInfo.Username,
                Password = connectionInfo.Password,
            };
            ConnectToRabbit();
        }
        private void ConnectToRabbit()
        {
            if (_connection == null || _connection.IsOpen == false)
            {
                _connection = _connectionFactory.CreateConnection();
            }

            if (Channel == null || Channel.IsOpen == false)
            {
                Channel = _connection.CreateModel();
            }
        }

        protected void DeclareQueue(string queueName, bool durable = true)
        {
            Channel.QueueDeclare(queue: queueName, durable: durable, exclusive: false, autoDelete: false);
        }

        public void Dispose()
        {
            try
            {
                Channel?.Close();
                Channel?.Dispose();
                Channel = null;

                _connection?.Close();
                _connection?.Dispose();
                _connection = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Dispose error {ex.Message}");
            }
        }

    }
}
