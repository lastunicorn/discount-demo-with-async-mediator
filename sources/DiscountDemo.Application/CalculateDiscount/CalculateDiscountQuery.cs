using DiscountDemo.Domain;
using AsyncMediator;
using DiscountDemo.Port.DataAccess;
using DiscountDemo.Application.Errors;

namespace DiscountDemo.Application.CalculateDiscount;

internal class CalculateDiscountQuery : IQuery<CalculateDiscountCriteria, CalculateDiscountResponse>
{
    private readonly ICustomerRepository customerRepository;

    public CalculateDiscountQuery(ICustomerRepository customerRepository)
    {
        this.customerRepository = customerRepository;
    }

    public async Task<CalculateDiscountResponse> Query(CalculateDiscountCriteria calculateDiscountCriteria)
    {
        if (calculateDiscountCriteria.PurchaseAmount < 0)
            throw new InvalidPriceException(calculateDiscountCriteria.PurchaseAmount);

        Customer customer = await customerRepository.GetCustomer(calculateDiscountCriteria.CustomerId);

        if (customer == null)
            throw new CustomerDoesNotExistException(calculateDiscountCriteria.CustomerId);

        Discount discount = CalculateDiscount(calculateDiscountCriteria, customer);

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
