using DiscountDemo.Domain;
using DiscountDemo.Port.DataAccess;

namespace DiscountDemo.Adapter.DataAccess;

public class CustomerRepository : ICustomerRepository
{
    public Customer GetCustomer(Guid customerId)
    {
        // Simulate a database lookup
        return new Customer
        {
            Id = customerId,
            Name = "John Doe",
            Type = CustomerType.Premium
        };
    }
}