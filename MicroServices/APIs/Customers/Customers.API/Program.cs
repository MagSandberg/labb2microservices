using FastEndpoints;
using Customers.DataAccess;
using Customers.API.BackgroundServices;
using Customers.API.Services.Interfaces;
using Customers.API.Services;
using Domain.Common.RabbitMq;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFastEndpoints();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();


builder.Services.AddSingleton(sp => new RabbitMqConfiguration()
{
    HostName = "rabbitmq",
    Username = "guest",
    Password = "guest"
});

builder.Services.AddSingleton<IRabbitMqService, RabbitMqService>();
builder.Services.AddSingleton<IMessageConsumerService, MessageConsumerService>();
builder.Services.AddHostedService<MessageConsumerHostedService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.UseFastEndpoints();

app.Run();