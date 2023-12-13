using Domain.Common.Interfaces;
using MongoDB.Bson;

namespace Orders.DataAccess;

public class OrderDetail : IEntity<ObjectId>
{
	public ObjectId Id { get; init; }
	public string AlbumId { get; init; }
	public int Quantity { get; init; }
}