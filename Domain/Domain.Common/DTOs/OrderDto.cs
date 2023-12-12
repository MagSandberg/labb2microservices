namespace Domain.Common.DTOs;

public record OrderDto(
    int CustomerId,
    DateTime OrderDate,
    IEnumerable<OrderDetailDto> OrderDetail,
    decimal TotalAmount
    );