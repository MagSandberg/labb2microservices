using Domain.Common.Interfaces;
using MongoDB.Bson;

namespace Customers.DataAccess;

public interface ICustomerRepository : IGenericRepository<Customer, ObjectId>
{
  
}