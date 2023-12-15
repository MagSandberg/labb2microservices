using RabbitMQ.Client;

namespace Albums.API.Services.Interfaces;

public interface IRabbitMqService
{
    IConnection CreateChannel();
}