using System.Text;
using Customers.API.Services.Interfaces;
using Domain.Common.RabbitMq;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;

namespace Customers.API.Services;

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
        var consumer = new AsyncEventingBasicConsumer(_channel);
        consumer.Received += async (sender, e) =>
        {
            var body = e.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            //Add deserialize logic for DTOs here
            Console.WriteLine($"Message received: {message}");
            await Task.CompletedTask;
            _channel.BasicAck(e.DeliveryTag, false);
        };

        _channel.BasicConsume(QueueName, false, consumer);
    }

    public void Dispose()
    {
        if (_channel.IsOpen) { _channel.Close(); }
        if (_connection.IsOpen) { _connection.Close(); }
    }
}