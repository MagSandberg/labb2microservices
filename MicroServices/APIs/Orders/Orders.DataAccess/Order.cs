using Domain.Common.Interfaces;
using MongoDB.Bson;

namespace Orders.DataAccess;

public class Order : IEntity<ObjectId>
{ 
	public ObjectId Id { get; init; }
	public string CustomerId { get; init; }
	public DateTime OrderDate { get; init; }
	public IEnumerable<OrderDetail> OrderDetail { get; init; }
	public decimal TotalAmount { get; set; }
}