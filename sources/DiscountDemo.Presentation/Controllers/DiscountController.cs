using AsyncMediator;
using DiscountDemo.Application.Discount;
using Microsoft.AspNetCore.Mvc;

namespace DiscountDemo.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DiscountController : ControllerBase
{
    private readonly IMediator mediator;

    public DiscountController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<DiscountResponseDto> Get(DiscountRequestDto discountRequestDto)
    {
        DiscountCriteria request = new()
        {
            CustomerId = discountRequestDto.CustomerId,
            PurchaseAmount = discountRequestDto.PurchaseAmount
        };
        DiscountResponse response = await mediator.Query<DiscountCriteria, DiscountResponse>(request);

        return new DiscountResponseDto
        {
            DiscountPercentage = response.DiscountPercentage,
            DiscountAmount = response.DiscountAmount
        };
    }
}
