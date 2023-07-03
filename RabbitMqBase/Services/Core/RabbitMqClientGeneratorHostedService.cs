using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMqBase.Model;

namespace RabbitMqBase.Services.Core
{
    //OPTIONSTAKI CONSUMER COUNT KADAR CONSUMER GENERATE EDER
    public class RabbitMqClientGeneratorHostedService : IHostedService
    {
        private readonly ILogger _logger;
        private RabbitMqConnectionInfo _connectionInfo;
        List<RabbitMqConsumerService> _listeners = new List<RabbitMqConsumerService>();
        public RabbitMqClientGeneratorHostedService(ILogger<RabbitMqClientGeneratorHostedService> logger, IOptionsMonitor<RabbitMqConnectionInfo> rabbitMqConnectionInfoMonitor)
        {
            _connectionInfo = rabbitMqConnectionInfoMonitor.CurrentValue;
            _logger = logger;
            try
            {
                for (var i = 0; i < rabbitMqConnectionInfoMonitor.CurrentValue.ConsumerCount; i++)
                {
                    var consumerListener = new RabbitMqConsumerService(_connectionInfo);
                    _listeners.Add(consumerListener);
                    var listenerIndex = i;
                    Task.Run(() => consumerListener.StartListening(listenerIndex, "TestQueue"));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

        }

        public virtual Task StartAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        public virtual Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
