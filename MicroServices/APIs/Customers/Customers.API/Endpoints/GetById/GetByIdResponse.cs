using Domain.Common.DTOs;

namespace Customers.API.Endpoints.GetById;

public class GetByIdResponse
{
    public CustomerDto Customer { get; set; }
}