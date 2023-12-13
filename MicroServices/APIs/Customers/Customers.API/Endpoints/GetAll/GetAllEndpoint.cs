using Customers.DataAccess;
using Domain.Common.DTOs;
using FastEndpoints;

namespace Customers.API.Endpoints.GetAll;

public class GetAllEndpoint(ICustomerRepository customerRepository) : Endpoint<GetAllRequest, GetAllResponse>
{
    public override void Configure()
    {
        Get("/");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetAllRequest getAllCustomerRequest, CancellationToken cancellationToken)
    {
        var allCustomers = await customerRepository.GetAllAsync();
        var dtos = allCustomers.Select(
            customer =>
                new CustomerDto(
                    customer.Name,
                    customer.Email,
                    customer.Country,
                    customer.City,
                    customer.StreetAddress,
                    customer.PostalCode)
        );

        await SendAsync(
            new GetAllResponse()
            {
                Customers = dtos
            },
            cancellation: cancellationToken
        );
    }
}