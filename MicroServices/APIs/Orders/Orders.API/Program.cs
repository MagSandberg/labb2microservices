using FastEndpoints;
using Orders.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFastEndpoints();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.UseFastEndpoints();

app.Run();
