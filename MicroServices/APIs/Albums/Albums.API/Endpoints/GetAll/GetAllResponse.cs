using Domain.Common.DTOs;

namespace Albums.API.Endpoints.GetAll;

public class GetAllResponse
{
    public IEnumerable<AlbumDto> Albums { get; set; } = new List<AlbumDto>();
}