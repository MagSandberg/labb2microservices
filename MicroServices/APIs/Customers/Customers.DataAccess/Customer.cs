using Domain.Common.Interfaces;
using MongoDB.Bson;

namespace Customers.DataAccess;

public class Customer : IEntity<ObjectId>
{
    public ObjectId Id { get; init; }
    public string Name { get; init; }
    public string Email { get; init; }
    public string Country { get; init; }
    public string City { get; init; }
    public string StreetAddress { get; init; }
    public int PostalCode { get; init; }
}