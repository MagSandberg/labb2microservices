using Domain.Common.Interfaces;
using MongoDB.Bson;

namespace Orders.DataAccess;

public interface IOrderRepository : IGenericRepository<Order, ObjectId>
{
	
}