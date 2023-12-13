using Domain.Common.DTOs;
using FastEndpoints;
using MongoDB.Bson;
using Orders.DataAccess;

namespace Orders.API.Endpoints.GetById;

public class GetByIdEndpoint(IOrderRepository orderRepository) : Endpoint<GetByIdRequest, GetByIdResponse>
{
	public override void Configure()
	{
		Get("/{OrderId}");
		AllowAnonymous();
	}

	public override async Task HandleAsync(GetByIdRequest getByIdRequest, CancellationToken cancellationToken)
	{
		var order = await orderRepository.GetByIdAsync(ObjectId.Parse(getByIdRequest.OrderId));

		await SendAsync(
			new GetByIdResponse()
			{
				Order = 
					new OrderDto(
						order.CustomerId,
						order.OrderDate,
						order.OrderDetail.Select(o => new OrderDetailDto(o.AlbumId,o.Quantity)),
						order.TotalAmount
					)
			}, cancellation: cancellationToken);
	}
}