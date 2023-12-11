namespace Domain.Common.DTOs;

public record TrackDto(
    string Artist,
    string Name,
    decimal Length
    );