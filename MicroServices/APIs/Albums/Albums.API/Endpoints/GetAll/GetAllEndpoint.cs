using Albums.DataAccess.Repositories.Interfaces;
using Domain.Common.DTOs;
using FastEndpoints;

namespace Albums.API.Endpoints.GetAll;

public class GetAllEndpoint(IAlbumRepository repository) : Endpoint<GetAllRequest, GetAllResponse>
{
    public override void Configure()
    {
        Get("/get-all");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetAllRequest getAllRequest, CancellationToken ct)
    {
        var allAlbums = await repository.GetAllAsync();
        var dtos = allAlbums.Select(
            album => 
                new AlbumDto(
                    album.Title,
                    album.Artist,
                    album.Genre,
                    album.Tracks.Select(t => new TrackDto(t.Name, t.Artist, t.Length)),
                    album.Price
                    )
            );

        await SendAsync(
           new GetAllResponse()
           {
               Albums = dtos
           },
           cancellation: ct
       );
    }
}