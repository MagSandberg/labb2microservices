using Domain.Common.DTOs;

namespace Customers.API.Endpoints.Add;

public class AddRequest
{
    public CustomerDto? NewCustomer { get; set; }
}