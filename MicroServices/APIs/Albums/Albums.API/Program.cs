using Albums.API.Services;
using FastEndpoints;
using Albums.DataAccess.Repositories;
using Albums.DataAccess.Repositories.Interfaces;
using Domain.Common.RabbitMq;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddFastEndpoints();

builder.Services.AddScoped(sp => new RabbitMqConfiguration()
{
    HostName = "rabbitmq",
    Username = "guest",
    Password = "guest"
});

builder.Services.AddScoped<IMessageProducerService, MessageProducerService>();

// Middleware pipeline
var app = builder.Build();

app.UseRouting();
app.UseFastEndpoints();
app.Run();
