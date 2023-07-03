using Microsoft.AspNetCore.Mvc;
using RabbitMqBase.Model;
using RabbitMqBase.Services;

namespace RabbitMqBase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProduceController : ControllerBase
    {
        private readonly ILogger<ProduceController> _logger;
        private readonly ISampleProducer _producerService;

        public ProduceController(ILogger<ProduceController> logger, ISampleProducer producerService)
        {
            _logger = logger;
            _producerService = producerService;
        }

        [HttpGet("{queueName}")]

        public bool Get(string queueName)
        {
            
            var testEvent = new SendEvent()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Emre",
                Description = "Here",
                CreateDate = DateTime.UtcNow
            };;
            _producerService.SendMessage(queueName,testEvent);
            return true;
        }
    }
}