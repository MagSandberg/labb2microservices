using FastEndpoints;
using Albums.DataAccess.Repositories;
using Albums.DataAccess.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddFastEndpoints();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseRouting();
app.UseFastEndpoints();
app.Run();
