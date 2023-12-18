using RabbitMQ.Client;

namespace Orders.API.Services.Interfaces;

public interface IRabbitMqService
{
	IConnection CreateConnection();
}