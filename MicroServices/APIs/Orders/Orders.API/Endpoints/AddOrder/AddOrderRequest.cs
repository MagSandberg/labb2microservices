using Domain.Common.DTOs;

namespace Orders.API.Endpoints.AddOrder;

public class AddOrderRequest
{
	public OrderDto? NewOrder { get; set; }
}