namespace Domain.Common.DTOs;

public record CustomerDto(
    string Name,
    string Email,
    string Country,
    string City,
    string StreetAddress,
    int PostalCode
    );


