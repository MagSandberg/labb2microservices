using Domain.Common.Enums;

namespace Domain.Common.DTOs;

public record AlbumDto(
        string Title,
        string Artist,
        Genre Genre,
        IEnumerable<TrackDto> Tracks,
        decimal Price
            );