using DiscountDemo.Domain;
using AsyncMediator;
using DiscountDemo.Port.DataAccess;

namespace DiscountDemo.Application.CalculateDiscount;

internal class CalculateDiscountQuery : IQuery<CalculateDiscountCriteria, CalculateDiscountResponse>
{
    private readonly ICustomerRepository customerRepository;

    public CalculateDiscountQuery(ICustomerRepository customerRepository)
    {
        this.customerRepository = customerRepository;
    }

    public async Task<CalculateDiscountResponse> Query(CalculateDiscountCriteria discountRequest)
    {
        Customer customer = await customerRepository.GetCustomer(discountRequest.CustomerId);

        if (customer == null)
            throw new CustomerDoesNotExistException(discountRequest.CustomerId);

        Discount discount = CalculateDiscount(discountRequest, customer);

        return new CalculateDiscountResponse
        {
            DiscountPercentage = discount.DiscountPercentage,
            DiscountAmount = discount.DiscountAmount
        };
    }

    private static Discount CalculateDiscount(CalculateDiscountCriteria discountRequest, Customer customer)
    {
        Discount discount = new(customer, discountRequest.PurchaseAmount);
        discount.Calculate();
        
        return discount;
    }
}
