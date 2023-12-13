using Domain.Common.DTOs;

namespace Albums.API.Endpoints.Add;

public class AddRequest
{
    public AlbumDto? AddAlbum { get; set; }
}