using Domain.Common.RabbitMq;

namespace Albums.API.BackgroundServices;

public class MessageConsumerHostedService(IMessageConsumerService consumerService) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken ct)
    {
        await consumerService.ReadMessagesAsync();
    }
}