using System.Text;
using System.Text.Json;
using Domain.Common.RabbitMq;
using RabbitMQ.Client;

namespace Albums.API.Services;

public class MessageProducerService(RabbitMqConfiguration config) : IMessageProducerService
{
    private readonly ConnectionFactory _connectionFactory = new()
    {
        HostName = config.HostName,
        UserName = config.Username,
        Password = config.Password,
        VirtualHost = "/"
    };

    public async Task SendMessageAsync<T>(T message)
    {
        var connection = _connectionFactory.CreateConnection();
        using var channel = connection.CreateModel();
        channel.QueueDeclare("albumsQueue", durable: true, exclusive: false);

        var jsonString = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(jsonString);

        channel.BasicPublish("", "albumsQueue", body: body);
    }
}