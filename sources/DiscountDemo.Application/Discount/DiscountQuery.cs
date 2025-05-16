using DiscountDemo.Domain;
using AsyncMediator;
using DiscountDemo.Port.DataAccess;

namespace DiscountDemo.Application.Discount;

internal class DiscountQuery : IQuery<DiscountCriteria, DiscountResponse>
{
    private readonly ICustomerRepository customerRepository;

    public DiscountQuery(ICustomerRepository customerRepository)
    {
        this.customerRepository = customerRepository;
    }

    public Task<DiscountResponse> Query(DiscountCriteria discountRequest)
    {
        Customer customer = customerRepository.GetCustomer(discountRequest.CustomerId);
        float discountPercentage = CalculateDiscountPercentage(customer.Type);
        float discountValue = CalculateDiscountAmount(discountRequest.PurchaseAmount, discountPercentage);

        DiscountResponse response = new()
        {
            DiscountPercentage = discountPercentage,
            DiscountAmount = discountValue
        };

        return Task.FromResult(response);
    }

    private static float CalculateDiscountPercentage(CustomerType customerType)
    {
        return customerType switch
        {
            CustomerType.Regular => 0f,
            CustomerType.Premium => 0.05f,
            CustomerType.VIP => 0.10f,
            _ => throw new InvalidCustomerTypeException(customerType)
        };
    }

    private static float CalculateDiscountAmount(float purchaseAmount, float discountPercentage)
    {
        return purchaseAmount * discountPercentage;
    }

    // todo: Create a domain entity called Discount.
}
