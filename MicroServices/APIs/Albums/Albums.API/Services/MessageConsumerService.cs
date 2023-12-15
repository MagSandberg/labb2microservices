using Albums.API.Services.Interfaces;
using Domain.Common.RabbitMq;
using RabbitMQ.Client;

namespace Albums.API.Services;

public class MessageConsumerService : IMessageConsumerService, IDisposable
{
    private const string QueueName = "albumsQueue";
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public MessageConsumerService(IRabbitMqService rabbitMqService)
    {
        _connection = rabbitMqService.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.QueueDeclare(QueueName, durable: true, exclusive: false);
        _channel.ExchangeDeclare("albumsExchange", ExchangeType.Fanout, durable: true);
        _channel.QueueBind(QueueName, "albumsExchange", string.Empty);
    }

    public async Task ReadMessagesAsync()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        if (_channel.IsOpen) { _channel.Close(); }
        if (_connection.IsOpen) { _connection.Close(); }
    }
}