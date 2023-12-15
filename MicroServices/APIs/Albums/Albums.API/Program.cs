using Albums.API.BackgroundServices;
using Albums.API.Services;
using Albums.API.Services.Interfaces;
using FastEndpoints;
using Albums.DataAccess.Repositories;
using Albums.DataAccess.Repositories.Interfaces;
using Domain.Common.RabbitMq;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddFastEndpoints();

builder.Services.AddSingleton(sp => new RabbitMqConfiguration()
{
    HostName = "rabbitmq",
    Username = "guest",
    Password = "guest"
});

builder.Services.AddSingleton<IRabbitMqService, RabbitMqService>();
builder.Services.AddScoped<IMessageProducerService, MessageProducerService>();
builder.Services.AddSingleton<IMessageConsumerService, MessageConsumerService>();
builder.Services.AddHostedService<MessageConsumerHostedService>();

// Middleware pipeline
var app = builder.Build();

app.UseRouting();
app.UseFastEndpoints();
app.Run();
