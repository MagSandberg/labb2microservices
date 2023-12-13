using FastEndpoints;
using Customers.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFastEndpoints();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//}

app.UseHttpsRedirection();
app.UseRouting();

app.UseFastEndpoints();

app.Run();