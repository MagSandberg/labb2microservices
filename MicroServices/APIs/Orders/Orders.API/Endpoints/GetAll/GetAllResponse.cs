using Domain.Common.DTOs;

namespace Orders.API.Endpoints.GetAll;

public class GetAllResponse
{
	public IEnumerable<OrderDto>? Orders { get; set; }
}