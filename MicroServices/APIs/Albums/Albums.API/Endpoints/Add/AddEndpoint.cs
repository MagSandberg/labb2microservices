using Albums.DataAccess.Repositories.Interfaces;
using Albums.DataAccess.Models;
using FastEndpoints;
using Domain.Common.RabbitMq;

namespace Albums.API.Endpoints.Add;

public class AddEndpoint(IAlbumRepository repository, IMessageProducerService messageProducer) : Endpoint<AddRequest, AddResponse>
{
    public override void Configure()
    {
        Post("/add");
        AllowAnonymous();
    }

    public override async Task HandleAsync(AddRequest addRequest, CancellationToken ct)
    {
        var tracks = addRequest.AddAlbum.Tracks.Select(t => new Track
        {
            Artist = t.Artist,
            Name = t.Name,
            Length = t.Length
        });

        await repository.AddAsync(new Album()
        {
            Title = addRequest.AddAlbum!.Title,
            Artist = addRequest.AddAlbum.Artist,
            Genre = addRequest.AddAlbum.Genre,
            Tracks = tracks,
            Price = addRequest.AddAlbum.Price
        });

        await messageProducer.SendMessageAsync(addRequest.AddAlbum.Title);

        await SendAsync(new AddResponse()
        {

        }, cancellation: ct);
    }
}