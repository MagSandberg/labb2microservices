using Domain.Common.Enums;
using MongoDB.Bson;

namespace Domain.Common.DTOs;

public record AlbumDto(
        string Title,
        string Artist,
        Genre Genre,
        IEnumerable<TrackDto> Tracks,
        decimal Price
            );