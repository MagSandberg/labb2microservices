using Domain.Common.DTOs;
using FastEndpoints;
using Orders.DataAccess;


namespace Orders.API.Endpoints.GetAll;

public class GetAllEndpoint(IOrderRepository orderRepository) : Endpoint<GetAllRequest, GetAllResponse>
{
	public override void Configure()
	{
		Get("/");
		AllowAnonymous();
	}

	public override async Task HandleAsync(GetAllRequest getAllRequest, CancellationToken cancellationToken)
	{
		var orders = await orderRepository.GetAllAsync();
		var dtos = orders.Select(
			order =>
				new OrderDto(
					order.CustomerId,
					order.OrderDate,
					order.OrderDetail.Select(orderDetail => new OrderDetailDto(orderDetail.AlbumId, orderDetail.Quantity)),
					order.TotalAmount
					));

		await SendAsync(
			new GetAllResponse()
			{
				Orders = dtos
			},
			cancellation: cancellationToken
		);
	}
}