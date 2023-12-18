using System.Text;
using Customers.API.Services.Interfaces;
using Domain.Common.RabbitMq;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;

namespace Customers.API.Services;

public class MessageConsumerService : IMessageConsumerService, IDisposable
{
    private const string AlbumsQueue = "albumsQueue";
    private const string OrdersQueue = "ordersQueue";
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public MessageConsumerService(IRabbitMqService rabbitMqService)
    {
        _connection = rabbitMqService.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.QueueDeclare(AlbumsQueue, durable: true, exclusive: false);
        _channel.ExchangeDeclare("albumsExchange", ExchangeType.Fanout, durable: true);
        _channel.QueueBind(AlbumsQueue, "albumsExchange", string.Empty);

        _channel.QueueDeclare(OrdersQueue, durable: true, exclusive: false);
        _channel.ExchangeDeclare("ordersExchange", ExchangeType.Fanout, durable: true);
        _channel.QueueBind(OrdersQueue, "ordersExchange", string.Empty);
    }

    public async Task ReadMessagesAsync()
    {
        var albumsConsumer = new AsyncEventingBasicConsumer(_channel);
        albumsConsumer.Received += async (sender, e) =>
        {
            var body = e.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($"Nu finns albumet {message} i lager, kom och köp!");
            await Task.CompletedTask;
            _channel.BasicAck(e.DeliveryTag, false);
        };

        var ordersConsumer = new AsyncEventingBasicConsumer(_channel);
        ordersConsumer.Received += async (sender, e) =>
        {
            var body = e.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            List<string> orderIdLista = new List<string>();
            orderIdLista.Add(message);
            Console.WriteLine($"Skriver ut orderListan: {orderIdLista[0]}");
            await Task.CompletedTask;
            _channel.BasicAck(e.DeliveryTag, false);
        };

        _channel.BasicConsume(AlbumsQueue, false, albumsConsumer);
        _channel.BasicConsume(OrdersQueue, false, ordersConsumer);
    }

    public void Dispose()
    {
        if (_channel.IsOpen) { _channel.Close(); }
        if (_connection.IsOpen) { _connection.Close(); }
    }
}