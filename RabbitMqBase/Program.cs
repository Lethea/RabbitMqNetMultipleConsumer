
using Microsoft.Extensions.Configuration;
using RabbitMqBase.Model;
using RabbitMqBase.Services;
using RabbitMqBase.Services.Core;

namespace RabbitMqBase
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.Configure<RabbitMqConnectionInfo>(builder.Configuration.GetSection(nameof(RabbitMqConnectionInfo)));
            builder.Services.AddHostedService<RabbitMqClientGeneratorHostedService>();
            builder.Services.AddTransient<ISampleProducer,SampleProducer>();
            builder.Services.AddSingleton<IRabbitInstance, RabbitProducerInstance>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}