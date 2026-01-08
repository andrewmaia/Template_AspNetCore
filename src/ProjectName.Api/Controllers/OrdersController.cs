using Microsoft.AspNetCore.Mvc;
using ProjectName.Api.Requests;
using ProjectName.Application.UsesCases;

namespace ProjectName.Api.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly CreateOrderUseCase _useCase;

    public OrdersController(CreateOrderUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderRequest request)
    {
        var orderId = await _useCase.ExecuteAsync(
            request.TotalAmount
        );

        return Created(string.Empty, orderId);
    }

}
