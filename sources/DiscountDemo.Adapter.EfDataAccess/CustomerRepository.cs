using DiscountDemo.Domain;
using DiscountDemo.Port.DataAccess;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DiscountDemo.Adapter.EfDataAccess;

public class CustomerRepository : ICustomerRepository
{
    private readonly DiscountDemoDbContext dbContext;

    public CustomerRepository(DiscountDemoDbContext dbContext)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<Customer> GetCustomer(Guid customerId)
    {
        try
        {
            return await dbContext.Set<Customer>()
                .FirstOrDefaultAsync(x => x.Id == customerId);
        }
        catch (SqlException ex)
        {
            throw new DataAccessException($"An error occurred while retrieving the customer with ID {customerId} from the database.", ex);
        }
    }
}