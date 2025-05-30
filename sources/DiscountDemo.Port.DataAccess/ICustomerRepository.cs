using DiscountDemo.Domain;

namespace DiscountDemo.Port.DataAccess;

public interface ICustomerRepository
{
    Task<Customer> GetCustomer(Guid customerId);
}