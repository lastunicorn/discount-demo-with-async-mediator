using DiscountDemo.Domain;
using DiscountDemo.Port.DataAccess;

namespace DiscountDemo.Adapter.InMemoryDataAccess;

public class CustomerRepository : ICustomerRepository
{
    public Task<Customer> GetCustomer(Guid customerId)
    {
        Customer customer = DatabaseFake.Customers
            .FirstOrDefault(x => x.Id == customerId);

        return Task.FromResult(customer);
    }
}
