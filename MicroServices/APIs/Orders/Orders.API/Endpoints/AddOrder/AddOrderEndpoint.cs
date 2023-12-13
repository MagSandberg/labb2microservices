using FastEndpoints;
using Orders.DataAccess;
using Order = Orders.DataAccess.Order;

namespace Orders.API.Endpoints.AddOrder;

public class AddOrderEndpoint(IOrderRepository orderRepository) : Endpoint<AddOrderRequest, AddOrderResponse>
{
	public override void Configure()
	{
		Post("/add");
		AllowAnonymous();
	}

	public override async Task HandleAsync(AddOrderRequest addOrderRequest, CancellationToken cancellationToken)
	{
		var order = new Order
		{
			CustomerId = addOrderRequest.NewOrder!.CustomerId,
			OrderDate = DateTime.UtcNow,
			OrderDetail = addOrderRequest.NewOrder.OrderDetail.Select(orderDetailDto => new OrderDetail()
			{
				AlbumId = orderDetailDto.AlbumId,
				Quantity = orderDetailDto.Quantity,
			}),
			TotalAmount = addOrderRequest.NewOrder.TotalAmount
		};

		await orderRepository.AddAsync(order);

		await SendAsync(new AddOrderResponse(), cancellation: cancellationToken);
	}
}