using AsyncMediator;
using DiscountDemo.Application.CalculateDiscount;
using DiscountDemo.Presentation.Models;
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
        CalculateDiscountCriteria request = new()
        {
            CustomerId = discountRequestDto.CustomerId,
            PurchaseAmount = discountRequestDto.PurchaseAmount
        };
        CalculateDiscountResponse response = await mediator.Query<CalculateDiscountCriteria, CalculateDiscountResponse>(request);

        return new DiscountResponseDto
        {
            DiscountPercentage = response.DiscountPercentage,
            DiscountAmount = response.DiscountAmount
        };
    }
}
