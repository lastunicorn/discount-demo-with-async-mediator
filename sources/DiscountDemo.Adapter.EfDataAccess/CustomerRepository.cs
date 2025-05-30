using DiscountDemo.Domain;
using DiscountDemo.Port.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DiscountDemo.Adapter.EfDataAccess;

public class CustomerRepository : ICustomerRepository
{
    private readonly DiscountDemoDbContext dbContext;

    public CustomerRepository(DiscountDemoDbContext dbContext)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public Task<Customer> GetCustomer(Guid customerId)
    {
        return dbContext.Set<Customer>()
            .FirstOrDefaultAsync(x => x.Id == customerId);
    }
}