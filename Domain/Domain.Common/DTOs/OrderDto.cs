namespace Domain.Common.DTOs;

public record OrderDto(
    CustomerDto Customer,
    DateTime OrderDate,
    IEnumerable<OrderDetailDto> OrderDetail,
    decimal TotalAmount
    );