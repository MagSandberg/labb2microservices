﻿using Albums.DataAccess.Repositories.Interfaces;
using Domain.Common.DTOs;
using FastEndpoints;

namespace Albums.API.Endpoints.GetById;

public class GetByIdEndpoint(IAlbumRepository repository) : Endpoint<GetByIdRequest, GetByIdResponse>
{
    public override void Configure()
    {
        Get("/get-by-id/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetByIdRequest getByIdRequest, CancellationToken ct)
    {
        var album = await repository.GetByIdAsync(getByIdRequest.Id);

        await SendAsync(new GetByIdResponse()
        {
            Album = new AlbumDto
            (
                album.Title,
                album.Artist,
                album.Genre,
                album.Tracks,
                album.Price
            )
        }, cancellation: ct);
    }
}