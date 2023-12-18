using RabbitMQ.Client;
namespace Customers.API.Services.Interfaces;

public interface IRabbitMqService
{
    IConnection CreateConnection();
}