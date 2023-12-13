namespace Domain.Common.DTOs;

public record OrderDto(
    string CustomerId,
    DateTime OrderDate,
    IEnumerable<OrderDetailDto> OrderDetail,
    decimal TotalAmount
    );