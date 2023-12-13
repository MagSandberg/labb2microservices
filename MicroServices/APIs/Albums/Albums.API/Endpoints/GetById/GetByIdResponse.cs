using Domain.Common.DTOs;

namespace Albums.API.Endpoints.GetById;

public class GetByIdResponse
{
    public AlbumDto? Album { get; init; }
}