using Domain.Common.RabbitMq;
using FastEndpoints;
using Orders.API.Services.Interfaces;
using Orders.API.Services;
using Orders.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFastEndpoints();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddSingleton(sp => new RabbitMqConfiguration()
{
	HostName = "rabbitmq",
	Username = "guest",
	Password = "guest"
});

builder.Services.AddSingleton<IRabbitMqService, RabbitMqService>();
builder.Services.AddScoped<IMessageProducerService, MessageProducerService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.UseFastEndpoints();

app.Run();
