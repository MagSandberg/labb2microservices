using Customers.DataAccess;
using Domain.Common.DTOs;
using FastEndpoints;
using MongoDB.Bson;

namespace Customers.API.Endpoints.GetById;

public class GetByIdEndpoint(ICustomerRepository customerRepository) : Endpoint<GetByIdRequest, GetByIdResponse>
{
    public override void Configure()
    {
        Get("{customerId}");
    }

    public override async Task HandleAsync(GetByIdRequest getByIdRequest, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetByIdAsync(ObjectId.Parse(getByIdRequest.CustomerId));

        await SendAsync(
            new GetByIdResponse()
            {
                Customer = 
                    new CustomerDto(
                        customer.Name,
                        customer.Email,
                        customer.Country,
                        customer.City,
                        customer.StreetAddress,
                        customer.PostalCode
                    )
            }, cancellation: cancellationToken);
    }
}
