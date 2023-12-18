using Customers.API.Services.Interfaces;
using Domain.Common.RabbitMq;
using RabbitMQ.Client;

namespace Customers.API.Services;

public class RabbitMqService(RabbitMqConfiguration config) : IRabbitMqService
{
    public IConnection CreateConnection()
    {
        var connectionFactory = new ConnectionFactory
        {
            HostName = config.HostName,
            UserName = config.Username,
            Password = config.Password,
            VirtualHost = "/",
            DispatchConsumersAsync = true
        };

        var connection = connectionFactory.CreateConnection();
        return connection;
    }
}