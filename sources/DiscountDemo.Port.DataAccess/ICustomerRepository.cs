using DiscountDemo.Domain;

namespace DiscountDemo.Port.DataAccess;

public interface ICustomerRepository
{
    Customer GetCustomer(Guid customerId);
}