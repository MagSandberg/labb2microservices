using Domain.Common.DTOs;

namespace Customers.API.Endpoints.GetAll;

public class GetAllResponse
{
    public IEnumerable<CustomerDto>? Customers { get; set; }
}