using Domain.Common.DTOs;

namespace Orders.API.Endpoints.GetById;

public class GetByIdResponse
{
	public OrderDto Order { get; set; }
}