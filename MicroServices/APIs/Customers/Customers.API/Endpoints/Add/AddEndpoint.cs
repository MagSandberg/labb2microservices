using FastEndpoints;
using Customers.DataAccess;

namespace Customers.API.Endpoints.Add;

public class AddEndpoint(ICustomerRepository customerRepository) : Endpoint<AddRequest, AddResponse>
{
    public override void Configure()
    {
        Post("add-new-customer");
        AllowAnonymous();
    }

    public override async Task HandleAsync(AddRequest addNewCustomerRequest, CancellationToken cancellationToken)
    {
        var customer = new Customer()
        {
            Name = addNewCustomerRequest.NewCustomer!.Name,
            Email = addNewCustomerRequest.NewCustomer!.Email,
            Country = addNewCustomerRequest.NewCustomer!.Country,
            City = addNewCustomerRequest.NewCustomer!.City,
            StreetAddress = addNewCustomerRequest.NewCustomer!.StreetAddress,
            PostalCode = addNewCustomerRequest.NewCustomer!.PostalCode
        };

        await customerRepository.AddAsync(customer);

        await SendAsync(new AddResponse(), cancellation: cancellationToken);
    }
}